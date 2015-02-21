#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DexterHardware_v2.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace DexterHardware_v2.UI_Controls.Transactions
{
   public partial class ctlSelectItems_LoanedItem : UserControl
   {
      private StockInDetailsDao StockInDetailsDao = new StockInDetailsDao();
      private ItemDao ItemDao = new ItemDao();
      private BundledItemDao BundledItemDao = new BundledItemDao();
      private TradingItemDao TradeItemDao = new TradingItemDao();
      private FabricatedItemDao FabItemDao = new FabricatedItemDao();

      public ctlLoanedItems ParentCtl { get; set; }
      
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

      public ctlSelectItems_LoanedItem()
      {
         InitializeComponent();
      }
      private void btnSearch_Click(object sender, EventArgs e)
      {
         if (txtSearch.Text != "")
         {
            string Condition = "";
            if (radioItems.SelectedIndex == 0)
            {
               //normal items
               //Condition = clsUtil.GenerateSQLCondition("sid.item.Name", txtSearch.Text, " ");
               Condition = cUtil.GenerateFilterCondition(txtSearch.Text);
               Condition = string.Format("sid.item.Name like '{0}' or sid.item.Description like '{0}'", Condition);
               SearchNormalItems(Condition);

               if (ParentCtl.m_LoanedItem.details.Count > 0)
               {
                  foreach (LoanedItemsDetails sivd in ParentCtl.m_LoanedItem.details)
                  {
                     UpdateDisplayNormal(sivd);
                  }
               }
            }
            else if (radioItems.SelectedIndex == 1)
            {
               //bundled items
               Condition = cUtil.GenerateFilterCondition(txtSearch.Text);
               SearchBundledItems(Condition);
            }
            else if (radioItems.SelectedIndex == 2)
            {
               //fabricated items
               Condition = cUtil.GenerateFilterCondition(txtSearch.Text);
               Condition =
                  string.Format("sid.fabricateditem.Name like '{0}' or sid.fabricateditem.Description like '{0}'",
                                Condition);
               SearchFabricatedItems(Condition);

               if (ParentCtl.m_LoanedItem.details.Count > 0)
               {
                  treeItems.BeginUnboundLoad();
                  foreach (LoanedItemsDetails lid in ParentCtl.m_LoanedItem.details)
                  {
                     UpdateDisplayMiscItems(lid);
                  }
                  treeItems.EndUnboundLoad();
               }
            }
            else if (radioItems.SelectedIndex == 3)
            {
               //trading items
               Condition = cUtil.GenerateFilterCondition(txtSearch.Text);
               Condition = string.Format("sid.tradingitem.Name like '{0}' or sid.tradingitem.Description like '{0}'",
                                         Condition);
               SearchTradingItems(Condition);

               if (ParentCtl.m_LoanedItem.details.Count > 0)
               {
                  treeItems.BeginUnboundLoad();
                  foreach (LoanedItemsDetails lid in ParentCtl.m_LoanedItem.details)
                  {
                     UpdateDisplayMiscItems(lid);
                  }
                  treeItems.EndUnboundLoad();
               }
            }
         }
      }

      private void SearchNormalItems(string Condition)
      {
         IList<StockInDetails> lst = StockInDetailsDao.GetAvailableStocks(Condition, true, false, false);

         treeItems.Nodes.Clear();
         int ItemID = 0;
         TreeListNode ParentNode = null, ChildNode = null, ChildNode2 = null, ParentWireNode = null;

         treeItems.BeginUnboundLoad();
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

               if (sid.item.IsWire)
               {
                  ParentNode.SetValue(eCol.OnHand1.ToString(), string.Format("{0} rolls", sid.item.QTYOnHand1));
                  ParentNode.SetValue(eCol.OnHand2.ToString(), string.Format("{0} mtrs", sid.item.QTYOnHand2));
               }
               else
                  ParentNode.SetValue(eCol.OnHand1.ToString(), sid.item.QTYOnHand1);
            }

            if (sid.item.IsWire)
            {
               ParentWireNode = GetWireParentNode(ParentNode, sid.QTY2);
               if (ParentWireNode == null)
               {
                  //create new parent node with specific mtrs/roll group
                  ParentWireNode = treeItems.AppendNode(null, ParentNode);
                  ParentWireNode.SetValue(eCol.ItemName.ToString(), string.Format("[@ {0} meters/roll]", sid.QTY2));
                  ParentWireNode.SetValue(eCol.ItemObject.ToString(), sid);
                  ParentWireNode.SetValue(eCol.OnHand1.ToString(), 0);
                  ParentWireNode.SetValue(eCol.OnHand2.ToString(), 0);
               }

               ChildNode = treeItems.AppendNode(null, ParentWireNode);
               ChildNode.SetValue(eCol.StockIn_ID.ToString(), sid.stockin.ID.ToString("000000"));

               //save StockInDetails to node
               ChildNode.SetValue(eCol.ItemObject.ToString(), sid);

               //set icon for Locked items
               if (sid.Status == (int) StockInDetails.eStatus.Locked)
                  ChildNode.StateImageIndex = 0;

               ChildNode.SetValue(eCol.OnHand1.ToString(), string.Format("{0} rolls", sid.QTY_OnHand1));
               ChildNode.SetValue(eCol.OnHand2.ToString(), string.Format("{0} mtrs", sid.QTY_OnHand2));

               //update parentwire QTY
               Int32 QTY_OnHand1, QTY_OnHand2;
               QTY_OnHand1 = cUtil.ParseInt32(ParentWireNode.GetValue(eCol.OnHand1.ToString()).ToString());
               QTY_OnHand2 = cUtil.ParseInt32(ParentWireNode.GetValue(eCol.OnHand2.ToString()).ToString());
               ParentWireNode.SetValue(eCol.OnHand1.ToString(), QTY_OnHand1 + sid.QTY_OnHand1);
               ParentWireNode.SetValue(eCol.OnHand2.ToString(), QTY_OnHand2 + sid.QTY_OnHand2);

               if (sid.wirebreakdown_details != null)
               {
                  //show wire breakdown
                  foreach (WireBreakdown wb in sid.wirebreakdown_details)
                  {
                     //list wire breakdown for this sid, only list wb with still supply left
                     ChildNode2 = treeItems.AppendNode(null, ChildNode);
                     ChildNode2.SetValue(eCol.ItemObject.ToString(), sid);
                     ChildNode2.SetValue(eCol.WireBreakdown.ToString(), wb);

                     //ChildNode.SetValue(eCol.ItemName.ToString(), "[Wire Breakdown]");
                     ChildNode2.SetValue(eCol.StockIn_ID.ToString(),
                                         string.Format("[Roll ID#] {0}", wb.BreakDownID.ToString("000")));
                     ChildNode2.SetValue(eCol.OnHand1.ToString(), string.Format("{0} roll", 0));
                     ChildNode2.SetValue(eCol.OnHand2.ToString(), string.Format("{0} mtrs", wb.QTY_OnHand));

                     //set icon for Locked items
                     if (sid.Status == (int)StockInDetails.eStatus.Locked)
                        ChildNode2.StateImageIndex = 0;

                     if (wb.QTY_OnHand == 0)
                     {
                        //hide this node
                        ChildNode2.Visible = false;
                        
                     }
                  }
               }
            }
            else
            {
               ChildNode = treeItems.AppendNode(null, ParentNode);
               ChildNode.SetValue(eCol.StockIn_ID.ToString(), sid.stockin.ID.ToString("000000"));

               //save StockInDetails to node
               ChildNode.SetValue(eCol.ItemObject.ToString(), sid);
               ChildNode.SetValue(eCol.OnHand1.ToString(), sid.QTY_OnHand1);

               //set icon for Locked items
               if (sid.Status == (int) StockInDetails.eStatus.Locked)
                  ChildNode.StateImageIndex = 0;
            }
         }

         //show No Stock Items
         Condition = cUtil.GenerateSQLCondition("Name", txtSearch.Text, " ");
         IList<Items> lst2 = ItemDao.getAllByCondition(Condition);
         foreach (Items item in lst2)
         {
            ParentNode = treeItems.AppendNode(null, null);
            ParentNode.SetValue(eCol.ItemName.ToString(), item.Name);
            ParentNode.SetValue(eCol.OnHand1.ToString(), 0);
            ParentNode.SetValue(eCol.OnHand2.ToString(), 0);
         }

         treeItems.EndUnboundLoad();

         CheckSelectedNode(treeItems.FocusedNode);
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
                  QTY_OnInvoice1 = cUtil.ParseInt32(cUtil.ParseString(node.GetValue(eCol.QTY1_InInvoice.ToString())));
                  QTY_OnInvoice2 = cUtil.ParseInt32(cUtil.ParseString(node.GetValue(eCol.QTY2_InInvoice.ToString())));
                  QTY_Avail1 = QTY_OnHand1 + QTY_OnInvoice1;
                  QTY_Avail2 = QTY_OnHand2 + QTY_OnInvoice2;

                  if (sid.item != null)
                  {
                     lblPrice2.Visible = sid.item.IsWire;
                     txtPrice2.Visible = sid.item.IsWire;
                     lblQTY2.Visible = sid.item.IsWire;
                     txtQTY2.Visible = sid.item.IsWire;

                     if (sid.item.IsWire)
                     {
                        lblPrice1.Text = "Price/roll";
                        lblPrice2.Text = "Price/mtr";
                        lblQTY1.Text = "Rolls";
                        lblQTY2.Text = "Meters/roll";
                        txtQTY1.Text = "1";

                        txtQTY1.Text = "1";
                        txtQTY2.Text = sid.QTY2.ToString();

                        if (sid.SellingPrice1 != 0)
                           txtPrice1.Text = sid.SellingPrice1.ToString("#,##0.00");
                        else
                           txtPrice1.Text = cUtil.DiscountAmt(sid.Price1, sid.SellingDiscount1).ToString("#,##0.00");


                        if (sid.item.Price1 == 0 && sid.item.Price2 == 0)
                        {
                           //show price set for item during item registration
                           if (sid.item.Price2 != 0)
                           {
                              //price per roll set
                              txtPrice1.Text = sid.item.Price1.ToString("#,##0.00");
                              txtPrice2.Text = (sid.item.Price1/sid.QTY2).ToString("#,##0.00");
                           }
                           else
                           {
                              //price per meter set
                              txtPrice1.Text = (sid.item.Price2*sid.QTY2).ToString("#,##0.00");
                              txtPrice2.Text = sid.item.Price2.ToString("#,##0.00");
                           }
                        }
                        else
                        {
                           //use selling price
                           if (sid.SellingPrice2 != 0)
                              txtPrice2.Text = sid.SellingPrice2.ToString("#,##0.00");
                           else
                              txtPrice2.Text = cUtil.DiscountAmt(sid.Price2, sid.SellingDiscount2).ToString("#,##0.00");
                        }
                        //txtQTY2.Text = sid.QTY2.ToString("#,##0");

                        if (node.ParentNode == null)
                        {
                           //parent node, no stockin selected, cannot add item
                           txtQTY2.Enabled = false;
                           txtPrice2.Enabled = false;
                           btnAddItem.Enabled = false;
                        }
                        else
                        {
                           string temp = cUtil.ParseString(node.GetValue(eCol.ItemName.ToString()));
                           if (temp != "" && temp.Contains("meters/roll"))
                           {
                              txtQTY1.Enabled = true;
                              txtPrice1.Enabled = true;
                              txtQTY2.Enabled = false;
                              txtPrice2.Enabled = false;
                           }
                           else
                           {
                              string SI_ID = cUtil.ParseString(node.GetValue(eCol.StockIn_ID.ToString()));
                              if (cUtil.ParseInt32(SI_ID) > 0)
                              {
                                 //has stockin ID entry (allow per roll or per meter sales)
                                 txtQTY1.Enabled = true;
                                 txtPrice1.Enabled = true;
                                 txtQTY2.Enabled = true;
                                 txtPrice2.Enabled = true;
                              }
                              else
                              {
                                 //[Roll ID#] xxx line
                                 //per meter sales only
                                 WireBreakdown wb = (WireBreakdown) node.GetValue(eCol.WireBreakdown.ToString());
                                 txtQTY1.Text = "0";
                                 txtQTY1.Enabled = false;
                                 txtPrice1.Enabled = false;

                                 txtQTY2.Text = (wb.QTY_OnHand + QTY_OnInvoice2).ToString();
                                 txtQTY2.Enabled = true;
                                 txtPrice2.Enabled = true;
                              }
                           }
                           btnAddItem.Enabled = true;
                        }
                     }
                     else
                     {
                        txtPrice1.Enabled = true;
                        txtQTY1.Enabled = true;
                        txtPrice2.Text = "0.00";
                        txtQTY2.Text = "0";

                        lblPrice1.Text = "Price";
                        if (sid.item.Price1 != 0)
                        {
                           //show price set for item during item registration
                           txtPrice1.Text = sid.item.Price1.ToString("#,##0.00");
                        }
                        else
                        {
                           //show selling price
                           if (sid.SellingPrice1 != 0)
                              txtPrice1.Text = sid.SellingPrice1.ToString("#,##0.00");
                           else
                              txtPrice1.Text = cUtil.DiscountAmt(sid.Price1, sid.SellingDiscount1).ToString("#,##0.00");
                        }

                        lblQTY1.Text = "QTY";
                        txtQTY1.Text = "1";
                        btnAddItem.Enabled = true;
                     }
                  }
                  else
                  {
                     lblPrice2.Visible = false;
                     txtPrice2.Visible = false;
                     txtPrice2.Text = "0.00";
                     lblQTY2.Visible = false;
                     txtQTY2.Visible = false;
                     txtQTY2.Text = "0";

                     lblPrice1.Text = "Price";
                     if (sid.SellingPrice1 != 0)
                        txtPrice1.Text = sid.SellingPrice1.ToString("#,##0.00");
                     else
                        txtPrice1.Text = cUtil.DiscountAmt(sid.Price1, sid.SellingDiscount1).ToString("#,##0.00");

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
         lblPrice1.Text = "Price1";
         lblPrice2.Text = "Price2";
         txtPrice1.Text = "0.00";
         txtPrice2.Text = "0.00";
         lblQTY1.Text = "QTY1";
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
                  foreach (LoanedItemsDetails sivd in ParentCtl.m_LoanedItem.details)
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
                  foreach (LoanedItemsDetails sivd in ParentCtl.m_LoanedItem.details)
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
         if (radioItems.SelectedIndex == 0)
         {
            //Normal Items
            AddNormaItem();
            txtDiscount.Text = "";
            treeItems.Focus();
         }
         else if (radioItems.SelectedIndex == 1)
         {
            //Bundled Items
            AddBundledItem();
            txtDiscount.Text = "";
            treeBundle.Focus();
         }
         else if (radioItems.SelectedIndex == 2)
         {
            //fabricated items
            AddMiscItems();
            txtDiscount.Text = "";
            treeItems.Focus();
         }
         else if (radioItems.SelectedIndex == 3)
         {
            //trading items
            AddMiscItems();
            txtDiscount.Text = "";
            treeItems.Focus();
         }
      }

      private void AddNormaItem()
      {
         TreeListNode ParentNode, SelectedNode;
         SelectedNode = treeItems.FocusedNode;

         if (SelectedNode == null)
         {
            cUtil.ShowMessageExclamation("Please select valid item!", "Add Item");
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

            QTY1 = (Int32) cUtil.CheckValue(txtQTY1);
            QTY2 = (Int32) cUtil.CheckValue(txtQTY2);
            Price1 = cUtil.CheckValue(txtPrice1);
            Price2 = cUtil.CheckValue(txtPrice2);

            StockInDetails sid = (StockInDetails) SelectedNode.GetValue(eCol.ItemObject.ToString());
            LoanedItemsDetails lid = new LoanedItemsDetails();
            lid.stockindetails = new List<LoanedItemsDetails_StockIn>();

            lid.item = sid.item;
            lid.QTY1 = QTY1;
            lid.QTY2 = QTY2;
            lid.AgentPrice1 = Price1;
            lid.AgentPrice2 = Price2;
            lid.AgentDiscount = txtDiscount.Text;
            lid.CustomerPrice1 = lid.AgentPrice1;
            lid.CustomerPrice2 = lid.AgentPrice2;
            lid.CustomerDiscount = lid.AgentDiscount;

            string temp = cUtil.ParseString(SelectedNode.GetValue(eCol.StockIn_ID.ToString()));
            Int32 StockInID = cUtil.ParseInt32(temp);

            //get stockin details
            Int32 QTY_OnHand1, QTY_OnHand2, QTY_InInvoice1, QTY_InInvoice2, QTY_Avail1, QTY_Avail2;

            if (sid.item.IsWire)
            {
               if (SelectedNode.ParentNode == null)
               {
                  //not allowed
                  return;
               }
               else
               {
                  if (QTY1 > 0)
                  {
                     //per roll sales
                     if (StockInID > 0)
                     {
                        LoanedItemsDetails_StockIn siv_si = new LoanedItemsDetails_StockIn();
                        siv_si.QTY1 = QTY1;
                        siv_si.QTY2 = sid.QTY2;
                        siv_si.SellingPrice1 = sid.SellingPrice1;
                        siv_si.SellingPrice2 = sid.SellingPrice2;
                        siv_si.SellingDiscount1 = sid.SellingDiscount1;
                        siv_si.SellingDiscount2 = sid.SellingDiscount2;
                        siv_si.stockindetails = sid;
                        lid.stockindetails.Add(siv_si);
                     }
                     else
                     {
                        //no StockIn selected, auto select
                        int QTY_Needed = QTY1;
                        foreach (TreeListNode node in SelectedNode.Nodes)
                        {
                           //check if item is not wirebreakdown
                           WireBreakdown wb = (WireBreakdown) node.GetValue(eCol.WireBreakdown.ToString());
                           if (wb != null)
                              continue;

                           StockInDetails sid2 = (StockInDetails) node.GetValue(eCol.ItemObject.ToString());

                           //check if sid is locked for selling
                           if (sid2.Status == (int) StockInDetails.eStatus.Locked)
                              continue;

                           //check if item has no selling price set
                           if (!sid2.HasSellingPrice())
                              continue;

                           QTY_OnHand1 = sid2.QTY_OnHand1;
                           QTY_OnHand2 = sid2.QTY_OnHand2;
                           QTY_InInvoice1 =
                              cUtil.ParseInt32(cUtil.ParseString(node.GetValue(eCol.QTY1_InInvoice.ToString())));
                           QTY_InInvoice2 =
                              cUtil.ParseInt32(cUtil.ParseString(node.GetValue(eCol.QTY2_InInvoice.ToString())));
                           QTY_Avail1 = QTY_OnHand1 + QTY_InInvoice1;
                           QTY_Avail2 = QTY_OnHand2 + QTY_InInvoice2;

                           LoanedItemsDetails_StockIn siv_si = new LoanedItemsDetails_StockIn();
                           siv_si.QTY2 = sid2.QTY2;
                           siv_si.SellingPrice1 = sid2.SellingPrice1;
                           siv_si.SellingPrice2 = sid2.SellingPrice2;
                           siv_si.SellingDiscount1 = sid2.SellingDiscount1;
                           siv_si.SellingDiscount2 = sid2.SellingDiscount2;
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
                           lid.stockindetails.Add(siv_si);

                           if (QTY_Needed == 0)
                              break;
                        }
                        if (QTY_Needed != 0)
                        {
                           cUtil.ShowMessageExclamation(
                              "Insufficient stocks! Some of the items might be locked for selling!", "Add Item");
                           return;
                        }
                     }
                  }
                  else
                  {
                     //per meter sales
                     if (StockInID > 0)
                     {
                        //get from a new roll
                        WireBreakdown wb = new WireBreakdown();
                        wb.NewBreakdown = true;

                        //get new ID
                        int newwireid = StockInDetailsDao.GetNextWireBreakdownID(StockInID);
                        int LastWireID = GetLastWireBreakDownID(SelectedNode);
                        if (LastWireID == 0)
                        {
                           //wb.ID = newwireid;
                           wb.BreakDownID = newwireid;
                        }
                        else
                        {
                           if (LastWireID < newwireid)
                              wb.BreakDownID = newwireid;
                           else
                              wb.BreakDownID = LastWireID + 1;
                        }
                        wb.SID = sid;
                        wb.QTY_OnHand = sid.QTY2;
                        wb.QTY_Original = sid.QTY2;

                        LoanedItemsDetails_StockIn siv_si = new LoanedItemsDetails_StockIn();
                        siv_si.QTY1 = 0;
                        siv_si.QTY2 = QTY2;
                        siv_si.SellingDiscount2 = sid.SellingDiscount2;
                        siv_si.SellingPrice2 = sid.SellingPrice2;
                        siv_si.stockindetails = sid;
                        siv_si.wirebreakdown = wb;
                        lid.stockindetails.Add(siv_si);
                     }
                     else
                     {
                        if (sid.Status == (Int32) StockInDetails.eStatus.Locked)
                        {
                           cUtil.ShowMessageExclamation("Cannot add item. Item is locked for selling.", "Add Item");
                           return;
                        }

                        //get from existing incomplete roll
                        WireBreakdown wb = (WireBreakdown) SelectedNode.GetValue(eCol.WireBreakdown.ToString());
                        if (wb == null)
                        {
                           cUtil.ShowMessageExclamation(
                              "Invalid item selected. Please select item with displayed StockIn ID.", "Add Item");
                           return;
                        }

                        //create new wirebreakdown from remains
                        WireBreakdown wb2 = new WireBreakdown();
                        wb2.BreakDownID = 0;
                        wb2.NewBreakdown = true;
                        wb2.BreakDownID_Source = wb.BreakDownID;     //source wb ID
                        wb2.SID = sid;
                        wb2.QTY_OnHand = QTY2;
                        wb2.QTY_Original = sid.QTY2;

                        LoanedItemsDetails_StockIn siv_si = new LoanedItemsDetails_StockIn();
                        siv_si.QTY1 = 0;
                        siv_si.QTY2 = QTY2;
                        siv_si.SellingDiscount2 = sid.SellingDiscount2;
                        siv_si.SellingPrice2 = sid.SellingPrice2;
                        siv_si.stockindetails = sid;
                        siv_si.wirebreakdown = wb2;
                        lid.stockindetails.Add(siv_si);
                     }
                  }
                  ParentCtl.AddItem(lid);
                  UpdateDisplayNormal(lid);
               }
            }
            else
            {
               //normal item
               if (StockInID > 0)
               {
                  //only 1 StockInID affected
                  LoanedItemsDetails_StockIn siv_si = new LoanedItemsDetails_StockIn();
                  siv_si.QTY1 = QTY1;
                  siv_si.QTY2 = sid.QTY2;
                  siv_si.SellingDiscount1 = sid.SellingDiscount1;
                  siv_si.SellingPrice1 = sid.SellingPrice1;
                  siv_si.stockindetails = sid;
                  lid.stockindetails.Add(siv_si);

                  ParentCtl.AddItem(lid);
                  UpdateDisplayNormal(lid);
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

                     LoanedItemsDetails_StockIn siv_si = new LoanedItemsDetails_StockIn();
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
                     lid.stockindetails.Add(siv_si);

                     if (QTY_Needed == 0)
                        break;
                  }
                  if (QTY_Needed != 0)
                  {
                     cUtil.ShowMessageExclamation(
                        "Insufficient stocks! Some of the items might be locked for selling!", "Add Item");
                     return;
                  }
                  ParentCtl.AddItem(lid);
                  UpdateDisplayNormal(lid);
               }
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
            cUtil.ShowMessageExclamation("Please select valid item!", "Add Item");
            return;
         }

         if (SelectedNode.ParentNode != null)
            ParentNode = SelectedNode.ParentNode;
         else
            ParentNode = SelectedNode;

         if (ValidateMiscItems(SelectedNode))
         {
            Int32 QTY1 = (Int32) cUtil.CheckValue(txtQTY1);
            double Price1 = cUtil.CheckValue(txtPrice1);

            StockInDetails sid = (StockInDetails) SelectedNode.GetValue(eCol.ItemObject.ToString());
            LoanedItemsDetails lid = new LoanedItemsDetails();
            lid.stockindetails = new List<LoanedItemsDetails_StockIn>();

            if (radioItems.SelectedIndex == 2)
            {
               //fab item
               lid.fabitem = sid.fabricateditem;
            }
            else if (radioItems.SelectedIndex == 3)
            {
               //trade item
               lid.tradeitem = sid.tradingitem;
            }

            lid.QTY1 = QTY1;
            lid.QTY2 = 0;
            lid.AgentPrice1 = Price1;
            lid.AgentPrice2 = 0;
            lid.AgentDiscount = txtDiscount.Text;
            lid.CustomerPrice1 = lid.AgentPrice1;
            lid.CustomerPrice2 = 0;
            lid.CustomerDiscount = lid.AgentDiscount;

            string temp = cUtil.ParseString(SelectedNode.GetValue(eCol.StockIn_ID.ToString()));
            Int32 StockInID = cUtil.ParseInt32(temp);

            //get stockin details
            Int32 QTY_OnHand1, QTY_InInvoice1, QTY_Avail1;
            if (StockInID > 0)
            {
               //only 1 StockInID affected
               LoanedItemsDetails_StockIn siv_si = new LoanedItemsDetails_StockIn();
               siv_si.QTY1 = QTY1;
               siv_si.QTY2 = 0;
               siv_si.SellingDiscount1 = sid.SellingDiscount1;
               siv_si.SellingDiscount2 = "";
               siv_si.SellingPrice1 = sid.SellingPrice1;
               siv_si.SellingPrice2 = 0;
               siv_si.stockindetails = sid;
               lid.stockindetails.Add(siv_si);
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
                     LoanedItemsDetails_StockIn siv_si = new LoanedItemsDetails_StockIn();
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
                     lid.stockindetails.Add(siv_si);

                     if (QTY_Needed == 0)
                        break;
                  }
               }
               if (QTY_Needed != 0)
               {
                  cUtil.ShowMessageExclamation("Insufficient stocks! Some of the items might be locked for selling!",
                                               "Add Item");
                  return;
               }
               ParentCtl.AddItem(lid);

               treeItems.BeginUnboundLoad();
               UpdateDisplayMiscItems(lid);
               treeItems.EndUnboundLoad();
            }
         }
      }

      private void AddBundledItem()
      {
         TreeListNode node = treeBundle.FocusedNode;
         if (node == null)
         {
            cUtil.ShowMessageError("Please select valid item!", "Add Bundled Item");
            return;
         }

         if (node.ParentNode != null)
            node = node.ParentNode;

         if (ValidateBundledItem(node))
         {
            Int32 QTY1 = (Int32) cUtil.CheckValue(txtQTY1);
            double Price1 = cUtil.CheckValue(txtPrice1);

            BundledItem bi = (BundledItem) node.GetValue(eColBundle.ItemObject.ToString());
            LoanedItemsDetails lid = new LoanedItemsDetails();
            lid.stockindetails = new List<LoanedItemsDetails_StockIn>();

            lid.bundleditem = bi;
            lid.QTY1 = QTY1;
            lid.QTY2 = 0;
            lid.AgentPrice1 = Price1;
            lid.AgentPrice2 = 0;
            lid.AgentDiscount = txtDiscount.Text;
            lid.CustomerPrice1 = lid.AgentPrice1;
            lid.CustomerPrice2 = 0;
            lid.CustomerDiscount = lid.AgentDiscount;

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
                        LoanedItemsDetails_StockIn siv_si = new LoanedItemsDetails_StockIn();
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
                        lid.stockindetails.Add(siv_si);
                     }
                     if (QTY_Needed == 0)
                        break;
                  }
                  if (QTY_Needed != 0)
                  {
                     cUtil.ShowMessageExclamation(
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
                        LoanedItemsDetails_StockIn siv_si = new LoanedItemsDetails_StockIn();
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
                        lid.stockindetails.Add(siv_si);
                     }
                     if (QTY_Needed == 0)
                        break;
                  }
                  if (QTY_Needed != 0)
                  {
                     cUtil.ShowMessageExclamation(
                        string.Format("Unable to add item. Insufficeint stock for item '{0}'!", bid.item.Name),
                        "Add Bundled Item");
                     return;
                  }
               }
               else
               {
                  cUtil.ShowMessageError("Invalid BundledItemDetails found!", "Add Bundled Item");
                  return;
               }
            }
            //evrything OK
            ParentCtl.AddItem(lid);
            UpdateDisplayBundledItem(node);
         }
      }

      private Int32 GetStockInDetailsQTY1InInvoice(StockInDetails sid)
      {
         Int32 QTY = 0;
         foreach (LoanedItemsDetails sivd in ParentCtl.m_LoanedItem.details)
         {
            foreach (LoanedItemsDetails_StockIn siv_si in sivd.stockindetails)
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
         QTY_InInvoice1 = cUtil.ParseInt32(cUtil.ParseString(node.GetValue(eCol.QTY1_InInvoice.ToString())));
         node.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - QTY1);

         if (QTY2 != 0)
         {
            QTY_InInvoice2 = cUtil.ParseInt32(cUtil.ParseString(node.GetValue(eCol.QTY2_InInvoice.ToString())));
            node.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice2 - (QTY1*QTY2));
         }

         if (node.ParentNode != null)
         {
            QTY_InInvoice1 =
               cUtil.ParseInt32(cUtil.ParseString(node.ParentNode.GetValue(eCol.QTY1_InInvoice.ToString())));
            node.ParentNode.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - QTY1);

            if (QTY2 != 0)
            {
               QTY_InInvoice2 =
                  cUtil.ParseInt32(cUtil.ParseString(node.ParentNode.GetValue(eCol.QTY2_InInvoice.ToString())));
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
               cUtil.ShowMessageExclamation("Cannot sell item. No selling price yet!", "Add Item");
               return false;
            }

            //is item locked?
            if (sid.Status == (int) StockInDetails.eStatus.Locked)
            {
               cUtil.ShowMessageExclamation("Cannot sell item. Item is locked!", "Add Item");
               return false;
            }
         }

         QTY1 = (Int32) cUtil.CheckValue(txtQTY1);
         QTY2 = (Int32) cUtil.CheckValue(txtQTY2);
         Price1 = cUtil.CheckValue(txtPrice1);
         Price2 = cUtil.CheckValue(txtPrice2);

         if (node.GetValue(eCol.QTY1_InInvoice.ToString()) == null)
            QTY_OnInvoice1 = 0;
         else
            QTY_OnInvoice1 = cUtil.ParseInt32(node.GetValue(eCol.QTY1_InInvoice.ToString()).ToString());

         if (node.GetValue(eCol.QTY2_InInvoice.ToString()) == null)
            QTY_OnInvoice2 = 0;
         else
            QTY_OnInvoice2 = cUtil.ParseInt32(node.GetValue(eCol.QTY2_InInvoice.ToString()).ToString());

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

            string temp = cUtil.ParseString(node.GetValue(eCol.OnHand1.ToString()));
            if (temp != null)
            {
               if (temp.Contains("rolls") || temp.Contains("mtrs"))
               {
                  string[] tmp = temp.Split(' ');
                  QTY_OnHand1 = cUtil.ParseInt32(tmp[0]);
               }
               else
               {
                  QTY_OnHand1 = cUtil.ParseInt32(temp);
               }
            }

            temp = cUtil.ParseString(node.GetValue(eCol.OnHand2.ToString()));
            if (temp != null)
            {
               if (temp.Contains("rolls") || temp.Contains("mtrs"))
               {
                  string[] tmp = temp.Split(' ');
                  QTY_OnHand2 = cUtil.ParseInt32(tmp[0]);
               }
               else
               {
                  QTY_OnHand2 = cUtil.ParseInt32(temp);
               }
            }
         }
         QTY_Available1 = QTY_OnHand1 + QTY_OnInvoice1;
         QTY_Available2 = QTY_OnHand2 + QTY_OnInvoice2;

         //validate discount
         if (txtDiscount.Text != "")
         {
            if (!cUtil.CheckFormula(txtDiscount.Text))
            {
               cUtil.ShowMessageExclamation("Invalid discount formula!", "Add Item");
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
               cUtil.ShowMessageExclamation("Invalid Quantity!", "Add Item");
               txtQTY1.Focus();
               return false;
            }

            if (QTY1 != 0)
            {
               //per roll sales
               if (QTY2 != sid.QTY2)
               {
                  //invalid qty for meters, should be equal to stockin meters/roll qty
                  cUtil.ShowMessageExclamation(
                     string.Format("Invalid meters / roll qty! Number of meters should be equal to {0}", sid.QTY2),
                     "Add Item");
                  txtQTY2.SelectAll();
                  txtQTY2.Focus();
                  return false;
               }

               if (QTY1 > QTY_Available1)
               {
                  cUtil.ShowMessageExclamation("Cannot add item. Insufficient stocks available!", "Add Item");
                  txtQTY1.Focus();
                  return false;
               }
            }
            else
            {
               //per meter sales
               if (QTY2 > sid.QTY2)
               {
                  cUtil.ShowMessageExclamation(
                     string.Format("Invalid quantity. Quantity should not be greater than '{0}'!", sid.QTY2), "Add Item");
                  txtQTY2.Focus();
                  return false;
               }

               if (wb != null)
               {
                  //get from incomplete roll
                  if (QTY2 > QTY_Available2)
                  {
                     cUtil.ShowMessageExclamation("Cannot add item. Insufficient stocks available!", "Add Item");
                     txtQTY2.Focus();
                     return false;
                  }
               }
               else
               {
                  //get suppply from full roll, make sure there is suffcient QTY1
                  if (QTY_Available1 <= 0)
                  {
                     cUtil.ShowMessageExclamation("Cannot add item. Insufficient stocks available!", "Add Item");
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
               cUtil.ShowMessageExclamation("Invalid QTY. Please input a number greater than '0'.", "Add Item");
               return false;
            }

            if (QTY_Available1 <= 0)
            {
               cUtil.ShowMessageExclamation("Cannot add item. Insufficient stocks available!", "Add Item");
               return false;
            }

            if (QTY1 > QTY_Available1)
            {
               cUtil.ShowMessageExclamation(
                  string.Format("Invalid QTY. Please input a number not greater than '{0}'!", QTY_Available1),
                  "Add Item");
               txtQTY1.SelectAll();
               txtQTY1.Focus();
               return false;
            }

            if (Price1 <= 0)
            {
               cUtil.ShowMessageExclamation("Invalid price!", "Add Item");
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
               cUtil.ShowMessageExclamation("Cannot sell item. No selling price yet!", "Add Item");
               return false;
            }

            //is item locked?
            if (sid.Status == (int) StockInDetails.eStatus.Locked)
            {
               cUtil.ShowMessageExclamation("Cannot sell item. Item is locked!", "Add Item");
               return false;
            }
         }

         QTY1 = (Int32) cUtil.CheckValue(txtQTY1);
         Price1 = cUtil.CheckValue(txtPrice1);

         QTY_OnHand1 = GetQTYOnHand(node, eCol.OnHand1.ToString());
         QTY_OnInvoice1 = GetQTYInInvoice(node, eCol.QTY1_InInvoice.ToString());
         QTY_Available1 = QTY_OnHand1 + QTY_OnInvoice1;

         //validate discount
         if (txtDiscount.Text != "")
         {
            if (!cUtil.CheckFormula(txtDiscount.Text))
            {
               cUtil.ShowMessageExclamation("Invalid discount formula!", "Add Item");
               txtDiscount.SelectAll();
               txtDiscount.Focus();
               return false;
            }
         }

         if (QTY1 <= 0)
         {
            cUtil.ShowMessageExclamation("Invalid QTY. Please input a number greater than '0'.", "Add Item");
            return false;
         }

         if (QTY_Available1 <= 0)
         {
            cUtil.ShowMessageExclamation("Cannot add item. Insufficient stocks available!", "Add Item");
            return false;
         }

         if (QTY1 > QTY_Available1)
         {
            cUtil.ShowMessageExclamation(
               string.Format("Invalid QTY. Please input a number not greater than '{0}'!", QTY_Available1), "Add Item");
            txtQTY1.SelectAll();
            txtQTY1.Focus();
            return false;
         }

         if (Price1 <= 0)
         {
            cUtil.ShowMessageExclamation("Invalid price!", "Add Item");
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


         Int32 QTY1 = (Int32) cUtil.CheckValue(txtQTY1);
         double Price = cUtil.CheckValue(txtPrice1);
         string Discount = txtDiscount.Text;

         if (QTY1 <= 0)
         {
            cUtil.ShowMessageExclamation("Invalid QTY!", "Add Bundled Item");
            txtQTY1.SelectAll();
            txtQTY1.Focus();
            return false;
         }

         if (Price <= 0)
         {
            cUtil.ShowMessageExclamation("Invalid Price!", "Add Bundled Item");
            txtPrice1.SelectAll();
            txtPrice1.Focus();
            return false;
         }

         if (Discount != "" && !cUtil.CheckFormula(Discount))
         {
            cUtil.ShowMessageExclamation("Invalid discount formula!", "Add Bundled Item");
            txtDiscount.SelectAll();
            txtDiscount.Focus();
            return false;
         }

         string status = cUtil.ParseString(node.GetValue(eColBundle.Stocks.ToString()));
         if (status != "" && status == "Not Available")
         {
            cUtil.ShowMessageExclamation("Cannot add item. Not enough stocks available!", "Add Bundled Item");
            return false;
         }
         else
         {
            //check if stocks are sufficient
            Int32 QTY_OnHand, QTY_Invoice, QTY_Avail;

            foreach (TreeListNode childnode in node.Nodes)
            {
               QTY_OnHand = cUtil.ParseInt32(childnode.GetValue(eColBundle.Stocks.ToString()).ToString());
               QTY_Invoice = cUtil.ParseInt32(childnode.GetValue(eColBundle.QTY_InInvoice.ToString()).ToString());
               QTY_Avail = QTY_OnHand + QTY_Invoice;

               BundledItemDetails bid = (BundledItemDetails) childnode.GetValue(eColBundle.ItemObject.ToString());
               if ((QTY1*bid.QTY) > QTY_Avail)
               {
                  if (bid.item != null)
                     cUtil.ShowMessageExclamation(
                        string.Format("Cannot add item. Not enough stocks available for item {0}!", bid.item.Name),
                        "Add Bundled Item");
                  else if (bid.FabItem != null)
                     cUtil.ShowMessageExclamation(
                        string.Format("Cannot add item. Not enough stocks available for item {0}!", bid.FabItem.Name),
                        "Add Bundled Item");
                  else
                     cUtil.ShowMessageExclamation("Cannot add item. Not enough stocks available!", "Add Bundled Item");
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

      private void UpdateDisplayNormal(LoanedItemsDetails lid)
      {
         Int32 QTY_InInvoice1, QTY_InInvoice2, StockInID;

         foreach (LoanedItemsDetails_StockIn lid_si in lid.stockindetails)
         {
            if (lid_si.wirebreakdown != null)
            {int breakdownID = lid_si.wirebreakdown.BreakDownID;
               if (breakdownID == 0)
                  breakdownID = lid_si.wirebreakdown.BreakDownID_Source;

               TreeListNode node = GetTargetNodeNormal(lid.item.ID, lid_si.stockindetails,
                                                       breakdownID);
               if (node != null)
               {
                  QTY_InInvoice2 = GetQTYInInvoice(node, eCol.QTY2_InInvoice.ToString());
                  node.SetValue(eCol.QTY2_InInvoice.ToString(), QTY_InInvoice2 - lid_si.QTY2);

                  //update wb parent (node with StockIn no.)
                  TreeListNode parentNode = node.ParentNode;
                  QTY_InInvoice2 = GetQTYInInvoice(parentNode, eCol.QTY2_InInvoice.ToString());
                  parentNode.SetValue(eCol.QTY2_InInvoice.ToString(), QTY_InInvoice2 - lid_si.QTY2);

                  //update [xxx mtrs/roll] node
                  parentNode = parentNode.ParentNode;
                  QTY_InInvoice2 = GetQTYInInvoice(parentNode, eCol.QTY2_InInvoice.ToString());
                  parentNode.SetValue(eCol.QTY2_InInvoice.ToString(), QTY_InInvoice2 - lid_si.QTY2);

                  //update main node [Item]
                  parentNode = parentNode.ParentNode;
                  QTY_InInvoice2 = GetQTYInInvoice(parentNode, eCol.QTY2_InInvoice.ToString());
                  parentNode.SetValue(eCol.QTY2_InInvoice.ToString(), QTY_InInvoice2 - lid_si.QTY2);
               }
               else
               {
                  //new wire breakdown
                  TreeListNode node_si = GetTargetNodeNormal(lid.item.ID, lid_si.stockindetails, 0);

                  TreeListNode node_temp = treeItems.AppendNode(null, node_si);
                  node_temp.SetValue(eCol.StockIn_ID.ToString(),
                                     string.Format("[Roll ID#] {0}", lid_si.wirebreakdown.BreakDownID.ToString("000")));
                  node_temp.SetValue(eCol.ItemObject.ToString(), lid_si.stockindetails);
                  node_temp.SetValue(eCol.WireBreakdown.ToString(), lid_si.wirebreakdown);
                  node_temp.SetValue(eCol.OnHand1.ToString(), "0 roll");
                  node_temp.SetValue(eCol.OnHand2.ToString(), lid_si.stockindetails.QTY2);
                  node_temp.SetValue(eCol.QTY2_InInvoice.ToString(), lid_si.QTY2*-1);
                  //treeItems.SetNodeIndex(node_temp, index);

                  QTY_InInvoice1 = GetQTYInInvoice(node_si, eCol.QTY1_InInvoice.ToString());
                  QTY_InInvoice2 = GetQTYInInvoice(node_si, eCol.QTY2_InInvoice.ToString());
                  node_si.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - 1);
                  node_si.SetValue(eCol.QTY2_InInvoice.ToString(), QTY_InInvoice2 - lid_si.QTY2);

                  TreeListNode ParentNode = node_si.ParentNode;
                  QTY_InInvoice1 = GetQTYInInvoice(ParentNode, eCol.QTY1_InInvoice.ToString());
                  QTY_InInvoice2 = GetQTYInInvoice(ParentNode, eCol.QTY2_InInvoice.ToString());
                  ParentNode.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - 1);
                  ParentNode.SetValue(eCol.QTY2_InInvoice.ToString(), QTY_InInvoice2 - lid_si.QTY2);

                  ParentNode = ParentNode.ParentNode;
                  QTY_InInvoice1 = GetQTYInInvoice(ParentNode, eCol.QTY1_InInvoice.ToString());
                  QTY_InInvoice2 = GetQTYInInvoice(ParentNode, eCol.QTY2_InInvoice.ToString());
                  ParentNode.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - 1);
                  ParentNode.SetValue(eCol.QTY2_InInvoice.ToString(), QTY_InInvoice2 - lid_si.QTY2);
               }
            }
            else
            {
               if (lid.item != null)
               {
                  TreeListNode node = GetTargetNodeNormal(lid.item.ID, lid_si.stockindetails, 0);
                  if (node != null)
                  {
                     QTY_InInvoice1 = GetQTYInInvoice(node, eCol.QTY1_InInvoice.ToString());
                     QTY_InInvoice2 = GetQTYInInvoice(node, eCol.QTY2_InInvoice.ToString());
                     node.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - lid_si.QTY1);
                     if (lid.item.IsWire)
                     {
                        node.SetValue(eCol.QTY2_InInvoice.ToString(), QTY_InInvoice2 - lid_si.QTY1*lid_si.QTY2);
                     }
                     QTY_InInvoice1 = GetQTYInInvoice(node.ParentNode, eCol.QTY1_InInvoice.ToString());
                     QTY_InInvoice2 = GetQTYInInvoice(node.ParentNode, eCol.QTY2_InInvoice.ToString());
                     node.ParentNode.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - lid_si.QTY1);
                     if (lid.item.IsWire)
                     {
                        node.ParentNode.SetValue(eCol.QTY2_InInvoice.ToString(),
                                                 QTY_InInvoice2 - lid_si.QTY1*lid_si.QTY2);

                        QTY_InInvoice1 = GetQTYInInvoice(node.ParentNode.ParentNode, eCol.QTY1_InInvoice.ToString());
                        node.ParentNode.ParentNode.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - lid_si.QTY1);
                        QTY_InInvoice2 = GetQTYInInvoice(node.ParentNode.ParentNode, eCol.QTY2_InInvoice.ToString());
                        node.ParentNode.ParentNode.SetValue(eCol.QTY2_InInvoice.ToString(),
                                                            QTY_InInvoice2 - lid_si.QTY1*lid_si.QTY2);
                     }
                  }
                  else
                  {
                     //?
                  }
               }
               else if (lid.bundleditem != null)
               {
                  foreach (BundledItemDetails bid in lid.bundleditem.details)
                  {
                     if (bid.item != null)
                     {
                        TreeListNode node = GetTargetNodeNormal(bid.item.ID, lid_si.stockindetails, 0);
                        if (node != null)
                        {
                           QTY_InInvoice1 = GetQTYInInvoice(node, eCol.QTY1_InInvoice.ToString());
                           QTY_InInvoice2 = GetQTYInInvoice(node, eCol.QTY2_InInvoice.ToString());
                           node.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - lid_si.QTY1);
                           if (bid.item.IsWire)
                           {
                              node.SetValue(eCol.QTY2_InInvoice.ToString(), QTY_InInvoice2 - lid_si.QTY1*lid_si.QTY2);
                           }
                           QTY_InInvoice1 = GetQTYInInvoice(node.ParentNode, eCol.QTY1_InInvoice.ToString());
                           QTY_InInvoice2 = GetQTYInInvoice(node.ParentNode, eCol.QTY2_InInvoice.ToString());
                           node.ParentNode.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - lid_si.QTY1);
                           if (bid.item.IsWire)
                           {
                              node.ParentNode.SetValue(eCol.QTY2_InInvoice.ToString(),
                                                       QTY_InInvoice2 - lid_si.QTY1*lid_si.QTY2);

                              QTY_InInvoice1 = GetQTYInInvoice(node.ParentNode.ParentNode,
                                                               eCol.QTY1_InInvoice.ToString());
                              node.ParentNode.ParentNode.SetValue(eCol.QTY1_InInvoice.ToString(),
                                                                  QTY_InInvoice1 - lid_si.QTY1);
                              QTY_InInvoice2 = GetQTYInInvoice(node.ParentNode.ParentNode,
                                                               eCol.QTY2_InInvoice.ToString());
                              node.ParentNode.ParentNode.SetValue(eCol.QTY2_InInvoice.ToString(),
                                                                  QTY_InInvoice2 - lid_si.QTY1*lid_si.QTY2);
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

      private void UpdateDisplayMiscItems(LoanedItemsDetails lid)
      {
         Int32 QTY_InInvoice1, QTY_InInvoice2;

         foreach (LoanedItemsDetails_StockIn lid_si in lid.stockindetails)
         {
            TreeListNode node = GetTargetNodeMiscItems(lid.fabitem.ID, lid_si.stockindetails);
            if (node != null)
            {
               QTY_InInvoice1 = GetQTYInInvoice(node, eCol.QTY1_InInvoice.ToString());
               QTY_InInvoice2 = GetQTYInInvoice(node, eCol.QTY2_InInvoice.ToString());
               node.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - lid_si.QTY1);

               QTY_InInvoice1 = GetQTYInInvoice(node.ParentNode, eCol.QTY1_InInvoice.ToString());
               QTY_InInvoice2 = GetQTYInInvoice(node.ParentNode, eCol.QTY2_InInvoice.ToString());
               node.ParentNode.SetValue(eCol.QTY1_InInvoice.ToString(), QTY_InInvoice1 - lid_si.QTY1);
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
         Int32 QTY1 = (Int32) cUtil.CheckValue(txtQTY1);
         treeBundle.BeginUnboundLoad();
         foreach (TreeListNode childnode in node.Nodes)
         {
            BundledItemDetails bid = (BundledItemDetails) childnode.GetValue(eColBundle.ItemObject.ToString());
            Int32 QTY_Invoice =
               cUtil.ParseInt32(cUtil.ParseString(childnode.GetValue(eColBundle.QTY_InInvoice.ToString())));
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
         return cUtil.ParseInt32(cUtil.ParseString(node.GetValue(ColName)));
      }

      private Int32 GetQTYInInvoice(TreeListNode node, string ColName)
      {
         return cUtil.ParseInt32(cUtil.ParseString(node.GetValue(ColName)));
      }

      private Int32 GetStockInID(TreeListNode node)
      {
         return cUtil.ParseInt32(cUtil.ParseString(node.GetValue(eCol.StockIn_ID.ToString())));
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
   }
}