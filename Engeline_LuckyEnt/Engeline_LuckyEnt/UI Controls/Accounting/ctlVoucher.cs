#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DexterHardware_v2.Classes;
using DexterHardware_v2.Forms;
using DexterHardware_v2.UI_Controls.Transactions;
using DexterHardware_v2.UI_Controls.Viewers;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace DexterHardware_v2.UI_Controls.Accounting
{
   public partial class ctlVoucher : UserControl
   {
      private ContactsDao mSupplierDao = null;
      private VoucherDao mVoucherDao = null;
      private VoucherDetailsDao mVoucherDetailsDao = null;
      private StockInDao mStockInDao = null;

      private IList<StockIn> mLstStockIn = null;
      private IList<StockInDetails> mBODetails = null;
      private IList<PaymentsPDC> mLstPDC = null;

      public Voucher m_Voucher { get; set; }

      public ctlVoucher()
      {
         InitializeComponent();

         mLstStockIn = new List<StockIn>();
         mBODetails = new List<StockInDetails>();
         mLstPDC = new List<PaymentsPDC>();

         mSupplierDao = new ContactsDao();
         mVoucherDao = new VoucherDao();
         mVoucherDetailsDao = new VoucherDetailsDao();
         mStockInDao = new StockInDao();
      }

      private void btnAddSI_Click(object sender, EventArgs e)
      {
         if (cboSupplier.SelectedIndex == -1)
         {
            cUtil.ShowMessageExclamation("Please select supplier first!", "New Voucher");
            cboSupplier.Focus();
            return;
         }

         ctlSelectStockIn ctl = new ctlSelectStockIn();
         frmGenericPopup frm = new frmGenericPopup();

         ctl.Supplier = (Contacts) cboSupplier.SelectedItem;
         frm.Text = "Select StockIn";
         frm.ShowCtl(ctl);
         if (!ctl.Canceled)
         {
            Add_SI(ctl.m_LstSI);
            UpdateTotal();
         }
      }

      private void UpdateTotal()
      {
         Double total = 0, subtotal = 0;
         foreach (StockIn s in mLstStockIn)
         {
            total += s.AmountDue;
         }
         lblTotalStockIn.Text = string.Format("Total : {0}", total.ToString(cUtil.FMT_AMOUNT));

         //BO
         subtotal = 0;
         foreach (StockInDetails sid in mBODetails)
         {
            total -= sid.SubTotal;
            subtotal += sid.SubTotal;
         }
         lblTotalBO.Text = string.Format("Total : {0}", subtotal.ToString(cUtil.FMT_AMOUNT));

         //Payments
         subtotal = 0;
         foreach (PaymentsPDC pdc in mLstPDC)
         {
            subtotal += pdc.Amount;
         }
         lblTotalPayments.Text = string.Format("Total : {0}", subtotal.ToString(cUtil.FMT_AMOUNT));

         lblTotal.Text = total.ToString(cUtil.FMT_AMOUNT);
      }

      private void Add_SI(StockIn si)
      {
         //check if stockin already added
         bool bFound = false;
         foreach (StockIn s in mLstStockIn)
         {
            if (s.ID == si.ID)
            {
               bFound = true;
               break;
            }
         }
         if (!bFound)
         {
            mLstStockIn.Add(si);
            grdSI.RefreshDataSource();
         }
      }

      private void Add_SI(IList<StockIn> lst)
      {
         bool bFound = false;
         int ctr = 0;
         foreach (StockIn si in lst)
         {
            //check if stockin already added
            foreach (StockIn s in mLstStockIn)
            {
               if (s.ID == si.ID)
               {
                  bFound = true;
                  break;
               }
            }
            if (!bFound)
            {
               mLstStockIn.Add(si);
               ctr++;
            }
         }

         if (ctr > 0)
            grdSI.RefreshDataSource();
      }

      private void ctlVoucher_Load(object sender, EventArgs e)
      {
         grdSI.DataSource = mLstStockIn;
         grdBO.DataSource = mBODetails;
         grdPayments.DataSource = mLstPDC;

         if (m_Voucher != null)
         {
            //view voucher

            //StockIn details
            m_Voucher.details = mVoucherDetailsDao.GetByVoucherID(m_Voucher.ID);
            foreach (VoucherDetails vd in m_Voucher.details)
            {
               mLstStockIn.Add(vd.stockin);
            }
            grdSI.RefreshDataSource();

            //BO details
            if (m_Voucher.BadOrderID != 0)
            {
               BadOrderDetailsDao bodDao = new BadOrderDetailsDao();
               IList<BadOrderDetails> lstBOD = bodDao.GetByBadOrderID(m_Voucher.BadOrderID);
               foreach (BadOrderDetails bod in lstBOD)
               {
                  mBODetails.Add(bod.sid);
               }
               grdBO.RefreshDataSource();
            }

            //payments
            VoucherPaymentDao pDao = new VoucherPaymentDao();
            IList<VoucherPayment> lstP = pDao.GetByVoucherID(m_Voucher.ID);
            grdPayments.DataSource = lstP;

            UpdateTotal();
            lblTotal.Text = m_Voucher.Amount.ToString(cUtil.FMT_AMOUNT);

            btnSave.Enabled = false;
            btnAddSI.Enabled = false;
            btnRemoveSI.Enabled = false;
            btnAddBO.Enabled = false;
            btnRemoveBO.Enabled = false;
            btnPaymentAdd.Enabled = false;
            btnPaymentRemove.Enabled = false;
         }
         else
            LoadSuppliers();
      }

      private void LoadSuppliers()
      {
         IList<Contacts> lst = mSupplierDao.getAllSuppliers(false);
         foreach (Contacts c in lst)
         {
            cboSupplier.Properties.Items.Add(c);
         }
         cboSupplier.SelectedIndex = -1;
      }

      private void btnRemoveSI_Click(object sender, EventArgs e)
      {
         StockIn si = (StockIn) grdvSI.GetRow(grdvSI.FocusedRowHandle);
         if (si != null)
         {
            if (cUtil.ShowMessageYesNo("Remove selected item?", "Remove Item") == DialogResult.Yes)
            {
               grdvSI.DeleteRow(grdvSI.FocusedRowHandle);
            }
            UpdateTotal();
         }
      }

      private void cboSupplier_SelectedIndexChanged(object sender, EventArgs e)
      {
         mLstStockIn.Clear();
         grdSI.RefreshDataSource();
         UpdateTotal();
      }

      private void btnAddBO_Click(object sender, EventArgs e)
      {
         if (cboSupplier.SelectedIndex == -1)
         {
            cUtil.ShowMessageExclamation("Please select supplier first!", "New Voucher");
            cboSupplier.Focus();
            return;
         }

         ctlInputStockIn ctl = new ctlInputStockIn();
         frmGenericPopup frm = new frmGenericPopup();

         ctl.Supplier = (Contacts) cboSupplier.SelectedItem;
         frm.ShowCtl(ctl);
         if (!ctl.Cancelled)
         {
            if (ctl.StockInID != 0)
            {
               StockIn si = mStockInDao.GetById(ctl.StockInID);
               if (si != null)
               {
                  ctlBadOrder ctlBO = new ctlBadOrder();
                  ctlBO.m_StockIn = si;
                  frm.Text = string.Format("Bad Order for StockIn [{0}]", si.ID.ToString(cUtil.FMT_ID));
                  frm.ShowCtl(ctlBO);
                  if (!ctl.Cancelled)
                  {
                     foreach (StockInDetails sid in ctlBO.m_StockIn.details)
                     {
                        if (sid.QTY_To_Return > 0)
                        {
                           mBODetails.Add(sid);
                        }
                     }
                     grdBO.RefreshDataSource();
                     UpdateTotal();
                  }
               }
               else
               {
                  cUtil.ShowMessageExclamation("Invalid StockIn number!", "Bad Order");
               }
            }
         }
      }

      private void grdvBO_CustomUnboundColumnData(object sender,
                                                  DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
      {
         StockInDetails sid = (StockInDetails) grdvBO.GetRow(e.RowHandle);
         if (sid != null && e.IsGetData)
         {
            if (e.Column.FieldName == "_ItemName")
            {
               e.Value = sid.GetItemNameFull();
            }
            else if (e.Column.FieldName == "_UnitPrice")
            {
               if (sid.item != null)
               {
                  if (sid.item.IsWire)
                  {
                     if (sid.Price1 == 0)
                        e.Value = string.Format("{0}/mtr", cUtil.DiscountAmt(sid.Price2, sid.Discount));
                     else
                        e.Value = string.Format("{0}/roll", cUtil.DiscountAmt(sid.Price1, sid.Discount));
                  }
                  else
                     e.Value = cUtil.DiscountAmt(sid.Price1, sid.Discount);
               }
               else
               {
                  e.Value = cUtil.DiscountAmt(sid.Price1, sid.Discount);
               }
            }
            else if (e.Column.FieldName == "_QTY")
            {
               //qty to return, for wires, always assume whole roll
               if (sid.item != null)
               {
                  if (sid.item.IsWire)
                     e.Value = string.Format("{0} rolls", sid.QTY_To_Return);
                  else
                     e.Value = string.Format("{0} pcs", sid.QTY_To_Return);
               }
               else
                  e.Value = string.Format("{0} pcs", sid.QTY_To_Return);
            }
         }
      }

      private void btnRemoveBO_Click(object sender, EventArgs e)
      {
         StockInDetails sid = (StockInDetails) grdvBO.GetRow(grdvBO.FocusedRowHandle);
         if (sid != null)
         {
            mBODetails.Remove(sid);
            grdBO.RefreshDataSource();
            UpdateTotal();
         }
      }

      private void btnPaymentAdd_Click(object sender, EventArgs e)
      {
         ctlPaymentPDC ctl = new ctlPaymentPDC();
         frmGenericPopup frm = new frmGenericPopup();

         ctl.Amount = cUtil.ParseDouble(lblTotal.Text);
         frm.Text = "New PDC Payment";
         frm.ShowCtl(ctl);
         if (!ctl.Canceled)
         {
            mLstPDC.Add(ctl.paymentcheck);
            grdPayments.RefreshDataSource();
         }
      }

      private void btnPaymentRemove_Click(object sender, EventArgs e)
      {
         PaymentsPDC pdc = (PaymentsPDC) grdvPayments.GetRow(grdvPayments.FocusedRowHandle);
         if (pdc != null)
         {
            mLstPDC.Remove(pdc);
            grdPayments.RefreshDataSource();
         }
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         if (cboSupplier.SelectedIndex == -1)
         {
            cUtil.ShowMessageExclamation("Please select supplier first!", "New Voucher");
            cboSupplier.Focus();
         }

         if (mLstStockIn.Count == 0)
         {
            cUtil.ShowMessageExclamation("Please add at least 1 unpaid Stock In to pay!", "New Voucher");
            return;
         }

         if (mLstPDC.Count == 0)
         {
            cUtil.ShowMessageExclamation("Please add payment details!", "New Voucher");
            return;
         }

         //everything ok
         Voucher voucher = new Voucher();
         voucher.Supplier = (Contacts) cboSupplier.SelectedItem;
         voucher.Amount = cUtil.ParseDouble(lblTotal.Text);
         voucher.VoucherDate = DateTime.Now;

         //save details
         voucher.details = new List<VoucherDetails>();
         foreach (StockIn si in mLstStockIn)
         {
            VoucherDetails vd = new VoucherDetails();
            vd.stockin = si;
            voucher.details.Add(vd);
         }

         //payments
         voucher.payments = new List<VoucherPayment>();
         foreach (PaymentsPDC pdc in mLstPDC)
         {
            VoucherPayment vp = new VoucherPayment();
            vp.AccountNumber = pdc.AccountNumber;
            vp.Amount = pdc.Amount;
            vp.bank = pdc.bank;
            vp.CheckDate = pdc.CheckDate;
            vp.CheckNumber = pdc.CheckNumber;
            vp.ClearingDate = PaymentsPDC.GetClearingDate(pdc.CheckDate);
            vp.Status = VoucherPayment.eStatus.ForDeposit;
            voucher.payments.Add(vp);
         }

         //BO
         try
         {
            mVoucherDao.Save(voucher, mBODetails);
            cUtil.ShowMessageInformation("Voucher saved successfully!", "New Voucher");
            btnClose.PerformClick();
         }
         catch
         {
            cUtil.ShowMessageError(mVoucherDao.ErrorMessage, "Save Voucher");
         }
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         if (m_Voucher != null)
         {
            //from View Vouchers
            cUtil.getMainForm().CloseCurrentControl();
         }
         else
         {
            ctlViewVouchers ctl = new ctlViewVouchers();
            cUtil.getMainForm().LoadCtl(ctl, true, "Manage Vouchers", "Add/Cancel Vouchers", true, DockStyle.Left);
         }
      }
   }
}