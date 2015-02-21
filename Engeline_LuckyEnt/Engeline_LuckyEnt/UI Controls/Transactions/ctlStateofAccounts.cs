#region

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.Forms;
using Engeline_LuckyEnt.UI_Controls.Accounting;
using Engeline_LuckyEnt.UI_Controls.Utilities;
using Engeline_LuckyEnt.UI_Controls.Viewers;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
    public partial class ctlStateofAccounts : UserControl
    {
        private const string FMT_AMOUNT = "#,##0.00";
        private const string FMT_ID = "000000";


        public ctlStateofAccounts SOC_ctl { get; set; }
        public StatementofAccount m_stateofaccount { get; set; }

        private StatementofAccountDao statementDao = null;
        private WarehouseDao WHDao = null;
        private ContactsDao mContactsDao =null;
        private ShippingDao mShipDao = null;
        private Boolean m_bRunOnce = false;

        public StatementofAccount SOC = null;
        private enum eCol
        {
            VanNumber,
            QTY,
            ItemName,
            SellingPrice,
            VanTracker,
            Destination,
            ItemObject
        }


        public ctlStateofAccounts()
        {
            InitializeComponent();
            statementDao = new StatementofAccountDao();
            WHDao = new WarehouseDao();
            mContactsDao = new ContactsDao();
            mShipDao = new ShippingDao();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsUtil.getMainForm().CloseCurrentControl();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SOC != null)
            {
                if (txtMemo.Text.Trim() == "" )
                {
                    clsUtil.ShowMessageExclamation("Do not forget to provide notes/memo", "SOC Amount Override");
                    return;
                }

                SOC.Notes = txtMemo.Text;
                SOC.AmountDueOverride = Convert.ToDouble(txtOverrideAmount.Text);
                SOC.AmountDue = statementDao.GetTotalAmountDue(SOC.ID);

                try
                {
                    statementDao.StatusUpdate(SOC);
                    clsUtil.ShowMessage(string.Format("Statement of Account '{0}' Amount Overrided.", SOC.ID), "SOC Amount Override",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);

                    clsUtil.getMainForm().CloseCurrentControl();
                }
                catch (Exception ex)
                {
                    clsUtil.ShowMessage(string.Format("An error occurred while saving Statement of Account!\n[{0}]", ex.Message),
                                      "SOC Amount Override", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (cboPaid.SelectedIndex == -1)
                {
                    clsUtil.ShowMessage(string.Format("No payment status selected."), "Statement of Account",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cboShipping.SelectedIndex == -1)
                {
                    clsUtil.ShowMessage(string.Format("No Shipping selected."), "Statement of Account",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cboSupplier.SelectedIndex == -1)
                {
                    clsUtil.ShowMessage(string.Format("No Supplier status selected."), "Statement of Account",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cboShippingStatus.SelectedIndex == -1)
                {
                    clsUtil.ShowMessage(string.Format("No shipping status selected."), "Statement of Account",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtShipName.Text == "" || txtShipName.Text.Length == 0)
                {
                    clsUtil.ShowMessage(string.Format("No Ship Name supplied."), "Statement of Account",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtVoyageNumber.Text == "" || txtVoyageNumber.Text.Length == 0)
                {
                    clsUtil.ShowMessage(string.Format("No voyage number supplied."), "Statement of Account",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtBillofLeading.Text == "" || txtBillofLeading.Text.Length == 0)
                {
                    clsUtil.ShowMessage(string.Format("No bill of leading supplied."), "Statement of Account",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtChequeNumber.Text == "" || txtChequeNumber.Text.Length == 0)
                {
                    if (cboPaid.SelectedIndex == 0)
                    {
                        clsUtil.ShowMessage(string.Format("No cheque number supplied."), "Statement of Account",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (m_stateofaccount == null)
                {
                    clsUtil.ShowMessage(string.Format("Please add at least 1 item to SoC."), "Statement of Account",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (m_stateofaccount.details.Count <= 0)
                {
                    clsUtil.ShowMessage(string.Format("Please add at least 1 item to SoC."), "Statement of Account",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                m_stateofaccount.AmountDue = Convert.ToDouble(lblTotal.Text);
                m_stateofaccount.Supplier = (Contacts)cboSupplier.SelectedItem;
                m_stateofaccount.EstimatedArrival = dtArrivalDate.Value;
                m_stateofaccount.TransactionDate = DateTime.Today;
                m_stateofaccount.ShippingCompany = (Shipping)cboShipping.SelectedItem;
                m_stateofaccount.ShipName = txtShipName.Text;
                m_stateofaccount.VoyageNumber = txtVoyageNumber.Text;
                m_stateofaccount.BillofLeading = txtBillofLeading.Text;
                m_stateofaccount.Payment = m_stateofaccount.GetPaymentType(cboPaid.Text);
                m_stateofaccount.PayDate = dtPayDate.Value;
                m_stateofaccount.ChequeNumber = txtChequeNumber.Text;
                m_stateofaccount.Handling = m_stateofaccount.GetHandling(cboShippingStatus.Text);
                m_stateofaccount.ShippingStatus = m_stateofaccount.GetShipStatus("");
                m_stateofaccount.Notes = txtMemo.Text;
                m_stateofaccount.user = clsUtil.GetLoggedInUser();
                m_stateofaccount.Canceled = false;
                m_stateofaccount.wh_id = WHDao.GetWarehouseCode();

                try
                {
                    statementDao.Save(m_stateofaccount);
                    clsUtil.ShowMessage(string.Format("Statement of Account '{0}' saved.", m_stateofaccount.ID), "Statement of Account",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //ctlViewStatement ctl = new ctlViewStatement();
                    //clsUtil.getMainForm().LoadCtl(ctl, true, "Statement of Accounts Viewer", "", false);

                    clsUtil.getMainForm().CloseCurrentControl();
                }
                catch (Exception ex)
                {
                    clsUtil.ShowMessage(string.Format("An error occurred while saving Statement of Account!\n[{0}]", ex.Message),
                                      "Save Statement of Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        public void AddItem(StatementofAccountDetails SOCD)
        {
            TreeListNode ParentNode = null, ChildNode = null;
            bool bExist = false;

            foreach (TreeListNode node in tlSOC.Nodes)
            {
                if(SOCD.VanNumber == (string)node.GetValue(eCol.VanNumber.ToString()))
                {
                    ParentNode = node;
                    bExist = true;
                }
            }

            if (!bExist)
            {
                ParentNode = tlSOC.AppendNode(null, null);
                //ParentNode.SetValue(eCol.ItemObject.ToString(), SOCD);
                ParentNode.SetValue(eCol.VanNumber.ToString(), string.Format("{0}", SOCD.VanNumber));
                if (SOCD.VanTracker != null)
                {
                    ParentNode.SetValue(eCol.VanTracker.ToString(), string.Format("{0}", SOCD.VanTracker.VanName));
                }

                if (SOCD.WhDestination != null)
                {
                    ParentNode.SetValue(eCol.Destination.ToString(), string.Format("{0}", SOCD.WhDestination.Name));
                }

                if (SOCD.CustomerDestination != null)
                {
                    ParentNode.SetValue(eCol.Destination.ToString(), string.Format("{0} / {1} {2}", 
                        SOCD.CustomerDestination.CompanyName, SOCD.CustomerDestination.FirstName, SOCD.CustomerDestination.LastName));
                }
            }

            //get first total qty
            int totalQTY = 0;
            if ((string)ParentNode.GetValue(eCol.QTY.ToString()) != null)
            {
                string strTotalQty = "";
                strTotalQty = (string)ParentNode.GetValue(eCol.QTY.ToString());
                totalQTY = Convert.ToInt32(strTotalQty);
            }

            if(m_stateofaccount != null)
                m_stateofaccount.details.Add(SOCD);

            tlSOC.BeginUnboundLoad();
            if (SOCD.item != null)
            {
                ChildNode = tlSOC.AppendNode(null, ParentNode);
                ChildNode.SetValue(eCol.ItemObject.ToString(), SOCD);
                ChildNode.SetValue(eCol.ItemName.ToString(),
                                    string.Format("{0}, {1}", SOCD.item.Name, SOCD.item.Description));
                ChildNode.SetValue(eCol.QTY.ToString(), string.Format("{0}", SOCD.QTY));
                ChildNode.SetValue(eCol.SellingPrice.ToString(), string.Format("{0}", SOCD.SellingPrice));
                totalQTY += SOCD.QTY;
            }

            ParentNode.SetValue(eCol.QTY.ToString(), string.Format("{0}", totalQTY));
            

            tlSOC.SetFocusedNode(ParentNode);
            tlSOC.EndUnboundLoad();
            if (SOC == null)
            {
                ComputeTotal();
            }
        }

        private Double ComputeTotal()
        {
            double Total = 0;

            if (m_stateofaccount != null)
            {
                foreach (StatementofAccountDetails SOCd in m_stateofaccount.details)
                {
                    if (SOCd.item != null)
                    {
                        Total += clsUtil.DiscountAmt(SOCd.SellingPrice, "") * SOCd.QTY;
                    }
                }
            }
            else
            {
                foreach (StatementofAccountDetails SOCd in SOC.details)
                {
                    if (SOCd.item != null)
                    {
                        Total += clsUtil.DiscountAmt(SOCd.SellingPrice, "") * SOCd.QTY;
                    }
                }
            }

            lblTotal.Text = Total.ToString("#,##0.00");
            return Total;
        }

        private void btnAddVan_Click(object sender, EventArgs e)
        {
            ctlStateofAccounts_AddItem ctl = new ctlStateofAccounts_AddItem();
            frmGenericPopup frm = new frmGenericPopup();

            if (m_stateofaccount == null)
            {
                m_stateofaccount = new StatementofAccount();
                //soc.details = new List<StatementofAccountDetails>();
                //tlSOC.DataSource = soc.details;
            }

            ctl.ParentCtl = this;
            frm.Text = "Select Item";
            frm.ShowCtl(ctl);
        }

        private void btnRemoveVan_Click(object sender, EventArgs e)
        {
            TreeListNode node = tlSOC.FocusedNode;
            StatementofAccountDetails socd = null;
            if(node !=null)
            {
                tlSOC.BeginUpdate();
                //delete parent
                if (node.ParentNode == null)
                {
                    if (clsUtil.ShowMessageYesNo(string.Format("Are you sure you want to delete Van # '{0}'?", node.GetValue(eCol.VanNumber.ToString())), "Delete Van") == DialogResult.No)
                        return;

                    foreach (TreeListNode cnode in node.Nodes)
                    {
                        socd = (StatementofAccountDetails)cnode.GetValue(eCol.ItemObject.ToString());
                        //update total qty & amount due
                        UpdateTotals(cnode, lblTotal.Text);

                        m_stateofaccount.details.Remove(socd);
                    }

                    tlSOC.Nodes.Remove(node);
                }
                else//delete child
                {
                   socd = (StatementofAccountDetails)node.GetValue(eCol.ItemObject.ToString());
                   //update total qty & amount due
                   UpdateTotals(node, lblTotal.Text);

                   m_stateofaccount.details.Remove(socd);
                   tlSOC.Nodes.Remove(node);
                }
                tlSOC.EndUpdate();
            }
        }

        private void UpdateTotals(TreeListNode remNode, string trxTotal)
        {
            string qty="", price="", origQty="";
            double remAmount=0, origAmount=0, newAmount=0;

            if (remNode.ParentNode != null)//probably a child node
            {
                qty = (string)remNode.GetValue(eCol.QTY.ToString());//get the quantity of the removed node
                price = (string)remNode.GetValue(eCol.SellingPrice.ToString()); // the price of the removed node
                remAmount = Convert.ToInt32(qty) * Convert.ToDouble(price);
                origAmount = Convert.ToDouble(trxTotal);
                newAmount = origAmount - remAmount;

                //update the total qty of the parentode
                origQty = (string)remNode.ParentNode.GetValue(eCol.QTY.ToString());
                remNode.ParentNode.SetValue(eCol.QTY.ToString(), string.Format("{0}", Convert.ToInt32(origQty) - Convert.ToInt32(qty)));
            }
            else //probably a parent
            {
                if (remNode.HasChildren)
                {
                    foreach (TreeListNode cnode in remNode.Nodes)
                    {
                        qty = (string)cnode.GetValue(eCol.QTY.ToString());//get the quantity of the removed node
                        price = (string)cnode.GetValue(eCol.SellingPrice.ToString()); // the price of the removed node
                        remAmount += Convert.ToInt32(qty) * Convert.ToDouble(price);
                    }

                    origAmount = Convert.ToDouble(trxTotal);
                    newAmount = origAmount - remAmount;
                }
                else
                {
                    newAmount = Convert.ToDouble(trxTotal);
                }
            }

            lblTotal.Text = newAmount.ToString("#,##0.00"); ;
        }

        private void ctlStateofAccounts_Load(object sender, EventArgs e)
        {
            DisableEdit();
            LoadSuppliers();
            LoadShippers();
            LoadOtherOptions();

            //balance preview
            label2.Visible = false;
            lblBalance.Visible = false;
            grdPayments.Visible = false;

            //amount due overrides
            btnOverride.Visible = false;
            lblAmountOverride.Visible = false;
            txtOverrideAmount.Visible = false;

            if (SOC != null)
            {
                txtInvoiceNo.Text = SOC.ID.ToString(clsUtil.FMT_ID);
                cboSupplier.Text = SOC.Supplier.ToString();
                cboShipping.Text = SOC.ShippingCompany.ToString();
                txtShipName.Text = SOC.ShipName;
                txtVoyageNumber.Text = SOC.VoyageNumber;
                txtBillofLeading.Text = SOC.BillofLeading;

                if (SOC.Payment != 2)
                    cboPaid.SelectedIndex = SOC.Payment;
                else
                    cboPaid.Text = "P. Paid";

                double PaymentHistory = 0, bal =0;
                SOC_PaymentsDao socpDao = new SOC_PaymentsDao();
                IList<SOC_Payments> lstSOCP = socpDao.GetAllPartialPayments(SOC.ID);
                if (lstSOCP.Count > 0)
                {
                    foreach (SOC_Payments payments in lstSOCP)
                    {
                        PaymentHistory += payments.Amount;
                    }
                }
                else
                {
                    if(SOC.Payment == 0)
                        PaymentHistory = SOC.AmountDue;
                }


                bal = statementDao.GetTotalAmountDue(SOC.ID) -PaymentHistory;
                if (bal < 0)
                {
                    label2.Text = "REFUND";
                    bal = Math.Abs(bal);
                }

                lblBalance.Text = bal.ToString(FMT_AMOUNT);
                cboShippingStatus.SelectedIndex = SOC.Handling;
                txtChequeNumber.Text = SOC.ChequeNumber;
                txtMemo.Text = SOC.Notes;
                lblTotal.Text = statementDao.GetTotalAmountDue(SOC.ID).ToString("#,##0.00");

                dtArrivalDate.Value = SOC.EstimatedArrival;
                dtPayDate.Value = SOC.PayDate;

                //add items
                foreach (StatementofAccountDetails socd in SOC.details)
                {
                    AddItem(socd);
                }

                //load payments
                LoadPayments(SOC.ID);

                btnSave.Enabled = false;
                btnAddVan.Enabled = false;
                btnRemoveVan.Enabled = false;

                DamagedMissingDao dmDao = new DamagedMissingDao();
                IList<DamagedMissing> lstDM = dmDao.GetMissingDamageByStockinID(SOC.ID);
                
                if(lstDM.Count > 0)
                    btnOverride.Visible = true;

                if (SOC.AmountDueOverride > 0)
                {
                    txtOverrideAmount.Visible = true;
                    txtOverrideAmount.Text = SOC.AmountDueOverride.ToString(clsUtil.FMT_AMOUNT);
                    txtOverrideAmount.Properties.ReadOnly = true;
                    lblAmountOverride.Visible = true;
                }
            }

            m_bRunOnce = true;//for updating comboboxes
        }

        private void LoadPayments(Int32 SOC_ID)
        {
            SOC_PaymentsDao socpDao = new SOC_PaymentsDao();
            IList<SOC_Payments> lstsocp = socpDao.GetAllPayments(SOC_ID);
            if (lstsocp.Count > 0)
            {
                grdPayments.Visible = true;
                label2.Visible = true;
                lblBalance.Visible = true;
                grdPayments.DataSource = lstsocp;
            }
            else
            {
                grdPayments.Visible = false;
                label2.Visible = false;
                lblBalance.Visible = false;
            }
        }

        private void LoadSuppliers()
        {
           IList<Contacts> lst =  mContactsDao.getAllSuppliers(false);
           cboSupplier.Properties.Items.Clear();
           foreach (Contacts c in lst)
           {
               cboSupplier.Properties.Items.Add(c);
           }

           cboSupplier.SelectedIndex = -1;
        }

        private void LoadShippers()
        {
            IList<Shipping> lst = mShipDao.getAllRecords();
            cboShipping.Properties.Items.Clear();
            foreach (Shipping ship in lst)
            {
                cboShipping.Properties.Items.Add(ship);
            }

            cboShipping.SelectedIndex = -1;
        }

        private void LoadOtherOptions()
        {
            //paid
            cboPaid.Properties.Items.Clear();
            cboPaid.Properties.Items.Add("Paid");
            cboPaid.Properties.Items.Add("Unpaid");
            cboPaid.SelectedIndex = 0;

            //shipping status
            cboShippingStatus.Properties.Items.Clear();
            cboShippingStatus.Properties.Items.Add("Prepaid");
            cboShippingStatus.Properties.Items.Add("Collect");
            cboShippingStatus.SelectedIndex = 0;
        }

        private void cboPaid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPaid.SelectedIndex == 1)
                dtPayDate.Enabled = false;
            else
                dtPayDate.Enabled = true;
        }

        private void cboShipping_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DisableEdit()
        {
            cboSupplier.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cboShipping.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cboPaid.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cboShippingStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }

        private void ctlStateofAccounts_VisibleChanged(object sender, EventArgs e)
        {
            UserControl myUC = sender as UserControl;
            if (myUC.Visible == true && !m_bRunOnce)
            {
                LoadSuppliers();
                LoadShippers();
            }

            if (m_bRunOnce)
                m_bRunOnce = false;
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
           // StatementofAccount SOC = (StatementofAccount)grdvSOC.GetRow(e.RowHandle);
            SOC_Payments payment = (SOC_Payments)gridView1.GetRow(e.RowHandle);

            if (e.IsGetData && e.Column.FieldName == "Type")
            {
                //e.Value = SOC.ShippingCompany.CompanyName + "-" + SOC.ShipName;
                if (payment.Chequenumber.Trim().Length == 0 || payment.Chequenumber == null)
                {
                    e.Value = "Cash";
                }
                else
                {
                    e.Value = "Cheque";
                }
            }
        }

        private void btnOverride_Click(object sender, EventArgs e)
        {
            lblAmountOverride.Visible = true;
            txtOverrideAmount.Visible = true;

            if (txtOverrideAmount.Properties.ReadOnly)
                txtOverrideAmount.Properties.ReadOnly = false;

            btnSave.Enabled = true;
        }

    }
}
