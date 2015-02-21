#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
//using Engeline_LuckyEnt.Reports;
using Engeline_LuckyEnt.UI_Controls.Transactions;
using Engeline_LuckyEnt.UI_Controls.Accounting;
using Engeline_LuckyEnt.Forms;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
   public partial class ctlViewSalesInvoice : UserControl
   {
      private SalesInvoiceDao mSalesInvoiceDao = new SalesInvoiceDao();
      private ContactsDao mCustomerDao = new ContactsDao();
      private bool m_bIsLoading = true;

      public ctlViewSalesInvoice()
      {
         InitializeComponent();
      }

      private void btnRefresh_Click(object sender, EventArgs e)
      {
         //get Filter conditions
         Int32 CustomerID = 0;
         if (cboCustomer.SelectedIndex > 0)
         {
            CustomerID = ((Contacts) cboCustomer.SelectedItem).ID;
         }
         Int32 paymentStatus = -1, deliverStatus =-1;
         if (cboStatus.SelectedIndex > 0)
            paymentStatus = cboStatus.SelectedIndex - 1;

         if (cboDeliverStatus.SelectedIndex > 0)
             deliverStatus = cboDeliverStatus.SelectedIndex - 1;

         IList<SalesInvoice> lst = mSalesInvoiceDao.getAllRecordsByCriteria(CustomerID, dtRange.getDateFrom(),
                                                                     dtRange.getDateTo(), paymentStatus, deliverStatus);
         grdInvoices.DataSource = lst;
      }

      private void ctlViewSalesInvoice_Load(object sender, EventArgs e)
      {
         //load customers
         IList<Contacts> customers = mCustomerDao.getAllCustomers();

         cboCustomer.Properties.Items.Add("ALL");
         foreach (Contacts c in customers)
         {
            cboCustomer.Properties.Items.Add(c);
         }
         cboCustomer.SelectedIndex = 0;
         m_bIsLoading = false;
         btnRefresh.PerformClick();
      }

      private void grdvInvoices_CustomUnboundColumnData(object sender,
                                                        DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
      {
         SalesInvoice si = (SalesInvoice) grdvInvoices.GetRow(e.RowHandle);
         if (e.IsGetData && e.Column.FieldName == "_Terms")
         {
            if (si.Terms != 0)
               e.Value = si.Terms;
         }
         else if (e.IsGetData && e.Column.FieldName == "_PaymentType")
         {
            e.Value = ((SalesInvoice.ePaymentType) si.PaymentType).ToString();
         }
         else if (e.IsGetData && e.Column.FieldName == "_PaymentStatus")
         {
            e.Value = ((SalesInvoice.ePaymentStatus) si.PaymentStatus).ToString();
         }
      }

      private void cmMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
      {
         SalesInvoice invoice = (SalesInvoice) grdvInvoices.GetRow(grdvInvoices.FocusedRowHandle);
         if (invoice != null)
         {
            mnuBadDebt.Enabled = !invoice.BadDebt;
            mnuCancelInvoice.Enabled = !invoice.Deleted;

             //set receive payment button
            mnuReceivePayment.Enabled = true;
            if (invoice.Deleted || invoice.BadDebt || invoice.InvoiceType == 0)
               mnuReceivePayment.Enabled = false;
            else
            {
               if (invoice.PaymentStatus == (int)SalesInvoice.ePaymentStatus.Paid ||
                        invoice.PaymentStatus == (int)SalesInvoice.ePaymentStatus.ForDeposit)
                  mnuReceivePayment.Enabled = false;
            }

             //set deliver button
            if (invoice.is_delivered)
                mnuDelivered.Enabled = false;
            else
                mnuDelivered.Enabled = true;

         }
         else
         {
            mnuBadDebt.Enabled = false;
            mnuCancelInvoice.Enabled = false;
            mnuViewInvoice.Enabled = false;
            mnuReceivePayment.Enabled = false;
            mnuDelivered.Enabled = false;
         }
      }

      private void repoLink_Click(object sender, EventArgs e)
      {
      }

      private SalesInvoice GetSelectedInvoice()
      {
         return (SalesInvoice) grdvInvoices.GetRow(grdvInvoices.FocusedRowHandle);
      }

      private void grdvInvoices_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
      {
          if (e.Column.FieldName == "ID")
          {
              mnuViewInvoice.PerformClick();
          }
      }

      private void grdInvoices_Click(object sender, EventArgs e)
      {
      }

      private void mnuCancelInvoice_Click(object sender, EventArgs e)
      {
         SalesInvoice invoice = (SalesInvoice) grdvInvoices.GetRow(grdvInvoices.FocusedRowHandle);
         if (invoice != null)
         {
            //check permission
            //if(clsUtil.GetUserPermissions().SIV_Delete!=1)
            //{
            //   switch (clsUtil.GetUserPermissions().SIV_Delete)
            //   {
            //      case 0:
            //         clsUtil.ShowMessagePermissionNotAllowed();
            //         return;
            //      case 2:     //ask permission
            //         string msg = string.Format("[Cancel Invoice]{0}{0}Invoice ID: {1}{0}Customer: {2}{0}",Environment.NewLine,invoice.ID.ToString(clsUtil.FMT_ID),invoice.Customer);
            //         msg += string.Format("Transaction Date: {0}{1}", invoice.InvoiceDate.ToString(clsUtil.FMT_DATE1),Environment.NewLine);
            //         msg += string.Format("Transaction Amount: {0}{1}", invoice.AmountDue.ToString(clsUtil.FMT_AMOUNT), Environment.NewLine);
            //         msg += string.Format("Payments: {0}{1}", invoice.getTotalPayments().ToString(clsUtil.FMT_AMOUNT), Environment.NewLine);
            //         //if(!clsUtil.ProcessApprovalRequest(msg, RequestApproval.eRequestType.General))
            //         //{
            //         //   return;
            //         //}

                     
            //         break;
            //      default:
            //         clsUtil.ShowMessagePermissionNotAllowed();
            //         return;
            //   }
            //}



            if (clsUtil.ShowMessageYesNo(string.Format("Cancel selected invoice?\nAll payments made will also be canceled."), "Cancel Invoice") == DialogResult.Yes)
            {
               try
               {
                   if (grdvInvoices.SelectedRowsCount > 0)
                   {
                       foreach (int rowID in grdvInvoices.GetSelectedRows())
                       {
                           SalesInvoice si = (SalesInvoice)grdvInvoices.GetRow(rowID);
                           if (si != null)
                           {
                               mSalesInvoiceDao.Delete(si);
                           }
                       }
                   }
                 
                  clsUtil.ShowMessageInformation("Invoice canceled!", "Cancel Invoice");
                  btnRefresh.PerformClick();
               }
               catch (Exception ex)
               {
                  clsUtil.ShowMessageError(ex, "Cancel Invoice");
               }
            }
         }
      }

      private void btnPrint_Click(object sender, EventArgs e)
      {
         //rptSalesInvoiceViewer rpt = new rptSalesInvoiceViewer();
         //rpt.DataSource = (IList<SalesInvoice>) grdInvoices.DataSource;
         //if (dtRange.GetDateSelection() != ctlDateRange.eDateSelection.Today)
         //   rpt.lblDate.Text = string.Format("From {0} To {1}", dtRange.getDateFrom().ToString("MMM dd, yyyy"),
         //                                    dtRange.getDateTo().ToString("MMM dd, yyyy"));
         //else
         //   rpt.lblDate.Text = dtRange.getDateFrom().ToString("MMM dd, yyyy");
         //rpt.ShowPreviewDialog();
      }

      private void dtRange_DateSelectionChanged(object sender, EventArgs e)
      {
         if (m_bIsLoading)
            return;

         if (dtRange.GetDateSelection() != ctlDateRange.eDateSelection.Custom)
            btnRefresh.PerformClick();
      }

      private void mnuBadDebt_Click(object sender, EventArgs e)
      {
         //if(clsUtil.GetUserPermissions().SIV_Edit == 1)
         //{
            SalesInvoice si = GetSelectedInvoice();
            if(si!=null)
            {
               si = mSalesInvoiceDao.GetById(si.ID);
               if(!si.BadDebt)
               {
                  if(mSalesInvoiceDao.SetBadDebt(si)==0)
                  {
                     grdvInvoices.SetRowCellValue(grdvInvoices.FocusedRowHandle, "BadDebt", true);
                     clsUtil.ShowMessageInformation("Operation successful!", "Set BadDebt");
                  }
                  else
                  {
                     clsUtil.ShowMessageError(mSalesInvoiceDao.ErrorMessage, "Set BadDebt");
                  }
               }
            }
         //}
         //else
         //{
         //   clsUtil.ShowMessagePermissionNotAllowed();
         //}
      }

      private void mnuViewInvoice_Click(object sender, EventArgs e)
      {
         SalesInvoice si = GetSelectedInvoice();
         if (si != null)
         {
            ctlSalesInvoice ctl = new ctlSalesInvoice();
            ctl.m_SalesInvoice = si;
            ctl.m_InvoiceType = (SalesInvoice.eInvoiceType)si.InvoiceType;
            clsUtil.getMainForm().LoadCtl(ctl, false, string.Format("Sales Invoice [{0}]",si.ID.ToString(clsUtil.FMT_ID)), "", false);
         }
      }

      private void mnuReceivePayment_Click(object sender, EventArgs e)
      {
          ctlReceivePayment ctl = new ctlReceivePayment();
          IList<SalesInvoice> lstSales = new List<SalesInvoice>();

          if (grdvInvoices.SelectedRowsCount > 1)
          {
              foreach (int rowID in grdvInvoices.GetSelectedRows())
              {
                  SalesInvoice si = (SalesInvoice)grdvInvoices.GetRow(rowID);
                  lstSales.Add(si);
              }
          }
          else
          {
              SalesInvoice si = GetSelectedInvoice();
              if (si != null)
              {
                  ctl.m_Customer = si.Customer;
                  ctl.m_Invoice = si;
                  if(si.CounterID!=0)
                  {
                      CounterDao dao = new CounterDao();
                      ctl.m_Counter = dao.GetById(si.CounterID);
                  }
              }
          }

          ctl.sel_SalesInvoices = lstSales;

          frmGenericPopup frm = new frmGenericPopup();
          frm.Text = "Receive Payment";
          frm.ShowCtl(ctl);
          if (!ctl.Canceled)
          {
              btnRefresh.PerformClick();
          }
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         clsUtil.getMainForm().CloseCurrentControl();
      }

      private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
      {
          btnRefresh.PerformClick();
      }

      private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
      {
          btnRefresh.PerformClick();
      }

      private void cboDeliverStatus_SelectedIndexChanged(object sender, EventArgs e)
      {
          btnRefresh.PerformClick();
      }

      private void mnuDelivered_Click(object sender, EventArgs e)
      {
          if (grdvInvoices.SelectedRowsCount > 0)
          {
              foreach (int rowID in grdvInvoices.GetSelectedRows())
              {
                  SalesInvoice si = (SalesInvoice)grdvInvoices.GetRow(rowID);
                  if (si != null)
                  {
                      mSalesInvoiceDao.UpdateDeliveredStatus(si, true);
                      btnRefresh.PerformClick();
                  }
              }
          }
      }
   }
}