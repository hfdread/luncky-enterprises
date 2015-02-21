#region

using System;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using MyHibernate.BusinessObjects;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
   public partial class ctlSalesInvoiceChangePrice : UserControl
   {
      private const string FMT_PRICE = "#,##0.00";

      public SalesInvoiceDetails m_InvoiceDetail { get; set; }
      public bool Canceled { get; set; }
      public bool ApplyToAll { get; set; }

      private double m_OrigAgentPrice, m_OrigCustomerPrice;
      private string m_OrigAgentDiscount, m_OrigCustomerDiscount;

      public ctlSalesInvoiceChangePrice()
      {
         InitializeComponent();
      }

      private void ctlSalesInvoiceChangePrice_Load(object sender, EventArgs e)
      {
         if (m_InvoiceDetail.QTY1 == 0)
         {
            //wire, by meter
            lblUnitAgent.Text = "/meter";
            lblUnitCustomer.Text = "/meter";

            m_OrigAgentPrice = m_InvoiceDetail.AgentPrice2;
            txtAgentPrice.Text = m_OrigAgentPrice.ToString(FMT_PRICE);

            m_OrigAgentDiscount = m_InvoiceDetail.AgentDiscount;
            txtDiscountAgent.Text = m_InvoiceDetail.AgentDiscount;
            grpAgentPrice.Text = "Agent Price: " +
                                 clsUtil.DiscountAmt(m_InvoiceDetail.AgentPrice2, m_InvoiceDetail.AgentDiscount).ToString(
                                    FMT_PRICE);

            m_OrigCustomerPrice = m_InvoiceDetail.CustomerPrice2;
            txtPriceCustomer.Text = m_OrigCustomerPrice.ToString(FMT_PRICE);

            m_OrigCustomerDiscount = m_InvoiceDetail.CustomerDiscount;
            txtDiscountCustomer.Text = m_InvoiceDetail.CustomerDiscount;
            grpCustomerPrice.Text = "Customer Price: " +
                                    clsUtil.DiscountAmt(m_InvoiceDetail.CustomerPrice2, m_InvoiceDetail.CustomerDiscount).
                                       ToString(FMT_PRICE);
         }
         else
         {
            if (m_InvoiceDetail.item != null && m_InvoiceDetail.item.IsWire)
            {
               lblUnitAgent.Text = "/roll";
               lblUnitCustomer.Text = "/roll";
            }
            else
            {
               lblUnitAgent.Text = "/pc";
               lblUnitCustomer.Text = "/pc";
            }

            m_OrigAgentPrice = m_InvoiceDetail.AgentPrice1;
            txtAgentPrice.Text = m_OrigAgentPrice.ToString(FMT_PRICE);

            m_OrigAgentDiscount = m_InvoiceDetail.AgentDiscount;
            txtDiscountAgent.Text = m_InvoiceDetail.AgentDiscount;
            grpAgentPrice.Text = "Agent Price: " +
                                 clsUtil.DiscountAmt(m_InvoiceDetail.AgentPrice1, m_InvoiceDetail.AgentDiscount).ToString(
                                    FMT_PRICE);

            m_OrigCustomerPrice = m_InvoiceDetail.CustomerPrice1;
            txtPriceCustomer.Text = m_OrigCustomerPrice.ToString(FMT_PRICE);

            m_OrigCustomerDiscount = m_InvoiceDetail.CustomerDiscount;
            txtDiscountCustomer.Text = m_InvoiceDetail.CustomerDiscount;
            grpCustomerPrice.Text = "Customer Price: " +
                                    clsUtil.DiscountAmt(m_InvoiceDetail.CustomerPrice1, m_InvoiceDetail.CustomerDiscount).
                                       ToString(FMT_PRICE);
         }
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         //validate
         double PriceAgent, PriceCustomer;
         string DiscountAgent, DiscountCustomer;

         PriceAgent = clsUtil.CheckValue(txtAgentPrice);
         if (PriceAgent == 0)
         {
            clsUtil.ShowMessageExclamation("Invalid agent price!", "Change Item Price");
            txtAgentPrice.Focus();
            return;
         }

         DiscountAgent = txtDiscountAgent.Text.Trim();
         if (DiscountAgent != "")
         {
            if (!clsUtil.CheckFormula(DiscountAgent))
            {
               clsUtil.ShowMessageExclamation("Invalid agent discount!", "Change Item Price");
               txtDiscountAgent.Focus();
               return;
            }
         }

         PriceCustomer = clsUtil.CheckValue(txtPriceCustomer);
         if (PriceCustomer == 0)
         {
            clsUtil.ShowMessageExclamation("Invalid customer price!", "Change Item Price");
            txtPriceCustomer.Focus();
            return;
         }

         DiscountCustomer = txtDiscountCustomer.Text.Trim();
         if (DiscountCustomer != "")
         {
            if (!clsUtil.CheckFormula(DiscountCustomer))
            {
               clsUtil.ShowMessageExclamation("Invalid customer discount!", "Change Item Price");
               txtDiscountCustomer.Focus();
               return;
            }
         }

         if (clsUtil.DiscountAmt(PriceAgent, DiscountAgent) > clsUtil.DiscountAmt(PriceCustomer, DiscountCustomer))
         {
            clsUtil.ShowMessageExclamation("Customer's price cannot be lower than agent's price!", "Change Item Price");
            return;
         }

         ApplyToAll = chkApplyToAll.Checked;
         if (ApplyToAll)
         {
            if (
               clsUtil.ShowMessageYesNo(
                  "Only discount will be set if changes will be applied to all.\nDo you wish to continue?",
                  "Change Item Price") == DialogResult.No)
               return;
         }

         //evrything ok
         if (m_InvoiceDetail.item != null && m_InvoiceDetail.item.IsWire)
         {
            m_InvoiceDetail.AgentPrice2 = PriceAgent;
            m_InvoiceDetail.AgentDiscount = DiscountAgent;
            m_InvoiceDetail.CustomerPrice2 = PriceCustomer;
            m_InvoiceDetail.CustomerDiscount = DiscountCustomer;
         }
         else
         {
            m_InvoiceDetail.AgentPrice1 = PriceAgent;
            m_InvoiceDetail.AgentDiscount = DiscountAgent;
            m_InvoiceDetail.CustomerPrice1 = PriceCustomer;
            m_InvoiceDetail.CustomerDiscount = DiscountCustomer;
         }

         Canceled = false;
         this.ParentForm.Close();
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         Canceled = true;
         this.ParentForm.Close();
      }

      private void btnResetAgentPrice_Click(object sender, EventArgs e)
      {
         txtAgentPrice.Text = m_OrigAgentPrice.ToString(FMT_PRICE);
         txtDiscountAgent.Text = m_OrigAgentDiscount;
         grpAgentPrice.Text = "Agent Price: " +
                              clsUtil.DiscountAmt(m_OrigAgentPrice, m_OrigAgentDiscount).ToString(FMT_PRICE);
         txtAgentPrice.Focus();
      }

      private void btnResetCustomerPrice_Click(object sender, EventArgs e)
      {
         txtPriceCustomer.Text = m_OrigCustomerPrice.ToString(FMT_PRICE);
         txtDiscountCustomer.Text = m_OrigCustomerDiscount;
         grpCustomerPrice.Text = "Customer Price: " +
                                 clsUtil.DiscountAmt(m_OrigCustomerPrice, m_OrigCustomerDiscount).ToString(FMT_PRICE);
         txtPriceCustomer.Focus();
      }
   }
}