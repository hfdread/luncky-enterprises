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
   public partial class ctlNoPriceItemSetPrice : UserControl
   {
      public ctlNoPriceItems PreviousCtl { get; set; }
      public bool Canceled { get; set; }
      public bool WireItem { get; set; }
      public IList<StockInDetails> m_lstItems { get; set; }


      private StockInDetailsDao StockInDetailsDao = new StockInDetailsDao();

      public ctlNoPriceItemSetPrice()
      {
         InitializeComponent();
      }

      private void optByPrice_CheckedChanged(object sender, EventArgs e)
      {
         txtPrice1.Text = "0.00";
         txtPrice2.Text = "0.00";
         txtDiscount1.Text = "";
         txtDiscount2.Text = "";

         txtPrice1.Enabled = optByPrice.Checked;
         txtDiscount1.Enabled = optByDiscount.Checked;

         //if (WireItem)
         //{
         //   txtPrice2.Enabled = optByPrice.Checked;
         //   txtDiscount2.Enabled = optByDiscount.Checked;
         //}
      }

      private void ctlNoPriceItemSetPrice_Load(object sender, EventArgs e)
      {
        
        txtPrice2.Enabled = false;
        txtDiscount2.Enabled = false;

         if (m_lstItems.Count > 1)
         {
            //multiple items, allow only setting of discount
            optByDiscount.Checked = true;
            optByPrice.Enabled = false;
            txtPrice1.Enabled = false;
            txtPrice2.Enabled = false;
            txtDiscount1.Focus();
         }
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         string Discount1, Discount2;
         double Price1, Price2;

         Price1 = clsUtil.CheckValue(txtPrice1);
         Price2 = clsUtil.CheckValue(txtPrice2);
         Discount1 = txtDiscount1.Text;
         Discount2 = txtDiscount2.Text;

         if (optByPrice.Checked)
         {
            Discount1 = "";
            Discount2 = "";

            if (Price1 == 0)
            {
               clsUtil.ShowMessageExclamation("Invalid Price!", "Set Item Price");
               txtPrice1.SelectAll();
               txtPrice1.Focus();
               return;
            }

           Price2 = 0;
         }
         else
         {
            Price1 = 0;
            Price2 = 0;

            if (Discount1.Trim() == "")
            {
               clsUtil.ShowMessageExclamation("Invalid Discount!", "Set Item Price");
               txtPrice1.SelectAll();
               txtPrice1.Focus();
               return;
            }
            else
            {
               if (!clsUtil.CheckFormula(Discount1))
               {
                  clsUtil.ShowMessageExclamation("Invalid Discount!", "Set Item Price");
                  txtDiscount1.SelectAll();
                  txtDiscount1.Focus();
                  return;
               }
            }

           Discount2 = "";
         }

         foreach (StockInDetails sid in m_lstItems)
         {
            sid.SellingPrice1 = Price1;
            sid.SellingPrice2 = Price1;
            sid.SellingDiscount1 = Discount1;
            sid.SellingDiscount2 = Discount2;
         }

         try
         {
            StockInDetailsDao.SaveBatch(m_lstItems);
            Canceled = false;
            this.ParentForm.Close();
         }
         catch (Exception ex)
         {
            clsUtil.ShowMessageError("Error:\n" + ex.Message, "Set Item Price");
         }
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         Canceled = true;
         this.ParentForm.Close();
      }
   }
}