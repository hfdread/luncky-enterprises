#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Accounting
{
   public partial class ctlReceivePayment : UserControl
   {
      private PaymentsDao mPaymentDao = new PaymentsDao();
      private ContactsDao mCustomerDao = new ContactsDao();
      private CounterDao mCounterDao = new CounterDao();
      private SalesInvoiceDao mSalesInvoiceDao = new SalesInvoiceDao();
      private BanksDao mBanksDao = new BanksDao();
      private ReturnedItemsDao mReturnedItemsDao = new ReturnedItemsDao();
      private PaymentsDetailDao mPaymentDetailDao = new PaymentsDetailDao();


      public bool Canceled { get; set; }
      public Contacts m_Customer { get; set; }
      public Counter m_Counter { get; set; }
      public SalesInvoice m_Invoice { get; set; }
      public int m_PaymentType { get; set; }
      public Payments m_Payment;
      public IList<SalesInvoice> sel_SalesInvoices { get; set; }

      private bool bAllowLoad = false;

      private enum eCol
      {
         Selected = 0,
         InvoiceDate,
         InvoiceNo,
         PO_No,
         OriginalAmount,
         AmountDue,
         Payment
      }

      public ctlReceivePayment()
      {
         InitializeComponent();
         m_PaymentType = -1;
      }

      private bool m_bUserInputAmount = false;

      private void ctlReceivePayment_Load(object sender, EventArgs e)
      {
         bAllowLoad = false;
         dtDate.DateTime = DateTime.Now;
        

         if(m_Invoice!=null)
         {
             LoadBanks();
             LoadCustomers();
            //payment for single invoice
            cboCounter.Enabled = false;
            LoadInvoices(null);
         }
         else if (sel_SalesInvoices.Count > 0)
         {
             //payment for multiple invoices
             LoadBanks();
             LoadInvoices();
             AllocatePayment();
             multiplePayments(false);
         }
         else
         {
             if (m_Customer != null)
             {
                 lblCustomerBalance.Text = m_Customer.CreditUsed.ToString(clsUtil.FMT_AMOUNT);
                 //cboCustomer.Text = m_Customer.ToString();
                 LoadCounters(m_Customer);
             }

             if (m_Counter != null)
             {
                 //cboCounter.Text = m_Counter.ToString();
                 LoadInvoices(m_Counter);
             }
         }

         bAllowLoad = true;
         cboPaymentMethod.SelectedIndex = 0;

         txtAmount.Focus();
      }

      private void multiplePayments(bool enabled) 
      {
          lblCustomerBalance.Enabled = enabled;
          cboCustomer.Enabled = enabled;
          cboCounter.Enabled = enabled;
      }

      private void LoadCustomers()
      {
         cboCustomer.Properties.Items.Clear();

         if (m_Customer != null)
         {
            cboCustomer.Properties.Items.Add(m_Customer);
            cboCustomer.SelectedIndex = 0;
         }
         else
         {
            IList<Contacts> lst = mCustomerDao.getAllCustomers();
            foreach (Contacts c in lst)
            {
               cboCustomer.Properties.Items.Add(c);
            }
            cboCustomer.SelectedIndex = -1;
         }
      }

      private void LoadBanks()
      {
         IList<Banks> lst = mBanksDao.getAllRecords();
         foreach (Banks b in lst)
         {
            cboBank.Properties.Items.Add(b);
         }
         cboBank.SelectedIndex = -1;
      }

      private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
      {
         Contacts c = (Contacts) cboCustomer.SelectedItem;

         if (c != null)
         {
            lblCustomerBalance.Text = c.CreditUsed.ToString(clsUtil.FMT_AMOUNT);
            if (bAllowLoad)
               LoadCounters(c);
         }
      }

      private void cboCounter_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (!bAllowLoad)
            return;

         Counter c = null;
         Int32 index = cboCounter.SelectedIndex;
         if (index >= 0)
         {
            c = (Counter) cboCounter.Properties.Items[index];
         }

         LoadInvoices(c);
      }

      private void LoadCounters(Contacts c)
      {
         //clear counter and invoices
         cboCounter.Properties.Items.Clear();
         cboCounter.Text = "";
         tblData.Rows.Clear();

         if (c != null)
         {
            if (m_Counter != null)
            {
               cboCounter.Properties.Items.Add(m_Counter);
               cboCounter.SelectedIndex = 0;
            }
            else
            {
               //load counters
               IList<Counter> lst = mCounterDao.getAllRecordsByCriteria(c.ID, true, DateTime.Now, DateTime.Now, false);
               //cboCounter.Properties.Items.Clear();
               foreach (Counter counter in lst)
               {
                  cboCounter.Properties.Items.Add(counter);
               }

               //select first counter
               if (lst.Count > 0)
                  cboCounter.SelectedIndex = 0;
            }
         }
      }

      private void LoadInvoices(Counter c)
      {
         double amount = 0;

         tblData.Rows.Clear();
         if (c != null)
         {
            //get invoices for counter
            IList<SalesInvoice> lst = mSalesInvoiceDao.getAllRecordsForCounter(c.Customer.ID, c.ID, false);
            foreach (SalesInvoice s in lst)
            {
               //show only unpaid/partially paid invoices
               if (s.PaymentStatus == (Int32) SalesInvoice.ePaymentStatus.Partial ||
                   s.PaymentStatus == (Int32) SalesInvoice.ePaymentStatus.Unpaid)
               {
                  AddInvoiceToList(s);
               }
            }
         }
         else if(m_Invoice!=null)
         {
            AddInvoiceToList(m_Invoice);
         }

         if (tblData.Rows.Count == 0)
         {
            btnSaveAndClose.Enabled = false;
         }
         else
         {
            foreach (DataRow row in tblData.Rows)
            {
               amount += (double) row[eCol.AmountDue.ToString()];
            }
         }
         txtAmount.Text = amount.ToString(clsUtil.FMT_AMOUNT);
      }

      private void LoadInvoices()
      {
          double amount = 0;
          tblData.Rows.Clear();
          if (sel_SalesInvoices != null)
          {
              foreach (SalesInvoice si in sel_SalesInvoices)
              {
                  AddInvoiceToList(si);
              }

              if (tblData.Rows.Count == 0)
                  btnSaveAndClose.Enabled = false;
              else
              {
                  foreach (DataRow row in tblData.Rows)
                  {
                      amount += (double)row[eCol.AmountDue.ToString()];
                  }
              }
          }

          txtAmount.Text = amount.ToString(clsUtil.FMT_AMOUNT);
      }

      private void AddInvoiceToList(SalesInvoice s)
      {
          double amountDue = mPaymentDetailDao.GetInvoicePayments(s.ID);
         //show only unpaid/partially paid invoices
         if (s.PaymentStatus == (Int32)SalesInvoice.ePaymentStatus.Partial ||
             s.PaymentStatus == (Int32)SalesInvoice.ePaymentStatus.Unpaid)
         {
             tblData.Rows.Add(true, s.InvoiceDate, s.ID, s.PO_Number, s.AmountDue,
                                   getRemainingAmountDue(s.AmountDue ,amountDue));
         }
      }

      public double getRemainingAmountDue(double origAmount, double totalPayment)
      {
          if (origAmount == totalPayment)
              return origAmount;
          else
              return origAmount - totalPayment;
      }

      private void cboPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (cboPaymentMethod.SelectedIndex == 0)
         {
            //cash   
            cboBank.SelectedIndex = -1;
            cboBank.Text = "";
            cboBank.Enabled = false;

            txtAccountNo.Text = "";
            txtAccountNo.Enabled = false;
            txtCheckNo.Text = "";
            txtCheckNo.Enabled = false;
            dtCheckDate.Enabled = false;
            dtCheckDate.DateTime = DateTime.Now;
         }
         else
         {
            //check
            cboBank.Enabled = true;
            txtAccountNo.Enabled = true;
            txtCheckNo.Enabled = true;
            dtCheckDate.Enabled = true;
         }
      }

      private void AllocatePayment()
      {
         double Amount = clsUtil.CheckValue(txtAmount);
         double PaymentAmount = Amount;
         double AmountDue, AmountDueTotal;
         DataRow row;

         AmountDue = AmountDueTotal = 0;

         //deselect all rows
         foreach (DataRow R in tblData.Rows)
         {
            R[(Int32) eCol.Selected] = false;
            R[(Int32) eCol.Payment] = 0;
         }

         row = GetMatchingAmount(Amount);
         if (row != null)
         {
            row[(Int32) eCol.Selected] = true;
            row[(Int32) eCol.Payment] = Amount;
            Amount -= Amount;
            AmountDueTotal += Amount;
         }
         else
         {
            //auto allocate
            foreach (DataRow R in tblData.Rows)
            {
               AmountDue = Convert.ToDouble(R[(Int32) eCol.AmountDue].ToString());
               if (AmountDue > 0)
               {
                  R[(Int32) eCol.Selected] = true;
                  if (Amount >= AmountDue)
                  {
                     R[(Int32) eCol.Payment] = AmountDue;
                     Amount -= AmountDue;
                  }
                  else
                  {
                     R[(Int32) eCol.Payment] = Amount;
                     Amount = 0;
                  }
                  AmountDueTotal += AmountDue;

                  if (Amount == 0)
                     break;
               }
            }
            //ShowOverPayment(Amount);

            lblAmountDue.Text = AmountDueTotal.ToString(clsUtil.FMT_AMOUNT);
            lblAmountApplied.Text = (PaymentAmount - Amount).ToString(clsUtil.FMT_AMOUNT);
         }
      }

      private DataRow GetMatchingAmount(double Amount)
      {
         //gets the invoice with AmountDue==Amount
         foreach (DataRow row in tblData.Rows)
         {
            if (Convert.ToDouble(row[(Int32) eCol.AmountDue].ToString()) == Amount &&
                !Convert.ToBoolean(row[(Int32) eCol.Selected].ToString()))
               return row;
         }
         return null;
      }

      private void ShowOverPayment(double Amount)
      {
         if (Amount > 0)
         {
            lblOverPayment.Text = string.Format("Over payment of {0}. When you finish, do you wish to:",
                                                Amount.ToString(clsUtil.FMT_AMOUNT));
            pnlOverpayment.Visible = true;
         }
         else
         {
            pnlOverpayment.Visible = false;
         }
      }

      private void txtAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
      {
         double Amount = clsUtil.CheckValue(txtAmount);
         txtAmount.Text = Amount.ToString(clsUtil.FMT_AMOUNT);
      }

      private void txtAmount_Validated(object sender, EventArgs e)
      {
         AllocatePayment();
      }

      private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (clsUtil.ParseDouble(txtAmount.Text) > 0)
            m_bUserInputAmount = true;
         else
            m_bUserInputAmount = false;
      }

      private void txtAmount_TextChanged(object sender, EventArgs e)
      {
         lblAmountApplied.Text = clsUtil.ParseDouble(txtAmount.Text).ToString(clsUtil.FMT_AMOUNT);
      }

      private void grdvInvoices_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
      {
         double AmountPaid = clsUtil.CheckValue(txtAmount);
         DataRow row = grdvInvoices.GetDataRow(e.RowHandle);

         if (AmountPaid > 0)
         {
            if (clsUtil.ParseBoolean(row[(Int32) eCol.Selected]))
            {
               //get all payments
               foreach (DataRow r in tblData.Rows)
               {
                  if (clsUtil.ParseBoolean(r[(Int32) eCol.Selected]) &&
                      (r[(Int32) eCol.InvoiceNo] != row[(Int32) eCol.InvoiceNo]))
                  {
                     AmountPaid -= clsUtil.ParseDouble(r[(Int32) eCol.Payment].ToString());
                  }
               }

               if (AmountPaid > 0)
               {
                  if (AmountPaid >= clsUtil.ParseDouble(row[(Int32) eCol.AmountDue].ToString()))
                  {
                     row[(Int32) eCol.Payment] = row[(Int32) eCol.AmountDue];
                  }
                  else
                  {
                     row[(Int32) eCol.Payment] = AmountPaid;
                  }
               }
               else
               {
                  e.ErrorText = "Insufficient amount paid!";
                  e.Valid = false;
               }
            }
            else
            {
               row[(Int32) eCol.Payment] = 0;
            }
         }
         else
         {
            if (clsUtil.ParseBoolean(row[(Int32) eCol.Selected]) &&
                Convert.ToDouble(row[(Int32) eCol.AmountDue].ToString()) > 0)
            {
               row[(Int32) eCol.Payment] = 0;
               e.ErrorText = "Insufficient amount paid!";
               e.Valid = false;
            }
         }
      }

      private void grdvInvoices_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
      {
         //update totals
         double TotalInvoices, TotalPayment;

         TotalInvoices = TotalPayment = 0;
         foreach (DataRow row in tblData.Rows)
         {
            if (clsUtil.ParseBoolean(row[(Int32) eCol.Selected]))
            {
               TotalInvoices += clsUtil.ParseDouble(row[(Int32) eCol.AmountDue].ToString());
               TotalPayment += clsUtil.ParseDouble(row[(Int32) eCol.Payment].ToString());
            }
         }

         lblAmountDue.Text = TotalInvoices.ToString(clsUtil.FMT_AMOUNT);
         lblAmountApplied.Text = TotalPayment.ToString(clsUtil.FMT_AMOUNT);

         //overpayment?
         //ShowOverPayment(clsUtil.ParseDouble(txtAmount.Text) - TotalPayment);
      }

      private void btnClear_Click(object sender, EventArgs e)
      {
         txtAmount.Text = "";
         lblAmountApplied.Text = "0.00";
         lblAmountDue.Text = "0.00";
         lblCustomerBalance.Text = "0.00";
         //ShowOverPayment(0);

         //clear check details
         cboBank.SelectedIndex = -1;
         txtAccountNo.Text = "";
         txtCheckNo.Text = "";
         dtCheckDate.DateTime = DateTime.Now;
         cboPaymentMethod.SelectedIndex = 0;
         txtMemo.Text = "";

         foreach (DataRow row in tblData.Rows)
         {
            row[(Int32) eCol.Selected] = false;
            row[(Int32) eCol.Payment] = 0;
         }
         txtAmount.Focus();
      }

      private bool SavePayment()
      {
         m_Payment = new Payments();
         Counter counter = null;
         Contacts customer = null;
         Banks bank = null;
         bool checkPayment = false;

         m_Payment.Amount = clsUtil.ParseDouble(txtAmount.Text);

         double totalAmountDue = clsUtil.ParseDouble(lblAmountDue.Text);
         if (m_Payment.Amount > totalAmountDue)
         {
             clsUtil.ShowMessageInformation(string.Format("Cannot Accept Payment! There is an overpayment of {0}", m_Payment.Amount - totalAmountDue), 
                 "Over Payment");
             return false;
         }

         if (m_Payment.Amount <= 0)
         {
            clsUtil.ShowMessageError("Invalid amount paid!", "Counter Payment");
            return false;
         }

         if (m_Invoice==null && cboCounter.SelectedIndex == -1 && sel_SalesInvoices.Count <= 0)
         {
            clsUtil.ShowMessageExclamation("Invalid counter selected!", "Receive Payment");
            cboCounter.Focus();
            return false;
         }
         //counter = (Counter) cboCounter.Properties.Items[cboCounter.SelectedIndex];

         if (cboCustomer.SelectedIndex == -1 && sel_SalesInvoices.Count <= 0)
         {
            clsUtil.ShowMessageExclamation("Invalid customer selected!", "Receive Payment");
            cboCustomer.Focus();
            return false;
         }

         if (cboCustomer.SelectedIndex != -1)
         {
             customer = (Contacts)cboCustomer.Properties.Items[cboCustomer.SelectedIndex];
         }

         if (cboPaymentMethod.SelectedIndex == -1)
         {
            clsUtil.ShowMessageExclamation("Invalid payment method selected!", "Receive Payment");
            cboCustomer.Focus();
            return false;
         }

          //check if selected a transaction
         bool bSelectedTrx = false;
         foreach (DataRow row in tblData.Rows)
         {
             if (clsUtil.ParseBoolean(row[(Int32)eCol.Selected]))
             {
                 bSelectedTrx = true;
             }
         }

         if (!bSelectedTrx)
         {
             clsUtil.ShowMessageExclamation("Please select an Invoice to pay!", "Receive Payment");
             return false;
         }

         if (cboPaymentMethod.SelectedIndex == 1)
         {
            //check payment
            if (cboBank.SelectedIndex == -1)
            {
               clsUtil.ShowMessageExclamation("Invalid bank selected!", "Receive Payment");
               cboBank.Focus();
               return false;
            }
            bank = (Banks) cboBank.Properties.Items[cboBank.SelectedIndex];

            if (txtAccountNo.Text.Trim() == "")
            {
               clsUtil.ShowMessageExclamation("Invalid account number!", "Receive Payment");
               txtAccountNo.Focus();
               return false;
            }

            if (txtCheckNo.Text.Trim() == "")
            {
               clsUtil.ShowMessageExclamation("Invalid check number!", "Receive Payment");
               txtCheckNo.Focus();
               return false;
            }
            checkPayment = true;

            //check if account details is allowed for customer
            //

            PaymentsPDC pdc = new PaymentsPDC();
            pdc.AccountNumber = txtAccountNo.Text;
            pdc.Amount = m_Payment.Amount;
            pdc.bank = bank;
            pdc.CheckDate = dtCheckDate.DateTime;
            pdc.CheckNumber = txtCheckNo.Text;
            pdc.Status = (Int32) PaymentsPDC.eStatus.ForDeposit;
            m_Payment.PDCdetail = pdc;
         }

         m_Payment.AmountApplied = clsUtil.ParseDouble(lblAmountApplied.Text);
         m_Payment.counter = m_Counter;
         m_Payment.invoice = m_Invoice;
         m_Payment.Customer = customer;
         m_Payment.PaymentDate = dtDate.DateTime;
         m_Payment.PaymentType = cboPaymentMethod.SelectedIndex;
         m_Payment.user = clsUtil.GetLoggedInUser();

         //add detail
         foreach (DataRow row in tblData.Rows)
         {
            if (clsUtil.ParseBoolean(row[(Int32) eCol.Selected]))
            {
               PaymentsDetail pd = new PaymentsDetail();
               pd.Amount = clsUtil.ParseDouble(row[(Int32) eCol.Payment].ToString());
               pd.invoice = new SalesInvoice();
               pd.invoice.ID = clsUtil.ParseInt32(row[(Int32) eCol.InvoiceNo].ToString());
               m_Payment.details.Add(pd);
            }
         }

         try
         {
            mPaymentDao.Save(m_Payment);
            clsUtil.ShowMessageInformation("Payment saved!", "Receive Payment");
         }
         catch (Exception ex)
         {
            clsUtil.ShowMessageError(ex, "Save Payment");
            return false;
         }
         return true;
      }

      private void btnSaveAndClose_Click(object sender, EventArgs e)
      {
         if (SavePayment())
         {
            Canceled = false;
            this.ParentForm.Close();
         }
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         Canceled = true;
         this.ParentForm.Close();
      }
   }
}