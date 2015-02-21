#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DexterHardware_v2.Classes;
using DexterHardware_v2.Forms;
using DexterHardware_v2.UI_Controls.Viewers;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace DexterHardware_v2.UI_Controls.Transactions
{
   public partial class ctlBundledItem : UserControl
   {
      private ItemDao ItemDao = new ItemDao();
      private BundledItemDao BundledItemDao = new BundledItemDao();

      public ctlViewBundledItems ParentCtl { get; set; }
      public virtual BundledItem bundleditem { get; set; }
      public virtual bool Canceled { get; set; }
      public virtual bool AllowModify { get; set; }

      public ctlBundledItem()
      {
         InitializeComponent();
      }

      private void ctlBundledItem_Load(object sender, EventArgs e)
      {
         if (bundleditem != null)
         {
            LoadBundledItem();
            txtName.Enabled = AllowModify;
            txtDescription.Enabled = AllowModify;
            txtPriceOverride.Enabled = AllowModify;
            btnAddItem.Enabled = AllowModify;
            btnRemove.Enabled = AllowModify;
            btnClearAll.Enabled = AllowModify;
            btnSave.Enabled = AllowModify;
            grdvItems.OptionsBehavior.Editable = AllowModify;
            grdvItems.OptionsSelection.EnableAppearanceFocusedCell = AllowModify;
         }
         else
         {
            txtName.Focus();
         }
      }

      private void LoadBundledItem()
      {
         txtName.Text = bundleditem.Name;
         txtDescription.Text = bundleditem.Description;

         //details
         tblItems.Rows.Clear();
         foreach (BundledItemDetails bid in bundleditem.details)
         {
            if (bid.item != null)
            {
               tblItems.Rows.Add(bid.item.ID, bid.item.Name, bid.QTY, bid.UnitPrice, bid.QTY*bid.UnitPrice, false);
            }
            else
            {
               tblItems.Rows.Add(bid.FabItem.ID, bid.FabItem.Name, bid.QTY, bid.UnitPrice, bid.QTY*bid.UnitPrice, false);
            }
         }
         ComputeTotal();
         txtPriceOverride.Text = bundleditem.UnitPrice.ToString("#,##0.00");
      }

      public void AddItem(Items item)
      {
         tblItems.Rows.Add(item.ID, string.Format("{0}\n{1}", item.Name, item.Description), 1, item.Price1, item.Price1,
                           false, item.Description);
         ComputeTotal();
      }

      public void AddFabItem(FabricatedItem FI)
      {
         tblItems.Rows.Add(FI.ID, string.Format("{0}\n{1}", FI.Name, FI.Description), 1, FI.UnitPrice, FI.UnitPrice,
                           true, FI.Description);
         ComputeTotal();
      }

      private void btnAddItem_Click(object sender, EventArgs e)
      {
         ctlSelectItems_Bundle ctl = new ctlSelectItems_Bundle();
         frmGenericPopup frm = new frmGenericPopup();

         ctl.ParentCtl = this;
         frm.Text = "Select Item for Bundle";
         frm.ShowCtl(ctl);
         grdvItems.Focus();
      }

      private void grdvItems_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
      {
         DataRow row = grdvItems.GetDataRow(e.RowHandle);

         if (Convert.ToInt32(row["QTY"].ToString()) < 0)
         {
            cUtil.ShowMessageError("Invalid QTY!", "Update Item Details");
            e.Valid = false;
         }

         if (Convert.ToDouble(row["UnitPrice"].ToString()) < 0)
         {
            cUtil.ShowMessageError("Invalid UnitPrice!", "Update Item Details");
            e.Valid = false;
         }

         if (e.Valid)
         {
            //update subtotal
            row["SubTotal"] = Convert.ToDouble(row["QTY"].ToString())*Convert.ToDouble(row["UnitPrice"].ToString());
            ComputeTotal();
         }
      }

      private void btnClearAll_Click(object sender, EventArgs e)
      {
         tblItems.Rows.Clear();
      }

      private void btnRemove_Click(object sender, EventArgs e)
      {
         if (grdvItems.FocusedRowHandle >= 0)
         {
            grdvItems.DeleteRow(grdvItems.FocusedRowHandle);
            ComputeTotal();
         }
      }

      public double ComputeTotal()
      {
         double Total = 0;
         foreach (DataRow row in tblItems.Rows)
         {
            Total += Convert.ToDouble(row["SubTotal"].ToString());
         }
         lblTotal.Text = Total.ToString("#,##0.00");
         txtPriceOverride.Text = lblTotal.Text;
         return Total;
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         bool bModifyItem = false;

         //validate
         if (tblItems.Rows.Count == 0)
         {
            cUtil.ShowMessageError("No items to save!", "Save Bundled Item");
            return;
         }

         if (txtName.Text == "")
         {
            cUtil.ShowMessageError("Invalid name!", "Save Bundled Item");
            txtName.SelectAll();
            txtName.Focus();
            return;
         }

         if (txtDescription.Text == "")
         {
            cUtil.ShowMessageError("Invalid description!", "Save Bundled Item");
            txtDescription.SelectAll();
            txtDescription.Focus();
            return;
         }

         if (bundleditem == null)
         {
            //check if duplicate name is used
            BundledItem bi = BundledItemDao.GetByName("Name", txtName.Text);
            if (bi != null)
            {
               cUtil.ShowMessageError("Bundled name is alredy used!", "Save Bundled Item");
               txtName.SelectAll();
               txtName.Focus();
               return;
            }
            bundleditem = new BundledItem();
         }
         else
         {
            if (!BundledItemDao.AllowModify(bundleditem.ID))
            {
               cUtil.ShowMessageError("Bundled Item cannot be modified!", "Save Bundled Item");
               return;
            }
            bModifyItem = true;
         }

         double PriceTotal, PriceOverride;
         PriceTotal = Convert.ToDouble(lblTotal.Text);
         PriceOverride = cUtil.CheckValue(txtPriceOverride);

         if (PriceTotal > 0 && PriceOverride == 0)
         {
            cUtil.ShowMessageError("Invalid price override!", "Save Bundled Item");
            txtPriceOverride.SelectAll();
            txtPriceOverride.Focus();
            return;
         }

         if (PriceOverride != PriceTotal)
         {
            if (
               cUtil.ShowMessageYesNo("Price override is not equal to computed total.\nDo you wish to continue?",
                                      "Save Bundled Item") == DialogResult.No)
            {
               return;
            }
         }

         //save bundled item
         bundleditem.Name = txtName.Text;
         bundleditem.Description = txtDescription.Text;
         bundleditem.ComputedPrice = PriceTotal;
         bundleditem.UnitPrice = PriceOverride;

         bundleditem.details = new List<BundledItemDetails>();
         foreach (DataRow row in tblItems.Rows)
         {
            BundledItemDetails bid = new BundledItemDetails();
            if (Convert.ToBoolean(row["FabItem"].ToString()))
            {
               bid.FabItem = new FabricatedItem();
               bid.FabItem.ID = Convert.ToInt32(row["ItemID"].ToString());
               bid.FabItem.Name = row["ItemName"].ToString();
               bid.FabItem.Description = row["Description"].ToString();
            }
            else
            {
               bid.item = new Items();
               bid.item.ID = Convert.ToInt32(row["ItemID"].ToString());
               bid.item.Name = row["ItemName"].ToString();
               bid.item.Description = row["Description"].ToString();
            }
            bid.QTY = Convert.ToInt32(row["QTY"].ToString());
            bid.UnitPrice = Convert.ToDouble(row["UnitPrice"].ToString());
            bundleditem.details.Add(bid);
         }

         try
         {
            BundledItemDao.Save(bundleditem);

            Canceled = false;
            if (ParentCtl != null)
            {
               if (bModifyItem)
               {
                  ParentCtl.UpdateModifiedNode(bundleditem);
               }
               else
               {
                  //new item
                  ParentCtl.AddNewItem(bundleditem, true);
               }
               //clsUtil.getMainForm().LoadLastCtl();
               cUtil.getMainForm().LoadCtl(ParentCtl, true, "Bundled Items", "Manage Bundled Items", false);
            }
            else
            {
               ctlViewBundledItems ctl = new ctlViewBundledItems();
               cUtil.getMainForm().LoadCtl(ctl, true, "Bundled Items", "Manage Bundled Items", false);
            }
         }
         catch (Exception ex)
         {
            cUtil.ShowMessageError("Error:\n" + ex.Message, "Save Bundled Item");
         }
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         Canceled = true;
         if (ParentCtl != null)
         {
            cUtil.getMainForm().CloseCurrentControl();
         }
         else
         {
            ctlViewBundledItems ctl = new ctlViewBundledItems();
            cUtil.getMainForm().LoadCtl(ctl, true, "Bundled Items", "Manage Bundled Items", false);
         }
      }
   }
}