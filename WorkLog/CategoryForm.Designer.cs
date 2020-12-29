namespace WorkLog
{
    partial class CategoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryForm));
            this.tabCategories = new System.Windows.Forms.TabControl();
            this.tabPageClient = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblMessageTop = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnUpdateClient = new System.Windows.Forms.Button();
            this.dgvClient = new System.Windows.Forms.DataGridView();
            this.tabPageProService = new System.Windows.Forms.TabPage();
            this.btnClosePS = new System.Windows.Forms.Button();
            this.lblMessageTopPS = new System.Windows.Forms.Label();
            this.btnRefreshPS = new System.Windows.Forms.Button();
            this.btnUpdatePS = new System.Windows.Forms.Button();
            this.dgvProService = new System.Windows.Forms.DataGridView();
            this.tabPageTask = new System.Windows.Forms.TabPage();
            this.lblMessageTopTask = new System.Windows.Forms.Label();
            this.btnCloseTask = new System.Windows.Forms.Button();
            this.btnRefreshTask = new System.Windows.Forms.Button();
            this.btnUpdateTask = new System.Windows.Forms.Button();
            this.dgvTask = new System.Windows.Forms.DataGridView();
            this.lblProService = new System.Windows.Forms.Label();
            this.cbProService = new System.Windows.Forms.ComboBox();
            this.tabPageItem = new System.Windows.Forms.TabPage();
            this.lblMessageTopItem = new System.Windows.Forms.Label();
            this.btnCloseItem = new System.Windows.Forms.Button();
            this.btnRefreshItem = new System.Windows.Forms.Button();
            this.btnUpdateItem = new System.Windows.Forms.Button();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.lblProServiceItem = new System.Windows.Forms.Label();
            this.cbProServiceItem = new System.Windows.Forms.ComboBox();
            this.btnDeleteClient = new System.Windows.Forms.Button();
            this.btnDeletePS = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.tabCategories.SuspendLayout();
            this.tabPageClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).BeginInit();
            this.tabPageProService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProService)).BeginInit();
            this.tabPageTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).BeginInit();
            this.tabPageItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCategories
            // 
            this.tabCategories.Controls.Add(this.tabPageClient);
            this.tabCategories.Controls.Add(this.tabPageProService);
            this.tabCategories.Controls.Add(this.tabPageTask);
            this.tabCategories.Controls.Add(this.tabPageItem);
            this.tabCategories.Location = new System.Drawing.Point(12, 12);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.SelectedIndex = 0;
            this.tabCategories.Size = new System.Drawing.Size(836, 341);
            this.tabCategories.TabIndex = 0;
            // 
            // tabPageClient
            // 
            this.tabPageClient.Controls.Add(this.btnDeleteClient);
            this.tabPageClient.Controls.Add(this.btnClose);
            this.tabPageClient.Controls.Add(this.lblMessageTop);
            this.tabPageClient.Controls.Add(this.btnRefresh);
            this.tabPageClient.Controls.Add(this.btnUpdateClient);
            this.tabPageClient.Controls.Add(this.dgvClient);
            this.tabPageClient.Location = new System.Drawing.Point(4, 22);
            this.tabPageClient.Name = "tabPageClient";
            this.tabPageClient.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClient.Size = new System.Drawing.Size(828, 315);
            this.tabPageClient.TabIndex = 0;
            this.tabPageClient.Text = "Client";
            this.tabPageClient.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(721, 275);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblMessageTop
            // 
            this.lblMessageTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageTop.Location = new System.Drawing.Point(6, 14);
            this.lblMessageTop.Name = "lblMessageTop";
            this.lblMessageTop.Size = new System.Drawing.Size(816, 22);
            this.lblMessageTop.TabIndex = 3;
            this.lblMessageTop.Text = "lblMessageTop";
            this.lblMessageTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(113, 275);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(101, 32);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // btnUpdateClient
            // 
            this.btnUpdateClient.Location = new System.Drawing.Point(6, 275);
            this.btnUpdateClient.Name = "btnUpdateClient";
            this.btnUpdateClient.Size = new System.Drawing.Size(101, 32);
            this.btnUpdateClient.TabIndex = 1;
            this.btnUpdateClient.Text = "Apply";
            this.btnUpdateClient.UseVisualStyleBackColor = true;
            this.btnUpdateClient.Click += new System.EventHandler(this.BtnUpdateClient_Click);
            // 
            // dgvClient
            // 
            this.dgvClient.Location = new System.Drawing.Point(6, 39);
            this.dgvClient.Name = "dgvClient";
            this.dgvClient.Size = new System.Drawing.Size(816, 230);
            this.dgvClient.TabIndex = 0;
            // 
            // tabPageProService
            // 
            this.tabPageProService.Controls.Add(this.btnDeletePS);
            this.tabPageProService.Controls.Add(this.btnClosePS);
            this.tabPageProService.Controls.Add(this.lblMessageTopPS);
            this.tabPageProService.Controls.Add(this.btnRefreshPS);
            this.tabPageProService.Controls.Add(this.btnUpdatePS);
            this.tabPageProService.Controls.Add(this.dgvProService);
            this.tabPageProService.Location = new System.Drawing.Point(4, 22);
            this.tabPageProService.Name = "tabPageProService";
            this.tabPageProService.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProService.Size = new System.Drawing.Size(828, 315);
            this.tabPageProService.TabIndex = 1;
            this.tabPageProService.Text = "Professional Service";
            this.tabPageProService.UseVisualStyleBackColor = true;
            // 
            // btnClosePS
            // 
            this.btnClosePS.Location = new System.Drawing.Point(721, 272);
            this.btnClosePS.Name = "btnClosePS";
            this.btnClosePS.Size = new System.Drawing.Size(101, 32);
            this.btnClosePS.TabIndex = 5;
            this.btnClosePS.Text = "Close";
            this.btnClosePS.UseVisualStyleBackColor = true;
            this.btnClosePS.Click += new System.EventHandler(this.BtnClosePS_Click);
            // 
            // lblMessageTopPS
            // 
            this.lblMessageTopPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageTopPS.Location = new System.Drawing.Point(6, 11);
            this.lblMessageTopPS.Name = "lblMessageTopPS";
            this.lblMessageTopPS.Size = new System.Drawing.Size(816, 22);
            this.lblMessageTopPS.TabIndex = 8;
            this.lblMessageTopPS.Text = "lblMessageTopPS";
            this.lblMessageTopPS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefreshPS
            // 
            this.btnRefreshPS.Location = new System.Drawing.Point(113, 272);
            this.btnRefreshPS.Name = "btnRefreshPS";
            this.btnRefreshPS.Size = new System.Drawing.Size(101, 32);
            this.btnRefreshPS.TabIndex = 7;
            this.btnRefreshPS.Text = "Refresh";
            this.btnRefreshPS.UseVisualStyleBackColor = true;
            this.btnRefreshPS.Click += new System.EventHandler(this.BtnRefreshPS_Click);
            // 
            // btnUpdatePS
            // 
            this.btnUpdatePS.Location = new System.Drawing.Point(6, 272);
            this.btnUpdatePS.Name = "btnUpdatePS";
            this.btnUpdatePS.Size = new System.Drawing.Size(101, 32);
            this.btnUpdatePS.TabIndex = 6;
            this.btnUpdatePS.Text = "Apply";
            this.btnUpdatePS.UseVisualStyleBackColor = true;
            this.btnUpdatePS.Click += new System.EventHandler(this.BtnUpdatePS_Click);
            // 
            // dgvProService
            // 
            this.dgvProService.Location = new System.Drawing.Point(6, 36);
            this.dgvProService.Name = "dgvProService";
            this.dgvProService.Size = new System.Drawing.Size(816, 230);
            this.dgvProService.TabIndex = 4;
            // 
            // tabPageTask
            // 
            this.tabPageTask.Controls.Add(this.btnDeleteTask);
            this.tabPageTask.Controls.Add(this.lblMessageTopTask);
            this.tabPageTask.Controls.Add(this.btnCloseTask);
            this.tabPageTask.Controls.Add(this.btnRefreshTask);
            this.tabPageTask.Controls.Add(this.btnUpdateTask);
            this.tabPageTask.Controls.Add(this.dgvTask);
            this.tabPageTask.Controls.Add(this.lblProService);
            this.tabPageTask.Controls.Add(this.cbProService);
            this.tabPageTask.Location = new System.Drawing.Point(4, 22);
            this.tabPageTask.Name = "tabPageTask";
            this.tabPageTask.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTask.Size = new System.Drawing.Size(828, 315);
            this.tabPageTask.TabIndex = 2;
            this.tabPageTask.Text = "Task";
            this.tabPageTask.UseVisualStyleBackColor = true;
            // 
            // lblMessageTopTask
            // 
            this.lblMessageTopTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageTopTask.Location = new System.Drawing.Point(6, 71);
            this.lblMessageTopTask.Name = "lblMessageTopTask";
            this.lblMessageTopTask.Size = new System.Drawing.Size(816, 22);
            this.lblMessageTopTask.TabIndex = 22;
            this.lblMessageTopTask.Text = "lblMessageTopTask";
            this.lblMessageTopTask.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCloseTask
            // 
            this.btnCloseTask.Location = new System.Drawing.Point(721, 277);
            this.btnCloseTask.Name = "btnCloseTask";
            this.btnCloseTask.Size = new System.Drawing.Size(101, 32);
            this.btnCloseTask.TabIndex = 19;
            this.btnCloseTask.Text = "Close";
            this.btnCloseTask.UseVisualStyleBackColor = true;
            this.btnCloseTask.Click += new System.EventHandler(this.BtnCloseTask_Click);
            // 
            // btnRefreshTask
            // 
            this.btnRefreshTask.Location = new System.Drawing.Point(113, 277);
            this.btnRefreshTask.Name = "btnRefreshTask";
            this.btnRefreshTask.Size = new System.Drawing.Size(101, 32);
            this.btnRefreshTask.TabIndex = 21;
            this.btnRefreshTask.Text = "Refresh";
            this.btnRefreshTask.UseVisualStyleBackColor = true;
            this.btnRefreshTask.Click += new System.EventHandler(this.BtnRefreshTask_Click);
            // 
            // btnUpdateTask
            // 
            this.btnUpdateTask.Location = new System.Drawing.Point(6, 277);
            this.btnUpdateTask.Name = "btnUpdateTask";
            this.btnUpdateTask.Size = new System.Drawing.Size(101, 32);
            this.btnUpdateTask.TabIndex = 20;
            this.btnUpdateTask.Text = "Apply";
            this.btnUpdateTask.UseVisualStyleBackColor = true;
            this.btnUpdateTask.Click += new System.EventHandler(this.BtnUpdateTask_Click);
            // 
            // dgvTask
            // 
            this.dgvTask.Location = new System.Drawing.Point(9, 100);
            this.dgvTask.Name = "dgvTask";
            this.dgvTask.Size = new System.Drawing.Size(813, 171);
            this.dgvTask.TabIndex = 18;
            // 
            // lblProService
            // 
            this.lblProService.AutoSize = true;
            this.lblProService.Location = new System.Drawing.Point(6, 25);
            this.lblProService.Name = "lblProService";
            this.lblProService.Size = new System.Drawing.Size(103, 13);
            this.lblProService.TabIndex = 17;
            this.lblProService.Text = "Professional Service";
            // 
            // cbProService
            // 
            this.cbProService.CausesValidation = false;
            this.cbProService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProService.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProService.FormattingEnabled = true;
            this.cbProService.Location = new System.Drawing.Point(9, 41);
            this.cbProService.Name = "cbProService";
            this.cbProService.Size = new System.Drawing.Size(215, 24);
            this.cbProService.TabIndex = 16;
            this.cbProService.SelectedIndexChanged += new System.EventHandler(this.CbProService_SelectedIndexChanged);
            // 
            // tabPageItem
            // 
            this.tabPageItem.Controls.Add(this.btnDeleteItem);
            this.tabPageItem.Controls.Add(this.lblMessageTopItem);
            this.tabPageItem.Controls.Add(this.btnCloseItem);
            this.tabPageItem.Controls.Add(this.btnRefreshItem);
            this.tabPageItem.Controls.Add(this.btnUpdateItem);
            this.tabPageItem.Controls.Add(this.dgvItem);
            this.tabPageItem.Controls.Add(this.lblProServiceItem);
            this.tabPageItem.Controls.Add(this.cbProServiceItem);
            this.tabPageItem.Location = new System.Drawing.Point(4, 22);
            this.tabPageItem.Name = "tabPageItem";
            this.tabPageItem.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItem.Size = new System.Drawing.Size(828, 315);
            this.tabPageItem.TabIndex = 3;
            this.tabPageItem.Text = "Item";
            this.tabPageItem.UseVisualStyleBackColor = true;
            // 
            // lblMessageTopItem
            // 
            this.lblMessageTopItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageTopItem.Location = new System.Drawing.Point(9, 70);
            this.lblMessageTopItem.Name = "lblMessageTopItem";
            this.lblMessageTopItem.Size = new System.Drawing.Size(813, 22);
            this.lblMessageTopItem.TabIndex = 25;
            this.lblMessageTopItem.Text = "lblMessageTopItem";
            this.lblMessageTopItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCloseItem
            // 
            this.btnCloseItem.Location = new System.Drawing.Point(721, 277);
            this.btnCloseItem.Name = "btnCloseItem";
            this.btnCloseItem.Size = new System.Drawing.Size(101, 32);
            this.btnCloseItem.TabIndex = 22;
            this.btnCloseItem.Text = "Close";
            this.btnCloseItem.UseVisualStyleBackColor = true;
            this.btnCloseItem.Click += new System.EventHandler(this.BtnCloseItem_Click);
            // 
            // btnRefreshItem
            // 
            this.btnRefreshItem.Location = new System.Drawing.Point(113, 277);
            this.btnRefreshItem.Name = "btnRefreshItem";
            this.btnRefreshItem.Size = new System.Drawing.Size(101, 32);
            this.btnRefreshItem.TabIndex = 24;
            this.btnRefreshItem.Text = "Refresh";
            this.btnRefreshItem.UseVisualStyleBackColor = true;
            this.btnRefreshItem.Click += new System.EventHandler(this.BtnRefreshItem_Click);
            // 
            // btnUpdateItem
            // 
            this.btnUpdateItem.Location = new System.Drawing.Point(6, 277);
            this.btnUpdateItem.Name = "btnUpdateItem";
            this.btnUpdateItem.Size = new System.Drawing.Size(101, 32);
            this.btnUpdateItem.TabIndex = 23;
            this.btnUpdateItem.Text = "Apply";
            this.btnUpdateItem.UseVisualStyleBackColor = true;
            this.btnUpdateItem.Click += new System.EventHandler(this.BtnUpdateItem_Click);
            // 
            // dgvItem
            // 
            this.dgvItem.Location = new System.Drawing.Point(9, 101);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.Size = new System.Drawing.Size(813, 170);
            this.dgvItem.TabIndex = 21;
            // 
            // lblProServiceItem
            // 
            this.lblProServiceItem.AutoSize = true;
            this.lblProServiceItem.Location = new System.Drawing.Point(6, 23);
            this.lblProServiceItem.Name = "lblProServiceItem";
            this.lblProServiceItem.Size = new System.Drawing.Size(103, 13);
            this.lblProServiceItem.TabIndex = 20;
            this.lblProServiceItem.Text = "Professional Service";
            // 
            // cbProServiceItem
            // 
            this.cbProServiceItem.CausesValidation = false;
            this.cbProServiceItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProServiceItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProServiceItem.FormattingEnabled = true;
            this.cbProServiceItem.Location = new System.Drawing.Point(9, 39);
            this.cbProServiceItem.Name = "cbProServiceItem";
            this.cbProServiceItem.Size = new System.Drawing.Size(215, 24);
            this.cbProServiceItem.TabIndex = 19;
            this.cbProServiceItem.SelectedIndexChanged += new System.EventHandler(this.CbProServiceItem_SelectedIndexChanged);
            // 
            // btnDeleteClient
            // 
            this.btnDeleteClient.Location = new System.Drawing.Point(220, 275);
            this.btnDeleteClient.Name = "btnDeleteClient";
            this.btnDeleteClient.Size = new System.Drawing.Size(101, 32);
            this.btnDeleteClient.TabIndex = 4;
            this.btnDeleteClient.Text = "Delete";
            this.btnDeleteClient.UseVisualStyleBackColor = true;
            this.btnDeleteClient.Click += new System.EventHandler(this.BtnDeleteClient_Click);
            // 
            // btnDeletePS
            // 
            this.btnDeletePS.Location = new System.Drawing.Point(220, 272);
            this.btnDeletePS.Name = "btnDeletePS";
            this.btnDeletePS.Size = new System.Drawing.Size(101, 32);
            this.btnDeletePS.TabIndex = 9;
            this.btnDeletePS.Text = "Delete";
            this.btnDeletePS.UseVisualStyleBackColor = true;
            this.btnDeletePS.Click += new System.EventHandler(this.BtnDeletePS_Click);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.Location = new System.Drawing.Point(220, 277);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(101, 32);
            this.btnDeleteTask.TabIndex = 23;
            this.btnDeleteTask.Text = "Delete";
            this.btnDeleteTask.UseVisualStyleBackColor = true;
            this.btnDeleteTask.Click += new System.EventHandler(this.BtnDeleteTask_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Location = new System.Drawing.Point(220, 277);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(101, 32);
            this.btnDeleteItem.TabIndex = 26;
            this.btnDeleteItem.Text = "Delete";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.BtnDeleteItem_Click);
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(860, 361);
            this.Controls.Add(this.tabCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CategoryForm";
            this.Text = "Manage Categories";
            this.tabCategories.ResumeLayout(false);
            this.tabPageClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).EndInit();
            this.tabPageProService.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProService)).EndInit();
            this.tabPageTask.ResumeLayout(false);
            this.tabPageTask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).EndInit();
            this.tabPageItem.ResumeLayout(false);
            this.tabPageItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCategories;
        private System.Windows.Forms.TabPage tabPageClient;
        private System.Windows.Forms.TabPage tabPageProService;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvClient;
        private System.Windows.Forms.Button btnUpdateClient;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblMessageTop;
        private System.Windows.Forms.Button btnClosePS;
        private System.Windows.Forms.Label lblMessageTopPS;
        private System.Windows.Forms.Button btnRefreshPS;
        private System.Windows.Forms.Button btnUpdatePS;
        private System.Windows.Forms.DataGridView dgvProService;
        private System.Windows.Forms.TabPage tabPageTask;
        private System.Windows.Forms.TabPage tabPageItem;
        private System.Windows.Forms.DataGridView dgvTask;
        private System.Windows.Forms.Label lblProService;
        private System.Windows.Forms.ComboBox cbProService;
        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.Label lblProServiceItem;
        private System.Windows.Forms.ComboBox cbProServiceItem;
        private System.Windows.Forms.Button btnCloseTask;
        private System.Windows.Forms.Button btnRefreshTask;
        private System.Windows.Forms.Button btnUpdateTask;
        private System.Windows.Forms.Button btnCloseItem;
        private System.Windows.Forms.Button btnRefreshItem;
        private System.Windows.Forms.Button btnUpdateItem;
        private System.Windows.Forms.Label lblMessageTopTask;
        private System.Windows.Forms.Label lblMessageTopItem;
        private System.Windows.Forms.Button btnDeleteClient;
        private System.Windows.Forms.Button btnDeletePS;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.Button btnDeleteItem;
    }
}