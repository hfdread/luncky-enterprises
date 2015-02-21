#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DexterHardware_v2.Classes;
using DexterHardware_v2.Forms;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using DexterHardware_v2.Reports;
#endregion

namespace DexterHardware_v2.UI_Controls.Accounting
{
   public partial class ctlCounter : UserControl
   {
      private CounterDao CounterDao = new CounterDao();
      private CounterDetailsDao CounterDetailsDao = new CounterDetailsDao();
      private SalesInvoiceDao InvoiceDao = new SalesInvoiceDao();
      private PaymentsDao PaymentDao = new PaymentsDao();
      private ReturnedItemsDao ReturnDao = new ReturnedItemsDao();

      public virtual Counter m_Counter { get; set; }

      private bool m_bDirty = false;

      private enum eCol
      {
         ID = 0,
         InvoiceDate,
         PO_Number,
         Customer,
         AmountDue,
         PaymentStatus,
         Withheld,
         WithheldAmount,
         ItemObject
      }

      public ctlCounter()
      {
         InitializeComponent();
      }

      private void ctlCounter_Load(object sender, EventArgs e)
      {
         LoadCounterDetails();

         rptCounter rpt = new rptCounter();
         
      }

      private void LoadCounterDetails()
      {
         //make sure counter is up to date
         m_Counter = CounterDao.GetById(m_Counter.ID);
         lblCustomer.Text = m_Counter.Customer.ToString();
         lblCounterID.Text = m_Counter.ID.ToString(cUtil.FMT_ID);
         lblDueDate.Text = m_Counter.CounterDueDate.ToString(cUtil.FMT_DATE1);
         lblAmountDue.Text = m_Counter.Amount.ToString(cUtil.FMT_AMOUNT);
         lblBalance.Text = m_Counter.Balance.ToString(cUtil.FMT_AMOUNT);

         treeInvoice.BeginUnboundLoad();
         treeInvoice.Nodes.Clear();

         //get Invoice details
         IList<SalesInvoice> lst = CounterDao.GetInvoiceDetails(m_Counter.ID);
         foreach (SalesInvoice SI in lst)
         {
            TreeListNode Parent;
            Parent = treeInvoice.AppendNode(null, null);
            Parent.SetValue(eCol.ItemObject.ToString(), SI);
            Parent.SetValue(eCol.ID.ToString(), SI.ID);
            Parent.SetValue(eCol.InvoiceDate.ToString(), SI.InvoiceDate);
            Parent.SetValue(eCol.Customer.ToString(), SI.Customer.ToString());
            Parent.SetValue(eCol.AmountDue.ToString(), SI.AmountDue);
            Parent.SetValue(eCol.PaymentStatus.ToString(), (SalesInvoice.ePaymentStatus) SI.PaymentStatus);
            Parent.SetValue(eCol.Withheld.ToString(), SI.Withheld);
            Parent.SetValue(eCol.WithheldAmount.ToString(), SI.WithholdingAmount);

            //get returned items for invoice
            IList<ReturnedItems> lstR = ReturnDao.getAllByInvoiceID(SI.ID);
            foreach (ReturnedItems ri in lstR)
            {
               TreeListNode child = treeInvoice.AppendNode(null, Parent);
               child.SetValue(eCol.InvoiceDate.ToString(), ri.TransactionDate);
               child.SetValue(eCol.Customer.ToString(), "[Returned Items]");
               child.SetValue(eCol.AmountDue.ToString(), ri.Amount);
               child.SetValue(eCol.Withheld.ToString(), false);
            }
         }

         //get payment details
         IList<Payments> lstP = CounterDao.GetPaymentDetails(m_Counter.ID);
         //update Invoice payment details
         foreach (Payments P in lstP)
         {
            AddPaymentDetailsToInvoice(P);
         }
         treeInvoice.ExpandAll();
         treeInvoice.EndUnboundLoad();
         grdPayments.DataSource = lstP;
      }

      private void AddPaymentDetailsToInvoice(Payments P)
      {
         if (P.invoice != null)
         {
            //payment is made for invoice
            TreeListNode node = GetInvoiceNode(P.invoice.ID);
            if (node != null)
            {
               TreeListNode child = treeInvoice.AppendNode(null, node);
               child.SetValue(eCol.InvoiceDate.ToString(), P.PaymentDate);
               child.SetValue(eCol.Customer.ToString(),
                              string.Format("[Payment-{0}]", (Payments.ePaymentType) P.PaymentType));
               child.SetValue(eCol.AmountDue.ToString(), P.Amount);
               child.SetValue(eCol.Withheld.ToString(), false);
               if (P.PaymentType == (int) Payments.ePaymentType.PDC)
               {
                  child.SetValue(eCol.PaymentStatus.ToString(), (PaymentsPDC.eStatus) P.PDCdetail.Status);
               }
            }
         }
         else
         {
            //payment is made through counter, get all invoices for payment
            P.details = PaymentDao.GetPaymentDetails(P.ID);
            foreach (PaymentsDetail pd in P.details)
            {
               TreeListNode node = GetInvoiceNode(pd.invoice.ID);
               if (node != null)
               {
                  TreeListNode child = treeInvoice.AppendNode(null, node);
                  child.SetValue(eCol.InvoiceDate.ToString(), P.PaymentDate);
                  child.SetValue(eCol.Customer.ToString(),
                                 string.Format("Payment-{0}", (Payments.ePaymentType) P.PaymentType));
                  child.SetValue(eCol.AmountDue.ToString(), pd.Amount);
                  child.SetValue(eCol.Withheld.ToString(), false);
                  if (P.PaymentType == (int) Payments.ePaymentType.PDC)
                  {
                     child.SetValue(eCol.PaymentStatus.ToString(), (PaymentsPDC.eStatus) P.PDCdetail.Status);
                  }
                  //update parent status
                  node.SetValue(eCol.PaymentStatus.ToString(), (SalesInvoice.ePaymentStatus) pd.invoice.PaymentStatus);
               }
            }
         }
      }

