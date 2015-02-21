#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.Forms;
using Engeline_LuckyEnt.UI_Controls.Transactions;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
//using Engeline_LuckyEnt.Reports;
#endregion

namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
   public partial class ctlViewStockIn : UserControl
   {
      private StockInDao StockinDao = new StockInDao();
      private IList<StockIn> m_lst = null;
      private bool m_bIsLoading = true;

      public ctlViewStockIn()
      {
         InitializeComponent();
      }

      private void btnRefresh_Click(object sender, EventArgs e)
      {
         m_lst = StockinDao.GetAllRecordsByDateRange("StockInDate", dtRange.getDateFrom(), dtRange.getDateTo());
         grdStockin.DataSource = m_lst;
      }

      private void ctlViewStockIn_Load(object sender, EventArgs e)
      {
          //hide unused buttons
         btnAddFreight.Visible = false;
         btnCancelStockIn.Visible = false;
         mnuAddFreight.Visible = false;
         mnuCancelStockIn.Visible = false;
         btnUnpaidSI.Visible = false;

         grdStockin.DataSource = m_lst;
         dtRange.SetDateSelection(ctlDateRange.eDateSelection.Today);
         m_bIsLoading = false;
         btnRefresh.PerformClick();
      }

      private void mnuViewStockIn_Click(object sender, EventArgs e)
      {
         btnViewStockIn.PerformClick();
      }

      private void grdStockin_Click(object sender, EventArgs e)
      {
      }

      private void grdvStockin_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
      {
         StockIn SI = (StockIn) grdvStockin.GetRow(e.RowHandle);
         if (e.Column.FieldName == "statementofaccount.ID")
         {
            //ctlPurchaseOrder ctl = new ctlPurchaseOrder();

            //ctl.PreviousCtl = this;
            //ctl.purchaseorder = SI.purchaseorder;
            //clsUtil.getMainForm().LoadCtl(ctl, false, "View Purchase Order", "", false);

             if (SI.statementofaccount != null)
             {
                 ctlStateofAccounts ctl = new ctlStateofAccounts();
                 ctl.SOC = SI.statementofaccount;
                 clsUtil.getMainForm().LoadCtl(ctl, false, string.Format("SOC [{0}]", SI.statementofaccount.ID.ToString(clsUtil.FMT_ID)), "", false);
             }
         }
         
      }

      private void mnuNewStockIn_Click(object sender, EventArgs e)
      {
         btnNewStockIn.PerformClick();
      }

      private void mnuCancelStockIn_Click(object sender, EventArgs e)
      {
         btnCancelStockIn.PerformClick();
      }

      private void btnNewStockIn_Click(object sender, EventArgs e)
      {
         /*if(clsUtil.GetUserPermissions().SI_Add!=1)
         {
            clsUtil.ShowMessagePermissionNotAllowed();
            return;
         }*/
         ctlStockIn ctl = new ctlStockIn();
         clsUtil.getMainForm().LoadCtl(ctl, true, "New Stock In", "", false);
      }

      private void btnViewStockIn_Click(object sender, EventArgs e)
      {
         StockIn SI = (StockIn) grdvStockin.GetRow(grdvStockin.FocusedRowHandle);

         if (SI != null)
         {
            ctlStockIn ctl = new ctlStockIn();

            ctl.PreviousCtl = this;
            ctl.stockin = SI;
            if (SI.damagedmissing != null)
                ctl.m_DMItem = SI.damagedmissing;
            clsUtil.getMainForm().LoadCtl(ctl, false, "Stock In", "", false);
         }
      }

      private void btnCancelStockIn_Click(object sender, EventArgs e)
      {
         /*if (clsUtil.getMainForm().g_Permissions.SI_Delete != 1)
         {
            clsUtil.ShowMessagePermissionNotAllowed();
            return;
         }*/

         StockIn SI = (StockIn) grdvStockin.GetRow(grdvStockin.FocusedRowHandle);
         if (SI != null)
         {
            if (!SI.Canceled)
            {
               if (
                  clsUtil.ShowMessage(string.Format("Cancel Stock In [{0}]?", SI.ID.ToString("000000")), "Cancel Stock In",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
               {
                  if (!StockinDao.AllowCancel(SI))
                  {
                     clsUtil.ShowMessage("Stock In cannot be canceled since it is used in other transactions.",
                                       "Cancel Stock In", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     return;
                  }

                  try
                  {
                     StockinDao.CancelStockIn(SI);
                     clsUtil.ShowMessage("Stock In canceled successfully!", "Cancel Stock In", MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
                     grdvStockin.RefreshData();
                  }
                  catch (Exception ex)
                  {
                     clsUtil.ShowMessage("Error:\n" + ex.Message, "Cancel Stock In", MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                  }
               }
            }
         }
      }

      private void mnuAddFreight_Click(object sender, EventArgs e)
      {
         btnAddFreight.PerformClick();
      }

      private void btnAddFreight_Click(object sender, EventArgs e)
      {
          //temporary commented
         /*if(clsUtil.GetUserPermissions().SI_Freight!=1)
         {
            clsUtil.ShowMessagePermissionNotAllowed();
            return;
         }*/
         
         IList<StockIn> lst = new List<StockIn>();
         ctlFreight ctl = new ctlFreight();
         frmGenericPopup frm = new frmGenericPopup();

         foreach (StockIn si in m_lst)
         {
            if (si.freight == null && !si.Canceled)
            {
               lst.Add(si);
            }
         }

         ctl.m_lstStockIn = lst;

         frm.Text = "Freight Charges";
         frm.ShowCtl(ctl);
         if (!ctl.Canceled)
         {
            btnRefresh.PerformClick();
         }
      }

      private void btnUnpaidSI_Click(object sender, EventArgs e)
      {
         m_lst = StockinDao.GetUnpaidStockIn();
         grdStockin.DataSource = m_lst;
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
         //rptStockIn rpt = new rptStockIn();
         //rpt.lblDate.Text = dtRange.GetDateRange();
         //rpt.DataSource = grdStockin.DataSource;
         //rpt.ShowPreviewDialog();
      }
   }
}