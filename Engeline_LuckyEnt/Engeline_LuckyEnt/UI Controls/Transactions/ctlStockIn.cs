#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.Forms;
using Engeline_LuckyEnt.UI_Controls.Viewers;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using DevExpress.XtraEditors;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
   public partial class ctlStockIn : UserControl
   {
      private PurchaseOrderDao PurchaseOrderDao = new PurchaseOrderDao();
      private StockInDao StockInDao = new StockInDao();
      private WarehouseDao WHDao = new WarehouseDao();
      private StockInDetailsDao sidDao = new StockInDetailsDao();
      private DamagedMissingDao dmDao = new DamagedMissingDao();

      private PurchaseOrder m_po = null;
      private StatementofAccount m_soc = null;
      private IList<StockIn> m_lstStockIn = null;
      private bool m_bIsFromView;

      public object PreviousCtl { get; set; }
      public StockIn stockin { get; set; }
      public DamagedMissing m_DMItem { get; set; }

      public ctlStockIn()
      {
         InitializeComponent();
      }

      private void btnSearchPONumber_Click(object sender, EventArgs e)
      {
         frmGenericPopup frm = new frmGenericPopup();
         ctlInputPO ctl = new ctlInputPO();

         frm.Text = "Select SOC";
         frm.ShowCtl(ctl);
         if (!ctl.Canceled)
         {

            //show SOC details
            ShowSOC_Details(ctl.SOC);
            //m_lstStockIn = StockInDao.GetAllByPO_ID(m_po.ID, false);
            //LoadPO(m_po);
            m_lstStockIn = StockInDao.GetAllBySOC_ID(m_soc.ID);
            LoadSOC(m_soc);

            txtInvoiceNo.Focus();
         }
         else
         {
            ClearInput();
         }
      }

      private void ShowPO_Details(PurchaseOrder PO)
      {
         PurchaseOrder.eStatus status = (PurchaseOrder.eStatus) PO.Status;
         m_po = PO;
         txtPONumber.Text = m_po.ID.ToString();
         txtSupplier.Text = m_po.Supplier.ToString();
         txtAddress.Text = m_po.Supplier.Address;
         txtStatus.Text = status.ToString();
         txtNotes.Text = m_po.Notes;
      }

      private void ShowSOC_Details(StatementofAccount SOC)
      {
          m_soc = SOC;
          txtPONumber.Text = m_soc.ID.ToString();
          txtSupplier.Text = m_soc.Supplier.ToString();
          txtAddress.Text = m_soc.Supplier.Address;
          if (m_soc.Payment != 1)
              txtStatus.Text = "Paid";
          else
              txtStatus.Text = "Unpaid";
          txtShipper.Text = m_soc.ShippingCompany.CompanyName + "-" + m_soc.ShipName;
          txtNotes.Text = m_soc.Notes;
      }

      private void ShowSI_Details()
      {
          txtPONumber.Text = stockin.ID.ToString();
          txtSupplier.Text = "";
          txtAddress.Text = "";
          if (stockin.Paid)
              txtStatus.Text = "Paid";
          else
              txtStatus.Text = "Unpaid";
          txtShipper.Text = stockin.Shipper;
          txtNotes.Text = stockin.Notes;
      }

      private void ClearInput()
      {
         m_po = null;
         txtPONumber.Text = "";
         txtSupplier.Text = "";
         txtAddress.Text = "";
         txtNotes.Text = "";
         grdItems.DataSource = null;
         grdItems.RefreshDataSource();
      }

      private double ComputeTotal()
      {
         double Total = 0;
         int index = 0;
         for (index = 0; index < tblData.Rows.Count; index++)
         {
            DataRow row = grdvItems.GetDataRow(index);
            if (Convert.ToBoolean(row["Checkbox"].ToString()))
            {
               Total += Convert.ToDouble(grdvItems.GetRowCellValue(index, "SubTotal").ToString());
            }
         }
         lblTotal.Text = Total.ToString("#,##0.00");
         return Total;
      }

      private void LoadPO(PurchaseOrder PO)
      {
         tblData.Rows.Clear();
         foreach (PurchaseOrderDetails POD in PO.details)
         {
            tblData.Rows.Add(true, POD.ItemIndex, POD.QTY1, POD.QTY2);
         }
         grdItems.DataSource = tblData;
         ComputeTotal();
      }

      private void LoadDamagedMissing(DamagedMissing dmitem)
      {
          tblData.Rows.Clear();
          //get data first before adding
          StockInDao siDao = new StockInDao();
          StockIn refStockIn = siDao.GetById(dmitem.stockin.ID);

          txtPONumber.Text = siDao.GetLastStockInforDamagesMissing().ToString(clsUtil.FMT_ID);
          if (dmitem.stockin.Paid)
              txtStatus.Text = "Paid";
          else
              txtStatus.Text = "Unpaid";

          txtShipper.Text = dmitem.stockin.Shipper;
          Warehouse W = WHDao.GetWHById(dmitem.Warehouse);
          tblData.Rows.Add(true, 1, dmitem.SalvageQuantity, 0, W);
          grdItems.DataSource = tblData;
          ComputeTotal();
      }

      private void LoadSOC(StatementofAccount SOC)
      {
          bool bToCustomer = false;
          int customerCount=0, ItemCount=0;
          tblData.Rows.Clear();
          foreach (StatementofAccountDetails SOCD in SOC.details)
          {
              ItemCount += 1;
              Warehouse W = SOCD.WhDestination;
              if (W != null)
              {
                  tblData.Rows.Add(true, SOCD.ItemIndex, SOCD.QTY, 0, W);
                  customerCount += 1;
              }
              else
              {
                  bToCustomer = true;   
              }
          }
          grdItems.DataSource = tblData;
          ComputeTotal();

          if (bToCustomer)
          {
              clsUtil.ShowMessageInformation(
                  string.Format("Some Items were not added, since its destination is to Customers.\n{0} item(s) added of {1}",customerCount, ItemCount), "New Stock In");
          }
      }

      private void LoadSI()
      {
         if (stockin != null)
         {
             m_bIsFromView = true;
            txtInvoiceNo.Text = stockin.InvoiceNo;
            txtDeliveryReceipt.Text = stockin.DeliveryReceipt;
            txtPackingListNo.Text = stockin.PackingListNo;
            dtInvoiceDate.DateTime = stockin.InvoiceDate;
            dtStockInDate.DateTime = stockin.StockInDate;
            txtShipper.Text = stockin.Shipper;
            //txtWaybill.Text = stockin.WaybillNo;
            //dtShippingDate.DateTime = stockin.ShippingDate;
            //dtArrivalDate.DateTime = stockin.ArrivalDate;
            //txtDueDays.Text = stockin.DueDays.ToString();

            grdvItems.OptionsBehavior.Editable = false;
            grdvItems.Columns["Checkbox"].Visible = false;

            //details
            tblData.Rows.Clear();
            foreach (StockInDetails SID in stockin.details)
            {
                Warehouse W = WHDao.GetWHById(SID.WarehouseStockin);
               tblData.Rows.Add(true, SID.ItemIndex, SID.QTY1, SID.QTY2, W);
            }
            grdItems.DataSource = tblData;
            ComputeTotal();

            btnSearchPONumber.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Text = "&Close";
         }
      }

      private void grdvItems_CustomUnboundColumnData(object sender,
                                                     DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
      {
         DataRow row = grdvItems.GetDataRow(e.RowHandle);
         //PurchaseOrderDetails POD = GetPO_Details(Convert.ToInt32(row["ItemIndex"].ToString()));

          //start for SOC
         if (m_soc != null)
         {
             StatementofAccountDetails SOCD = GetSOC_Details(Convert.ToInt32(row["ItemIndex"].ToString()));
             if (e.IsGetData && e.Column.FieldName == "ItemName")
             {
                 if (SOCD.item != null)
                 {
                     e.Value = string.Format("{0}\n{1}", SOCD.item.Name, SOCD.item.Description);
                 }

             }
             else if (e.IsGetData && e.Column.FieldName == "UnitPrice")
             {
                 if (SOCD.item != null)
                 {
                     e.Value = SOCD.SellingPrice.ToString("#,##0.00");
                 }
             }
             else if (e.IsGetData && e.Column.FieldName == "SubTotal")
             {
                 if (SOCD.item != null)
                 {
                     double st = SOCD.SellingPrice * Convert.ToDouble(row["QTY1"].ToString());
                     //e.Value = clsUtil.DiscountAmt(SOCD.SellingPrice1, POD.Discount)*Convert.ToDouble(row["QTY1"].ToString());
                     e.Value = st;
                 }
             }
         }//end for SOC
         else if (m_DMItem != null)
         {
             if (e.IsGetData && e.Column.FieldName == "ItemName")
             {
                 if (m_DMItem.item != null)
                 {
                     e.Value = string.Format("{0}\n{1}", m_DMItem.item.Name, m_DMItem.item.Description);
                 }
             }
             else if (e.IsGetData && e.Column.FieldName == "UnitPrice")
             {
                 if (m_DMItem.item != null)
                 {
                     e.Value = m_DMItem.SellingPrice.ToString("#,##0.00");
                 }
             }
             else if (e.IsGetData && e.Column.FieldName == "SubTotal")
             {
                 if (m_DMItem.item != null)
                 {
                     double st = 0;
                     if (stockin != null)
                     {
                         StockInDetails dmdetails = sidDao.GetItemByIndex(stockin, Convert.ToInt32(row["ItemIndex"].ToString()));

                         //if(dmdetails.SellingPrice1 > 0)
                         //    st = dmdetails.SellingPrice1 * Convert.ToDouble(dmdetails.QTY_OnHand1);
                         //else
                         st = dmdetails.Price1 * Convert.ToDouble(dmdetails.QTY_OnHand1);
                         //e.Value = clsUtil.DiscountAmt(SOCD.S;ellingPrice1, POD.Discount)*Convert.ToDouble(row["QTY1"].ToString());
                     }
                     else
                     {
                         st = m_DMItem.SellingPrice * m_DMItem.SalvageQuantity;
                     }
                     e.Value = st;
                 }
             }
         }
         
      }

      private PurchaseOrderDetails GetPO_Details(Int32 itemindex)
      {
         foreach (PurchaseOrderDetails POD in m_po.details)
         {
            if (POD.ItemIndex == itemindex)
            {
               return POD;
            }
         }
         return null;
      }

      private StatementofAccountDetails GetSOC_Details(Int32 itemindex)
      {
          if (m_soc != null)
          {
              foreach (StatementofAccountDetails SOCD in m_soc.details)
              {
                  if (SOCD.ItemIndex == itemindex)
                  {
                      return SOCD;
                  }
              }

          }

          return null;
      }
       

      private void grdvItems_RowCellDefaultAlignment(object sender,
                                                     DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventArgs e)
      {
         if (e.Column.FieldName == "UnitPrice" || e.Column.FieldName == "Discount" ||
             e.Column.FieldName == "DiscountedPrice" || e.Column.FieldName == "QTY_PO")
         {
            e.HorzAlignment = DevExpress.Utils.HorzAlignment.Far;
         }
      }

      private void grdvItems_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
      {
         DataRow row = grdvItems.GetDataRow(e.RowHandle);
         //PurchaseOrderDetails POD = GetPO_Details(e.RowHandle + 1);
         StatementofAccountDetails SOCD = GetSOC_Details(e.RowHandle + 1);
         if (SOCD.item != null)
         {
             grdvItems.SetRowCellValue(e.RowHandle, "SubTotal",
                                         SOCD.SellingPrice * Convert.ToDouble(row["QTY1"].ToString()));
         }
         else
         {
             grdvItems.SetRowCellValue(e.RowHandle, "SubTotal",
                                       SOCD.SellingPrice * Convert.ToDouble(row["QTY1"].ToString()));
         }
         ComputeTotal();
      }

      private void ctlStockIn_Load(object sender, EventArgs e)
      {
         //dtArrivalDate.DateTime = DateTime.Now;
         dtInvoiceDate.DateTime = DateTime.Now;
         //dtShippingDate.DateTime = DateTime.Now;
         dtStockInDate.DateTime = DateTime.Now;
         m_bIsFromView = false;

          //warehouses
         IList<Warehouse> lstWarehouse = WHDao.GetWarehouseList();
         foreach (Warehouse w in lstWarehouse)
         {
             this.repositoryItemComboBox1.Items.Add(w);
         }

         if (stockin != null)
         {
            //ShowPO_Details(stockin.purchaseorder);
            //m_lstStockIn = StockInDao.GetAllByPO_ID(stockin.purchaseorder.ID, false);
             if (stockin.statementofaccount != null)
             {
                 ShowSOC_Details(stockin.statementofaccount);
                 m_lstStockIn = StockInDao.GetAllBySOC_ID(stockin.statementofaccount.ID);
             }
             else
             {
                 ShowSI_Details();
                 m_lstStockIn = StockInDao.GetByIdList(stockin.ID);
             }

             
            LoadSI();
         }
         else if (m_DMItem != null)
         {
             //add damaged missing item here
             LoadDamagedMissing(m_DMItem);
         }
         else
             btnSearchPONumber.PerformClick();
      }

      private void LoadStockIn()
      {
         btnSearchPONumber.Enabled = false;
         btnSave.Enabled = false;
      }

      private bool ValidateInput()
      {

          if (m_soc == null && m_DMItem == null)
          {
              clsUtil.ShowMessage("Invalid Statement of Account!", "New Stock In", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
              btnSearchPONumber.Focus();
              return false;
          }


         int ctr = 0;
         foreach (DataRow row in tblData.Rows)
         {
            if (Convert.ToBoolean(row["Checkbox"].ToString()))
            {
               ctr += 1;
            }
         }

         if (ctr == 0)
         {
            clsUtil.ShowMessage("No items to save.Please check at least 1 item.\n!", "New Stock In", MessageBoxButtons.OK,
                              MessageBoxIcon.Exclamation);
            return false;
         }
         return true;
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         if (ValidateInput())
         {
             Int32 updateQty =0;
            StockIn SI = new StockIn();
             if(m_soc != null)
                 SI.ID = m_soc.ID;

             if (m_DMItem != null)
                 SI.ID = Convert.ToInt32(txtPONumber.Text);

            SI.details = new List<StockInDetails>();

            SI.AmountDue = ComputeTotal();
            //SI.ArrivalDate = dtArrivalDate.DateTime;
            SI.DeliveryReceipt = txtDeliveryReceipt.Text;
            SI.DueDays = (Int32) clsUtil.CheckValue(txtDueDays);
            SI.InvoiceDate = dtInvoiceDate.DateTime;
            SI.InvoiceNo = txtInvoiceNo.Text;
            SI.PackingListNo = txtPackingListNo.Text;
            SI.purchaseorder = m_po;
            SI.statementofaccount = m_soc;
            SI.damagedmissing = m_DMItem;
            SI.Shipper = txtShipper.Text;
            //SI.ShippingDate = dtShippingDate.DateTime;
            //PO Related
            //SI.Notes
            //SI.Status
            SI.StockInDate = dtStockInDate.DateTime;
            //SI.DueDate = SI.StockInDate.AddDays(SI.DueDays);
            //SI.WaybillNo = txtWaybill.Text;
            SI.user = clsUtil.GetLoggedInUser();
            SI.wh_id = WHDao.GetWarehouseCode();
            if (txtStatus.Text.ToLower() == "paid")
                SI.Paid = true;
            else
                SI.Paid = false;

            //details
            DataRow row;
            bool bExcess = false;
            for (int index = 0; index < tblData.Rows.Count; index++)
            {
               row = tblData.Rows[index];
               if (Convert.ToBoolean(row["Checkbox"].ToString()))
               {
                  //PurchaseOrderDetails POD = GetPO_Details(index + 1);
                  StatementofAccountDetails SOCD = GetSOC_Details(index + 1);
                  StockInDetails SID = new StockInDetails();
                  if (SOCD != null)
                  {
                      if (SOCD.item != null)
                      {
                          SID.item = new Items();
                          SID.item.ID = SOCD.item.ID;
                      }
                  }

                  SID.ItemIndex = Convert.ToInt32(row["ItemIndex"].ToString());
                   if(SOCD != null)
                       SID.Price1 = SOCD.SellingPrice;

                   if (m_DMItem != null)
                   {
                       SID.item = new Items();
                       SID.item.ID = m_DMItem.item.ID;
                       SID.Price1 = m_DMItem.SellingPrice;
                   }
                  //SID.Price2 = 0;
                  SID.QTY1 = Convert.ToInt32(row["QTY1"].ToString());
                  updateQty = SID.QTY1;
                  //SID.QTY2 = Convert.ToInt32(row["QTY2"].ToString());
                  SID.QTY_OnHand1 = SID.QTY1;
                  SID.QTY_OnHand2 = 0;
                  SID.QTY_OnHandWire = "";
                  //SID.Discount = POD.Discount;

                  SID.SellingPrice1 = 0;
                  //SID.SellingPrice2 = 0;
                  SID.SellingDiscount1 = "";
                  //SID.SellingDiscount2 = "";
                   Warehouse wrehouse = (Warehouse)row["Destination"];
                  SID.WarehouseStockin = wrehouse.ID; //SOCD.WhDestination.ID;

                  SI.details.Add(SID);

                  //check if there is excess in stocks coming in
                  //int count = GetStockInCount(SOCD) + SID.QTY1;
                  //if (count > SOCD.QTY)
                     bExcess = false;
               }
            }

            try
            {
               StockInDao.Save(SI, bExcess);

               if (m_DMItem != null)
               {
                   //update dmitem
                   if (m_DMItem.Damage_Qty > 0)
                       m_DMItem.Damage_Qty -= updateQty;
                   else if (m_DMItem.Missing_Qty > 0)
                       m_DMItem.Missing_Qty -= updateQty;

                   m_DMItem.ReStock = true;
                   m_DMItem.NewStockinID = Convert.ToInt32(txtPONumber.Text);
                   dmDao.Save(m_DMItem);
               }
               clsUtil.ShowMessage("Stock In saved successfully!", "Save Stock In", MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);

               //ctlViewStockIn ctl = new ctlViewStockIn();
               //clsUtil.getMainForm().LoadCtl(ctl, true, "View Stock In", "", false);
               btnCancel.PerformClick();
            }
            catch (Exception ex)
            {
               clsUtil.ShowMessage("Error:\n" + ex.Message, "Save Stock In", MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
            }
         }
      }

      private Int32 GetStockInCount(PurchaseOrderDetails POD)
      {
         Int32 count = 0;
         foreach (StockIn si in m_lstStockIn)
         {
            foreach (StockInDetails sid in si.details)
            {
               if (sid.ItemIndex == POD.ItemIndex)
               {
                  count += sid.QTY1;
               }
            }
         }
         return count;
      }

      private Int32 GetStockInCount(StatementofAccountDetails SOCD)
      {
          Int32 count = 0;
          foreach (StockIn si in m_lstStockIn)
          {
              foreach (StockInDetails sid in si.details)
              {
                  if (sid.ItemIndex == SOCD.ItemIndex)
                  {
                      count += sid.QTY1;
                  }
              }
          }
          return count;
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         clsUtil.getMainForm().CloseCurrentControl();
      }

      private void grdvItems_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
      {
         //System.Drawing.Brush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
         //System.Drawing.Brush backbrush = new System.Drawing.SolidBrush(System.Drawing.Color.LightBlue);
         //e.Graphics.FillRectangle(backbrush, e.Bounds);
         //e.Graphics.DrawString(e.DisplayText, e.Appearance.Font, brush, e.Bounds, e.Appearance.GetStringFormat());
         //e.Handled = true;
      }

      private void mnu_UpdateWarehouse_Click(object sender, EventArgs e)
      {
          ctlStockin_UpdateWarehouse ctl = new ctlStockin_UpdateWarehouse();
          frmGenericPopup frm = new frmGenericPopup();

          ctl.stockin = this;
          frm.Text = "Update Warehouse Item Location";
          frm.ShowCtl(ctl);
      }

      public void UpdateWarehouse(Warehouse W)
      {
          grdvItems.SetRowCellValue(grdvItems.FocusedRowHandle, grdvItems.Columns.ColumnByFieldName("Destination"), W);
      }

      private void mnu_Damage_Click(object sender, EventArgs e)
      {
          DataRow row = grdvItems.GetDataRow(grdvItems.FocusedRowHandle);
          Int32 iIndex = Convert.ToInt32(row["ItemIndex"].ToString());

          if (iIndex > 0)
          {
              StockInDetails sid = sidDao.GetItemByIndex(stockin, iIndex);
              ctlStockin_DamagedMissingForm dmCtl = new ctlStockin_DamagedMissingForm();
              frmGenericPopup frm = new frmGenericPopup();

              int qty1 = sid.QTY_OnHand1;
              double sPrice = sid.SellingPrice1;
              string sDiscount = sid.SellingDiscount1;
              //int dmqty = 0;

              dmCtl.previousCtl = this;
              dmCtl.stockin = stockin;
              dmCtl.sid = sid;
              dmCtl.trxType = "damage";
              frm.Text = "Damage Items";
              frm.ShowCtl(dmCtl);

              //if (dm != null)
              //{
              //    sid.SellingPrice1 = sPrice;
              //    sid.SellingDiscount1 = sDiscount;
                  
              //}
          }
      }

      private void mnu_Missing_Click(object sender, EventArgs e)
      {
          DataRow row = grdvItems.GetDataRow(grdvItems.FocusedRowHandle);
          Int32 iIndex = Convert.ToInt32(row["ItemIndex"].ToString());

          if (iIndex > 0)
          {
              StockInDetails sid = sidDao.GetItemByIndex(stockin, iIndex);
              ctlStockin_DamagedMissingForm dmCtl = new ctlStockin_DamagedMissingForm();
              frmGenericPopup frm = new frmGenericPopup();

              int qty1 = sid.QTY_OnHand1;
              double sPrice = sid.SellingPrice1;
              string sDiscount = sid.SellingDiscount1;
              //int dmqty = 0;

              dmCtl.previousCtl = this;
              dmCtl.stockin = stockin;
              dmCtl.sid = sid;
              dmCtl.trxType = "missing";
              frm.Text = "Missing Items";
              frm.ShowCtl(dmCtl);

              
          }
      }

      private void cmMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
      {
          if (stockin == null)
          {
              mnu_UpdateWarehouse.Enabled = true;
              mnu_Damage.Enabled = false;
              mnu_Missing.Enabled = false;
          }
          else
          {
              mnu_UpdateWarehouse.Enabled = false;
              mnu_Damage.Enabled = true;
              mnu_Missing.Enabled = true;
          }
      }
   }
}