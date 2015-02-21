#region

using System;
using System.Windows.Forms;
using DexterHardware_v2.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace DexterHardware_v2.UI_Controls.Transactions
{
   public partial class ctlInputStockIn : UserControl
   {
      private StockInDao siDao = null;

      public bool Cancelled { get; set; }
      public Contacts Supplier { get; set; }
      public int StockInID { get; set; }

      public ctlInputStockIn()
      {
         InitializeComponent();
         Cancelled = false;

         siDao = new StockInDao();
      }

      private void btnSearch_Click(object sender, EventArgs e)
      {
         if (txtxSearchString.Text.Trim() == "")
         {
            cUtil.ShowMessageExclamation("Please enter search string!", "Search Stock In");
            txtxSearchString.Focus();
            return;
         }

         grdResult.DataSource = siDao.SearchStockInByItem(cUtil.GenerateFilterCondition(txtxSearchString.Text),
                                                          Supplier.ID);
         grdvResult_SelectionChanged(null, null);
      }

      private void ctlInputStockIn_Load(object sender, EventArgs e)
      {
      }

      private void grdvResult_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
      {
         StockIn si = (StockIn) grdvResult.GetRow(grdvResult.FocusedRowHandle);
         if (si != null)
         {
            txtPONumber.Text = si.ID.ToString(cUtil.FMT_ID);
         }
         else
         {
            txtPONumber.Text = "";
         }
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         Cancelled = true;
         this.ParentForm.Close();
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         StockInID = cUtil.ParseInt32(txtPONumber.Text);
         if (StockInID == 0)
         {
            cUtil.ShowMessageExclamation("Invalid StockIn number!", "Bad Order");
         }
         else
         {
            Cancelled = false;
            this.ParentForm.Close();
         }
      }
   }
}