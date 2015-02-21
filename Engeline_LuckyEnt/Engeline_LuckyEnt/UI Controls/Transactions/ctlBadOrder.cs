#region

using System;
using System.Windows.Forms;
using DexterHardware_v2.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace DexterHardware_v2.UI_Controls.Transactions
{
   public partial class ctlBadOrder : UserControl
   {
      private StockInDao siDao = null;

      public bool Cancelled { get; set; }
      public StockIn m_StockIn { get; set; }

      public ctlBadOrder()
      {
         InitializeComponent();
         Cancelled = false;
         siDao = new StockInDao();
      }

      private void ctlBadOrder_Load(object sender, EventArgs e)
      {
         //Show StockIn Details
         lblStockInID.Text = m_StockIn.ID.ToString(cUtil.FMT_ID);
         lblPOID.Text = m_StockIn.purchaseorder.ID.ToString(cUtil.FMT_ID);
         lblSupplier.Text = m_StockIn.purchaseorder.Supplier.ToString();
         lblDateStockIn.Text = m_StockIn.StockInDate.ToString(cUtil.FMT_DATE1);
         lblDateShipping.Text = m_StockIn.ShippingDate.ToString(cUtil.FMT_DATE1);
         lblDateArrival.Text = m_StockIn.ArrivalDate.ToString(cUtil.FMT_DATE1);

         //show Stock In details
         grdItems.DataSource = m_StockIn.details;
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         Cancelled = true;
         ParentForm.Close();
      }

      private void grdvItems_CustomUnboundColumnData(object sender,
                                                     DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
      {
         StockInDetails sid = (StockInDetails) grdvItems.GetRow(e.RowHandle);
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
               if (sid.item != null)
               {
                  if (sid.item.IsWire)
                  {
                     if (sid.QTY1 == 0)
                     {
                        //meters
                        e.Value = string.Format("{0}\nmtrs", sid.QTY2);
                     }
                     else
                     {
                        //rolls
                        e.Value = string.Format("{0}\n[@{1} mtrs", sid.QTY1, sid.QTY2);
                     }
                  }
                  else
                     e.Value = string.Format("{0} pcs", sid.QTY1);
               }
               else
               {
                  e.Value = sid.QTY1;
               }
            }
         }
      }

      private void grdvItems_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
      {
         //compute subtotal
         //StockInDetails sid = (StockInDetails)grdvItems.GetRow(e.RowHandle);
         //if (sid != null)
         //{
         //   Double price = sid.Price1; ;
         //   if (sid.item != null)
         //   {
         //      if (sid.item.IsWire && sid.item.Price1 == 0)
         //         price = sid.Price2;
         //   }

         //}
         grdvItems.UpdateCurrentRow();
      }

      private void grdvItems_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
      {
         StockInDetails sid = (StockInDetails) grdvItems.GetRow(e.RowHandle);
         if (sid != null)
         {
            int qty = sid.QTY_To_Return;
            Double price = sid.Price1;

            //for wires, assume to return 1 whole roll
            if (sid.item != null)
            {
               if (sid.item.IsWire)
                  sid.SubTotal = qty*cUtil.DiscountAmt(sid.Price1, sid.Discount);
               else
                  sid.SubTotal = qty*cUtil.DiscountAmt(sid.Price1, sid.Discount);
            }
            else
               sid.SubTotal = qty*cUtil.DiscountAmt(price, sid.Discount);

            UpdateTotal();
         }
      }

      private Double UpdateTotal()
      {
         Double total = 0;
         foreach (StockInDetails sid in m_StockIn.details)
         {
            total += sid.SubTotal;
         }
         lblTotal.Text = total.ToString(cUtil.FMT_AMOUNT);
         return total;
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         int count = 0;
         foreach (StockInDetails sid in m_StockIn.details)
         {
            count += sid.QTY_To_Return;
         }
         if (count == 0)
         {
            cUtil.ShowMessageExclamation("No items to save!", "Bad Order");
         }
         else
         {
            Cancelled = false;
            ParentForm.Close();
         }
      }
   }
}