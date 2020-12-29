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

            dgvClient.RowsAdded += (s, a) => OnRowNumberChanged(dgvClient, lblMessageTop);
            dgvProService.RowsAdded += (s, a) => OnRowNumberChanged(dgvProService, lblMessageTopPS);
            dgvTask.RowsAdded += (s, a) => OnRowNumberChanged(dgvTask, lblMessageTopTask);
            dgvItem.RowsAdded += (s, a) => OnRowNumberChanged(dgvItem, lblMessageTopItem);

            // Attach DataGridView events to the corresponding event handlers.
            dgvClient.CellValidating += new DataGridViewCellValidatingEventHandler(dgvClient_CellValidating);
            dgvClient.CellEndEdit += new DataGridViewCellEventHandler(dgvClient_CellEndEdit);

            dgvProService.CellValidating += new DataGridViewCellValidatingEventHandler(dgvProService_CellValidating);
            dgvProService.CellEndEdit += new DataGridViewCellEventHandler(dgvProService_CellEndEdit);

            dgvTask.CellValidating += new DataGridViewCellValidatingEventHandler(dgvTask_CellValidating);
            dgvTask.CellEndEdit += new DataGridViewCellEventHandler(dgvTask_CellEndEdit);

            dgvItem.CellValidating += new DataGridViewCellValidatingEventHandler(dgvItem_CellValidating);
            dgvItem.CellEndEdit += new DataGridViewCellEventHandler(dgvItem_CellEndEdit);

            tabCategories.SelectedIndexChanged += new EventHandler(tabCategories_SelectedIndexChanged);

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
                RefreshComboBoxes();

                //dgvClient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvClient.AutoResizeColumns();
                dgvProService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTask.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
        }  
        
        private void RefreshComboBoxes()
        {
            oDAL.FillComboBox("SELECT ProServiceID, ProServiceName FROM ProfessionalService", cbProService, "ProServiceName", "ProServiceID");
            oDAL.FillComboBox("SELECT ProServiceID, ProServiceName FROM ProfessionalService", cbProServiceItem, "ProServiceName", "ProServiceID");
        }

        /* ------------------------------------------------------------------------------------------------ */
        private void BtnUpdateClient_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Database will be updated. Continue?", "Apply Changes Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (oDAL.UpdateClient(dgvClient))                    
                        DisplayMessage(lblMessageTop, "Update Successful", Color.Green);
                    else
                        DisplayMessage(lblMessageTop, "An unexpected error has occured", Color.Red);
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
        }

        private void BtnUpdatePS_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Database will be updated. Continue?", "Apply Changes Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (oDAL.UpdateProService(dgvProService))
                        DisplayMessage(lblMessageTopPS, "Update Successful", Color.Green);
                    else
                        DisplayMessage(lblMessageTopPS, "An unexpected error has occured", Color.Red);                    
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
        }

        private void BtnUpdateTask_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Database will be updated. Continue?", "Apply Changes Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (oDAL.UpdateTask(dgvTask, cbProService))
                        DisplayMessage(lblMessageTopTask, "Update Successful", Color.Green);
                    else
                        DisplayMessage(lblMessageTopTask, "An unexpected error has occured", Color.Red);                    
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnUpdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Database will be updated. Continue?", "Apply Changes Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (oDAL.UpdateItem(dgvItem, cbProServiceItem))
                        DisplayMessage(lblMessageTopItem, "Update Successful", Color.Green);
                    else
                        DisplayMessage(lblMessageTopItem, "An unexpected error has occured", Color.Red);                    
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
        }

        /* ------------------------------------------------------------------------------------------------ */

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetDataClient();
            ResetMessageTop();
        }

        private void BtnRefreshPS_Click(object sender, EventArgs e)
        {
            GetDataProService();
            ResetMessageTop();
        }

        private void BtnRefreshTask_Click(object sender, EventArgs e)
        {
            GetDataTask();
            ResetMessageTop();
        }

        private void BtnRefreshItem_Click(object sender, EventArgs e)
        {
            GetDataItem();
            ResetMessageTop();
        }

        /* ------------------------------------------------------------------------------------------------ */

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnClosePS_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnCloseTask_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnCloseItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        /* ------------------------------------------------------------------------------------------------ */

        private void GetDataClient()
        {
            try
            {
                string cmd = "SELECT DISTINCT ClientID, ClientName, Rate, AddressLine1, AddressLine2, City, State, Zip, Enabled FROM Client ORDER BY ClientID";
                oDAL.FillDataGrid(cmd, dgvClient);
                dgvClient.Columns["ClientID"].Visible = false;
                dgvClient.Columns["ClientID"].ReadOnly = true;
                dgvClient.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
        }

        private void GetDataProService()
        {
            try
            {
                string cmd = "SELECT DISTINCT ProServiceID, ProServiceName, Enabled FROM ProfessionalService ORDER BY ProServiceID";
                oDAL.FillDataGrid(cmd, dgvProService);
                dgvProService.Columns["ProServiceID"].Visible = false;
                dgvProService.Columns["ProServiceID"].ReadOnly = true;
                //dgvProService.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
        }

        private void GetDataTask()
        {
            try
            {
                string cmd = "SELECT DISTINCT TaskID, TaskName, Enabled FROM Task WHERE ProServiceID = " + cbProService.SelectedValue;
                oDAL.FillDataGrid(cmd, dgvTask);
                dgvTask.Columns["TaskID"].Visible = false;
                dgvTask.Columns["TaskID"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
        }

        private void GetDataItem()
        {
            try
            {
                string cmd = "SELECT DISTINCT ItemID, ItemName, Enabled FROM Item WHERE ProServiceID = " + cbProServiceItem.SelectedValue;
                oDAL.FillDataGrid(cmd, dgvItem);
                dgvItem.Columns["ItemID"].Visible = false;
                dgvItem.Columns["ItemID"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
        }

        /* ------------------------------------------------------------------------------------------------ */

        private void CbProService_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbProService.SelectedIndex < 1)
                {
                    dgvTask.DataSource = null;
                    return;
                }

                string cmd = "";

                if (cbProService.SelectedIndex > 0)
                    cmd = "SELECT TaskID, TaskName, Enabled FROM Task WHERE ProServiceID = " + cbProService.SelectedValue;

                oDAL.FillDataGrid(cmd, dgvTask);
                dgvTask.Columns["TaskID"].Visible = false;
                dgvTask.Columns["TaskID"].ReadOnly = true;
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
                if (cbProServiceItem.SelectedIndex < 1)
                {
                    dgvItem.DataSource = null;
                    return;
                }
                string cmd = "";
                if (cbProServiceItem.SelectedIndex > 0)
                    cmd = "SELECT ItemID, ItemName, Enabled FROM Item WHERE ProServiceID = " + cbProServiceItem.SelectedValue;

                oDAL.FillDataGrid(cmd, dgvItem);
                dgvItem.Columns["ItemID"].Visible = false;
                dgvItem.Columns["ItemID"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
        }

        private void tabCategories_SelectedIndexChanged(Object sender, EventArgs e)
        {
            RefreshComboBoxes();
            //switch ((sender as TabControl).SelectedIndex)
            //{
            //    case 0:
                    
            //        break;
            //    case 1:
            //        break;
            //}
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

        private void OnRowNumberChanged(DataGridView dgv, Label lblMessage)
        {
            lblMessage.ForeColor = SystemColors.ControlText;
            lblMessage.Text = "";
            //dgv.AutoResizeColumns();
        }

        private void DisplayMessage(Label lbl, string msg, Color color)
        {
            lbl.Text = msg;
            lbl.ForeColor = color;
        }

        /************************************** Cell Validation *************************************/
        /* Client */
        private void dgvClient_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = dgvClient.Columns[e.ColumnIndex].HeaderText;

            if (!headerText.Equals("Enabled")) return;
            if (dgvClient.Rows[e.RowIndex].IsNewRow) return;

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
            if (dgvProService.Rows[e.RowIndex].IsNewRow) return;

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
            if (dgvItem.Rows[e.RowIndex].IsNewRow) return;

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


        private void DeleteRow(DataGridView dgv, string id, Label lbl, string table, string tableID)
        {
            try
            {
                int iCount = 0;
                if (dgv.DataSource == null)
                {
                    MessageBox.Show("Data table is empty. Select a view or filter to populate table");
                    return;
                }

                if (dgv.SelectedRows.Count > 0)
                {
                    int i = 0;
                    DialogResult result = MessageBox.Show("Selected rows will be deleted. Continue?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow dr in dgv.SelectedRows)
                        {
                            if (oDAL.DeleteRecord(table, tableID, dr.Cells[id].Value.ToString()))
                            {
                                dgv.Rows.RemoveAt(dr.Index);
                                iCount--;
                                i++;
                            }
                            else
                            {
                                DisplayMessage(lbl, "An unexpected error has occured at row index " + dr.Index.ToString(), Color.Red);
                                return;
                            }
                        }
                        if (i == 1)
                            DisplayMessage(lbl, "1 record deleted", Color.Green);
                        else if (i > 1)
                            DisplayMessage(lbl, i.ToString() + " records deleted", Color.Green);
                        
                    }
                    else
                        return;
                }
                else
                {
                    MessageBox.Show("No rows selected. Select one or more rows by clicking the black arrow in the left-most cell");
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(lbl, "An unexpected error has occured", Color.Red);
                logger.Error(ex, ex.Source);
            }
        }

        private void BtnDeleteClient_Click(object sender, EventArgs e)
        {
            DeleteRow(dgvClient, "ClientID", lblMessageTop, "Client", "ClientID");
        }

        private void BtnDeletePS_Click(object sender, EventArgs e)
        {
            DeleteRow(dgvProService, "ProServiceID", lblMessageTopPS, "ProfessionalService", "ProServiceID");
        }

        private void BtnDeleteTask_Click(object sender, EventArgs e)
        {
            DeleteRow(dgvTask, "TaskID", lblMessageTopTask, "Task", "TaskID");
        }

        private void BtnDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteRow(dgvItem, "ItemID", lblMessageTopItem, "Item", "ItemID");
        }
    }
}
