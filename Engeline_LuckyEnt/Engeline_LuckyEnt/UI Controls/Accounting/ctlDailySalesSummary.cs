#region

using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using DexterHardware_v2.Classes;
#endregion

namespace DexterHardware_v2.UI_Controls
{
   public partial class ctlDailySalesSummary : UserControl
   {
      private readonly SalesInvoiceDao m_invoiceDao = new SalesInvoiceDao();
      private readonly ReturnedItemsDao m_returnDao = new ReturnedItemsDao();

      private enum eCol
      {
         Group=0,
         SIV_ID,
         ReceiptNo,
         Date,
         Customer,
         Amount,
         Canceled,
         ItemObject
      }

      private enum eColP
      {
         Group = 0,
         Date,
         Customer,
         Bank,
         CheckNo,
         AccountNo,
         Status,
         CheckDate,
         Amount,
         Canceled,
         ItemObject
      }

      private bool m_bIsLoading = true;

      public ctlDailySalesSummary()
      {
         InitializeComponent();
      }

      private void btnRefresh_Click(object sender, System.EventArgs e)
      {
         if (m_bIsLoading)
            return;

         treeInvoice.BeginUnboundLoad();
         treeInvoice.Nodes.Clear();

         //load invoices
         IList<SalesInvoice> lstInvoice = m_invoiceDao.getAllRecordsByCriteria(0, dtDateRange.getDateFrom(),
                                                                               dtDateRange.getDateTo(), -1);
         LoadInvoices(lstInvoice);

         //load Returns
         IList<ReturnedItems> lstRI = m_returnDao.GetAllRecordsByDateRange(dtDateRange.getDateFrom(),
                                                                           dtDateRange.getDateTo(), true);
         LoadReturns(lstRI);

         treeInvoice.ExpandAll(); treeInvoice.EndUnboundLoad();

         //load payments
         PaymentsDao pDao = new PaymentsDao();
         IList<Payments> lstPayments = pDao.GetAllRecordsByDateRange("PaymentDate", dtDateRange.getDateFrom(),
                                                                     dtDateRange.getDateTo());
         LoadPayments(lstPayments);
      }

      private void LoadPayments(IEnumerable<Payments> lst )
      {
         double totalPDC = 0, totalCash = 0, totalWithholding = 0;

         treePayments.BeginUnboundLoad();
         treePayments.Nodes.Clear();

         //add parent nodes
         TreeListNode nodePDC = treePayments.AppendNode(null, null);
         nodePDC.SetValue(eColP.Group.ToString(),"PDC Payments");
         nodePDC.SetValue(eColP.Status.ToString(), "Total");
         nodePDC.SetValue(eColP.Amount.ToString(), 0);

         TreeListNode nodeCash = treePayments.AppendNode(null, null);
         nodeCash.SetValue(eColP.Group.ToString(), "Cash Payments");
         nodeCash.SetValue(eColP.Status.ToString(), "Total");
         nodeCash.SetValue(eColP.Amount.ToString(), 0);

         TreeListNode nodeW = treePayments.AppendNode(null, null);
         nodeW.SetValue(eColP.Group.ToString(), "Withholding");
         nodeW.SetValue(eColP.Status.ToString(), "Total");
         nodeW.SetValue(eColP.Amount.ToString(), 0);

         double amount = 0;
         foreach(Payments p in lst)
         {
            amount = p.Canceled ? 0 : p.Amount;

            TreeListNode node = null;
            if(p.PaymentType==(int)Payments.ePaymentType.PDC)
            {
               node = treePayments.AppendNode(null, nodePDC);
               totalPDC += amount;
            }
            else if(p.PaymentType==(int)Payments.ePaymentType.Cash)
            {
               node = treePayments.AppendNode(null, nodeCash);
               totalCash += amount;
            }
            else
            {
               node = treePayments.AppendNode(null, nodeW);
               totalWithholding += amount;
            }
            
            node.SetValue(eColP.Group.ToString(),p.ID.ToString(cUtil.FMT_ID));
            node.SetValue(eColP.Date.ToString(),p.PaymentDate);
            node.SetValue(eColP.Customer.ToString(),p.Customer);
            if(p.PaymentType==(int)Payments.ePaymentType.PDC)
            {
               node.SetValue(eColP.Bank.ToString(),p.PDCdetail.bank);
               node.SetValue(eColP.CheckNo.ToString(),p.PDCdetail.CheckNumber);
               node.SetValue(eColP.AccountNo.ToString(),p.PDCdetail.AccountNumber);
               node.SetValue(eColP.CheckDate.ToString(),p.PDCdetail.CheckDate);
               node.SetValue(eColP.Status.ToString(),p.PDCdetail.Status.ToString());
            }
            node.SetValue(eColP.Amount.ToString(),p.Amount);

            if (p.Canceled)
               node.SetValue(eColP.Canceled.ToString(), true);

            node.SetValue(eColP.ItemObject.ToString(),p);
         }

         //set totals
         nodePDC.SetValue(eColP.Amount.ToString(),totalPDC);
         nodeCash.SetValue(eColP.Amount.ToString(),totalCash);
         nodeW.SetValue(eColP.Amount.ToString(),totalWithholding);
         treePayments.ExpandAll();
         
         treePayments.EndUnboundLoad();
      }
      
