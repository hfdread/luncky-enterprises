#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using DexterHardware_v2.Classes;
using DexterHardware_v2.Forms;
using DexterHardware_v2.UI_Controls.Viewers;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace DexterHardware_v2.UI_Controls.Transactions
{
   public partial class ctlQuotation : UserControl
   {
      private ContactsDao CustomerDao = new ContactsDao();
      private QuotationDao QuotationDao = new QuotationDao();
      private QuotationDetailsDao QuotationDetailsDao = new QuotationDetailsDao();

      public Quotation m_Quotation { get; set; }
      private bool bViewOnly = false;

      private enum eCol
      {
         QTY,
         ItemName,
         AgentPrice,
         CustomerPrice,
         SubTotal,
         ItemObject,
         LowPrice
      }

      public ctlQuotation()
      {
         InitializeComponent();
      }

      private void ctlQuotation_Load(object sender, EventArgs e)
      {
         dtDate.DateTime = DateTime.Now;

         if (m_Quotation != null)
         {
            //view only
            cboCustomer.Enabled = false;
            dtDate.Enabled = false;
            txtNotes.Enabled = false;
            treeItems.OptionsBehavior.Editable = false;
            btnSave.Enabled = false;
            btnAddItem.Enabled = false;
            btnRemoveItem.Enabled = false;
            LoadQuotation();
            bViewOnly = true;
         }
         else
         {
            LoadCustomers();
            cboCustomer.Focus();
         }
      }

      private void LoadQuotation()
      {
         cboCustomer.Text = m_Quotation.Customer.ToString();
         txtContactNo.Text = m_Quotation.Customer.LandlineNumber;
         txtAddress.Text = m_Quotation.Customer.Address;

         dtDate.DateTime = m_Quotation.QuotationDate;

         IList<QuotationDetails> details = QuotationDetailsDao.GetAllRecordsByField("quotation.ID", m_Quotation.ID);
         foreach (QuotationDetails QD in details)
         {
            AddItem(QD);
            ComputeTotal();
         }
      }

      private void LoadCustomers()
      {
         cboCustomer.DataSource = CustomerDao.getAllCustomers();
         cboCustomer.SelectedIndex = -1;
      }

      private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
      {
         Contacts customer = (Contacts) cboCustomer.SelectedValue;
         if (customer != null)
         {
            txtAddress.Text = customer.Address;
            txtContactNo.Text = customer.LandlineNumber;
         }
         else
         {
            txtContactNo.Text = "";
            txtAddress.Text = "";
         }
      }

      private void btnAddItem_Click(object sender, EventArgs e)
      {
         if (m_Quotation == null)
         {
            m_Quotation = new Quotation();
         }

         ctlSelectItems_Quotation ctl = new ctlSelectItems_Quotation();
         frmGenericPopup frm = new frmGenericPopup();

         ctl.ParentCtl = this;
         frm.Text = "Select Item";
         frm.ShowCtl(ctl);
      }

      public void AddItem(QuotationDetails sivd)
      {
         TreeListNode ParentNode, ChildNode;

         ParentNode = treeItems.AppendNode(null, null);
         ParentNode.SetValue(eCol.ItemObject.ToString(), sivd);
         ParentNode.SetValue(eCol.LowPrice.ToString(), 0);

         m_Quotation.details.Add(sivd);

         treeItems.BeginUnboundLoad();
         if (sivd.item != null)
         {
            ParentNode.SetValue(eCol.ItemName.ToString(),
                                string.Format("{0}\n{1}", sivd.item.Name, sivd.item.Description));
         }
         else if (sivd.fabitem != null)
         {
            //fab description should only be shown in tooltip because description could contain more than 1 line
            ParentNode.SetValue(eCol.ItemName.ToString(), string.Format("{0}", sivd.fabitem.Name));
         }
         else if (sivd.tradeitem != null)
         {
            //fab description should only be shown in tooltip because description could contain more than 1 line
            ParentNode.SetValue(eCol.ItemName.ToString(), string.Format("{0}", sivd.tradeitem.Name));
         }
         else if (sivd.bundleditem != null)
         {
            ParentNode.SetValue(eCol.ItemName.ToString(),
                                string.Format("{0}\n{1}", sivd.bundleditem.Name, sivd.bundleditem.Description));
            foreach (BundledItemDetails bid in sivd.bundleditem.details)
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
               ChildNode.SetValue(eCol.SubTotal.ToString(), (bid.UnitPrice*sivd.QTY1).ToString("#,##0.00"));
            }
         }

         if (sivd.QTY2 != 0)
         {
            if (sivd.QTY1 != 0)
               ParentNode.SetValue(eCol.QTY.ToString(), string.Format("{0}\n@{1} mtrs", sivd.QTY1, sivd.QTY2));
            else
               ParentNode.SetValue(eCol.QTY.ToString(), string.Format("{0} mtrs", sivd.QTY2));
         }
         else
         {
            ParentNode.SetValue(eCol.QTY.ToString(), sivd.QTY1);
         }

         if (sivd.AgentDiscount == "")
         {
            if (sivd.QTY1 != 0)
            {
               ParentNode.SetValue(eCol.AgentPrice.ToString(), sivd.AgentPrice1.ToString("#,##0.00"));
            }
            else
            {
               ParentNode.SetValue(eCol.AgentPrice.ToString(), sivd.AgentPrice2.ToString("#,##0.00"));
            }
         }
         else
         {
            if (sivd.QTY1 != 0)
            {
               ParentNode.SetValue(eCol.AgentPrice.ToString(),
                                   string.Format("{0}\n@{1} Less: {2}",
                                                 cUtil.DiscountAmt(sivd.AgentPrice1, sivd.AgentDiscount).ToString(
                                                    "#,##0.00"), sivd.AgentPrice1.ToString("#,##0.00"),
                                                 sivd.AgentDiscount));
            }
            else
            {
               ParentNode.SetValue(eCol.AgentPrice.ToString(),
                                   string.Format("{0}\n@{1} Less: {2}",
                                                 cUtil.DiscountAmt(sivd.AgentPrice2, sivd.AgentDiscount).ToString(
                                                    "#,##0.00"), sivd.AgentPrice2.ToString("#,##0.00"),
                                                 sivd.AgentDiscount));
            }
         }

         if (sivd.CustomerDiscount == "")
         {
            if (sivd.QTY1 != 0)
            {
               ParentNode.SetValue(eCol.CustomerPrice.ToString(), sivd.CustomerPrice1.ToString("#,##0.00"));
               ParentNode.SetValue(eCol.SubTotal.ToString(), sivd.CustomerPrice1*sivd.QTY1);
            }
            else
            {
               ParentNode.SetValue(eCol.CustomerPrice.ToString(), sivd.CustomerPrice2.ToString("#,##0.00"));
               ParentNode.SetValue(eCol.SubTotal.ToString(), sivd.CustomerPrice2*sivd.QTY2);
            }
         }
         else
         {
            if (sivd.QTY1 != 0)
            {
               ParentNode.SetValue(eCol.CustomerPrice.ToString(),
                                   string.Format("{0}\n@{1} Less: {2}",
                                                 cUtil.DiscountAmt(sivd.CustomerPrice1, sivd.CustomerDiscount).ToString(
                                                    "#,##0.00"), sivd.CustomerPrice1.ToString("#,##0.00"),
                                                 sivd.CustomerDiscount));
               ParentNode.SetValue(eCol.SubTotal.ToString(),
                                   cUtil.DiscountAmt(sivd.CustomerPrice1, sivd.CustomerDiscount)*sivd.QTY1);
            }
            else
            {
               ParentNode.SetValue(eCol.CustomerPrice.ToString(),
                                   string.Format("{0}\n@{1} Less: {2}",
                                                 cUtil.DiscountAmt(sivd.CustomerPrice2, sivd.CustomerDiscount).ToString(
                                                    "#,##0.00"), sivd.CustomerPrice2.ToString("#,##0.00"),
                                                 sivd.CustomerDiscount));
               ParentNode.SetValue(eCol.SubTotal.ToString(),
                                   cUtil.DiscountAmt(sivd.CustomerPrice2, sivd.CustomerDiscount)*sivd.QTY2);
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

      private void btnRemoveItem_Click(object sender, EventArgs e)
      {
         TreeListNode node = treeItems.FocusedNode;
         if (node != null)
         {
            if (node.ParentNode != null)
               node = node.ParentNode;

            QuotationDetails QD = (QuotationDetails) node.GetValue(eCol.ItemObject.ToString());
            m_Quotation.details.Remove(QD);
            treeItems.Nodes.Remove(node);
         }
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         Contacts customer = (Contacts) cboCustomer.SelectedItem;
         if (customer == null)
         {
            cUtil.ShowMessageExclamation("Please select customer!", "Save Quotation");
            return;
         }

         if (m_Quotation.details.Count == 0)
         {
            cUtil.ShowMessageExclamation("Please add at least a single item to transaction!", "Save Quotation");
            return;
         }

         m_Quotation.Customer = customer;
         m_Quotation.AmountDue = ComputeTotal();
         m_Quotation.EnteredBy = cUtil.GetLoggedInUser();
         m_Quotation.Notes = txtNotes.Text;
         m_Quotation.QuotationDate = dtDate.DateTime;

         try
         {
            QuotationDao.Save(m_Quotation);
            cUtil.ShowMessageInformation(
               string.Format("Quotation [{0}] saved!", m_Quotation.ID.ToString(cUtil.FMT_ID)), "Save Quotation");

            ctlViewQuotations ctl = new ctlViewQuotations();
            cUtil.getMainForm().LoadCtl(ctl, true, "Quotation Viewer", "", true, DockStyle.Left);
         }
         catch (Exception ex)
         {
            cUtil.ShowMessageError(ex.Message);
         }
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         cUtil.getMainForm().CloseCurrentControl();
      }
   }
}