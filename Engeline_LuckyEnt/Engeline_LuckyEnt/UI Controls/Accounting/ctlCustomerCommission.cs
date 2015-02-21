#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DexterHardware_v2.Classes;
using DexterHardware_v2.UI_Controls.Transactions;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using DexterHardware_v2.Reports;
#endregion

namespace DexterHardware_v2.UI_Controls.Accounting
{
   public partial class ctlCustomerCommission : UserControl
   {
      private readonly CustomerCommissionDao CommissionDao = new CustomerCommissionDao();
      private readonly ContactsDao ContactsDao = new ContactsDao();

      private bool m_bIsLoading = true;

      public ctlCustomerCommission()
      {
         InitializeComponent();
      }

      private void ctlCustomerCommission_Load(object sender, EventArgs e)
      {
         //load Customers
         lstCustomers.DataSource = ContactsDao.getAllCustomers();

         dtRange.SetDateSelection(ctlDateRange.eDateSelection.Today);
      }

      private void btnRefresh_Click(object sender, EventArgs e)
      {
         Contacts cust = (Contacts) lstCustomers.SelectedItem;
         if (cust != null)
         {
            //get customer commissions
            IList<CustomerCommission> lst = CommissionDao.getAllRecordsByCustomer(cust.ID, dtRange.getDateFrom(),
                                                                                  dtRange.getDateTo());
            grdCommission.DataSource = lst;
         }
      }

      private void grdvCommission_CustomUnboundColumnData(object sender,
                                                          DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
      {
         CustomerCommission c = (CustomerCommission) grdvCommission.GetRow(e.RowHandle);
         if (e.IsGetData && e.Column.FieldName == "Percent")
         {
            e.Value = (c.Amount/c.Invoice.AmountDue)*100;
         }
         else if (e.IsGetData && e.Column.FieldName == "CommissionStatus")
         {
            switch (c.Status)
            {
               case (Int32) CustomerCommission.eStatus.Pending:
                  e.Value = "Pending";
                  break;
               case (Int32) CustomerCommission.eStatus.Released:
                  e.Value = "Released";
                  break;
            }
         }
      }

      private void grdvCommission_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
      {
         CustomerCommission c = (CustomerCommission) grdvCommission.GetRow(e.RowHandle);
         if (c != null)
         {
            if (e.Column.FieldName == "Invoice.ID")
            {
               //show invoice detail
               ctlSalesInvoice ctl = new ctlSalesInvoice();
               ctl.m_SalesInvoice = c.Invoice;
               ctl.m_InvoiceType = (SalesInvoice.eInvoiceType) c.Invoice.InvoiceType;
               cUtil.getMainForm().LoadCtl(ctl, false, "View Sales Invoice", "", false);
            }
         }
      }

      private void btnReleasePrint_Click(object sender, EventArgs e)
      {
         CustomerCommission c = (CustomerCommission) grdvCommission.GetRow(grdvCommission.FocusedRowHandle);
         if (ReleaseCommission(c))
         {
            //print commision
            btnPrint.PerformClick();
         }
      }

      private bool ReleaseCommission(CustomerCommission c)
      {
         if (c != null)
         {
            if (c.Status == (int) CustomerCommission.eStatus.Released)
            {
               cUtil.ShowMessageExclamation("Selected commission has already been released!",
                                            "Release Customer Commission");
               return false;
            }

            if (cUtil.ShowMessageYesNo("Release commission to customer?", "Release Commission") == DialogResult.Yes)
            {
               c.Status = (Int32) CustomerCommission.eStatus.Released;
               try
               {
                  CommissionDao.Save(c);
                  cUtil.ShowMessageInformation("Commission released!", "Release Customer Commission");
                  return true;
               }
               catch (Exception ex)
               {
                  cUtil.ShowMessageError(ex.Message);
                  return false;
               }
            }
         }
         return false;
      }

      private void btnRelease_Click(object sender, EventArgs e)
      {
         CustomerCommission c = (CustomerCommission) grdvCommission.GetRow(grdvCommission.FocusedRowHandle);
         ReleaseCommission(c);
         grdCommission.RefreshDataSource();
      }

      private void dtRange_DateSelectionChanged(object sender, EventArgs e)
      {
         if (m_bIsLoading)
            return;

         if(dtRange.GetDateSelection() != ctlDateRange.eDateSelection.Custom )
            btnRefresh.PerformClick();
      }

      private void btnPrint_Click(object sender, EventArgs e)
      {
         CustomerCommission cc = (CustomerCommission) grdvCommission.GetRow(grdvCommission.FocusedRowHandle);
         if(cc!=null)
         {
            rptCustomerCommission rpt = new rptCustomerCommission();
            //rpt.DataSource = cc;
            rpt.bindingSource1.DataSource = cc;
            rpt.ShowPreviewDialog();
         }
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         cUtil.getMainForm().CloseCurrentControl();
      }
   }
}