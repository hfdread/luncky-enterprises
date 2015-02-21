#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion


namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
    public partial class ctlStateofAccounts_AddItem : UserControl
    {
        private ItemDao ItemDao = null;
        private ContactsDao mContactsDao = null;
        private WarehouseDao mWarehouseDao = null;
        private VantrackersDao mVantrackersDao = null;

        public ctlStateofAccounts ParentCtl { get; set; }

        public ctlStateofAccounts_AddItem()
        {
            InitializeComponent();
            ItemDao = new ItemDao();
            mContactsDao = new ContactsDao();
            mWarehouseDao = new WarehouseDao();
            mVantrackersDao = new VantrackersDao();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void ctlStateofAccounts_AddItem_Load(object sender, EventArgs e)
        {
            grdvItems.Columns["Name"].FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            grdvItems.Columns["Description"].FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            grdItems.DataSource = ItemDao.getAllRecords();
            txtSearch.Focus();

            //load vantrackers
            //LoadVanTrackers();
        }

        //private void LoadVanTrackers()
        //{
        //    IList<Vantrackers> lst = mVantrackersDao.getAllRecords();
        //    cboVanPickup.Properties.Items.Clear();
        //    foreach (Vantrackers v in lst)
        //    {
        //        cboVanPickup.Properties.Items.Add(v);
        //    }
        //}

        private void LoadWarehouse()
        {
            IList<Warehouse> lst = mWarehouseDao.getAllRecords();
            cboDestination.Properties.Items.Clear();
            foreach (Warehouse W in lst)
            {
                cboDestination.Properties.Items.Add(W);
            }
        }

        private void LoadCustomerList()
        {
            IList<Contacts> lst = mContactsDao.getAllCustomers();
            cboDestination.Properties.Items.Clear();
            foreach (Contacts C in lst)
            {
                cboDestination.Properties.Items.Add(C);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                string sFilter = clsUtil.GenerateFilterCondition(txtSearch.Text);
                grdvItems.ActiveFilterString = string.Format("[Name] LIKE '{0}' OR [Description] LIKE '{0}'", sFilter);
            }
        }

        private void grdvItems_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            Items I = (Items)grdvItems.GetRow(e.RowHandle);

            if (e.IsGetData && e.Column.FieldName == "UnitPrice")
            {
                e.Value = I.Price1.ToString("#,##0.00");
            }
            else if (e.IsGetData && e.Column.FieldName == "OnHand")
            {
                e.Value = I.QTYOnHand1.ToString("#,##0");
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            clsUtil.CheckValue(txtQuantity);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            Items item = (Items)grdvItems.GetRow(grdvItems.FocusedRowHandle);
            if (txtQuantity.Text.Length <= 0 || txtQuantity.Text == "" || Convert.ToInt32(txtQuantity.Text) <= 0)
            {
                clsUtil.ShowMessage("Cannot Add item with 0 or less quantity",
                                  "Cannot Add Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return;
            }

            if (txtPrice.Text.Length <= 0 || txtPrice.Text == "" || Convert.ToDouble(txtPrice.Text) <= 0)
            {
                clsUtil.ShowMessage("Cannot Add item with 0 or less selling price",
                                  "Cannot Add Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return;
            }

            if (item != null)
            {
                int QTY1 = (int)clsUtil.CheckValue(txtQuantity);
                double iPrice = Convert.ToDouble(txtPrice.Text);
                double Price1 = item.Price1;

                if (Price1 == 0)
                {
                    clsUtil.ShowMessage("Invalid Price!", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPrice.Focus();
                    return;
                }

                if (QTY1 == 0)
                {
                    clsUtil.ShowMessage("Invalid Quantity!", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtQuantity.Focus();
                    return;
                }

                if (iPrice  <= 0)
                {
                    clsUtil.ShowMessage("Selling Price must be above 0!", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPrice.Focus();
                    return;
                }

                if (txtVanNumber.Text == "" || txtVanNumber.Text.Length <= 0)
                {
                    clsUtil.ShowMessage("Van Number not specified!", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtVanNumber.Focus();
                    return;
                }

                //if (cboVanPickup.SelectedIndex == -1 || cboVanPickup.Text == "")
                //{
                //    clsUtil.ShowMessage("Van for pickup not specified!", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    cboVanPickup.Focus();
                //    return;
                //}

                //if (cboDestination.SelectedIndex == -1 || cboDestination.Text == "")
                //{
                //    clsUtil.ShowMessage("Van destination not specified!", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    cboDestination.Focus();
                //    return;
                //}

                StatementofAccountDetails SOCD = new StatementofAccountDetails();
                //Vantrackers v = (Vantrackers)cboVanPickup.SelectedItem;
                if (chkCustomer.Checked)
                {
                    try
                    {
                        Contacts c = (Contacts)cboDestination.SelectedItem;
                        SOCD.CustomerDestination = c;
                    }
                    catch (Exception ex)
                    {
                        clsUtil.ShowMessageExclamation("No Customer selected", "Add Item");
                        return;
                    }
                }
                else if (chkWarehouse.Checked)
                {
                    try
                    {
                        Warehouse w = (Warehouse)cboDestination.SelectedItem;
                        SOCD.WhDestination = w;
                    }
                    catch (Exception ex)
                    {
                        clsUtil.ShowMessageExclamation("No Warehouse selected", "Add Item");
                        return;
                    }
                }

                SOCD.item = item;
                SOCD.QTY = QTY1;
                SOCD.SellingPrice = iPrice;
                SOCD.VanNumber = txtVanNumber.Text;
                SOCD.VanTracker = null;
                SOCD.Status = SOCD.GetStatus("");
               

                //SOC_ctl.AddItem(SOCD);
                ((ctlStateofAccounts)ParentCtl).AddItem(SOCD);
            }
        }

        private void grdvItems_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Items I = (Items)grdvItems.GetRow(grdvItems.FocusedRowHandle);
            if (I != null)
            {
                txtPrice.Text = I.Price1.ToString("#,##0.00");
                txtQuantity.Text = "1";
                txtQuantity.Focus();
            }
        }

        private void chkWarehouse_CheckedChanged(object sender, EventArgs e)
        {
            cboDestination.Text = "";
            cboDestination.Properties.Items.Clear();

            if (chkWarehouse.Checked)
            {
                chkCustomer.Checked = false;
                LoadWarehouse();
            }
        }

        private void chkCustomer_CheckedChanged(object sender, EventArgs e)
        {
            cboDestination.Text = "";
            cboDestination.Properties.Items.Clear();

            if (chkCustomer.Checked)
            {
                chkWarehouse.Checked = false;
                LoadCustomerList();
            }
        }

        
    }
}
