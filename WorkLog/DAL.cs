using System;
//using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Security.Cryptography;

namespace WorkLog
{
    public class DAL
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public string SaveAsFilename { get; set; }



        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        public void SetConnectionString(string con)
        {

            ConnectionStringSettings DBCS = ConfigurationManager.ConnectionStrings["Default"];

            FieldInfo writable = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            writable.SetValue(DBCS, false);

            DBCS.ConnectionString = con;
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

        public bool FileSaveAs()
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = @"SQLite Database|*.db",
                    Title = @"Save Database As",
                    FileName = "WorkLog_" + DateTime.Now.ToString("yyyy-MM-dd_HHmm")
                };

                if (sfd.ShowDialog() != DialogResult.OK) return false;

                string fn = sfd.FileName;
                string backupConnection = @"DataSource=" + fn + ";Version=3;";

                if (string.IsNullOrWhiteSpace(fn)) return false;

                using (SQLiteConnection dest = new SQLiteConnection(backupConnection))
                using (SQLiteConnection src = new SQLiteConnection(LoadConnectionString()))
                {
                    dest.Open();
                    src.Open();
                    src.BackupDatabase(dest, "main", "main", -1, null, 0);
                    SetConnectionString(backupConnection);
                    SaveAsFilename = sfd.FileName;
                }

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
                return false;
            }

        }

        public bool BackupDB()
        {
            try
            {
                Directory.CreateDirectory(@"..\..\..\db");
                string now = DateTime.Now.ToString("yyyy-MM-dd_HHmmsss");
                string strFilename = "WorkLog_" + now + ".db";
                string backupConnection = @"DataSource=..\..\..\db\" + strFilename + ";Version=3;";

                //string fullPathNew = Path.GetFullPath(@"..\..\..\db\" + strFilename);

                using (SQLiteConnection dest = new SQLiteConnection(backupConnection))
                using (SQLiteConnection src = new SQLiteConnection(LoadConnectionString()))
                {
                    dest.Open();
                    src.Open();
                    src.BackupDatabase(dest, "main", "main", -1, null, 0);
                }
                //logger.Info("Database backed up: {0}", fullPathNew);

                int iBackups = Directory.GetFiles(@"..\..\..\db\", "*.db", SearchOption.TopDirectoryOnly).Length;

                DeleteDuplicateFiles(@"..\..\..\db\");

                if (iBackups <= 50) return true;
                ArchiveBackups();

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
                return false;
            }
        }

        //https://codereview.stackexchange.com/questions/166120/delete-duplicate-files
        public void DeleteDuplicateFiles(string directoryPath)
        {
            string[] allFiles = Directory.GetFiles(directoryPath, "*.db*", SearchOption.AllDirectories);
            //logger.Info(@"Backups found: {0}", allFiles.Length);

            // get duplicate files
            var dupFiles = allFiles.Select(f =>
                {
                    using (FileStream fs = new FileStream(f, FileMode.Open, FileAccess.Read))
                    {
                        return new
                        {
                            FileName = f,
                            FileHash = BitConverter.ToString(SHA1.Create().ComputeHash(fs))
                        };
                    }
                }).GroupBy(f => f.FileHash).Select(g => new { FileHash = g.Key, Files = g.Select(z => z.FileName).ToList() })
                .SelectMany(f => f.Files.Skip(1)).ToList();
            //int iDupes = dupFiles.Count;

            // delete duplicate files
            dupFiles.ForEach(File.Delete);

            //if (iDupes > 0)
            //    logger.Info(@"Duplicate backups found and deleted: {0}", dupFiles.Count);
        }

        public void ArchiveBackups(int daysOld = 0)
        {
            string now = DateTime.Now.ToString("yyyy-MM-dd_HHmm");
            string strFilename = "WorkLog_" + now + ".zip";
            string zipPath = Path.GetFullPath(@"..\..\..\db\Archive\" + strFilename);
            int i = 0;

            try
            {
                using (ZipArchive zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
                {
                    foreach (FileInfo fi in new DirectoryInfo(@"..\..\..\db").GetFiles().OrderBy(x => x.LastWriteTime))
                    {
                        if (fi.LastWriteTime >= DateTime.Now.AddDays(daysOld)) continue;
                        zip.CreateEntryFromFile(fi.FullName, fi.Name);
                        fi.Delete();
                        i++;
                    }
                }
                logger.Info("Database archive count: {0}, zip file: {1} ", i.ToString(), zipPath);
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
        }

        public bool InsertRecord(Record record, bool isReimburse)
        {
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
                {
                    const string insertSQL = @"INSERT INTO Record (Client, ProService, Task, Item, Date, StartTime, " +
                                             "EndTime, Hours, ReimbursableCost, Description, Comments, StartTimeOnly, EndTimeOnly, CreateDate) " +
                                             "VALUES (@Client, @ProService, @Task, @Item, @Date, @StartTime, @EndTime, @Hours, @ReimbursableCost, " +
                                             "@Description, @Comments, @StartTimeOnly, @EndTimeOnly, @CreateDate)";

                    con.Open();

                    SQLiteCommand cmd = new SQLiteCommand(insertSQL, con);

                    cmd.Parameters.Add("@Client", DbType.String).Value = record.Client;
                    cmd.Parameters.Add("@ProService", DbType.String).Value = record.ProService;
                    cmd.Parameters.Add("@Task", DbType.String).Value = record.Task;
                    cmd.Parameters.Add("@Item", DbType.String).Value = record.Item;
                    //cmd.Parameters.Add("@Date", DbType.String).Value = record.Date.ToString("yyyy-MM-dd");
                    cmd.Parameters.Add("@Date", DbType.String).Value = record.StartTime.ToString("yyyy-MM-dd");

                    if (isReimburse)
                    {
                        cmd.Parameters.Add("@StartTime", DbType.String).Value = "";
                        cmd.Parameters.Add("@EndTime", DbType.String).Value = "";
                        cmd.Parameters.Add("@StartTimeOnly", DbType.String).Value = "";
                        cmd.Parameters.Add("@EndTimeOnly", DbType.String).Value = "";
                        cmd.Parameters.Add("@Hours", DbType.String).Value = "";
                        cmd.Parameters.Add("@ReimbursableCost", DbType.String).Value = record.ReimburseAmount.ToString();
                    }
                    else
                    {
                        cmd.Parameters.Add("@StartTime", DbType.String).Value = record.StartTime.ToString("yyyy-MM-dd HH:mm");
                        cmd.Parameters.Add("@EndTime", DbType.String).Value = record.EndTime.ToString("yyyy-MM-dd HH:mm");
                        cmd.Parameters.Add("@StartTimeOnly", DbType.String).Value = record.StartTime.ToString("hh:mm tt");
                        cmd.Parameters.Add("@EndTimeOnly", DbType.String).Value = record.EndTime.ToString("hh:mm tt");
                        cmd.Parameters.Add("@Hours", DbType.String).Value = record.TotalHours.ToString();
                        cmd.Parameters.Add("@ReimbursableCost", DbType.String).Value = "0";
                    }

                    cmd.Parameters.Add("@Description", DbType.String).Value = record.Description;
                    cmd.Parameters.Add("@Comments", DbType.String).Value = record.Comments;
                    cmd.Parameters.Add("@CreateDate", DbType.String).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
                return false;
            }
        }

        public bool UpdateRecord(DataGridView dgv)
        {
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    const string sql = "UPDATE Record SET Description = @Description, Comments = @Comments WHERE RowID = @ID";
                    using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
                    {
                        using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                        {
                            cmd.Parameters.Add("@Description", DbType.String).Value = row.Cells["Description"].Value;
                            cmd.Parameters.Add("@Comments", DbType.String).Value = row.Cells["Comments"].Value;
                            cmd.Parameters.Add("@ID", DbType.String).Value = row.Cells["RowID"].Value;
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
                return false;
            }
        }

        public bool DeleteRecord(string table, string tableID, string strRowID)
        {
            try
            {
                if (table == "ProfessionalService")
                {
                    if (CheckProServiceDependency("Task", strRowID, "TaskID"))
                    {
                        MessageBox.Show(@"Cannot delete Professional Service because a Task depends on it. Delete the Task first");
                        return false;
                    }
                    if (CheckProServiceDependency("Item", strRowID, "ItemID"))
                    {
                        MessageBox.Show(@"Cannot delete Professional Service because an Item depends on it. Delete the Item first");
                        return false;
                    }
                }

                using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
                {
                    string deleteSql = @"DELETE FROM " + table + " WHERE " + tableID + " = " + strRowID;
                    using (SQLiteCommand cmd = new SQLiteCommand(deleteSql, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                logger.Info("Row deleted: " + table + "|" + tableID + "|" + strRowID);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
                return false;
            }
        }

        /********************************************** CATEGORIES  **********************************************/
        public bool UpdateClient(DataGridView dgv)
        {
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (IsRowEmpty(row))
                        break;

                    if (row.Cells["ClientID"].Value == DBNull.Value && !string.IsNullOrEmpty(row.Cells["ClientName"].Value.ToString()))
                    {
                        const string sqlInsert = "INSERT INTO Client(ClientName, AddressLine1, AddressLine2, City, State, Zip, Rate) VALUES(@name, @a1, @a2, @city, @state, @zip, @rate)";
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
                                cmd.Parameters.Add("@rate", DbType.String).Value = row.Cells["Rate"].Value;
                                con.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                        logger.Info("New Client added: {0}", row.Cells["ClientName"].Value);
                    }
                    else if (!string.IsNullOrEmpty(row.Cells["ClientName"].Value.ToString()))
                    {
                        const string sql = "UPDATE Client SET ClientName = @name, AddressLine1 = @a1, AddressLine2 = @a2, City = @city, State = @state, Zip = @zip, Enabled = @enabled, Rate = @rate WHERE ClientID = @ID";
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
                                cmd.Parameters.Add("@enabled", DbType.String).Value = row.Cells["Enabled"].Value;
                                cmd.Parameters.Add("@rate", DbType.String).Value = row.Cells["Rate"].Value;
                                con.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                        //logger.Info("Existing Client updated: {0}", row.Cells["ClientName"].Value);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
                return false;
            }
        }


        public bool UpdateProService(DataGridView dgv)
        {
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (IsRowEmpty(row))
                        break;

                    if (row.Cells["ProServiceID"].Value == DBNull.Value && !string.IsNullOrEmpty(row.Cells["ProServiceName"].Value.ToString()))
                    {
                        const string sqlInsert = "INSERT INTO ProfessionalService(ProServiceName) VALUES(@proservice)";
                        using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
                        {
                            using (SQLiteCommand cmd = new SQLiteCommand(sqlInsert, con))
                            {
                                cmd.Parameters.Add("@proservice", DbType.String).Value = row.Cells["ProServiceName"].Value;
                                con.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                        logger.Info("New Professional Service added: {0}", row.Cells["ProServiceName"].Value);
                    }
                    else if (!string.IsNullOrEmpty(row.Cells["ProServiceName"].Value.ToString()))
                    {
                        string sql = "UPDATE ProfessionalService SET ProServiceName = @proservice, Enabled = @enabled WHERE ProServiceID = @ID";
                        using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
                        {
                            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                            {
                                cmd.Parameters.Add("@ID", DbType.String).Value = row.Cells["ProServiceID"].Value;
                                cmd.Parameters.Add("@proservice", DbType.String).Value = row.Cells["ProServiceName"].Value;
                                cmd.Parameters.Add("@enabled", DbType.String).Value = row.Cells["Enabled"].Value;
                                con.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                        //logger.Info("Existing Professional Service updated: {0}", row.Cells["ProServiceName"].Value);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
                return false;
            }
        }

        public bool UpdateTask(DataGridView dgv, ComboBox cbProServ)
        {
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (IsRowEmpty(row))
                        break;

                    if (row.Cells["TaskID"].Value == DBNull.Value && !string.IsNullOrEmpty(row.Cells["TaskName"].Value.ToString()))
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
                        logger.Info("New Task added: {0}", row.Cells["TaskName"].Value);
                    }
                    else if (!string.IsNullOrEmpty(row.Cells["TaskName"].Value.ToString()))
                    {
                        string sql = "UPDATE Task SET TaskName = @taskname, Enabled = @enabled WHERE TaskID = @ID";
                        using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
                        {
                            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                            {
                                cmd.Parameters.Add("@ID", DbType.String).Value = row.Cells["TaskID"].Value;
                                cmd.Parameters.Add("@taskname", DbType.String).Value = row.Cells["TaskName"].Value;
                                cmd.Parameters.Add("@enabled", DbType.String).Value = row.Cells["Enabled"].Value;
                                con.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                        //logger.Info("Existing Task updated: {0}", row.Cells["TaskName"].Value);
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
                return false;
            }
        }

        public bool UpdateItem(DataGridView dgv, ComboBox cbProServ)
        {
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (IsRowEmpty(row))
                        break;

                    if (row.Cells["ItemID"].Value == DBNull.Value && !string.IsNullOrEmpty(row.Cells["ItemName"].Value.ToString()))
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
                        logger.Info("New Item added: {0}", row.Cells["ItemName"].Value);
                    }
                    else if (!string.IsNullOrEmpty(row.Cells["ItemName"].Value.ToString()))
                    {
                        const string sql = "UPDATE Item SET ItemName = @itemname, Enabled = @enabled WHERE ItemID = @ID";
                        using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
                        {
                            using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                            {
                                cmd.Parameters.Add("@ID", DbType.String).Value = row.Cells["ItemID"].Value;
                                cmd.Parameters.Add("@itemname", DbType.String).Value = row.Cells["ItemName"].Value;
                                cmd.Parameters.Add("@enabled", DbType.String).Value = row.Cells["Enabled"].Value;
                                con.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                        //logger.Info("Existing Item updated: {0}", row.Cells["ItemName"].Value);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
                return false;
            }
        }

        public bool CheckProServiceDependency(string table, string proServiceID, string existsID)
        {
            return !string.IsNullOrEmpty(ReadString("SELECT " + existsID + " FROM " + table + " WHERE ProServiceID = " + proServiceID));
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


        /*
                private bool FileCompare(string file1, string file2)
                {
                    try
                    {
                        int file1byte, file2byte;

                        if (file1 == file2)
                        {
                            return true;
                        }

                        FileStream fs1 = new FileStream(file1, FileMode.Open);
                        FileStream fs2 = new FileStream(file2, FileMode.Open);

                        if (fs1.Length != fs2.Length)
                        {
                            fs1.Close();
                            fs2.Close();

                            return false;
                        }

                        do
                        {
                            file1byte = fs1.ReadByte();
                            file2byte = fs2.ReadByte();
                        }
                        while ((file1byte == file2byte) && (file1byte != -1));

                        fs1.Close();
                        fs2.Close();

                        return ((file1byte - file2byte) == 0);
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex, ex.Source);
                        return false;
                    }
                }
        */

        private bool IsRowEmpty(DataGridViewRow row)
        {
            for (int i = 0; i < row.Cells.Count; i++)
            {
                if (row.Cells[i].Value != null)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public static class CSVUtility
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void ToCSV(this DataTable dtDataTable, string strFilePath)
        {
            try
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
                                value = string.Format("\"{0}\"", value);
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
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
        }
    }


}
