#region

using System;
using System.Windows.Forms;
using DexterHardware_v2.Classes;
using MyHibernate.DataAccessLayer;

#endregion

namespace DexterHardware_v2.UI_Controls.Utilities
{
   public partial class ctlSelectItem : UserControl
   {
      private ItemDao ItemDao = new ItemDao();

      public ctlSelectItem()
      {
         InitializeComponent();
      }

      private void btnSearch_Click(object sender, EventArgs e)
      {
         if (txtSearch.Text != "")
         {
            string sFilter = cUtil.GenerateFilterCondition(txtSearch.Text);
            grdvItems.ActiveFilterString = string.Format("[Name] LIKE '{0}' OR [Description] LIKE '{0}'", sFilter);
         }
      }

      private void ctlSelectItem_Load(object sender, EventArgs e)
      {
         grdvItems.Columns["Name"].FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
         grdvItems.Columns["Description"].FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
         grdItems.DataSource = ItemDao.getAllRecords();
         txtSearch.Focus();
      }
   }
}