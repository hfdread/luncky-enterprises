#region

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DexterHardware_v2.Classes;
using DexterHardware_v2.Forms;
using DexterHardware_v2.UI_Controls.Accounting;
using DexterHardware_v2.UI_Controls.Utilities;
using DexterHardware_v2.UI_Controls.Viewers;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
#endregion

namespace DexterHardware_v2.UI_Controls.Transactions
{
   public partial class ctlLoanedItems : DevExpress.XtraEditors.XtraUserControl
   {
      private ContactsDao m_CustomerDao = new ContactsDao();
      private LoanedItemsDao m_LoanedItemDao = new LoanedItemsDao();
      private LoanedItemsDetailsDao m_LoanedItemsDetailDao = null;
      public LoanedItems m_LoanedItem { get; set; }
      private bool m_bViewOnly = false;
      private bool m_bIsLoading = true;
      private eOperation m_Operation;

      private enum eOperation
      {
         Invoice,
         Return
      }

      private enum eCol
      {
         Selected,
         QTY,
         ItemName,
         AgentPrice,
         CustomerPrice,
         SubTotal,
         ItemObject,
         LowPrice,
         QTY_Returned,
         QTY_Invoiced,
         QTY_ToReturn
      }

      public ctlLoanedItems()
      {
         InitializeComponent();
      }

      private void ctlLoanedItems_Load(object sender, EventArgs e)
      {
         treeItems.Columns[eCol.CustomerPrice.ToString()].Visible = false;

         //m_LoanedItem = m_LoanedItemDao.GetById(1);
         if(m_LoanedItem!=null)
         {
            m_bViewOnly = true;
            //view previous transaction
            LoadLoanedItem();
            btnSave.Enabled = false;
            btnAddItem.Enabled = false;
            btnRemoveItem.Enabled = false;
            
            if(!m_LoanedItem.Canceled && m_LoanedItem.Status != LoanedItems.eStatus.Returned)
            {
               //enable editing
               colSelect.Visible = true;
               colQTY_Returned.Visible = true;
               colQTY_Invoiced.Visible = true;
               colQTY_ToReturn.Visible = true;
               btnInvoice.Visible = true;
               btnReturn.Visible = true;

               treeItems.OptionsBehavior.Editable = true;
            }
            else
            {
               colSelect.Visible = false;
            }
         }
         else
         {
            colSelect.Visible = false;

            //new transaction
            LoadCustomers();

            cboTerms.Enabled = false;
            dtDate.DateTime = DateTime.Now;
         }
         this.Show();
         cboCustomer.Focus();
      }

      private void LoadLoanedItem()
      {
         txtInvoiceNo.Text = m_LoanedItem.ID.ToString(cUtil.FMT_ID);
         cboCustomer.Text = m_LoanedItem.Customer.ToString();
         txtAddress.Text = m_LoanedItem.Customer.Address;
         txtContactNo.Text = m_LoanedItem.Customer.LandlineNumber;
         dtDate.DateTime = m_LoanedItem.TransactionDate;
         txtNotes.Text = m_LoanedItem.Notes;

         //load details
         IList<LoanedItemsDetails> lst = m_LoanedItemDao.GetDetails(m_LoanedItem.ID);
         foreach (LoanedItemsDetails lid in lst)
         {
            AddItem(lid);
         }

      }

      private void LoadCustomers()
      {
         cboCustomer.DataSource = m_CustomerDao.getAllCustomers();
         cboCustomer.SelectedIndex = -1;
      }

