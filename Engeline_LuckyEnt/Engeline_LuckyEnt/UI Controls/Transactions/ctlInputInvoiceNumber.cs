#region

using System;
using System.Windows.Forms;
using DexterHardware_v2.Classes;

#endregion

namespace DexterHardware_v2.UI_Controls.Transactions
{
   public partial class ctlInputInvoiceNumber : UserControl
   {
      public bool Canceled { get; set; }

      public ctlInputInvoiceNumber()
      {
         InitializeComponent();
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         Canceled = true;
         ParentForm.Close();
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         if (cUtil.ParseInt32(txtPONumber.Text) > 0)
            ParentForm.Close();
         else
         {
            cUtil.ShowMessageExclamation("Invalid invoice number!", "Enter Invoice No.");
            txtPONumber.Focus();
         }
      }
   }
}