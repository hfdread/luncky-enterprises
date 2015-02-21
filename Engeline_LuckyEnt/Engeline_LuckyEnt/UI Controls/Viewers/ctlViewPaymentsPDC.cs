#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DexterHardware_v2.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace DexterHardware_v2.UI_Controls.Viewers
{
   public partial class ctlViewPaymentsPDC : UserControl
   {
      private PaymentsDao mPaymentsDao = new PaymentsDao();
      private PaymentsDetailDao mPaymentsDetailDao = new PaymentsDetailDao();
      private PaymentsPDCDao mPaymentsPdcDao = new PaymentsPDCDao();
      private bool m_bIsLoading = true;

      public bool Canceled { get; set; }
      public UserControl ParentCtl { get; set; }

      public ctlViewPaymentsPDC()
      {
         InitializeComponent();
      }

      private void ctlViewPaymentsPDC_Load(object sender, EventArgs e)
      {
         cboStatus.SelectedIndex = 0;
         m_bIsLoading = false;
         btnRefresh.PerformClick();
      }

      private void btnRefresh_Click(object sender, EventArgs e)
      {
         Int32 iStatus = PaymentsPDC.GetStatus(cboStatus.Text);
         IList<Payments> lstPayments = mPaymentsDao.getAllPaymentsPDC(0, iStatus, dtRange.getDateFrom(),
                                                                     dtRange.getDateTo());
         grdChecks.DataSource = lstPayments;
      }

      private void grdvChecks_CustomUnboundColumnData(object sender,
                                                      DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
      {
         if (e.IsGetData && e.Column.FieldName == "CheckStatus")
         {
            Payments p = (Payments) grdvChecks.GetRow(e.RowHandle);
            if (p != null)
               e.Value = PaymentsPDC.GetStatus((int) p.PDCdetail.Status);
            else
               e.Value = "";
         }
      }

      private void btnSearch_Click(object sender, EventArgs e)
      {
         if (cboSearchFilter.SelectedIndex == -1)
         {
            cUtil.ShowMessageExclamation("Invalid Filter", "Search Checks");
            cboSearchFilter.Focus();
            return;
         }

         IList<Payments> lst = null;
         if (cboSearchFilter.Text.ToLower() == "account no.")
         {
            lst = mPaymentsDao.GetAllRecordsByField("PDCdetail.AccountNumber", txtSearchField.Text, false);
         }
         else if (cboSearchFilter.Text.ToLower() == "check no.")
         {
            lst = mPaymentsDao.GetAllRecordsByField("PDCdetail.CheckNumber", txtSearchField.Text, false);
         }
         else if (cboSearchFilter.Text.ToLower() == "bank")
         {
            lst = mPaymentsDao.GetAllRecordsByField("PDCdetail.bank.Name", txtSearchField.Text, false);
         }
         lblRecordsFound.Text = lst.Count.ToString();
         grdChecks.DataSource = lst;
      }

      private void btnCheckGood_Click(object sender, EventArgs e)
      {
         Payments p = (Payments) grdvChecks.GetRow(grdvChecks.FocusedRowHandle);
         if (p != null)
         {
            UpdatePDC(p, PaymentsPDC.eStatus.Good);
         }
      }

      private void chkViewCheckForClearing_CheckedChanged(object sender, EventArgs e)
      {
         IList<Payments> lstPDC = null;
         if (chkViewCheckForClearing.Checked)
         {
            lstPDC = mPaymentsDao.GetChecksForClearing(DateTime.Now.Date);

            //update checks
            foreach (Payments p in lstPDC)
            {
               try
               {
                  mPaymentsDao.UpdatePDC(p, (int) p.PDCdetail.Status, (int) PaymentsPDC.eStatus.Good);
               }
               catch (Exception ex)
               {
                  cUtil.ShowMessageError(ex,
                                         string.Format("Check status update failed [Check No. {0}]",
                                                       p.PDCdetail.CheckNumber));
               }
            }

            //show checks
            lblRecordsFound.Text = lstPDC.Count.ToString();
            grdChecks.DataSource = lstPDC;
         }
         else
         {
            btnRefresh.PerformClick();
         }
      }

      private void dtRange_DateSelectionChanged(object sender, EventArgs e)
      {
         if (m_bIsLoading)
            return;

         if(dtRange.GetDateSelection() != ctlDateRange.eDateSelection.Custom)
            btnRefresh.PerformClick();
      }

      private void btnBounced_Click(object sender, EventArgs e)
      {
         Payments p = (Payments)grdvChecks.GetRow(grdvChecks.FocusedRowHandle);
         if (p != null)
         {
            UpdatePDC(p, PaymentsPDC.eStatus.Bounced);
         }
      }

      private void UpdatePDC(Payments p, PaymentsPDC.eStatus newStatus)
      {
         //get updated PDC detail
         Payments updatedP = mPaymentsDao.GetById(p.ID);

         if (updatedP.PDCdetail.Status != newStatus)
         {
            int ret = mPaymentsDao.UpdatePDC(updatedP, (int)updatedP.PDCdetail.Status, (int)newStatus);
            if (ret == 0)
            {
               p.PDCdetail.Status = newStatus;
               grdChecks.RefreshDataSource();
               cUtil.ShowMessageInformation("PDC updated successfully!", "Update PDC");
            }
            else
            {
               cUtil.ShowMessageError(mPaymentsDao.ErrorMessage, "Update PDC");
            }
         }
         else
         {
            //do nothing since status is the same            
         }
      }

      private void btnCheckReturned_Click(object sender, EventArgs e)
      {
         Payments p = (Payments)grdvChecks.GetRow(grdvChecks.FocusedRowHandle);
         if (p != null)
         {
            UpdatePDC(p, PaymentsPDC.eStatus.Returned);
         }
      }
   }
}