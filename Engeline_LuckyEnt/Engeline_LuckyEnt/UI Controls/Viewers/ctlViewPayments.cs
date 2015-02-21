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
   public partial class ctlViewPayments : UserControl
   {
      private PaymentsDao PaymentsDao = new PaymentsDao();

      public bool Canceled { get; set; }
      public UserControl ParentCtl { get; set; }
      
      private bool m_bIsLoading = true;

      public ctlViewPayments()
      {
         InitializeComponent();
      }

      private void btnRefresh_Click(object sender, EventArgs e)
      {
         IList<Payments> lstP = PaymentsDao.GetAllRecordsByDateRange("PaymentDate", dtRange.getDateFrom(),
                                                                     dtRange.getDateTo());
         grdPayments.DataSource = lstP;
      }

      private void grdvPayments_CellValueChanging(object sender,
                                                  DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
      {
         Payments p = (Payments) grdvPayments.GetRow(e.RowHandle);
         if (p != null)
         {
            p.Selected = true;
         }
      }

      private void btnGetUnreviewedPayments_Click(object sender, EventArgs e)
      {
         grdPayments.DataSource = PaymentsDao.getAllPaymentsForReview();
      }

      private void ctlViewPayments_Load(object sender, EventArgs e)
      {
         dtRange.SetDateSelection(ctlDateRange.eDateSelection.Today);
         m_bIsLoading = false;
         btnRefresh.PerformClick();
      }

      private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
      {
         IList<Payments> lst = (List<Payments>) grdPayments.DataSource;

         foreach (Payments p in lst)
         {
            if (!p.Canceled)
            {
               p.Reviewed = chkSelectAll.Checked;
               p.Selected = true;
            }
         }
         grdPayments.RefreshDataSource();
      }

      private void btnUpdateStatus_Click(object sender, EventArgs e)
      {
         IList<Payments> lst = (List<Payments>) grdPayments.DataSource;
         try
         {
            int ret = PaymentsDao.UpdateReviewStatus(lst);
            if (ret > 0)
            {
               cUtil.ShowMessageInformation("Successfully updated payment review status!",
                                            "Update Payment Review Status");
            }
         }
         catch (Exception ex)
         {
            cUtil.ShowMessageError(ex, "Update Payment Review Status");
         }
      }

      private void dtRange_DateSelectionChanged(object sender, EventArgs e)
      {
         
         if (m_bIsLoading)
            return;

         if (dtRange.GetDateSelection() != ctlDateRange.eDateSelection.Custom)
            btnRefresh.PerformClick();
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         cUtil.getMainForm().CloseCurrentControl();
      }
   }
}