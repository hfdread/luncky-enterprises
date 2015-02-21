#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DexterHardware_v2.Classes;
using DexterHardware_v2.UI_Controls.Viewers;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace DexterHardware_v2.UI_Controls.Accounting
{
   public partial class ctlCustomerAccounting : UserControl
   {
      private readonly SalesInvoiceDao InvoiceDao = new SalesInvoiceDao();
      private PaymentsDao PaymentDao = new PaymentsDao();
      private readonly PaymentsDetailDao PaymentDetailDao = new PaymentsDetailDao();
      private readonly ReturnedItemsDao ReturnDao = new ReturnedItemsDao();
      private readonly ContactsDao ContactsDao = new ContactsDao();
      private readonly CounterDao CounterDao = new CounterDao();

      private enum eCol
      {
         InvoiceID,
         InvoiceDate,
         CounterID,
         Amount,
         Credit,
         Debit,
         DebitPDC,
         CheckNo,
         CheckDate,
         ItemObject
      }

      private IList<SalesInvoice> m_lstInvoices = null;
      private double m_Balance, m_DebitPDC, m_Withholding, m_BadDebts;
      private bool m_bIsLoading = true;

      public ctlCustomerAccounting()
      {
         InitializeComponent();
      }

      private void ctlCustomerAccounting_Load(object sender, EventArgs e)
      {
         //load customers
         IList<Contacts> lstC = ContactsDao.getAllCustomers();
         foreach (Contacts c in lstC)
         {
            cboCustomer.Properties.Items.Add(c);
         }
         cboCustomer.SelectedIndex = -1;

         dtRangeMain.SetDateSelection(ctlDateRange.eDateSelection.ThisMonth);
         dtRangeInvoice.SetDateSelection(ctlDateRange.eDateSelection.ThisMonth);
         m_bIsLoading = false;
      }

      private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (cboCustomer.SelectedIndex != -1)
         {
            Contacts c = (Contacts) cboCustomer.SelectedItem;
            txtContactNo.Text = c.LandlineNumber;
            txtAddress.Text = c.Address;

            lblCreditLimit.Text = c.CreditLimit.ToString(cUtil.FMT_AMOUNT);
            lblCreditUsed.Text = c.CreditUsed.ToString(cUtil.FMT_AMOUNT);
         }
         else
         {
            txtContactNo.Text = "";
            txtAddress.Text = "";

            lblCreditLimit.Text = "0.00";
            lblCreditUsed.Text = "0.00";
         }
      }

      private void btnRefresh_Click(object sender, EventArgs e)
      {
         if (m_bIsLoading)
            return;

         if (cboCustomer.SelectedIndex == -1)
         {
            cUtil.ShowMessageError("Please select valid customer!", "Customer Accounting");
            cboCustomer.Focus();
            return;
         }
         Contacts c = (Contacts) cboCustomer.SelectedItem;
         int status = -1;
         if (chkUnpaidInvoicesOnly.Checked)
            status = (int) SalesInvoice.ePaymentStatus.Unpaid;

         IList<SalesInvoice> lstSI = InvoiceDao.getAllRecordsByCriteria(c.ID, dtRangeMain.getDateFrom(),
                                                                        dtRangeMain.getDateTo(), status);
         m_lstInvoices = new List<SalesInvoice>();

         //display invoices
         tvMain.BeginUnboundLoad();
         tvMain.Nodes.Clear();
         tvBadDebts.BeginUnboundLoad();
         tvBadDebts.Nodes.Clear();

         m_Balance = m_BadDebts = m_DebitPDC = m_Withholding = 0;

         foreach (SalesInvoice si in lstSI)
         {
            if (si.Deleted)
               continue;

            TreeListNode node = tvMain.AppendNode(null, null);
            AddInvoiceDetails(tvMain, node, si);

            if (si.BadDebt)
            {
               node = tvBadDebts.AppendNode(null, null);
               AddInvoiceDetails(tvBadDebts, node, si);
            }
            else
            {
               m_lstInvoices.Add(si);
            }
         }
         grdInvoices.DataSource = m_lstInvoices;
         tvMain.ExpandAll();
         tvBadDebts.ExpandAll();
         tvMain.EndUnboundLoad();
         tvBadDebts.EndUnboundLoad();

         //update display
         lblBalance.Text = m_Balance.ToString(cUtil.FMT_AMOUNT);
         lblPDC.Text = string.Format("({0})", m_DebitPDC.ToString(cUtil.FMT_AMOUNT));
         lblWithholding.Text = m_Withholding.ToString(cUtil.FMT_AMOUNT);
         lblBadDebts.Text = m_BadDebts.ToString(cUtil.FMT_AMOUNT);
      }

      private void AddInvoiceDetails(TreeList tv, TreeListNode node, SalesInvoice si)
      {
         node.SetValue(eCol.InvoiceID.ToString(), si.ID);
         node.SetValue(eCol.InvoiceDate.ToString(), si.InvoiceDate);
         node.SetValue(eCol.Amount.ToString(), si.AmountDue);
         if (si.CounterID != 0)
            node.SetValue(eCol.CounterID.ToString(), si.CounterID);

         node.SetValue(eCol.Debit.ToString(), si.AmountDue);

         double dpaymentCash, dpaymentWithholding, dpaymentPDC, dpaymentForDeposit;
         dpaymentCash = dpaymentPDC = dpaymentForDeposit = dpaymentWithholding = 0;

         //get payments
         IList<PaymentsDetail> lstPD = PaymentDetailDao.getAllPaymentsByInvoice(si.ID);
         foreach (PaymentsDetail pd in lstPD)
         {
            if (!pd.payment.Canceled)
            {
               if (pd.payment.PDCdetail != null)
               {
                  TreeListNode child = null;
                  switch (pd.payment.PDCdetail.Status)
                  {
                     case PaymentsPDC.eStatus.ForDeposit:
                        child = tv.AppendNode(null, node);
                        child.SetValue(eCol.DebitPDC.ToString(), pd.Amount);
                        dpaymentForDeposit += pd.Amount;
                        break;
                     case PaymentsPDC.eStatus.Good:
                        child = tv.AppendNode(null, node);
                        child.SetValue(eCol.Credit.ToString(), pd.Amount);
                        dpaymentPDC += pd.Amount;
                        break;
                     default:
                        break;
                  }
                  if (child != null)
                  {
                     child.SetValue(eCol.CheckDate.ToString(), pd.payment.PDCdetail.CheckDate);
                     child.SetValue(eCol.CheckNo.ToString(), pd.payment.PDCdetail.CheckNumber);
                  }
               }
               else
               {
                  //cash or withholding
                  TreeListNode child = tv.AppendNode(null, node);
                  child.SetValue(eCol.Credit.ToString(), pd.Amount);
                  child.SetValue(eCol.CheckNo.ToString(), pd.payment.GetPaymentType(pd.payment.PaymentType));
                  if (pd.payment.PaymentType == (int) Payments.ePaymentType.Cash)
                     dpaymentCash += pd.Amount;
                  else
                     dpaymentWithholding += pd.Amount;
               }
            }
         }

         double totalpayments = dpaymentCash + dpaymentPDC + dpaymentWithholding + dpaymentPDC;

         if (si.PaymentStatus == (int) SalesInvoice.ePaymentStatus.Paid)
         {
            //check if paid amount not full
            if (totalpayments < si.AmountDue)
            {
               TreeListNode child = tv.AppendNode(null, node);
               child.SetValue(eCol.Credit.ToString(), si.AmountDue - totalpayments);
               child.SetValue(eCol.CheckNo.ToString(), "[Bonus]");
            }
         }

         //update variables
         if (!si.BadDebt)
         {
            m_DebitPDC += dpaymentForDeposit;
            m_Withholding += dpaymentWithholding;

            if (si.PaymentStatus != (int) SalesInvoice.ePaymentStatus.Paid)
               m_Balance += (si.AmountDue - totalpayments);
         }
         else
         {
            m_BadDebts += si.AmountDue;
         }

         //get credit memo / returned item
         IList<ReturnedItems> lstR = ReturnDao.getAllByInvoiceID(si.ID);
         foreach (ReturnedItems ri in lstR)
         {
            if (!ri.Canceled)
            {
               TreeListNode child = tv.AppendNode(null, node);
               child.SetValue(eCol.Credit.ToString(), ri.Amount);
               child.SetValue(eCol.CheckNo.ToString(), "[Returned Item]");
            }
         }
      }

      private void grdvInvoices_CustomUnboundColumnData(object sender,
                                                        DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
      {
         SalesInvoice si = (SalesInvoice) e.Row;
         if (e.IsGetData && e.Column.FieldName == "DueDate")
         {
            if (si.InvoiceType == (int) SalesInvoice.eInvoiceType.Accounts)
            {
               e.Value = SalesInvoice.GetDueDate(si.InvoiceDate, si.Terms);
            }
         }
         else if (e.IsGetData && e.Column.FieldName == "Counter_ID")
         {
            if (si.CounterID != 0)
               e.Value = si.CounterID;
         }
         else if (e.IsGetData && e.Column.FieldName == "_Terms")
         {
            if (si.Terms != 0)
            {
               e.Value = si.Terms;
            }
         }
         else if (e.IsGetData && e.Column.FieldName == "_Status")
         {
            e.Value = ((SalesInvoice.ePaymentStatus) si.PaymentStatus).ToString();
         }
      }

      private void btnInvoicesRefresh_Click(object sender, EventArgs e)
      {
      }

      private void btnViewCounters_Click(object sender, EventArgs e)
      {
         if (cboCustomer.SelectedIndex != -1)
         {
            ctlViewCounters ctl = new ctlViewCounters();
            ctl.m_Customer = (Contacts) cboCustomer.SelectedItem;
            ctl.m_eDateSel = ctlDateRange.eDateSelection.ThisYear;
            cUtil.getMainForm().LoadCtl(ctl, true, "View Counters", "", true, DockStyle.Left);
         }
      }

      private void btnAddCounter_Click(object sender, EventArgs e)
      {
         //get list of selected invoices
         IList<SalesInvoice> lstSI = new List<SalesInvoice>();
         foreach (SalesInvoice si in (IList<SalesInvoice>) grdInvoices.DataSource)
         {
            if (si.Selected && si.InvoiceType == (int) SalesInvoice.eInvoiceType.Accounts && si.CounterID == 0 &&
                si.Deleted == false && si.BadDebt == false)
            {
               lstSI.Add(si);
            }
         }

         if (lstSI.Count > 0)
         {
            //get different due dates
            List<string> lstDueDates = new List<string>();
            string sDueDate = "";
            double amount = 0;
            foreach (SalesInvoice si in lstSI)
            {
               sDueDate = si.InvoiceDate.AddDays(si.Terms).ToString(cUtil.FMT_DATE1);
               if (!lstDueDates.Contains(sDueDate))
                  lstDueDates.Add(sDueDate);
            }

            //create counter for each due dates
            foreach (string s in lstDueDates)
            {
               Counter c = new Counter();
               c.CounterDate = DateTime.Now;
               c.CounterDueDate = c.GetDueDate(DateTime.Parse(s + " 12:00 AM"));
               c.Customer = (Contacts) cboCustomer.SelectedItem;

               amount = 0;
               foreach (SalesInvoice si in lstSI)
               {
                  sDueDate = si.InvoiceDate.AddDays(si.Terms).ToString(cUtil.FMT_DATE1);
                  if (sDueDate == s)
                  {
                     CounterDetails cd = new CounterDetails();
                     cd.invoice = si;
                     c.details.Add(cd);
                     amount += si.AmountDue;
                  }
               }
               c.Amount = amount;
               if (c.details.Count > 0)
               {
                  try
                  {
                     CounterDao.Save(c);
                     //TODO: print counter
                  }
                  catch (Exception ex)
                  {
                     cUtil.ShowMessageError(ex, "Save Counter");
                  }
               }
            }
            btnRefresh.PerformClick();
         }
         else
         {
            cUtil.ShowMessageExclamation("No valid Sales Invoice for counter!", "Add Counter");
         }
      }

      private void dtRangeMain_DateSelectionChanged(object sender, EventArgs e)
      {
         btnRefresh.PerformClick();
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         cUtil.getMainForm().CloseCurrentControl();
      }
   }
}