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



        private void InitializeDefaults()
        {
            ResetMessageTop();
            GetDataClient();
            GetDataProService();
        }

        /************************************** Client *************************************/
        private void BtnUpdateClient_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Data will be updated. Continue?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    oDAL.UpdateClient(dgvClient);
                    lblMessageTop.ForeColor = Color.Green;
                    lblMessageTop.Text = "Update Successful!";
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetDataClient();
            ResetMessageTop();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void GetDataClient()
        {
            string cmd = "SELECT DISTINCT ClientID, ClientName, AddressLine1, AddressLine2, City, State, Zip FROM Client ORDER BY ClientID";
            oDAL.FillDataGrid(cmd, dgvClient);
            dgvClient.Columns[0].ReadOnly = true;
        }

        /************************************** Pro Service *************************************/
        private void BtnUpdatePS_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Data will be updated. Continue?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    oDAL.UpdateProService(dgvProService);
                    lblMessageTopPS.ForeColor = Color.Green;
                    lblMessageTopPS.Text = "Update Successful!";
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnRefreshPS_Click(object sender, EventArgs e)
        {
            GetDataProService();
            ResetMessageTop();
        }

        private void BtnClosePS_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void GetDataProService()
        {
            string cmd = "SELECT DISTINCT ProServiceID, ProServiceName FROM ProfessionalService ORDER BY ProServiceID";
            oDAL.FillDataGrid(cmd, dgvProService);
            dgvProService.Columns[0].ReadOnly = true;
        }

        /************************************** Helpers *************************************/
        private void ResetMessageTop()
        {
            lblMessageTop.Text = "";
            lblMessageTop.ForeColor = SystemColors.ControlText;
            lblMessageTopPS.Text = "";
            lblMessageTopPS.ForeColor = SystemColors.ControlText;
        }

        
    }
}
