using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Globalization;

namespace WorkLog
{
    public partial class WorkLog : Form
    {
        private readonly ILogger _logger;
        private readonly Timer timer = new Timer();
        DAL oDAL = new DAL();
        int iCount;
        string strFilterClientID, strCurrDatabase;

        public WorkLog(ILogger<WorkLog> logger)
        {
            _logger = logger;

            InitializeComponent();
            InitializeDefaults();
            InitializeTimer();

            dtpStartTime.ValueChanged += new EventHandler(dtpStartTime_ValueChanged);
            dtpEndTime.ValueChanged += new EventHandler(dtpEndTime_ValueChanged);

            dtpStartTime.MouseWheel += new MouseEventHandler(dtpStartTime_MouseWheel);
            dtpEndTime.MouseWheel += new MouseEventHandler(dtpEndTime_MouseWheel);

            dtpFilterStart.MouseWheel += new MouseEventHandler(dtpFilterStart_MouseWheel);
            dtpFilterEnd.MouseWheel += new MouseEventHandler(dtpFilterEnd_MouseWheel);

            txtReimburseCost.KeyPress += new KeyPressEventHandler(TxtReimburseCost_KeyPress);
            dgvRecords.RowsAdded += (s, a) => OnRowNumberChanged();
        }

        private void InitializeDefaults()
        {
            dtpStartTime.CustomFormat = "M/d/yyyy h:mm tt";
            dtpEndTime.CustomFormat = "M/d/yyyy h:mm tt";
            lblHours.Text = Math.Round(CalculateTimespan().TotalHours, 2).ToString();

            cbClient.SelectedValue = "";
            cbProService.SelectedValue = "";
            lblMessage.Text = "";
            lblRecordCount.Text = "";
            dgvRecords.AllowUserToAddRows = false;

            RefreshComboBox();

            dtpFilterStart.CustomFormat = "M/dd/yyyy";
            dtpFilterEnd.CustomFormat = "M/dd/yyyy";

            strCurrDatabase = oDAL.ReadString("SELECT file FROM pragma_database_list WHERE seq = 0");
            lblDatabaseName.Text = Path.GetFileName(strCurrDatabase);
            //dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;            
        }

        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            lblHours.Text = GetTotalHours();
        }

        private void RefreshComboBox()
        {
            oDAL.FillComboBox("SELECT ClientID, ClientName FROM Client WHERE Enabled = 1", cbClient, "ClientName", "ClientID");
            oDAL.FillComboBox("SELECT ProServiceID, ProServiceName FROM ProfessionalService WHERE Enabled = 1", cbProService, "ProServiceName", "ProServiceID");
            oDAL.FillComboBox("SELECT ClientID, ClientName FROM Client WHERE Enabled = 1", cbFilterClient, "ClientName", "ClientID");
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            lblHours.Text = GetTotalHours();
        }

