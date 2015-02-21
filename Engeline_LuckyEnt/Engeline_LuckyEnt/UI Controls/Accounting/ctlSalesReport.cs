#region

using System.Windows.Forms;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using DexterHardware_v2.Classes;
using DexterHardware_v2.Reports;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
#endregion

namespace DexterHardware_v2.UI_Controls.Accounting
{
   public partial class ctlSalesReport : UserControl
   {
      private SalesInvoiceDao mInvoiceDao = new SalesInvoiceDao();
      private SalesInvoiceWithDetailsDao mInvoiceWithDetailsDao = new SalesInvoiceWithDetailsDao();
      private ContactsDao mContactsDao = new ContactsDao();
      
      private enum eCol
      {
         Customer=0,
         Item,
         QTY,
         Capital,
         Freight,
         SellingPrice,
         AgentPrice,
         CustomerPrice,
         PriceUp,
         GrossSales,
         Profit,
         ItemObject
      }

      private enum eCol2
      {
         AgentID=0,
         AgentName,
         Period,
         FixedSales,
         PerItemSales,
         FabSales,
         TradingSales,
         MiscSales,
         FixCom,
         PerItemCom,
         ItemObject
      }

      public ctlSalesReport()
      {
         InitializeComponent();
      }

      private void ctlSalesReport_Load(object sender, System.EventArgs e)
      {
         LoadCustomers();
         LoadAgents();
         dtDateRange.DisableCustomDate();
         dtDateRange.SetDateSelection(ctlDateRange.eDateSelection.ThisMonth);
      }

      private  void LoadCustomers()
      {
         IList<Contacts> lst = mContactsDao.getAllCustomers();
         cboCustomer.Properties.Items.Add("[All]");
         foreach (Contacts cu in lst)
         {
            cboCustomer.Properties.Items.Add(cu);
         }
         cboCustomer.SelectedIndex = 0;
      }

      private void LoadAgents()
      {
         IList<Contacts> lst = mContactsDao.getAllAgents();
         cboAgent.Properties.Items.Add("[All]");
         foreach (Contacts cu in lst)
         {
            cboAgent.Properties.Items.Add(cu);
         }
         cboAgent.SelectedIndex = 0;
      }

      private void btnRefresh_Click(object sender, System.EventArgs e)
      {
         string sOrder = "ORDER BY si.Customer.ID, si.ID";
         int custID = 0;

         if (cboAgent.SelectedIndex > 0)
         {
            Contacts agent = (Contacts) cboAgent.SelectedItem;
            IList<Contacts> lst = mContactsDao.getAllCustomersByAgent(agent.ID);
            string cust = "";
            if(lst.Count>0)
            {
               foreach (Contacts cu in lst)
               {
                  if (cust != "")
                     cust += ",";

                  cust += cu.ID;
               }

               IList<SalesInvoiceWithDetails> lstInvoice = mInvoiceWithDetailsDao.getAllRecordsWithDetails(cust, dtDateRange.getDateFrom(), dtDateRange.getDateTo(), 0, sOrder);
               ShowReport(lstInvoice);
            }
            else{
               cUtil.ShowMessageExclamation("Selected agent has no handled customers!", "Sales Report");
            }
         }
         else
         {
            if(cboCustomer.SelectedIndex>0)
            {
               Contacts cu = (Contacts) cboCustomer.SelectedItem;
               custID = cu.ID;
            }

            IList<SalesInvoiceWithDetails> lstInvoice = mInvoiceWithDetailsDao.getAllRecordsWithDetails(custID, dtDateRange.getDateFrom(), dtDateRange.getDateTo(), 0, sOrder);
            ShowReport(lstInvoice);
         }
      }

