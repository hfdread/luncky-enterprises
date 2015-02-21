#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DexterHardware_v2.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace DexterHardware_v2.UI_Controls.Transactions
{
   public partial class ctlSelectItems_Bundle : UserControl
   {
      private ItemDao ItemDao = new ItemDao();
      private FabricatedItemDao FabitemDao = new FabricatedItemDao();

      public ctlBundledItem ParentCtl { get; set; }
      public bool Canceled { get; set; }

      private IList<Items> m_lstItems = null;
      private IList<FabricatedItem> m_lstFabItem = null;

      public ctlSelectItems_Bundle()
      {
         InitializeComponent();
      }

      private void ctlSelectItems_PO_Load(object sender, EventArgs e)
      {
         grdvItems.Columns["Name"].FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
         grdvItems.Columns["Description"].FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;

         m_lstItems = ItemDao.getAllRecords(true);
         m_lstFabItem = FabitemDao.getAllRecords();

         grdItems.DataSource = m_lstItems;
         txtSearch.Focus();
      }

      private void btnSearch_Click(object sender, EventArgs e)
      {
         if (txtSearch.Text != "")
         {
            grdItems.DataSource = null;

            string sFilter = cUtil.GenerateFilterCondition(txtSearch.Text);
            grdvItems.ActiveFilterString = string.Format("[Name] LIKE '{0}' OR [Description] LIKE '{0}'", sFilter);

            if (radioGroup1.SelectedIndex == 0)
               grdItems.DataSource = m_lstItems;
            else
               grdItems.DataSource = m_lstFabItem;

            grdvItems.Focus();
         }
      }

      private void grdvItems_CustomUnboundColumnData(object sender,
                                                     DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
      {
         double UnitPrice = 0;
         if (radioGroup1.SelectedIndex == 0)
         {
            Items I = (Items) grdvItems.GetRow(e.RowHandle);
            UnitPrice = I.Price1;
         }
         else
         {
            FabricatedItem FI = (FabricatedItem) grdvItems.GetRow(e.RowHandle);
            UnitPrice = FI.UnitPrice;
         }

         if (e.IsGetData && e.Column.FieldName == "UnitPrice")
         {
            e.Value = UnitPrice.ToString("#,##0.00");
         }
      }

      private void grdvItems_FocusedRowChanged(object sender,
                                               DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
      {
         //ShowItemDetail();
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         Canceled = true;
         this.ParentForm.Close();
      }

      private void btnAddItem_Click(object sender, EventArgs e)
      {
         if (radioGroup1.SelectedIndex == 0)
         {
            Items item = (Items) grdvItems.GetRow(grdvItems.FocusedRowHandle);
            if (item != null)
            {
               ParentCtl.AddItem(item);
               grdvItems.Focus();
            }
         }
         else
         {
            FabricatedItem FI = (FabricatedItem) grdvItems.GetRow(grdvItems.FocusedRowHandle);
            if (FI != null)
            {
               ParentCtl.AddFabItem(FI);
            }
         }
      }

      private void grdItems_Leave(object sender, EventArgs e)
      {
      }
   }
}