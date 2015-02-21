#region

using System;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.Forms;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
   public partial class ctlInputPO : UserControl
   {
      private PurchaseOrderDao PurchaseOrderDao = new PurchaseOrderDao();
      private StatementofAccountDao socDao = new StatementofAccountDao();

      public bool Canceled { get; set; }
      public PurchaseOrder PO { get; set; }
      public ctlStockIn StockIn_Ctl { get; set; }
      public StatementofAccount SOC { get; set; }

      public ctlInputPO()
      {
         InitializeComponent();
      }

      private void btnSelectPO_Click(object sender, EventArgs e)
      {
         ctlInputPOSelect ctl = new ctlInputPOSelect();
         frmGenericPopup frm = new frmGenericPopup();

         this.ParentForm.Visible = false;

         ctl.StocknIn_ctl = StockIn_Ctl;
         frm.Text = "Select Statement of Accounts";
         frm.ShowCtl(ctl);
         if (!ctl.Canceled)
         {
            Canceled = false;
            SOC = ctl.SOC;
            //PO = ctl.PO;
            this.ParentForm.Close();
         }
         else
         {
            PO = null;
            Canceled = true;
            this.ParentForm.Close();
         }
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         Canceled = true;
         this.ParentForm.Close();
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         Int32 PO_ID = (Int32) clsUtil.CheckValue(txtPONumber);
         if (PO_ID != 0)
         {
            //PurchaseOrder PO = PurchaseOrderDao.GetById(PO_ID);
             StatementofAccount SOC = socDao.GetById(PO_ID);
            if (SOC != null)
            {
               //this.PO = PO;
                this.SOC = SOC;
               Canceled = false;
               this.ParentForm.Close();
            }
            else
            {
               clsUtil.ShowMessage("Invalid SOC Number!", "Select SOC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               txtPONumber.SelectAll();
               txtPONumber.Focus();
               return;
            }
         }
         else
         {
            clsUtil.ShowMessage("Invalid SOC Number!", "Select SOC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            txtPONumber.SelectAll();
            txtPONumber.Focus();
            return;
         }
      }
   }
}