      private void ShowReport(IList<SalesInvoiceWithDetails> lst)
      {
         int lastCustID = 0;
         double grossSales = 0, profit = 0, _profit = 0, _capital = 0;
         TreeListNode parentNode = null;
         IList<int> lstAgents = new List<int>();
         treeItems.BeginUnboundLoad();
         treeItems.Nodes.Clear();
         foreach (SalesInvoiceWithDetails si in lst)
         {
            if(lastCustID!=si.Customer.ID)
            {
               lastCustID = si.Customer.ID;
               parentNode = treeItems.AppendNode(null, null);

               parentNode.SetValue((int) eCol.Customer, si.Customer);
               parentNode.SetValue((int) eCol.GrossSales, 0);
               parentNode.SetValue((int)eCol.Profit, 0);

               grossSales = profit = 0;

               if(si.Customer.Agent!=null)
               {
                  if (lstAgents.IndexOf(si.Customer.Agent.ID) == -1)
                     lstAgents.Add(si.Customer.Agent.ID);
               }
            }

            TreeListNode child = treeItems.AppendNode(null, parentNode);
            child.SetValue((int) eCol.Customer, si.ID.ToString(cUtil.FMT_ID));
            child.SetValue((int)eCol.Item, string.Format("[{0}]",si.AmountDue.ToString(cUtil.FMT_AMOUNT)));
            child.SetValue((int)eCol.Capital, 0);
            child.SetValue((int)eCol.GrossSales, si.AmountDue);
            child.SetValue((int)eCol.Profit, 0);
            child.SetValue((int)eCol.ItemObject, si);

            //update parent
            grossSales += si.AmountDue;
            parentNode.SetValue((int)eCol.GrossSales, grossSales);

            //add details
            _profit = _capital = 0;
            foreach (SalesInvoiceDetails sivd in si.details)
            {
               double agentPrice = 0, customerPrice = 0, capital = 0, qty = 0;

               TreeListNode child2 = treeItems.AppendNode(null, child);
               if(sivd.item!=null)
                  child2.SetValue((int)eCol.Item, sivd.item.Name);
               else if(sivd.bundleditem!=null)
               {
                  child2.SetValue((int)eCol.Item, sivd.bundleditem.Name);
                  //show details?
               }
               else if(sivd.tradeitem!=null)
                  child2.SetValue((int)eCol.Item, sivd.tradeitem.Name);
               else if(sivd.fabitem!=null)
                  child2.SetValue((int)eCol.Item, sivd.fabitem.Name);

               //qty
               if(sivd.QTY1==0)
               {
                  qty = sivd.QTY2;
                  child2.SetValue((int)eCol.QTY, qty);

                  //capital
                  capital = cUtil.DiscountAmt(sivd.stockindetails[0].stockindetails.Price2, sivd.stockindetails[0].stockindetails.Discount);
                  child2.SetValue((int)eCol.Capital, capital);
                  
                  //selling price
                  child2.SetValue((int)eCol.SellingPrice, cUtil.DiscountAmt(sivd.stockindetails[0].stockindetails.Price2, sivd.stockindetails[0].stockindetails.SellingDiscount2));

                  //Agent price
                  agentPrice = cUtil.DiscountAmt(sivd.AgentPrice2, sivd.AgentDiscount);
                  child2.SetValue((int)eCol.AgentPrice, agentPrice);

                  //customer price
                  customerPrice = cUtil.DiscountAmt(sivd.CustomerPrice2, sivd.CustomerDiscount);
                  child2.SetValue((int)eCol.CustomerPrice, customerPrice);
               }
               else
               {
                  qty = sivd.QTY1;
                  child2.SetValue((int)eCol.QTY, qty);

                  //capital
                  capital = cUtil.DiscountAmt(sivd.stockindetails[0].stockindetails.Price1, sivd.stockindetails[0].stockindetails.Discount);
                  child2.SetValue((int)eCol.Capital, capital);

                  //selling price
                  child2.SetValue((int)eCol.SellingPrice, cUtil.DiscountAmt(sivd.stockindetails[0].stockindetails.Price1, sivd.stockindetails[0].stockindetails.SellingDiscount1));

                  //Agent price
                  agentPrice = cUtil.DiscountAmt(sivd.AgentPrice1, sivd.AgentDiscount);
                  child2.SetValue((int)eCol.AgentPrice, agentPrice);

                  //customer price
                  customerPrice = cUtil.DiscountAmt(sivd.CustomerPrice1, sivd.CustomerDiscount);
                  child2.SetValue((int)eCol.CustomerPrice, customerPrice);
               }

               //price up
               if(agentPrice!=customerPrice)
               child2.SetValue((int)eCol.PriceUp, customerPrice - agentPrice);

               //gross sales
               child2.SetValue((int)eCol.GrossSales, qty * customerPrice);

               //profit
               child2.SetValue((int)eCol.Profit, qty * (agentPrice - capital));
               _profit += qty * (agentPrice - capital);

               //update immediate parent
               child.SetValue((int)eCol.Profit, _profit);

               _capital += (qty * capital);child.SetValue((int)eCol.Capital, _capital);
               

               profit += qty*(agentPrice - capital);
            }

            //update main parent
            parentNode.SetValue((int) eCol.Profit, profit);
         }
         treeItems.EndUnboundLoad();

         //load Agent Commissions
         treeCommission.BeginUnboundLoad();
         treeCommission.Nodes.Clear();

         if(lstAgents.Count>0)
         {
            string sAgents = "";
            foreach (int id in lstAgents)
            {
               if (sAgents != "")
                  sAgents += ",";

               sAgents += id.ToString();
            }

            AgentCommissionDao dao = new AgentCommissionDao();
            IList<AgentCommission> lstAC = dao.getAllRecordsByCriteria(sAgents, dtDateRange.getDateFrom(), dtDateRange.getDateTo(), "ac.Agent.ID,ac.Invoice.InvoiceDate");

            TreeListNode _parent = null;
            lastCustID = 0;
            foreach (AgentCommission ac in lstAC)
            {
               if(lastCustID!=ac.Agent.ID)
               {
                  //new entry
                  lastCustID = ac.Agent.ID;
                  _parent = treeCommission.AppendNode(null, null);
                  _parent.SetValue((int)eCol2.AgentID, ac.Agent.ID);
                  _parent.SetValue((int)eCol2.AgentName, ac.Agent.ToString());
                  _parent.SetValue((int)eCol2.ItemObject, ac);

                  double fixedsales = 0, peritemSales = 0, fabSales = 0, tradeSales = 0, miscSale = 0;

                  TreeListNode child = null;
                  foreach (TreeListNode node in _parent.Nodes)
                  {
                     if(node.GetValue((int)eCol2.Period).ToString()== ac.Invoice.InvoiceDate.ToString("MMMM"))
                     {
                        child = node;
                        break;
                     }
                  }

                  if(child==null)
                  {
                     child = treeCommission.AppendNode(null, _parent);
                     child.SetValue((int) eCol2.Period, ac.Invoice.InvoiceDate.ToString("MMMM"));
                     child.SetValue((int)eCol2.FixedSales, 0);
                     child.SetValue((int)eCol2.PerItemSales, 0);
                     child.SetValue((int)eCol2.FabSales, 0);
                     child.SetValue((int)eCol2.TradingSales, 0);
                     child.SetValue((int)eCol2.MiscSales, 0);
                     fixedsales = peritemSales = fabSales = tradeSales = miscSale = 0;
                  }
                  else
                  {
                     fixedsales = cUtil.ParseDouble(child.GetValue((int) eCol2.FixedSales));
                     peritemSales = cUtil.ParseDouble(child.GetValue((int)eCol2.PerItemSales));
                     fabSales = cUtil.ParseDouble(child.GetValue((int)eCol2.FabSales));
                     tradeSales = cUtil.ParseDouble(child.GetValue((int)eCol2.TradingSales));
                     miscSale = cUtil.ParseDouble(child.GetValue((int)eCol2.MiscSales));
                  }

                  fixedsales += ac.SalesTotal;
                  peritemSales += ac.SalesItem;
                  fabSales += ac.SalesFab;
                  tradeSales += ac.SalesTrading;
                  miscSale += ac.SalesMiscItems;

                  child.SetValue((int)eCol2.FixedSales, fixedsales);
                  child.SetValue((int)eCol2.PerItemSales, peritemSales);
                  child.SetValue((int)eCol2.FabSales, fabSales);
                  child.SetValue((int)eCol2.TradingSales, tradeSales);
                  child.SetValue((int)eCol2.MiscSales, miscSale);
               }
            }
         }
         treeCommission.ExpandAll();
         treeCommission.EndUnboundLoad();

         //calculate commissions
         //foreach (TreeListNode node in treeCommission.Nodes)
         //{
         //   AgentCommission ac = (AgentCommission) node.GetValue((int) eCol2.ItemObject);
         //   AgentQuotaDao dao = new AgentQuotaDao();
         //   IList<AgentQuota> m_lstQuota = dao.GetAllRecordsByField("Agent.ID", ac.Agent.ID);

         //   foreach (TreeListNode node2 in node.Nodes)
         //   {
         //      double fixsales = cUtil.ParseDouble(node2.GetValue((int) eCol2.FixedSales));

         //      //determine quota for fixed sales
         //      AgentQuota quota = null;
         //      foreach (AgentQuota ac2 in m_lstQuota)
         //      {
         //         if (fixsales >= ac2.Quota)
         //            quota = ac2;}

         //      if(quota!=null)
         //      {
         //         //sales reached quota
         //         node2.SetValue((int) eCol2.FixCom, quota.FixSalesDetails.Commission);
         //      }

         //      //determine per item commission
         //      double peritemsales = cUtil.ParseDouble(node2.GetValue((int)eCol2.PerItemSales));


         //   }
         //}

         //get totals
         grossSales = profit = 0;
         foreach (TreeListNode node in treeItems.Nodes)
         {
            grossSales += cUtil.ParseDouble(node.GetValue((int) eCol.GrossSales));
            profit += cUtil.ParseDouble(node.GetValue((int)eCol.Profit));
         }

         lblTotalSales.Text = grossSales.ToString(cUtil.FMT_AMOUNT);
         lblProfit.Text = profit.ToString(cUtil.FMT_AMOUNT);


      }

