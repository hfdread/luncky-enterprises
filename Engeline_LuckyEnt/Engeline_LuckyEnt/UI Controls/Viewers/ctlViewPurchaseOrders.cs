#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.UI_Controls.Transactions;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
//using Engeline_LuckyEnt.Reports;
#endregion

namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
   public partial class ctlViewPurchaseOrders : UserControl
   {
      private PurchaseOrderDao PurchaseOrderDao = new PurchaseOrderDao();
      private WarehouseDao warehouseDao = new WarehouseDao();
      private bool m_bIsLoading = true;

      public ctlViewPurchaseOrders()
      {
         InitializeComponent();
      }

      private void ctlViewPurchaseOrders_Load(object sender, EventArgs e)
      {
         dtRange.SetDateSelection(ctlDateRange.eDateSelection.Today);
         m_bIsLoading = false;
         btnRefresh.PerformClick();
      }

      private void btnRefresh_Click(object sender, EventArgs e)
      {
         /*if(clsUtil.GetUserPermissions().PO_ViewSuppliersManila==0)
         {
            grdPO.DataSource = PurchaseOrderDao.GetAllRecordsByDateRange(dtRange.getDateFrom(), dtRange.getDateTo(), false, true);
         }
         else
         {*/
            grdPO.DataSource = PurchaseOrderDao.GetAllRecordsByDateRange(dtRange.getDateFrom(), dtRange.getDateTo(), true, true);
         //}
      }

      private void grdvPO_CustomUnboundColumnData(object sender,
                                                  DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
      {
         PurchaseOrder PO = (PurchaseOrder) grdvPO.GetRow(e.RowHandle);

         if (e.IsGetData && e.Column.FieldName == "PO_Status")
         {
            switch (PO.Status)
            {
               case (int) PurchaseOrder.eStatus.NG:
                  e.Value = "NG";
                  break;
               case (int) PurchaseOrder.eStatus.OK:
                  e.Value = "OK";
                  break;
               case (int) PurchaseOrder.eStatus.PENDING:
                  e.Value = "PENDING";
                  break;
               default:
                  e.Value = "";
                  break;
            }
         }
         else if (e.IsGetData && e.Column.FieldName == "PO_Excess")
         {
            if (PO.Excess)
            {
               e.Value = "Yes";
            }
            else
            {
               e.Value = "No";
            }
         }
         else if (e.IsGetData && e.Column.FieldName == "warehouse")
         {
             Warehouse W = warehouseDao.GetWHById(PO.WarehouseID);
             e.Value = string.Format("{0}, {1}", W.ID, W.Name);
         }

      }

      private void mnuViewPO_Click(object sender, EventArgs e)
      {
         btnViewPO.PerformClick();
      }

      private void mnuNewPO_Click(object sender, EventArgs e)
      {
         btnNewPO.PerformClick();
      }

      private void btnViewPO_Click(object sender, EventArgs e)
      {
         PurchaseOrder PO = (PurchaseOrder) grdvPO.GetRow(grdvPO.FocusedRowHandle);
         if (PO != null)
         {
            ctlPurchaseOrder ctl = new ctlPurchaseOrder();

            ctl.PreviousCtl = this;
            ctl.purchaseorder = PO;
            clsUtil.getMainForm().LoadCtl(ctl, false,string.Format("Purchase Order [{0}]",PO.ID.ToString(clsUtil.FMT_ID)), "", false);
         }
      }

      private void btnNewPO_Click(object sender, EventArgs e)
      {
         //check permission
          //temporary commented
         /*if(clsUtil.GetUserPermissions().PO_Add==0)
         {
            clsUtil.ShowMessagePermissionNotAllowed();
            return;
         }*/
         
         ctlPurchaseOrder ctl = new ctlPurchaseOrder();
         clsUtil.getMainForm().LoadCtl(ctl, true, "New Purchase Order", "", false);
      }

      private void btnCancelPO_Click(object sender, EventArgs e)
      {
         /*if (clsUtil.getMainForm().g_Permissions.PO_Delete != 1)
         {
            clsUtil.ShowMessagePermissionNotAllowed();
            return;
         }*/

         PurchaseOrder PO = (PurchaseOrder) grdvPO.GetRow(grdvPO.FocusedRowHandle);
         if (PO != null)
         {
            if (!PO.Canceled)
            {
               if (
                  clsUtil.ShowMessage(string.Format("Cancel Purchase Order [{0}]?", PO.ID.ToString("000000")),
                                    "Cancel Purchase Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                  DialogResult.Yes)
               {
                  //check first if PO is allowed to be canceled
                  if (PurchaseOrderDao.AllowCancel(PO))
                  {
                     PO.Canceled = true;
                     PurchaseOrderDao.Save(PO);
                     grdPO.RefreshDataSource();
                  }
                  else
                  {
                     clsUtil.ShowMessage("Purchase Order cannot be canceled since it is used in other transactions.",
                                       "Cancel Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  }
               }
            }
         }
      }

      private void mnuCancelPO_Click(object sender, EventArgs e)
      {
         btnCancelPO.PerformClick();
      }

      private void dtRange_DateSelectionChanged(object sender, EventArgs e)
      {
         if (m_bIsLoading)
            return;

         if (dtRange.GetDateSelection() != ctlDateRange.eDateSelection.Custom)
            btnRefresh.PerformClick();
      }

      private void btnPrint_Click(object sender, EventArgs e)
      {
         //rptPurchaseOrder rpt = new rptPurchaseOrder();
         //rpt.lblDate.Text = dtRange.GetDateRange();
            //rpt.DataSource = (IList<PurchaseOrder>) grdPO.DataSource;
         //rpt.DataSource = grdPO.DataSource;
         //rpt.ShowPreviewDialog();
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         clsUtil.getMainForm().CloseCurrentControl();
      }
   }
}