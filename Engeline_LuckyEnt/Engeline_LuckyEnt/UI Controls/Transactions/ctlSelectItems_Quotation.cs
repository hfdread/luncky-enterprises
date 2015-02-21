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
   public partial class ctlSelectItems_Quotation : UserControl
   {
      private StockInDetailsDao StockInDetailsDao = new StockInDetailsDao();
      private ItemDao ItemDao = new ItemDao();
      private BundledItemDao BundledItemDao = new BundledItemDao();
      private TradingItemDao TradeItemDao = new TradingItemDao();
      private FabricatedItemDao FabItemDao = new FabricatedItemDao();

      public ctlQuotation ParentCtl { get; set; }
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

      public ctlSelectItems_Quotation()
      {
         InitializeComponent();
      }

      private void ctlSelectItems_Quotation_Load(object sender, EventArgs e)
      {
         radioItems_SelectedIndexChanged(null, null);
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
            }
            else if (radioItems.SelectedIndex == 3)
            {
               //trading items
               Condition = cUtil.GenerateFilterCondition(txtSearch.Text);
               Condition = string.Format("sid.tradingitem.Name like '{0}' or sid.tradingitem.Description like '{0}'",
                                         Condition);
               SearchTradingItems(Condition);
            }
         }
      }

      private void SearchNormalItems(string Condition)
      {
         IList<StockInDetails> lst = StockInDetailsDao.GetAvailableStocks(Condition, true, false, false);

         treeItems.Nodes.Clear();
         int ItemID = 0;
         TreeListNode ParentNode = null, ChildNode = null, ParentWireNode = null;

         treeItems.BeginUnboundLoad();
         foreach (StockInDetails sid in lst)
         {
            if (ItemID != sid.item.ID)
            {
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
                     ChildNode = treeItems.AppendNode(null, ParentWireNode);
                     ChildNode.SetValue(eCol.ItemObject.ToString(), sid);
                     ChildNode.SetValue(eCol.WireBreakdown.ToString(), wb);

                     //ChildNode.SetValue(eCol.ItemName.ToString(), "[Wire Breakdown]");
                     ChildNode.SetValue(eCol.StockIn_ID.ToString(),
                                        string.Format("[Roll ID#] {0}", wb.ID.ToString("000")));
                     ChildNode.SetValue(eCol.OnHand1.ToString(), string.Format("{0} roll", 0));
                     ChildNode.SetValue(eCol.OnHand2.ToString(), string.Format("{0} mtrs", wb.QTY_OnHand));

                     //set icon for Locked items
                     if (sid.Status == (int) StockInDetails.eStatus.Locked)
                        ChildNode.StateImageIndex = 0;
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

         Int32 QTY1, QTY2;
         double Price1, Price2;

         QTY1 = (Int32) cUtil.CheckValue(txtQTY1);
         QTY2 = (Int32) cUtil.CheckValue(txtQTY2);
         Price1 = cUtil.CheckValue(txtPrice1);
         Price2 = cUtil.CheckValue(txtPrice2);

         StockInDetails sid = (StockInDetails) SelectedNode.GetValue(eCol.ItemObject.ToString());
         QuotationDetails QD = new QuotationDetails();

         QD.item = sid.item;
         QD.QTY1 = QTY1;
         QD.QTY2 = QTY2;
         QD.AgentPrice1 = Price1;
         QD.AgentPrice2 = Price2;
         QD.AgentDiscount = txtDiscount.Text;
         QD.CustomerPrice1 = QD.AgentPrice1;
         QD.CustomerPrice2 = QD.AgentPrice2;
         QD.CustomerDiscount = QD.AgentDiscount;

         ParentCtl.AddItem(QD);
         CheckSelectedNode(SelectedNode);
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

         Int32 QTY1 = (Int32) cUtil.CheckValue(txtQTY1);
         double Price1 = cUtil.CheckValue(txtPrice1);

         StockInDetails sid = (StockInDetails) SelectedNode.GetValue(eCol.ItemObject.ToString());
         QuotationDetails QD = new QuotationDetails();

         if (radioItems.SelectedIndex == 2)
         {
            //fab item
            QD.fabitem = sid.fabricateditem;
         }
         else if (radioItems.SelectedIndex == 3)
         {
            //trade item
            QD.tradeitem = sid.tradingitem;
         }

         QD.QTY1 = QTY1;
         QD.QTY2 = 0;
         QD.AgentPrice1 = Price1;
         QD.AgentPrice2 = 0;
         QD.AgentDiscount = txtDiscount.Text;
         QD.CustomerPrice1 = QD.AgentPrice1;
         QD.CustomerPrice2 = 0;
         QD.CustomerDiscount = QD.AgentDiscount;

         ParentCtl.AddItem(QD);
         CheckSelectedNode(SelectedNode);
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

         Int32 QTY1 = (Int32) cUtil.CheckValue(txtQTY1);
         double Price1 = cUtil.CheckValue(txtPrice1);

         BundledItem bi = (BundledItem) node.GetValue(eColBundle.ItemObject.ToString());
         QuotationDetails QD = new QuotationDetails();

         QD.bundleditem = bi;
         QD.QTY1 = QTY1;
         QD.QTY2 = 0;
         QD.AgentPrice1 = Price1;
         QD.AgentPrice2 = 0;
         QD.AgentDiscount = txtDiscount.Text;
         QD.CustomerPrice1 = QD.AgentPrice1;
         QD.CustomerPrice2 = 0;
         QD.CustomerDiscount = QD.AgentDiscount;

         ParentCtl.AddItem(QD);
         CheckSelectedBundledItem();
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
                                 txtQTY1.Text = "0";
                                 txtQTY1.Enabled = false;
                                 txtPrice1.Enabled = false;

                                 txtQTY2.Text = (sid.QTY2 + QTY_OnInvoice2).ToString();
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

      private void treeItems_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
      {
         CheckSelectedNode(e.Node);
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

      private void treeBundle_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
      {
         CheckSelectedBundledItem();
      }

      private void treeBundle_BeforeExpand(object sender, BeforeExpandEventArgs e)
      {
         CheckBundledItemStocks(e.Node);
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         Canceled = true;
         this.ParentForm.Close();
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
   }
}