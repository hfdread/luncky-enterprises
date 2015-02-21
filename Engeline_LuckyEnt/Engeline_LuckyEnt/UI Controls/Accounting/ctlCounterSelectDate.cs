#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace DexterHardware_v2.UI_Controls.Accounting
{
   public partial class ctlCounterSelectDate : UserControl
   {
      private ContactsDao ContactsDao = new ContactsDao();
      private bool bAllowLoad = false;

      public ctlCounterSelectDate()
      {
         InitializeComponent();
      }

      private void ctlCounterSelectDate_Load(object sender, EventArgs e)
      {
         //load customers
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
      }

      private void SetMonthEnd()
      {
         if (bAllowLoad)
         {
            cboDay.Properties.Items.Clear();
            cboDay.Properties.Items.Add("15");
            cboDay.Properties.Items.Add(DateTime.DaysInMonth(Convert.ToInt32(cboYear.Text), cboMonth.SelectedIndex + 1));

            if (DateTime.Now.Day > 15)
               cboDay.SelectedIndex = 1;
            else
               cboDay.SelectedIndex = 0;
         }
      }
   }
}