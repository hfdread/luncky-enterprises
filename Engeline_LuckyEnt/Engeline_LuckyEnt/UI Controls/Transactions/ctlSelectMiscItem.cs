#region

using System;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
   public partial class ctlSelectMiscItem : UserControl
   {
      private FabricatedItemDao FabItemDao = new FabricatedItemDao();
      private TradingItemDao TradeItemDao = new TradingItemDao();
      private PurchaseOrderDao PurchaseOrderDao = new PurchaseOrderDao();

      public ctlPurchaseOrder PO_Ctl { get; set; }
      public bool Canceled { get; set; }

      public ctlSelectMiscItem()
      {
         InitializeComponent();
         Canceled = false;
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         this.ParentForm.Close();
      }

      private void btnAddItem_Click(object sender, EventArgs e)
      {
         Int32 QTY = 0;
         double Price = 0;

         //validation
         if (txtItemName.Text == "")
         {
            clsUtil.ShowMessage("Invalid Item Name!", "Add Misc Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            txtItemName.Focus();
            return;
         }

         //description, allow null

         QTY = (Int32) clsUtil.CheckValue(txtQTY);
         if (QTY == 0)
         {
            clsUtil.ShowMessage("Invalid Item Quantity!", "Add Misc Item", MessageBoxButtons.OK,
                              MessageBoxIcon.Exclamation);
            txtQTY.SelectAll();
            txtQTY.Focus();
            return;
         }

         Price = (Int32) clsUtil.CheckValue(txtUnitPrice);
         if (Price == 0)
         {
            clsUtil.ShowMessage("Invalid Item Price!", "Add Misc Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            txtUnitPrice.SelectAll();
            txtUnitPrice.Focus();
            return;
         }

         txtTotalAmount.Text = (QTY*Price).ToString("#,##0.00");

         PurchaseOrderDetails POD = new PurchaseOrderDetails();
         if (radioGrp1.SelectedIndex == 0)
         {
            //trading item
            POD.tradingitem = new TradingItem();
            POD.tradingitem.Name = txtItemName.Text;
            POD.tradingitem.Description = txtDescription.Text;
            POD.tradingitem.QTY = QTY;
            POD.tradingitem.UnitPrice = Price;
         }
         else
         {
            //fabricated item
            POD.fabricateditem = new FabricatedItem();
            POD.fabricateditem.Name = txtItemName.Text;
            POD.fabricateditem.Description = txtDescription.Text;
            POD.fabricateditem.QTY = QTY;
            POD.fabricateditem.UnitPrice = Price;
         }

         POD.QTY1 = QTY;
         POD.QTY2 = 0;
         POD.SellingPrice1 = Price;
         POD.SellingPrice2 = 0;
         PO_Ctl.AddItem(POD);
      }

      private void txtQTY_EditValueChanged(object sender, EventArgs e)
      {
         double Price = 0;
         Int32 QTY = 0;

         Price = clsUtil.ParseDouble(txtUnitPrice.Text);
         QTY = clsUtil.ParseInt32(txtQTY.Text);

         txtTotalAmount.Text = (Price*QTY).ToString("#,##0.00");
      }

      private void txtInput_Enter(object sender, EventArgs e)
      {
         ((DevExpress.XtraEditors.TextEdit) sender).SelectAll();
      }

      private void txtDescription_Enter(object sender, EventArgs e)
      {
         ((DevExpress.XtraEditors.MemoEdit) sender).SelectAll();
      }
   }
}