      private void cboAgent_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         if(cboAgent.SelectedIndex>0)
         {
            cboCustomer.SelectedIndex = 0;
         }
      }

      private void btnPrintReport_Click(object sender, System.EventArgs e)
      {
         IList<SalesReportDetails> lst = new List<SalesReportDetails>();

         foreach (TreeListNode node in treeItems.Nodes)
         {
            foreach (TreeListNode node2 in node.Nodes)
            {
               SalesReportDetails det = new SalesReportDetails();
               SalesInvoiceWithDetails si = (SalesInvoiceWithDetails) node2.GetValue((int) eCol.ItemObject);

               det.InvoiceID = si.ID;
               det.InvoiceDate = si.InvoiceDate;
               det.Customer = si.Customer.ToString();
               det.ReceiptNo = si.ReceiptNumber;
               det.Capital = cUtil.ParseDouble(node2.GetValue((int) eCol.Capital));
               det.GrossSales = cUtil.ParseDouble(node2.GetValue((int)eCol.GrossSales));
               det.Profit = cUtil.ParseDouble(node2.GetValue((int)eCol.Profit));
               lst.Add(det);
            }
         }

         rptSalesReport rpt = new rptSalesReport();
         rpt.lblDate.Text = dtDateRange.GetDateRange();
         rpt.DataSource = lst;
         rpt.ShowPreviewDialog();}
   }
}