        private void dtpStartTime_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)            
                SendKeys.Send("{UP}");            
            else            
                SendKeys.Send("{DOWN}");            
        }

        private void dtpEndTime_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)            
                SendKeys.Send("{UP}");            
            else            
                SendKeys.Send("{DOWN}");            
        }

        private void dtpFilterStart_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                SendKeys.Send("{UP}");
            else
                SendKeys.Send("{DOWN}");
        }

        private void dtpFilterEnd_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                SendKeys.Send("{UP}");
            else
                SendKeys.Send("{DOWN}");
        }

        private string GetTotalHours()
        {
            string ret = Math.Round(CalculateTimespan().TotalHours, 2).ToString();
            if (Math.Round(CalculateTimespan().TotalHours, 2) < 0)
                ret = "0";
            return ret;
        }

        public TimeSpan CalculateTimespan()
        {
            TimeSpan tsDuration = dtpEndTime.Value.Subtract(dtpStartTime.Value);
            return tsDuration;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void CbFilterClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterClient.SelectedIndex > 0 && cbFilterClient.SelectedValue != null)
                strFilterClientID = cbFilterClient.SelectedValue.ToString();
            else
                strFilterClientID = null;
        }

        private void CbProService_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cmd = "";
                        
            if (cbProService.SelectedIndex > 0 && cbProService.SelectedValue != null)
                cmd = "SELECT TaskID, TaskName FROM Task WHERE ProServiceID = " + cbProService.SelectedValue + " AND Enabled = 1";
            else
                cmd = "SELECT TaskID, TaskName FROM Task WHERE ProServiceID = 1 AND Enabled = 1";

            oDAL.FillComboBox(cmd, cbTask, "TaskName", "TaskID");

            if (cbProService.Text == "Reimbursable")
            {
                txtReimburseCost.Enabled = true;
                dtpStartTime.Enabled = false;
                dtpEndTime.Enabled = false;
                lblHours.Enabled = false;
            }
            else
            {
                txtReimburseCost.Enabled = false;
                dtpStartTime.Enabled = true;
                dtpEndTime.Enabled = true;
                lblHours.Enabled = true;
            }
        }

        private void CbTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cmd = "";
            if (cbTask.SelectedIndex > 0 && cbTask.SelectedValue != null)
                cmd = "SELECT ItemID, ItemName FROM Item WHERE ProServiceID = " + cbProService.SelectedValue + " AND Enabled = 1";
            else
                cmd = "SELECT ItemID, ItemName FROM Item WHERE ProServiceID = 1 AND Enabled = 1";

            oDAL.FillComboBox(cmd, cbItem, "ItemName", "ItemID");
        }

        private void TxtReimburseCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar)
                    && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int i = rnd.Next(1, 16);
            cbClient.SelectedValue = i;

            i = rnd.Next(1, 4);
            cbProService.SelectedValue = i;

            switch (i)
            {
                case 1:
                    cbTask.SelectedValue = rnd.Next(1, 5);
                    cbItem.SelectedValue = rnd.Next(1, 5);
                    break;
                case 2:
                    cbTask.SelectedValue = rnd.Next(6, 11);
                    break;
                case 3:
                    cbTask.SelectedValue = rnd.Next(12, 16);
                    break;
            }

            int hr = rnd.Next(1, 12);
            int m = rnd.Next(1, 29);
            int d = rnd.Next(1, 30);

            dtpDate.Value = DateTime.Now.AddDays(d * -1);
            dtpStartTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hr, m, 0);
            dtpEndTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hr + rnd.Next(1, 11), m + rnd.Next(1, 29), 0);
            txtDescription.Text = "";
            int r = rnd.Next(1, 15);
            r *= 10;
            txtReimburseCost.Text = r.ToString();
        }

        private Record NewRecord()
        {
            Record myRecord = new Record();
            myRecord.Client = cbClient.Text;
            myRecord.ProService = cbProService.Text;
            myRecord.Task = cbTask.Text;
            myRecord.Item = cbItem.Text;
            myRecord.Date = dtpDate.Value.Date;
            myRecord.StartTime = dtpStartTime.Value;
            myRecord.EndTime = dtpEndTime.Value;
            myRecord.TotalHours = Convert.ToDouble(lblHours.Text);
            myRecord.ReimburseAmount = Convert.ToInt32(txtReimburseCost.Text);
            myRecord.Description = txtDescription.Text;
            return myRecord;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            cbClient.SelectedValue = 0;
            cbProService.SelectedValue = 0;
            cbTask.SelectedValue = 0;
            cbItem.SelectedValue = 0;

            dtpDate.Value = DateTime.Now;
            dtpStartTime.Value = DateTime.Now;
            dtpEndTime.Value = DateTime.Now;

            txtDescription.Text = "";
            txtReimburseCost.Text = "0";
            lblMessage.Text = "";
            lblMessage.ForeColor = SystemColors.ControlText;

            lblRecordCount.Text = "0";
            dgvRecords.DataSource = null;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation() == true)
            {
                try
                {
                    Record myRecord = NewRecord();
                    if (cbProService.Text == "Reimbursable")
                    {
                        if (txtReimburseCost.Text == "0")
                        {
                            DialogResult result = MessageBox.Show("Reimbursable cost is 0, continue?", "Confirmation", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                oDAL.InsertRecord(myRecord, true);

                            }
                            else
                                return;
                        }
                        else
                            oDAL.InsertRecord(myRecord, true);
                    }
                    else
                        oDAL.InsertRecord(myRecord, false);

                    iCount++;
                    FillDataGridOnSubmit(iCount);
                }
                catch (Exception ex)
                {
                    DisplayMessage("An unexpected error has occured", Color.Red);
                    _logger.LogError(ex, ex.Source);
                }
            }
        }

        private void FillDataGridOnSubmit(int iCount)
        {
            try
            {
                string cmd = "SELECT R.CreateDate, R.Client, R.ProService, R.Task, R.Item, R.Date, R.StartTime, R.EndTime, R.Hours, " +
                    "C.Rate, R.ReimbursableCost, round((R.Hours * C.Rate) + R.ReimbursableCost)  Billable, R.Description, R.RowID " +
                    "FROM Record R " +
                    "INNER JOIN Client C ON R.Client = C.ClientName " +
                    "ORDER BY R.RowID DESC LIMIT " + iCount.ToString();
                oDAL.FillDataGrid(cmd, dgvRecords);
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occured", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private bool Validation()
        {
            if (Convert.ToInt32(cbClient.SelectedValue) < 1)
            {
                MessageBox.Show("Select a Client");
                return false;
            }

            if (Convert.ToInt32(cbProService.SelectedValue) < 1)
            {
                MessageBox.Show("Select a Professional Service");
                return false;
            }

            if (Convert.ToInt32(cbTask.SelectedValue) < 1)
            {
                MessageBox.Show("Select a Task");
                return false;
            }

            if (cbProService.Text == "Reimbursable")
            {
                if (txtReimburseCost.Text == "")
                {
                    MessageBox.Show("Reimbursable cost cannot be blank");
                    txtReimburseCost.Focus();
                    return false;
                }
                else if (!Regex.IsMatch(txtReimburseCost.Text.Trim().Replace(",", ""), @"^\d+(\.\d{1,2})?$"))
                {
                    MessageBox.Show("Reimbursable cost must be in valid numeric form, e.g., 30, 56.23, 80.4 ");
                    txtReimburseCost.Focus();
                    return false;
                }
            }
            else
            {
                if (dtpStartTime.Value > dtpEndTime.Value)
                {
                    MessageBox.Show("Start Time cannot be greater than End Time");
                    return false;
                }
                else if (lblHours.Text == "0")
                {
                    DialogResult result = MessageBox.Show("Start Time is equal to End Time (0 hours). Continue?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        return true;
                    else
                        return false;
                }
            }
            return true;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dgvRecords.DataSource;
                if (dt == null)
                {
                    MessageBox.Show("Data table is empty. Select a view or filter to populate table");
                    return;
                }
                else
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "CSV (Comma delimited)|*.csv";
                    sfd.Title = "Export Records to CSV";
                    sfd.FileName = "WorkLog_" + DateTime.Now.ToString("yyyy-MM-dd_HHmm");
                    sfd.ShowDialog();
                    string fn = sfd.FileName;

                    if (string.IsNullOrWhiteSpace(fn))
                        return;
                    else
                    {
                        dt.ToCSV(fn);
                        Process.Start("explorer.exe", fn);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occured", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            RefreshCurrentView();
        }

        private void RefreshCurrentView()
        {
            try
            {
                string start = dtpFilterStart.Value.ToString("yyyy-MM-dd");
                string end = dtpFilterEnd.Value.ToString("yyyy-MM-dd");
                string where = "WHERE R.Date BETWEEN '" + start + "' AND '" + end + "' ";
                FillRecordView(where);
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occured", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void FillRecordView(string where)
        {
            try
            {
                string cmd = "SELECT R.CreateDate, R.Client, R.ProService, R.Task, R.Item, R.Date, R.StartTime, R.EndTime, " +
                    "R.Hours, C.Rate, R.ReimbursableCost, round((R.Hours * C.Rate) + R.ReimbursableCost)  Billable, R.Description, R.RowID " +
                    "FROM Record R " +
                    "INNER JOIN Client C ON R.Client = C.ClientName " +
                     where;

                if (!string.IsNullOrEmpty(strFilterClientID))
                {
                    cmd += " AND ClientID = " + strFilterClientID; 
                }
                 
                cmd += " ORDER BY R.Date";
                oDAL.FillDataGrid(cmd, dgvRecords);
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occured", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }


        private void ToolStripManageCat_Click(object sender, EventArgs e)
        {
            CategoryForm formCategories = new CategoryForm();
            formCategories.ShowDialog();

            RefreshComboBox();
        }

        private void OnRowNumberChanged()
        {
            lblRecordCount.Text = dgvRecords.Rows.Count.ToString();
            dgvRecords.Columns["RowID"].Visible = false;
            dgvRecords.Columns["RowID"].ReadOnly = true;
            dgvRecords.Columns["CreateDate"].ReadOnly = true;
            lblMessage.ForeColor = SystemColors.ControlText;
            lblMessage.Text = "";
            dgvRecords.AutoResizeColumns();
        }

        private void DisplayMessage(string msg, Color color)
        {
            lblMessage.Text = msg;
            lblMessage.ForeColor = color;
        }

        private void BtnLastMonth_Click(object sender, EventArgs e)
        {
            string where = " WHERE R.Date >= date('now', 'start of month', '-1 month') AND R.Date < date('now','start of month') ";
            string cmd;
            FillRecordView(where);

            cmd = "SELECT date('now', 'start of month', '-1 month')";
            string startDate = oDAL.ReadString(cmd);
            dtpFilterStart.Value = DateTime.Parse(startDate);

            cmd = "SELECT date('now','start of month', '-1 day')";
            string endDate = oDAL.ReadString(cmd);
            dtpFilterEnd.Value = DateTime.Parse(endDate);
        }

        private void BtnLast30_Click(object sender, EventArgs e)
        {
            string where = " WHERE R.Date >= date('now','-30 days') ";
            string cmd;
            FillRecordView(where);

            cmd = "SELECT date('now','-30 days')";
            string startDate = oDAL.ReadString(cmd);
            dtpFilterStart.Value = DateTime.Parse(startDate);

            dtpFilterEnd.Value = DateTime.Now;
        }

        private void BtnYTD_Click(object sender, EventArgs e)
        {
            string where = " WHERE R.Date >= date('now', 'start of year') AND R.Date < date('now','start of year', '+1 year') ";
            string cmd;
            FillRecordView(where);

            cmd = "SELECT date('now', 'start of year')";
            string startDate = oDAL.ReadString(cmd);
            dtpFilterStart.Value = DateTime.Parse(startDate);

            dtpFilterEnd.Value = DateTime.Now;
        }

        private void BtnMTD_Click(object sender, EventArgs e)
        {
            string where = " WHERE R.Date >= date('now', 'start of month') AND R.Date < date('now','start of month', '+1 month') ";
            string cmd;
            FillRecordView(where);

            cmd = "SELECT date('now', 'start of month')";
            string startDate = oDAL.ReadString(cmd);
            dtpFilterStart.Value = DateTime.Parse(startDate);

            dtpFilterEnd.Value = DateTime.Now;
        }

        private void BtnAll_Click(object sender, EventArgs e)
        {
            string cmd = "SELECT R.CreateDate, R.Client, R.ProService, R.Task, R.Item, R.Date, R.StartTime, R.EndTime, R.Hours, C.Rate, " +
                         "R.ReimbursableCost, round((R.Hours * C.Rate) + R.ReimbursableCost)  Billable, R.Description, R.RowID " +
                         "FROM Record R INNER JOIN Client C ON R.Client = C.ClientName ORDER BY R.Date ";
            oDAL.FillDataGrid(cmd, dgvRecords);

            cmd = "SELECT MIN(date) FROM Record";
            string startDate = oDAL.ReadString(cmd);
            dtpFilterStart.Value = DateTime.Parse(startDate);

            cmd = "SELECT MAX(date) FROM Record";
            string endDate = oDAL.ReadString(cmd);
            dtpFilterEnd.Value = DateTime.Parse(endDate);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRecords.DataSource == null)
                {
                    MessageBox.Show("Data table is empty. Select a view or filter to populate table");
                    return;
                }

                if (dgvRecords.SelectedRows.Count > 0)
                {
                    int i = 0;
                    DialogResult result = MessageBox.Show("Selected rows will be deleted. Continue?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow dr in dgvRecords.SelectedRows)
                        {
                            oDAL.DeleteRecord(dr.Cells["RowID"].Value.ToString());
                            dgvRecords.Rows.RemoveAt(dr.Index);
                            iCount--;
                            i++;
                        }
                        if (i == 1)
                            DisplayMessage("1 record deleted", Color.Green);
                        else if (i > 1)
                            DisplayMessage(i.ToString() + " records deleted", Color.Green);

                        lblRecordCount.Text = dgvRecords.Rows.Count.ToString();
                    }
                    else
                        return;
                }
                else
                {
                    MessageBox.Show("No rows selected. Select one or more rows by clicking the black arrow in the left-most cell");
                }
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occured", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }


        private void BackupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                oDAL.BackupDB();
                MessageBox.Show("Backup successful!");
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occured", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void ArchiveBackupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                oDAL.ArchiveBackups(-30);
                MessageBox.Show("Archive successful!");
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occured", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRecords.SelectedCells.Count < 1 && dgvRecords.DataSource != null)
                    MessageBox.Show("Select a cell or row to load from");
                else if (dgvRecords.DataSource == null)
                    MessageBox.Show("Data table is empty. Select a view or filter to populate table");
                else
                {
                    DataGridViewRow dr = dgvRecords.SelectedCells[0].OwningRow;
                    cbClient.SelectedIndex = cbClient.FindStringExact(dr.Cells["Client"].Value.ToString());
                    cbProService.SelectedIndex = cbProService.FindStringExact(dr.Cells["ProService"].Value.ToString());
                    cbTask.SelectedIndex = cbTask.FindStringExact(dr.Cells["Task"].Value.ToString());
                    cbItem.SelectedIndex = cbItem.FindStringExact(dr.Cells["Item"].Value.ToString());
                    dtpDate.Value = DateTime.ParseExact(dr.Cells["Date"].Value.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    txtReimburseCost.Text = dr.Cells["ReimbursableCost"].Value.ToString();
                    txtDescription.Text = dr.Cells["Description"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occured", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void BtnUpdateRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRecords.DataSource == null)
                {
                    MessageBox.Show("Data table is empty. Select a view or filter to populate table");
                    return;
                }

                DialogResult result = MessageBox.Show("Description field will be updated for all visible records. Continue?", "Apply Changes Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    oDAL.UpdateRecord(dgvRecords);
                    lblMessage.ForeColor = Color.Green;
                    lblMessage.Text = "Update Successful";
                    RefreshCurrentView();
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occured", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ResetRecordGrid();
        }

        private void ResetRecordGrid()
        {
            lblMessage.Text = "";
            lblRecordCount.Text = "";
            dtpFilterStart.Value = DateTime.Today;
            dtpFilterEnd.Value = DateTime.Today;
            string start = dtpFilterStart.Value.ToString("yyyy-MM-dd");
            string end = dtpFilterEnd.Value.ToString("yyyy-MM-dd");
            string where = " WHERE R.Date BETWEEN '" + start + "' AND '" + end + "' ";
            cbFilterClient.SelectedIndex = 0;
            FillRecordView(where);

            if (dgvRecords.RowCount == 0)
                dgvRecords.DataSource = null;
        }

        private void InitializeTimer()
        {            
            timer.Interval = 300000;
            timer.Enabled = true;            
            timer.Tick += new System.EventHandler(Timer_Tick);
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            oDAL.BackupDB();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var filePath = string.Empty;
                using (OpenFileDialog ofg = new OpenFileDialog())
                {                    
                    ofg.Filter = "SQLite Database|*.db";
                    ofg.RestoreDirectory = true;

                    if (ofg.ShowDialog() == DialogResult.OK)
                    {
                        filePath = @"DataSource=" + ofg.FileName + ";Version=3;";
                        oDAL.SetConnectionString(filePath);
                        strCurrDatabase = oDAL.ReadString("SELECT file FROM pragma_database_list WHERE seq = 0");
                        lblDatabaseName.Text = Path.GetFileName(strCurrDatabase);
                        ResetRecordGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occured", Color.Red);
                _logger.LogError(ex, ex.Source);
            }                    
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oDAL.FileSaveAs();
        }
    }
}
