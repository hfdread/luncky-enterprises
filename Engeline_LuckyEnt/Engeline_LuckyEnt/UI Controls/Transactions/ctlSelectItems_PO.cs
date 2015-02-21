#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
   public partial class ctlSelectItems_PO : UserControl
   {
      private ItemDao ItemDao = new ItemDao();
      private PurchaseOrderDiscountsDao DiscountsDao = new PurchaseOrderDiscountsDao();
      private bool m_bAllowChange = true;

      public ctlPurchaseOrder PO_ctl { get; set; }
      //public PurchaseOrder m_PO { get; set; }
      public bool Canceled { get; set; }

      public ctlSelectItems_PO()
      {
         InitializeComponent();
      }

      private void ctlSelectItems_PO_Load(object sender, EventArgs e)
      {
         grdvItems.Columns["Name"].FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
         grdvItems.Columns["Description"].FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
         grdItems.DataSource = ItemDao.getAllRecords();
         txtSearch.Focus();
      }

      private void btnSearch_Click(object sender, EventArgs e)
      {
         if (txtSearch.Text != "")
         {
            string sFilter = clsUtil.GenerateFilterCondition(txtSearch.Text);
            grdvItems.ActiveFilterString = string.Format("[Name] LIKE '{0}' OR [Description] LIKE '{0}'", sFilter);
            ShowItemDetail();
         }
      }

      private void grdvItems_CustomUnboundColumnData(object sender,
                                                     DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
      {
         Items I = (Items) grdvItems.GetRow(e.RowHandle);

         if (e.IsGetData && e.Column.FieldName == "UnitPrice")
         {
            if (I.IsWire)
            {
               e.Value = string.Format("{0}/mtr", I.Price2.ToString("#,##0.00"));
            }
            else
            {
               e.Value = I.Price1.ToString("#,##0.00");
            }
         }
         else if (e.IsGetData && e.Column.FieldName == "OnHand")
         {
            if (I.IsWire)
            {
               e.Value = string.Format("{0}/{1}", I.QTYOnHand1.ToString("#,##0"), I.QTYOnHand2.ToString("#,##0"));
            }
            else
            {
               e.Value = I.QTYOnHand1.ToString("#,##0");
            }
         }
      }

      private void grdvItems_FocusedRowChanged(object sender,
                                               DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
      {
         ShowItemDetail();
      }

      private void ShowItemDetail()
      {
         Items I = (Items) grdvItems.GetRow(grdvItems.FocusedRowHandle);
         if (I != null)
         {
            lblPrice2.Visible = I.IsWire;
            txtPrice2.Visible = I.IsWire;
            lblQTY2.Visible = I.IsWire;
            txtQTY2.Visible = I.IsWire;

            if (I.IsWire)
            {
               lblPrice1.Text = "Price/roll";
               txtPrice1.Text = I.Price1.ToString("#,##0.00");

               lblQTY1.Text = "Rolls";
               txtQTY1.Text = "1";

               lblPrice2.Text = "Price/mtr";
               txtPrice2.Text = I.Price2.ToString("#,##0.00");

               lblQTY2.Text = "Meters/roll";
               txtQTY2.Text = I.QTY2.ToString("#,##0");
            }
            else
            {
               lblPrice1.Text = "Price";
               txtPrice1.Text = I.Price1.ToString("#,##0.00");

               lblQTY1.Text = "QTY";
               txtQTY1.Text = "1";
            }
         }
         else
         {
         }
      }


      private void txtQTY1_TextChanged(object sender, EventArgs e)
      {
         clsUtil.CheckValue(txtQTY1);
      }

      private void txtQTY2_TextChanged(object sender, EventArgs e)
      {
         if (!m_bAllowChange)
            return;

         m_bAllowChange = false;

         long lQTY2 = 0;
         double Price = 0;

         lQTY2 = (long) clsUtil.CheckValue(txtQTY2);
         Price = clsUtil.CheckValue(txtPrice2);
         txtPrice1.Text = (lQTY2*Price).ToString("#,##0.00");

         m_bAllowChange = true;
      }

      private void txtPrice1_TextChanged(object sender, EventArgs e)
      {
         if (!m_bAllowChange)
            return;

         m_bAllowChange = false;

         Double Price1 = 0;
         long QTY1, QTY2;

         if (lblPrice2.Visible)
         {
            //compute Price per meter
            Price1 = clsUtil.CheckValue(txtPrice1);
            QTY1 = (long) clsUtil.CheckValue(txtQTY1);
            QTY2 = (long) clsUtil.CheckValue(txtQTY2);

            if (QTY2 == 0)
            {
               txtPrice2.Text = "0.00";
            }
            else
            {
               txtPrice2.Text = (Price1/QTY2).ToString("#,##0.00");
            }
         }
         m_bAllowChange = true;
      }

      private void txtPrice2_TextChanged(object sender, EventArgs e)
      {
         if (!m_bAllowChange)
            return;

         m_bAllowChange = false;

         double Price2 = 0;
         long QTY2 = 0;

         QTY2 = (long) clsUtil.CheckValue(txtQTY2);
         Price2 = clsUtil.CheckValue(txtPrice2);

         txtPrice1.Text = (QTY2*Price2).ToString("#,##0.00");
         m_bAllowChange = true;
      }

      private void txtQTY1_Enter(object sender, EventArgs e)
      {
         txtQTY1.SelectAll();
      }

      private void txtQTY2_Enter(object sender, EventArgs e)
      {
         txtQTY2.SelectAll();
      }

      private void txtPrice1_Enter(object sender, EventArgs e)
      {
         txtPrice1.SelectAll();
      }

      private void txtPrice2_Enter(object sender, EventArgs e)
      {
         txtPrice2.SelectAll();
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         Canceled = true;
         this.ParentForm.Close();
      }

      private void btnAddItem_Click(object sender, EventArgs e)
      {
         //validate input
         Items item = (Items) grdvItems.GetRow(grdvItems.FocusedRowHandle);
         if (item != null)
         {
            m_bAllowChange = false;
            int QTY1 = (int) clsUtil.CheckValue(txtQTY1);
            int QTY2 = (int) clsUtil.CheckValue(txtQTY2);
            double Price1 = clsUtil.CheckValue(txtPrice1);
            double Price2 = clsUtil.CheckValue(txtPrice2);
            m_bAllowChange = true;

            if (Price1 == 0)
            {
               clsUtil.ShowMessage("Invalid Price!", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               txtPrice1.Focus();
               return;
            }

            if (item.IsWire && Price2 == 0)
            {
               clsUtil.ShowMessage("Invalid Price!", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               txtPrice2.Focus();
               return;
            }

            if (QTY1 == 0)
            {
               clsUtil.ShowMessage("Invalid Quantity!", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               txtQTY1.Focus();
               return;
            }

            if (item.IsWire && QTY2 == 0)
            {
               clsUtil.ShowMessage("Invalid Quantity!", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               txtQTY2.Focus();
               return;
            }

            if (cboDiscount.Text != "")
            {
               if (clsUtil.CheckFormula(cboDiscount.Text) == false)
               {
                  clsUtil.ShowMessage("Invalid Discount Formula!", "Add Item", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                  cboDiscount.SelectAll();
                  cboDiscount.Focus();
                  return;
               }
            }

            PurchaseOrderDetails POD = new PurchaseOrderDetails();
            POD.Discount = cboDiscount.Text;
            POD.item = item;
            POD.QTY1 = QTY1;
            POD.QTY2 = QTY2;
            POD.SellingPrice1 = Price1;
            POD.SellingPrice2 = Price2;

            PO_ctl.AddItem(POD);

            //reset
            cboDiscount.Text = "";
            txtQTY1.Text = "1";
            txtQTY2.Text = "1";
            txtPrice1.Text = "0.00";
            txtPrice2.Text = "0.00";
            ShowItemDetail();

            grdvItems.Focus();
            //if (m_PO.details == null)
            //   m_PO.details = new List<PurchaseOrderDetails>();

            //m_PO.details.Add(POD);

            //Canceled = false;
            //this.ParentForm.Close();
         }
         else
         {
            //do nothing
         }
      }

      private void grdItems_Leave(object sender, EventArgs e)
      {
         cboDiscount.Text = "";
         cboDiscount.Properties.Items.Clear();

         Items item = (Items) grdvItems.GetRow(grdvItems.FocusedRowHandle);
         if (item != null)
         {
            Contacts supplier = (Contacts) PO_ctl.cboCustomer.SelectedValue;
            if (supplier != null)
            {
               IList<PurchaseOrderDiscounts> discounts = DiscountsDao.GetItemDiscounts(supplier.ID, item.ID);
               foreach (PurchaseOrderDiscounts POD in discounts)
               {
                  cboDiscount.Properties.Items.Add(POD.Discount);
               }
            }
         }
      }
   }
}