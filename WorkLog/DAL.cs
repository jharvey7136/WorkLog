using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using Microsoft.Extensions.Logging;
using System.IO.Compression;

namespace WorkLog
{
    public class DAL
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public void FillComboBox(string cmd, ComboBox cb, string strDisplay, string strValue)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                using (SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd, con))
                {
                    //Fill the DataTable with records from Table.
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    //Insert the Default Item to DataTable.
                    DataRow row = dt.NewRow();
                    row[0] = 0;
                    row[1] = "";
                    dt.Rows.InsertAt(row, 0);

                    //Assign DataTable as DataSource.
                    cb.DataSource = dt;
                    cb.DisplayMember = strDisplay;
                    cb.ValueMember = strValue;
                }
            }
        }

        public void FillDataGrid(string cmd, DataGridView dgv)
        {
            dgv.DataSource = CreateDataTable(cmd);
        }

        public static DataTable CreateDataTable(string cmd)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                using (SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd, con))
                {
                    //Fill the DataTable with records from Table.
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
        }



        public bool BackupDB()
        {
            try
            {
                string now = DateTime.Now.ToString("yyyyMMddHHmmss");
                string strFilename = "WorkLog_" + now + ".db";
                string backupConnection = @"DataSource=..\..\..\db\" + strFilename + ";Version=3;";

                string fullPathNew = Path.GetFullPath(@"..\..\..\db\" + strFilename);
                string fullPathCurr;

                using (SQLiteConnection dest = new SQLiteConnection(backupConnection))
                using (SQLiteConnection src = new SQLiteConnection(LoadConnectionString()))
                {
                    dest.Open();
                    src.Open();
                    src.BackupDatabase(dest, "main", "main", -1, null, 0);
                }

                foreach (var fi in new DirectoryInfo(@"..\..\..\db").GetFiles().OrderByDescending(x => x.LastWriteTime).Skip(1))
                {
                    fullPathCurr = Path.GetFullPath(fi.FullName);

                    if (FileCompare(fullPathNew, fullPathCurr))
                    {
                        fi.Delete();
                        logger.Info("Duplicate backup database deleted: {0}", fi.FullName);
                    }

                }

                //DeleteOldestBackups();
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
                return false;
            }
        }

        public void ArchiveBackups(int daysOld)
        {
            string now = DateTime.Now.ToString("yyyyMMddmmss");
            string strFilename = "WorkLog_" + now + ".zip";
            string zipPath = Path.GetFullPath(@"..\..\..\db\Archive\" + strFilename);
            int i = 0;

            try
            {
                using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
                {
                    foreach (var fi in new DirectoryInfo(@"..\..\..\db").GetFiles().OrderBy(x => x.LastWriteTime))
                    {
                        if (fi.LastWriteTime < DateTime.Now.AddDays(daysOld))
                        {
                            zip.CreateEntryFromFile(fi.FullName, fi.Name);
                            fi.Delete();
                            i++;
                        }                        
                    }
                }
                logger.Info("Database archive count: {0}, zip file: {1} ", i.ToString(), zipPath);
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }

        }

        public void InsertRecord(Record record, bool isReimburse)
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
                {
                    string insertSQL = @"INSERT INTO Record (Client, ProService, Task, Item, Date, StartTime, " +
                    "EndTime, Hours, ReimbursableCost, Description, CreateDate) " +
                    "VALUES (@Client, @ProService, @Task, @Item, @Date, @StartTime, @EndTime, @Hours, @ReimbursableCost, " +
                    "@Description, @CreateDate)";

                    con.Open();

                    SQLiteCommand cmd = new SQLiteCommand(insertSQL, con);

                    cmd.Parameters.Add("@Client", DbType.String).Value = record.Client;
                    cmd.Parameters.Add("@ProService", DbType.String).Value = record.ProService;
                    cmd.Parameters.Add("@Task", DbType.String).Value = record.Task;
                    cmd.Parameters.Add("@Item", DbType.String).Value = record.Item;
                    cmd.Parameters.Add("@Date", DbType.String).Value = record.Date.ToString("yyyy-MM-dd");

                    if (isReimburse == true)
                    {
                        cmd.Parameters.Add("@StartTime", DbType.String).Value = "";
                        cmd.Parameters.Add("@EndTime", DbType.String).Value = "";
                        cmd.Parameters.Add("@Hours", DbType.String).Value = "";
                        cmd.Parameters.Add("@ReimbursableCost", DbType.String).Value = record.ReimburseAmount.ToString();
                    }
                    else
                    {
                        cmd.Parameters.Add("@StartTime", DbType.String).Value = record.StartTime.ToString("h:mm tt");
                        cmd.Parameters.Add("@EndTime", DbType.String).Value = record.EndTime.ToString("h:mm tt");
                        cmd.Parameters.Add("@Hours", DbType.String).Value = record.TotalHours.ToString();
                        cmd.Parameters.Add("@ReimbursableCost", DbType.String).Value = "0";
                    }

                    cmd.Parameters.Add("@Description", DbType.String).Value = record.Description;
                    cmd.Parameters.Add("@CreateDate", DbType.String).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
        }

        public void DeleteRecord(string strRowID)
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
                {
                    string deleteSql = @"DELETE FROM Record WHERE RowID = " + strRowID;
                    con.Open();
                    SQLiteCommand cmd = new SQLiteCommand(deleteSql, con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
        }

        public void UpdateClient(DataGridView dgv)
        {
            try
            {
                if (BackupDB())
                {
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells["ClientID"].Value != null)
                        {
                            if (row.Cells["ClientID"].Value.ToString() == "")
                            {
                                string sqlInsert = "INSERT INTO Client(ClientName, AddressLine1, AddressLine2, City, State, Zip) VALUES(@name, @a1, @a2, @city, @state, @zip)";
                                using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
                                {
                                    using (SQLiteCommand cmd = new SQLiteCommand(sqlInsert, con))
                                    {
                                        cmd.Parameters.Add("@name", DbType.String).Value = row.Cells["ClientName"].Value;
                                        cmd.Parameters.Add("@a1", DbType.String).Value = row.Cells["AddressLine1"].Value;
                                        cmd.Parameters.Add("@a2", DbType.String).Value = row.Cells["AddressLine2"].Value;
                                        cmd.Parameters.Add("@city", DbType.String).Value = row.Cells["City"].Value;
                                        cmd.Parameters.Add("@state", DbType.String).Value = row.Cells["State"].Value;
                                        cmd.Parameters.Add("@zip", DbType.String).Value = row.Cells["Zip"].Value;
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            else
                            {
                                string sql = "UPDATE Client SET ClientName = @name, AddressLine1 = @a1, AddressLine2 = @a2, City = @city, State = @state, Zip = @zip WHERE ClientID = @ID";
                                using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
                                {
                                    using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                                    {
                                        cmd.Parameters.Add("@ID", DbType.String).Value = row.Cells["ClientID"].Value;
                                        cmd.Parameters.Add("@name", DbType.String).Value = row.Cells["ClientName"].Value;
                                        cmd.Parameters.Add("@a1", DbType.String).Value = row.Cells["AddressLine1"].Value;
                                        cmd.Parameters.Add("@a2", DbType.String).Value = row.Cells["AddressLine2"].Value;
                                        cmd.Parameters.Add("@city", DbType.String).Value = row.Cells["City"].Value;
                                        cmd.Parameters.Add("@state", DbType.String).Value = row.Cells["State"].Value;
                                        cmd.Parameters.Add("@zip", DbType.String).Value = row.Cells["Zip"].Value;
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
        }

        public void UpdateProService(DataGridView dgv)
        {
            try
            {
                if (BackupDB())
                {
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells["ProServiceID"].Value != null)
                        {
                            if (row.Cells["ProServiceID"].Value.ToString() == "")
                            {
                                string sqlInsert = "INSERT INTO ProfessionalService(ProServiceName) VALUES(@proservice)";
                                using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
                                {
                                    using (SQLiteCommand cmd = new SQLiteCommand(sqlInsert, con))
                                    {
                                        cmd.Parameters.Add("@proservice", DbType.String).Value = row.Cells["ProServiceName"].Value;
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            else
                            {
                                string sql = "UPDATE ProfessionalService SET ProServiceName = @proservice WHERE ProServiceID = @ID";
                                using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
                                {
                                    using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                                    {
                                        cmd.Parameters.Add("@ID", DbType.String).Value = row.Cells["ProServiceID"].Value;
                                        cmd.Parameters.Add("@proservice", DbType.String).Value = row.Cells["ProServiceName"].Value;
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
        }

        public void UpdateTask(DataGridView dgv, ComboBox cbProServ)
        {
            try
            {
                if (BackupDB())
                {
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells["TaskID"].Value != null)
                        {
                            if (row.Cells["TaskID"].Value.ToString() == "")
                            {
                                string sqlInsert = "INSERT INTO Task(ProServiceID, TaskName) VALUES(" + cbProServ.SelectedValue + ", @taskname)";
                                using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
                                {
                                    using (SQLiteCommand cmd = new SQLiteCommand(sqlInsert, con))
                                    {
                                        cmd.Parameters.Add("@taskname", DbType.String).Value = row.Cells["TaskName"].Value;
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            else
                            {
                                string sql = "UPDATE Task SET TaskName = @taskname WHERE TaskID = @ID";
                                using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
                                {
                                    using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                                    {
                                        cmd.Parameters.Add("@ID", DbType.String).Value = row.Cells["TaskID"].Value;
                                        cmd.Parameters.Add("@taskname", DbType.String).Value = row.Cells["TaskName"].Value;
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
        }

        public void UpdateItem(DataGridView dgv, ComboBox cbProServ)
        {
            try
            {
                if (BackupDB())
                {
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells["ItemID"].Value != null)
                        {
                            if (row.Cells["ItemID"].Value.ToString() == "")
                            {
                                string sqlInsert = "INSERT INTO Item(ProServiceID, ItemName) VALUES(" + cbProServ.SelectedValue + ", @itemname)";
                                using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
                                {
                                    using (SQLiteCommand cmd = new SQLiteCommand(sqlInsert, con))
                                    {
                                        cmd.Parameters.Add("@itemname", DbType.String).Value = row.Cells["ItemName"].Value;
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            else
                            {
                                string sql = "UPDATE Item SET ItemName = @itemname WHERE ItemID = @ID";
                                using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
                                {
                                    using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                                    {
                                        cmd.Parameters.Add("@ID", DbType.String).Value = row.Cells["ItemID"].Value;
                                        cmd.Parameters.Add("@itemname", DbType.String).Value = row.Cells["ItemName"].Value;
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
        }

        public string ReadString(string txtQuery)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(txtQuery, con))
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    return (result == null ? "" : result.ToString());
                }
            }
        }

        private bool FileCompare(string file1, string file2)
        {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            // Determine if the same file was referenced two times.
            if (file1 == file2)
            {
                // Return true to indicate that the files are the same.
                return true;
            }

            // Open the two files.
            fs1 = new FileStream(file1, FileMode.Open);
            fs2 = new FileStream(file2, FileMode.Open);

            // Check the file sizes. If they are not the same, the files
            // are not the same.
            if (fs1.Length != fs2.Length)
            {
                // Close the file
                fs1.Close();
                fs2.Close();

                // Return false to indicate files are different
                return false;
            }

            // Read and compare a byte from each file until either a
            // non-matching set of bytes is found or until the end of
            // file1 is reached.
            do
            {
                // Read one byte from each file.
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            // Close the files.
            fs1.Close();
            fs2.Close();

            // Return the success of the comparison. "file1byte" is
            // equal to "file2byte" at this point only if the files are
            // the same.
            return ((file1byte - file2byte) == 0);
        }

    }

    public static class CSVUtility
    {
        public static void ToCSV(this DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);

            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
    }


}