      public void AddItem(LoanedItemsDetails lid)
      {
         TreeListNode ParentNode, ChildNode;

         ParentNode = treeItems.AppendNode(null, null);
         ParentNode.SetValue(eCol.ItemObject.ToString(), lid);
         ParentNode.SetValue(eCol.LowPrice.ToString(), 0);
         ParentNode.SetValue(eCol.Selected.ToString(), false);
         ParentNode.SetValue(eCol.QTY_Returned.ToString(), lid.QTY_Returned);
         ParentNode.SetValue(eCol.QTY_Invoiced.ToString(), lid.QTY_Invoiced);
         ParentNode.SetValue(eCol.QTY_ToReturn.ToString(), lid.QTY_ToReturn);

         m_LoanedItem.details.Add(lid);

         //make customer's price=agent's price
         lid.CustomerDiscount = lid.AgentDiscount;
         lid.CustomerPrice1 = lid.AgentPrice1;lid.CustomerPrice2 = lid.AgentPrice2;
         treeItems.BeginUnboundLoad();
         if (lid.item != null)
         {
            ParentNode.SetValue(eCol.ItemName.ToString(),
                                string.Format("{0}\n{1}", lid.item.Name, lid.item.Description));
         }
         else if (lid.fabitem != null)
         {
            //fab description should only be shown in tooltip because description could contain more than 1 line
            ParentNode.SetValue(eCol.ItemName.ToString(), string.Format("{0}", lid.fabitem.Name));
         }
         else if (lid.tradeitem != null)
         {
            //fab description should only be shown in tooltip because description could contain more than 1 line
            ParentNode.SetValue(eCol.ItemName.ToString(), string.Format("{0}", lid.tradeitem.Name));
         }
         else if (lid.bundleditem != null)
         {
            ParentNode.SetValue(eCol.ItemName.ToString(),
                                string.Format("{0}\n{1}", lid.bundleditem.Name, lid.bundleditem.Description));
            foreach (BundledItemDetails bid in lid.bundleditem.details)
            {
               ChildNode = treeItems.AppendNode(null, ParentNode);
               ChildNode.SetValue(eCol.QTY.ToString(), string.Format("{0} pcs", bid.QTY));
               ChildNode.SetValue(eCol.LowPrice.ToString(), 0);
               ChildNode.SetValue(eCol.ItemObject.ToString(), bid);

               if (bid.item != null)
                  ChildNode.SetValue(eCol.ItemName.ToString(),
                                     string.Format("{0}\n{1}", bid.item.Name, bid.item.Description));
               else if (bid.FabItem != null)
                  ChildNode.SetValue(eCol.ItemName.ToString(),
                                     string.Format("{0}\n{1}", bid.FabItem.Name, bid.FabItem.Description));

               ChildNode.SetValue(eCol.AgentPrice.ToString(), bid.UnitPrice.ToString("#,##0.00"));
               ChildNode.SetValue(eCol.CustomerPrice.ToString(), bid.UnitPrice.ToString("#,##0.00"));
               ChildNode.SetValue(eCol.SubTotal.ToString(), (bid.UnitPrice * lid.QTY1).ToString("#,##0.00"));
            }
         }

         if (lid.QTY2 != 0)
         {
            if (lid.QTY1 != 0)
               ParentNode.SetValue(eCol.QTY.ToString(), string.Format("{0}\n@{1} mtrs", lid.QTY1, lid.QTY2));
            else
               ParentNode.SetValue(eCol.QTY.ToString(), string.Format("{0} mtrs", lid.QTY2));
         }
         else
         {
            ParentNode.SetValue(eCol.QTY.ToString(), lid.QTY1);
         }

         if (lid.AgentDiscount == "")
         {
            if (lid.QTY1 != 0)
            {
               ParentNode.SetValue(eCol.AgentPrice.ToString(), lid.AgentPrice1.ToString("#,##0.00"));
            }
            else
            {
               ParentNode.SetValue(eCol.AgentPrice.ToString(), lid.AgentPrice2.ToString("#,##0.00"));
            }
         }
         else
         {
            if (lid.QTY1 != 0)
            {
               ParentNode.SetValue(eCol.AgentPrice.ToString(),
                                   string.Format("{0}\n@{1} Less: {2}",
                                                 cUtil.DiscountAmt(lid.AgentPrice1, lid.AgentDiscount).ToString(
                                                    "#,##0.00"), lid.AgentPrice1.ToString("#,##0.00"),
                                                 lid.AgentDiscount));
            }
            else
            {
               ParentNode.SetValue(eCol.AgentPrice.ToString(),
                                   string.Format("{0}\n@{1} Less: {2}",
                                                 cUtil.DiscountAmt(lid.AgentPrice2, lid.AgentDiscount).ToString(
                                                    "#,##0.00"), lid.AgentPrice2.ToString("#,##0.00"),
                                                 lid.AgentDiscount));
            }
         }

         if (lid.CustomerDiscount == "")
         {
            if (lid.QTY1 != 0)
            {
               ParentNode.SetValue(eCol.CustomerPrice.ToString(), lid.CustomerPrice1.ToString("#,##0.00"));
               ParentNode.SetValue(eCol.SubTotal.ToString(), lid.CustomerPrice1 * lid.QTY1);
            }
            else
            {
               ParentNode.SetValue(eCol.CustomerPrice.ToString(), lid.CustomerPrice2.ToString("#,##0.00"));
               ParentNode.SetValue(eCol.SubTotal.ToString(), lid.CustomerPrice2 * lid.QTY2);
            }
         }
         else
         {
            if (lid.QTY1 != 0)
            {
               ParentNode.SetValue(eCol.CustomerPrice.ToString(),
                                   string.Format("{0}\n@{1} Less: {2}",
                                                 cUtil.DiscountAmt(lid.CustomerPrice1, lid.CustomerDiscount).ToString(
                                                    "#,##0.00"), lid.CustomerPrice1.ToString("#,##0.00"),
                                                 lid.CustomerDiscount));
               ParentNode.SetValue(eCol.SubTotal.ToString(),
                                   cUtil.DiscountAmt(lid.CustomerPrice1, lid.CustomerDiscount) * lid.QTY1);
            }
            else
            {
               ParentNode.SetValue(eCol.CustomerPrice.ToString(),
                                   string.Format("{0}\n@{1} Less: {2}",
                                                 cUtil.DiscountAmt(lid.CustomerPrice2, lid.CustomerDiscount).ToString(
                                                    "#,##0.00"), lid.CustomerPrice2.ToString("#,##0.00"),
                                                 lid.CustomerDiscount));
               ParentNode.SetValue(eCol.SubTotal.ToString(),
                                   cUtil.DiscountAmt(lid.CustomerPrice2, lid.CustomerDiscount) * lid.QTY2);
            }
         }
         treeItems.SetFocusedNode(ParentNode);
         treeItems.EndUnboundLoad();

         txtTotal.Text = ComputeTotal().ToString(cUtil.FMT_AMOUNT);
      }

