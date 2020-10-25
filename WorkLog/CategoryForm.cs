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

namespace WorkLog
{
    public partial class CategoryForm : Form
    {
        DAL oDAL = new DAL();

        public CategoryForm()
        {
            InitializeComponent();
            InitializeDefaults();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {            
            this.Dispose();
        }

        private void InitializeDefaults()
        {
            ResetMessageTop();
            GetDataClient();
        }

        private void BtnUpdateClient_Click(object sender, EventArgs e)
        {
            try
            {   
                oDAL.UpdateClient(dgvClient);
                lblMessageTop.ForeColor = Color.Green;
                lblMessageTop.Text = "Update Successful!";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            oDAL.BackupDB();
            GetDataClient();
            ResetMessageTop();
        }

        private void GetDataClient()
        {
            string cmd = "SELECT DISTINCT ClientID, ClientName, AddressLine1, AddressLine2, City, State, Zip FROM Client ORDER BY ClientID";
            oDAL.FillDataGrid(cmd, dgvClient);
        }

        private void ResetMessageTop()
        {
            lblMessageTop.Text = "";
            lblMessageTop.ForeColor = SystemColors.ControlText;
        }
    }
}
