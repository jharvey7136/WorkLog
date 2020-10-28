﻿using System;
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

namespace WorkLog
{
    public partial class WorkLog : Form
    {
        DAL oDAL = new DAL();

        public WorkLog()
        {
            InitializeComponent();
            InitializeDefaults();

            dtpStartTime.ValueChanged += new EventHandler(dtpStartTime_ValueChanged);
            dtpEndTime.ValueChanged += new EventHandler(dtpEndTime_ValueChanged);

            txtReimburseCost.KeyPress += new KeyPressEventHandler(TxtReimburseCost_KeyPress);
        }

        private void InitializeDefaults()
        {
            dtpStartTime.CustomFormat = "h:mm tt";
            dtpEndTime.CustomFormat = "h:mm tt";
            lblHours.Text = Math.Round(CalculateTimespan().TotalHours, 2).ToString();

            cbClient.SelectedValue = "";
            cbProService.SelectedValue = "";
            lblMessage.Text = "";

            oDAL.FillComboBox("SELECT ClientID, ClientName FROM Client", cbClient, "ClientName", "ClientID");
            oDAL.FillComboBox("SELECT ProServiceID, ProServiceName FROM ProfessionalService", cbProService, "ProServiceName", "ProServiceID");
        }

        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            lblHours.Text = GetTotalHours();
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            lblHours.Text = GetTotalHours();
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

        private void CbProService_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cmd = "";
            if (cbProService.SelectedValue.ToString() != "System.Data.DataRowView" && cbProService.SelectedValue != null)
                cmd = "SELECT TaskID, TaskName FROM Task WHERE ProServiceID = " + cbProService.SelectedValue;
            else
                cmd = "SELECT TaskID, TaskName FROM Task WHERE ProServiceID = 1";

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
            if (cbTask.SelectedValue.ToString() != "System.Data.DataRowView" && cbTask.SelectedValue != null)
                cmd = "SELECT ItemID, ItemName FROM Item WHERE ProServiceID = " + cbProService.SelectedValue;
            else
                cmd = "SELECT ItemID, ItemName FROM Item WHERE ProServiceID = 1";

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
            int d = rnd.Next(1, 200);

            dtpDate.Value = DateTime.Now.AddDays(d * -1);
            dtpStartTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hr, m, 0);
            dtpEndTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hr + rnd.Next(1, 11), m + rnd.Next(1, 29), 0);
            txtDescription.Text = "";
            int r = rnd.Next(1, 30);
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
                                oDAL.InsertRecord(myRecord, true);
                            else
                                return;
                        }
                        else
                            oDAL.InsertRecord(myRecord, true);
                    }
                    else
                        oDAL.InsertRecord(myRecord, false);

                    FillDataGridOnSubmit();
                    lblMessage.ForeColor = Color.Green;
                    lblMessage.Text = "Record submitted successfully! Last 30 entries displayed";
                }
                catch (Exception ex)
                {
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Text = "Error submitting record, verify selections and try again";
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void FillDataGridOnSubmit()
        {
            string cmd = "SELECT CreateDate, Client, ProService, Task, Item, Date, StartTime, EndTime, Hours, ReimbursableCost, Description " +
                "FROM Record ORDER BY RowID DESC LIMIT 30";
            oDAL.FillDataGrid(cmd, dgvRecords);
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
                    MessageBox.Show("Start Time cannot equal End Time");
                    return false;
                }
            }
            return true;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = "SELECT CreateDate, Client, ProService, Task, Item, Date, StartTime, EndTime, Hours, ReimbursableCost, Description " +
                                "FROM Record ORDER BY RowID DESC";
                DataTable dt = DAL.CreateDataTable(cmd);
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "csv|*.csv";
                sfd.Title = "Export Records to CSV";
                sfd.ShowDialog();
                dt.ToCSV(sfd.FileName);
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "Data exported successfully!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                string start = dtpFilterStart.Value.ToString("yyyy-MM-dd");
                string end = dtpFilterEnd.Value.ToString("yyyy-MM-dd");
                string cmd = "SELECT CreateDate, Client, ProService, Task, Item, Date, StartTime, EndTime, Hours, ReimbursableCost, Description " +
                             "FROM Record " +
                             "WHERE Date BETWEEN '" + start + "' AND '" + end + "' " +
                             "ORDER BY Date";
                oDAL.FillDataGrid(cmd, dgvRecords);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ToolStripManageCat_Click(object sender, EventArgs e)
        {
            CategoryForm formCategories = new CategoryForm();
            formCategories.ShowDialog();
        }

        private void BtnLastMonth_Click(object sender, EventArgs e)
        {
            string cmd = "SELECT CreateDate, Client, ProService, Task, Item, Date, StartTime, EndTime, Hours, ReimbursableCost, Description " +
                         "FROM Record WHERE date >= date('now', 'start of month', '-1 month') AND date<date('now','start of month') ORDER BY Date";
            oDAL.FillDataGrid(cmd, dgvRecords);
        }

        private void BtnLast30_Click(object sender, EventArgs e)
        {
            string cmd = "SELECT CreateDate, Client, ProService, Task, Item, Date, StartTime, EndTime, Hours, ReimbursableCost, Description " +
                         "FROM Record WHERE date >= date('now','-30 days') ORDER BY Date";
            oDAL.FillDataGrid(cmd, dgvRecords);
        }

        private void BtnYTD_Click(object sender, EventArgs e)
        {
            string cmd = "SELECT CreateDate, Client, ProService, Task, Item, Date, StartTime, EndTime, Hours, ReimbursableCost, Description " +
                         "FROM Record WHERE date >= date('now', 'start of year') AND date<date('now','start of year', '+1 year')";
            oDAL.FillDataGrid(cmd, dgvRecords);
        }

        private void GetRecordAggregates()
        {

        }



    }
}
