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

            oDAL.FillComboBox("SELECT ClientID, ClientName FROM Client", cbClient, "ClientName", "ClientID");
            oDAL.FillComboBox("SELECT ProServiceID, ProServiceName FROM ProfessionalService", cbProService, "ProServiceName", "ProServiceID");
            ResetPreview();
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
            }
            else
            {
                txtReimburseCost.Enabled = false;
                dtpStartTime.Enabled = true;
                dtpEndTime.Enabled = true;
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

        private void TxtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar)
                    && e.KeyChar != '.')
            {
                e.Handled = true;
            }
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
            GeneratePreview();
        }

        private void ResetPreview()
        {
            lblPrevClient.Text = "";
            lblPrevDate.Text = "";
            lblPrevDescription.Text = "";
            lblPrevHours.Text = "";
            lblPrevItem.Text = "";
            lblPrevProService.Text = "";
            lblPrevTask.Text = "";
            lblPrevTime.Text = "";
            lblPrevReimburse.Text = "";
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            int i = rnd.Next(1, 15);
            cbClient.SelectedValue = i;

            i = rnd.Next(1, 3);
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
            dtpStartTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hr, m, 0);

            dtpEndTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hr + rnd.Next(1, 11), m + rnd.Next(1, 29), 0);

            txtDescription.Text = "The quick brown fox jumped over the lazy brown dog";
            GeneratePreview();
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

        private void GeneratePreview()
        {
            try
            {
                Record myRecord = NewRecord();

                lblPrevClient.Text = myRecord.Client;
                lblPrevDate.Text = String.Format("{0:M/d/yyyy}", myRecord.Date);
                lblPrevDescription.Text = myRecord.Description;
                lblPrevHours.Text = myRecord.TotalHours.ToString();
                lblPrevItem.Text = myRecord.Item;
                lblPrevProService.Text = myRecord.ProService;
                lblPrevTask.Text = myRecord.Task;
                lblPrevTime.Text = String.Format("{0:t}", myRecord.StartTime) + " - " + String.Format("{0:t}", myRecord.EndTime);

                if (cbProService.Text == "Reimbursable")
                {
                    lblPrevHours.Text = "";
                    lblPrevTime.Text = "";
                    lblPrevReimburse.Text = myRecord.ReimburseAmount.ToString();
                }
                else
                {
                    lblPrevReimburse.Text = "";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            cbClient.SelectedValue = 0;
            cbProService.SelectedValue = 0;
            cbTask.SelectedValue = 0;
            cbItem.SelectedValue = 0;

            dtpStartTime.Value = DateTime.Now;
            dtpEndTime.Value = DateTime.Now;

            txtDescription.Text = "";

            lblPrevClient.Text = "";
            lblPrevDate.Text = "";
            lblPrevDescription.Text = "";
            lblPrevHours.Text = "";
            lblPrevItem.Text = "";
            lblPrevProService.Text = "";
            lblPrevTask.Text = "";
            lblPrevTime.Text = "";

            
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Record myRecord = NewRecord();
                oDAL.InsertRecord(myRecord);
                //MessageBox.Show(myRecord.PrintRecord());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            List<Record> record = new List<Record>();

            record = DAL.LoadRecords();

            //listOutput.DataSource = record;
            //listOutput.DisplayMember = "FullRecord";

            string cmd = "SELECT * FROM Record";

            oDAL.FillDataGrid(cmd, dgvRecords);
        }
    }
}
