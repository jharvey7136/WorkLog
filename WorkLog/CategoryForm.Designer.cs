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
            this.dgvClient = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAddClient = new System.Windows.Forms.Label();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.lblZip = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lblAddressTwo = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lblAddressOne = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdateClient = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblMessageTop = new System.Windows.Forms.Label();
            this.tabCategories.SuspendLayout();
            this.tabPageClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCategories
            // 
            this.tabCategories.Controls.Add(this.tabPageClient);
            this.tabCategories.Controls.Add(this.tabPage2);
            this.tabCategories.Location = new System.Drawing.Point(12, 12);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.SelectedIndex = 0;
            this.tabCategories.Size = new System.Drawing.Size(740, 361);
            this.tabCategories.TabIndex = 0;
            // 
            // tabPageClient
            // 
            this.tabPageClient.Controls.Add(this.lblMessageTop);
            this.tabPageClient.Controls.Add(this.btnRefresh);
            this.tabPageClient.Controls.Add(this.btnUpdateClient);
            this.tabPageClient.Controls.Add(this.dgvClient);
            this.tabPageClient.Location = new System.Drawing.Point(4, 22);
            this.tabPageClient.Name = "tabPageClient";
            this.tabPageClient.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClient.Size = new System.Drawing.Size(732, 335);
            this.tabPageClient.TabIndex = 0;
            this.tabPageClient.Text = "Client";
            this.tabPageClient.UseVisualStyleBackColor = true;
            // 
            // dgvClient
            // 
            this.dgvClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClient.Location = new System.Drawing.Point(6, 39);
            this.dgvClient.Name = "dgvClient";
            this.dgvClient.Size = new System.Drawing.Size(720, 230);
            this.dgvClient.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(732, 335);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(218, 20);
            this.textBox1.TabIndex = 0;
            // 
            // lblClient
            // 
            this.lblClient.Location = new System.Drawing.Point(4, 31);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(83, 20);
            this.lblClient.TabIndex = 1;
            this.lblClient.Text = "Client";
            this.lblClient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(93, 58);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(218, 20);
            this.textBox2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblAddClient);
            this.panel1.Controls.Add(this.btnAddClient);
            this.panel1.Controls.Add(this.lblZip);
            this.panel1.Controls.Add(this.textBox6);
            this.panel1.Controls.Add(this.lblState);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.lblCity);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.lblAddressTwo);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.lblAddressOne);
            this.panel1.Controls.Add(this.lblClient);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Location = new System.Drawing.Point(116, 396);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 232);
            this.panel1.TabIndex = 4;
            // 
            // lblAddClient
            // 
            this.lblAddClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddClient.Location = new System.Drawing.Point(3, 9);
            this.lblAddClient.Name = "lblAddClient";
            this.lblAddClient.Size = new System.Drawing.Size(320, 16);
            this.lblAddClient.TabIndex = 5;
            this.lblAddClient.Text = "Add Client";
            this.lblAddClient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddClient
            // 
            this.btnAddClient.Location = new System.Drawing.Point(236, 198);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(75, 23);
            this.btnAddClient.TabIndex = 6;
            this.btnAddClient.Text = "Add";
            this.btnAddClient.UseVisualStyleBackColor = true;
            // 
            // lblZip
            // 
            this.lblZip.Location = new System.Drawing.Point(4, 171);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(83, 20);
            this.lblZip.TabIndex = 11;
            this.lblZip.Text = "Zip";
            this.lblZip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(93, 172);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(218, 20);
            this.textBox6.TabIndex = 10;
            // 
            // lblState
            // 
            this.lblState.Location = new System.Drawing.Point(4, 143);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(83, 20);
            this.lblState.TabIndex = 9;
            this.lblState.Text = "State";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(93, 144);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(218, 20);
            this.textBox5.TabIndex = 8;
            // 
            // lblCity
            // 
            this.lblCity.Location = new System.Drawing.Point(4, 113);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(83, 20);
            this.lblCity.TabIndex = 7;
            this.lblCity.Text = "City";
            this.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(93, 114);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(218, 20);
            this.textBox4.TabIndex = 6;
            // 
            // lblAddressTwo
            // 
            this.lblAddressTwo.Location = new System.Drawing.Point(4, 85);
            this.lblAddressTwo.Name = "lblAddressTwo";
            this.lblAddressTwo.Size = new System.Drawing.Size(83, 20);
            this.lblAddressTwo.TabIndex = 5;
            this.lblAddressTwo.Text = "Address Line 2";
            this.lblAddressTwo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(93, 86);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(218, 20);
            this.textBox3.TabIndex = 4;
            // 
            // lblAddressOne
            // 
            this.lblAddressOne.Location = new System.Drawing.Point(4, 57);
            this.lblAddressOne.Name = "lblAddressOne";
            this.lblAddressOne.Size = new System.Drawing.Size(83, 20);
            this.lblAddressOne.TabIndex = 3;
            this.lblAddressOne.Text = "Address Line 1";
            this.lblAddressOne.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(673, 380);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
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
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 688);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabCategories);
            this.Name = "CategoryForm";
            this.Text = "CategoryForm";
            this.tabCategories.ResumeLayout(false);
            this.tabPageClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCategories;
        private System.Windows.Forms.TabPage tabPageClient;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAddressTwo;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblAddressOne;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblZip;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblAddClient;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.DataGridView dgvClient;
        private System.Windows.Forms.Button btnUpdateClient;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblMessageTop;
    }
}