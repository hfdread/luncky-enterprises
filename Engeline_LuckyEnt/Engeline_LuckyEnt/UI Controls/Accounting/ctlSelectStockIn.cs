#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DexterHardware_v2.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace DexterHardware_v2.UI_Controls.Accounting
{
   public partial class ctlSelectStockIn : UserControl
   {
      private StockInDao siDao = new StockInDao();
      private ContactsDao supplierDao = new ContactsDao();

      public bool Canceled { get; set; }
      public Contacts Supplier { get; set; }
      public IList<StockIn> m_LstSI = null;

      public ctlSelectStockIn()
      {
         InitializeComponent();

         Canceled = false;
         m_LstSI = new List<StockIn>();
      }

      private void ctlSelectStockIn_Load(object sender, EventArgs e)
      {
         dtRange.SetDateSelection(ctlDateRange.eDateSelection.ThisMonth);
         btnRefresh.PerformClick();
      }

      private void btnRefresh_Click(object sender, EventArgs e)
      {
         if (Supplier == null)
         {
            cUtil.ShowMessageExclamation("Supplier not set!", "Select Unpaid Stock In");
            return;
         }

         m_LstSI = siDao.GetUnpaidStockIn(dtRange.getDateFrom(), dtRange.getDateTo(), Supplier.ID);
         grdSI.DataSource = m_LstSI;
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         Canceled = true;
         this.ParentForm.Close();
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         Canceled = false;
         this.ParentForm.Close();
      }

      private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
      {
         if (m_LstSI.Count > 0)
         {
            foreach (StockIn si in m_LstSI)
            {
               si.Selected = chkSelectAll.Checked;
            }
            grdSI.RefreshDataSource();
         }
      }
   }
}