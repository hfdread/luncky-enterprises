#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.Forms;
using Engeline_LuckyEnt.UI_Controls.Transactions;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
    public partial class ctlViewInventory : UserControl
    {
        private readonly StockInDetailsDao StockInDetailsDao = new StockInDetailsDao();
        private readonly ItemDao ItemDao = new ItemDao();
        private SettingsDao settingsDao = new SettingsDao();
        private WarehouseDao WHDao = new WarehouseDao();

        public bool Canceled { get; set; }
        public UserControl ParentCtl { get; set; }
        public bool m_bIsLoading = true;

        private enum eCol
        {
            ItemName,
            StockInID,
            OnHand_1,
            OnHand_2,
            BasePrice,
            Capital,
            SellingPrice_1,
            SellingPrice_2,
            LockIcon,
            ItemObject,
            Code,
            Warehouse
        }

        public ctlViewInventory()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string Condition = txtSearch.Text;
            Warehouse selectedWarehouse = null;
            try
            {
                if (cboWarehouse.SelectedIndex != 0)
                    selectedWarehouse = (Warehouse)cboWarehouse.SelectedItem;
            }
            catch (Exception ex)
            {
                clsUtil.ShowMessageError("Invalid Warehouse Selected!");
                return;
            }

            if (Condition != "")
            {
                Condition = clsUtil.GenerateFilterCondition(txtSearch.Text);
                Condition = string.Format("(sid.item.Name like '{0}' or sid.item.Description like '{0}') ", Condition);
                if (selectedWarehouse != null)
                {
                    Condition += string.Format("and sid.WarehouseStockin='{0}'", selectedWarehouse.ID);
                }
            }
            else
            {
                if (selectedWarehouse != null)
                {
                    Condition += string.Format(" sid.WarehouseStockin='{0}'", selectedWarehouse.ID);
                }
            }
            

            IList<StockInDetails> lst = StockInDetailsDao.GetAvailableStocks(Condition, true, false, false);

            treeItems.Nodes.Clear();
            int ItemID = 0;
            TreeListNode ParentNode = null, ChildNode = null;//, ParentWireNode = null;
            double Price1 = 0;//, Price2 = 0;
            Int32 QTY_OnHand1;//, QTY_OnHand2;

            treeItems.BeginUnboundLoad();
            foreach (StockInDetails sid in lst)
            {
                if (ItemID != sid.item.ID)
                {
                    ItemID = sid.item.ID;
                    ParentNode = treeItems.AppendNode(null, null);
                    ParentNode.SetValue(eCol.Code.ToString(), string.Format("{0}",sid.item.Code));
                    ParentNode.SetValue(eCol.ItemName.ToString(),
                                        string.Format("{0}\n{1}", sid.item.Name, sid.item.Description));
                    ParentNode.SetValue(eCol.ItemObject.ToString(), sid);
                    ParentNode.SetValue(eCol.OnHand_1.ToString(), 0);
                    ParentNode.SetValue(eCol.OnHand_2.ToString(), 0);
                }
                ChildNode = treeItems.AppendNode(null, ParentNode);
                ChildNode.SetValue(eCol.StockInID.ToString(), sid.stockin.ID.ToString("000000"));
                ChildNode.SetValue(eCol.ItemObject.ToString(), sid);

                //set icon for Locked items
                if (sid.Status == (int)StockInDetails.eStatus.Locked)
                    ChildNode.StateImageIndex = 1;

                //save StockInDetails to node
                ChildNode.SetValue(eCol.OnHand_1.ToString(), sid.QTY_OnHand1);
                ChildNode.SetValue(eCol.BasePrice.ToString(), sid.item.Price1);
                Warehouse wh = WHDao.GetWHById(sid.WarehouseStockin);
                ChildNode.SetValue(eCol.Warehouse.ToString(), wh.ID + ", " + wh.Name);

                if (sid.Discount != "" && sid.Discount != null)
                    ChildNode.SetValue(eCol.Capital.ToString(),
                                        string.Format("{0}\n[@{1}]",
                                                        clsUtil.DiscountAmt(sid.Price1, sid.Discount).ToString(
                                                        clsUtil.FMT_AMOUNT), sid.Discount));
                else
                    ChildNode.SetValue(eCol.Capital.ToString(), clsUtil.DiscountAmt(sid.Price1, sid.Discount));

                if (sid.SellingPrice1 == 0)
                    Price1 = 0;//clsUtil.DiscountAmt(sid.Price1, sid.SellingDiscount1);
                else
                    Price1 = sid.SellingPrice1;

                if (sid.SellingDiscount1 != "" && sid.SellingDiscount1 != null)
                {
                    Price1 = clsUtil.DiscountAmt(sid.Price1, sid.SellingDiscount1);
                    ChildNode.SetValue(eCol.SellingPrice_1.ToString(),
                                        string.Format("{0}\n[@{1}]", Price1.ToString(clsUtil.FMT_AMOUNT),
                                                        sid.SellingDiscount1));
                }
                else
                {
                    ChildNode.SetValue(eCol.SellingPrice_1.ToString(), Price1.ToString(clsUtil.FMT_AMOUNT));
                }

                //update parent QTY
                QTY_OnHand1 = clsUtil.ParseInt32(ChildNode.ParentNode.GetValue(eCol.OnHand_1.ToString()).ToString());
                ChildNode.ParentNode.SetValue(eCol.OnHand_1.ToString(), QTY_OnHand1 + sid.QTY_OnHand1);
            }

            //show No Stock Items
            if (Condition != "")
            {
                Condition = clsUtil.GenerateSQLCondition("Name", txtSearch.Text, " ");
                if(selectedWarehouse != null)
                    Condition += "I.QTYOnHand1=0";
                else
                    Condition += "and I.QTYOnHand1=0";
            }
            else 
            {
                Condition = "I.QTYOnHand1=0";
            }

           
            IList<Items> lst2 = ItemDao.getAllByCondition(Condition);
            foreach (Items item in lst2)
            {
                ParentNode = treeItems.AppendNode(null, null);
                ParentNode.SetValue(eCol.Code.ToString(), item.Code);
                ParentNode.SetValue(eCol.ItemName.ToString(), item.Name);
                ParentNode.SetValue(eCol.OnHand_1.ToString(), 0);
                ParentNode.SetValue(eCol.OnHand_2.ToString(), 0);
            }

            //show/hide selling price
            Settings s = settingsDao.GetSetting(Settings.eSettings.ShowSellingPrice.ToString());
            bool bShow = true;
            if (s != null)
            {
                if (s.Value == "0")
                    bShow = false;
            }
            treeItems.Columns[eCol.SellingPrice_1.ToString()].Visible = bShow;
            //treeItems.Columns[eCol.SellingPrice_2.ToString()].Visible = bShow;

            treeItems.EndUnboundLoad();

            if (clsUtil.GetLoggedInUser().UserType != Users.eUserType.Admin)
            {
                btnLockItem.Visible = false;
                btnUnLockItem.Visible = false;
                btnChangePrice.Visible = false;
            }
        }

        private void LoadWarehouse()
        {
            cboWarehouse.Properties.Items.Add("ALL");
            IList<Warehouse> lstWH = WHDao.getAllRecords();

            foreach (Warehouse W in lstWH)
            {
                cboWarehouse.Properties.Items.Add(W);
            }
            cboWarehouse.SelectedIndex = 0;
        }

        private void ctlViewInventory_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
            LoadWarehouse();
            m_bIsLoading = false;
        }

        private void btnLockItem_Click(object sender, EventArgs e)
        {
            TreeListNode node = treeItems.FocusedNode;
            if (node != null)
            {
                if (node.ParentNode == null)
                {
                    //parent node, set all stockin
                    StockInDetails sid = (StockInDetails)node.GetValue(eCol.ItemObject.ToString());
                    if (sid != null)
                    {
                        IList<StockInDetails> lst = new List<StockInDetails>();
                        foreach (TreeListNode child in node.Nodes)
                        {
                            sid = (StockInDetails)child.GetValue(eCol.ItemObject.ToString());
                            if (sid.Status != (int)StockInDetails.eStatus.Locked)
                            {
                                lst.Add(sid);
                            }
                        }

                        if (lst.Count > 0)
                        {
                            try
                            {
                                StockInDetailsDao.LockItem(lst, (int)StockInDetails.eStatus.Locked);

                                //update icons
                                treeItems.BeginUnboundLoad();
                                foreach (TreeListNode child in node.Nodes)
                                {
                                    //child.StateImageIndex = 1;
                                    child.SetValue("LockIcon", "L");
                                    sid = (StockInDetails)child.GetValue(eCol.ItemObject.ToString());
                                    if (sid.Status != (int)StockInDetails.eStatus.Locked)
                                        sid.Status = (int)StockInDetails.eStatus.Locked;
                                }
                                treeItems.EndUnboundLoad();
                            }
                            catch (Exception ex)
                            {
                                clsUtil.ShowMessageError("Error: " + ex.Message, "Lock Item");
                            }
                        }
                    }
                }
                else
                {
                    StockInDetails sid = (StockInDetails)node.GetValue(eCol.ItemObject.ToString());
                    if (sid != null)
                    {
                        try
                        {
                            StockInDetailsDao.LockItem(sid, (int)StockInDetails.eStatus.Locked);
                            node.SetValue("LockIcon", "L");
                            //node.StateImageIndex = 1;
                        }
                        catch (Exception ex)
                        {
                            clsUtil.ShowMessageError("Error: " + ex.Message, "Lock Item");
                        }
                    }
                }
            }
        }

        private void btnUnLockItem_Click(object sender, EventArgs e)
        {
            TreeListNode node = treeItems.FocusedNode;
            if (node != null)
            {
                if (node.ParentNode == null)
                {
                    //parent node, set all stockin
                    StockInDetails sid = (StockInDetails)node.GetValue(eCol.ItemObject.ToString());
                    if (sid != null)
                    {
                        IList<StockInDetails> lst = new List<StockInDetails>();
                        foreach (TreeListNode child in node.Nodes)
                        {
                            sid = (StockInDetails)child.GetValue(eCol.ItemObject.ToString());
                            if (sid.Status != (int)StockInDetails.eStatus.Unlocked)
                            {
                                lst.Add(sid);
                            }
                        }

                        if (lst.Count > 0)
                        {
                            try
                            {
                                StockInDetailsDao.LockItem(lst, (int)StockInDetails.eStatus.Unlocked);

                                //update icons
                                treeItems.BeginUnboundLoad();
                                foreach (TreeListNode child in node.Nodes)
                                {
                                    //child.StateImageIndex = -1;
                                    child.SetValue("LockIcon", "");
                                    sid = (StockInDetails)child.GetValue(eCol.ItemObject.ToString());
                                    if (sid.Status != (int)StockInDetails.eStatus.Unlocked)
                                        sid.Status = (int)StockInDetails.eStatus.Unlocked;
                                }
                                treeItems.EndUnboundLoad();
                            }
                            catch (Exception ex)
                            {
                                clsUtil.ShowMessageError("Error: " + ex.Message, "Lock Item");
                            }
                        }
                    }
                }
                else
                {
                    StockInDetails sid = (StockInDetails)node.GetValue(eCol.ItemObject.ToString());
                    if (sid != null)
                    {
                        try
                        {
                            StockInDetailsDao.LockItem(sid, (int)StockInDetails.eStatus.Unlocked);
                            node.SetValue("LockIcon", "");
                            //node.StateImageIndex = -1;
                        }
                        catch (Exception ex)
                        {
                            clsUtil.ShowMessageError("Error: " + ex.Message, "Lock Item");
                        }
                    }
                }
            }
        }

        private void treeItems_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (e.Node.ParentNode == null && !e.Node.HasChildren)
            {
                e.Appearance.ForeColor = System.Drawing.Color.Red;
                //e.Appearance.BorderColor = System.Drawing.Color.Black;
                e.Appearance.Options.UseBorderColor = true;
            }
            else if (e.Node.ParentNode != null)
            {
                StockInDetails sid = (StockInDetails)e.Node.GetValue(eCol.ItemObject.ToString());
                if (!sid.HasSellingPrice() || (sid.QTY_OnHand1 == 0 && sid.QTY_OnHand2 == 0))
                {
                    e.Appearance.ForeColor = System.Drawing.Color.Red;
                    //e.Appearance.BorderColor = System.Drawing.Color.Black;
                    e.Appearance.Options.UseBorderColor = true;
                }
            }

            ((TreeList)sender).Painter.DefaultPaintHelper.DrawNodeCell(e);
            e.Handled = true;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.SelectAll();
        }

        private void btnChangePrice_Click(object sender, EventArgs e)
        {
            TreeListNode node = treeItems.FocusedNode;
            if (node != null)
            {
                TreeListNode ParentNode = null;
                StockInDetails sid = (StockInDetails)node.GetValue(eCol.ItemObject.ToString());
                try
                {
                    if (sid != null)
                    {
                        ctlNoPriceItemSetPrice ctl = new ctlNoPriceItemSetPrice();
                        frmGenericPopup frm = new frmGenericPopup();
                        IList<StockInDetails> lst = new List<StockInDetails>();

                        //parent node, set all stockin
                        if (node.ParentNode == null)
                        {
                            ParentNode = node;
                            foreach (TreeListNode child in node.Nodes)
                            {
                                sid = (StockInDetails)child.GetValue(eCol.ItemObject.ToString());
                                lst.Add(sid);
                            }
                        }
                        else
                        {
                            ParentNode = node.ParentNode;
                            lst.Add(sid);
                        }

                        if (lst.Count > 0)
                        {
                            ctl.WireItem = sid.item.IsWire;
                            ctl.m_lstItems = lst;
                            frm.Text = "Change Item Price";
                            frm.ShowCtl(ctl);
                            if (!ctl.Canceled)
                            {
                                //update display
                                foreach (TreeListNode child in ParentNode.Nodes)
                                {
                                    sid = (StockInDetails)child.GetValue(eCol.ItemObject.ToString());
                                    foreach (StockInDetails sid2 in ctl.m_lstItems)
                                    {
                                        if (sid.ID == sid2.ID)
                                        {
                                            if (sid.SellingPrice1 != 0)
                                                child.SetValue(eCol.SellingPrice_1.ToString(),
                                                               sid.SellingPrice1.ToString(clsUtil.FMT_AMOUNT));
                                            else
                                                child.SetValue(eCol.SellingPrice_1.ToString(),
                                                               string.Format("{0}\n[@{1}]",
                                                                             clsUtil.DiscountAmt(sid.Price1, sid.SellingDiscount1).
                                                                                ToString(clsUtil.FMT_AMOUNT), sid.SellingDiscount1));
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                //catch
                catch (Exception ex)
                {
                    clsUtil.ShowMessageError(ex.Message);
                }
            }
        }

        private void treeItems_Click(object sender, EventArgs e)
        {
            TreeListHitInfo info = treeItems.CalcHitInfo(treeItems.PointToClient(MousePosition));
            if (info.HitInfoType == HitInfoType.Cell)
            {
                if (info.Column.FieldName == eCol.StockInID.ToString())
                {
                    //check if there is stock id
                    if (info.Node.GetValue(eCol.StockInID.ToString()) != null &&
                        info.Node.GetValue(eCol.StockInID.ToString()).ToString() != "")
                    {
                        StockInDetails sid = (StockInDetails)info.Node.GetValue(eCol.ItemObject.ToString());
                        ctlStockIn ctl = new ctlStockIn();

                        ctl.PreviousCtl = this;
                        ctl.stockin = sid.stockin;
                        if (sid.stockin.damagedmissing != null)
                            ctl.m_DMItem = sid.stockin.damagedmissing;
                        clsUtil.getMainForm().LoadCtl(ctl, false, "View Stock In", "", false);
                    }
                }
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSearch.Text.Trim() != "")
                    btnSearch.PerformClick();
            }
        }

        private void cboWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_bIsLoading)
                return;

            btnSearch.PerformClick();
        }
    }
}