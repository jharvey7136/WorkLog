using System;
using System.Data;
//using System.Data.Entity.Core.Common.CommandTrees;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Collections.Specialized;

namespace WorkLog
{
    public partial class WorkLog : Form
    {
        private readonly ILogger _logger;
        private readonly Timer timer = new Timer();
        private readonly DAL oDAL = new DAL();
        private int iCount;
        private string strFilterClientID, strCurrDatabase;
        private double dblTotalHours, dblTotalBillable, dblTotalReimbursable;
        private readonly CultureInfo ci = new CultureInfo("en-us");

        public WorkLog(ILogger<WorkLog> logger)
        {
            _logger = logger;

            try
            {
                InitializeComponent();

                btnTest.Visible = true;

                dtpDate.Visible = false;
                lblDate.Visible = false;

                InitializeDefaults();
                InitializeTimer();

                dtpStartTime.ValueChanged += DtpStartTime_ValueChanged;
                dtpEndTime.ValueChanged += DtpEndTime_ValueChanged;

                dtpStartTime.MouseWheel += DtpStartTime_MouseWheel;
                dtpEndTime.MouseWheel += DtpEndTime_MouseWheel;

                dtpFilterStart.MouseWheel += DtpFilterStart_MouseWheel;
                dtpFilterEnd.MouseWheel += DtpFilterEnd_MouseWheel;

                txtReimburseCost.KeyPress += TxtReimburseCost_KeyPress;
                dgvRecords.RowsAdded += (s, a) => OnRowNumberChanged();
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void InitializeDefaults()
        {
            try
            {
                if (ConfigurationManager.ConnectionStrings["Default"] == null)
                    SetDatabaseConnection();


                ConnectionStringSettings con = ConfigurationManager.ConnectionStrings["Default"];

                if (string.IsNullOrEmpty(con.ToString()))
                {
                    SetDatabaseConnection();                    
                }

                dtpStartTime.CustomFormat = @"M/d/yyyy h:mm tt";
                dtpEndTime.CustomFormat = @"M/d/yyyy h:mm tt";
                lblHours.Text = Math.Round(CalculateTimespan().TotalHours, 2).ToString();

                cbClient.SelectedValue = "";
                cbProService.SelectedValue = "";
                lblMessage.Text = "";
                lblRecordCount.Text = "";

                lblAggrHoursSum.Text = @"0.00";
                lblAggrReimbursableSum.Text = @"$0.00";
                lblAggrBillableSum.Text = @"$0.00";

                dgvRecords.AllowUserToAddRows = false;

                oDAL.FillComboBox("SELECT ClientID, ClientName FROM Client WHERE Enabled = 1 ORDER BY ClientName", cbClient, "ClientName", "ClientID");
                oDAL.FillComboBox("SELECT ProServiceID, ProServiceName FROM ProfessionalService WHERE Enabled = 1", cbProService, "ProServiceName", "ProServiceID");
                oDAL.FillComboBox("SELECT ClientID, ClientName FROM Client WHERE Enabled = 1 ORDER BY ClientName", cbFilterClient, "ClientName", "ClientID");

                dtpFilterStart.CustomFormat = @"M/dd/yyyy";
                dtpFilterEnd.CustomFormat = @"M/dd/yyyy";

                strCurrDatabase = oDAL.ReadString("SELECT file FROM pragma_database_list WHERE seq = 0");
                lblDatabaseName.Text = Path.GetFileName(strCurrDatabase);
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void DtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            lblHours.Text = GetTotalHours();
        }

        private void DtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            lblHours.Text = GetTotalHours();
        }

        private void DtpStartTime_MouseWheel(object sender, MouseEventArgs e)
        {
            SendKeys.Send(e.Delta > 0 ? "{UP}" : "{DOWN}");
        }

        private void DtpEndTime_MouseWheel(object sender, MouseEventArgs e)
        {
            SendKeys.Send(e.Delta > 0 ? "{UP}" : "{DOWN}");
        }

        private void DtpFilterStart_MouseWheel(object sender, MouseEventArgs e)
        {
            SendKeys.Send(e.Delta > 0 ? "{UP}" : "{DOWN}");
        }

        private void DtpFilterEnd_MouseWheel(object sender, MouseEventArgs e)
        {
            SendKeys.Send(e.Delta > 0 ? "{UP}" : "{DOWN}");
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
            try
            {
                if (cbProService.SelectedIndex > 0 && cbProService.SelectedValue != null)
                {
                    string cmdTask = "SELECT TaskID, TaskName FROM Task WHERE ProServiceID = " + cbProService.SelectedValue + " AND Enabled = 1 ORDER BY TaskName";
                    string cmdItem = "SELECT ItemID, ItemName FROM Item WHERE ProServiceID = " + cbProService.SelectedValue + " AND Enabled = 1 ORDER BY ItemName";
                    oDAL.FillComboBox(cmdTask, cbTask, "TaskName", "TaskID");
                    oDAL.FillComboBox(cmdItem, cbItem, "ItemName", "ItemID");
                }
                if (cbProService.Text == @"Reimbursable")
                {
                    txtReimburseCost.Enabled = true;                    
                    lblHours.Enabled = false;
                }
                else
                {
                    txtReimburseCost.Enabled = false;                    
                    lblHours.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void TxtReimburseCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            try
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
                dtpStartTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hr, m, 0).AddDays(-d);
                dtpEndTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hr + rnd.Next(1, 11), m + rnd.Next(1, 29), 0).AddDays(-d);
                txtDescription.Text = "";
                int r = rnd.Next(1, 15);
                r *= 10;
                txtReimburseCost.Text = r.ToString();
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }

        }

        private Record NewRecord()
        {
            Record myRecord = new Record
            {
                Client = cbClient.Text,
                ProService = cbProService.Text,
                Task = cbTask.Text,
                Item = cbItem.Text,
                Date = dtpDate.Value.Date,
                StartTime = dtpStartTime.Value,
                EndTime = dtpEndTime.Value,
                TotalHours = Convert.ToDouble(lblHours.Text),
                ReimburseAmount = Convert.ToDouble(txtReimburseCost.Text),
                Description = txtDescription.Text,
                Comments = txtComments.Text
            };
            return myRecord;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                cbClient.SelectedValue = 0;
                cbProService.SelectedValue = 0;
                cbTask.SelectedValue = 0;
                cbItem.SelectedValue = 0;

                dtpDate.Value = DateTime.Now;
                dtpStartTime.Value = DateTime.Now;
                dtpEndTime.Value = DateTime.Now;

                txtDescription.Text = "";
                txtComments.Text = "";
                txtReimburseCost.Text = @"0";
                lblMessage.Text = "";
                lblMessage.ForeColor = SystemColors.ControlText;
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (!Validation()) return;
            try
            {
                bool insert;
                Record myRecord = NewRecord();
                if (cbProService.Text == @"Reimbursable")
                {
                    if (txtReimburseCost.Text == @"0")
                    {
                        DialogResult result = MessageBox.Show(@"Reimbursable cost is 0. Continue?", @"Confirmation", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                            insert = oDAL.InsertRecord(myRecord, true);
                        else
                            return;
                    }
                    else
                        insert = oDAL.InsertRecord(myRecord, true);
                }
                else
                    insert = oDAL.InsertRecord(myRecord, false);

                if (insert)
                {
                    _logger.LogInformation("New expense: " + myRecord.FullRecord, Color.Green);
                    iCount++;
                    FillDataGridOnSubmit(iCount);
                }
                else
                    DisplayMessage("An unexpected error has occurred", Color.Red);

            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void FillDataGridOnSubmit(int i)
        {
            try
            {
                string cmd = "SELECT R.CreateDate, R.Client, R.ProService, R.Task, R.Item, R.Date, R.StartTimeOnly, R.EndTimeOnly, R.Hours, " +
                    "C.Rate, R.ReimbursableCost, (R.Hours * C.Rate) + R.ReimbursableCost Billable, R.Description, R.Comments, R.RowID, " +
                    "C.AddressLine1, C.AddressLine2, C.City, C.State, C.Zip, R.StartTime, R.EndTime  " +
                    "FROM Record R " +
                    "INNER JOIN Client C ON R.Client = C.ClientName " +
                    "ORDER BY R.RowID DESC, R.Date, R.StartTime LIMIT " + i;
                oDAL.FillDataGrid(cmd, dgvRecords);
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private bool Validation()
        {
            if (Convert.ToInt32(cbClient.SelectedValue) < 1)
            {
                MessageBox.Show(@"Select a Client");
                cbClient.Focus();
                cbClient.DroppedDown = true;
                return false;
            }

            if (Convert.ToInt32(cbProService.SelectedValue) < 1)
            {
                MessageBox.Show(@"Select a Professional Service");
                cbProService.Focus();
                cbProService.DroppedDown = true;
                return false;
            }

            if (Convert.ToInt32(cbTask.SelectedValue) < 1)
            {
                MessageBox.Show(@"Select a Task");
                cbTask.Focus();
                cbTask.DroppedDown = true;
                return false;
            }

            if (cbProService.Text == @"Reimbursable")
            {
                if (string.IsNullOrWhiteSpace(txtReimburseCost.Text))
                {
                    MessageBox.Show(@"Reimbursable cost cannot be blank");
                    txtReimburseCost.Focus();
                    return false;
                }

                if (Regex.IsMatch(txtReimburseCost.Text.Trim().Replace(",", ""), @"^\d+(\.\d{1,2})?$")) return true;

                MessageBox.Show(@"Reimbursable cost must be in valid numeric form, e.g., 30, 56.23, 80.4 ");
                txtReimburseCost.Focus();
                return false;
            }
            else
            {
                if (dtpStartTime.Value > dtpEndTime.Value)
                {
                    MessageBox.Show(@"Start Time cannot be greater than End Time");
                    return false;
                }

                if (lblHours.Text == @"0")
                {
                    DialogResult result = MessageBox.Show(@"Start Time is equal to End Time (0 hours). Continue?", @"Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                        return true;
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
                    MessageBox.Show(@"Data table is empty. Select a view or filter to populate table");
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = @"CSV (Comma delimited)|*.csv",
                    Title = @"Export Records to CSV",
                    FileName = "WorkLog_" + DateTime.Now.ToString("yyyy-MM-dd_HHmm")
                };

                if (sfd.ShowDialog() != DialogResult.OK) return;
                string fn = sfd.FileName;

                if (string.IsNullOrWhiteSpace(fn)) return;

                dt.ToCSV(fn);
                Process.Start("explorer.exe", fn);
                DisplayMessage(@"Export successful", Color.Green);
                _logger.LogInformation("Data view exported: {0}", fn);
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshCurrentView();
                if (dgvRecords.RowCount == 0)
                    OnRowNumberChanged();
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void RefreshCurrentView()
        {
            try
            {
                string start = dtpFilterStart.Value.ToString("yyyy-MM-dd");
                string end = dtpFilterEnd.Value.ToString("yyyy-MM-dd");
                string where = "WHERE R.Date BETWEEN '" + start + "' AND '" + end + "' ";
                FillRecordView(where);
                if (dgvRecords.RowCount == 0)
                    OnRowNumberChanged();
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void FillRecordView(string where, int limit = 0)
        {
            try
            {
                string cmd =
                    "SELECT R.CreateDate, R.Client, R.ProService, R.Task, R.Item, R.Date, R.StartTimeOnly, R.EndTimeOnly, R.Hours, " +
                    "C.Rate, R.ReimbursableCost, (R.Hours * C.Rate) + R.ReimbursableCost  Billable, R.Description, R.Comments, R.RowID, " +
                    "C.AddressLine1, C.AddressLine2, C.City, C.State, C.Zip, R.StartTime , R.EndTime  " +
                    "FROM Record R " +
                    "INNER JOIN Client C ON R.Client = C.ClientName " +
                    where;

                if (!string.IsNullOrWhiteSpace(where) && !string.IsNullOrWhiteSpace(strFilterClientID))
                    cmd += " AND ClientID = " + strFilterClientID;
                else if (string.IsNullOrWhiteSpace(where) && !string.IsNullOrWhiteSpace(strFilterClientID))
                    cmd += " WHERE ClientID = " + strFilterClientID;


                cmd += " ORDER BY R.Date, R.StartTime ";

                if (limit > 0)
                    cmd += " LIMIT " + iCount;

                oDAL.FillDataGrid(cmd, dgvRecords);
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void ToolStripManageCat_Click(object sender, EventArgs e)
        {
            try
            {
                CategoryForm formCategories = new CategoryForm();
                formCategories.ShowDialog();
                oDAL.FillComboBox("SELECT ClientID, ClientName FROM Client WHERE Enabled = 1 ORDER BY ClientName", cbClient, "ClientName", "ClientID");
                oDAL.FillComboBox("SELECT ProServiceID, ProServiceName FROM ProfessionalService WHERE Enabled = 1 ORDER BY ProServiceName", cbProService, "ProServiceName", "ProServiceID");
                oDAL.FillComboBox("SELECT ClientID, ClientName FROM Client WHERE Enabled = 1 ORDER BY ClientName", cbFilterClient, "ClientName", "ClientID");

            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void OnRowNumberChanged()
        {
            try
            {
                lblRecordCount.Text = dgvRecords.Rows.Count.ToString();
                dgvRecords.Columns["RowID"].Visible = false;
                dgvRecords.Columns["AddressLine1"].Visible = false;
                dgvRecords.Columns["AddressLine2"].Visible = false;
                dgvRecords.Columns["City"].Visible = false;
                dgvRecords.Columns["State"].Visible = false;
                dgvRecords.Columns["Zip"].Visible = false;
                dgvRecords.Columns["RowID"].ReadOnly = true;
                dgvRecords.Columns["CreateDate"].ReadOnly = true;
                dgvRecords.Columns["StartTime"].Visible = false;
                dgvRecords.Columns["EndTime"].Visible = false;
                lblMessage.ForeColor = SystemColors.ControlText;
                lblMessage.Text = "";
                dgvRecords.AutoResizeColumns();

                CalculateTotals();
                lblAggrHoursSum.Text = dblTotalHours.ToString("N02", ci);
                lblAggrReimbursableSum.Text = dblTotalReimbursable.ToString("C", ci);
                lblAggrBillableSum.Text = dblTotalBillable.ToString("C", ci);
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void CalculateTotals()
        {
            dblTotalHours = 0;
            dblTotalReimbursable = 0;
            dblTotalBillable = 0;

            try
            {
                if (dgvRecords.DataSource == null || dgvRecords.RowCount < 1)
                    return;

                foreach (DataGridViewRow row in dgvRecords.Rows)
                {
                    if (!string.IsNullOrEmpty(row.Cells["Hours"].Value.ToString()) && row.Cells["Hours"].Value != DBNull.Value)
                        dblTotalHours += double.Parse(row.Cells["Hours"].Value.ToString());

                    if (!string.IsNullOrEmpty(row.Cells["ReimbursableCost"].Value.ToString()) && row.Cells["ReimbursableCost"].Value != DBNull.Value)
                        dblTotalReimbursable += double.Parse(row.Cells["ReimbursableCost"].Value.ToString());

                    dblTotalBillable += double.Parse(row.Cells["Billable"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void DisplayMessage(string msg, Color color)
        {
            lblMessage.Text = msg;
            lblMessage.ForeColor = color;
        }

        private void BtnLastMonth_Click(object sender, EventArgs e)
        {
            try
            {
                const string where = " WHERE R.Date >= date('now', 'start of month', '-1 month') AND R.Date < date('now','start of month') ";
                FillRecordView(where);

                string cmd = "SELECT date('now', 'start of month', '-1 month')";
                string startDate = oDAL.ReadString(cmd);
                dtpFilterStart.Value = DateTime.Parse(startDate);

                cmd = "SELECT date('now','start of month', '-1 day')";
                string endDate = oDAL.ReadString(cmd);
                dtpFilterEnd.Value = DateTime.Parse(endDate);

                if (dgvRecords.DataSource == null || dgvRecords.RowCount < 1)
                    OnRowNumberChanged();
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void BtnLast30_Click(object sender, EventArgs e)
        {
            try
            {
                const string where = " WHERE R.Date >= date('now','-30 days') ";
                FillRecordView(where);

                const string cmd = "SELECT date('now','-30 days')";
                string startDate = oDAL.ReadString(cmd);
                dtpFilterStart.Value = DateTime.Parse(startDate);

                dtpFilterEnd.Value = DateTime.Now;

                if (dgvRecords.DataSource == null || dgvRecords.RowCount < 1)
                    OnRowNumberChanged();
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void BtnYTD_Click(object sender, EventArgs e)
        {
            try
            {
                const string where = " WHERE R.Date >= date('now', 'start of year') AND R.Date < date('now','start of year', '+1 year') ";
                FillRecordView(where);

                const string cmd = "SELECT date('now', 'start of year')";
                string startDate = oDAL.ReadString(cmd);
                dtpFilterStart.Value = DateTime.Parse(startDate);

                dtpFilterEnd.Value = DateTime.Now;

                if (dgvRecords.DataSource == null || dgvRecords.RowCount < 1)
                    OnRowNumberChanged();
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void BtnMTD_Click(object sender, EventArgs e)
        {
            try
            {
                const string where = " WHERE R.Date >= date('now', 'start of month') AND R.Date < date('now','start of month', '+1 month') ";
                FillRecordView(where);

                const string cmd = "SELECT date('now', 'start of month')";
                string startDate = oDAL.ReadString(cmd);
                dtpFilterStart.Value = DateTime.Parse(startDate);

                dtpFilterEnd.Value = DateTime.Now;

                if (dgvRecords.DataSource == null || dgvRecords.RowCount < 1)
                    OnRowNumberChanged();
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void BtnAll_Click(object sender, EventArgs e)
        {
            try
            {
                FillRecordView("");

                string cmd = "SELECT MIN(date) FROM Record";
                string startDate = oDAL.ReadString(cmd);
                dtpFilterStart.Value = DateTime.Parse(startDate);

                cmd = "SELECT MAX(date) FROM Record";
                string endDate = oDAL.ReadString(cmd);
                dtpFilterEnd.Value = DateTime.Parse(endDate);

                if (dgvRecords.DataSource == null || dgvRecords.RowCount < 1)
                    OnRowNumberChanged();
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRecords.DataSource == null)
                {
                    MessageBox.Show(@"Data table is empty. Select a view or filter to populate table");
                    return;
                }

                if (dgvRecords.SelectedRows.Count > 0)
                {
                    //oDAL.BackupDB();
                    int i = 0;
                    DialogResult result = MessageBox.Show(@"Selected rows will be deleted. Continue?", @"Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow dr in dgvRecords.SelectedRows)
                        {
                            if (oDAL.DeleteRecord("Record", "RowID", dr.Cells["RowID"].Value.ToString()))
                            {
                                dgvRecords.Rows.RemoveAt(dr.Index);
                                iCount--;
                                i++;
                            }
                            else
                            {
                                DisplayMessage("An unexpected error has occurred at row index " + dr.Index, Color.Red);
                                return;
                            }
                        }

                        if (i == 1)
                        {
                            DisplayMessage("1 record deleted", Color.Green);
                            _logger.LogInformation("1 record deleted");
                        }

                        else if (i > 1)
                        {
                            DisplayMessage(i + " records deleted", Color.Green);
                            _logger.LogInformation(i + " records deleted");
                        }

                        lblRecordCount.Text = dgvRecords.Rows.Count.ToString();
                    }
                    else
                        return;
                }
                else
                {
                    MessageBox.Show(@"No rows selected. Select one or more rows by clicking the black arrow in the left-most cell");
                }
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }


        private void BackupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _logger.LogInformation("Database backup initiated via Tools -> Backup Database");
                if (!oDAL.BackupDB())
                {
                    DisplayMessage("An unexpected error has occurred. Database backup failed", Color.Red);
                    return;
                }
                DisplayMessage("Backup successful", Color.Green);
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void ArchiveBackupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _logger.LogInformation("Backup archive initiated via Tools -> Archive Backups");
                if (!oDAL.ArchiveBackups())
                {
                    DisplayMessage("An unexpected error has occurred. Archive failed", Color.Red);
                    return;
                }                
                DisplayMessage("Archive successful", Color.Green);
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            try
            {
                if (dgvRecords.SelectedCells.Count < 1 && dgvRecords.DataSource != null)
                    MessageBox.Show(@"Select a cell or row to load from");
                else if (dgvRecords.DataSource == null)
                    MessageBox.Show(@"Data table is empty. Select a view or filter to populate table");
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
                    txtComments.Text = dr.Cells["Comments"].Value.ToString();

                    if (!string.IsNullOrEmpty(dr.Cells["StartTime"].Value.ToString()) && dr.Cells["StartTime"].Value != DBNull.Value)
                        dtpStartTime.Value = DateTime.ParseExact(dr.Cells["StartTime"].Value.ToString(), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

                    if (!string.IsNullOrEmpty(dr.Cells["EndTime"].Value.ToString()) && dr.Cells["EndTime"].Value != DBNull.Value)
                        dtpEndTime.Value = DateTime.ParseExact(dr.Cells["EndTime"].Value.ToString(), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void BtnUpdateRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRecords.DataSource == null)
                {
                    MessageBox.Show(@"Data table is empty. Select a view or filter to populate table");
                    return;
                }

                DialogResult result = MessageBox.Show(@"Description and Comments field will be updated for all visible records. Continue?", @"Apply Changes Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    oDAL.UpdateRecord(dgvRecords);
                    lblMessage.ForeColor = Color.Green;
                    lblMessage.Text = @"Update Successful";
                    RefreshCurrentView();
                    _logger.LogInformation("Record update successful");
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void BtnRefreshView_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshRecordGrid();
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ResetRecordGrid();
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void RefreshRecordGrid()
        {
            try
            {
                if (dgvRecords.DataSource == null || dgvRecords.RowCount < 1)
                    return;

                string IDs = "";
                foreach (DataGridViewRow row in dgvRecords.Rows)
                {
                    IDs += row.Cells["RowID"].Value + ",";
                }
                IDs = IDs.Remove(IDs.Length - 1);
                string where = " WHERE R.RowID IN (" + IDs + ")";

                FillRecordView(where);
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void ResetRecordGrid()
        {
            try
            {
                lblMessage.Text = "";
                lblRecordCount.Text = "";
                dtpFilterStart.Value = DateTime.Today;
                dtpFilterEnd.Value = DateTime.Today;
                cbFilterClient.SelectedIndex = 0;

                lblAggrHoursSum.Text = @"0.00";
                lblAggrReimbursableSum.Text = @"$0.00";
                lblAggrBillableSum.Text = @"$0.00";

                if (iCount > 0)
                {
                    string cmd = "SELECT R.CreateDate, R.Client, R.ProService, R.Task, R.Item, R.Date, R.StartTimeOnly, R.EndTimeOnly, R.Hours, " +
                                 "C.Rate, R.ReimbursableCost, round((R.Hours * C.Rate) + R.ReimbursableCost, 2) Billable, R.Description, R.Comments, R.RowID, " +
                                 "C.AddressLine1, C.AddressLine2, C.City, C.State, C.Zip, R.StartTime, R.EndTime  " +
                                 "FROM Record R " +
                                 "INNER JOIN Client C ON R.Client = C.ClientName " +
                                 "ORDER BY R.Date, R.StartTime LIMIT " + iCount;
                    oDAL.FillDataGrid(cmd, dgvRecords);
                }
                else
                    dgvRecords.DataSource = null;
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void InitializeTimer()
        {
            timer.Interval = 9000000;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                oDAL.BackupDB();                
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void DatabaseConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BackupDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oDAL.SetBackupDir();
        }

        private void ArchiveDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oDAL.SetArchiveDir();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDatabaseConnection();
            ResetRecordGrid();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (oDAL.FileSaveAs())
                {
                    strCurrDatabase = oDAL.ReadString("SELECT file FROM pragma_database_list WHERE seq = 0");
                    lblDatabaseName.Text = Path.GetFileName(strCurrDatabase);
                    ResetRecordGrid();
                    DisplayMessage(@"Database file saved successfully", Color.Green);
                    _logger.LogInformation("Database file saved via File -> Save As: {0}", oDAL.SaveAsFilename);
                }
                else
                    DisplayMessage(@"Database file was not saved", Color.Red);
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }

        private void SetDatabaseConnection()
        {
            try
            {
                using (OpenFileDialog ofg = new OpenFileDialog())
                {
                    ofg.Filter = @"SQLite Database|*.db";
                    ofg.RestoreDirectory = true;
                    ofg.Title = "Select SQLite database";

                    if (ofg.ShowDialog() != DialogResult.OK) 
                        return;

                    string filePath = @"DataSource=" + ofg.FileName + ";Version=3;";

                    oDAL.SetConnectionStringConfig("Default", filePath);                    

                    strCurrDatabase = oDAL.ReadString("SELECT file FROM pragma_database_list WHERE seq = 0");
                    lblDatabaseName.Text = Path.GetFileName(strCurrDatabase);
                    ResetRecordGrid();
                    DisplayMessage(@"Database loaded successfully", Color.Green);
                    _logger.LogInformation("New database loaded via File -> Open: {0}", ofg.FileName);
                }
            }
            catch (Exception ex)
            {
                DisplayMessage("An unexpected error has occurred", Color.Red);
                _logger.LogError(ex, ex.Source);
            }
        }
    }
}
