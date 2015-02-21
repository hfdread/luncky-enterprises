#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls
{
   public partial class ctlItems : UserControl
   {
      private ItemDao mItemDao = new ItemDao();
      private ItemCategoryDao mItemCategoryDao = new ItemCategoryDao();
      private WarehouseDao mWHDao = new WarehouseDao();

      private enum eFld
      {
         ItemID = 0,
         ItemName,
         Description,
         Code,
         Price1,
         Price2,
         MetersPerRoll,
         Unit,
         LowThreshold,
         Dirty,
         IsWire
      }

      public ctlItems()
      {
         InitializeComponent();
      }

      private void ctlItems_Load(object sender, EventArgs e)
      {
         //get list of all items
          IList<Items> lst = mItemDao.getAllItems();
         grdItems.BeginUpdate();
         foreach (Items item in lst)
         {
            tblItems.Rows.Add(item.ID, item.Name, item.Description, item.Code, item.Price1, item.Price2, item.QTY2,
                              item.Unit, item.LowThreshold, false, item.IsWire);
         }

         grdvItems.OptionsBehavior.Editable = false;
         grdvItems.OptionsSelection.EnableAppearanceFocusedCell = false;
         grdvItems.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

         grdItems.EndUpdate();

          //temporary
         //if (clsUtil.GetUserPermissions().Item_Add == 0)
         //   btnEdit.Visible = false;

         if (tblItems.Rows.Count > 0)
            btnImportCSV.Visible = false;
      }

      private void grdvItems_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
      {
         DataRow row = grdvItems.GetDataRow(e.RowHandle);
         row[(int) eFld.ItemID] = 0;
         row[(int) eFld.Dirty] = true;
         row[(int) eFld.Price1] = 0;
         row[(int) eFld.Price2] = 0;
         row[(int) eFld.MetersPerRoll] = 0;
         row[(int) eFld.LowThreshold] = 0;
         row[(int) eFld.IsWire] = false;
      }

      private void grdvItems_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
      {
         DataRow row = grdvItems.GetDataRow(e.RowHandle);
         //row[(int)eFld.ItemID] = 0;
         row[(int) eFld.Dirty] = true;
      }

      private void grdvItems_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
      {
         DataRow row = grdvItems.GetDataRow(e.RowHandle);

         //validate item
         if (row[(int) eFld.ItemName].ToString() == "")
         {
            e.ErrorText = "Invalid item name!";
            e.Valid = false;
            return;
         }

         if (row[(int) eFld.Description].ToString() == "")
         {
            e.ErrorText = "Invalid item description!";
            e.Valid = false;
            return;
         }

         if (Convert.ToInt32(row[(int) eFld.ItemID].ToString()) != 0)
         {
            //check for duplicate item
            Items item = mItemDao.GetByName("Name", row[(int) eFld.ItemName].ToString());
            if (item != null)
            {
               if (item.ID != Convert.ToInt32(row[(int) eFld.ItemID].ToString()))
               {
                  //duplicate item name
                  e.ErrorText = "Duplicate Item Name";
                  e.Valid = false;
                  return;
               }
            }
         }

         if (row[(int) eFld.Price1].ToString() == "")
         {
            e.ErrorText = "Invalid item Price!";
            e.Valid = false;
            return;
         }
         else
         {
            try
            {
               Convert.ToDouble(row[(int) eFld.Price1]);
            }
            catch
            {
               e.ErrorText = "Invalid Item Price";
               e.Valid = false;
               return;
            }
         }

        /*if (row[(int) eFld.MetersPerRoll] != "")
         {
            try
            {
               Convert.ToInt32(row[(int) eFld.MetersPerRoll]);
            }
            catch
            {
               e.ErrorText = "Invalid Meters per Roll value!";
               e.Valid = false;
               return;
            }
         }*/

         if (row[(int) eFld.LowThreshold].ToString() != "")
         {
            try
            {
               Convert.ToInt32(row[(int) eFld.LowThreshold]);
            }
            catch
            {
               e.ErrorText = "Invalid Low Threshold value!";
               e.Valid = false;
               return;
            }
         }
         //everything ok ;)
         btnSave.Enabled = true;
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         Items item = null;
         Int32 ctrSaved, ctrError;

         ItemCategory category = mItemCategoryDao.GetByName("Name", "Others");
         if (category == null)
         {
            //create category
            category = new ItemCategory();
            category.Name = "Others";
            category.Description = "Others";
            try
            {
               mItemCategoryDao.Save(category);
            }
            catch
            {
               MessageBox.Show("Updates not saved! An error occurred while saving default category.", "Save Items",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
               return;
            }
         }

         //save all new / updated rows
         ctrSaved = ctrError = 0;
         foreach (DataRow row in tblItems.Rows)
         {
            if (Convert.ToBoolean(row[(int) eFld.Dirty]) == true)
            {
               if (Convert.ToInt32(row[(int) eFld.ItemID].ToString()) == 0)
               {
                  //new item
                  item = new Items();
                  item.ItemDate = DateTime.Now;
                  item.category = new ItemCategory();
                  item.category.ID = category.ID;
               }
               else
               {
                  item = mItemDao.GetById(Convert.ToInt32(row[(Int32) eFld.ItemID].ToString()));
               }

               if (item != null)
               {
                  item.Name = row[(Int32) eFld.ItemName].ToString();
                  item.Description = row[(Int32) eFld.Description].ToString();
                  item.Price1 = Convert.ToDouble(row[(Int32) eFld.Price1].ToString());
                  item.Price2 = Convert.ToDouble(row[(Int32) eFld.Price2].ToString());
                  item.QTY2 = Convert.ToInt32(row[(Int32) eFld.MetersPerRoll].ToString());
                  item.LowThreshold = Convert.ToInt32(row[(Int32) eFld.LowThreshold].ToString());
                  item.IsWire = Convert.ToBoolean(row[(Int32) eFld.IsWire]);
                  //item.wh_id = mWHDao.GetWarehouseCode();
                  item.Code = row[(Int32)eFld.Code].ToString();
                  item.Unit = row[(Int32)eFld.Unit].ToString();
                  //item.Name = row[(Int32)eFld.ItemName].ToString();

                  try
                  {
                     mItemDao.Save(item);
                     ctrSaved++;
                     row[(int) eFld.Dirty] = false;
                     row[(Int32)eFld.ItemID] = item.ID;
                  }
                  catch (Exception ex)
                  {
                     ctrError++;
                  }
               }
            }
         }

         if (ctrSaved > 0)
         {
            MessageBox.Show(string.Format("Successfully Updated {0} items.", ctrSaved), "Save Items",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
         }

         //if (ctrError == 0)
         //btnSave.Enabled = false;
      }

      private void btnImportCSV_Click(object sender, EventArgs e)
      {
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         clsUtil.getMainForm().CloseCurrentControl();
      }

      private void btnFilter_Click(object sender, EventArgs e)
      {
         if (txtFilter.Text != "")
         {
            string sFilter = clsUtil.GenerateFilterCondition(txtFilter.Text);

            grdvItems.Columns["ItemName"].FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            grdvItems.Columns["Description"].FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;

            grdvItems.ActiveFilterString = string.Format("[ItemName] LIKE '{0}' OR [Description] LIKE '{0}'", sFilter);
         }
      }

      private void btnClearFilters_Click(object sender, EventArgs e)
      {
         grdvItems.ActiveFilterString = "";
         txtFilter.Text = "";
      }

      private void btnEdit_Click(object sender, EventArgs e)
      {
         if (!grdvItems.OptionsBehavior.Editable)
         {
            btnEdit.Text = "&Lock Table";
            grdvItems.OptionsBehavior.Editable = true;
            grdvItems.OptionsSelection.EnableAppearanceFocusedCell = true;
            grdvItems.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            grdvItems.Focus();

            btnDeleteItem.Enabled = true;
         }
         else
         {
            if (btnSave.Enabled)
            {
            }

            btnEdit.Text = "&Edit List";
            grdvItems.OptionsBehavior.Editable = false;
            grdvItems.OptionsSelection.EnableAppearanceFocusedCell = false;
            grdvItems.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            btnDeleteItem.Enabled = false;
         }
      }

      private void btnDeleteItem_Click(object sender, EventArgs e)
      {
          //temporary
         /*if (clsUtil.GetUserPermissions().Item_Delete == 0)
         {
            clsUtil.ShowMessagePermissionNotAllowed();
            return;
         }*/

         DataRow row = grdvItems.GetDataRow(grdvItems.FocusedRowHandle);
         if (row != null)
         {
            if(clsUtil.ShowMessageYesNo(string.Format("Are you sure you want to delete item '{0}'?",row[(int)eFld.ItemName].ToString()),"Delete Item") == DialogResult.No)
               return;

            Items item = mItemDao.GetById(Convert.ToInt32(row[(Int32) eFld.ItemID].ToString()));
            try
            {
               mItemDao.Delete(item);

               //remove item from list
               tblItems.Rows.RemoveAt(grdvItems.GetDataSourceRowIndex(grdvItems.FocusedRowHandle));
               grdItems.RefreshDataSource();
            }
            catch (Exception ex)
            {
               clsUtil.ShowMessageError(ex, "Delete Item");
            }
         }}
   }}