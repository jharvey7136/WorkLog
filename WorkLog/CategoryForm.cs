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
            dgvClient.RowsAdded += (s, a) => OnRowNumberChanged(dgvClient);
            dgvProService.RowsAdded += (s, a) => OnRowNumberChanged(dgvProService);
            dgvTask.RowsAdded += (s, a) => OnRowNumberChanged(dgvTask);
            dgvItem.RowsAdded += (s, a) => OnRowNumberChanged(dgvItem);
        }

        private void InitializeDefaults()
        {
            ResetMessageTop();
            GetDataClient();
            GetDataProService();

            oDAL.FillComboBox("SELECT ProServiceID, ProServiceName FROM ProfessionalService", cbProService, "ProServiceName", "ProServiceID");
            oDAL.FillComboBox("SELECT ProServiceID, ProServiceName FROM ProfessionalService", cbProServiceItem, "ProServiceName", "ProServiceID");
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

        /************************************** Task *************************************/
        private void BtnUpdateTask_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Data will be updated. Continue?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    oDAL.UpdateTask(dgvTask, cbProService);
                    lblMessageTopTask.ForeColor = Color.Green;
                    lblMessageTopTask.Text = "Update Successful!";
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnRefreshTask_Click(object sender, EventArgs e)
        {
            GetDataTask();
            ResetMessageTop();            
        }

        private void GetDataTask()
        {
            string cmd = "SELECT DISTINCT TaskID, TaskName FROM Task WHERE ProServiceID = " + cbProService.SelectedValue;
            oDAL.FillDataGrid(cmd, dgvTask);
            dgvTask.Columns[0].ReadOnly = true;
        }

        private void BtnCloseTask_Click(object sender, EventArgs e)
        {
            Dispose();
        }


        /************************************** Item *************************************/
        private void BtnUpdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Data will be updated. Continue?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    oDAL.UpdateItem(dgvItem, cbProServiceItem);
                    lblMessageTopItem.ForeColor = Color.Green;
                    lblMessageTopItem.Text = "Update Successful!";
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnRefreshItem_Click(object sender, EventArgs e)
        {
            GetDataItem();
            ResetMessageTop();
        }

        private void BtnCloseItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void GetDataItem()
        {
            string cmd = "SELECT DISTINCT ItemID, ItemName FROM Item WHERE ProServiceID = " + cbProServiceItem.SelectedValue;
            oDAL.FillDataGrid(cmd, dgvItem);
            dgvItem.Columns[0].ReadOnly = true;
        }

        /************************************** Helpers *************************************/
        private void ResetMessageTop()
        {
            lblMessageTop.Text = "";
            lblMessageTop.ForeColor = SystemColors.ControlText;
            lblMessageTopPS.Text = "";
            lblMessageTopPS.ForeColor = SystemColors.ControlText;
            lblMessageTopTask.Text = "";
            lblMessageTopTask.ForeColor = SystemColors.ControlText;
            lblMessageTopItem.Text = "";
            lblMessageTopItem.ForeColor = SystemColors.ControlText;
        }

        private void CbProService_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cmd = "";
            if (cbProService.SelectedValue.ToString() != "System.Data.DataRowView" && cbProService.SelectedValue != null)
                cmd = "SELECT TaskID, TaskName FROM Task WHERE ProServiceID = " + cbProService.SelectedValue;
            else
                cmd = "SELECT TaskID, TaskName FROM Task WHERE ProServiceID = 1";

            oDAL.FillDataGrid(cmd, dgvTask);
            dgvTask.Columns[0].ReadOnly = true;
        }

        private void CbProServiceItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cmd = "";
            if (cbProServiceItem.SelectedValue.ToString() != "System.Data.DataRowView" && cbProServiceItem.SelectedValue != null)
                cmd = "SELECT ItemID, ItemName FROM Item WHERE ProServiceID = " + cbProServiceItem.SelectedValue;
            else
                cmd = "SELECT ItemID, ItemName FROM Item WHERE ProServiceID = 1";

            oDAL.FillDataGrid(cmd, dgvItem);
            dgvItem.Columns[0].ReadOnly = true;
        }

        private void OnRowNumberChanged(DataGridView dgv)
        {
            //lblRecordCount.Text = dgvRecords.Rows.Count.ToString();
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        
    }
}