      private double ComputeTotal()
      {
         double Total = 0;
         foreach (TreeListNode node in treeItems.Nodes)
         {
            Total += cUtil.ParseDouble(node.GetValue(eCol.SubTotal.ToString()).ToString());
         }
         return Total;
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         double dblTemp = 0;
         if (ValidateInput())
         {
            double CashPayment = cUtil.CheckValue(txtCashPayment);

            m_LoanedItem.Customer = (Contacts)cboCustomer.SelectedValue;
            m_LoanedItem.AmountDue = cUtil.CheckValue(txtTotal);
            m_LoanedItem.Canceled = false;
            m_LoanedItem.EnteredBy = cUtil.GetLoggedInUser();
            m_LoanedItem.TransactionDate = dtDate.DateTime;
            m_LoanedItem.Notes = txtNotes.Text;
            m_LoanedItem.Terms = cUtil.ParseInt32(cboTerms.Text);

            try
            {
               m_LoanedItemDao.Save(m_LoanedItem);
               cUtil.ShowMessage(string.Format("LoanedItem '{0}' saved.", m_LoanedItem.ID), "Save LoanedItem",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);

               btnSave.Enabled = false;
               btnAddItem.Enabled = false;
               btnRemoveItem.Enabled = false;
               treeItems.OptionsBehavior.Editable = false;
               cboCustomer.Enabled = false;
               //ctlviewlo ctl = new ctlViewSalesInvoice();
               //cUtil.getMainForm().LoadCtl(ctl, true, "Sales Invoice Viewer", "", false);
            }
            catch (Exception ex)
            {
               if (ex.InnerException != null)
                  cUtil.ShowMessageError(
                     string.Format("Error:\n{0}\n[Inner Exception]\n{1}", ex.Message, ex.InnerException.Message),
                     "Save LoanedItem");
               else
                  cUtil.ShowMessageError(string.Format("Error:\n{0}", ex.Message), "Save LoanedItems");
            }
         }
      }

      private bool ValidateInput()
      {
         const string Title = "Save LoanedItem";

         if(cboCustomer.SelectedIndex==-1)
         {
            cUtil.ShowMessageExclamation("Please select customer!", Title);
            return false;
         }

         if(m_LoanedItem.details.Count==0)
         {
            cUtil.ShowMessageExclamation("Please add at least one item to the transaction!", Title);
            return false;
         }
         return true;
      }

