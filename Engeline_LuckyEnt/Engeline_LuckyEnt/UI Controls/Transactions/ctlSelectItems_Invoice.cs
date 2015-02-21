#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Engeline_LuckyEnt.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
   public partial class ctlSelectItems_Invoice : UserControl
   {
      private StockInDetailsDao StockInDetailsDao = new StockInDetailsDao();
      private ItemDao ItemDao = new ItemDao();
      private BundledItemDao BundledItemDao = new BundledItemDao();
      private TradingItemDao TradeItemDao = new TradingItemDao();
      private FabricatedItemDao FabItemDao = new FabricatedItemDao();
      private WarehouseDao WHDao = new WarehouseDao();

      public ctlSalesInvoice ParentCtl { get; set; }
      public bool m_bIsLoanedItems = false;

      public bool Canceled { get; set; }

      private enum eCol
      {
         ItemName,
         StockIn_ID,
         OnHand1,
         QTY1_InInvoice,
         OnHand2,
         QTY2_InInvoice,
         ItemObject,
         WireBreakdown
      }

      private enum eColBundle
      {
         Name,
         Description,
         Cost,
         Stocks,
         ItemObject,
         QTY_InInvoice,
         StockInDetails
      }

      public ctlSelectItems_Invoice()
      {
         InitializeComponent();
      }

      private void btnSearch_Click(object sender, EventArgs e)
      {

          string Condition = "";
          //normal items
          //Condition = clsUtil.GenerateSQLCondition("sid.item.Name", txtSearch.Text, " ");
          if (txtSearch.Text.Trim() != "")
          {
              Condition = clsUtil.GenerateFilterCondition(txtSearch.Text);
              Condition = string.Format("sid.item.Name like '{0}' or sid.item.Description like '{0}'", Condition);
          }
          Warehouse W = (Warehouse)cboWarehouse.SelectedItem;
          SearchNormalItems(Condition, W);

          if (ParentCtl.m_SalesInvoice.details.Count > 0)
          {
              foreach (SalesInvoiceDetails sivd in ParentCtl.m_SalesInvoice.details)
              {
                  UpdateDisplayNormal(sivd);
              }
          }
      }

      private void SearchNormalItems(string Condition, Warehouse W)
      {
         //IList<StockInDetails> lst = StockInDetailsDao.GetAvailableStocks(Condition, true, false, false,chkExcludeNoStockItems.Checked);
          IList<StockInDetails> lst = StockInDetailsDao.GetAvailableStocks(Condition, W);

         treeItems.Nodes.Clear();
         int ItemID = 0;
         TreeListNode ParentNode = null, ChildNode = null, ChildNode2 = null, ParentWireNode = null;
         int selIndex = -1;
         Warehouse selWarehouse = null;
         string msg = "";

         treeItems.BeginUnboundLoad();
         if (lst.Count <= 0)
         {
             //IList<Warehouse> lstWarehouse = WHDao.getAllRecords();
             int iIndex =0;
             foreach (Warehouse wrehouse in cboWarehouse.Properties.Items)
             {
                 if (wrehouse.ID != W.ID)
                 {
                     lst = StockInDetailsDao.GetAvailableStocks(Condition, wrehouse);
                     if (lst.Count > 0)
                     {
                         selIndex = iIndex;
                         selWarehouse = wrehouse;
                         break;
                     }
                 }
                 iIndex +=1;
             }          
             
             if (txtSearch.Text.Trim() != "")
             {
                 msg = string.Format("Did not find any item name or description '{0}', with Stocks in Warehouse: {1} ",
                     txtSearch.Text.Trim(), cboWarehouse.SelectedItem.ToString());

                 if (lst.Count <= 0 && selIndex < 0)
                 {
                     msg += string.Format("\n\nDid not also find any Warehouse with these item that has stocks!");
                 }
                 else
                 {
                     msg += string.Format("\n\nAuto Selected Next Warehouse: {0} ,with stocks for these item.", selWarehouse.ID);
                 }
             }
             else
             {
                 msg = string.Format("Did not find any item with Stocks in Warehouse: {0} ",
                     cboWarehouse.SelectedItem.ToString());

                 if (lst.Count <= 0 && selIndex < 0)
                 {
                     msg += string.Format("\n\nDid not find any Warehouse with stocks!");
                 }
                 else
                 {
                     msg += string.Format("\n\nAuto Selected Next Warehouse: {0} with stocks.", selWarehouse.ID);
                 }
             }

             clsUtil.ShowMessageInformation(msg, "Select Item");

         }

         Int32 QTY_OnHand1 = 0;
         foreach (StockInDetails sid in lst)
         {
             if (ItemID != sid.item.ID)
             {
                 //new item to be displayed
                 ItemID = sid.item.ID;
                 ParentNode = treeItems.AppendNode(null, null);
                 ParentNode.SetValue(eCol.ItemName.ToString(),
                                     string.Format("{0}\n{1}", sid.item.Name, sid.item.Description));
                 ParentNode.SetValue(eCol.ItemObject.ToString(), sid);
                 ParentNode.SetValue(eCol.OnHand1.ToString(),0);
             }


             ChildNode = treeItems.AppendNode(null, ParentNode);
             ChildNode.SetValue(eCol.StockIn_ID.ToString(), sid.stockin.ID.ToString("000000"));

             //save StockInDetails to node
             ChildNode.SetValue(eCol.ItemObject.ToString(), sid);
             ChildNode.SetValue(eCol.OnHand1.ToString(), sid.QTY_OnHand1);

             //update parent total qty on hand
             QTY_OnHand1 = clsUtil.ParseInt32(ChildNode.ParentNode.GetValue(eCol.OnHand1.ToString()).ToString());
             ChildNode.ParentNode.SetValue(eCol.OnHand1.ToString(), QTY_OnHand1 + sid.QTY_OnHand1);

             //set icon for Locked items
             if (sid.Status == (int)StockInDetails.eStatus.Locked)
                 ChildNode.StateImageIndex = 0;

         }

         treeItems.EndUnboundLoad();
         CheckSelectedNode(treeItems.FocusedNode);
         if (selIndex >= 0)
             cboWarehouse.SelectedIndex = selIndex;
      }

      private TreeListNode GetWireParentNode(TreeListNode node, Int32 MetersPerRoll)
      {
         foreach (TreeListNode n in node.Nodes)
         {
            StockInDetails sid = (StockInDetails) n.GetValue(eCol.ItemObject.ToString());
            if (sid.QTY2 == MetersPerRoll)
               return n;
         }
         return null;
      }

      private void SearchFabricatedItems(string Condition)
      {
         IList<StockInDetails> lst = StockInDetailsDao.GetAvailableStocks(Condition, false, true, false);

         treeItems.Nodes.Clear();
         int ItemID = 0;
         TreeListNode ParentNode = null, ChildNode = null;

         treeItems.BeginUnboundLoad();
         foreach (StockInDetails sid in lst)
         {
            if (ItemID != sid.fabricateditem.ID)
            {
               ItemID = sid.fabricateditem.ID;
               ParentNode = treeItems.AppendNode(null, null);
               ParentNode.SetValue(eCol.ItemName.ToString(),
                                   string.Format("{0}\n{1}", sid.fabricateditem.Name, sid.fabricateditem.Description));
               ParentNode.SetValue(eCol.ItemObject.ToString(), sid);
               ParentNode.SetValue(eCol.OnHand1.ToString(), 0);
            }

            ChildNode = treeItems.AppendNode(null, ParentNode);
            ChildNode.SetValue(eCol.StockIn_ID.ToString(), sid.stockin.ID.ToString("000000"));

            //save StockInDetails to node
            ChildNode.SetValue(eCol.ItemObject.ToString(), sid);

            //set icon for Locked items
            if (sid.Status == (int) StockInDetails.eStatus.Locked)
               ChildNode.StateImageIndex = 0;
            ChildNode.SetValue(eCol.OnHand1.ToString(), sid.QTY_OnHand1);

            //update parent node
            Int32 OnHand = Convert.ToInt32(ParentNode.GetValue(eCol.OnHand1.ToString()).ToString());
            OnHand += sid.QTY_OnHand1;
            ParentNode.SetValue(eCol.OnHand1.ToString(), OnHand);
         }
         treeItems.EndUnboundLoad();
         CheckSelectedNode(treeItems.FocusedNode);
      }

      private void SearchTradingItems(string Condition)
      {
         IList<StockInDetails> lst = StockInDetailsDao.GetAvailableStocks(Condition, false, false, true);

         treeItems.Nodes.Clear();
         int ItemID = 0;
         TreeListNode ParentNode = null, ChildNode = null;

         treeItems.BeginUnboundLoad();
         foreach (StockInDetails sid in lst)
         {
            if (ItemID != sid.tradingitem.ID)
            {
               ItemID = sid.tradingitem.ID;
               ParentNode = treeItems.AppendNode(null, null);
               ParentNode.SetValue(eCol.ItemName.ToString(),
                                   string.Format("{0}\n{1}", sid.tradingitem.Name, sid.tradingitem.Description));
               ParentNode.SetValue(eCol.ItemObject.ToString(), sid);
               ParentNode.SetValue(eCol.OnHand1.ToString(), 0);
            }

            ChildNode = treeItems.AppendNode(null, ParentNode);
            ChildNode.SetValue(eCol.StockIn_ID.ToString(), sid.stockin.ID.ToString("000000"));

            //save StockInDetails to node
            ChildNode.SetValue(eCol.ItemObject.ToString(), sid);

            //set icon for Locked items
            if (sid.Status == (int) StockInDetails.eStatus.Locked)
               ChildNode.StateImageIndex = 0;

            ChildNode.SetValue(eCol.OnHand1.ToString(), sid.QTY_OnHand1);

            //update parent node
            Int32 OnHand = Convert.ToInt32(ParentNode.GetValue(eCol.OnHand1.ToString()).ToString());
            OnHand += sid.QTY_OnHand1;
            ParentNode.SetValue(eCol.OnHand1.ToString(), OnHand);
         }
         treeItems.EndUnboundLoad();
         CheckSelectedNode(treeItems.FocusedNode);
      }

      private void SearchBundledItems(string Condition)
      {
         IList<BundledItem> lst = BundledItemDao.getAllRecordsByCriteria(Condition);

         treeBundle.Nodes.Clear();
         TreeListNode ParentNode = null;
         treeBundle.BeginUnboundLoad();
         foreach (BundledItem bi in lst)
         {
            ParentNode = treeBundle.AppendNode(null, null);
            ParentNode.SetValue(eColBundle.Name.ToString(), bi.Name);
            ParentNode.SetValue(eColBundle.Description.ToString(), bi.Description);
            ParentNode.SetValue(eColBundle.Cost.ToString(), bi.UnitPrice);
            ParentNode.SetValue(eColBundle.ItemObject.ToString(), bi);
            ParentNode.HasChildren = true;
         }
         treeBundle.EndUnboundLoad();
         CheckSelectedBundledItem();
      }

      private void treeItems_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
      {
         CheckSelectedNode(e.Node);
      }

      private void CheckSelectedNode(TreeListNode node)
      {
         if (node != null)
         {
            if (radioItems.SelectedIndex == 1)
            {
               //bundled items
               lblPrice2.Visible = false;
               txtPrice2.Visible = false;
               txtPrice2.Text = "0.00";
               lblQTY2.Visible = false;
               txtQTY2.Visible = false;
               txtQTY2.Text = "0";
            }
            else
            {
               //normal / Fab items / trade items
               Int32 QTY_OnHand1, QTY_OnHand2, QTY_OnInvoice1, QTY_OnInvoice2, QTY_Avail1, QTY_Avail2;
               StockInDetails sid = (StockInDetails) node.GetValue("ItemObject");
               if (sid != null)
               {
                  QTY_OnHand1 = sid.QTY_OnHand1;
                  QTY_OnHand2 = sid.QTY_OnHand2;
                  QTY_OnInvoice1 = clsUtil.ParseInt32(clsUtil.ParseString(node.GetValue(eCol.QTY1_InInvoice.ToString())));
                  QTY_OnInvoice2 = clsUtil.ParseInt32(clsUtil.ParseString(node.GetValue(eCol.QTY2_InInvoice.ToString())));
                  QTY_Avail1 = QTY_OnHand1 + QTY_OnInvoice1;
                  QTY_Avail2 = QTY_OnHand2 + QTY_OnInvoice2;

                  if (sid.item != null)
                  {
                     
                    //if (sid.Price1 != 0)
                    //{
                    //    //show price set for item during item registration
                    //    txtPrice1.Text = sid.Price1.ToString("#,##0.00");
                    //}
                    //else
                    //{
                    //    //show selling price
                    //    if (sid.SellingPrice1 != 0)
                    //        txtPrice1.Text = sid.SellingPrice1.ToString("#,##0.00");
                    //    else
                    //        txtPrice1.Text = clsUtil.DiscountAmt(sid.Price1, sid.SellingDiscount1).ToString("#,##0.00");
                    //}

                      if (sid.SellingPrice1 != 0)
                      {
                          txtPrice1.Text = sid.SellingPrice1.ToString(clsUtil.FMT_AMOUNT);
                      }
                      else if (sid.SellingDiscount1 != "" && sid.SellingDiscount1 != null)
                      {
                          txtPrice1.Text = clsUtil.DiscountAmt(sid.Price1, sid.SellingDiscount1).ToString(clsUtil.FMT_AMOUNT);
                      }
                      else
                      {
                          txtPrice1.Text = sid.Price1.ToString(clsUtil.FMT_AMOUNT);
                      }

                    txtQTY1.Text = "1";
                    btnAddItem.Enabled = true;
                  }
                  else
                  {
                     if (sid.SellingPrice1 != 0)
                        txtPrice1.Text = sid.SellingPrice1.ToString("#,##0.00");
                     else
                        txtPrice1.Text = clsUtil.DiscountAmt(sid.Price1, sid.SellingDiscount1).ToString("#,##0.00");

                     lblQTY1.Text = "QTY";
                     txtQTY1.Text = "1";
                     btnAddItem.Enabled = true;
                  }
               }
               else
               {
                  //selected item has no StockIn
                  ResetDetails();
                  btnAddItem.Enabled = false;
               }
            }
         }
         else
         {
            //selected item has no StockIn
            ResetDetails();
            btnAddItem.Enabled = false;
         }
      }

      private void ResetDetails()
      {
         lblPrice1.Text = "Price";
         lblPrice2.Text = "Price2";
         txtPrice1.Text = "0.00";
         txtPrice2.Text = "0.00";
         lblQTY1.Text = "QTY";
         lblQTY2.Text = "QTY2";
         txtQTY1.Text = "0";
         txtQTY2.Text = "0";
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         Canceled = true;
         this.ParentForm.Close();
      }

      private void treeItems_AfterExpand(object sender, NodeEventArgs e)
      {
         //e.Node.ExpandAll();
      }

      private void pnlHeader_Paint(object sender, PaintEventArgs e)
      {
      }

      private void radioItems_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (radioItems.SelectedIndex == 1)
         {
            //bundled items
            treeItems.Visible = false;
            treeItems.Dock = DockStyle.None;
            treeBundle.Nodes.Clear();
            treeBundle.Dock = DockStyle.Fill;
            treeBundle.Visible = true;

            lblPrice2.Visible = false;
            txtPrice2.Visible = false;
            lblQTY2.Visible = false;
            txtQTY2.Visible = false;

            lblPrice1.Text = "Price";
            lblQTY1.Text = "QTY";
         }
         else
         {
            treeBundle.Visible = false;
            treeBundle.Dock = DockStyle.None;
            treeItems.Nodes.Clear();
            treeItems.Dock = DockStyle.Fill;
            treeItems.Visible = true;
         }
         txtSearch.Text = "";
         txtSearch.Focus();
      }

      private void txtSearch_Enter(object sender, EventArgs e)
      {
         txtSearch.SelectAll();
      }

      private void treeItems_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
      {
         if (e.Node.ParentNode == null && !e.Node.HasChildren)
         {
            e.Appearance.ForeColor = System.Drawing.Color.Red;
            e.Appearance.BorderColor = System.Drawing.Color.Black;
            e.Appearance.Options.UseBorderColor = true;
         }
         else if (e.Node.ParentNode != null)
         {
            Int32 StockInID = GetStockInID(e.Node);
            if (StockInID > 0)
            {
               //this node has StockIn ID displayed
               StockInDetails sid = (StockInDetails) e.Node.GetValue(eCol.ItemObject.ToString());
               if (sid.SellingPrice1 == 0 && sid.SellingPrice2 == 0 &&
                   sid.SellingDiscount1 == "" & sid.SellingDiscount2 == "")
               {
                  e.Appearance.ForeColor = System.Drawing.Color.Red;
                  e.Appearance.BorderColor = System.Drawing.Color.Black;
                  e.Appearance.Options.UseBorderColor = true;
               }
            }
         }

         ((TreeList) sender).Painter.DefaultPaintHelper.DrawNodeCell(e);
         e.Handled = true;
      }

      private void ctlSelectItems_Invoice_Load(object sender, EventArgs e)
      {
         radioItems_SelectedIndexChanged(null, null);
         HideUnusedItems();
         LoadWarehouseList();
         //treeItems.Columns[eCol.StockIn_ID.ToString()].SortOrder = SortOrder.Ascending;
         //treeItems.Columns[eCol.StockIn_ID.ToString()].SortIndex = 0;
      }

      private void LoadWarehouseList()
      {
          cboWarehouse.Properties.Items.Clear();
          int selIndex = -1, iIndex=0;
          WarehouseDao whDao = new WarehouseDao();
          string WHselected = whDao.GetWarehouseCode();
          IList<Warehouse> lstWarehouse = whDao.getAllRecords();
          foreach (Warehouse W in lstWarehouse)
          {
              cboWarehouse.Properties.Items.Add(W);
              if (WHselected == W.ID)
                  selIndex = iIndex;

              iIndex += 1;
          }

          cboWarehouse.SelectedIndex = selIndex;
      }

      private void treeBundle_BeforeExpand(object sender, BeforeExpandEventArgs e)
      {
         CheckBundledItemStocks(e.Node);
      }

      private void CheckBundledItemStocks(TreeListNode node)
      {
         BundledItem bi = (BundledItem) node.GetValue(eColBundle.ItemObject.ToString());
         if (bi != null)
         {
            treeBundle.BeginUnboundLoad();
            node.Nodes.Clear();

            TreeListNode ChildNode;
            Int32 QTY = 0, QTY_InInvoice = 0;
            foreach (BundledItemDetails bid in bi.details)
            {
               ChildNode = treeBundle.AppendNode(null, node);
               if (bid.item != null)
               {
                  ChildNode.SetValue(eColBundle.Name.ToString(),
                                     string.Format("{0} X {1} ", bid.QTY, bid.UnitPrice.ToString("#,##0.00"),
                                                   bid.item.Name));
                  ChildNode.SetValue(eColBundle.Description.ToString(), bid.item.Description);
                  ChildNode.SetValue(eColBundle.Cost.ToString(), bid.QTY*bid.UnitPrice);
                  ChildNode.SetValue(eColBundle.ItemObject.ToString(), bid);

                  //get available stocks
                  IList<StockInDetails> lst = StockInDetailsDao.GetAvailableStocks(bid.item.ID, true, false, false);
                  QTY = 0;
                  foreach (StockInDetails sid in lst)
                  {
                     if (sid.Status != (int) StockInDetails.eStatus.Locked)
                        QTY += sid.QTY_OnHand1;
                  }
                  ChildNode.SetValue(eColBundle.Stocks.ToString(), QTY);

                  //show QTY already added to invoice
                  QTY_InInvoice = 0;
                  foreach (SalesInvoiceDetails sivd in ParentCtl.m_SalesInvoice.details)
                  {
                     if (sivd.bundleditem != null && sivd.bundleditem.ID == bi.ID)
                     {
                        foreach (BundledItemDetails bid2 in sivd.bundleditem.details)
                        {
                           if (bid2.item != null && bid2.item.ID == bid.item.ID)
                           {
                              QTY_InInvoice -= (sivd.QTY1*bid2.QTY);
                              //stop loop, it is assumed that no duplicate item exists in a bundled item
                              break;
                           }
                        }
                     }
                     else if (sivd.item != null)
                     {
                        //added normal items QTY
                        if (sivd.item.ID == bid.item.ID)
                        {
                           QTY_InInvoice -= (sivd.QTY1);
                        }
                     }
                  }
                  ChildNode.SetValue(eColBundle.QTY_InInvoice.ToString(), QTY_InInvoice);

                  if (QTY <= 0 || bid.QTY > QTY)
                  {
                     node.SetValue(eColBundle.Stocks.ToString(), "Not Available");
                  }
               }
               else if (bid.FabItem != null)
               {
                  ChildNode.SetValue(eColBundle.Name.ToString(),
                                     string.Format("{0} X {1} ", bid.QTY, bid.UnitPrice.ToString("#,##0.00"),
                                                   bid.FabItem.Name));
                  ChildNode.SetValue(eColBundle.Description.ToString(), bid.FabItem.Description);
                  ChildNode.SetValue(eColBundle.Cost.ToString(), bid.QTY*bid.UnitPrice);
                  ChildNode.SetValue(eColBundle.ItemObject.ToString(), bid);

                  //get available stocks
                  IList<StockInDetails> lst = StockInDetailsDao.GetAvailableStocks(bid.FabItem.ID, false, true, false);
                  QTY = 0;
                  foreach (StockInDetails sid in lst)
                  {
                     if (sid.Status != (int) StockInDetails.eStatus.Locked)
                        QTY += sid.QTY_OnHand1;
                  }
                  ChildNode.SetValue(eColBundle.Stocks.ToString(), QTY);

                  //show QTY already added to invoice
                  QTY_InInvoice = 0;
                  foreach (SalesInvoiceDetails sivd in ParentCtl.m_SalesInvoice.details)
                  {
                     if (sivd.bundleditem != null && sivd.bundleditem.ID == bi.ID)
                     {
                        foreach (BundledItemDetails bid2 in sivd.bundleditem.details)
                        {
                           if (bid2.FabItem != null && bid2.FabItem.ID == bid.FabItem.ID)
                           {
                              QTY_InInvoice -= (sivd.QTY1*bid2.QTY);
                              //stop loop, it is assumed that no duplicate item exists in a bundled item
                              break;
                           }
                        }
                     }
                     else if (sivd.fabitem != null && sivd.fabitem.ID == bid.FabItem.ID)
                     {
                        QTY_InInvoice -= (sivd.QTY1);
                     }
                  }
                  ChildNode.SetValue(eColBundle.QTY_InInvoice.ToString(), QTY_InInvoice);

                  if (QTY <= 0 || bid.QTY > QTY)
                  {
                     node.SetValue(eColBundle.Stocks.ToString(), "Not Available");
                  }
               }
            }
            //node.Expanded = true;
            treeBundle.EndUnboundLoad();
         }
      }

      private void btnAddItem_Click(object sender, EventArgs e)
      {
          //Normal Items
          AddNormaItem();
          txtDiscount.Text = "";
          treeItems.Focus();
      }

      private void AddNormaItem()
      {
         TreeListNode ParentNode, SelectedNode;
         SelectedNode = treeItems.FocusedNode;

         if (SelectedNode == null)
         {
            clsUtil.ShowMessageExclamation("Please select valid item!", "Add Item");
            return;
         }

         if (SelectedNode.ParentNode != null)
            ParentNode = SelectedNode.ParentNode;
         else
            ParentNode = SelectedNode;

         if (ValidateNormalItem(SelectedNode))
         {
            Int32 QTY1, QTY2;
            double Price1, Price2;

            QTY1 = (Int32) clsUtil.CheckValue(txtQTY1);
            QTY2 = (Int32) clsUtil.CheckValue(txtQTY2);
            Price1 = clsUtil.CheckValue(txtPrice1);
            Price2 = clsUtil.CheckValue(txtPrice2);

            StockInDetails sid = (StockInDetails) SelectedNode.GetValue(eCol.ItemObject.ToString());
            SalesInvoiceDetails sivd = new SalesInvoiceDetails();
            sivd.stockindetails = new List<SalesInvoiceDetails_StockIn>();

            sivd.item = sid.item;
            sivd.QTY1 = QTY1;
            sivd.QTY2 = QTY2;
            sivd.AgentPrice1 = Price1;
            sivd.AgentPrice2 = Price2;
            sivd.AgentDiscount = txtDiscount.Text;
            sivd.CustomerPrice1 = sivd.AgentPrice1;
            sivd.CustomerPrice2 = sivd.AgentPrice2;
            sivd.CustomerDiscount = sivd.AgentDiscount;

            // //check if item needs PO
            //if (sid.WarehouseStockin != WHDao.GetWarehouseCode())
            //{
            //    sivd.b_PO = true;
            //    sivd.whPO = WHDao.GetWHById(sid.WarehouseStockin);
            //}
            //else
            //{
            //    sivd.b_PO = false;
            //    sivd.whPO = null;
            //    //string wrehouse = WHDao.GetWarehouseCode();
            //    //sivd.whStockin = WHDao.GetWHById(wrehouse);
            //}

            string temp = clsUtil.ParseString(SelectedNode.GetValue(eCol.StockIn_ID.ToString()));
            Int32 StockInID = clsUtil.ParseInt32(temp);

            //get stockin details
            Int32 QTY_OnHand1, QTY_OnHand2, QTY_InInvoice1, QTY_InInvoice2, QTY_Avail1, QTY_Avail2;

               //normal item
               if (StockInID > 0)
               {
                  //only 1 StockInID affected
                  SalesInvoiceDetails_StockIn siv_si = new SalesInvoiceDetails_StockIn();
                  siv_si.QTY1 = QTY1;
                  siv_si.QTY2 = sid.QTY2;
                  siv_si.SellingDiscount1 = sid.SellingDiscount1;
                  siv_si.SellingPrice1 = sid.SellingPrice1;
                  siv_si.stockindetails = sid;
                  sivd.stockindetails.Add(siv_si);

                  ParentCtl.AddItem(sivd);
                  UpdateDisplayNormal(sivd);
               }
               else
               {
                  //Auto-select sid
                  Int32 QTY_Needed = QTY1;
                  foreach (TreeListNode node in SelectedNode.Nodes)
                  {
                     StockInDetails sid2 = (StockInDetails) node.GetValue(eCol.ItemObject.ToString());

                     if (sid2.Status == (int) StockInDetails.eStatus.Locked)
                        continue;

                     if (!sid2.HasSellingPrice())
                        continue;

                     QTY_OnHand1 = sid2.QTY_OnHand1;
                     QTY_InInvoice1 = GetQTYInInvoice(node, eCol.QTY1_InInvoice.ToString());
                     QTY_Avail1 = QTY_OnHand1 + QTY_InInvoice1;

                     SalesInvoiceDetails_StockIn siv_si = new SalesInvoiceDetails_StockIn();
                     siv_si.QTY2 = sid2.QTY2;
                     siv_si.SellingDiscount1 = sid2.SellingDiscount1;
                     siv_si.SellingPrice1 = sid2.SellingPrice1;
                     siv_si.stockindetails = sid2;

                     if (QTY_Needed <= QTY_Avail1)
                     {
                        siv_si.QTY1 = QTY_Needed;
                        //update display
                        //UpdateDisplay(node, QTY_Needed, 0);
                        QTY_Needed = 0;
                     }
                     else
                     {
                        siv_si.QTY1 = QTY_Avail1;
                        //update display
                        //UpdateDisplay(node, QTY_Avail1, 0);
                        QTY_Needed -= QTY_Avail1;
                     }
                     sivd.stockindetails.Add(siv_si);

                     if (QTY_Needed == 0)
                        break;
                  }
                  if (QTY_Needed != 0)
                  {
                     clsUtil.ShowMessageExclamation(
                        "Insufficient stocks! Some of the items might be locked for selling!", "Add Item");
                     return;
                  }
                  ParentCtl.AddItem(sivd);
                  UpdateDisplayNormal(sivd);
               
            }
            CheckSelectedNode(SelectedNode);
         }
      }

      private void AddMiscItems()
      {
         TreeListNode ParentNode, SelectedNode;
         SelectedNode = treeItems.FocusedNode;

         if (SelectedNode == null)
         {
            clsUtil.ShowMessageExclamation("Please select valid item!", "Add Item");
            return;
         }

         if (SelectedNode.ParentNode != null)
            ParentNode = SelectedNode.ParentNode;
         else
            ParentNode = SelectedNode;

         if (ValidateMiscItems(SelectedNode))
         {
            Int32 QTY1 = (Int32) clsUtil.CheckValue(txtQTY1);
            double Price1 = clsUtil.CheckValue(txtPrice1);

            StockInDetails sid = (StockInDetails) SelectedNode.GetValue(eCol.ItemObject.ToString());
            SalesInvoiceDetails sivd = new SalesInvoiceDetails();
            sivd.stockindetails = new List<SalesInvoiceDetails_StockIn>();

            if (radioItems.SelectedIndex == 2)
            {
               //fab item
               sivd.fabitem = sid.fabricateditem;
            }
            else if (radioItems.SelectedIndex == 3)
            {
               //trade item
               sivd.tradeitem = sid.tradingitem;
            }

            sivd.QTY1 = QTY1;
            sivd.QTY2 = 0;
            sivd.AgentPrice1 = Price1;
            sivd.AgentPrice2 = 0;
            sivd.AgentDiscount = txtDiscount.Text;
            sivd.CustomerPrice1 = sivd.AgentPrice1;
            sivd.CustomerPrice2 = 0;
            sivd.CustomerDiscount = sivd.AgentDiscount;

            string temp = clsUtil.ParseString(SelectedNode.GetValue(eCol.StockIn_ID.ToString()));
            Int32 StockInID = clsUtil.ParseInt32(temp);

            //get stockin details
            Int32 QTY_OnHand1, QTY_InInvoice1, QTY_Avail1;
            if (StockInID > 0)
            {
               //only 1 StockInID affected
               SalesInvoiceDetails_StockIn siv_si = new SalesInvoiceDetails_StockIn();
               siv_si.QTY1 = QTY1;
               siv_si.QTY2 = 0;
               siv_si.SellingDiscount1 = sid.SellingDiscount1;
               siv_si.SellingDiscount2 = "";
               siv_si.SellingPrice1 = sid.SellingPrice1;
               siv_si.SellingPrice2 = 0;
               siv_si.stockindetails = sid;
               sivd.stockindetails.Add(siv_si);
            }
            else
            {
               //Auto-select sid
               Int32 QTY_Needed = QTY1;
               foreach (TreeListNode node in SelectedNode.Nodes)
               {
                  StockInDetails sid2 = (StockInDetails) node.GetValue(eCol.ItemObject.ToString());

                  //check if item is locked
                  if (sid2.Status == (int) StockInDetails.eStatus.Locked)
                     continue;

                  //check if item has selling price
                  if (!sid2.HasSellingPrice())
                     continue;

                  QTY_OnHand1 = sid2.QTY_OnHand1;
                  QTY_InInvoice1 = GetQTYInInvoice(node, eCol.QTY1_InInvoice.ToString());
                  QTY_Avail1 = QTY_OnHand1 + QTY_InInvoice1;

                  if (QTY_Avail1 > 0)
                  {
                     SalesInvoiceDetails_StockIn siv_si = new SalesInvoiceDetails_StockIn();
                     siv_si.QTY2 = sid2.QTY2;
                     siv_si.SellingDiscount1 = sid2.SellingDiscount1;
                     siv_si.SellingPrice1 = sid2.SellingPrice1;
                     siv_si.stockindetails = sid2;


                     if (QTY_Needed <= QTY_Avail1)
                     {
                        siv_si.QTY1 = QTY_Needed;
                        QTY_Needed = 0;
                     }
                     else
                     {
                        siv_si.QTY1 = QTY_Avail1;
                        QTY_Needed -= QTY_Avail1;
                     }
                     sivd.stockindetails.Add(siv_si);

                     if (QTY_Needed == 0)
                        break;
                  }
               }
               if (QTY_Needed != 0)
               {
                  clsUtil.ShowMessageExclamation("Insufficient stocks! Some of the items might be locked for selling!",
                                               "Add Item");
                  return;
               }
               ParentCtl.AddItem(sivd);

               treeItems.BeginUnboundLoad();
               UpdateDisplayMiscItems(sivd);
               treeItems.EndUnboundLoad();
            }
         }
      }

      private void AddBundledItem()
      {
         TreeListNode node = treeBundle.FocusedNode;
         if (node == null)
         {
            clsUtil.ShowMessageError("Please select valid item!", "Add Bundled Item");
            return;
         }

         if (node.ParentNode != null)
            node = node.ParentNode;

         if (ValidateBundledItem(node))
         {
            Int32 QTY1 = (Int32) clsUtil.CheckValue(txtQTY1);
            double Price1 = clsUtil.CheckValue(txtPrice1);

            BundledItem bi = (BundledItem) node.GetValue(eColBundle.ItemObject.ToString());
            SalesInvoiceDetails sivd = new SalesInvoiceDetails();
            sivd.stockindetails = new List<SalesInvoiceDetails_StockIn>();

            sivd.bundleditem = bi;
            sivd.QTY1 = QTY1;
            sivd.QTY2 = 0;
            sivd.AgentPrice1 = Price1;
            sivd.AgentPrice2 = 0;
            sivd.AgentDiscount = txtDiscount.Text;
            sivd.CustomerPrice1 = sivd.AgentPrice1;
            sivd.CustomerPrice2 = 0;
            sivd.CustomerDiscount = sivd.AgentDiscount;

            //get stockin details
            int QTY_Needed = 0, QTY_InInvoice = 0, QTY_Avail = 0;
            foreach (TreeListNode childnode in node.Nodes)
            {
               BundledItemDetails bid = (BundledItemDetails) childnode.GetValue(eColBundle.ItemObject.ToString());
               QTY_Needed = QTY1*bid.QTY;
               if (bid.item != null)
               {
                  //get available stocks
                  IList<StockInDetails> lst = StockInDetailsDao.GetAvailableStocks(bid.item.ID, true, false, false);
                  foreach (StockInDetails sid in lst)
                  {
                     if (sid.Status == (int) StockInDetails.eStatus.Locked)
                        continue;

                     if (!sid.HasSellingPrice())
                        continue;

                     //get total QTY already in Invoice for StockInDetails
                     QTY_InInvoice = GetStockInDetailsQTY1InInvoice(sid);
                     QTY_Avail = sid.QTY_OnHand1 - QTY_InInvoice;
                     if (QTY_Avail > 0)
                     {
                        SalesInvoiceDetails_StockIn siv_si = new SalesInvoiceDetails_StockIn();
                        siv_si.QTY2 = 0;
                        siv_si.SellingDiscount1 = sid.SellingDiscount1;
                        siv_si.SellingDiscount2 = "";
                        siv_si.SellingPrice1 = sid.SellingPrice1;
                        siv_si.SellingPrice2 = 0;
                        siv_si.stockindetails = sid;

                        if (QTY_Needed <= QTY_Avail)
                        {
                           siv_si.QTY1 = QTY_Needed;
                           QTY_Needed = 0;
                        }
                        else
                        {
                           siv_si.QTY1 = QTY_Avail;
                           QTY_Needed -= QTY_Avail;
                        }
                        sivd.stockindetails.Add(siv_si);
                     }
                     if (QTY_Needed == 0)
                        break;
                  }
                  if (QTY_Needed != 0)
                  {
                     clsUtil.ShowMessageExclamation(
                        string.Format("Unable to add item. Insufficeint stock for item '{0}'!", bid.item.Name),
                        "Add Bundled Item");
                     return;
                  }
               }
               else if (bid.FabItem != null)
               {
                  //get available stocks
                  IList<StockInDetails> lst = StockInDetailsDao.GetAvailableStocks(bid.FabItem.ID, false, true, false);
                  foreach (StockInDetails sid in lst)
                  {
                     if (sid.Status == (int) StockInDetails.eStatus.Locked)
                        continue;

                     if (!sid.HasSellingPrice())
                        continue;

                     //get total QTY already in Invoice for StockInDetails
                     QTY_InInvoice = GetStockInDetailsQTY1InInvoice(sid);
                     QTY_Avail = sid.QTY_OnHand1 - QTY_InInvoice;
                     if (QTY_Avail > 0)
                     {
                        SalesInvoiceDetails_StockIn siv_si = new SalesInvoiceDetails_StockIn();
                        siv_si.QTY2 = 0;
                        siv_si.SellingDiscount1 = sid.SellingDiscount1;
                        siv_si.SellingDiscount2 = "";
                        siv_si.SellingPrice1 = sid.SellingPrice1;
                        siv_si.SellingPrice2 = 0;
                        siv_si.stockindetails = sid;

                        if (QTY_Needed <= QTY_Avail)
                        {
                           siv_si.QTY1 = QTY_Needed;
                           QTY_Needed = 0;
                        }
                        else
                        {
                           siv_si.QTY1 = QTY_Avail;
                           QTY_Needed -= QTY_Avail;
                        }
                        sivd.stockindetails.Add(siv_si);
                     }
                     if (QTY_Needed == 0)
                        break;
                  }
                  if (QTY_Needed != 0)
                  {
                     clsUtil.ShowMessageExclamation(
                        string.Format("Unable to add item. Insufficeint stock for item '{0}'!", bid.item.Name),
                        "Add Bundled Item");
                     return;
                  }
               }
               else
               {
                  clsUtil.ShowMessageError("Invalid BundledItemDetails found!", "Add Bundled Item");
                  return;
               }
            }
            //evrything OK
            ParentCtl.AddItem(sivd);
            UpdateDisplayBundledItem(node);
         }
      }

      private Int32 GetStockInDetailsQTY1InInvoice(StockInDetails sid)
      {
         Int32 QTY = 0;
         foreach (SalesInvoiceDetails sivd in ParentCtl.m_SalesInvoice.details)
         {
            foreach (SalesInvoiceDetails_StockIn siv_si in sivd.stockindetails)
            {
               if (siv_si.stockindetails.ID == sid.ID)
               {
                  QTY += siv_si.QTY1;
               }
            }
         }
         return QTY;
      }

      private void UpdateDisplay(TreeListNode node, Int32 QTY1, Int32 QTY2)
      {
         //update display
         Int32 QTY_InInvoice1 = 0, QTY_InInvoice2 = 0;
         QTY_InInvoice1 = clsUtil.ParseInt32(clsUtil.ParseString(node.GetValue(eCol.QTY1_InInvoice.ToString())));
         node.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - QTY1);

         if (QTY2 != 0)
         {
            QTY_InInvoice2 = clsUtil.ParseInt32(clsUtil.ParseString(node.GetValue(eCol.QTY2_InInvoice.ToString())));
            node.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice2 - (QTY1*QTY2));
         }

         if (node.ParentNode != null)
         {
            QTY_InInvoice1 =
               clsUtil.ParseInt32(clsUtil.ParseString(node.ParentNode.GetValue(eCol.QTY1_InInvoice.ToString())));
            node.ParentNode.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - QTY1);

            if (QTY2 != 0)
            {
               QTY_InInvoice2 =
                  clsUtil.ParseInt32(clsUtil.ParseString(node.ParentNode.GetValue(eCol.QTY2_InInvoice.ToString())));
               node.ParentNode.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice2 - (QTY1*QTY2));
            }
         }
      }


      private bool ValidateNormalItem(TreeListNode node)
      {
         Int32 QTY1, QTY2, QTY_OnHand1, QTY_OnHand2, QTY_OnInvoice1, QTY_OnInvoice2, QTY_Available1, QTY_Available2;
         Int32 StockInID = 0;
         double Price1, Price2;

         TreeListNode ParentNode = node.ParentNode;
         StockInDetails sid = (StockInDetails) node.GetValue(eCol.ItemObject.ToString());
         StockInID = GetStockInID(node);

         if (StockInID > 0)
         {
            //selected node has displayed StockIn ID
            if (!sid.HasSellingPrice())
            {
               clsUtil.ShowMessageExclamation("Cannot sell item. No selling price yet!", "Add Item");
               return false;
            }

            //is item locked?
            if (sid.Status == (int) StockInDetails.eStatus.Locked)
            {
               clsUtil.ShowMessageExclamation("Cannot sell item. Item is locked!", "Add Item");
               return false;
            }
         }

         QTY1 = (Int32) clsUtil.CheckValue(txtQTY1);
         QTY2 = (Int32) clsUtil.CheckValue(txtQTY2);
         Price1 = clsUtil.CheckValue(txtPrice1);
         Price2 = clsUtil.CheckValue(txtPrice2);

         if (node.GetValue(eCol.QTY1_InInvoice.ToString()) == null)
            QTY_OnInvoice1 = 0;
         else
            QTY_OnInvoice1 = clsUtil.ParseInt32(node.GetValue(eCol.QTY1_InInvoice.ToString()).ToString());

         if (node.GetValue(eCol.QTY2_InInvoice.ToString()) == null)
            QTY_OnInvoice2 = 0;
         else
            QTY_OnInvoice2 = clsUtil.ParseInt32(node.GetValue(eCol.QTY2_InInvoice.ToString()).ToString());

         WireBreakdown wb = (WireBreakdown) node.GetValue(eCol.WireBreakdown.ToString());
         if (wb != null)
         {
            QTY_OnHand1 = 0;
            //QTY_OnHand2 = wb.QTY_Original;
            QTY_OnHand2 = wb.QTY_OnHand;
         }
         else
         {
            QTY_OnHand1 = 0;
            QTY_OnHand2 = 0;

            string temp = clsUtil.ParseString(node.GetValue(eCol.OnHand1.ToString()));
            if (temp != null)
            {
               if (temp.Contains("rolls") || temp.Contains("mtrs"))
               {
                  string[] tmp = temp.Split(' ');
                  QTY_OnHand1 = clsUtil.ParseInt32(tmp[0]);
               }
               else
               {
                  QTY_OnHand1 = clsUtil.ParseInt32(temp);
               }
            }

            temp = clsUtil.ParseString(node.GetValue(eCol.OnHand2.ToString()));
            if (temp != null)
            {
               if (temp.Contains("rolls") || temp.Contains("mtrs"))
               {
                  string[] tmp = temp.Split(' ');
                  QTY_OnHand2 = clsUtil.ParseInt32(tmp[0]);
               }
               else
               {
                  QTY_OnHand2 = clsUtil.ParseInt32(temp);
               }
            }
         }
         QTY_Available1 = QTY_OnHand1 + QTY_OnInvoice1;
         QTY_Available2 = QTY_OnHand2 + QTY_OnInvoice2;

         //validate discount
         if (txtDiscount.Text != "")
         {
            if (!clsUtil.CheckFormula(txtDiscount.Text))
            {
               clsUtil.ShowMessageExclamation("Invalid discount formula!", "Add Item");
               txtDiscount.SelectAll();
               txtDiscount.Focus();
               return false;
            }
         }

         if (sid.item.IsWire)
         {
            //wire
            if (QTY1 <= 0 && QTY2 <= 0)
            {
               clsUtil.ShowMessageExclamation("Invalid Quantity!", "Add Item");
               txtQTY1.Focus();
               return false;
            }

            if (QTY1 != 0)
            {
               //per roll sales
               if (QTY2 != sid.QTY2)
               {
                  //invalid qty for meters, should be equal to stockin meters/roll qty
                  clsUtil.ShowMessageExclamation(
                     string.Format("Invalid meters / roll qty! Number of meters should be equal to {0}", sid.QTY2),
                     "Add Item");
                  txtQTY2.SelectAll();
                  txtQTY2.Focus();
                  return false;
               }

               if (QTY1 > QTY_Available1)
               {
                  clsUtil.ShowMessageExclamation("Cannot add item. Insufficient stocks available!", "Add Item");
                  txtQTY1.Focus();
                  return false;
               }
            }
            else
            {
               //per meter sales
               if (QTY2 > sid.QTY2)
               {
                  clsUtil.ShowMessageExclamation(
                     string.Format("Invalid quantity. Quantity should not be greater than '{0}'!", sid.QTY2), "Add Item");
                  txtQTY2.Focus();
                  return false;
               }

               if (wb != null)
               {
                  //get from incomplete roll
                  if (QTY2 > QTY_Available2)
                  {
                     clsUtil.ShowMessageExclamation("Cannot add item. Insufficient stocks available!", "Add Item");
                     txtQTY2.Focus();
                     return false;
                  }
               }
               else
               {
                  //get suppply from full roll, make sure there is suffcient QTY1
                  if (QTY_Available1 <= 0)
                  {
                     clsUtil.ShowMessageExclamation("Cannot add item. Insufficient stocks available!", "Add Item");
                     return false;
                  }
               }
            }
         }
         else
         {
            //normal item
            if (QTY1 <= 0)
            {
               clsUtil.ShowMessageExclamation("Invalid QTY. Please input a number greater than '0'.", "Add Item");
               return false;
            }

            if (QTY_Available1 <= 0)
            {
               clsUtil.ShowMessageExclamation("Cannot add item. Insufficient stocks available!", "Add Item");
               return false;
            }

            if (QTY1 > QTY_Available1)
            {
               clsUtil.ShowMessageExclamation(
                  string.Format("Invalid QTY. Please input a number not greater than '{0}'!", QTY_Available1),
                  "Add Item");
               txtQTY1.SelectAll();
               txtQTY1.Focus();
               return false;
            }

            if (Price1 <= 0)
            {
               clsUtil.ShowMessageExclamation("Invalid price!", "Add Item");
               txtPrice1.SelectAll();
               txtPrice1.Focus();
               return false;
            }
         }
         return true;
      }

      private bool ValidateMiscItems(TreeListNode node)
      {
         Int32 QTY1, QTY_OnHand1, QTY_OnInvoice1, QTY_Available1;
         Int32 StockInID = 0;
         double Price1 = 0;
         TreeListNode ParentNode = node.ParentNode;
         StockInDetails sid = (StockInDetails) node.GetValue(eCol.ItemObject.ToString());

         StockInID = GetStockInID(node);
         if (StockInID > 0)
         {
            //selected node has displayed StockIn ID
            if (!sid.HasSellingPrice())
            {
               clsUtil.ShowMessageExclamation("Cannot sell item. No selling price yet!", "Add Item");
               return false;
            }

            //is item locked?
            if (sid.Status == (int) StockInDetails.eStatus.Locked)
            {
               clsUtil.ShowMessageExclamation("Cannot sell item. Item is locked!", "Add Item");
               return false;
            }
         }

         QTY1 = (Int32) clsUtil.CheckValue(txtQTY1);
         Price1 = clsUtil.CheckValue(txtPrice1);

         QTY_OnHand1 = GetQTYOnHand(node, eCol.OnHand1.ToString());
         QTY_OnInvoice1 = GetQTYInInvoice(node, eCol.QTY1_InInvoice.ToString());
         QTY_Available1 = QTY_OnHand1 + QTY_OnInvoice1;

         //validate discount
         if (txtDiscount.Text != "")
         {
            if (!clsUtil.CheckFormula(txtDiscount.Text))
            {
               clsUtil.ShowMessageExclamation("Invalid discount formula!", "Add Item");
               txtDiscount.SelectAll();
               txtDiscount.Focus();
               return false;
            }
         }

         if (QTY1 <= 0)
         {
            clsUtil.ShowMessageExclamation("Invalid QTY. Please input a number greater than '0'.", "Add Item");
            return false;
         }

         if (QTY_Available1 <= 0)
         {
            clsUtil.ShowMessageExclamation("Cannot add item. Insufficient stocks available!", "Add Item");
            return false;
         }

         if (QTY1 > QTY_Available1)
         {
            clsUtil.ShowMessageExclamation(
               string.Format("Invalid QTY. Please input a number not greater than '{0}'!", QTY_Available1), "Add Item");
            txtQTY1.SelectAll();
            txtQTY1.Focus();
            return false;
         }

         if (Price1 <= 0)
         {
            clsUtil.ShowMessageExclamation("Invalid price!", "Add Item");
            txtPrice1.SelectAll();
            txtPrice1.Focus();
            return false;
         }
         return true;
      }

      private bool ValidateBundledItem(TreeListNode node)
      {
         //get available stocks
         if (node.Expanded == false)
         {
            node.Expanded = true;
         }
         //else
         //CheckBundledItemStocks(node);


         Int32 QTY1 = (Int32) clsUtil.CheckValue(txtQTY1);
         double Price = clsUtil.CheckValue(txtPrice1);
         string Discount = txtDiscount.Text;

         if (QTY1 <= 0)
         {
            clsUtil.ShowMessageExclamation("Invalid QTY!", "Add Bundled Item");
            txtQTY1.SelectAll();
            txtQTY1.Focus();
            return false;
         }

         if (Price <= 0)
         {
            clsUtil.ShowMessageExclamation("Invalid Price!", "Add Bundled Item");
            txtPrice1.SelectAll();
            txtPrice1.Focus();
            return false;
         }

         if (Discount != "" && !clsUtil.CheckFormula(Discount))
         {
            clsUtil.ShowMessageExclamation("Invalid discount formula!", "Add Bundled Item");
            txtDiscount.SelectAll();
            txtDiscount.Focus();
            return false;
         }

         string status = clsUtil.ParseString(node.GetValue(eColBundle.Stocks.ToString()));
         if (status != "" && status == "Not Available")
         {
            clsUtil.ShowMessageExclamation("Cannot add item. Not enough stocks available!", "Add Bundled Item");
            return false;
         }
         else
         {
            //check if stocks are sufficient
            Int32 QTY_OnHand, QTY_Invoice, QTY_Avail;

            foreach (TreeListNode childnode in node.Nodes)
            {
               QTY_OnHand = clsUtil.ParseInt32(childnode.GetValue(eColBundle.Stocks.ToString()).ToString());
               QTY_Invoice = clsUtil.ParseInt32(childnode.GetValue(eColBundle.QTY_InInvoice.ToString()).ToString());
               QTY_Avail = QTY_OnHand + QTY_Invoice;

               BundledItemDetails bid = (BundledItemDetails) childnode.GetValue(eColBundle.ItemObject.ToString());
               if ((QTY1*bid.QTY) > QTY_Avail)
               {
                  if (bid.item != null)
                     clsUtil.ShowMessageExclamation(
                        string.Format("Cannot add item. Not enough stocks available for item {0}!", bid.item.Name),
                        "Add Bundled Item");
                  else if (bid.FabItem != null)
                     clsUtil.ShowMessageExclamation(
                        string.Format("Cannot add item. Not enough stocks available for item {0}!", bid.FabItem.Name),
                        "Add Bundled Item");
                  else
                     clsUtil.ShowMessageExclamation("Cannot add item. Not enough stocks available!", "Add Bundled Item");
                  return false;
               }
            }
         }
         return true;
      }

      private void txtQTY2_Enter(object sender, EventArgs e)
      {
         ((DevExpress.XtraEditors.TextEdit) sender).SelectAll();
      }

      private void UpdateDisplayNormal(SalesInvoiceDetails sivd)
      {
         Int32 QTY_InInvoice1, QTY_InInvoice2, StockInID;

         foreach (SalesInvoiceDetails_StockIn siv_si in sivd.stockindetails)
         {
            if (siv_si.wirebreakdown != null)
            {
               int breakdownID = siv_si.wirebreakdown.BreakDownID;
               if (breakdownID == 0)
                  breakdownID = siv_si.wirebreakdown.BreakDownID_Source;

               TreeListNode node = GetTargetNodeNormal(sivd.item.ID, siv_si.stockindetails,
                                                       breakdownID);
               if (node != null)
               {
                  QTY_InInvoice2 = GetQTYInInvoice(node, eCol.QTY2_InInvoice.ToString());
                  node.SetValue(eCol.QTY2_InInvoice.ToString(), QTY_InInvoice2 - siv_si.QTY2);

                  //update wb parent (node with StockIn no.)
                  TreeListNode parentNode = node.ParentNode;
                  QTY_InInvoice2 = GetQTYInInvoice(parentNode, eCol.QTY2_InInvoice.ToString());
                  parentNode.SetValue(eCol.QTY2_InInvoice.ToString(), QTY_InInvoice2 - siv_si.QTY2);

                  //update [xxx mtrs/roll] node
                  parentNode = parentNode.ParentNode;
                  QTY_InInvoice2 = GetQTYInInvoice(parentNode, eCol.QTY2_InInvoice.ToString());
                  parentNode.SetValue(eCol.QTY2_InInvoice.ToString(), QTY_InInvoice2 - siv_si.QTY2);

                  //update main node [Item]
                  parentNode = parentNode.ParentNode;
                  QTY_InInvoice2 = GetQTYInInvoice(parentNode, eCol.QTY2_InInvoice.ToString());
                  parentNode.SetValue(eCol.QTY2_InInvoice.ToString(), QTY_InInvoice2 - siv_si.QTY2);
               }
               else
               {
                  //new wire breakdown
                  TreeListNode node_si = GetTargetNodeNormal(sivd.item.ID, siv_si.stockindetails, 0);
                  if (node_si == null)
                     continue;

                  TreeListNode node_temp = treeItems.AppendNode(null, node_si);
                  node_temp.SetValue(eCol.StockIn_ID.ToString(),
                                     string.Format("[Roll ID#] {0}", siv_si.wirebreakdown.BreakDownID.ToString("000")));
                  node_temp.SetValue(eCol.ItemObject.ToString(), siv_si.stockindetails);
                  node_temp.SetValue(eCol.WireBreakdown.ToString(), siv_si.wirebreakdown);
                  node_temp.SetValue(eCol.OnHand1.ToString(), "0 roll");
                  node_temp.SetValue(eCol.OnHand2.ToString(), siv_si.stockindetails.QTY2);
                  node_temp.SetValue(eCol.QTY2_InInvoice.ToString(), siv_si.QTY2*-1);
                  //treeItems.SetNodeIndex(node_temp, index);

                  QTY_InInvoice1 = GetQTYInInvoice(node_si, eCol.QTY1_InInvoice.ToString());
                  QTY_InInvoice2 = GetQTYInInvoice(node_si, eCol.QTY2_InInvoice.ToString());
                  node_si.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - 1);
                  node_si.SetValue(eCol.QTY2_InInvoice.ToString(), QTY_InInvoice2 - siv_si.QTY2);

                  TreeListNode ParentNode = node_si.ParentNode;
                  QTY_InInvoice1 = GetQTYInInvoice(ParentNode, eCol.QTY1_InInvoice.ToString());
                  QTY_InInvoice2 = GetQTYInInvoice(ParentNode, eCol.QTY2_InInvoice.ToString());
                  ParentNode.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - 1);
                  ParentNode.SetValue(eCol.QTY2_InInvoice.ToString(), QTY_InInvoice2 - siv_si.QTY2);

                  ParentNode = ParentNode.ParentNode;
                  QTY_InInvoice1 = GetQTYInInvoice(ParentNode, eCol.QTY1_InInvoice.ToString());
                  QTY_InInvoice2 = GetQTYInInvoice(ParentNode, eCol.QTY2_InInvoice.ToString());
                  ParentNode.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - 1);
                  ParentNode.SetValue(eCol.QTY2_InInvoice.ToString(), QTY_InInvoice2 - siv_si.QTY2);
               }
            }
            else
            {
               if (sivd.item != null)
               {
                  TreeListNode node = GetTargetNodeNormal(sivd.item.ID, siv_si.stockindetails, 0);
                  if (node != null)
                  {
                     QTY_InInvoice1 = GetQTYInInvoice(node, eCol.QTY1_InInvoice.ToString());
                     QTY_InInvoice2 = GetQTYInInvoice(node, eCol.QTY2_InInvoice.ToString());
                     node.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - siv_si.QTY1);
                     if (sivd.item.IsWire)
                     {
                        node.SetValue(eCol.QTY2_InInvoice.ToString(), QTY_InInvoice2 - siv_si.QTY1*siv_si.QTY2);
                     }
                     QTY_InInvoice1 = GetQTYInInvoice(node.ParentNode, eCol.QTY1_InInvoice.ToString());
                     QTY_InInvoice2 = GetQTYInInvoice(node.ParentNode, eCol.QTY2_InInvoice.ToString());
                     node.ParentNode.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - siv_si.QTY1);
                     if (sivd.item.IsWire)
                     {
                        node.ParentNode.SetValue(eCol.QTY2_InInvoice.ToString(),
                                                 QTY_InInvoice2 - siv_si.QTY1*siv_si.QTY2);

                        QTY_InInvoice1 = GetQTYInInvoice(node.ParentNode.ParentNode, eCol.QTY1_InInvoice.ToString());
                        node.ParentNode.ParentNode.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - siv_si.QTY1);
                        QTY_InInvoice2 = GetQTYInInvoice(node.ParentNode.ParentNode, eCol.QTY2_InInvoice.ToString());
                        node.ParentNode.ParentNode.SetValue(eCol.QTY2_InInvoice.ToString(),
                                                            QTY_InInvoice2 - siv_si.QTY1*siv_si.QTY2);
                     }
                  }
                  else
                  {
                     //?
                  }
               }
               else if (sivd.bundleditem != null)
               {
                  foreach (BundledItemDetails bid in sivd.bundleditem.details)
                  {
                     if (bid.item != null)
                     {
                        TreeListNode node = GetTargetNodeNormal(bid.item.ID, siv_si.stockindetails, 0);
                        if (node != null)
                        {
                           QTY_InInvoice1 = GetQTYInInvoice(node, eCol.QTY1_InInvoice.ToString());
                           QTY_InInvoice2 = GetQTYInInvoice(node, eCol.QTY2_InInvoice.ToString());
                           node.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - siv_si.QTY1);
                           if (bid.item.IsWire)
                           {
                              node.SetValue(eCol.QTY2_InInvoice.ToString(), QTY_InInvoice2 - siv_si.QTY1*siv_si.QTY2);
                           }
                           QTY_InInvoice1 = GetQTYInInvoice(node.ParentNode, eCol.QTY1_InInvoice.ToString());
                           QTY_InInvoice2 = GetQTYInInvoice(node.ParentNode, eCol.QTY2_InInvoice.ToString());
                           node.ParentNode.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - siv_si.QTY1);
                           if (bid.item.IsWire)
                           {
                              node.ParentNode.SetValue(eCol.QTY2_InInvoice.ToString(),
                                                       QTY_InInvoice2 - siv_si.QTY1*siv_si.QTY2);

                              QTY_InInvoice1 = GetQTYInInvoice(node.ParentNode.ParentNode,
                                                               eCol.QTY1_InInvoice.ToString());
                              node.ParentNode.ParentNode.SetValue(eCol.QTY1_InInvoice.ToString(),
                                                                  QTY_InInvoice1 - siv_si.QTY1);
                              QTY_InInvoice2 = GetQTYInInvoice(node.ParentNode.ParentNode,
                                                               eCol.QTY2_InInvoice.ToString());
                              node.ParentNode.ParentNode.SetValue(eCol.QTY2_InInvoice.ToString(),
                                                                  QTY_InInvoice2 - siv_si.QTY1*siv_si.QTY2);
                           }
                        }
                        else
                        {
                           //?
                        }
                     }
                  }
               }
            }
         }
      }

      private void UpdateDisplayMiscItems(SalesInvoiceDetails sivd)
      {
         Int32 QTY_InInvoice1, QTY_InInvoice2;

         foreach (SalesInvoiceDetails_StockIn siv_si in sivd.stockindetails)
         {
            TreeListNode node = GetTargetNodeMiscItems(sivd.fabitem.ID, siv_si.stockindetails);
            if (node != null)
            {
               QTY_InInvoice1 = GetQTYInInvoice(node, eCol.QTY1_InInvoice.ToString());
               QTY_InInvoice2 = GetQTYInInvoice(node, eCol.QTY2_InInvoice.ToString());
               node.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - siv_si.QTY1);

               QTY_InInvoice1 = GetQTYInInvoice(node.ParentNode, eCol.QTY1_InInvoice.ToString());
               QTY_InInvoice2 = GetQTYInInvoice(node.ParentNode, eCol.QTY2_InInvoice.ToString());
               node.ParentNode.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - siv_si.QTY1);
            }
            else
            {
               //?
            }
         }
      }

      private void UpdateDisplayBundledItem(TreeListNode node)
      {
         BundledItem bi = (BundledItem) node.GetValue(eColBundle.ItemObject.ToString());
         Int32 QTY1 = (Int32) clsUtil.CheckValue(txtQTY1);
         treeBundle.BeginUnboundLoad();
         foreach (TreeListNode childnode in node.Nodes)
         {
            BundledItemDetails bid = (BundledItemDetails) childnode.GetValue(eColBundle.ItemObject.ToString());
            Int32 QTY_Invoice =
               clsUtil.ParseInt32(clsUtil.ParseString(childnode.GetValue(eColBundle.QTY_InInvoice.ToString())));
            QTY_Invoice -= (QTY1*bid.QTY);
            childnode.SetValue(eColBundle.QTY_InInvoice.ToString(), QTY_Invoice);
         }
         treeBundle.EndUnboundLoad();
      }

      private TreeListNode GetTargetNodeNormal(Int32 ItemID, StockInDetails stockindetails, Int32 WireBreakdownID)
      {
         Int32 StockInID = 0;
         foreach (TreeListNode node in treeItems.Nodes)
         {
            if (node.HasChildren)
            {
               StockInDetails sid = (StockInDetails) node.GetValue(eCol.ItemObject.ToString());
               if (sid.item.ID == ItemID)
               {
                  //found parent node
                  if (sid.item.IsWire)
                  {
                     foreach (TreeListNode childnode in node.Nodes)
                     {
                        StockInDetails sid2 = (StockInDetails) childnode.GetValue(eCol.ItemObject.ToString());
                        if (sid2.QTY2 == stockindetails.QTY2)
                        {
                           foreach (TreeListNode childnode2 in childnode.Nodes)
                           {
                              StockInDetails sid3 = (StockInDetails) childnode2.GetValue(eCol.ItemObject.ToString());
                              if (sid3.ID == stockindetails.ID)
                              {
                                 StockInID = GetStockInID(childnode2);
                                 if (WireBreakdownID == 0)
                                 {
                                    //per roll
                                    if (StockInID == stockindetails.stockin.ID && sid3.ID == stockindetails.ID)
                                       return childnode2;
                                 }
                                 else
                                 {
                                    foreach (TreeListNode childnode3 in childnode2.Nodes)
                                    {
                                       //get wire breakdown
                                       WireBreakdown wb =
                                          (WireBreakdown) childnode3.GetValue(eCol.WireBreakdown.ToString());
                                       if (wb != null && wb.BreakDownID == WireBreakdownID &&
                                           wb.SID.ID == stockindetails.ID)
                                          return childnode3;
                                    }
                                 }
                              }
                           }
                           break;
                        }
                     }
                  }
                  else
                  {
                     foreach (TreeListNode childnode in node.Nodes)
                     {
                        StockInDetails sid2 = (StockInDetails) childnode.GetValue(eCol.ItemObject.ToString());
                        if (sid2.ID == stockindetails.ID)
                        {
                           return childnode;
                        }
                     }
                  }
                  break;
               }
            }
            else
            {
               //reached no stock items
               return null;
            }
         }
         return null;
      }

      private TreeListNode GetTargetNodeMiscItems(Int32 ItemID, StockInDetails stockindetails)
      {
         Int32 StockInID = 0;
         foreach (TreeListNode node in treeItems.Nodes)
         {
            if (node.HasChildren)
            {
               StockInDetails sid = (StockInDetails) node.GetValue(eCol.ItemObject.ToString());
               if (sid.fabricateditem != null)
               {
                  if (sid.fabricateditem.ID == ItemID)
                  {
                     foreach (TreeListNode childnode in node.Nodes)
                     {
                        StockInDetails sid2 = (StockInDetails) childnode.GetValue(eCol.ItemObject.ToString());
                        if (sid2.ID == stockindetails.ID)
                        {
                           return childnode;
                        }
                     }
                     break;
                  }
               }
               else if (sid.tradingitem != null)
               {
                  if (sid.tradingitem.ID == ItemID)
                  {
                     foreach (TreeListNode childnode in node.Nodes)
                     {
                        StockInDetails sid2 = (StockInDetails) childnode.GetValue(eCol.ItemObject.ToString());
                        if (sid2.ID == stockindetails.ID)
                        {
                           return childnode;
                        }
                     }
                     break;
                  }
               }
            }
         }
         return null;
      }

      private Int32 GetQTYOnHand(TreeListNode node, string ColName)
      {
         return clsUtil.ParseInt32(clsUtil.ParseString(node.GetValue(ColName)));
      }

      private Int32 GetQTYInInvoice(TreeListNode node, string ColName)
      {
         return clsUtil.ParseInt32(clsUtil.ParseString(node.GetValue(ColName)));
      }

      private Int32 GetStockInID(TreeListNode node)
      {
         return clsUtil.ParseInt32(clsUtil.ParseString(node.GetValue(eCol.StockIn_ID.ToString())));
      }

      private Int32 GetLastWireBreakDownID(TreeListNode node)
      {
         if (node.Nodes.Count == 0)
            return 0;

         WireBreakdown wb = null;
         int wbID = 0;
         foreach (TreeListNode node2 in node.Nodes)
         {
            wb = (WireBreakdown) node2.GetValue(eCol.WireBreakdown.ToString());
            if (wb.BreakDownID > wbID)
               wbID = wb.BreakDownID;
         }
         return wbID;
      }

      private void treeBundle_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
      {
         CheckSelectedBundledItem();
      }

      private void CheckSelectedBundledItem()
      {
         TreeListNode node = treeBundle.FocusedNode;
         if (node != null)
         {
            if (node.ParentNode != null)
               node = node.ParentNode;

            BundledItem bi = (BundledItem) node.GetValue(eColBundle.ItemObject.ToString());
            if (bi != null)
            {
               txtQTY1.Text = "1";
               txtPrice1.Text = bi.UnitPrice.ToString("#,##0.00");
               btnAddItem.Enabled = true;
            }
            else
            {
               txtQTY1.Text = "0";
               txtPrice1.Text = "0.00";
               btnAddItem.Enabled = false;
            }
         }
         else
         {
            txtQTY1.Text = "0";
            txtPrice1.Text = "0.00";
            btnAddItem.Enabled = false;
         }
      }

      private void treeItems_CompareNodeValues(object sender, CompareNodeValuesEventArgs e)
      {
         WireBreakdown wb1 = (WireBreakdown)e.Node1.GetValue(eCol.WireBreakdown.ToString());
         WireBreakdown wb2 = (WireBreakdown)e.Node2.GetValue(eCol.WireBreakdown.ToString());
         if (wb1 == null || wb2 == null)
            e.Result = 0;
         else
         {
            e.Result = (wb1.BreakDownID<wb2.BreakDownID)? -1:1;
            //return;
         }
      }

      private void HideUnusedItems()
      {
          chkExcludeNoStockItems.Visible = false;
          radioItems.Visible = false;
          txtQTY2.Visible = false;
          txtPrice2.Visible = false;
          lblQTY2.Visible = false;
          lblPrice2.Visible = false;
      }

      private void cboWarehouse_SelectedIndexChanged(object sender, EventArgs e)
      {
          btnSearch.PerformClick();
      }

   }
}