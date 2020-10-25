namespace WorkLog
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
            this.lblComments = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtReimburseCost = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.cbItem = new System.Windows.Forms.ComboBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvRecords = new System.Windows.Forms.DataGridView();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.gbDataFilters = new System.Windows.Forms.GroupBox();
            this.dtpFilterStart = new System.Windows.Forms.DateTimePicker();
            this.dtpFilterEnd = new System.Windows.Forms.DateTimePicker();
            this.lblFilterStart = new System.Windows.Forms.Label();
            this.lblFilterEnd = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.addSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.professionalServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.gbDataFilters.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbClient
            // 
            this.cbClient.CausesValidation = false;
            this.cbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(16, 56);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(215, 24);
            this.cbClient.TabIndex = 0;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(16, 40);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(33, 13);
            this.lblClient.TabIndex = 1;
            this.lblClient.Text = "Client";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(8, 98);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(111, 24);
            this.dtpStartTime.TabIndex = 2;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(8, 82);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(55, 13);
            this.lblStartTime.TabIndex = 5;
            this.lblStartTime.Text = "Start Time";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(133, 82);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(52, 13);
            this.lblEndTime.TabIndex = 7;
            this.lblEndTime.Text = "End Time";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(136, 98);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(111, 24);
            this.dtpEndTime.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(763, 196);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 22);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.Location = new System.Drawing.Point(263, 103);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(63, 18);
            this.lblHours.TabIndex = 9;
            this.lblHours.Text = "lblHours";
            // 
            // lblTotalHours
            // 
            this.lblTotalHours.AutoSize = true;
            this.lblTotalHours.Location = new System.Drawing.Point(263, 82);
            this.lblTotalHours.Name = "lblTotalHours";
            this.lblTotalHours.Size = new System.Drawing.Size(62, 13);
            this.lblTotalHours.TabIndex = 11;
            this.lblTotalHours.Text = "Total Hours";
            // 
            // lblProService
            // 
            this.lblProService.AutoSize = true;
            this.lblProService.Location = new System.Drawing.Point(234, 40);
            this.lblProService.Name = "lblProService";
            this.lblProService.Size = new System.Drawing.Size(103, 13);
            this.lblProService.TabIndex = 13;
            this.lblProService.Text = "Professional Service";
            // 
            // cbProService
            // 
            this.cbProService.CausesValidation = false;
            this.cbProService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProService.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProService.FormattingEnabled = true;
            this.cbProService.Location = new System.Drawing.Point(237, 56);
            this.cbProService.Name = "cbProService";
            this.cbProService.Size = new System.Drawing.Size(215, 24);
            this.cbProService.TabIndex = 12;
            this.cbProService.SelectedIndexChanged += new System.EventHandler(this.CbProService_SelectedIndexChanged);
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Location = new System.Drawing.Point(13, 97);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(31, 13);
            this.lblTask.TabIndex = 15;
            this.lblTask.Text = "Task";
            // 
            // cbTask
            // 
            this.cbTask.CausesValidation = false;
            this.cbTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTask.FormattingEnabled = true;
            this.cbTask.Location = new System.Drawing.Point(16, 113);
            this.cbTask.Name = "cbTask";
            this.cbTask.Size = new System.Drawing.Size(215, 24);
            this.cbTask.TabIndex = 14;
            this.cbTask.SelectedIndexChanged += new System.EventHandler(this.CbTask_SelectedIndexChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(8, 198);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(391, 20);
            this.txtDescription.TabIndex = 16;
            // 
            // lblComments
            // 
            this.lblComments.AutoSize = true;
            this.lblComments.Location = new System.Drawing.Point(5, 182);
            this.lblComments.Name = "lblComments";
            this.lblComments.Size = new System.Drawing.Size(60, 13);
            this.lblComments.TabIndex = 17;
            this.lblComments.Text = "Description";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(8, 40);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 18;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(8, 24);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 19;
            this.lblDate.Text = "Date";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.txtReimburseCost);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.btnView);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.lblComments);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.dtpStartTime);
            this.groupBox1.Controls.Add(this.lblStartTime);
            this.groupBox1.Controls.Add(this.dtpEndTime);
            this.groupBox1.Controls.Add(this.lblEndTime);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.lblTotalHours);
            this.groupBox1.Controls.Add(this.lblHours);
            this.groupBox1.Location = new System.Drawing.Point(16, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 227);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // txtReimburseCost
            // 
            this.txtReimburseCost.Enabled = false;
            this.txtReimburseCost.Location = new System.Drawing.Point(99, 148);
            this.txtReimburseCost.Name = "txtReimburseCost";
            this.txtReimburseCost.Size = new System.Drawing.Size(100, 20);
            this.txtReimburseCost.TabIndex = 18;
            this.txtReimburseCost.Text = "0";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(405, 196);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(78, 23);
            this.btnSubmit.TabIndex = 28;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(489, 196);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(109, 23);
            this.btnView.TabIndex = 31;
            this.btnView.Text = "View Records";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.BtnView_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reimbursable Cost";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(234, 97);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(27, 13);
            this.lblItem.TabIndex = 22;
            this.lblItem.Text = "Item";
            // 
            // cbItem
            // 
            this.cbItem.CausesValidation = false;
            this.cbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbItem.FormattingEnabled = true;
            this.cbItem.Location = new System.Drawing.Point(237, 113);
            this.cbItem.Name = "cbItem";
            this.cbItem.Size = new System.Drawing.Size(215, 24);
            this.cbItem.TabIndex = 21;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(458, 113);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(78, 24);
            this.btnTest.TabIndex = 26;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(542, 113);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(78, 24);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // dgvRecords
            // 
            this.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecords.Location = new System.Drawing.Point(16, 394);
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.Size = new System.Drawing.Size(847, 223);
            this.dgvRecords.TabIndex = 32;
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(16, 373);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(847, 18);
            this.lblMessage.TabIndex = 33;
            this.lblMessage.Text = "lblMessage";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(604, 196);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(78, 23);
            this.btnExport.TabIndex = 32;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // gbDataFilters
            // 
            this.gbDataFilters.Controls.Add(this.btnFilter);
            this.gbDataFilters.Controls.Add(this.lblFilterStart);
            this.gbDataFilters.Controls.Add(this.lblFilterEnd);
            this.gbDataFilters.Controls.Add(this.dtpFilterStart);
            this.gbDataFilters.Controls.Add(this.dtpFilterEnd);
            this.gbDataFilters.Location = new System.Drawing.Point(16, 623);
            this.gbDataFilters.Name = "gbDataFilters";
            this.gbDataFilters.Size = new System.Drawing.Size(847, 81);
            this.gbDataFilters.TabIndex = 34;
            this.gbDataFilters.TabStop = false;
            this.gbDataFilters.Text = "Filter Data View";
            // 
            // dtpFilterStart
            // 
            this.dtpFilterStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFilterStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterStart.Location = new System.Drawing.Point(11, 40);
            this.dtpFilterStart.Name = "dtpFilterStart";
            this.dtpFilterStart.Size = new System.Drawing.Size(111, 24);
            this.dtpFilterStart.TabIndex = 36;
            // 
            // dtpFilterEnd
            // 
            this.dtpFilterEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFilterEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterEnd.Location = new System.Drawing.Point(128, 40);
            this.dtpFilterEnd.Name = "dtpFilterEnd";
            this.dtpFilterEnd.Size = new System.Drawing.Size(111, 24);
            this.dtpFilterEnd.TabIndex = 37;
            // 
            // lblFilterStart
            // 
            this.lblFilterStart.AutoSize = true;
            this.lblFilterStart.Location = new System.Drawing.Point(8, 23);
            this.lblFilterStart.Name = "lblFilterStart";
            this.lblFilterStart.Size = new System.Drawing.Size(55, 13);
            this.lblFilterStart.TabIndex = 38;
            this.lblFilterStart.Text = "Start Date";
            // 
            // lblFilterEnd
            // 
            this.lblFilterEnd.AutoSize = true;
            this.lblFilterEnd.Location = new System.Drawing.Point(125, 23);
            this.lblFilterEnd.Name = "lblFilterEnd";
            this.lblFilterEnd.Size = new System.Drawing.Size(52, 13);
            this.lblFilterEnd.TabIndex = 39;
            this.lblFilterEnd.Text = "End Date";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(245, 40);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 24);
            this.btnFilter.TabIndex = 40;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.BtnFilter_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 24);
            this.menuStrip1.TabIndex = 35;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSelectionToolStripMenuItem});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 19);
            this.menuFile.Text = "File";
            // 
            // addSelectionToolStripMenuItem
            // 
            this.addSelectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientToolStripMenuItem,
            this.professionalServiceToolStripMenuItem,
            this.taskToolStripMenuItem,
            this.itemToolStripMenuItem});
            this.addSelectionToolStripMenuItem.Name = "addSelectionToolStripMenuItem";
            this.addSelectionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addSelectionToolStripMenuItem.Text = "Add Selection";
            // 
            // clientToolStripMenuItem
            // 
            this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clientToolStripMenuItem.Text = "Client";
            // 
            // professionalServiceToolStripMenuItem
            // 
            this.professionalServiceToolStripMenuItem.Name = "professionalServiceToolStripMenuItem";
            this.professionalServiceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.professionalServiceToolStripMenuItem.Text = "Professional Service";
            // 
            // taskToolStripMenuItem
            // 
            this.taskToolStripMenuItem.Name = "taskToolStripMenuItem";
            this.taskToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.taskToolStripMenuItem.Text = "Task";
            // 
            // itemToolStripMenuItem
            // 
            this.itemToolStripMenuItem.Name = "itemToolStripMenuItem";
            this.itemToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.itemToolStripMenuItem.Text = "Item";
            // 
            // WorkLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 732);
            this.Controls.Add(this.gbDataFilters);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.dgvRecords);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.cbItem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblTask);
            this.Controls.Add(this.cbTask);
            this.Controls.Add(this.lblProService);
            this.Controls.Add(this.cbProService);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WorkLog";
            this.Text = "Work Log";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.gbDataFilters.ResumeLayout(false);
            this.gbDataFilters.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.ComboBox cbItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReimburseCost;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DataGridView dgvRecords;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.GroupBox gbDataFilters;
        private System.Windows.Forms.DateTimePicker dtpFilterStart;
        private System.Windows.Forms.DateTimePicker dtpFilterEnd;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label lblFilterStart;
        private System.Windows.Forms.Label lblFilterEnd;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem addSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem professionalServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItem;
    }
}

