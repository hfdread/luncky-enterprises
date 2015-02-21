#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.Forms;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
   public partial class ctlNoPriceItems : UserControl
   {
      public StockIn stockin { get; set; }

      private StockInDetailsDao StockinDetailsDao = new StockInDetailsDao();
      private WarehouseDao warehouseDao = new WarehouseDao();

      public ctlNoPriceItems()
      {
         InitializeComponent();
      }

      private void ctlNoPriceItems_Load(object sender, EventArgs e)
      {
         IList<StockInDetails> lst = StockinDetailsDao.GetNoPriceItems(stockin);
         grdItems.DataSource = lst;
      }

      private void grdvItems_CustomUnboundColumnData(object sender,
                                                     DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
      {
         StockInDetails sid = (StockInDetails) grdvItems.GetRow(e.RowHandle);

         if (e.IsGetData && e.Column.FieldName == "ItemName")
         {
            if (sid.item != null)
            {
               e.Value = string.Format("{0}\n{1}", sid.item.Name, sid.item.Description);
            }
            else if (sid.fabricateditem != null)
            {
               e.Value = string.Format("{0}\n{1}", sid.fabricateditem.Name, sid.fabricateditem.Description);
            }
            else if (sid.tradingitem != null)
            {
               e.Value = string.Format("{0}\n{1}", sid.tradingitem.Name, sid.tradingitem.Description);
            }
         }
         else if (e.IsGetData && e.Column.FieldName == "QTY_SI")
         {
            if (sid.item != null)
            {
               e.Value = sid.QTY1.ToString();
            }
            else
            {
               e.Value = sid.QTY1.ToString();
            }
         }
         else if (e.IsGetData && e.Column.FieldName == "Capital")
         {
             if (sid != null)
                 e.Value = clsUtil.DiscountAmt(sid.Price1, sid.Discount).ToString("#,##0.00");
             else
                 e.Value = "";

         }
         else if (e.IsGetData && e.Column.FieldName == "BasePrice")
         {
            if (sid.item != null)
            {
                  if (sid.item.Price1 != 0)
                     e.Value = sid.item.Price1.ToString("#,##0.00");
                  else
                     e.Value = "";
            }
            else
            {
               if (sid.fabricateditem != null)
                  e.Value = sid.fabricateditem.UnitPrice.ToString("#,##0.00");
               else if (sid.tradingitem != null)
                  e.Value = sid.tradingitem.UnitPrice.ToString("#,##0.00");
            }
         }
         else if (e.IsGetData && e.Column.FieldName == "SellingPrice_1")
         {
            //if (sid.item != null)
            //{
               if (sid.SellingDiscount1 != "")
                  e.Value = string.Format("{0}\n@[{1}]",
                                          clsUtil.DiscountAmt(sid.Price1, sid.SellingDiscount1).ToString("#,##0.00"),
                                          sid.SellingDiscount1);
               else
                  e.Value = sid.SellingPrice1.ToString("#,##0.00");
            //}
            //else
            //{
            //   if (sid.SellingDiscount1 != "")
            //      e.Value = string.Format("{0}\n@[{1}]",
            //                              clsUtil.DiscountAmt(sid.Price1, sid.SellingDiscount1).ToString("#,##0.00"),
            //                              sid.SellingDiscount1);
            //   else
            //      e.Value = sid.SellingPrice1.ToString("#,##0.00");
            //}
         }
         else if (e.IsGetData && e.Column.FieldName == "SellingPrice_2")
         {
            if (sid.item != null)
            {
               if (sid.item.IsWire)
               {
                  if (sid.SellingDiscount2 != "")
                  {
                     e.Value = string.Format("{0}\n@[{1}]",
                                             clsUtil.DiscountAmt(sid.Price2, sid.SellingDiscount2).ToString("#,##0.00"),
                                             sid.SellingDiscount2);
                  }
                  else
                     e.Value = sid.SellingPrice2.ToString("#,##0.00");
               }
               else
                  e.Value = "";
            }
            else
               e.Value = "";
         }
         else if (e.IsGetData && e.Column.FieldName == "warehouse")
         {
             Warehouse W = warehouseDao.GetWHById(sid.WarehouseStockin);
             e.Value = string.Format("{0}, {1}", W.ID, W.Name);
         }

      }

      private void btnSetSellingPrice_Click(object sender, EventArgs e)
      {
         Int32 iNormal, iWire;

         IList<StockInDetails> lst = new List<StockInDetails>();
         iNormal = iWire = 0;
         for (int i = 0; i < grdvItems.GetSelectedRows().Length; i++)
         {
            StockInDetails sid = (StockInDetails) grdvItems.GetRow(grdvItems.GetSelectedRows()[i]);
            lst.Add(sid);

            if (sid.item != null)
            {
               if (sid.item.IsWire)
                  iWire++;
               else
                  iNormal++;
            }
            else
            {
               iNormal++;
            }
         }

         //selected items should not be mixed
         if (iNormal > 0 && iWire > 0)
         {
            clsUtil.ShowMessageExclamation("Invalid selection! Please do not mix Normal & Wire items!",
                                         "Set Selling Price");
            return;
         }

         if (lst.Count > 0)
         {
            ctlNoPriceItemSetPrice ctl = new ctlNoPriceItemSetPrice();
            frmGenericPopup frm = new frmGenericPopup();

            if (iWire > 0)
               ctl.WireItem = true;

            ctl.m_lstItems = lst;
            frm.Text = "Set Item Price";
            frm.ShowCtl(ctl);
            if (!ctl.Canceled)
            {
               for (int i = 0; i < grdvItems.GetSelectedRows().Length; i++)
               {
                  StockInDetails sid1 = (StockInDetails) grdvItems.GetRow(grdvItems.GetSelectedRows()[i]);
                  foreach (StockInDetails sid2 in lst)
                  {
                     if (sid1.stockin.ID == sid2.stockin.ID && sid1.ItemIndex == sid2.ItemIndex)
                     {
                        sid1.SellingPrice1 = sid2.SellingPrice1;
                        sid1.SellingPrice2 = sid2.SellingPrice2;
                        sid1.SellingDiscount1 = sid2.SellingDiscount1;
                        sid1.SellingDiscount2 = sid2.SellingDiscount2;
                     }
                  }
               }
               grdvItems.RefreshData();
            }
         }
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         clsUtil.getMainForm().CloseCurrentControl();
      }
   }
}