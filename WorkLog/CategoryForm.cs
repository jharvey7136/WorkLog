using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WorkLog
{
    public partial class CategoryForm : Form
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly DAL oDAL = new DAL();

        public CategoryForm()
        {
            try
            {
                InitializeComponent();
                InitializeDefaults();

                dgvClient.RowsAdded += (s, a) => OnRowNumberChanged(lblMessageTop);
                dgvProService.RowsAdded += (s, a) => OnRowNumberChanged(lblMessageTopPS);
                dgvTask.RowsAdded += (s, a) => OnRowNumberChanged(lblMessageTopTask);
                dgvItem.RowsAdded += (s, a) => OnRowNumberChanged(lblMessageTopItem);

                // Attach DataGridView events to the corresponding event handlers.
                dgvClient.CellValidating += DgvClient_CellValidating;
                dgvClient.CellEndEdit += DgvClient_CellEndEdit;

                dgvProService.CellValidating += DgvProService_CellValidating;
                dgvProService.CellEndEdit += DgvProService_CellEndEdit;

                dgvTask.CellValidating += DgvTask_CellValidating;
                dgvTask.CellEndEdit += DgvTask_CellEndEdit;

                dgvItem.CellValidating += DgvItem_CellValidating;
                dgvItem.CellEndEdit += DgvItem_CellEndEdit;

                tabCategories.SelectedIndexChanged += TabCategories_SelectedIndexChanged;

                dgvClient.DataBindingComplete += DgvClient_DataBindingComplete;

                FormClosing += CategoryForm_FormClosing;

                dgvTask.DataSource = null;
                dgvItem.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"An error has occurred while trying to open the category management tool");
                logger.Error(ex, ex.Source);
            }

        }

        private void InitializeDefaults()
        {
            try
            {
                ResetMessageTop();
                GetDataClient();
                GetDataProService();
                RefreshComboBoxes();

                dgvProService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTask.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"An error has occurred initializing the category management tool");
                logger.Error(ex, ex.Source);
            }
        }

        private void DgvClient_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvClient.Columns["ClientID"].Visible = false;
                dgvClient.Columns["ClientID"].ReadOnly = true;
                dgvClient.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                DisplayMessage(lblMessageTop, "An unexpected error has occurred", Color.Red);
                logger.Error(ex, ex.Source);
            }
        }

        private void RefreshComboBoxes()
        {
            try
            {
                /* Fill Task page dropdown */
                oDAL.FillComboBox("SELECT ProServiceID, ProServiceName FROM ProfessionalService WHERE Enabled = 1 ", cbProService, "ProServiceName", "ProServiceID");

                /* Fill Item page dropdown */
                oDAL.FillComboBox("SELECT ProServiceID, ProServiceName FROM ProfessionalService WHERE Enabled = 1 ", cbProServiceItem, "ProServiceName", "ProServiceID");
            }
            catch (Exception ex)
            {
                DisplayMessage(lblMessageTop, "An unexpected error has occurred", Color.Red);
                logger.Error(ex, ex.Source);
            }
        }

        /* ------------------------------------------------------------------------------------------------ */
        private void BtnUpdateClient_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(@"Database will be updated. Continue?", @"Apply Changes Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (oDAL.UpdateClient(dgvClient))
                    {
                        GetDataClient();
                        DisplayMessage(lblMessageTop, "Update Successful", Color.Green);
                        logger.Info("Client table updated");
                    }
                    else
                        DisplayMessage(lblMessageTop, "Client update failed", Color.Red);
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                DisplayMessage(lblMessageTop, "An unexpected error has occurred", Color.Red);
                logger.Error(ex, ex.Source);
            }
        }

        private void BtnUpdatePS_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(@"Database will be updated. Continue?", @"Apply Changes Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (oDAL.UpdateProService(dgvProService))
                    {
                        RefreshComboBoxes();
                        GetDataProService();
                        DisplayMessage(lblMessageTopPS, "Update Successful", Color.Green);
                        logger.Info("Professional Service table updated");
                    }
                    else
                        DisplayMessage(lblMessageTopPS, "Professional Service update failed", Color.Red);
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                DisplayMessage(lblMessageTopPS, "An unexpected error has occurred", Color.Red);
                logger.Error(ex, ex.Source);
            }
        }

        private void BtnUpdateTask_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(@"Database will be updated. Continue?", @"Apply Changes Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (oDAL.UpdateTask(dgvTask, cbProService))
                    {
                        GetDataTask();
                        DisplayMessage(lblMessageTopTask, "Update Successful", Color.Green);
                        logger.Info("Task table updated");
                    }
                    else
                        DisplayMessage(lblMessageTopTask, "Task update failed", Color.Red);
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                DisplayMessage(lblMessageTopTask, "An unexpected error has occurred", Color.Red);
                logger.Error(ex, ex.Source);
            }
        }

        private void BtnUpdateItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(@"Database will be updated. Continue?", @"Apply Changes Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (oDAL.UpdateItem(dgvItem, cbProServiceItem))
                    {
                        GetDataItem();
                        DisplayMessage(lblMessageTopItem, "Update Successful", Color.Green);
                        logger.Info("Item table updated");
                    }
                    else
                        DisplayMessage(lblMessageTopItem, "Item update failed", Color.Red);
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                DisplayMessage(lblMessageTopItem, "An unexpected error has occurred", Color.Red);
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

        private void BtnDeleteClient_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dgvClient, "ClientID", lblMessageTop, "Client", "ClientID");
                GetDataClient();
            }
            catch (Exception ex)
            {
                DisplayMessage(lblMessageTop, "An unexpected error has occurred", Color.Red);
                logger.Error(ex, ex.Source);
            }
        }

        private void BtnDeletePS_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dgvProService, "ProServiceID", lblMessageTopPS, "ProfessionalService", "ProServiceID");
                GetDataProService();
                RefreshComboBoxes();
            }
            catch (Exception ex)
            {
                DisplayMessage(lblMessageTopPS, "An unexpected error has occurred", Color.Red);
                logger.Error(ex, ex.Source);
            }
        }

        private void BtnDeleteTask_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dgvTask, "TaskID", lblMessageTopTask, "Task", "TaskID");
                GetDataTask();
            }
            catch (Exception ex)
            {
                DisplayMessage(lblMessageTopTask, "An unexpected error has occurred", Color.Red);
                logger.Error(ex, ex.Source);
            }
        }

        private void BtnDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dgvItem, "ItemID", lblMessageTopItem, "Item", "ItemID");
                GetDataItem();
            }
            catch (Exception ex)
            {
                DisplayMessage(lblMessageTopItem, "An unexpected error has occurred", Color.Red);
                logger.Error(ex, ex.Source);
            }
        }

        /* ------------------------------------------------------------------------------------------------ */

        private void GetDataClient()
        {
            try
            {
                const string cmd = "SELECT DISTINCT ClientID, ClientName, Rate, AddressLine1, AddressLine2, City, State, Zip, Enabled FROM Client ORDER BY ClientID";
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
                const string cmd = "SELECT DISTINCT ProServiceID, ProServiceName, Enabled FROM ProfessionalService ORDER BY ProServiceID";
                oDAL.FillDataGrid(cmd, dgvProService);
                dgvProService.Columns["ProServiceID"].Visible = false;
                dgvProService.Columns["ProServiceID"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Source);
            }
        }

        private void GetDataTask()
        {
            if (dgvTask.DataSource == null)
                return;
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
            if (dgvItem.DataSource == null)
                return;
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

        private void CbProService_SelectedIndexChanged(object sender, EventArgs e)      //Task page
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

        private void CbProServiceItem_SelectedIndexChanged(object sender, EventArgs e)  //Item page
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

        private void TabCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RefreshComboBoxes();
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

        private static void OnRowNumberChanged(Label lblMessage)
        {
            lblMessage.ForeColor = SystemColors.ControlText;
            lblMessage.Text = "";
        }

        private void DisplayMessage(Label lbl, string msg, Color color)
        {
            lbl.Text = msg;
            lbl.ForeColor = color;
        }

        private void DeleteRow(DataGridView dgv, string id, Label lbl, string table, string tableID)
        {
            try
            {
                if (dgv.DataSource == null)
                {
                    MessageBox.Show(@"Data table is empty. Select a view or filter to populate table");
                    return;
                }

                if (dgv.SelectedRows.Count > 0)
                {
                    int i = 0;
                    DialogResult result = MessageBox.Show(@"Selected rows will attempt to be deleted. Continue?", @"Delete Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow dr in dgv.SelectedRows)
                        {
                            if (dr.Cells[id].Value == DBNull.Value || dr.Cells[id].Value == null)
                            {
                                DisplayMessage(lbl, "Row is empty", Color.Red);
                                return;
                            }

                            if (oDAL.DeleteRecord(table, tableID, dr.Cells[id].Value.ToString()))
                            {
                                dgv.Rows.RemoveAt(dr.Index);
                                i++;
                            }
                            else
                            {
                                DisplayMessage(lbl, "Error while attempting to delete", Color.Red);
                                return;
                            }
                        }
                        if (i == 1)
                            DisplayMessage(lbl, "1 row deleted", Color.Green);
                        else if (i > 1)
                            DisplayMessage(lbl, i + " rows deleted", Color.Green);
                    }
                    else
                        return;
                }
                else
                {
                    MessageBox.Show(@"No rows selected. Select one or more rows by clicking the black arrow in the left-most cell");
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(lbl, "An unexpected error has occurred", Color.Red);
                logger.Error(ex, ex.Source);
            }
        }

        /************************************** Cell Validation *************************************/
        /* Client */
        private void DgvClient_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = dgvClient.Columns[e.ColumnIndex].HeaderText;

            if (headerText.Equals("Rate"))
            {
                if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                    return;

                if (Regex.IsMatch(e.FormattedValue.ToString(), @"^\d+$")) return;
                dgvClient.Rows[e.RowIndex].ErrorText = "Rate must be whole number";
                e.Cancel = true;
            }

            if (!headerText.Equals("Enabled")) return;
            if (dgvClient.Rows[e.RowIndex].IsNewRow) return;

            if (e.FormattedValue.ToString() == "0" || e.FormattedValue.ToString() == "1")
                return;
            dgvClient.Rows[e.RowIndex].ErrorText = "Enabled must be 0 or 1 (0 = disabled, 1 = enabled)";
            e.Cancel = true;
        }

        private void DgvClient_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvClient.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        /* ProService */
        private void DgvProService_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = dgvProService.Columns[e.ColumnIndex].HeaderText;

            if (!headerText.Equals("Enabled")) return;
            if (dgvProService.Rows[e.RowIndex].IsNewRow) return;

            if (e.FormattedValue.ToString() == "0" || e.FormattedValue.ToString() == "1")
                return;
            dgvProService.Rows[e.RowIndex].ErrorText = "Enabled must be 0 or 1 (0 = disabled, 1 = enabled)";
            e.Cancel = true;
        }

        private void DgvProService_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvProService.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        /* Task */
        private void DgvTask_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = dgvTask.Columns[e.ColumnIndex].HeaderText;

            if (!headerText.Equals("Enabled")) return;
            if (dgvTask.Rows[e.RowIndex].IsNewRow) return;

            if (e.FormattedValue.ToString() == "0" || e.FormattedValue.ToString() == "1")
                return;
            dgvTask.Rows[e.RowIndex].ErrorText = "Enabled must be 0 or 1 (0 = disabled, 1 = enabled)";
            e.Cancel = true;
        }

        private void DgvTask_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvTask.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        /* Item */
        private void DgvItem_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = dgvItem.Columns[e.ColumnIndex].HeaderText;

            if (!headerText.Equals("Enabled")) return;
            if (dgvItem.Rows[e.RowIndex].IsNewRow) return;

            if (e.FormattedValue.ToString() == "0" || e.FormattedValue.ToString() == "1")
                return;
            dgvItem.Rows[e.RowIndex].ErrorText = "Enabled must be 0 or 1 (0 = disabled, 1 = enabled)";
            e.Cancel = true;
        }

        private void DgvItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvItem.Rows[e.RowIndex].ErrorText = string.Empty;
        }


        private void CategoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //logger.Info("Category form closing... Backing up database");
            oDAL.BackupDB();
        }


    }
}
