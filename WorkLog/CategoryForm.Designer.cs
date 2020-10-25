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
            this.tabCategories = new System.Windows.Forms.TabControl();
            this.tabPageClient = new System.Windows.Forms.TabPage();
            this.lblMessageTop = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnUpdateClient = new System.Windows.Forms.Button();
            this.dgvClient = new System.Windows.Forms.DataGridView();
            this.tabPageProService = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClosePS = new System.Windows.Forms.Button();
            this.lblMessageTopPS = new System.Windows.Forms.Label();
            this.btnRefreshPS = new System.Windows.Forms.Button();
            this.btnUpdatePS = new System.Windows.Forms.Button();
            this.dgvProService = new System.Windows.Forms.DataGridView();
            this.tabCategories.SuspendLayout();
            this.tabPageClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).BeginInit();
            this.tabPageProService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProService)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCategories
            // 
            this.tabCategories.Controls.Add(this.tabPageClient);
            this.tabCategories.Controls.Add(this.tabPageProService);
            this.tabCategories.Location = new System.Drawing.Point(12, 12);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.SelectedIndex = 0;
            this.tabCategories.Size = new System.Drawing.Size(740, 341);
            this.tabCategories.TabIndex = 0;
            // 
            // tabPageClient
            // 
            this.tabPageClient.Controls.Add(this.btnClose);
            this.tabPageClient.Controls.Add(this.lblMessageTop);
            this.tabPageClient.Controls.Add(this.btnRefresh);
            this.tabPageClient.Controls.Add(this.btnUpdateClient);
            this.tabPageClient.Controls.Add(this.dgvClient);
            this.tabPageClient.Location = new System.Drawing.Point(4, 22);
            this.tabPageClient.Name = "tabPageClient";
            this.tabPageClient.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClient.Size = new System.Drawing.Size(732, 315);
            this.tabPageClient.TabIndex = 0;
            this.tabPageClient.Text = "Client";
            this.tabPageClient.UseVisualStyleBackColor = true;
            // 
            // lblMessageTop
            // 
            this.lblMessageTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageTop.Location = new System.Drawing.Point(6, 14);
            this.lblMessageTop.Name = "lblMessageTop";
            this.lblMessageTop.Size = new System.Drawing.Size(720, 22);
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
            this.btnUpdateClient.Text = "Update";
            this.btnUpdateClient.UseVisualStyleBackColor = true;
            this.btnUpdateClient.Click += new System.EventHandler(this.BtnUpdateClient_Click);
            // 
            // dgvClient
            // 
            this.dgvClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClient.Location = new System.Drawing.Point(6, 39);
            this.dgvClient.Name = "dgvClient";
            this.dgvClient.Size = new System.Drawing.Size(720, 230);
            this.dgvClient.TabIndex = 0;
            // 
            // tabPageProService
            // 
            this.tabPageProService.Controls.Add(this.btnClosePS);
            this.tabPageProService.Controls.Add(this.lblMessageTopPS);
            this.tabPageProService.Controls.Add(this.btnRefreshPS);
            this.tabPageProService.Controls.Add(this.btnUpdatePS);
            this.tabPageProService.Controls.Add(this.dgvProService);
            this.tabPageProService.Location = new System.Drawing.Point(4, 22);
            this.tabPageProService.Name = "tabPageProService";
            this.tabPageProService.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProService.Size = new System.Drawing.Size(732, 315);
            this.tabPageProService.TabIndex = 1;
            this.tabPageProService.Text = "Professional Service";
            this.tabPageProService.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(625, 275);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnClosePS
            // 
            this.btnClosePS.Location = new System.Drawing.Point(625, 272);
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
            this.lblMessageTopPS.Size = new System.Drawing.Size(720, 22);
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
            this.btnUpdatePS.Text = "Update";
            this.btnUpdatePS.UseVisualStyleBackColor = true;
            this.btnUpdatePS.Click += new System.EventHandler(this.BtnUpdatePS_Click);
            // 
            // dgvProService
            // 
            this.dgvProService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProService.Location = new System.Drawing.Point(6, 36);
            this.dgvProService.Name = "dgvProService";
            this.dgvProService.Size = new System.Drawing.Size(720, 230);
            this.dgvProService.TabIndex = 4;
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(760, 361);
            this.Controls.Add(this.tabCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CategoryForm";
            this.Text = "Manage Categories";
            this.tabCategories.ResumeLayout(false);
            this.tabPageClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).EndInit();
            this.tabPageProService.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProService)).EndInit();
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
    }
}