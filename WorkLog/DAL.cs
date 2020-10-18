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

        public void DisplayRecord(string cmd, Label label)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                using (SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd, con))
                {
                    //Fill the DataTable with records from Table.
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    MessageBox.Show(dt.ToString());
                    
                }
            }
        }

        public void FillDataGrid(string cmd, DataGridView dgv)
        {
            using (SQLiteConnection con = new SQLiteConnection(LoadConnectionString()))
            {
                using (SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd, con))
                {
                    //Fill the DataTable with records from Table.
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    dgv.DataSource = dt;

                }
            }
        }
         

        public void InsertRecord(Record record)
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
                    cmd.Parameters.Add("@Date", DbType.String).Value = record.Date.ToString("d");
                    cmd.Parameters.Add("@StartTime", DbType.String).Value = record.StartTime.ToString("h:mm tt");
                    cmd.Parameters.Add("@EndTime", DbType.String).Value = record.EndTime.ToString("h:mm tt");
                    cmd.Parameters.Add("@Hours", DbType.String).Value = record.TotalHours.ToString();
                    cmd.Parameters.Add("@ReimbursableCost", DbType.String).Value = record.ReimburseAmount.ToString();
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

        public static List<Record> LoadRecords()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Record>("select * from Record", new DynamicParameters());
                return output.ToList();
            }
        }


    }
}
