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

namespace WorkLog
{
    public class DAL
    {
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        //@"DataSource=C:\Users\johnh\source\repos\WorkLog\WorkLog\WorkLog.db;"
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
            //using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            //{
            //    using (SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd, con))
            //    {
            //        //Fill the DataTable with records from Table.
            //        DataTable dt = new DataTable();
            //        sda.Fill(dt);

            //        dgv.DataSource = dt;
            //    }
            //}
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
                    cmd.Parameters.Add("@CreateDate", DbType.String).Value = DateTime.Now.ToString();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

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
