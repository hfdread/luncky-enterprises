#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Accounting
{
   public partial class ctlPaymentPDC : UserControl
   {
      private BanksDao BankDao = null;

      public bool Canceled { get; set; }
      public Contacts customer { get; set; }
      public Double Amount { get; set; }
      public PaymentsPDC paymentcheck { get; set; }

      public ctlPaymentPDC()
      {
         InitializeComponent();

         BankDao = new BanksDao();
      }

      private void ctlPaymentPDC_Load(object sender, EventArgs e)
      {
         txtAmount.Text = Amount.ToString(clsUtil.FMT_AMOUNT);

         IList<Banks> lst = BankDao.getAllRecords();
         foreach (Banks bank in lst)
         {
            cboBank.Properties.Items.Add(bank);
         }
         cboBank.SelectedIndex = -1;
         cboBank.Focus();
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         const string TITLE = "PDC Payment";
         string AccountNumber, CheckNo;
         Banks bank;
         double Amount = 0;

         //validate
         if (cboBank.SelectedIndex == -1)
         {
            clsUtil.ShowMessageExclamation("Please select bank!", TITLE);
            cboBank.Focus();
            return;
         }
         bank = (Banks) cboBank.SelectedItem;

         if (txtAccountNo.Text == "")
         {
            clsUtil.ShowMessageExclamation("Invalid account number!", TITLE);
            txtAccountNo.Focus();
            return;
         }
         AccountNumber = txtAccountNo.Text;

         if (txtCheckNo.Text == "")
         {
            clsUtil.ShowMessageExclamation("Invalid check number!", TITLE);
            txtCheckNo.Focus();
            return;
         }
         CheckNo = txtCheckNo.Text;

         Amount = clsUtil.CheckValue(txtAmount);
         if (Amount == 0)
         {
            clsUtil.ShowMessageExclamation("Invalid amount!", TITLE);
            txtAmount.Focus();
            return;
         }

         paymentcheck = new PaymentsPDC();
         paymentcheck.CheckDate = dtCheckDate.DateTime;
         paymentcheck.AccountNumber = AccountNumber;
         paymentcheck.CheckNumber = CheckNo;
         paymentcheck.bank = bank;
         paymentcheck.Amount = Amount;
         paymentcheck.Status = (Int32) PaymentsPDC.eStatus.ForDeposit;

         Canceled = false;
         this.ParentForm.Close();
      }

      private void txtAmount_Enter(object sender, EventArgs e)
      {
         ((DevExpress.XtraEditors.TextEdit) sender).SelectAll();
      }

      private void simpleButton1_Click(object sender, EventArgs e)
      {
         Canceled = true;
         this.ParentForm.Close();
      }
   }
}