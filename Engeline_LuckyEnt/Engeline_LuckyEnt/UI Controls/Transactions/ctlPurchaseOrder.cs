#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.Forms;
using Engeline_LuckyEnt.UI_Controls.Viewers;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
   public partial class ctlPurchaseOrder : UserControl
   {
      private PurchaseOrderDao PurchaseOrderDao = new PurchaseOrderDao();
      private PurchaseOrderDetailsDao PurchaseOrderDetailsDao = new PurchaseOrderDetailsDao();
      private ContactsDao CustomerDao = new ContactsDao();
      private PurchaseOrderDiscountsDao DiscountsDao = new PurchaseOrderDiscountsDao();
      private WarehouseDao WHDao = new WarehouseDao();

      public object PreviousCtl { get; set; }
      public PurchaseOrder purchaseorder { get; set; }
      public bool ViewMode { get; set; }


      public ctlPurchaseOrder()
      {
         InitializeComponent();
         ViewMode = false;
      }

      private void ctlPurchaseOrder_Load(object sender, EventArgs e)
      {
         if (purchaseorder != null)
         {
            LoadPO();
         }
         else
         {
            cboStatus.SelectedIndex = (int) PurchaseOrder.eStatus.PENDING;
            LoadCustomers();
         }
         cboCustomer.Focus();
      }

      private void LoadCustomers()
      {
        // if (clsUtil.GetUserPermissions().PO_AddSuppliersManila == 1)
            cboCustomer.DataSource = CustomerDao.getAllSuppliers(false);
        // else
        // cboCustomer.DataSource = CustomerDao.getAllSuppliers(true);
         cboCustomer.SelectedIndex = -1;
      }

      private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
      {
         Contacts C = (Contacts) cboCustomer.SelectedValue;
         if (C != null)
         {
            txtGracePeriod.Text = C.Terms.ToString();
            txtAddress.Text = C.Address;
         }
         else
         {
            txtGracePeriod.Text = "";
            txtAddress.Text = "";
         }
      }

      private void btnAddItem_Click(object sender, EventArgs e)
      {
         ctlSelectItems_PO ctl = new ctlSelectItems_PO();
         frmGenericPopup frm = new frmGenericPopup();

         if (purchaseorder == null)
         {
            purchaseorder = new PurchaseOrder();
            purchaseorder.details = new List<PurchaseOrderDetails>();
            grdItems.DataSource = purchaseorder.details;
         }

         ctl.PO_ctl = this;
         frm.Text = "Select Item";
         frm.ShowCtl(ctl);
      }

      private void grdvItems_CustomUnboundColumnData(object sender,
                                                     DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
      {
         PurchaseOrderDetails POD = (PurchaseOrderDetails) grdvItems.GetRow(e.RowHandle);
         if (e.IsGetData && e.Column.FieldName == "ItemName")
         {
            if (POD.item != null)
            {
               e.Value = string.Format("{0}\n{1}", POD.item.Name, POD.item.Description);
            }
            else if (POD.fabricateditem != null)
            {
               e.Value = string.Format("{0}\n{1}", POD.fabricateditem.Name, POD.fabricateditem.Description);
            }
            else if (POD.tradingitem != null)
            {
               e.Value = string.Format("{0}\n{1}", POD.tradingitem.Name, POD.tradingitem.Description);
            }
         }
         else if (e.IsGetData && e.Column.FieldName == "UnitPrice")
         {
            if (POD.item != null)
            {
               if (POD.item.IsWire)
               {
                  if (POD.item.Price2 == 0)
                  {
                     e.Value = string.Format("{0} /meter", POD.SellingPrice1.ToString("#,##0.00"));
                  }
                  else
                  {
                     e.Value = string.Format("{0} /meter", POD.SellingPrice2.ToString("#,##0.00"));
                  }
               }
               else
               {
                  e.Value = POD.item.Price1;
               }
            }
            else
            {
               //fab item / trade item
               e.Value = string.Format("{0}", POD.SellingPrice1.ToString("#,##0.00"));
            }
         }
         else if (e.IsGetData && e.Column.FieldName == "DiscountedPrice")
         {
            if (POD.item != null)
            {
               if (POD.item.IsWire)
               {
                  if (POD.SellingPrice2 == 0)
                  {
                     e.Value = clsUtil.DiscountAmt(POD.SellingPrice1, POD.Discount);
                  }
                  else
                  {
                     e.Value = clsUtil.DiscountAmt(POD.SellingPrice2, POD.Discount);
                  }
               }
               else
               {
                  e.Value = clsUtil.DiscountAmt(POD.SellingPrice1, POD.Discount);
               }
            }
            else
            {
               // fab or trading item
               e.Value = clsUtil.DiscountAmt(POD.SellingPrice1, POD.Discount);
            }
         }
         else if (e.IsGetData && e.Column.FieldName == "SubTotal")
         {
            if (POD.item != null)
            {
               if (POD.item.IsWire)
               {
                  if (POD.SellingPrice2 == 0)
                  {
                     e.Value = clsUtil.DiscountAmt(POD.SellingPrice1, POD.Discount)*POD.QTY1;
                  }
                  else
                  {
                     e.Value = clsUtil.DiscountAmt(POD.SellingPrice2, POD.Discount)*POD.QTY1*POD.QTY2;
                  }
               }
               else
               {
                  e.Value = clsUtil.DiscountAmt(POD.SellingPrice1, POD.Discount)*POD.QTY1;
               }
            }
            else
            {
               e.Value = clsUtil.DiscountAmt(POD.SellingPrice1, POD.Discount)*POD.QTY1;
            }
         }
      }

      public void AddItem(PurchaseOrderDetails POD)
      {
         purchaseorder.details.Add(POD);
         grdvItems.RefreshData();
         grdvItems.FocusedRowHandle = grdvItems.DataRowCount - 1;
         ComputeTotal();

         //disable mixing other types of items
         if (POD.item != null)
            btnAddMiscItem.Enabled = false;
         else
            btnAddItem.Enabled = false;
      }

      private void grdvItems_RowCellDefaultAlignment(object sender,
                                                     DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventArgs e)
      {
         if (e.Column.FieldName == "UnitPrice" || e.Column.FieldName == "Discount" ||
             e.Column.FieldName == "DiscountedPrice")
         {
            e.HorzAlignment = DevExpress.Utils.HorzAlignment.Far;
         }
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         if (cboCustomer.SelectedIndex == -1)
         {
            clsUtil.ShowMessage("Please select supplier first!", "Save Purchase Order", MessageBoxButtons.OK,
                              MessageBoxIcon.Exclamation);
            cboCustomer.Focus();
            return;
         }

         if (purchaseorder == null)
         {
            clsUtil.ShowMessage("No items to save!", "Save Purchase Order", MessageBoxButtons.OK,
                              MessageBoxIcon.Exclamation);
            return;
         }

         if (purchaseorder.details.Count == 0)
         {
            clsUtil.ShowMessage("No items to save!", "Save Purchase Order", MessageBoxButtons.OK,
                              MessageBoxIcon.Exclamation);
            return;
         }

         try
         {
            purchaseorder.Supplier = (Contacts) cboCustomer.SelectedValue;
            purchaseorder.TransactionDate = dtDate.Value;
            purchaseorder.GracePeriod = Convert.ToInt32(txtGracePeriod.Text);
            purchaseorder.Notes = txtNotes.Text;
            purchaseorder.AmountDue = Convert.ToDouble(lblTotal.Text);
            purchaseorder.Status = purchaseorder.GetStatus(cboStatus.Text);
            purchaseorder.user = clsUtil.GetLoggedInUser();
            purchaseorder.wh_id = WHDao.GetWarehouseCode();

            PurchaseOrderDao.Save(purchaseorder);
            clsUtil.ShowMessage(string.Format("Purchase Order [{0}] saved!", purchaseorder.ID), "Save Purchase Order",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

            //save discounts
            foreach (PurchaseOrderDetails POD in purchaseorder.details)
            {
               if (POD.Discount != "")
               {
                  //save discounts for normal items only
                  if (POD.item != null)
                  {
                     if (!DiscountsDao.DiscountExists(purchaseorder.Supplier.ID, POD.item.ID, POD.Discount))
                     {
                        PurchaseOrderDiscounts discount = new PurchaseOrderDiscounts();
                        discount.Supplier = purchaseorder.Supplier;
                        discount.item = POD.item;
                        discount.Discount = POD.Discount;
                        DiscountsDao.Save(discount);
                     }
                  }
               }
            }

            ctlViewPurchaseOrders ctl = new ctlViewPurchaseOrders();
            clsUtil.getMainForm().LoadCtl(ctl, true, "View Purchase Orders", "", false);
         }
         catch (Exception ex)
         {
            clsUtil.ShowMessage(string.Format("An error occurred while saving Purchase Order!\n[{0}]", ex.Message),
                              "Save Purchase Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private Double ComputeTotal()
      {
         double Total = 0;
         foreach (PurchaseOrderDetails POD in purchaseorder.details)
         {
            if (POD.item != null && POD.item.IsWire)
            {
               if (POD.SellingPrice2 == 0)
               {
                  Total += clsUtil.DiscountAmt(POD.SellingPrice1, POD.Discount)*POD.QTY1;
               }
               else
               {
                  Total += clsUtil.DiscountAmt(POD.SellingPrice2, POD.Discount)*POD.QTY1*POD.QTY2;
               }
            }
            else
            {
               Total += clsUtil.DiscountAmt(POD.SellingPrice1, POD.Discount)*POD.QTY1;
            }
         }
         lblTotal.Text = Total.ToString("#,##0.00");
         return Total;
      }

      private void btnAddMiscItem_Click(object sender, EventArgs e)
      {
         ctlSelectMiscItem ctl = new ctlSelectMiscItem();
         frmGenericPopup frm = new frmGenericPopup();

         if (purchaseorder == null)
         {
            purchaseorder = new PurchaseOrder();
            purchaseorder.details = new List<PurchaseOrderDetails>();
            grdItems.DataSource = purchaseorder.details;
         }

         ctl.PO_Ctl = this;
         frm.Text = "Select MISC Item";
         frm.ShowCtl(ctl);
      }

      public void LoadPO()
      {
         if (purchaseorder != null)
         {
            lblPONumber.Text = purchaseorder.ID.ToString("000000");
            cboCustomer.Items.Clear();
            Warehouse W = WHDao.GetWHById(purchaseorder.WarehouseID);
            try
            {
                cboCustomer.Items.Add(W);
                cboCustomer.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                cboCustomer.SelectedIndex = -1;
            }
            //cboCustomer.Items.Add(purchaseorder.Supplier);
            //cboCustomer.Text = purchaseorder.Supplier.ToString();
            txtGracePeriod.Text = purchaseorder.GracePeriod.ToString();
            txtAddress.Text = W.Address;
            dtDate.Value = purchaseorder.TransactionDate;
            cboStatus.SelectedIndex = purchaseorder.Status;
            txtNotes.Text = purchaseorder.Notes;

            grdItems.DataSource = purchaseorder.details;
            grdvItems.OptionsBehavior.Editable = false;
            ComputeTotal();

            btnAddItem.Enabled = false;
            btnAddMiscItem.Enabled = false;
            btnRemoveItem.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Text = "&Close";
         }
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         clsUtil.getMainForm().CloseCurrentControl();
      }

      private void btnRemoveItem_Click(object sender, EventArgs e)
      {
         PurchaseOrderDetails pod = (PurchaseOrderDetails) grdvItems.GetRow(grdvItems.FocusedRowHandle);
         if (pod != null)
         {
            string ItemName = "";
            if (pod.item != null)
            {
               ItemName = pod.item.Name;
            }
            else if (pod.fabricateditem != null)
            {
               ItemName = pod.fabricateditem.Name;
            }
            else if (pod.tradingitem != null)
            {
               ItemName = pod.tradingitem.Name;
            }

            if (clsUtil.ShowMessageYesNo(string.Format("Remove item '{0}'?", ItemName), "Remove Item") == DialogResult.No)
               return;

            purchaseorder.details.Remove(pod);
            grdvItems.RefreshData();
            ComputeTotal();

            if (purchaseorder.details.Count == 0)
            {
               //re-enable both Add buttons
               btnAddItem.Enabled = true;
               btnAddMiscItem.Enabled = true;
            }
         }
      }
   }
}