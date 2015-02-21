#region 

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.Forms;
using Engeline_LuckyEnt.UI_Controls;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
    public partial class ctlStatementofAccount_ReceivePayment : UserControl
    {
        private const string FMT_AMOUNT = "#,##0.00";
        private const string FMT_ID = "000000";
        private StatementofAccountDao socDao = new StatementofAccountDao();
        private SOC_PaymentsDao socpDao = new SOC_PaymentsDao();
        private double balNew = 0;
        private BanksDao mBanksDao = null;

        public StatementofAccount soc = null;
        public SOC_Payments socp = null;

        public ctlStatementofAccount_ReceivePayment()
        {
            InitializeComponent();

            socp = new SOC_Payments();
            mBanksDao = new BanksDao();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void ctlStatementofAccount_ReceivePayment_Load(object sender, EventArgs e)
        {
            LoadSOC();
            LoadBanks();
            txtChequeNumber.Focus();
            dtDue.DateTime = DateTime.Now;
            dtIssue.DateTime = DateTime.Now;
        }

        public void LoadSOC()
        {
            if (soc != null)
            {
                double Amt = 0, Bal = 0, PaymentHistory=0;
                txtInvoiceNo.Text = soc.ID.ToString(FMT_ID);
                txtSupplier.Text = soc.Supplier.ToString();
                txtShipName.Text = soc.ShippingCompany.ToString() + "-" + soc.ShipName;
                Amt = soc.AmountDue;
                
                //get history of partial payments
                IList<SOC_Payments> lst = socpDao.GetAllPartialPayments(soc.ID);
                if (lst.Count > 0)
                {
                    foreach (SOC_Payments payments in lst)
                    {
                        PaymentHistory += payments.Amount;
                    }
                }

                Bal = Amt - PaymentHistory;
                balNew = Bal;

                lblAmtDue.Text = Amt.ToString(FMT_AMOUNT);
                lblBalance.Text = Bal.ToString(FMT_AMOUNT);
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

        private void btnPay_Click(object sender, EventArgs e)
        {
            double amt = clsUtil.CheckValue(txtPayment);
            if (amt <= 0)
            {
                clsUtil.ShowMessageExclamation("Payment Amount must be greater than 0", "Payment for Statement of Account");
                txtPayment.Focus();
                return;
            }

            if (amt > balNew)
            {
                clsUtil.ShowMessageExclamation("Payment Amount is greater than the balance", "Payment for Statement of Account");
                txtPayment.Focus();
                return;
            }

            if (txtChequeNumber.Text.Trim() != "")
            {
                if (cboBank.Text.Trim() == "")
                {
                    clsUtil.ShowMessageExclamation("Please specify the Bank.", "Payment for Statement of Account");
                    cboBank.Focus();
                    return;
                }
                else
                {
                    socp.Bank = cboBank.Text;
                    socp.Issue_Date = dtIssue.DateTime;
                    socp.Due_Date = dtDue.DateTime;
                }
            }
            
            socp.statementofaccount = soc;
            socp.Amount = amt;
            socp.Payment_Date = DateTime.Now;
            socp.Chequenumber = txtChequeNumber.Text.Trim();
            socp.ctr = socpDao.GetLastCounter(socp.statementofaccount.ID) + 1;
           

            try
            {
                socpDao.Save(socp);

                double checkBal = balNew - amt;
                soc.PayDate = DateTime.Now;
                if (checkBal > 0)
                    soc.Payment = soc.GetPaymentType("ppaid");
                else
                {
                    soc.Payment = soc.GetPaymentType("paid");

                    //update stockin status also.
                    StockInDao siDao = new StockInDao();
                    StockIn si = siDao.ChangePaymentStatusPaid(soc.ID);

                    if (si != null)
                    {
                        si.Paid = true;
                        siDao.Save(si);
                    }
                }


                socDao.StatusUpdate(soc);

                if (socp.Chequenumber.Trim().Length != 0)
                    clsUtil.ShowMessageInformation(string.Format("Payment Saved! with Cheque Number {0} and Amount {1}", socp.Chequenumber, socp.Amount.ToString(FMT_AMOUNT)),
                        "Payment for Statement of Account");
                else
                    clsUtil.ShowMessageInformation(string.Format("Payment Saved! with Cash Payment {0}", socp.Amount.ToString(FMT_AMOUNT)),
                        "Payment for Statement of Account");

                btnCancel.PerformClick();
            }
            catch (Exception ex)
            {
                clsUtil.ShowMessage(string.Format("An error occurred while saving Payment!\n[{0}]", ex.Message),
                                  "Payment for Statement of Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
