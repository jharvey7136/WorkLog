﻿namespace WorkLog
{
    partial class WorkLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkLog));
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblTotalHours = new System.Windows.Forms.Label();
            this.lblProService = new System.Windows.Forms.Label();
            this.cbProService = new System.Windows.Forms.ComboBox();
            this.lblTask = new System.Windows.Forms.Label();
            this.cbTask = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.lblComments = new System.Windows.Forms.Label();
            this.txtReimburseCost = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblReimbursableCost = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.cbItem = new System.Windows.Forms.ComboBox();
            this.dgvRecords = new System.Windows.Forms.DataGridView();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.gbDataFilters = new System.Windows.Forms.GroupBox();
            this.lblAggrReimbursableSum = new System.Windows.Forms.Label();
            this.lblAggrReimbursable = new System.Windows.Forms.Label();
            this.lblAggrBillableSum = new System.Windows.Forms.Label();
            this.lblAggrBillable = new System.Windows.Forms.Label();
            this.lblAggrHoursSum = new System.Windows.Forms.Label();
            this.lblAggrHours = new System.Windows.Forms.Label();
            this.lblTotals = new System.Windows.Forms.Label();
            this.lblFilterClient = new System.Windows.Forms.Label();
            this.cbFilterClient = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnMTD = new System.Windows.Forms.Button();
            this.btnYTD = new System.Windows.Forms.Button();
            this.btnLast30 = new System.Windows.Forms.Button();
            this.btnLastMonth = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.lblFilterStart = new System.Windows.Forms.Label();
            this.lblFilterEnd = new System.Windows.Forms.Label();
            this.dtpFilterStart = new System.Windows.Forms.DateTimePicker();
            this.dtpFilterEnd = new System.Windows.Forms.DateTimePicker();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripManageCat = new System.Windows.Forms.ToolStripMenuItem();
            this.backupDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archiveBackupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archiveDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdateRecord = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.btnRefreshView = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.gbDataFilters.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbClient
            // 
            this.cbClient.CausesValidation = false;
            this.cbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(610, 40);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(250, 24);
            this.cbClient.TabIndex = 5;
            // 
            // lblClient
            // 
            this.lblClient.Location = new System.Drawing.Point(610, 24);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(68, 13);
            this.lblClient.TabIndex = 1;
            this.lblClient.Text = "Client";
            this.lblClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(283, 50);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(154, 22);
            this.dtpStartTime.TabIndex = 2;
            // 
            // lblStartTime
            // 
            this.lblStartTime.Location = new System.Drawing.Point(207, 57);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(70, 13);
            this.lblStartTime.TabIndex = 5;
            this.lblStartTime.Text = "Start Time";
            this.lblStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEndTime
            // 
            this.lblEndTime.Location = new System.Drawing.Point(207, 90);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(70, 13);
            this.lblEndTime.TabIndex = 7;
            this.lblEndTime.Text = "End Time";
            this.lblEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(283, 83);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(154, 22);
            this.dtpEndTime.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1283, 78);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 24);
            this.btnClose.TabIndex = 29;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.Location = new System.Drawing.Point(280, 114);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(63, 18);
            this.lblHours.TabIndex = 9;
            this.lblHours.Text = "lblHours";
            // 
            // lblTotalHours
            // 
            this.lblTotalHours.Location = new System.Drawing.Point(207, 118);
            this.lblTotalHours.Name = "lblTotalHours";
            this.lblTotalHours.Size = new System.Drawing.Size(70, 13);
            this.lblTotalHours.TabIndex = 11;
            this.lblTotalHours.Text = "Total Hours";
            this.lblTotalHours.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProService
            // 
            this.lblProService.Location = new System.Drawing.Point(879, 24);
            this.lblProService.Name = "lblProService";
            this.lblProService.Size = new System.Drawing.Size(253, 13);
            this.lblProService.TabIndex = 13;
            this.lblProService.Text = "Professional Service";
            this.lblProService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbProService
            // 
            this.cbProService.CausesValidation = false;
            this.cbProService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProService.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProService.FormattingEnabled = true;
            this.cbProService.Location = new System.Drawing.Point(882, 40);
            this.cbProService.Name = "cbProService";
            this.cbProService.Size = new System.Drawing.Size(250, 24);
            this.cbProService.TabIndex = 6;
            this.cbProService.SelectedIndexChanged += new System.EventHandler(this.CbProService_SelectedIndexChanged);
            // 
            // lblTask
            // 
            this.lblTask.Location = new System.Drawing.Point(610, 81);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(63, 13);
            this.lblTask.TabIndex = 15;
            this.lblTask.Text = "Task";
            this.lblTask.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbTask
            // 
            this.cbTask.CausesValidation = false;
            this.cbTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTask.FormattingEnabled = true;
            this.cbTask.Location = new System.Drawing.Point(610, 97);
            this.cbTask.Name = "cbTask";
            this.cbTask.Size = new System.Drawing.Size(250, 24);
            this.cbTask.TabIndex = 7;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(556, 151);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(318, 20);
            this.txtDescription.TabIndex = 9;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(490, 154);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 17;
            this.lblDescription.Text = "Description";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(283, 21);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(202, 20);
            this.dtpDate.TabIndex = 1;
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(207, 24);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(70, 13);
            this.lblDate.TabIndex = 19;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtComments);
            this.groupBox1.Controls.Add(this.lblComments);
            this.groupBox1.Controls.Add(this.txtReimburseCost);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.btnTest);
            this.groupBox1.Controls.Add(this.lblDescription);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.lblReimbursableCost);
            this.groupBox1.Controls.Add(this.lblItem);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.dtpStartTime);
            this.groupBox1.Controls.Add(this.cbItem);
            this.groupBox1.Controls.Add(this.lblStartTime);
            this.groupBox1.Controls.Add(this.dtpEndTime);
            this.groupBox1.Controls.Add(this.lblTask);
            this.groupBox1.Controls.Add(this.lblEndTime);
            this.groupBox1.Controls.Add(this.cbTask);
            this.groupBox1.Controls.Add(this.lblTotalHours);
            this.groupBox1.Controls.Add(this.lblProService);
            this.groupBox1.Controls.Add(this.lblHours);
            this.groupBox1.Controls.Add(this.cbProService);
            this.groupBox1.Controls.Add(this.lblClient);
            this.groupBox1.Controls.Add(this.cbClient);
            this.groupBox1.Location = new System.Drawing.Point(24, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1369, 219);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(556, 176);
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(318, 20);
            this.txtComments.TabIndex = 10;
            // 
            // lblComments
            // 
            this.lblComments.Location = new System.Drawing.Point(490, 179);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(60, 13);
            this.lblComments.TabIndex = 24;
            this.lblComments.Text = "Comments";
            this.lblComments.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtReimburseCost
            // 
            this.txtReimburseCost.Enabled = false;
            this.txtReimburseCost.Location = new System.Drawing.Point(300, 151);
            this.txtReimburseCost.Name = "txtReimburseCost";
            this.txtReimburseCost.Size = new System.Drawing.Size(62, 20);
            this.txtReimburseCost.TabIndex = 4;
            this.txtReimburseCost.Text = "0";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(882, 172);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(78, 24);
            this.btnSubmit.TabIndex = 11;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(1050, 172);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(78, 24);
            this.btnTest.TabIndex = 13;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(966, 172);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(78, 24);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // lblReimbursableCost
            // 
            this.lblReimbursableCost.AutoSize = true;
            this.lblReimbursableCost.Location = new System.Drawing.Point(206, 154);
            this.lblReimbursableCost.Name = "lblReimbursableCost";
            this.lblReimbursableCost.Size = new System.Drawing.Size(95, 13);
            this.lblReimbursableCost.TabIndex = 1;
            this.lblReimbursableCost.Text = "Reimbursable Cost";
            // 
            // lblItem
            // 
            this.lblItem.Location = new System.Drawing.Point(882, 81);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(51, 13);
            this.lblItem.TabIndex = 22;
            this.lblItem.Text = "Item";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbItem
            // 
            this.cbItem.CausesValidation = false;
            this.cbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbItem.FormattingEnabled = true;
            this.cbItem.Location = new System.Drawing.Point(882, 97);
            this.cbItem.Name = "cbItem";
            this.cbItem.Size = new System.Drawing.Size(250, 24);
            this.cbItem.TabIndex = 8;
            // 
            // dgvRecords
            // 
            this.dgvRecords.AllowUserToAddRows = false;
            this.dgvRecords.Location = new System.Drawing.Point(24, 270);
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.Size = new System.Drawing.Size(1369, 337);
            this.dgvRecords.TabIndex = 14;
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(169, 249);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(1061, 18);
            this.lblMessage.TabIndex = 33;
            this.lblMessage.Text = "lblMessage";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(1199, 78);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(78, 24);
            this.btnExport.TabIndex = 28;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // gbDataFilters
            // 
            this.gbDataFilters.Controls.Add(this.lblAggrReimbursableSum);
            this.gbDataFilters.Controls.Add(this.lblAggrReimbursable);
            this.gbDataFilters.Controls.Add(this.lblAggrBillableSum);
            this.gbDataFilters.Controls.Add(this.lblAggrBillable);
            this.gbDataFilters.Controls.Add(this.lblAggrHoursSum);
            this.gbDataFilters.Controls.Add(this.lblAggrHours);
            this.gbDataFilters.Controls.Add(this.lblTotals);
            this.gbDataFilters.Controls.Add(this.lblFilterClient);
            this.gbDataFilters.Controls.Add(this.cbFilterClient);
            this.gbDataFilters.Controls.Add(this.btnReset);
            this.gbDataFilters.Controls.Add(this.btnAll);
            this.gbDataFilters.Controls.Add(this.btnMTD);
            this.gbDataFilters.Controls.Add(this.btnYTD);
            this.gbDataFilters.Controls.Add(this.btnLast30);
            this.gbDataFilters.Controls.Add(this.btnLastMonth);
            this.gbDataFilters.Controls.Add(this.btnExport);
            this.gbDataFilters.Controls.Add(this.btnView);
            this.gbDataFilters.Controls.Add(this.lblFilterStart);
            this.gbDataFilters.Controls.Add(this.lblFilterEnd);
            this.gbDataFilters.Controls.Add(this.dtpFilterStart);
            this.gbDataFilters.Controls.Add(this.dtpFilterEnd);
            this.gbDataFilters.Controls.Add(this.btnClose);
            this.gbDataFilters.Location = new System.Drawing.Point(24, 641);
            this.gbDataFilters.Name = "gbDataFilters";
            this.gbDataFilters.Size = new System.Drawing.Size(1369, 112);
            this.gbDataFilters.TabIndex = 34;
            this.gbDataFilters.TabStop = false;
            this.gbDataFilters.Text = "Filter Data View";
            // 
            // lblAggrReimbursableSum
            // 
            this.lblAggrReimbursableSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAggrReimbursableSum.Location = new System.Drawing.Point(885, 58);
            this.lblAggrReimbursableSum.Name = "lblAggrReimbursableSum";
            this.lblAggrReimbursableSum.Size = new System.Drawing.Size(84, 23);
            this.lblAggrReimbursableSum.TabIndex = 55;
            this.lblAggrReimbursableSum.Text = "0";
            this.lblAggrReimbursableSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAggrReimbursable
            // 
            this.lblAggrReimbursable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAggrReimbursable.Location = new System.Drawing.Point(708, 58);
            this.lblAggrReimbursable.Name = "lblAggrReimbursable";
            this.lblAggrReimbursable.Size = new System.Drawing.Size(175, 23);
            this.lblAggrReimbursable.TabIndex = 54;
            this.lblAggrReimbursable.Text = "Reimbursables:";
            this.lblAggrReimbursable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAggrBillableSum
            // 
            this.lblAggrBillableSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAggrBillableSum.Location = new System.Drawing.Point(885, 82);
            this.lblAggrBillableSum.Name = "lblAggrBillableSum";
            this.lblAggrBillableSum.Size = new System.Drawing.Size(84, 23);
            this.lblAggrBillableSum.TabIndex = 53;
            this.lblAggrBillableSum.Text = "0";
            this.lblAggrBillableSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAggrBillable
            // 
            this.lblAggrBillable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAggrBillable.Location = new System.Drawing.Point(708, 82);
            this.lblAggrBillable.Name = "lblAggrBillable";
            this.lblAggrBillable.Size = new System.Drawing.Size(175, 23);
            this.lblAggrBillable.TabIndex = 52;
            this.lblAggrBillable.Text = "Billable:";
            this.lblAggrBillable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAggrHoursSum
            // 
            this.lblAggrHoursSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAggrHoursSum.Location = new System.Drawing.Point(885, 35);
            this.lblAggrHoursSum.Name = "lblAggrHoursSum";
            this.lblAggrHoursSum.Size = new System.Drawing.Size(84, 23);
            this.lblAggrHoursSum.TabIndex = 51;
            this.lblAggrHoursSum.Text = "0";
            this.lblAggrHoursSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAggrHours
            // 
            this.lblAggrHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAggrHours.Location = new System.Drawing.Point(708, 35);
            this.lblAggrHours.Name = "lblAggrHours";
            this.lblAggrHours.Size = new System.Drawing.Size(175, 23);
            this.lblAggrHours.TabIndex = 50;
            this.lblAggrHours.Text = "Hours:";
            this.lblAggrHours.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotals
            // 
            this.lblTotals.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotals.Location = new System.Drawing.Point(737, 11);
            this.lblTotals.Name = "lblTotals";
            this.lblTotals.Size = new System.Drawing.Size(331, 23);
            this.lblTotals.TabIndex = 49;
            this.lblTotals.Text = "Totals";
            this.lblTotals.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFilterClient
            // 
            this.lblFilterClient.Location = new System.Drawing.Point(243, 32);
            this.lblFilterClient.Name = "lblFilterClient";
            this.lblFilterClient.Size = new System.Drawing.Size(52, 13);
            this.lblFilterClient.TabIndex = 48;
            this.lblFilterClient.Text = "Client";
            // 
            // cbFilterClient
            // 
            this.cbFilterClient.DropDownHeight = 160;
            this.cbFilterClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterClient.FormattingEnabled = true;
            this.cbFilterClient.IntegralHeight = false;
            this.cbFilterClient.ItemHeight = 16;
            this.cbFilterClient.Location = new System.Drawing.Point(246, 49);
            this.cbFilterClient.MaxDropDownItems = 20;
            this.cbFilterClient.Name = "cbFilterClient";
            this.cbFilterClient.Size = new System.Drawing.Size(212, 24);
            this.cbFilterClient.TabIndex = 20;
            this.cbFilterClient.SelectedIndexChanged += new System.EventHandler(this.CbFilterClient_SelectedIndexChanged);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(464, 79);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 23);
            this.btnReset.TabIndex = 27;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(373, 79);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(85, 23);
            this.btnAll.TabIndex = 26;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.BtnAll_Click);
            // 
            // btnMTD
            // 
            this.btnMTD.Location = new System.Drawing.Point(191, 79);
            this.btnMTD.Name = "btnMTD";
            this.btnMTD.Size = new System.Drawing.Size(85, 23);
            this.btnMTD.TabIndex = 24;
            this.btnMTD.Text = "MTD";
            this.btnMTD.UseVisualStyleBackColor = true;
            this.btnMTD.Click += new System.EventHandler(this.BtnMTD_Click);
            // 
            // btnYTD
            // 
            this.btnYTD.Location = new System.Drawing.Point(282, 79);
            this.btnYTD.Name = "btnYTD";
            this.btnYTD.Size = new System.Drawing.Size(85, 23);
            this.btnYTD.TabIndex = 25;
            this.btnYTD.Text = "YTD";
            this.btnYTD.UseVisualStyleBackColor = true;
            this.btnYTD.Click += new System.EventHandler(this.BtnYTD_Click);
            // 
            // btnLast30
            // 
            this.btnLast30.Location = new System.Drawing.Point(100, 79);
            this.btnLast30.Name = "btnLast30";
            this.btnLast30.Size = new System.Drawing.Size(85, 23);
            this.btnLast30.TabIndex = 23;
            this.btnLast30.Text = "Last 30 Days";
            this.btnLast30.UseVisualStyleBackColor = true;
            this.btnLast30.Click += new System.EventHandler(this.BtnLast30_Click);
            // 
            // btnLastMonth
            // 
            this.btnLastMonth.Location = new System.Drawing.Point(9, 79);
            this.btnLastMonth.Name = "btnLastMonth";
            this.btnLastMonth.Size = new System.Drawing.Size(85, 23);
            this.btnLastMonth.TabIndex = 22;
            this.btnLastMonth.Text = "Last Month";
            this.btnLastMonth.UseVisualStyleBackColor = true;
            this.btnLastMonth.Click += new System.EventHandler(this.BtnLastMonth_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(464, 49);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(85, 23);
            this.btnView.TabIndex = 21;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // lblFilterStart
            // 
            this.lblFilterStart.Location = new System.Drawing.Point(6, 32);
            this.lblFilterStart.Name = "lblFilterStart";
            this.lblFilterStart.Size = new System.Drawing.Size(55, 13);
            this.lblFilterStart.TabIndex = 38;
            this.lblFilterStart.Text = "Start Date";
            // 
            // lblFilterEnd
            // 
            this.lblFilterEnd.Location = new System.Drawing.Point(123, 32);
            this.lblFilterEnd.Name = "lblFilterEnd";
            this.lblFilterEnd.Size = new System.Drawing.Size(52, 13);
            this.lblFilterEnd.TabIndex = 39;
            this.lblFilterEnd.Text = "End Date";
            // 
            // dtpFilterStart
            // 
            this.dtpFilterStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFilterStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterStart.Location = new System.Drawing.Point(9, 49);
            this.dtpFilterStart.Name = "dtpFilterStart";
            this.dtpFilterStart.Size = new System.Drawing.Size(111, 24);
            this.dtpFilterStart.TabIndex = 18;
            // 
            // dtpFilterEnd
            // 
            this.dtpFilterEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFilterEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterEnd.Location = new System.Drawing.Point(126, 49);
            this.dtpFilterEnd.Name = "dtpFilterEnd";
            this.dtpFilterEnd.Size = new System.Drawing.Size(111, 24);
            this.dtpFilterEnd.TabIndex = 19;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuFile});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1413, 24);
            this.menuStrip.TabIndex = 35;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripManageCat,
            this.backupDatabaseToolStripMenuItem,
            this.archiveBackupsToolStripMenuItem,
            this.configurationToolStripMenuItem});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(46, 20);
            this.menuFile.Text = "Tools";
            // 
            // toolStripManageCat
            // 
            this.toolStripManageCat.Name = "toolStripManageCat";
            this.toolStripManageCat.Size = new System.Drawing.Size(180, 22);
            this.toolStripManageCat.Text = "Manage Categories";
            this.toolStripManageCat.Click += new System.EventHandler(this.ToolStripManageCat_Click);
            // 
            // backupDatabaseToolStripMenuItem
            // 
            this.backupDatabaseToolStripMenuItem.Name = "backupDatabaseToolStripMenuItem";
            this.backupDatabaseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.backupDatabaseToolStripMenuItem.Text = "Backup Database";
            this.backupDatabaseToolStripMenuItem.Click += new System.EventHandler(this.BackupDatabaseToolStripMenuItem_Click);
            // 
            // archiveBackupsToolStripMenuItem
            // 
            this.archiveBackupsToolStripMenuItem.Name = "archiveBackupsToolStripMenuItem";
            this.archiveBackupsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.archiveBackupsToolStripMenuItem.Text = "Archive Backups";
            this.archiveBackupsToolStripMenuItem.Click += new System.EventHandler(this.ArchiveBackupsToolStripMenuItem_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseConnectionToolStripMenuItem,
            this.backupDirectoryToolStripMenuItem,
            this.archiveDirectoryToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // databaseConnectionToolStripMenuItem
            // 
            this.databaseConnectionToolStripMenuItem.Name = "databaseConnectionToolStripMenuItem";
            this.databaseConnectionToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.databaseConnectionToolStripMenuItem.Text = "Set Database Connection";
            this.databaseConnectionToolStripMenuItem.Click += new System.EventHandler(this.DatabaseConnectionToolStripMenuItem_Click);
            // 
            // backupDirectoryToolStripMenuItem
            // 
            this.backupDirectoryToolStripMenuItem.Name = "backupDirectoryToolStripMenuItem";
            this.backupDirectoryToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.backupDirectoryToolStripMenuItem.Text = "Set Backup Directory";
            this.backupDirectoryToolStripMenuItem.Click += new System.EventHandler(this.BackupDirectoryToolStripMenuItem_Click);
            // 
            // archiveDirectoryToolStripMenuItem
            // 
            this.archiveDirectoryToolStripMenuItem.Name = "archiveDirectoryToolStripMenuItem";
            this.archiveDirectoryToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.archiveDirectoryToolStripMenuItem.Text = "Set Archive Directory";
            this.archiveDirectoryToolStripMenuItem.Click += new System.EventHandler(this.ArchiveDirectoryToolStripMenuItem_Click);
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordCount.ForeColor = System.Drawing.Color.Green;
            this.lblRecordCount.Location = new System.Drawing.Point(1312, 610);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(82, 22);
            this.lblRecordCount.TabIndex = 43;
            this.lblRecordCount.Text = "lblRecordCount";
            this.lblRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(24, 613);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 23);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnUpdateRecord
            // 
            this.btnUpdateRecord.Location = new System.Drawing.Point(1109, 613);
            this.btnUpdateRecord.Name = "btnUpdateRecord";
            this.btnUpdateRecord.Size = new System.Drawing.Size(85, 23);
            this.btnUpdateRecord.TabIndex = 16;
            this.btnUpdateRecord.Text = "Update";
            this.btnUpdateRecord.UseVisualStyleBackColor = true;
            this.btnUpdateRecord.Click += new System.EventHandler(this.BtnUpdateRecord_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(1200, 613);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(106, 23);
            this.btnLoad.TabIndex = 17;
            this.btnLoad.Text = "Load Selection";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.Location = new System.Drawing.Point(24, 250);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(166, 17);
            this.lblDatabaseName.TabIndex = 48;
            this.lblDatabaseName.Text = "lblDatabaseName";
            // 
            // btnRefreshView
            // 
            this.btnRefreshView.Location = new System.Drawing.Point(1018, 613);
            this.btnRefreshView.Name = "btnRefreshView";
            this.btnRefreshView.Size = new System.Drawing.Size(85, 23);
            this.btnRefreshView.TabIndex = 49;
            this.btnRefreshView.Text = "Refresh";
            this.btnRefreshView.UseVisualStyleBackColor = true;
            this.btnRefreshView.Click += new System.EventHandler(this.BtnRefreshView_Click);
            // 
            // WorkLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 761);
            this.Controls.Add(this.btnRefreshView);
            this.Controls.Add(this.lblDatabaseName);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnUpdateRecord);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblRecordCount);
            this.Controls.Add(this.gbDataFilters);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.dgvRecords);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "WorkLog";
            this.Text = "Work Log";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.gbDataFilters.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Label lblTotalHours;
        private System.Windows.Forms.Label lblProService;
        private System.Windows.Forms.ComboBox cbProService;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.ComboBox cbTask;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.ComboBox cbItem;
        private System.Windows.Forms.Label lblReimbursableCost;
        private System.Windows.Forms.TextBox txtReimburseCost;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView dgvRecords;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox gbDataFilters;
        private System.Windows.Forms.DateTimePicker dtpFilterStart;
        private System.Windows.Forms.DateTimePicker dtpFilterEnd;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblFilterStart;
        private System.Windows.Forms.Label lblFilterEnd;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripManageCat;
        private System.Windows.Forms.Button btnLast30;
        private System.Windows.Forms.Button btnLastMonth;
        private System.Windows.Forms.Button btnYTD;
        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Button btnMTD;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolStripMenuItem backupDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archiveBackupsToolStripMenuItem;
        private System.Windows.Forms.Button btnUpdateRecord;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox cbFilterClient;
        private System.Windows.Forms.Label lblFilterClient;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Label lblDatabaseName;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.Button btnRefreshView;
        private System.Windows.Forms.Label lblAggrBillableSum;
        private System.Windows.Forms.Label lblAggrBillable;
        private System.Windows.Forms.Label lblAggrHoursSum;
        private System.Windows.Forms.Label lblAggrHours;
        private System.Windows.Forms.Label lblTotals;
        private System.Windows.Forms.Label lblAggrReimbursableSum;
        private System.Windows.Forms.Label lblAggrReimbursable;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archiveDirectoryToolStripMenuItem;
    }
}

