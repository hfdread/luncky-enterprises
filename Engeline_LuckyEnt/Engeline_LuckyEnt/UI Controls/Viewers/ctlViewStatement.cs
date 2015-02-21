#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Engeline_LuckyEnt.Forms;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.UI_Controls.Transactions;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

//using Engeline_LuckyEnt.Reports;
#endregion

namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
    public partial class ctlViewStatement : UserControl
    {
        private bool m_bIsLoading = true;
        private StatementofAccountDao SOCDao = null;
        private StatementofAccount m_statement = null;
        DamagedMissingDao dmDao = null;

        private enum eCol
        {
            SOC_ID,
            Details,
            Supplier,
            Amount,
            AmountOverride,
            dm_items,
            Est,
            TrxDate,
            Ship,
            PayStatus,
            Shipment,
            Handling,
            Canceled,
            DetailsObject,
            ItemObject
        }

        private enum eShipmentSTatus
        {
            ARRIVED = 0,
            SHUTOUT,
            CANCELLED,
            SOME_CANCELLED,
            SOME_SHUTOUT,
            SOME_ARRIVE
        }

        public enum eStatus
        {
            CANCELLED = 0,
            ARRIVED,
            SHUTOUT
        }

        public ctlViewStatement()
        {
            InitializeComponent();
            SOCDao = new StatementofAccountDao();
            dmDao = new DamagedMissingDao();
        }

        private string GetPaymentStatus(int PayStatus)
        {
            switch (PayStatus)
            {
                case 0:
                    return "Paid";
                case 1:
                    return "Unpaid";
                case 2:
                    return "P. Paid";
                default:
                    return "";
            }
        }

        private string GetHandling(int handling)
        {
            switch (handling)
            {
                case 0:
                    return "Prepaid";
                case 1:
                    return "Collect";
                default:
                    return "";
            }
        }

        private string GetShippingStatus(int ShipStatus)
        {
            switch (ShipStatus)
            {
                case 0:
                    return "Arrived";
                case 1:
                    return "Shutout";
                case 2:
                    return "Cancelled";
                case 3:
                    return "Some Cancelled";
                case 4:
                    return "Some Shutout";
                case 5:
                    return "Some Arrived";
                default:
                    return "";
            }
        }


        private void dtRange_DateSelectionChanged(object sender, EventArgs e)
        {
            if (m_bIsLoading)
                return;

            if (dtRange.GetDateSelection() != ctlDateRange.eDateSelection.Custom)
                btnRefresh.PerformClick();
        }

        private void ctlViewStatement_Load(object sender, EventArgs e)
        {
            dtRange.SetDateSelection(ctlDateRange.eDateSelection.Today);
            m_statement = new StatementofAccount();
            m_bIsLoading = false;

            //load ship status
            cboVanStatus.Properties.Items.Add("Any");
            cboVanStatus.Properties.Items.Add("Shutout");
            cboVanStatus.Properties.Items.Add("Arrived");
            cboVanStatus.Properties.Items.Add("Cancelled");

            cboVanStatus.SelectedIndex = 0;

            btnRefresh.PerformClick();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
           // grdPO.DataSource = PurchaseOrderDao.GetAllRecordsByDateRange(dtRange.getDateFrom(), dtRange.getDateTo(), true, true);
            treeSOC.Nodes.Clear();

            IList<StatementofAccount> lst = SOCDao.GetAllRecordsByDateRange(dtRange.getDateFrom(), dtRange.getDateTo(), true, true, txtBillofLeading.Text.Trim(), cboVanStatus.SelectedText);
            TreeListNode ParentNode=null, ChildNode=null;

            foreach (StatementofAccount SOC in lst)
            {
                ParentNode = treeSOC.AppendNode(null, null);
                ParentNode.SetValue(eCol.ItemObject.ToString(), SOC);
                ParentNode.SetValue(eCol.SOC_ID.ToString(), string.Format("{0}", SOC.ID));
                if (SOC.Supplier.CompanyName == "")
                    ParentNode.SetValue(eCol.Supplier.ToString(), string.Format("{0} {1}", SOC.Supplier.FirstName, SOC.Supplier.LastName));
                else
                    ParentNode.SetValue(eCol.Supplier.ToString(), string.Format("{0}", SOC.Supplier.CompanyName));
                
                ParentNode.SetValue(eCol.Est.ToString(), string.Format("{0}", SOC.EstimatedArrival.ToString("MMM dd, yyyy")));
                ParentNode.SetValue(eCol.TrxDate.ToString(), string.Format("{0}", SOC.TransactionDate.ToString("MMM dd, yyyy")));
                ParentNode.SetValue(eCol.Ship.ToString(), string.Format("{0} - {1}", SOC.ShippingCompany, SOC.ShipName));
                ParentNode.SetValue(eCol.PayStatus.ToString(), string.Format("{0}", GetPaymentStatus(SOC.Payment)));
                //ParentNode.SetValue(eCol.Shipment.ToString(), string.Format("{0}", GetShippingStatus(SOC.ShippingStatus)));
                string ShipmentStatus = ParentShipmentStatus(SOC);
                ParentNode.SetValue(eCol.Shipment.ToString(), string.Format("{0}", ShipmentStatus));
                ParentNode.SetValue(eCol.Handling.ToString(), string.Format("{0}", GetHandling(SOC.Handling)));

                //check for missing/damanges
                ParentNode.SetValue(eCol.dm_items.ToString(), string.Format("{0}",  CheckMissingDamage(SOC)));
                ParentNode.SetValue(eCol.Amount.ToString(), string.Format("{0}", UpdateAmountDue(SOC)));

                if (SOC.AmountDueOverride == 0)
                    ParentNode.SetValue(eCol.AmountOverride.ToString(), "0.00");
                else
                    ParentNode.SetValue(eCol.AmountOverride.ToString(), string.Format("{0}", SOC.AmountDueOverride.ToString(clsUtil.FMT_AMOUNT)));


                string van1 = "";
                double vanTotalAmt = 0;
                int vanTotalQty = 0;
                StatementofAccountDetails xsocd = null;
                foreach (StatementofAccountDetails socd in SOC.details)
                {
                    xsocd = socd;

                    if (van1 == socd.VanNumber || van1 == "") // still same van
                    {
                        if (van1 == "")
                        {
                            ChildNode = treeSOC.AppendNode(null, ParentNode);
                            ChildNode.SetValue(eCol.DetailsObject.ToString(), xsocd);
                        }

                        van1 = socd.VanNumber;
                        vanTotalQty += socd.QTY;
                        vanTotalAmt += socd.QTY * socd.SellingPrice;

                        ChildNode.SetValue(eCol.Details.ToString(), string.Format("Van #: {0}\n" + "Total Quantity: {1}\n" + "Total Amt Due: {2}",
                            van1, vanTotalQty, vanTotalAmt.ToString("#,##0.00")));
                        ChildNode.SetValue(eCol.Shipment.ToString(), string.Format("{0}", GetVanStatus(socd.Status)));
                    }
                    else //new van, add previous to child nodes
                    {
                        ChildNode = treeSOC.AppendNode(null, ParentNode);
                        ChildNode.SetValue(eCol.DetailsObject.ToString(), xsocd);

                        //update data for new van
                        van1 = socd.VanNumber;
                        vanTotalQty = 0;
                        vanTotalAmt = 0;
                        vanTotalQty += socd.QTY;
                        vanTotalAmt += socd.QTY * socd.SellingPrice;

                        ChildNode.SetValue(eCol.Details.ToString(), string.Format("Van #: {0}\n" + "Total Quantity: {1}\n" + "Total Amt Due: {2}",
                            van1, vanTotalQty, vanTotalAmt.ToString("#,##0.00")));
                        ChildNode.SetValue(eCol.Shipment.ToString(), string.Format("{0}", GetVanStatus(socd.Status)));
                    }
                }

                //add last van
                //ChildNode = treeSOC.AppendNode(null, ParentNode);
                //ChildNode.SetValue(eCol.DetailsObject.ToString(), xsocd);
                //ChildNode.SetValue(eCol.Details.ToString(), string.Format("Van #: {0}\n" + "Total Quantity: {1}\n" + "Total Amt Due: {2}",
                //    van1, vanTotalQty, vanTotalAmt.ToString("#,##0.00")));
                //ChildNode.SetValue(eCol.Shipment.ToString(), string.Format("{0}", GetVanStatus(xsocd.Status)));
            }
        }

        private string CheckMissingDamage(StatementofAccount soc)
        {
            string retValue = "";
            IList<DamagedMissing> lstdm = dmDao.GetMissingDamageByStockinID(soc.ID);

            foreach (DamagedMissing dm in lstdm)
            {
                retValue += string.Format("{0}", dm.item.Name);

                if(dm.Damage_Qty !=0)
                    retValue += string.Format(" D: {0}\n", dm.Damage_Qty.ToString());

                if(dm.Missing_Qty != 0)
                    retValue += string.Format(" M: {0}\n", dm.Missing_Qty.ToString());
                
            }

            return retValue;
        }

        private string UpdateAmountDue(StatementofAccount soc)
        {
            Int32 totalDM = 0;
            double totalPriceDM = 0;
            IList<DamagedMissing> lstdm = dmDao.GetMissingDamageByStockinID(soc.ID);

            foreach (StatementofAccountDetails sid in soc.details)
            {
                foreach (DamagedMissing dm in lstdm)
                {
                    if (dm.item.ID == sid.item.ID)
                    {
                        totalDM += dm.Damage_Qty + dm.Missing_Qty;
                        totalPriceDM = totalDM * sid.SellingPrice;
                        soc.AmountDue -= totalPriceDM;
                    }

                    totalDM = 0;
                    totalPriceDM = 0;
                }
            }

            return soc.AmountDue.ToString(clsUtil.FMT_AMOUNT);
        }

        private string GetVanStatus(int shipStatus)
        {
            switch (shipStatus)
            {
                case 0:
                    return "Arrived";
                case 1:
                    return "Shutout";
                case 2:
                    return "Cancelled";
                default:
                    return "";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsUtil.getMainForm().CloseCurrentControl();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ctlStateofAccounts ctl = new ctlStateofAccounts();
            clsUtil.getMainForm().LoadCtl(ctl, true, "New Statement of Account", "Add a Statement of Account", true, DockStyle.Left);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            TreeListNode ParentNode, FocusNode;
            FocusNode = treeSOC.FocusedNode;

            if (FocusNode != null)
            {
                ctlStateofAccounts ctl = new ctlStateofAccounts();

                if (FocusNode.ParentNode != null)//probably a child
                {
                    ParentNode = FocusNode.ParentNode;
                    StatementofAccount SOC = (StatementofAccount)ParentNode.GetValue(eCol.ItemObject.ToString());
                    ctl.SOC = SOC;
                    clsUtil.getMainForm().LoadCtl(ctl, false, string.Format("SOC [{0}]", SOC.ID.ToString(clsUtil.FMT_ID)), "", false);
                }
                else //probably a parent
                {
                    StatementofAccount SOC = (StatementofAccount)FocusNode.GetValue(eCol.ItemObject.ToString());
                    ctl.SOC = SOC;
                    clsUtil.getMainForm().LoadCtl(ctl, false, string.Format("SOC [{0}]", SOC.ID.ToString(clsUtil.FMT_ID)), "", false);
                }
            }
        }

        private void mnu_arrive_Click(object sender, EventArgs e)
        {
            TreeListNode node, ParentNode;
            node = treeSOC.FocusedNode;

            bool arrived = true;
            string childShipmentStatus = "";

            if (node.ParentNode != null)//probably a child node
            {
                ParentNode = node.ParentNode;
                node.SetValue(eCol.Shipment.ToString(), string.Format("{0}", GetVanStatus((int)eShipmentSTatus.ARRIVED)));

                //foreach (TreeListNode child in ParentNode.Nodes)
                //{ 
                //    childShipmentStatus = (string)child.GetValue(eCol.Shipment.ToString());
                //    if (childShipmentStatus != "Arrived")
                //    {
                //        arrived = false;
                //    }
                //}
                //if (arrived)
                //{
                //    ParentNode.SetValue(eCol.Shipment.ToString(), string.Format("{0}", GetShippingStatus((int)eShipmentSTatus.ARRIVED)));
                //}
                //else
                //{
                //    ParentNode.SetValue(eCol.Shipment.ToString(), string.Format("{0}", GetShippingStatus((int)eShipmentSTatus.SOME_ARRIVE)));
                //}

                StatementofAccount soc = (StatementofAccount) ParentNode.GetValue(eCol.ItemObject.ToString());
                StatementofAccountDetailsDao socd_DAO = new StatementofAccountDetailsDao();
                StatementofAccountDetails socd =(StatementofAccountDetails) node.GetValue(eCol.DetailsObject.ToString());

                soc.ShippingStatus = m_statement.GetShipStatus((string)ParentNode.GetValue(eCol.Shipment.ToString()));
                IList<StatementofAccountDetails> xsocd = socd_DAO.getTrxVan(socd);
                
                
                foreach (StatementofAccountDetails lst in xsocd)
                {
                    lst.Status = m_statement.GetShipStatus((string)node.GetValue(eCol.Shipment.ToString()));
                    //soc.details.Add(lst);
                    socd_DAO.Save(lst);
                }
                SOCDao.StatusUpdate(soc);

                StatementofAccount lstSOC = SOCDao.GetById(soc.ID);
                string ShipmentStatus = ParentShipmentStatus(lstSOC);
                ParentNode.SetValue(eCol.Shipment.ToString(), string.Format("{0}", ShipmentStatus));
            }
            else 
            {
                ParentNode = node;
                ParentNode.SetValue(eCol.Shipment.ToString(), string.Format("{0}", GetShippingStatus((int)eShipmentSTatus.ARRIVED)));
                //foreach (TreeListNode child in ParentNode.Nodes)
                //{
                //    child.SetValue(eCol.Shipment.ToString(), string.Format("{0}", GetVanStatus((int)eShipmentSTatus.ARRIVED)));
                //}

                for (int i = 0; i < ParentNode.Nodes.Count; i++)
                {
                    TreeListNode child = ParentNode.Nodes[i];

                    child.SetValue(eCol.Shipment.ToString(), string.Format("{0}", GetVanStatus((int)eShipmentSTatus.ARRIVED)));
                }

                StatementofAccount soc = (StatementofAccount)ParentNode.GetValue(eCol.ItemObject.ToString());

                soc.ShippingStatus = m_statement.GetShipStatus((string)ParentNode.GetValue(eCol.Shipment.ToString()));
                foreach (StatementofAccountDetails socd in soc.details)
                {
                    socd.Status = m_statement.GetShipStatus("arrived");
                }

                SOCDao.Save(soc);
            }
        }

        private void mnu_shutout_Click(object sender, EventArgs e)
        {
            TreeListNode node, ParentNode;
            node = treeSOC.FocusedNode;

            bool arrived = true;
            string childShipmentStatus = "";

            if (node.ParentNode != null)//probably a child node
            {
                ParentNode = node.ParentNode;
                node.SetValue(eCol.Shipment.ToString(), string.Format("{0}", GetVanStatus((int)eShipmentSTatus.SHUTOUT)));

                StatementofAccount soc = (StatementofAccount)ParentNode.GetValue(eCol.ItemObject.ToString());
                StatementofAccountDetailsDao socd_DAO = new StatementofAccountDetailsDao();
                StatementofAccountDetails socd = (StatementofAccountDetails)node.GetValue(eCol.DetailsObject.ToString());

                soc.ShippingStatus = m_statement.GetShipStatus((string)ParentNode.GetValue(eCol.Shipment.ToString()));
                IList<StatementofAccountDetails> xsocd = socd_DAO.getTrxVan(socd);

                foreach (StatementofAccountDetails lst in xsocd)
                {
                    lst.Status = m_statement.GetShipStatus((string)node.GetValue(eCol.Shipment.ToString()));
                    //soc.details.Add(lst);
                    socd_DAO.Save(lst);
                }
                SOCDao.StatusUpdate(soc);

                StatementofAccount lstSOC = SOCDao.GetById(soc.ID);
                string ShipmentStatus = ParentShipmentStatus(lstSOC);
                ParentNode.SetValue(eCol.Shipment.ToString(), string.Format("{0}", ShipmentStatus));
            }
            else
            {
                ParentNode = node;
                ParentNode.SetValue(eCol.Shipment.ToString(), string.Format("{0}", GetShippingStatus((int)eShipmentSTatus.SHUTOUT)));
                //foreach (TreeListNode child in ParentNode.Nodes)
                //{
                //    child.SetValue(eCol.Shipment.ToString(), string.Format("{0}", GetVanStatus((int)eShipmentSTatus.SHUTOUT)));
                //}

                for (int i = 0; i < ParentNode.Nodes.Count; i++)
                {
                    TreeListNode child = ParentNode.Nodes[i];

                    child.SetValue(eCol.Shipment.ToString(), string.Format("{0}", GetVanStatus((int)eShipmentSTatus.SHUTOUT)));
                }


                StatementofAccount soc = (StatementofAccount)ParentNode.GetValue(eCol.ItemObject.ToString());

                soc.ShippingStatus = m_statement.GetShipStatus((string)ParentNode.GetValue(eCol.Shipment.ToString()));
                foreach (StatementofAccountDetails socd in soc.details)
                {
                    socd.Status = m_statement.GetShipStatus("shutout");
                }

                SOCDao.Save(soc);
            }
        }

        private void mnu_cancel_Click(object sender, EventArgs e)
        {
            TreeListNode node, ParentNode;
            node = treeSOC.FocusedNode;

            bool arrived = true;
            string childShipmentStatus = "";

            if (node.ParentNode != null)//probably a child node
            {
                ParentNode = node.ParentNode;
                node.SetValue(eCol.Shipment.ToString(), string.Format("{0}", GetVanStatus((int)eShipmentSTatus.CANCELLED)));

                StatementofAccount soc = (StatementofAccount)ParentNode.GetValue(eCol.ItemObject.ToString());
                StatementofAccountDetailsDao socd_DAO = new StatementofAccountDetailsDao();
                StatementofAccountDetails socd = (StatementofAccountDetails)node.GetValue(eCol.DetailsObject.ToString());

                soc.ShippingStatus = m_statement.GetShipStatus((string)ParentNode.GetValue(eCol.Shipment.ToString()));
                IList<StatementofAccountDetails> xsocd = socd_DAO.getTrxVan(socd);

                foreach (StatementofAccountDetails lst in xsocd)
                {
                    lst.Status = m_statement.GetShipStatus((string)node.GetValue(eCol.Shipment.ToString()));
                    //soc.details.Add(lst);
                    socd_DAO.Save(lst);
                }
                SOCDao.StatusUpdate(soc);

                StatementofAccount lstSOC = SOCDao.GetById(soc.ID);
                string ShipmentStatus = ParentShipmentStatus(lstSOC);
                ParentNode.SetValue(eCol.Shipment.ToString(), string.Format("{0}", ShipmentStatus));
            }
            else
            {
                ParentNode = node;
                ParentNode.SetValue(eCol.Shipment.ToString(), string.Format("{0}", GetShippingStatus((int)eShipmentSTatus.CANCELLED)));
                //foreach (TreeListNode child in ParentNode.Nodes)
                //{
                //    child.SetValue(eCol.Shipment.ToString(), string.Format("{0}", GetVanStatus((int)eShipmentSTatus.CANCELLED)));
                //}

                for (int i = 0; i < ParentNode.Nodes.Count; i++)
                {
                    TreeListNode child = ParentNode.Nodes[i];

                    child.SetValue(eCol.Shipment.ToString(), string.Format("{0}", GetVanStatus((int)eShipmentSTatus.CANCELLED)));
                }

                StatementofAccount soc = (StatementofAccount)ParentNode.GetValue(eCol.ItemObject.ToString());

                soc.ShippingStatus = m_statement.GetShipStatus((string)ParentNode.GetValue(eCol.Shipment.ToString()));
                foreach (StatementofAccountDetails socd in soc.details)
                {
                    socd.Status = m_statement.GetShipStatus("cancelled");
                }

                SOCDao.Save(soc);
            }
        }

        public string ParentShipmentStatus(StatementofAccount soc)
        {
            string retValue = "";
            
            // 0-arrived, 1-shutout, 2-cancelled
            int Arrived=0, Shutout=0, Cancel=0;
            foreach (StatementofAccountDetails socd in soc.details)
            {

                if (socd.Status == 0 && Arrived == 0)
                {
                    retValue += "A-";
                    Arrived = 1;
                }
                else if (socd.Status == 1 && Shutout == 0)
                {
                    retValue += "S-";
                    Shutout =1;
                }
                else if (socd.Status == 2 && Cancel == 0)
                {
                    retValue += "C-";
                    Cancel = 1;
                }
            }

            if(retValue != "")
                retValue = retValue.Remove(retValue.LastIndexOf("-"));

            if (retValue == "A")
                retValue = "Arrived";
            else if (retValue == "S")
                retValue = "Shutout";
            else if (retValue == "C")
                retValue = "Cancelled";

            if (Arrived == 0 && Shutout == 0 && Cancel == 0)
                retValue = "On Transit";

            return retValue;
        }

        private void mnu_receivePayment_Click(object sender, EventArgs e)
        {
            ctlStatementofAccount_ReceivePayment ctl = new ctlStatementofAccount_ReceivePayment();
            frmGenericPopup frm = new frmGenericPopup();

            TreeListNode selectedNode = null;
            selectedNode = treeSOC.FocusedNode;
            if (treeSOC.FocusedNode.ParentNode != null)
            {
                selectedNode = treeSOC.FocusedNode.ParentNode;
            }

            StatementofAccount statement = (StatementofAccount)selectedNode.GetValue(eCol.ItemObject.ToString());
            ctl.soc = statement;
            frm.Text = "Receive Payment";
            frm.ShowCtl(ctl);
        }

        private void CMMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TreeListNode SelectedNode = null;

            SelectedNode = treeSOC.FocusedNode;
            if (treeSOC.FocusedNode.ParentNode != null)//must be child
            {
                SelectedNode = treeSOC.FocusedNode.ParentNode;
            }

            StatementofAccount statement = (StatementofAccount) SelectedNode.GetValue(eCol.ItemObject.ToString());
            if (statement.Payment == 0)
                mnu_receivePayment.Enabled = false;
            else
                mnu_receivePayment.Enabled = true;

        }

    }
}
