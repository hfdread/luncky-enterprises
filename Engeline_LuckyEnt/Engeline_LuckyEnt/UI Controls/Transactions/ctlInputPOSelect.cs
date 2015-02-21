#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
   public partial class ctlInputPOSelect : UserControl
   {
      private PurchaseOrderDao PurchaseOrderDao = new PurchaseOrderDao();
      private StatementofAccountDao socDao = new StatementofAccountDao();
      private StockInDao sidao = new StockInDao();

      public bool Canceled { get; set; }
      public PurchaseOrder PO { get; set; }
      public StatementofAccount SOC { get; set; }
      public ctlStockIn StocknIn_ctl { get; set; }

      public ctlInputPOSelect()
      {
         InitializeComponent();
      }

      private void ctlInputPOSelect_Load(object sender, EventArgs e)
      {
         //cboStatus.SelectedIndex = (int) PurchaseOrder.eStatus.PENDING;
          cboStatus.SelectedIndex = 0;
         //PO = null;
          SOC = null;
         grdvPO.Focus();
      }

      private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
      {
         //IList<PurchaseOrder> lst = PurchaseOrderDao.GetAllRecordsByField("Status", cboStatus.SelectedIndex);
         //IList<StatementofAccount> lst = socDao.GetAllRecordsByField("Payment", cboStatus.SelectedIndex);
          IList<StockIn> lstStockin = sidao.GetAllStockInID();

          string stockInID = "(";
          foreach (StockIn si in lstStockin)
          {
              stockInID += Convert.ToString(si.ID) + ",";
          }

          try
          {
              stockInID = stockInID.Remove(stockInID.LastIndexOf(","), 1);
              stockInID += ")";
          }
          catch
          { 
              stockInID = "";
          }


          IList<StatementofAccount> lst = socDao.GetAllSOCforStockIn(stockInID, "Payment", cboStatus.SelectedIndex);
         grdPO.DataSource = lst;
         grdPO.RefreshDataSource();
      }

      private void grdvPO_CustomUnboundColumnData(object sender,
                                                  DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
      {
         //PurchaseOrder PO = (PurchaseOrder) grdvPO.GetRow(e.RowHandle);
         StatementofAccount SOC = (StatementofAccount)grdvPO.GetRow(e.RowHandle);
         if (e.IsGetData && e.Column.FieldName == "Payment")
         {
            //switch (PO.Status)
            //{
            //   case (int) PurchaseOrder.eStatus.OK:
            //      e.Value = "OK";
            //      break;
            //   case (int) PurchaseOrder.eStatus.NG:
            //      e.Value = "NG";
            //      break;
            //   case (int) PurchaseOrder.eStatus.PENDING:
            //      e.Value = "PENDING";
            //      break;
            //   default:
            //      break;
            //}

             switch (SOC.Payment)
             {
                 case 0:
                     e.Value = "PAID";
                     break;
                 case 1:
                     e.Value = "UNPAID";
                     break;
                 default:
                     break;
             }
         }
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         Canceled = true;
         PO = null;
         this.ParentForm.Close();
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         //PurchaseOrder PO = (PurchaseOrder) grdvPO.GetRow(grdvPO.FocusedRowHandle);
         //if (PO != null)
         //{
         //   this.PO = PO;
         //   Canceled = false;
         //   this.ParentForm.Close();
         //}
          StatementofAccount SOC = (StatementofAccount) grdvPO.GetRow(grdvPO.FocusedRowHandle);
          if (SOC != null)
          {
              this.SOC = SOC;
              Canceled = false;
              this.ParentForm.Close();
          }
          else
          {
              clsUtil.ShowMessage("Invalid SOC selected!", "Select SOC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
      }
   }
}