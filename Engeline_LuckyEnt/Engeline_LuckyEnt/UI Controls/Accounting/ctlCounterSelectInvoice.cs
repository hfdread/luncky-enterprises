#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DexterHardware_v2.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace DexterHardware_v2.UI_Controls.Accounting
{
   public partial class ctlCounterSelectInvoice : UserControl
   {
      private CounterDao CounterDao = new CounterDao();
      private ContactsDao ContactsDao = new ContactsDao();
      private SalesInvoiceDao InvoiceDao = new SalesInvoiceDao();
      private bool bAllowLoad = false;
      private DateTime m_DueDate = DateTime.Now;
      private Contacts m_Customer = null;

      private const string S_ALLCUSTOMERS = "[All Customers]";

      public bool Canceled { get; set; }
      public bool BatchCounter { get; set; }

      public ctlCounterSelectInvoice()
      {
         InitializeComponent();
         BatchCounter = false;
      }

      private void ctlCounterSelectInvoice_Load(object sender, EventArgs e)
      {
         //load customers
         if (BatchCounter)
            cboCustomer.Properties.Items.Add(S_ALLCUSTOMERS);

         IList<Contacts> lst = ContactsDao.getAllCustomers();
         foreach (Contacts c in lst)
         {
            cboCustomer.Properties.Items.Add(c);
         }
         cboCustomer.SelectedIndex = -1;

         //load years
         for (int i = 0; i < 100; i++)
            cboYear.Properties.Items.Add(DateTime.Now.Year - i);
         cboYear.SelectedIndex = 0;

         for (int i = 1; i <= 12; i++)
            cboMonth.Properties.Items.Add(Microsoft.VisualBasic.DateAndTime.MonthName(i, false));
         bAllowLoad = true;
         cboMonth.SelectedIndex = DateTime.Now.Month - 1;

         if (BatchCounter)
            btnCreateCounter.Text = "Batch Counter";

         cboCustomer.Focus();
      }

      private void SetMonthEnd()
      {
         if (bAllowLoad)
         {
            int iEnd = DateTime.DaysInMonth(Convert.ToInt32(cboYear.Text), cboMonth.SelectedIndex + 1);
            if (iEnd > 30)
               iEnd = 30;
            cboDay.Properties.Items.Clear();
            cboDay.Properties.Items.Add("15");
            cboDay.Properties.Items.Add(iEnd.ToString());

            if (DateTime.Now.Day > 15)
               cboDay.SelectedIndex = 1;
            else
               cboDay.SelectedIndex = 0;
         }
      }

      private void btnGetInvoices_Click(object sender, EventArgs e)
      {
         if (cboCustomer.SelectedIndex == -1)
         {
            cUtil.ShowMessageExclamation("Invalid customer!", "New Counter");
            cboCustomer.Focus();
            return;
         }
         else if (BatchCounter && cboCustomer.Text == S_ALLCUSTOMERS)
         {
            m_Customer = null;
         }
         else
            m_Customer = (Contacts) cboCustomer.SelectedItem;

         DateTime counterduedate;
         try
         {
            counterduedate =
               Convert.ToDateTime(string.Format("{0} {1}, {2} 11:59:59 PM", cboMonth.Text, cboDay.Text, cboYear.Text));
            m_DueDate = counterduedate;
         }
         catch
         {
            cUtil.ShowMessageExclamation("Invalid counter due date!", "New Counter");
            cboYear.Focus();
            return;
         }

         IList<SalesInvoice> lst = null;
         if (m_Customer != null)
            lst = InvoiceDao.getAllRecordsForCounter(m_Customer.ID, counterduedate);
         else
            lst = InvoiceDao.getAllRecordsForCounter(0, counterduedate);
         grdInvoices.DataSource = lst;

         btnCreateCounter.Enabled = (lst.Count > 0);
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         cUtil.getMainForm().CloseCurrentControl();
      }

      private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
      {
         SetMonthEnd();
      }

      private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
      {
         SetMonthEnd();
      }

      private void grdvInvoices_CustomUnboundColumnData(object sender,
                                                        DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
      {
         SalesInvoice si = (SalesInvoice) grdvInvoices.GetRow(e.RowHandle);
         if (si != null)
         {
            if (e.IsGetData && e.Column.FieldName == "duedate")
            {
               e.Value = si.InvoiceDate.AddDays(si.Terms);
            }
            else if (e.IsGetData && e.Column.FieldName == "invoicestatus")
            {
               e.Value = ((SalesInvoice.ePaymentStatus) si.PaymentStatus).ToString();
            }
         }
      }

      private void btnCreateCounter_Click(object sender, EventArgs e)
      {
         if (BatchCounter && cboCustomer.SelectedIndex == 0)
         {
            ProcessBatchCounter();
            return;
         }

         double Amount = 0;
         IList<SalesInvoice> lst = (IList<SalesInvoice>) grdInvoices.DataSource;
         IList<SalesInvoice> tmp = new List<SalesInvoice>();

         foreach (SalesInvoice si in lst)
         {
            if (si.Selected)
            {
               tmp.Add(si);
               Amount += si.AmountDue;
            }
         }

         if (tmp.Count == 0)
         {
            cUtil.ShowMessageExclamation("Please select at least 1 invoice!", "New Counter");
            return;
         }

         Counter counter = new Counter();
         counter.CounterDate = DateTime.Now;
         counter.CounterDueDate = m_DueDate;
         counter.Customer = m_Customer;
         counter.Amount = Amount;

         //add details
         foreach (SalesInvoice s in tmp)
         {
            CounterDetails cd = new CounterDetails();
            cd.invoice = s;
            counter.details.Add(cd);
         }

         try
         {
            CounterDao.Save(counter);
            cUtil.ShowMessageInformation(string.Format("Counter [{0}] saved!", counter.ID.ToString(cUtil.FMT_ID)),
                                         "New Counter");

            //TODO: Print counter

            btnCancel.PerformClick();
         }
         catch (Exception ex)
         {
            if (ex.InnerException != null)
               cUtil.ShowMessageError(
                  string.Format("Error:\n{0}\n[Inner Exception]\n{1}", ex.Message, ex.InnerException.Message),
                  "New Counter");
            else
               cUtil.ShowMessageError(string.Format("Error:\n{0}", ex.Message), "New Counter");
         }
      }

      private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
      {
         IList<SalesInvoice> lst = (IList<SalesInvoice>) grdInvoices.DataSource;
         if (lst != null)
         {
            foreach (SalesInvoice si in lst)
            {
               si.Selected = chkSelectAll.Checked;
            }
            grdInvoices.RefreshDataSource();
         }
      }

      private void ProcessBatchCounter()
      {
         //get all customers to be countered
         List<Int32> lstCustomerIDs = new List<Int32>();
         foreach (SalesInvoice si in (IList<SalesInvoice>) grdInvoices.DataSource)
         {
            if (si.Selected)
            {
               if (!lstCustomerIDs.Contains(si.Customer.ID))
                  lstCustomerIDs.Add(si.Customer.ID);
            }
         }

         string sDueDate = "";
         double amount = 0;
         foreach (Int32 x in lstCustomerIDs)
         {
            //get unique counter due dates for each customer
            List<String> lstDueDates = new List<string>();
            foreach (SalesInvoice si in (IList<SalesInvoice>) grdInvoices.DataSource)
            {
               if (si.Selected && si.Customer.ID == x)
               {
                  sDueDate = si.InvoiceDate.AddDays(si.Terms).ToString(cUtil.FMT_DATE1);
                  if (!lstDueDates.Contains(sDueDate))
                     lstDueDates.Add(sDueDate);
               }
            }

            //create counters for customer
            foreach (string s in lstDueDates)
            {
               Counter c = new Counter();
               c.CounterDate = DateTime.Now;
               c.CounterDueDate = c.GetDueDate(DateTime.Parse(s + " 12:00 AM"));
               c.Customer = new Contacts();
               c.Customer.ID = x;

               amount = 0;
               foreach (SalesInvoice si in (IList<SalesInvoice>) grdInvoices.DataSource)
               {
                  if (si.Selected)
                  {
                     sDueDate = si.InvoiceDate.AddDays(si.Terms).ToString(cUtil.FMT_DATE1);
                     if (si.Customer.ID == x && sDueDate == s)
                     {
                        CounterDetails cd = new CounterDetails();
                        cd.invoice = si;
                        c.details.Add(cd);
                        amount += si.AmountDue;
                     }
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
         }
         btnCancel.PerformClick();
      }
   }
}