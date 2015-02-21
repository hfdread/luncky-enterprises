#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DexterHardware_v2.Classes;
using DexterHardware_v2.UI_Controls.Viewers;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace DexterHardware_v2.UI_Controls.Transactions
{
   public partial class ctlReturnedItems : UserControl
   {
      private SalesInvoiceDao InvoiceDao = new SalesInvoiceDao();
      private ReturnedItemsDao ReturnItemDao = new ReturnedItemsDao();
      private ReturnedItemsDetailsDao ReturnDetailDao = new ReturnedItemsDetailsDao();

      public ReturnedItems m_ReturnedItems { get; set; }
      public SalesInvoice m_SalesInvoice { get; set; }
      private bool m_bViewOnly = false;

      private enum eCol
      {
         Index = 0,
         ItemName,
         ItemPrice,
         QTY_Invoice,
         QTY_Return,
         SubTotal
      }

      public ctlReturnedItems()
      {
         InitializeComponent();
      }

      private void ctlReturnedItems_Load(object sender, EventArgs e)
      {
         string sPrice, sName, sQTY;
         double price = 0;
         int index = 0;

         //load salesinvoice details
         lblInvoiceNo.Text = m_SalesInvoice.ID.ToString(cUtil.FMT_ID);
         lblCustomer.Text = m_SalesInvoice.Customer.ToString();
         lblReceiptNo.Text = m_SalesInvoice.ReceiptNumber;
         lblInvoicePO.Text = m_SalesInvoice.PO_Number;
         lblInvoiceDate.Text = m_SalesInvoice.InvoiceDate.ToString(cUtil.FMT_DATE1);
         lblPaymentType.Text = SalesInvoice.GetPaymentType(m_SalesInvoice.PaymentType);

         if (m_ReturnedItems != null)
         {
            //view info
            m_bViewOnly = true;
            m_ReturnedItems.details = ReturnItemDao.GetDetails(m_ReturnedItems.ID);
            grdvItems.OptionsBehavior.Editable = false;
            btnSave.Enabled = false;
         }

         m_SalesInvoice.details = InvoiceDao.GetDetails(m_SalesInvoice.ID);
         foreach (SalesInvoiceDetails sid in m_SalesInvoice.details)
         {
            sName = sid.GetItemNameFull();
            sQTY = sid.GetLabelQTYFull();
            price = cUtil.DiscountAmt(sid.GetAgentPriceUsed(), sid.AgentDiscount);
            sPrice = price.ToString(cUtil.FMT_AMOUNT);

            if (m_bViewOnly)
            {
               foreach (ReturnedItemsDetails rid in m_ReturnedItems.details)
               {
                  if (sid.ID == rid.SID.ID)
                  {
                     if (sid.QTY1 == 0)
                     {
                        tblItems.Rows.Add(index, sName, sPrice, sQTY, rid.QTY2, price*rid.QTY2);
                     }
                     else
                     {
                        tblItems.Rows.Add(index, sName, sPrice, sQTY, rid.QTY1, price*rid.QTY1);
                     }
                  }
               }
            }
            else
               tblItems.Rows.Add(index, sName, sPrice, sQTY, 0, 0);

            index++;
         }
         lblTotal.Text = ComputeTotal().ToString(cUtil.FMT_AMOUNT);
      }

      private void grdvItems_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
      {
         DataRow row = grdvItems.GetDataRow(e.RowHandle);
         Int32 qty_returned = (Int32) row[(Int32) eCol.QTY_Return];

         if (qty_returned > 0)
         {
            SalesInvoiceDetails sid = m_SalesInvoice.details[(Int32) row[(Int32) eCol.Index]];

            if (sid.item != null && sid.QTY1 == 0)
            {
               //per meter sales, should return whole qty if to be returned
               if (sid.QTY_Returned == 0)
               {
                  if (qty_returned != sid.QTY2)
                  {
                     e.ErrorText = "Quantity returned should match invoice quantity!";
                     e.Valid = false;
                     return;
                  }
               }
               else
               {
                  e.ErrorText = "Item already returned!";
                  e.Valid = false;
                  return;
               }

               row[(Int32) eCol.SubTotal] = cUtil.DiscountAmt(sid.GetAgentPriceUsed(), sid.AgentDiscount)*qty_returned;
            }
            else
            {
               if ((qty_returned + sid.QTY_Returned) > sid.QTY1)
               {
                  e.ErrorText = "Total quantity returned should not exceed invoice quantity!";
                  e.Valid = false;
                  return;
               }

               row[(Int32) eCol.SubTotal] = cUtil.DiscountAmt(sid.GetAgentPriceUsed(), sid.AgentDiscount)*qty_returned;
            }
         }
         else
         {
            row[(Int32) eCol.QTY_Return] = 0;
            row[(Int32) eCol.SubTotal] = 0;
         }

         lblTotal.Text = ComputeTotal().ToString(cUtil.FMT_AMOUNT);
      }

      private double ComputeTotal()
      {
         double Total = 0;
         foreach (DataRow row in tblItems.Rows)
         {
            Int32 qty = (Int32) row[(Int32) eCol.QTY_Return];
            SalesInvoiceDetails sid = m_SalesInvoice.details[(Int32) row[(Int32) eCol.Index]];
            if (qty > 0)
            {
               Total += cUtil.DiscountAmt(sid.GetAgentPriceUsed(), sid.AgentDiscount)*qty;
            }
         }
         return Total;
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         if (ValidateInput())
         {
            ReturnedItems RI = new ReturnedItems();

            RI.Invoice = m_SalesInvoice;
            RI.Amount = cUtil.ParseDouble(lblTotal.Text);
            RI.Notes = txtNotes.Text;
            RI.TransactionDate = DateTime.Now;
            RI.EnteredBy = cUtil.GetLoggedInUser();

            //add details
            Int32 qty = 0;
            foreach (DataRow row in tblItems.Rows)
            {
               qty = (Int32) row[(Int32) eCol.QTY_Return];
               if (qty > 0)
               {
                  ReturnedItemsDetails rid = new ReturnedItemsDetails();
                  SalesInvoiceDetails sid = m_SalesInvoice.details[(Int32) row[(Int32) eCol.Index]];
                  rid.SID = sid;

                  if (sid.QTY1 == 0)
                  {
                     //per meter
                     rid.QTY1 = 0;
                     rid.QTY2 = qty;
                  }
                  else
                  {
                     //per roll/normal items
                     rid.QTY1 = qty;
                     rid.QTY2 = sid.QTY2;
                  }

                  //get stockin_details [auto-select]
                  if (sid.bundleditem != null)
                  {
                     foreach (BundledItemDetails bid in sid.bundleditem.details)
                     {
                        GetStockInDetails(sid, rid, bid, qty);
                     }
                  }
                  else
                  {
                     //normal/fab/trade items
                     GetStockInDetails(sid, rid, sid.item, sid.fabitem, sid.tradeitem, qty);
                  }
                  RI.details.Add(rid);
               }
            }

            if (RI.details.Count > 0)
            {
               try
               {
                  ReturnItemDao.Save(RI);
                  cUtil.ShowMessageInformation("Return Items successful!", "Return Items");

                  ctlViewReturnedItems ctl = new ctlViewReturnedItems();
                  cUtil.getMainForm().LoadCtl(ctl, true, "Returned Items Viewer", "", true, DockStyle.Left);
               }
               catch (Exception ex)
               {
                  cUtil.ShowMessageError(ex, "Return Items Error");
               }
            }
            else
            {
               cUtil.ShowMessageExclamation("No Items to return!", "Return Items");
            }
         }
      }

      private void GetStockInDetails(SalesInvoiceDetails sid, ReturnedItemsDetails rid, BundledItemDetails bid,
                                     Int32 QTY)
      {
         Int32 qty_needed = QTY*bid.QTY;

         foreach (SalesInvoiceDetails_StockIn sid2 in sid.stockindetails)
         {
            if (sid2.stockindetails.item != null)
            {
               if (bid.item != null && bid.item.ID == sid2.stockindetails.item.ID)
               {
                  ReturnedItemsDetails_StockIn rid2 = new ReturnedItemsDetails_StockIn();
                  rid2.stockindetails = sid2.stockindetails;

                  if (sid.QTY1 == 0)
                  {
                     rid2.QTY1 = 0;
                     rid2.QTY2 = qty_needed;
                     rid2.wirebreakdown = new WireBreakdown();
                     rid2.wirebreakdown.QTY_OnHand = qty_needed;
                     rid2.wirebreakdown.QTY_Original = qty_needed;
                     rid2.wirebreakdown.SID = rid2.stockindetails;
                     qty_needed = 0;
                  }
                  else
                  {
                     //normal item
                     rid2.wirebreakdown = null;
                     rid2.QTY2 = sid.QTY2;

                     if (sid2.QTY1 >= qty_needed)
                     {
                        rid2.QTY1 = qty_needed;
                        qty_needed = 0;
                     }
                     else
                     {
                        rid2.QTY1 = sid2.QTY1;
                        qty_needed -= sid2.QTY1;
                     }
                  }
                  rid.stockindetails.Add(rid2);

                  if (qty_needed == 0)
                     break;
               }
            }
            else if (sid2.stockindetails.fabricateditem != null)
            {
               if (bid.FabItem != null && bid.FabItem.ID == sid2.stockindetails.fabricateditem.ID)
               {
                  ReturnedItemsDetails_StockIn rid2 = new ReturnedItemsDetails_StockIn();
                  rid2.stockindetails = sid2.stockindetails;

                  //fab item match
                  rid2.wirebreakdown = null;
                  rid2.QTY2 = 0;

                  if (sid2.QTY1 >= qty_needed)
                  {
                     rid2.QTY1 = qty_needed;
                     qty_needed = 0;
                  }
                  else
                  {
                     rid2.QTY1 = sid2.QTY1;
                     qty_needed -= sid2.QTY1;
                  }

                  rid.stockindetails.Add(rid2);

                  if (qty_needed == 0)
                     break;
               }
            }
         }
      }

      private void GetStockInDetails(SalesInvoiceDetails sid, ReturnedItemsDetails rid, Items item,
                                     FabricatedItem fabitem, TradingItem tradeitem, Int32 QTY)
      {
         Int32 qty_needed = QTY;

         foreach (SalesInvoiceDetails_StockIn sid2 in sid.stockindetails)
         {
            if (sid2.stockindetails.item != null)
            {
               if (item != null && item.ID == sid2.stockindetails.item.ID)
               {
                  ReturnedItemsDetails_StockIn rid2 = new ReturnedItemsDetails_StockIn();
                  rid2.stockindetails = sid2.stockindetails;

                  if (sid.QTY1 == 0)
                  {
                     rid2.QTY1 = 0;
                     rid2.QTY2 = qty_needed;
                     rid2.wirebreakdown = new WireBreakdown();
                     rid2.wirebreakdown.QTY_OnHand = qty_needed;
                     rid2.wirebreakdown.QTY_Original = qty_needed;
                     rid2.wirebreakdown.SID = rid2.stockindetails;
                     qty_needed = 0;
                  }
                  else
                  {
                     //normal item
                     rid2.wirebreakdown = null;
                     rid2.QTY2 = sid.QTY2;

                     if (sid2.QTY1 >= qty_needed)
                     {
                        rid2.QTY1 = qty_needed;
                        qty_needed = 0;
                     }
                     else
                     {
                        rid2.QTY1 = sid2.QTY1;
                        qty_needed -= sid2.QTY1;
                     }
                  }
                  rid.stockindetails.Add(rid2);
                  if (qty_needed == 0)
                     break;
               }
            }
            else if (sid2.stockindetails.fabricateditem != null)
            {
               if (fabitem != null && fabitem.ID == sid2.stockindetails.fabricateditem.ID)
               {
                  ReturnedItemsDetails_StockIn rid2 = new ReturnedItemsDetails_StockIn();
                  rid2.stockindetails = sid2.stockindetails;

                  //fab item match
                  rid2.wirebreakdown = null;
                  rid2.QTY2 = 0;

                  if (sid2.QTY1 >= qty_needed)
                  {
                     rid2.QTY1 = qty_needed;
                     qty_needed = 0;
                  }
                  else
                  {
                     rid2.QTY1 = sid2.QTY1;
                     qty_needed -= sid2.QTY1;
                  }
                  rid.stockindetails.Add(rid2);
                  if (qty_needed == 0)
                     break;
               }
            }
            else if (sid2.stockindetails.tradingitem != null)
            {
               if (tradeitem != null && tradeitem.ID == sid2.stockindetails.fabricateditem.ID)
               {
                  ReturnedItemsDetails_StockIn rid2 = new ReturnedItemsDetails_StockIn();
                  rid2.stockindetails = sid2.stockindetails;

                  //fab item match
                  rid2.wirebreakdown = null;
                  rid2.QTY2 = 0;

                  if (sid2.QTY1 >= qty_needed)
                  {
                     rid2.QTY1 = qty_needed;
                     qty_needed = 0;
                  }
                  else
                  {
                     rid2.QTY1 = sid2.QTY1;
                     qty_needed -= sid2.QTY1;
                  }
                  rid.stockindetails.Add(rid2);
                  if (qty_needed == 0)
                     break;
               }
            }
         }
      }

      private bool ValidateInput()
      {
         Int32 qty = 0;
         bool hasItem = false;

         foreach (DataRow row in tblItems.Rows)
         {
            qty = (Int32) row[(Int32) eCol.QTY_Return];
            if (qty > 0)
            {
               hasItem = true;
               //check if allowed to get from this item
               int qty1 = 0, qty2 = 0;
               IList<ReturnedItemsDetails> lst = ReturnDetailDao.getByInvoiceID(m_SalesInvoice.ID);
               foreach (ReturnedItemsDetails rid in lst)
               {
                  qty1 += rid.QTY1;
                  qty2 += rid.QTY2;
               }
               SalesInvoiceDetails sid = m_SalesInvoice.details[(Int32) row[(Int32) eCol.Index]];
               if (sid.item != null)
               {
                  if (sid.item.IsWire)
                  {
                     if (sid.QTY1 != 0)
                     {
                        if ((qty + qty1) > sid.QTY1)
                        {
                           cUtil.ShowMessageExclamation(
                              string.Format(
                                 "Quantity entered will exceed quantity from purchase!\nPlease enter a lower number."),
                              "Return Items");
                           return false;
                        }
                     }
                  }
                  else
                  {
                     //normal item
                     if ((qty + qty1) > sid.QTY1)
                     {
                        cUtil.ShowMessageExclamation(
                           string.Format(
                              "Quantity entered will exceed quantity from purchase!\nPlease enter a lower number."),
                           "Return Items");
                        return false;
                     }
                  }
               }
               else
               {
                  if ((qty + qty1) > sid.QTY1)
                  {
                     cUtil.ShowMessageExclamation(
                        string.Format(
                           "Quantity entered will exceed quantity from purchase!\nPlease enter a lower number."),
                        "Return Items");
                     return false;
                  }
               }
            }
         }

         if (hasItem == false)
         {
            cUtil.ShowMessageExclamation("No item to save!", "Return Items");
            return false;
         }

         return true;
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         cUtil.getMainForm().CloseCurrentControl();
         //if (m_bViewOnly)
         //   cUtil.getMainForm().CloseCurrentControl();
         //else
         //{
         //   ctlViewReturnedItems ctl = new ctlViewReturnedItems();
         //   cUtil.getMainForm().LoadCtl(ctl, true, "Returned Items Viewer", "", true, DockStyle.Left);
         //}
      }
   }
}