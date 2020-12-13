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
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        DAL oDAL = new DAL();

        public CategoryForm()
        {
            InitializeComponent();
            InitializeDefaults();

            dgvClient.RowsAdded += (s, a) => OnRowNumberChanged(dgvClient);
            dgvProService.RowsAdded += (s, a) => OnRowNumberChanged(dgvProService);
            dgvTask.RowsAdded += (s, a) => OnRowNumberChanged(dgvTask);
            dgvItem.RowsAdded += (s, a) => OnRowNumberChanged(dgvItem);

            // Attach DataGridView events to the corresponding event handlers.
            dgvClient.CellValidating += new DataGridViewCellValidatingEventHandler(dgvClient_CellValidating);
            dgvClient.CellEndEdit += new DataGridViewCellEventHandler(dgvClient_CellEndEdit);

            dgvProService.CellValidating += new DataGridViewCellValidatingEventHandler(dgvProService_CellValidating);
            dgvProService.CellEndEdit += new DataGridViewCellEventHandler(dgvProService_CellEndEdit);

            dgvTask.CellValidating += new DataGridViewCellValidatingEventHandler(dgvTask_CellValidating);
            dgvTask.CellEndEdit += new DataGridViewCellEventHandler(dgvTask_CellEndEdit);

            dgvItem.CellValidating += new DataGridViewCellValidatingEventHandler(dgvItem_CellValidating);
            dgvItem.CellEndEdit += new DataGridViewCellEventHandler(dgvItem_CellEndEdit);

            dgvTask.DataSource = null;
            dgvItem.DataSource = null;
        }

        private void InitializeDefaults()
        {
            try
            {
                ResetMessageTop();
                GetDataClient();
                GetDataProService();

                oDAL.FillComboBox("SELECT ProServiceID, ProServiceName FROM ProfessionalService", cbProService, "ProServiceName", "ProServiceID");
                oDAL.FillComboBox("SELECT ProServiceID, ProServiceName FROM ProfessionalService", cbProServiceItem, "ProServiceName", "ProServiceID");
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
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
                logger.Error(ex, ex.Source);
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
            try
            {
                string cmd = "SELECT DISTINCT ClientID, ClientName, AddressLine1, AddressLine2, City, State, Zip, Enabled FROM Client ORDER BY ClientID";
                oDAL.FillDataGrid(cmd, dgvClient);
                dgvClient.Columns["ClientID"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
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
                logger.Error(ex, ex.Source);
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
            try
            {
                string cmd = "SELECT DISTINCT ProServiceID, ProServiceName, Enabled FROM ProfessionalService ORDER BY ProServiceID";
                oDAL.FillDataGrid(cmd, dgvProService);
                dgvProService.Columns["ProServiceID"].ReadOnly = true;                
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
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
            try
            {
                string cmd = "SELECT DISTINCT TaskID, TaskName, Enabled FROM Task WHERE ProServiceID = " + cbProService.SelectedValue;
                oDAL.FillDataGrid(cmd, dgvTask);
                dgvTask.Columns["TaskID"].ReadOnly = true;                
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }

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
                logger.Error(ex, ex.Source);
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
            try
            {
                string cmd = "SELECT DISTINCT ItemID, ItemName, Enabled FROM Item WHERE ProServiceID = " + cbProServiceItem.SelectedValue;
                oDAL.FillDataGrid(cmd, dgvItem);
                dgvItem.Columns["ItemID"].ReadOnly = true;                
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }

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
            try
            {
                string cmd = "";
                if (cbProService.SelectedValue.ToString() != "System.Data.DataRowView" && cbProService.SelectedValue != null)
                    cmd = "SELECT TaskID, TaskName, Enabled FROM Task WHERE ProServiceID = " + cbProService.SelectedValue;
                else
                    cmd = "SELECT TaskID, TaskName, Enabled FROM Task WHERE ProServiceID = 1";

                oDAL.FillDataGrid(cmd, dgvTask);
                dgvTask.Columns[0].ReadOnly = true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
        }

        private void CbProServiceItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string cmd = "";
                if (cbProServiceItem.SelectedValue.ToString() != "System.Data.DataRowView" && cbProServiceItem.SelectedValue != null)
                    cmd = "SELECT ItemID, ItemName, Enabled FROM Item WHERE ProServiceID = " + cbProServiceItem.SelectedValue;
                else
                    cmd = "SELECT ItemID, ItemName, Enabled FROM Item WHERE ProServiceID = 1";

                oDAL.FillDataGrid(cmd, dgvItem);
                dgvItem.Columns[0].ReadOnly = true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
        }

        private void OnRowNumberChanged(DataGridView dgv)
        {
            //lblRecordCount.Text = dgvRecords.Rows.Count.ToString();
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        /************************************** Cell Validation *************************************/
        /* Client */
        private void dgvClient_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = dgvClient.Columns[e.ColumnIndex].HeaderText;

            if (!headerText.Equals("Enabled")) return;

            if (e.FormattedValue.ToString() == "0" || e.FormattedValue.ToString() == "1")
                return;
            else
            {
                dgvClient.Rows[e.RowIndex].ErrorText = "Enabled must be 0 or 1 (0 = disabled, 1 = enabled)";
                e.Cancel = true;
            }
        }

        void dgvClient_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvClient.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        /* ProService */
        private void dgvProService_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = dgvProService.Columns[e.ColumnIndex].HeaderText;

            if (!headerText.Equals("Enabled")) return;

            if (e.FormattedValue.ToString() == "0" || e.FormattedValue.ToString() == "1")
                return;
            else
            {
                dgvProService.Rows[e.RowIndex].ErrorText = "Enabled must be 0 or 1 (0 = disabled, 1 = enabled)";
                e.Cancel = true;
            }
        }

        void dgvProService_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvProService.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        /* Task */
        private void dgvTask_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = dgvTask.Columns[e.ColumnIndex].HeaderText;

            if (!headerText.Equals("Enabled")) return;
            if (dgvTask.Rows[e.RowIndex].IsNewRow) return; 

            if (e.FormattedValue.ToString() == "0" || e.FormattedValue.ToString() == "1")
                return;
            else
            {
                dgvTask.Rows[e.RowIndex].ErrorText = "Enabled must be 0 or 1 (0 = disabled, 1 = enabled)";
                e.Cancel = true;
            }
        }

        void dgvTask_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvTask.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        /* Item */
        private void dgvItem_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = dgvItem.Columns[e.ColumnIndex].HeaderText;

            if (!headerText.Equals("Enabled")) return;

            if (e.FormattedValue.ToString() == "0" || e.FormattedValue.ToString() == "1")
                return;
            else
            {
                dgvItem.Rows[e.RowIndex].ErrorText = "Enabled must be 0 or 1 (0 = disabled, 1 = enabled)";
                e.Cancel = true;
            }
        }

        void dgvItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvItem.Rows[e.RowIndex].ErrorText = String.Empty;
        }

    }
}