      private void LoadReturns(IEnumerable<ReturnedItems> lst )
      {
         double amountTotal = 0;
         TreeListNode parent = treeInvoice.AppendNode(null, null);
         parent.SetValue(eCol.Group.ToString(), "Returned Items");
         parent.SetValue(eCol.Customer.ToString(), "Total");

         foreach (ReturnedItems ri in lst)
         {
            amountTotal += ri.Amount;
            TreeListNode node = treeInvoice.AppendNode(null, parent);

            node.SetValue(eCol.SIV_ID.ToString(), ri.ID);
            //node.SetValue(eCol.ReceiptNo.ToString(), ri.ReceiptNumber);
            node.SetValue(eCol.Date.ToString(), ri.TransactionDate);
            node.SetValue(eCol.Customer.ToString(), ri.Invoice.Customer);
            node.SetValue(eCol.Amount.ToString(), ri.Amount); 
            if (ri.Canceled)
               node.SetValue(eCol.Canceled.ToString(), ri.Canceled);
            node.SetValue(eCol.ItemObject.ToString(),ri);
         }
         parent.SetValue(eCol.Amount.ToString(), amountTotal);
      }

      private void LoadInvoices(IEnumerable<SalesInvoice> lst )
      {
         double amountTotal = 0, amountTotal2=0;

         TreeListNode parent = treeInvoice.AppendNode(null, null);
         parent.SetValue(eCol.Group.ToString(), "Sales Invoice");
         parent.SetValue(eCol.Customer.ToString(), "Total");

         TreeListNode parent2 = treeInvoice.AppendNode(null, null);
         parent2.SetValue(eCol.Group.ToString(), "Cash Invoice");
         parent2.SetValue(eCol.Customer.ToString(), "Total");

         double amount = 0;
         foreach (SalesInvoice si in lst)
         {
            if (!si.Deleted)
               amount = si.AmountDue;
            else
               amount = 0;

            TreeListNode node = null;
            if(si.InvoiceType ==(int)SalesInvoice.eInvoiceType.Cash)
            {
               node = treeInvoice.AppendNode(null, parent2);
               amountTotal2 += amount;
            }
            else
            {
               node = treeInvoice.AppendNode(null, parent);
               amountTotal += amount;
            }
            node.SetValue(eCol.SIV_ID.ToString(),si.ID);
            node.SetValue(eCol.ReceiptNo.ToString(), si.ReceiptNumber);
            node.SetValue(eCol.Date.ToString(), si.InvoiceDate);
            node.SetValue(eCol.Customer.ToString(), si.Customer);
            node.SetValue(eCol.Amount.ToString(), si.AmountDue);if(si.Deleted)
               node.SetValue(eCol.Canceled.ToString(), si.Deleted);
            node.SetValue(eCol.ItemObject.ToString(),si);
         }
         parent.SetValue(eCol.Amount.ToString(), amountTotal);
         parent2.SetValue(eCol.Amount.ToString(), amountTotal2);
      }

      private void treeInvoice_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
      {
         if (e.Node.Level==0)
         {
            e.Appearance.BackColor = Color.Gray;

            if (e.Column.FieldName == "Amount")
               e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
         }
         else
         {
            if (e.Column.FieldName == "Amount")
            {
               object obj = e.Node.GetValue(eCol.ItemObject.ToString());
               if(obj.GetType()==typeof(SalesInvoice))
               {
                  SalesInvoice si = (SalesInvoice) obj;
                  if(si.Deleted)
                     e.Appearance.ForeColor = Color.Red;
               }
            }
         }
      }

      private void ctlDailySalesSummary_Load(object sender, System.EventArgs e)
      {
         m_bIsLoading = false;
         btnRefresh.PerformClick();
      }

      private void treePayments_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
      {
         if (e.Node.Level == 0)
         {e.Appearance.BackColor = Color.Gray;

            if (e.Column.FieldName == "Amount")
               e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
         }
         else
         {
            if (e.Column.FieldName == "Amount")
            {
               if (e.Node.GetValue(eCol.Canceled) != null)
                  e.Appearance.ForeColor = Color.Red;
            }}
      }

      private void dtDateRange_DateSelectionChanged(object sender, System.EventArgs e)
      {
         if(dtDateRange.GetDateSelection()!= ctlDateRange.eDateSelection.Custom)
            btnRefresh.PerformClick();
      }

      private void simpleButton1_Click(object sender, System.EventArgs e)
      {
         cUtil.getMainForm().CloseCurrentControl();
      }
   }
}