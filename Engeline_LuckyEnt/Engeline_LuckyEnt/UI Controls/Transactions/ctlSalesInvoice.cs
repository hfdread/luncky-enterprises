#region

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.Forms;
using Engeline_LuckyEnt.UI_Controls.Accounting;
using Engeline_LuckyEnt.UI_Controls.Utilities;
using Engeline_LuckyEnt.UI_Controls.Viewers;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
//using Engeline_LuckyEnt.Reports;
#endregion

namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
   public partial class ctlSalesInvoice : UserControl
   {
      private const string FMT_AMOUNT = "#,##0.00";
      private const string FMT_ID = "000000";

      private ContactsDao CustomerDao = null;
      private SalesInvoiceDao InvoiceDao = null;
      private SalesInvoiceDetailsDao InvoiceDetailsDao = null;
      private PaymentsDao PaymentsDao = null;
      private PaymentsDetailDao PaymentsDetailsDao = null;
      private AgentQuotaDao AgentQuotaDao = null;
      private StatementofAccountDao socDao = null;
      private PurchaseOrderDao poDao = null;
      private WarehouseDao whDao = null;

      public SalesInvoice.eInvoiceType m_InvoiceType { get; set; }
      public SalesInvoice m_SalesInvoice { get; set; }
      public LoanedItems m_LoanedItem { get; set; }
      private bool bViewOnly = false;
      public IList<PurchaseOrder> lstPO { get; set; }

      private Int32 m_TermsDaysApproved = 0;
      private Int32 m_TermsPDCDaysApproved = 0;
      private bool m_bLowPriceApproved = false;
      private double m_CreditExtensionAllowed = 0;

      private IList<PaymentsPDC> m_lstPDC = new List<PaymentsPDC>();

      private enum eCol
      {
         QTY,
         Unit,
         ItemName,
         WAREHOUSE,
         AgentPrice,
         CustomerPrice,
         SubTotal,
         ItemObject,
         LowPrice
      }

      public ctlSalesInvoice()
      {
         InitializeComponent();

         CustomerDao = new ContactsDao();
         InvoiceDao = new SalesInvoiceDao();
         InvoiceDetailsDao = new SalesInvoiceDetailsDao();
         PaymentsDao = new PaymentsDao();
         PaymentsDetailsDao = new PaymentsDetailDao();
         AgentQuotaDao = new AgentQuotaDao();
         socDao = new StatementofAccountDao();
         poDao = new PurchaseOrderDao();
         whDao = new WarehouseDao();
      }

      private void ctlSalesInvoice_Load(object sender, EventArgs e)
      {
         this.Hide();
         dtDate.DateTime = DateTime.Now;

         if (m_InvoiceType == SalesInvoice.eInvoiceType.Accounts || m_InvoiceType == SalesInvoice.eInvoiceType.DeliveryReceipt)
         {
            grpCreditInfo.Visible = true;
            chkWithHeld.Visible = true;
         }
         else
         {
            grpCreditInfo.Visible = false;
            chkWithHeld.Visible = false;
         }

         if (m_InvoiceType == SalesInvoice.eInvoiceType.Cash)
         {
            grpCheck.Visible = false;
            chkWithHeld.Visible = false;
         }

         //set datasource for PDC Payments
         grdPDC.DataSource = m_lstPDC;

         if (m_SalesInvoice != null)
         {
            //view mode
            txtReceiptNo.Enabled = false;
            txtPONo.Enabled = false;
            cboCustomer.Enabled = false;
            txtContactNo.Enabled = false;
            txtAddress.Enabled = false;
            cboPaymentType.Enabled = false;
            cboTerms.Enabled = false;
            txtNotes.Enabled = false;
            btnAddItem.Enabled = false;
            btnRemoveItem.Enabled = false;
            btnAddPDC.Enabled = false;
            btnRemovePDC.Enabled = false;
            txtCashPayment.Enabled = false;
            btnSave.Enabled = false;
            dtDate.Enabled = false;
            bViewOnly = true;
            grpCreditInfo.Visible = false;
            chkWithHeld.Visible = true;
            chkWithHeld.Enabled = false;
            LoadInvoice();

            btnPrint.Visible = true;
         }
         else if (m_LoanedItem!=null)
         {
            cboCustomer.Enabled = false;
            txtContactNo.Enabled = false;
            txtAddress.Enabled = false;
            btnAddItem.Enabled = false;
            btnRemoveItem.Enabled = false;
            bViewOnly = true;
            chkWithHeld.Visible = true;
            LoadLoanedItem();
            LoadPaymentMode();
            cboPaymentType.SelectedIndex = 0;
            txtReceiptNo.Focus();
         }
         else
         {
            LoadCustomers();
            LoadPaymentMode();
            cboPaymentType.SelectedIndex = 0;

            //load default terms
            cboTerms.Properties.Items.Add("15");
            cboTerms.Properties.Items.Add("30");
            cboTerms.Properties.Items.Add("45");
            cboTerms.Properties.Items.Add("60");
            cboTerms.Properties.Items.Add("75");
            cboTerms.Properties.Items.Add("90");
            cboTerms.Enabled = true;

            txtReceiptNo.Focus();
            cboCustomer.Focus();
         }
         this.Show();
         HideUnusedItems();
      }

      private void LoadInvoice()
      {
         txtInvoiceNo.Text = m_SalesInvoice.ID.ToString(FMT_ID);
         txtReceiptNo.Text = m_SalesInvoice.ReceiptNumber;
         cboCustomer.Text = m_SalesInvoice.Customer.ToString();
         txtContactNo.Text = m_SalesInvoice.Customer.LandlineNumber;
         txtAddress.Text = m_SalesInvoice.Customer.Address;
         txtPONo.Text = m_SalesInvoice.PO_Number;
         chkWithHeld.Checked = m_SalesInvoice.Withheld;

         //credit info
         if (grpCreditInfo.Visible)
         {
            lblCreditLimit.Text = m_SalesInvoice.Customer.CreditLimit.ToString(FMT_AMOUNT);
            lblCreditUsed.Text = m_SalesInvoice.Customer.CreditUsed.ToString(FMT_AMOUNT);
            lblCreditAllowed.Text =
               (m_SalesInvoice.Customer.CreditLimit - m_SalesInvoice.Customer.CreditUsed).ToString(FMT_AMOUNT);
         }

         cboPaymentType.Text = ((SalesInvoice.ePaymentType) m_SalesInvoice.PaymentType).ToString();
         cboTerms.Text = m_SalesInvoice.Terms.ToString();
         txtNotes.Text = m_SalesInvoice.Notes;
         dtDate.DateTime = m_SalesInvoice.InvoiceDate;

         //load item details  
         IList<SalesInvoiceDetails> lstDetails = InvoiceDetailsDao.GetAllRecordsByField("salesinvoice.ID",
                                                                                        m_SalesInvoice.ID);
         foreach (SalesInvoiceDetails sivd in lstDetails)
         {
            AddItem(sivd);
         }

         txtTotal.Text = m_SalesInvoice.AmountDue.ToString(FMT_AMOUNT);
         if (m_SalesInvoice.PaymentCash > 0)
            txtCashPayment.Text = m_SalesInvoice.PaymentCash.ToString(FMT_AMOUNT);

         //load payments
         IList<PaymentsDetail> lstInvoicePayments = PaymentsDetailsDao.getAllPaymentsByInvoice(m_SalesInvoice.ID);

         double CashPayment = 0;
         m_lstPDC = new List<PaymentsPDC>();
         foreach (PaymentsDetail pd in lstInvoicePayments)
         {
            if (pd.payment.PaymentType == (Int32) Payments.ePaymentType.Cash)
               CashPayment += pd.Amount;
            else if (pd.payment.PDCdetail != null)
            {
               m_lstPDC.Add(pd.payment.PDCdetail);
            }
         }
         grdPDC.DataSource = m_lstPDC;
      }

      private void LoadLoanedItem()
      {
         m_SalesInvoice = new SalesInvoice();
         m_SalesInvoice.LoanedItemID = m_LoanedItem.ID;txtInvoiceNo.Text = "--";
         m_SalesInvoice.InvoiceType = (int)SalesInvoice.eInvoiceType.Accounts;
         txtReceiptNo.Text = "";
         cboCustomer.Items.Add(m_LoanedItem.Customer);
         cboCustomer.SelectedIndex = 0;
         cboCustomer.Text = m_LoanedItem.Customer.ToString();
         txtContactNo.Text = m_LoanedItem.Customer.LandlineNumber;
         txtAddress.Text = m_LoanedItem.Customer.Address;
         txtPONo.Text = "";
         chkWithHeld.Checked = false;

         //load details
         foreach (LoanedItemsDetails lid in m_LoanedItem.details)
         {
            if(lid.Selected)
            {
               SalesInvoiceDetails sivd = new SalesInvoiceDetails();
               sivd.LoanedItemDetailsID = lid.ID;
               sivd.AgentDiscount = lid.AgentDiscount;
               sivd.AgentPrice1 = lid.AgentPrice1;
               sivd.AgentPrice2 = lid.AgentPrice2;
               sivd.CustomerDiscount = lid.CustomerDiscount;
               sivd.CustomerPrice1 = lid.CustomerPrice1;
               sivd.CustomerPrice2 = lid.CustomerPrice2;
               if(lid.item!=null && lid.item.IsWire && lid.QTY1==0)
               {
                  sivd.QTY1 = 0;
                  sivd.QTY2 = lid.QTY2;
               }
               else
               {
                  sivd.QTY1 = lid.QTY_ToReturn;
                  sivd.QTY2 = lid.QTY2;
               }

               sivd.bundleditem = lid.bundleditem;
               sivd.fabitem = lid.fabitem;
               sivd.item = lid.item;
               sivd.tradeitem = lid.tradeitem;

               sivd.stockindetails = new List<SalesInvoiceDetails_StockIn>();

               int qtytoreturn = lid.QTY_ToReturn, unreturned = 0;
               foreach (LoanedItemsDetails_StockIn lid_si in lid.stockindetails)
               {
                  SalesInvoiceDetails_StockIn sivd_si = new SalesInvoiceDetails_StockIn();
                  
                  if(lid.item!=null && lid.item.IsWire && lid.QTY1==0)
                  {
                     unreturned = (lid_si.QTY2 - lid_si.QTY_Invoiced - lid_si.QTY_Returned);

                     sivd_si.QTY1 = 0;
                     sivd_si.QTY2 = unreturned;
                     qtytoreturn = 0;

                     WireBreakdown wb = new WireBreakdown();
                     wb.NewBreakdown = true;

                     //create new wire breakdown
                     if (lid_si.wirebreakdown != null)
                     {
                        wb.BreakDownID = lid_si.wirebreakdown.BreakDownID;
                        wb.QTY_OnHand = lid_si.wirebreakdown.QTY_Original;
                        wb.QTY_Original = lid_si.wirebreakdown.QTY_Original;
                        wb.SID = lid_si.wirebreakdown.SID;
                     }
                     else
                     {
                        wb.BreakDownID = 0;
                        wb.QTY_OnHand = lid_si.QTY2;
                        wb.QTY_Original = lid_si.stockindetails.QTY2;
                        wb.SID = lid_si.stockindetails;
                     }
                     sivd_si.wirebreakdown = wb;
                  }
                  else
                  {
                     unreturned = lid_si.QTY1 - lid_si.QTY_Invoiced - lid_si.QTY_Returned;
                     if(qtytoreturn<=unreturned)
                     {
                        sivd_si.QTY1 = qtytoreturn;
                        sivd_si.QTY2 = lid_si.stockindetails.QTY2;
                        qtytoreturn = 0;
                     }
                     else
                     {
                        sivd_si.QTY1 = unreturned;
                        qtytoreturn -= unreturned;
                     }
                  }
                  //sivd_si.QTY1 = lid_si.QTY1;
                  //sivd_si.QTY2 = lid_si.QTY2;
                  sivd_si.SellingDiscount1 = lid_si.SellingDiscount1;
                  sivd_si.SellingDiscount2 = lid_si.SellingDiscount2;
                  sivd_si.SellingPrice1 = lid_si.SellingPrice1;
                  sivd_si.SellingPrice2 = lid_si.SellingPrice2;
                  sivd_si.salesinvoicedetails = sivd;
                  sivd_si.stockindetails = lid_si.stockindetails;

                  sivd.stockindetails.Add(sivd_si);

                  if (qtytoreturn == 0)
                     break;
               }
               AddItem(sivd);
            }}
      }

      private void LoadCustomers()
      {
         cboCustomer.DataSource = CustomerDao.getAllCustomers();
         cboCustomer.SelectedIndex = -1;
      }

      private void LoadPaymentMode()
      {
         cboPaymentType.Items.Clear();
         if (m_InvoiceType == SalesInvoice.eInvoiceType.Cash)
         {
            cboPaymentType.Items.Add(SalesInvoice.GetPaymentType((int) SalesInvoice.ePaymentType.CBD));
            cboPaymentType.Items.Add(SalesInvoice.GetPaymentType((int) SalesInvoice.ePaymentType.COD));
            //if (m_LoanedItem != null)
            //{
            //   cboPaymentType.Items.Add(SalesInvoice.GetPaymentType((int)SalesInvoice.ePaymentType.Terms));
            //   cboPaymentType.Items.Add(SalesInvoice.GetPaymentType((int)SalesInvoice.ePaymentType.PDC));
            //   cboPaymentType.Items.Add(SalesInvoice.GetPaymentType((int)SalesInvoice.ePaymentType.MultiPDC));
            //}
            cboTerms.Text = "";
            cboTerms.Enabled = false;
         }
         else if (m_InvoiceType == SalesInvoice.eInvoiceType.Accounts ||
                  m_InvoiceType == SalesInvoice.eInvoiceType.DeliveryReceipt)
         {
            cboPaymentType.Items.Add(SalesInvoice.GetPaymentType((int) SalesInvoice.ePaymentType.Terms));
            cboPaymentType.Items.Add(SalesInvoice.GetPaymentType((int) SalesInvoice.ePaymentType.PDC));
            cboPaymentType.Items.Add(SalesInvoice.GetPaymentType((int) SalesInvoice.ePaymentType.MultiPDC));
            cboTerms.Enabled = true;
         }
         else
         {
            cboPaymentType.Items.Add(SalesInvoice.GetPaymentType((int) SalesInvoice.ePaymentType.CBD));
            cboPaymentType.Items.Add(SalesInvoice.GetPaymentType((int) SalesInvoice.ePaymentType.COD));
            cboPaymentType.Items.Add(SalesInvoice.GetPaymentType((int) SalesInvoice.ePaymentType.Terms));
            cboPaymentType.Items.Add(SalesInvoice.GetPaymentType((int) SalesInvoice.ePaymentType.PDC));
            cboPaymentType.Items.Add(SalesInvoice.GetPaymentType((int) SalesInvoice.ePaymentType.MultiPDC));
            cboTerms.Enabled = false;
         }
         cboPaymentType.SelectedIndex = 0;
      }

      private void btnAddItem_Click(object sender, EventArgs e)
      {
         if (m_SalesInvoice == null)
         {
            m_SalesInvoice = new SalesInvoice();
         }

         ctlSelectItems_Invoice ctl = new ctlSelectItems_Invoice();
         frmGenericPopup frm = new frmGenericPopup();

         ctl.ParentCtl = this;
         frm.Text = "Select Item";
         frm.ShowCtl(ctl);
      }

      private void cboPaymentType_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (cboPaymentType.Text == SalesInvoice.GetPaymentType((int) SalesInvoice.ePaymentType.Terms))
         {
            cboTerms.Enabled = true;
            cboTerms.Properties.Items.Clear();

            Contacts customer = (Contacts) cboCustomer.SelectedValue;
            if (customer != null)
            {
               for (int i = 1; i <= customer.Terms; i++)
                  cboTerms.Properties.Items.Add(i);

               if (cboTerms.Properties.Items.Count > 0)
                  cboTerms.SelectedIndex = cboTerms.Properties.Items.Count - 1;
            }
         }
         else
         {
            cboTerms.Text = "";
            cboTerms.Enabled = false;
         }
      }

      private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
      {
         Contacts customer = (Contacts) cboCustomer.SelectedItem;
         if (customer != null)
         {
            txtAddress.Text = customer.Address;
            txtContactNo.Text = customer.LandlineNumber;

            //credit info
            if (grpCreditInfo.Visible)
            {
               lblCreditLimit.Text = customer.CreditLimit.ToString("#,##0.00");
               lblCreditUsed.Text = customer.CreditUsed.ToString("#,##0.00");
               lblCreditAllowed.Text = (customer.CreditLimit - customer.CreditUsed).ToString("#,##0.00");
            }

            //load terms for customer
            cboPaymentType_SelectedIndexChanged(null,null);
         }
         else
         {
            txtContactNo.Text = "";
            txtAddress.Text = "";

            //credit info
            if (grpCreditInfo.Visible)
            {
               lblCreditLimit.Text = "0.00";
               lblCreditUsed.Text = "0.00";
               lblCreditAllowed.Text = "0.00";
            }
         }
      }

      public void AddItem(SalesInvoiceDetails sivd)
      {
         TreeListNode ParentNode, ChildNode;

         ParentNode = treeItems.AppendNode(null, null);
         ParentNode.SetValue(eCol.ItemObject.ToString(), sivd);
         ParentNode.SetValue(eCol.LowPrice.ToString(), 0);

         m_SalesInvoice.details.Add(sivd);

         treeItems.BeginUnboundLoad();
         if (sivd.item != null)
         {
            ParentNode.SetValue(eCol.ItemName.ToString(),
                                string.Format("{0}\n{1}", sivd.item.Name, sivd.item.Description));
         }
         
          ParentNode.SetValue(eCol.QTY.ToString(), sivd.QTY1);
          ParentNode.SetValue(eCol.Unit.ToString(), sivd.item.Unit);
          //if(sivd.whPO != null)
          //    ParentNode.SetValue(eCol.WAREHOUSE.ToString(), string.Format("{0}, {1}", sivd.whPO.ID, sivd.whPO.Name));
          //else
          //    ParentNode.SetValue(eCol.WAREHOUSE.ToString(), string.Format("{0}, {1}", sivd.whStockin.ID, sivd.whStockin.Name));

          if (sivd.AgentDiscount == "")
          {
              ParentNode.SetValue(eCol.AgentPrice.ToString(), sivd.AgentPrice1.ToString("#,##0.00"));
          }
          else
          {
              ParentNode.SetValue(eCol.AgentPrice.ToString(),
                                  string.Format("{0}\n@{1} Less: {2}",
                                                  clsUtil.DiscountAmt(sivd.AgentPrice1, sivd.AgentDiscount).ToString(
                                                  "#,##0.00"), sivd.AgentPrice1.ToString("#,##0.00"),
                                                  sivd.AgentDiscount));
          }

          if (sivd.CustomerDiscount == "")
         {
            ParentNode.SetValue(eCol.CustomerPrice.ToString(), sivd.CustomerPrice1.ToString("#,##0.00"));
            ParentNode.SetValue(eCol.SubTotal.ToString(), sivd.CustomerPrice1*sivd.QTY1);
         }
         else
         {
            ParentNode.SetValue(eCol.CustomerPrice.ToString(),
                                string.Format("{0}\n@{1} Less: {2}",
                                                clsUtil.DiscountAmt(sivd.CustomerPrice1, sivd.CustomerDiscount).ToString(
                                                "#,##0.00"), sivd.CustomerPrice1.ToString("#,##0.00"),
                                                sivd.CustomerDiscount));
            ParentNode.SetValue(eCol.SubTotal.ToString(),
                                clsUtil.DiscountAmt(sivd.CustomerPrice1, sivd.CustomerDiscount)*sivd.QTY1);
         }
         treeItems.SetFocusedNode(ParentNode);
         treeItems.EndUnboundLoad();

         txtTotal.Text = ComputeTotal().ToString(FMT_AMOUNT);
      }

      private double ComputeTotal()
      {
         double Total = 0;
         foreach (TreeListNode node in treeItems.Nodes)
         {
            Total += clsUtil.ParseDouble(node.GetValue(eCol.SubTotal.ToString()).ToString());
         }
         return Total;
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         double dblTemp = 0;
         if (ValidateInput())
         {
            double CashPayment = clsUtil.CheckValue(txtCashPayment);

            m_SalesInvoice.Customer = (Contacts) cboCustomer.SelectedItem;
            m_SalesInvoice.AmountDue = clsUtil.CheckValue(txtTotal);
            m_SalesInvoice.BadDebt = false;
            m_SalesInvoice.PaymentCash = CashPayment;
            m_SalesInvoice.PaymentPDC = 0;
            m_SalesInvoice.PaymentForDeposit = 0;
            m_SalesInvoice.CounterID = 0;
            m_SalesInvoice.Deleted = false;
            m_SalesInvoice.EnteredBy = clsUtil.GetLoggedInUser();
            m_SalesInvoice.InvoiceDate = dtDate.DateTime;
            m_SalesInvoice.InvoiceType = (int) m_InvoiceType;
            m_SalesInvoice.Notes = txtNotes.Text;
            m_SalesInvoice.PaymentType = (int) SalesInvoice.GetPaymentType(cboPaymentType.Text);
            m_SalesInvoice.PO_Number = txtPONo.Text;
            m_SalesInvoice.Printed = false;
            m_SalesInvoice.ReceiptNumber = txtReceiptNo.Text;
            m_SalesInvoice.Terms = clsUtil.ParseInt32(cboTerms.Text);
            m_SalesInvoice.Withheld = chkWithHeld.Checked;
            //calculate withholding amount
            if (m_SalesInvoice.Withheld)
               m_SalesInvoice.WithholdingAmount = clsUtil.CalculateWithholdingAmount(m_SalesInvoice.AmountDue);
            else
               m_SalesInvoice.WithholdingAmount = 0;


            //payments
            m_SalesInvoice.paymentdetails.Clear();
            if (CashPayment > 0)
            {
               Payments payment = new Payments();
               payment.Customer = m_SalesInvoice.Customer;
               payment.Amount = CashPayment;
               payment.AmountApplied = CashPayment;
               payment.AmountUsed = CashPayment;
               payment.PaymentDate = m_SalesInvoice.InvoiceDate;
               payment.PaymentType = (Int32) Payments.ePaymentType.Cash;
               payment.user = clsUtil.GetLoggedInUser();

               PaymentsDetail detail = new PaymentsDetail();
               detail.Amount = CashPayment;
               payment.details.Add(detail);

               m_SalesInvoice.paymentdetails.Add(payment);
            }

            //PDC payments
            double PDC_Payment = 0;
            if (m_lstPDC.Count > 0)
            {
               foreach (PaymentsPDC pdc in m_lstPDC)
               {
                  Payments payment = new Payments();
                  payment.Customer = m_SalesInvoice.Customer;
                  payment.Amount = pdc.Amount;
                  payment.AmountApplied = pdc.Amount;
                  payment.AmountUsed = pdc.Amount;
                  payment.PaymentDate = m_SalesInvoice.InvoiceDate;
                  payment.PaymentType = (Int32) Payments.ePaymentType.PDC;
                  payment.PDCdetail = pdc;
                  payment.user = clsUtil.GetLoggedInUser();

                  PaymentsDetail detail = new PaymentsDetail();
                  detail.Amount = pdc.Amount;
                  payment.details.Add(detail);

                  m_SalesInvoice.paymentdetails.Add(payment);

                  PDC_Payment += pdc.Amount;
               }
            }
            m_SalesInvoice.PaymentForDeposit = PDC_Payment;

            //set invoice PaymentStatus
            if ((CashPayment + PDC_Payment) >= m_SalesInvoice.AmountDue)
            {
               if (PDC_Payment > 0)
                  m_SalesInvoice.PaymentStatus = (Int32) SalesInvoice.ePaymentStatus.ForDeposit;
               else
                  m_SalesInvoice.PaymentStatus = (Int32) SalesInvoice.ePaymentStatus.Paid;
            }
            else if ((CashPayment + PDC_Payment) > 0)
               m_SalesInvoice.PaymentStatus = (Int32) SalesInvoice.ePaymentStatus.Partial;
            else
               m_SalesInvoice.PaymentStatus = (Int32) SalesInvoice.ePaymentStatus.Unpaid;

            //compute agent commission
            AgentCommission commission = null;
            if (m_SalesInvoice.Customer.Agent != null)
            {
                bool HasFab = false, HasTrade = false;
                commission = new AgentCommission();
                commission.Agent = m_SalesInvoice.Customer.Agent;
                commission.SalesTotal = m_SalesInvoice.AmountDue;

                IList<AgentQuota> lstAgentQuota = AgentQuotaDao.getAllRecordsByAgent(commission.Agent.ID);
                IList<Int32> lstItemsExempted = AgentQuotaDao.getAllExemptedItemsByAgent(commission.Agent.ID);
                IList<string> lstItem = new List<String>();

                foreach (AgentQuota q in lstAgentQuota)
                {
                    foreach (AgentQuotaItemDetails iqd in q.ItemDetails)
                    {
                        if (iqd.ItemName == AgentQuotaItemDetails.STR_FAB)
                            HasFab = true;
                        else if (iqd.ItemName == AgentQuotaItemDetails.STR_TRADE)
                            HasTrade = true;
                        else
                        {
                            lstItem.Add(clsUtil.GenerateFilterCondition(iqd.ItemName));
                        }
                    }
                }
                IList<Int32> lstItemsHandled = AgentQuotaDao.getAllHandledItemsByAgent(lstItem);

                //check each item if it is handled by agent
                foreach (SalesInvoiceDetails sivd in m_SalesInvoice.details)
                {
                    double ItemSale = 0;
                    //using price1
                    dblTemp = clsUtil.DiscountAmt(sivd.AgentPrice1, sivd.AgentDiscount);
                    dblTemp = dblTemp * sivd.QTY1;
                    ItemSale = dblTemp;

                    //Normal/Trade/Fab items
                    if (sivd.item != null)
                    {
                        if (IsItemHandled(sivd.item.ID, lstItemsHandled, lstItemsExempted))
                        {
                            commission.SalesItem += ItemSale;

                            //add itemdetails
                            AgentQuotaItemDetails itemDetail = GetMatchingAgentQuotaItem(lstAgentQuota, sivd.item.Name);
                            AgentCommissionItemDetails detail = new AgentCommissionItemDetails();

                            detail.AmountSales = ItemSale;
                            detail.ItemDetails = itemDetail;
                            commission.ItemDetails.Add(detail);
                        }
                        else
                            commission.SalesMiscItems += ItemSale;
                    }
                    else
                    {
                        commission.SalesMiscItems += ItemSale;
                    }
                }
            }

            //compute customer commission
            double CustomerCommission = 0;
            foreach (SalesInvoiceDetails sivd in m_SalesInvoice.details)
            {
                //using price1
                dblTemp = clsUtil.DiscountAmt(sivd.CustomerPrice1, sivd.CustomerDiscount) -
                            clsUtil.DiscountAmt(sivd.AgentPrice1, sivd.AgentDiscount);
                dblTemp = dblTemp * sivd.QTY1;
                CustomerCommission += dblTemp;
            }

            try
            {
               InvoiceDao.Save(m_SalesInvoice, commission, CustomerCommission,m_LoanedItem);
               clsUtil.ShowMessage(string.Format("Salesinvoice '{0}' saved.", m_SalesInvoice.ID.ToString(clsUtil.FMT_ID)), "Save Invoice",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);

               //ctlViewSalesInvoice ctl = new ctlViewSalesInvoice();
               //clsUtil.getMainForm().LoadCtl(ctl, true, "Sales Invoice Viewer", "", false);

               btnClose.PerformClick();
            }
            catch (Exception ex)
            {
               if (ex.InnerException != null)
                  clsUtil.ShowMessageError(
                     string.Format("Error:\n{0}\n[Inner Exception]\n{1}", ex.Message, ex.InnerException.Message),
                     "Save Invoice");
               else
                  clsUtil.ShowMessageError(string.Format("Error:\n{0}", ex.Message), "Save Invoice");
            }
         }
      }

      private bool IsItemHandled(Int32 ItemID, IList<Int32> itemsHandled, IList<Int32> itemsExempted)
      {
         foreach (Int32 id in itemsHandled)
         {
            if (ItemID == id)
            {
               //item is handled by agent
               foreach (Int32 id_e in itemsExempted)
               {
                  if (ItemID == id_e)
                  {
                     //item is exempted
                     return false;
                  }
               }
               return true;
            }
         }
         return false;
      }

      private AgentQuotaItemDetails GetMatchingAgentQuotaItem(IList<AgentQuota> lstQuota, string ItemName)
      {
         foreach (AgentQuota quota in lstQuota)
         {
            foreach (AgentQuotaItemDetails detail in quota.ItemDetails)
            {
               if (detail.ItemName != AgentQuotaItemDetails.STR_TRADE &&
                   detail.ItemName != AgentQuotaItemDetails.STR_FAB)
               {
                  if (Regex.IsMatch(ItemName, clsUtil.GenerateRegexCondition(detail.ItemName)))
                  {
                     return detail;
                  }
               }
            }
         }
         return null;
      }

      private bool ValidateInput()
      {
         const string TITLE = "Save Invoice";

         double Total = clsUtil.ParseDouble(txtTotal.Text);
         double CashPayment = clsUtil.CheckValue(txtCashPayment);
         double PDCPayment = 0;

         foreach (PaymentsPDC pdc in m_lstPDC)
         {
            PDCPayment += pdc.Amount;
         }

         if (m_SalesInvoice == null)
         {
             clsUtil.ShowMessageExclamation("Transaction must have at least 1 item!", TITLE);
             return false;
         }

         Contacts customer = (Contacts) cboCustomer.SelectedItem;
         if (customer == null)
         {
            clsUtil.ShowMessageExclamation("Please select customer first!", TITLE);
            cboCustomer.Focus();
            return false;
         }

         if (m_SalesInvoice.details.Count == 0)
         {
            clsUtil.ShowMessageExclamation("Transaction must have at least 1 item!", TITLE);
            return false;
         }

         if (cboPaymentType.SelectedIndex == -1)
         {
            clsUtil.ShowMessageExclamation("Invalid payment type selected!", TITLE);
            cboPaymentType.Focus();
            return false;
         }

         //check cash payment
         if (m_InvoiceType == SalesInvoice.eInvoiceType.Cash)
         {
            if (CashPayment < Total)
            {
               clsUtil.ShowMessageExclamation("Cash payment is not enough!", "Save Invoice");
               txtCashPayment.Text = Total.ToString(FMT_AMOUNT);
               txtCashPayment.SelectAll();
               txtCashPayment.Focus();
               return false;
            }
         }
         else
         {
            //check credit limit
            double CreditAllowed = customer.CreditLimit - customer.CreditUsed;
            double ExcessAmount = Total - CashPayment - CreditAllowed;
            Users loggedUser =  clsUtil.GetLoggedInUser();
            if (ExcessAmount > 0)
            {
               if (ExcessAmount > m_CreditExtensionAllowed)
               {
                   string creditmsg = "";
                   if (CreditAllowed > 0)
                   {
                       creditmsg = string.Format("Credit limit reached. Customer is only allowed {0} for this transaction.",
                            CreditAllowed.ToString(FMT_AMOUNT));
                   }
                   else
                   {
                       double excessCreditAmt = Math.Abs(CreditAllowed);
                       creditmsg = string.Format("Credit limit reached. Customer has already {0} excess in credit amount.",
                            excessCreditAmt.ToString(FMT_AMOUNT));
                   }

                   if (loggedUser.UserType == Users.eUserType.Admin)
                   {
                       creditmsg += " Continue?";
                       if (clsUtil.ShowMessageYesNo(creditmsg, "Save Invoice") == DialogResult.Yes)
                       {
                           m_CreditExtensionAllowed = ExcessAmount;
                       }
                       else
                       {
                           return false;
                       }
                   }
                   else 
                   {
                       creditmsg += " Request credit extension?";
                       if (clsUtil.ShowMessageYesNo(creditmsg, "Save Invoice") == DialogResult.Yes)
                       {
                           //post new approval request
                           string msg = string.Format("Customer Name: {0}{4}{4}Credit Limit: {1}{4}Credit Used: {2}{4}Credit Excess: {3}",
                                                      customer.ToString(), customer.CreditLimit.ToString(FMT_AMOUNT),
                                                      customer.CreditUsed.ToString(FMT_AMOUNT), ExcessAmount.ToString(FMT_AMOUNT), Environment.NewLine);

                           if (!clsUtil.ProcessApprovalRequest(msg, RequestApproval.eRequestType.CreditExtension))
                           {
                               return false;
                           }

                           m_CreditExtensionAllowed = ExcessAmount;
                       }
                       else
                       {
                           return false;
                       }
                   }
               }
            }
         }

         //check item onhand qty changes

         //check terms
         Int32 terms = clsUtil.ParseInt32(cboTerms.Text);

         if (m_InvoiceType == SalesInvoice.eInvoiceType.Accounts ||
             m_InvoiceType == SalesInvoice.eInvoiceType.DeliveryReceipt)
         {
            if (terms == 0)
            {
               clsUtil.ShowMessageExclamation("Terms selected is invalid!", TITLE);
               cboTerms.Focus();
               return false;
            }

            if (SalesInvoice.GetPaymentType(cboPaymentType.Text) == (Int32) SalesInvoice.ePaymentType.Terms)
            {
               //Terms
               if (customer.Terms == 0)
               {
                  clsUtil.ShowMessageExclamation("Customer is not allowed for this kind of transaction!\nPlease select another transaction type.",
                     TITLE);
                  return false;
               }
               else
               {
                  if (terms > customer.Terms)
                  {
                     if (m_TermsDaysApproved == 0)
                     {
                        //request for approval
                        if (
                           clsUtil.ShowMessageYesNo(
                              "Terms selected is beyond allowed terms for customer!\nRequest terms extension?", TITLE) ==
                           DialogResult.Yes)
                        {
                           //post new approval request
                           //RequestApproval ra = new RequestApproval();
                           //clsUtil.InitRequestApproval(ra, RequestApproval.eRequestType.TermsExtension);
                           //string msg = string.Format("Customer Name: {0}{3}Terms: {1}{3}Requested Terms: {2}",
                           //                           customer.ToString(), customer.Terms, terms,Environment.NewLine);
                           //if(!clsUtil.ProcessApprovalRequest(msg, RequestApproval.eRequestType.TermsExtension))
                           //{
                           //   return false;
                           //}
                           //else
                           //{
                              m_TermsDaysApproved = terms;
                           //}
                        }
                        else
                        {
                           return false;
                        }
                     }
                     else
                     {
                        if (terms > m_TermsDaysApproved)
                        {
                           clsUtil.ShowMessageExclamation(string.Format("Invalid terms! Approved terms is only '{0}' days", m_TermsDaysApproved),
                              "Save Invoice");
                           return false;
                        }
                     }
                  }
               }
            }
            else
            {
               //PDC or Multi PDC
               //if (m_lstPDC.Count == 0)
               //{
               //   //clsUtil.ShowMessageExclamation("Please add at least 1 PDC Payment!",TITLE);
               //   //return false;
               //}

               if (terms > customer.Terms_PDC)
               {
                  if (m_TermsPDCDaysApproved == 0)
                  {
                     if (clsUtil.getMainForm().g_LoggedInUser.UserType != Users.eUserType.Admin)
                     {
                        //request for approval
                        if (
                           clsUtil.ShowMessageYesNo("Terms selected is beyond allowed terms for customer!\nRequest terms extension?", TITLE) ==
                           DialogResult.Yes)
                        {
                           //post new approval request
                           //string msg = string.Format("Customer Name: {0}{3}Terms: {1}{3}Requested Terms: {2}",
                           //                           customer.ToString(), customer.Terms_PDC, terms,Environment.NewLine);
                           //if(!clsUtil.ProcessApprovalRequest(msg,RequestApproval.eRequestType.TermsExtension))
                           //{
                           //   return false;
                           //}
                           //else
                           //{
                              m_TermsPDCDaysApproved = terms;
                           //}
                        }
                        else
                        {
                           return false;
                        }
                     }
                  }
                  else
                  {
                     if (terms > m_TermsPDCDaysApproved)
                     {
                        clsUtil.ShowMessageExclamation(string.Format("Invalid terms! Approved terms is only '{0}' days", m_TermsPDCDaysApproved),
                           "Save Invoice");
                        return false;
                     }
                  }
               }
            }
         }

         //validate all item prices
         List<String> lstItems = new List<string>();
         double PriceAgent, PriceItem;

         foreach (TreeListNode node in treeItems.Nodes)
         {
            SalesInvoiceDetails sivd = (SalesInvoiceDetails) node.GetValue(eCol.ItemObject.ToString());
            node.SetValue(eCol.LowPrice.ToString(), 0);

            //for Normal/Fab/Trade items
            foreach (SalesInvoiceDetails_StockIn sivd_si in sivd.stockindetails)
            {
                StockInDetails sid = sivd_si.stockindetails;
                if (sivd.QTY1 == 0)
                {
                    //using price2
                    PriceAgent = clsUtil.DiscountAmt(sivd.AgentPrice2, sivd.AgentDiscount);
                    //PriceAgent = 0;

                    if (sid.SellingPrice2 == 0)
                    PriceItem = clsUtil.DiscountAmt(sid.Price2, sid.SellingDiscount2);
                    else
                    PriceItem = sid.SellingPrice2;

                    if (PriceAgent < PriceItem)
                    {
                    //agent price is below selling price
                    string temp = string.Format("{0}:\t{1}\t{2}", sivd.item.Name, PriceItem.ToString("#,##0.00"),
                                                PriceAgent.ToString("#,##0.00"));
                    lstItems.Add(temp);

                    //set node color to red
                    node.SetValue(eCol.LowPrice.ToString(), 1);
                    }
                }
                else
                {
                    //using price1
                    PriceAgent = clsUtil.DiscountAmt(sivd.AgentPrice1, sivd.AgentDiscount);
                    //PriceAgent = 0;
                    if (sid.SellingPrice1 == 0)
                    PriceItem = clsUtil.DiscountAmt(sid.Price1, sid.SellingDiscount1);
                    else
                    PriceItem = sid.SellingPrice1;

                    if (PriceAgent < PriceItem)
                    {
                    //agent price is below selling price
                    string temp = string.Format("{0}:\t{1}\t{2}", sivd.item.Name, PriceItem.ToString("#,##0.00"),
                                                PriceAgent.ToString("#,##0.00"));
                    lstItems.Add(temp);

                    //set node color to red
                    node.SetValue(eCol.LowPrice.ToString(), 1);
                    }
                }
            }
         }

         if (lstItems.Count > 0 && !m_bLowPriceApproved)
         {
            if (clsUtil.getMainForm().g_LoggedInUser.UserType != Users.eUserType.Admin)
            {
               if (clsUtil.ShowMessageYesNo("Some items have prices lower than selling price. Request approval?",
                                         "Save Invoice") == DialogResult.Yes)
               {
                  //some item have lower agent price, request approval
                  string Msg = string.Format("Customer Name: {0}{1}{1}[Items for approval]", customer.ToString(),Environment.NewLine);
                  foreach (string sItem in lstItems)
                  {
                     Msg += string.Format("{0}{1}",Environment.NewLine, sItem);
                  }
                  //if(!clsUtil.ProcessApprovalRequest(Msg,RequestApproval.eRequestType.PriceApproval))
                  //{
                  //   return false;
                  //}
                  //else
                  //{
                     m_bLowPriceApproved = true;
                  //}
               }
               else
               {
                  return false;
               }
            }
            else
            {
               if (clsUtil.ShowMessageYesNo("Some items have prices lower than selling price. Review items?",
                                         "Save Invoice") == DialogResult.Yes)
               {
                  return false;
               }
            }
         }
#region PO block
         //check if items needs PO
         //bool b_hasItemForPO = false;
         //IList<PurchaseOrder> POList = new List<PurchaseOrder>();

         //foreach (TreeListNode node in treeItems.Nodes)
         //{
         //    SalesInvoiceDetails sivd2 = (SalesInvoiceDetails)node.GetValue(eCol.ItemObject.ToString());

         //    if (sivd2.b_PO)
         //    {
                 
         //        PurchaseOrderDetails PO_details = new PurchaseOrderDetails();
         //        PurchaseOrder PO = checkPObyWarehouse(POList, sivd2);
         //        if (PO == null)
         //        {
         //            PO = new PurchaseOrder();
         //            PO.TransactionDate = DateTime.Now;
         //            PO.Status = 2;
         //            PO.user = clsUtil.GetLoggedInUser();
         //            PO.GracePeriod = 0;
         //            PO.Notes = "";
         //            PO.WarehouseID = sivd2.whPO.ID;
         //            PO.AmountDue = sivd2.QTY1 * sivd2.CustomerPrice1;
         //            PO.wh_id = whDao.GetWarehouseCode();

         //            //po details for non created PO
         //            PO.details = new List<PurchaseOrderDetails>();
         //            PO_details.ItemIndex = 1;
         //        }
         //        else
         //        {
         //            POList.Remove(PO);
         //            PO_details.ItemIndex = PO.mItemIndex;
         //        }


         //        PO_details.item = sivd2.item;
         //        PO_details.QTY1 = sivd2.QTY1;
         //        PO_details.QTY2 = sivd2.QTY2;
         //        PO_details.SellingPrice1 = sivd2.CustomerPrice1;
         //        PO_details.SellingPrice2 = sivd2.CustomerPrice2;
         //        PO_details.Discount = sivd2.CustomerDiscount;
                 

         //        PO.details.Add(PO_details);
         //        POList.Add(PO);

                 
         //        b_hasItemForPO = true;
         //    }

         //}

         //if (b_hasItemForPO)
         //{
         //    if (clsUtil.ShowMessageYesNo("PO will be issued for some items. Continue?", "Save Invoice") == DialogResult.No)
         //    {
         //        return false;
         //    }
         //    else 
         //    {
         //        lstPO = POList;
         //    }
         //}
#endregion
         return true;
      }

      //PurchaseOrder checkPObyWarehouse(IList<PurchaseOrder> PO_list, SalesInvoiceDetails salesinvoice_details)
      //{
      //    PurchaseOrder PO = null;
      //    if (PO_list.Count > 0)
      //    {
      //        foreach (PurchaseOrder xpo in PO_list)
      //        {
      //            if (xpo.WarehouseID == salesinvoice_details.whPO.ID)
      //            {
      //                PO = xpo;
      //                PO.mItemIndex = PO.details.Count + 1;
      //                break;
      //            }
      //        }
      //    }

      //    return PO;
      //}

      private void btnRemoveItem_Click(object sender, EventArgs e)
      {
         TreeListNode node = treeItems.FocusedNode;
         int wbID = 0;
         if (node != null)
         {
            if (node.ParentNode != null)
               node = node.ParentNode;
            SalesInvoiceDetails sivd = (SalesInvoiceDetails) node.GetValue(eCol.ItemObject.ToString());
            if(sivd.item!=null && sivd.item.IsWire && sivd.QTY1==0)
            {
               WireBreakdown wb = (WireBreakdown) sivd.stockindetails[0].wirebreakdown;
               wbID = wb.BreakDownID;
               //search all items linked to this wb
               foreach (TreeListNode node2 in treeItems.Nodes)
               {
                  if(node.Id != node2.Id)
                  {
                     SalesInvoiceDetails sivd2 = (SalesInvoiceDetails)node2.GetValue(eCol.ItemObject.ToString());
                     if (sivd2.item != null && sivd2.item.IsWire && sivd2.QTY1 == 0)
                     {
                        WireBreakdown wb2 = (WireBreakdown)sivd2.stockindetails[0].wirebreakdown;
                        if(wb2.BreakDownID_Source==wbID)
                        {
                           if(clsUtil.ShowMessageYesNo("This item is linked to other items in the list.\nRemoving this item will also remove linked items.\n\nContinue?","Remove Item") == DialogResult.No)
                           {
                              return;
                           }
                        }
                     }
                  }
               }
            }

            //remove linked items
            if(wbID!=0 && treeItems.Nodes.Count>1)
            {
               bool bDone = false;
               while (!bDone)
               {
                  bool bFoundItem = false;
                  foreach (TreeListNode node2 in treeItems.Nodes)
                  {
                     if (node.Id != node2.Id)
                     {
                        SalesInvoiceDetails sivd2 = (SalesInvoiceDetails)node2.GetValue(eCol.ItemObject.ToString());
                        if (sivd2.item != null && sivd2.item.IsWire && sivd2.QTY1 == 0)
                        {
                           WireBreakdown wb2 = (WireBreakdown)sivd2.stockindetails[0].wirebreakdown;
                           if (wb2.BreakDownID_Source == wbID)
                           {
                              m_SalesInvoice.details.Remove(sivd2);
                              treeItems.Nodes.Remove(node2);
                              bFoundItem = true;
                              break;
                           }
                        }
                     }
                  }
                  if (bFoundItem)
                     bDone = true;
               }
            }

            //remove original sivd
            m_SalesInvoice.details.Remove(sivd);
            treeItems.Nodes.Remove(node);
         }
      }

      private void grdvPDC_CustomUnboundColumnData(object sender,
                                                   DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
      {
         PaymentsPDC pdc = (PaymentsPDC) grdvPDC.GetRow(e.RowHandle);

         if (e.IsGetData && e.Column.FieldName == "CheckStatus")
         {
            e.Value = PaymentsPDC.GetStatus((int) pdc.Status);
         }

      }

      private void btnAddPDC_Click(object sender, EventArgs e)
      {
         Contacts customer = (Contacts) cboCustomer.SelectedValue;
         if (customer == null)
         {
            clsUtil.ShowMessageExclamation("Please select customer first!", "PDC Payment");
            cboCustomer.Focus();
            return;
         }

         frmGenericPopup frm = new frmGenericPopup();
         ctlPaymentPDC ctl = new ctlPaymentPDC();

         ctl.customer = customer;
         frm.Text = "PDC Payment";
         frm.ShowCtl(ctl);
         if (!ctl.Canceled)
         {
            //add check
            m_lstPDC.Add(ctl.paymentcheck);
            grdPDC.RefreshDataSource();
         }
      }

      private void btnRemovePDC_Click(object sender, EventArgs e)
      {
         if (grdvPDC.FocusedRowHandle >= 0)
         {
            PaymentsPDC pdc = (PaymentsPDC) grdvPDC.GetRow(grdvPDC.FocusedRowHandle);
            if (pdc != null)
            {
               m_lstPDC.Remove(pdc);
               grdPDC.RefreshDataSource();
            }
         }
      }

      private void treeItems_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
      {
         Int32 iLowPrice = clsUtil.ParseInt32(e.Node.GetValue(eCol.LowPrice.ToString()).ToString());
         if (iLowPrice == 1)
         {
            e.Appearance.ForeColor = System.Drawing.Color.Red;
         }

         ((TreeList) sender).Painter.DefaultPaintHelper.DrawNodeCell(e);
         e.Handled = true;
      }

      private void treeItems_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
      {
      }

      private void treeItems_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         if (bViewOnly)
            return;

         TreeListNode node = treeItems.FocusedNode;
         if (node != null)
         {
            TreeListNode ParentNode = null;
            if (node.ParentNode != null)
               ParentNode = node.ParentNode;
            else
               ParentNode = node;

            SalesInvoiceDetails sivd = (SalesInvoiceDetails) node.GetValue(eCol.ItemObject.ToString());
            ctlSalesInvoiceChangePrice ctl = new ctlSalesInvoiceChangePrice();
            frmGenericPopup frm = new frmGenericPopup();

            ctl.m_InvoiceDetail = sivd;
            frm.Text = "Change Item Price";
            frm.ShowCtl(ctl);
            if (!ctl.Canceled)
            {
               if (ctl.ApplyToAll)
               {
                  foreach (TreeListNode node2 in treeItems.Nodes)
                  {
                     SalesInvoiceDetails sivd2 = (SalesInvoiceDetails) node2.GetValue(eCol.ItemObject.ToString());
                     sivd2.AgentDiscount = ctl.m_InvoiceDetail.AgentDiscount;
                     sivd2.CustomerDiscount = ctl.m_InvoiceDetail.CustomerDiscount;
                     SetNodeItemPriceDisplay(node2, sivd2);
                  }
               }
               else
               {
                  ParentNode.SetValue(eCol.ItemObject.ToString(), ctl.m_InvoiceDetail);
                  SetNodeItemPriceDisplay(ParentNode, ctl.m_InvoiceDetail);
               }
               txtTotal.Text = ComputeTotal().ToString(FMT_AMOUNT);
            }
         }
      }

      private void SetNodeItemPriceDisplay(TreeListNode node, SalesInvoiceDetails sivd)
      {

         if (sivd.CustomerDiscount == "")
         {
            if (sivd.QTY1 != 0)
            {
               node.SetValue(eCol.CustomerPrice.ToString(), sivd.CustomerPrice1.ToString("#,##0.00"));
               node.SetValue(eCol.SubTotal.ToString(), sivd.CustomerPrice1*sivd.QTY1);
            }
            else
            {
               node.SetValue(eCol.CustomerPrice.ToString(), sivd.CustomerPrice2.ToString("#,##0.00"));
               node.SetValue(eCol.SubTotal.ToString(), sivd.CustomerPrice2*sivd.QTY2);
            }
         }
         else
         {
            if (sivd.QTY1 != 0)
            {
               node.SetValue(eCol.CustomerPrice.ToString(),
                             string.Format("{0}\n@{1} Less: {2}",
                                           clsUtil.DiscountAmt(sivd.CustomerPrice1, sivd.CustomerDiscount).ToString(
                                              "#,##0.00"), sivd.CustomerPrice1.ToString("#,##0.00"),
                                           sivd.CustomerDiscount));
               node.SetValue(eCol.SubTotal.ToString(),
                             clsUtil.DiscountAmt(sivd.CustomerPrice1, sivd.CustomerDiscount)*sivd.QTY1);
            }
            else
            {
               node.SetValue(eCol.CustomerPrice.ToString(),
                             string.Format("{0}\n@{1} Less: {2}",
                                           clsUtil.DiscountAmt(sivd.CustomerPrice2, sivd.CustomerDiscount).ToString(
                                              "#,##0.00"), sivd.CustomerPrice2.ToString("#,##0.00"),
                                           sivd.CustomerDiscount));
               node.SetValue(eCol.SubTotal.ToString(),
                             clsUtil.DiscountAmt(sivd.CustomerPrice2, sivd.CustomerDiscount)*sivd.QTY2);
            }
         }
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         clsUtil.getMainForm().CloseCurrentControl();
         //if (bViewOnly)
         //   clsUtil.getMainForm().CloseCurrentControl();
         //else
         //{
         //   ctlViewSalesInvoice ctl = new ctlViewSalesInvoice();
         //   clsUtil.getMainForm().LoadCtl(ctl, true, "Sales Invoice Viewer", "", true, DockStyle.Left);
         //}
      }

      private void btnPrint_Click(object sender, EventArgs e)
      {
         //rptSalesInvoice rpt = new rptSalesInvoice();
         //rpt.DataSource = m_SalesInvoice.details;
         //rpt.ShowPreviewDialog();
      }

      private void HideUnusedItems()
      {
          chkWithHeld.Visible = false;
      }
   }
}