      private TreeListNode GetInvoiceNode(Int32 ID)
      {
         foreach (TreeListNode node in treeInvoice.Nodes)
         {
            SalesInvoice si = (SalesInvoice) node.GetValue(eCol.ItemObject.ToString());
            if (si.ID == ID)
               return node;
         }
         return null;
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         if (m_bDirty)
         {
            if (cUtil.ShowMessageYesNo("Do you wish to save changes?", "Save") == DialogResult.Yes)
            {
               foreach (TreeListNode node in treeInvoice.Nodes)
               {
                  SalesInvoice si = (SalesInvoice) node.GetValue(eCol.ItemObject.ToString());
                  if (si.Selected)
                  {
                     try
                     {
                        InvoiceDao.Save(si);
                     }
                     catch (Exception ex)
                     {
                        cUtil.ShowMessageError(ex, string.Format("Update Invoice [{0}]", si.ID.ToString(cUtil.FMT_ID)));
                     }
                  }
               }
            }
         }

         cUtil.getMainForm().CloseCurrentControl();
      }

      private void grdvPayments_CustomUnboundColumnData(object sender,
                                                        DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
      {
         if (e.IsGetData)
         {
            Payments p = (Payments) grdvPayments.GetRow(e.RowHandle);
            if (p != null)
            {
               if (e.Column.FieldName == "paymenttype")
               {
                  e.Value = (Payments.ePaymentType) p.PaymentType;
               }
               else if (e.Column.FieldName == "checkstatus")
               {
                  if (p.PDCdetail != null)
                  {
                     e.Value = (PaymentsPDC.eStatus) p.PDCdetail.Status;
                  }
               }
            }
         }
      }

      private void btnPaymentAdd_Click(object sender, EventArgs e)
      {
         ctlReceivePayment ctl = new ctlReceivePayment();
         ctl.m_Counter = m_Counter;
         ctl.m_Customer = m_Counter.Customer;

         frmGenericPopup frm = new frmGenericPopup();
         frm.Text = "Receive Payment for Counter " + m_Counter.ID.ToString(cUtil.FMT_ID);
         frm.ControlBox = false;
         frm.ShowCtl(ctl);
         if (!ctl.Canceled)
         {
            //update display
            m_Counter = CounterDao.GetById(m_Counter.ID);
            lblBalance.Text = m_Counter.Balance.ToString(cUtil.FMT_AMOUNT);
            AddPaymentDetailsToInvoice(ctl.m_Payment);

            //reload payments
            grdPayments.DataSource = CounterDao.GetPaymentDetails(m_Counter.ID);
         }
      }

      private void treeInvoice_CellValueChanging(object sender, CellValueChangedEventArgs e)
      {
         if (e.Column.FieldName == eCol.Withheld.ToString())
         {
            if (e.Node.ParentNode != null)
               return;

            m_bDirty = true;
            SalesInvoice si = (SalesInvoice) e.Node.GetValue(eCol.ItemObject.ToString());
            si.Selected = true;
            si.Withheld = (bool) e.Value;
            if (si.Withheld)
               si.WithholdingAmount = cUtil.CalculateWithholdingAmount(si.AmountDue);
            else
               si.WithholdingAmount = 0;

            e.Node.SetValue(eCol.WithheldAmount.ToString(), si.WithholdingAmount);
         }
      }

      private void btnPaymentCancel_Click(object sender, EventArgs e)
      {
         Payments p = (Payments) grdvPayments.GetRow(grdvPayments.FocusedRowHandle);
         if (p != null)
         {
            if (p.Reviewed)
            {
               cUtil.ShowMessageExclamation("Cannot cancel payment!", "Cancel Payment");
               return;
            }

            if (cUtil.ShowMessageYesNo("Cancel selected payment?", "Cancel Payment") == DialogResult.Yes)
            {
               try
               {
                  PaymentDao.CancelPayment(p.ID);
                  m_Counter = CounterDao.GetById(m_Counter.ID);
                  LoadCounterDetails();
               }
               catch (Exception ex)
               {
                  cUtil.ShowMessageError(ex, "Cancel Payment");
               }
            }
         }
      }

      private void btnPaymentWithholding_Click(object sender, EventArgs e)
      {
         ctlReceivePayment ctl = new ctlReceivePayment();
         ctl.m_Counter = m_Counter;
         ctl.m_Customer = m_Counter.Customer;
         ctl.m_PaymentType = (Int32) Payments.ePaymentType.WithHolding;

         frmGenericPopup frm = new frmGenericPopup();
         frm.Text = "Receive Payment for Counter " + m_Counter.ID.ToString(cUtil.FMT_ID);
         frm.ControlBox = false;
         frm.ShowCtl(ctl);
         if (!ctl.Canceled)
         {
            //update display
            m_Counter = CounterDao.GetById(m_Counter.ID);
            lblBalance.Text = m_Counter.Balance.ToString(cUtil.FMT_AMOUNT);
            AddPaymentDetailsToInvoice(ctl.m_Payment);

            //reload payments
            grdPayments.DataSource = CounterDao.GetPaymentDetails(m_Counter.ID);
         }
      }
   }
}