      private bool ValidateInput2()
      {
         int iSelected = 0;
         int iTotalQTY = 0;
         foreach (TreeListNode node in treeItems.Nodes)
         {
            LoanedItemsDetails lid = (LoanedItemsDetails)node.GetValue(eCol.ItemObject.ToString());
            
            if(Convert.ToBoolean(node.GetValue(eCol.Selected.ToString())))
            {
               lid.Selected = true;

               int qty = Convert.ToInt32(node.GetValue(eCol.QTY_ToReturn.ToString()));
               if(qty==0)
               {
                  lid.Selected = false;
                  node.SetValue(eCol.Selected.ToString(), false);
                  continue;
               }

               if(m_Operation == eOperation.Invoice && qty<0)
               {
                  cUtil.ShowMessageExclamation("Invalid QTY. Please enter a number greater than '0'.", "Invoice Items");
                  return false;
               }

               lid.QTY_ToReturn = qty;
               
               if(lid.QTY1==0)
               {
                  //wire
                  int unreturned = lid.QTY2 - (lid.QTY_Invoiced + lid.QTY_Returned);
                  if (unreturned == 0)
                  {
                     //cannot return more items
                     cUtil.ShowMessageExclamation(string.Format("{0}\n*** Quantity entered must not exceed unreturned quantity!", node.GetValue(eCol.ItemName.ToString())), "");
                     return false;
                  }
                  else
                  {
                     if(lid.QTY2!=lid.QTY_ToReturn)
                     {
                        cUtil.ShowMessageExclamation(string.Format("{0}\n*** Quantity must match for wire items!", node.GetValue(eCol.ItemName.ToString())), "");
                        return false;
                     }
                  }
               }
               else
               {
                  if (lid.QTY1 < (lid.QTY_Invoiced + lid.QTY_Returned + lid.QTY_ToReturn))
                  {
                     cUtil.ShowMessageExclamation(string.Format("{0}\n*** Quantity entered must not exceed unreturned quantity!", node.GetValue(eCol.ItemName.ToString())), "");
                     return false;
                  }
               }

               iSelected++;
               iTotalQTY += lid.QTY_ToReturn;
            }
         }

         if(iTotalQTY==0)
         {
            cUtil.ShowMessageExclamation("No item to return!\nPlease check at least 1 item and set 'QTY' to return.","Return/Invoice Items");
            return false;
         }

         //check if transction is already returned
         LoanedItems li = m_LoanedItemDao.GetById(m_LoanedItem.ID);
         if(li.Status == LoanedItems.eStatus.Returned)
         {
            //cUtil.ShowMessageExclamation("Nothing to return. All items for this transaction are already returned.", "Return Items");
            //return false;
         }

         if(li.Canceled)
         {
            cUtil.ShowMessageExclamation("Invalid Transaction. Transaction already canceled.", "Return Items");
            return false;
         }

         return true;
      }

      private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
      {
         Contacts customer = (Contacts)cboCustomer.SelectedValue;
         if (customer != null)
         {
            txtAddress.Text = customer.Address;
            txtContactNo.Text = customer.LandlineNumber;

            //credit info
            if (grpCreditInfo.Visible)
            {
               lblCreditLimit.Text = customer.CreditLimit.ToString(cUtil.FMT_AMOUNT);
               lblCreditUsed.Text = customer.CreditUsed.ToString(cUtil.FMT_AMOUNT);
               lblCreditAllowed.Text = (customer.CreditLimit - customer.CreditUsed).ToString(cUtil.FMT_AMOUNT);
            }
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

      private void btnAddItem_Click(object sender, EventArgs e)
      {
         if (m_LoanedItem == null)
         {
            m_LoanedItem = new LoanedItems();
         }

         ctlSelectItems_LoanedItem ctl = new ctlSelectItems_LoanedItem();
         frmGenericPopup frm = new frmGenericPopup();

         ctl.ParentCtl = this;
         frm.Text = "Select Item";
         frm.ShowCtl(ctl);
      }

      private void btnRemoveItem_Click(object sender, EventArgs e)
      {
         TreeListNode node = treeItems.FocusedNode;if (node != null)
         {
            if (node.ParentNode != null)
               node = node.ParentNode;

            LoanedItemsDetails lid = (LoanedItemsDetails)node.GetValue(eCol.ItemObject.ToString());
            m_LoanedItem.details.Remove(lid);
            treeItems.Nodes.Remove(node);
         }
      }

      private void btnReturn_Click(object sender, EventArgs e)
      {
         m_Operation = eOperation.Return;
         if(ValidateInput2()){
            if(m_LoanedItemDao.ReturnItems(m_LoanedItem)==0){
               btnClose.PerformClick();
            }
            else
            {
               cUtil.ShowMessageError(m_LoanedItemDao.ErrorMessage, "Return LoanedItems");
            }
         }
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         cUtil.getMainForm().CloseCurrentControl();
      }

      private void btnInvoice_Click(object sender, EventArgs e)
      {
         m_Operation = eOperation.Invoice;
         if (ValidateInput2())
         {
            ctlSalesInvoice ctl = new ctlSalesInvoice();
            ctl.m_LoanedItem = m_LoanedItem;
            ctl.m_InvoiceType = SalesInvoice.eInvoiceType.Accounts;
            cUtil.getMainForm().LoadCtl(ctl,false,"SalesInvoice","New invoice for LoanedItem",true, DockStyle.Left);
         }
      }
   }
}