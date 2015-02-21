#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.Forms;
//using Engeline_LuckyEnt.UI_Controls.Transactions;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
   public partial class ctlViewAgents : UserControl
   {
      private const string FMT_AMOUNT = "#,##0.00";

      private ContactsDao AgentDao = new ContactsDao();
      private AgentQuotaDao AgentQuotaDao = new AgentQuotaDao();
      private AgentQuotaItemDetailsDao ItemDetailsDao = new AgentQuotaItemDetailsDao();
      private AgentQuotaFixSalesDetailsDao FixSalesQuotaDetailsDao = new AgentQuotaFixSalesDetailsDao();
      private AgentCommissionDao CommissionDao = new AgentCommissionDao();

      private Contacts m_Agent = null;
      private IList<AgentQuota> m_lstQuota = null;
      private IList<AgentCommission> m_lstCom = null;
      private IList<AgentCommissionItemDetails> m_lstCommissionItemDetails = null;
      private IList<Contacts> m_lstUnassignedContacts = null;

      private enum eCol
      {
         AgentQuota,
         ItemName,
         LimitValue,
         Percentage,
         ItemObject
      }

      private enum eColFixCom
      {
         Month = 0,
         SalesTotal,
         SalesPerItem,
         SalesMisc
      }

      private enum eColAnnualCom
      {
         Month = 0,
         SalesTotal,
         SalesOffset
      }

      private enum eColItemCom
      {
         Month = 0,
         AgentItem,
         TotalSales,
         Commission,
         ItemObject
      }

      private enum eMonthNames
      {
         Jan = 0,
         Feb,
         Mar,
         Apr,
         May,
         Jun,
         Jul,
         Aug,
         Sep,
         Oct,
         Nov,
         Dec
      }

      public ctlViewAgents()
      {
         InitializeComponent();
      }

      private void btnRefreshAgentList_Click(object sender, EventArgs e)
      {
         grdAgents.DataSource = AgentDao.getAllAgents();
      }

      private void grdvAgents_CustomUnboundColumnData(object sender,
                                                      DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
      {
         Contacts agent = (Contacts) grdvAgents.GetRow(e.RowHandle);
         if (e.IsGetData && e.Column.FieldName == "AgentName")
         {
            e.Value = agent.ToString();
         }
      }

      private void grdvAgents_FocusedRowChanged(object sender,
                                                DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
      {
         ViewSelectedAgent();
      }

      private void ViewSelectedAgent()
      {
         Contacts agent = (Contacts) grdvAgents.GetRow(grdvAgents.FocusedRowHandle);
         if (agent != null)
         {
            m_Agent = agent;

            //load customers
            grdCustomers.DataSource = AgentDao.getAllCustomersByAgent(agent.ID);

            //load quota
            //IList<AgentQuota> lstQuota = AgentQuotaDao.getAllRecordsByAgent(m_Agent.ID);
            m_lstQuota = AgentQuotaDao.GetAllRecordsByField("Agent.ID", m_Agent.ID);
            grdQuota.DataSource = m_lstQuota;

            //load fix sales
            grdFixSales.DataSource = m_lstQuota;

            //get all sales by customer for current year
            Int32 year = DateTime.Now.Year;
            if (cboFixCommissionYear.SelectedIndex >= 0)
               year = Convert.ToInt32(cboFixCommissionYear.Text);

            DateTime dateFrom = Convert.ToDateTime(string.Format("Jan 1, {0} 12:00 AM", year));
            DateTime dateTo = Convert.ToDateTime(string.Format("Dec 31, {0} 11:59:59 PM", year));
            m_lstCom = CommissionDao.getAllRecordsByCriteria(m_Agent.ID, dateFrom, dateTo);

            //show per item
            ShowPerItemDetails(m_lstQuota);

            //show commissions
            GetPerItemCommission();
            GetFixCommisionDetails();
            GetAnnualCommission();
         }
         else
         {
            m_Agent = null;
            grdCustomers.DataSource = null;
            grdQuota.DataSource = null;
            grdFixSales.DataSource = null;

            treeItemCommission.Nodes.Clear();
         }
      }

      private void ShowPerItemDetails(IList<AgentQuota> lst)
      {
         TreeListNode ParentNode, ChildNode;

         treeItems.BeginUnboundLoad();
         treeItems.Nodes.Clear();
         foreach (AgentQuota quota in lst)
         {
            ParentNode = treeItems.AppendNode(null, null);
            ParentNode.SetValue(eCol.ItemObject.ToString(), quota);
            ParentNode.SetValue(eCol.AgentQuota.ToString(), quota.Quota);

            foreach (AgentQuotaItemDetails detail in quota.ItemDetails)
            {
               ChildNode = treeItems.AppendNode(null, ParentNode);
               ChildNode.SetValue(eCol.ItemObject.ToString(), detail);
               ChildNode.SetValue(eCol.ItemName.ToString(), detail.ItemName);
               ChildNode.SetValue(eCol.LimitValue.ToString(), detail.LimitValue);
               ChildNode.SetValue(eCol.Percentage.ToString(), detail.PercentCommission);
            }
         }
         treeItems.EndUnboundLoad();
      }

      private void ctlViewAgents_Load(object sender, EventArgs e)
      {
         //load years
         for (int i = 0; i < 100; i++)
         {
            cboFixCommissionYear.Properties.Items.Add(DateTime.Now.Year - i);
            cboItemCommissionYear.Properties.Items.Add(DateTime.Now.Year - i);
            cboAnnualCom_Year.Properties.Items.Add(DateTime.Now.Year - i);
         }
         cboFixCommissionYear.SelectedIndex = 0;
         cboItemCommissionYear.SelectedIndex = 0;
         cboAnnualCom_Year.SelectedIndex = 0;

         //load all agents
         grdAgents.DataSource = AgentDao.getAllAgents();

         //get all unassigned customers
         m_lstUnassignedContacts = AgentDao.getAllCustomersNoAgent();
         foreach (Contacts c in m_lstUnassignedContacts)
         {
            cboCustomer.Properties.Items.Add(c);
         }
         cboCustomer.SelectedIndex = -1;

         ViewSelectedAgent();
      }

      private void btnCustomerAdd_Click(object sender, EventArgs e)
      {
         Contacts customer = null;

         try
         {
            customer = (Contacts) cboCustomer.SelectedItem;
            if (customer != null)
            {
               if (m_Agent != null)
               {
                  customer.Agent = m_Agent;
                  AgentDao.Save(customer);
                  IList<Contacts> lst = (IList<Contacts>) grdCustomers.DataSource;
                  lst.Add(customer);
                  grdCustomers.RefreshDataSource();

                  cboCustomer.Properties.Items.Remove(customer);
                  cboCustomer.Text = "";
               }
               else
               {
                  clsUtil.ShowMessageExclamation("No agent selected. Please select agent first!", "Add Customer");
                  grdAgents.Focus();
                  return;
               }
            }
         }
         catch
         {
            clsUtil.ShowMessageExclamation("Invalid customer selected!", "Add Customer");
            cboCustomer.Focus();
         }
      }

      private void grdvCustomers_CustomUnboundColumnData(object sender,
                                                         DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
      {
         Contacts customer = (Contacts) grdvCustomers.GetRow(e.RowHandle);
         if (e.IsGetData && e.Column.FieldName == "CustomerName")
         {
            e.Value = customer.ToString();
         }
      }

      private void btnCustomerRemove_Click(object sender, EventArgs e)
      {
         Contacts customer = (Contacts) grdvCustomers.GetRow(grdvCustomers.FocusedRowHandle);
         if (customer != null)
         {
            if (
               clsUtil.ShowMessageYesNo(
                  string.Format("Remove customer '{0}' from agent '{1}'?", customer.ToString(), m_Agent.ToString()),
                  "remove Customer") == DialogResult.Yes)
            {
               customer.Agent = null;
               AgentDao.Save(customer);

               //remove customer from list
               IList<Contacts> lst = (IList<Contacts>) grdCustomers.DataSource;
               lst.Remove(customer);
               grdCustomers.RefreshDataSource();

               //add customer to cbobox
               cboCustomer.Properties.Items.Add(customer);
            }
         }
      }

      private void btnAgentQuotaAdd_Click(object sender, EventArgs e)
      {
         if (m_Agent != null)
         {
            double quota = clsUtil.CheckValue(txtQuotaRange);
            if (quota > 0)
            {
               AgentQuota a = new AgentQuota();
               a.Agent = m_Agent;
               a.Quota = quota;

               //add fix sales details
               a.FixSalesDetails = new AgentQuotaFixSalesDetails();
               a.FixSalesDetails.Quota = a.Quota;
               a.FixSalesDetails.Commission = 0;

               if (m_lstQuota.Count > 0)
               {
                  foreach (AgentQuotaItemDetails aqid in m_lstQuota[0].ItemDetails)
                  {
                     AgentQuotaItemDetails detail = new AgentQuotaItemDetails();
                     detail.ItemName = aqid.ItemName;
                     detail.LimitValue = 0;
                     detail.PercentCommission = 0;
                     foreach (AgentQuotaExemptItem exempt in aqid.ExemptedItems)
                     {
                        AgentQuotaExemptItem _exempt = new AgentQuotaExemptItem();
                        _exempt.ItemID = exempt.ItemID;
                        detail.ExemptedItems.Add(_exempt);
                     }
                     a.ItemDetails.Add(detail);
                  }
               }

               try
               {
                  AgentQuotaDao.Save(a);

                  IList<AgentQuota> lstQuota = (IList<AgentQuota>) grdvQuota.DataSource;
                  lstQuota.Add(a);
                  grdQuota.RefreshDataSource();

                  //load fix sales
                  //IList<AgentCommissionFixSales> lstFixSales = FixSalesDao.GetAllRecordsByField("Agent.ID", m_Agent.ID);
                  grdFixSales.DataSource = lstQuota;

                  ShowPerItemDetails(lstQuota);
               }
               catch (Exception ex)
               {
                  clsUtil.ShowMessageError("Error: " + ex.Message, "Save Quota");
               }
            }
            else
            {
               clsUtil.ShowMessageExclamation("Invalid amount!", "Add Quota");
               txtQuotaRange.Focus();
            }
         }
         else
         {
            clsUtil.ShowMessageExclamation("Invalid agent selected!", "Add Agent Quota");
         }
      }

      private void btnAgentQuotaRemove_Click(object sender, EventArgs e)
      {
         AgentQuota a = (AgentQuota) grdvQuota.GetRow(grdvQuota.FocusedRowHandle);
         if (a != null)
         {
            if (clsUtil.ShowMessageYesNo("Remove selected agent quota?", "Remove Quota") == DialogResult.Yes)
            {
               try
               {
                  AgentQuotaDao.Delete(a);
                  IList<AgentQuota> lstQuota = (IList<AgentQuota>) grdvQuota.DataSource;
                  lstQuota.Remove(a);
                  grdQuota.RefreshDataSource();

                  //load fix sales
                  grdFixSales.DataSource = lstQuota;

                  //load per itemdetails
                  ShowPerItemDetails(lstQuota);
               }
               catch (Exception ex)
               {
                  clsUtil.ShowMessageError("Error: " + ex.Message, "Remove Quota");
               }
            }
         }
      }

      private void grdvFixSales_FocusedRowChanged(object sender,
                                                  DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
      {
         GetSelectedRowFixSales();
      }

      private void GetSelectedRowFixSales()
      {
         //AgentCommissionFixSales fixsales = (AgentCommissionFixSales)grdvFixSales.GetRow(grdvFixSales.FocusedRowHandle);
         AgentQuota fixsales = (AgentQuota) grdvFixSales.GetRow(grdvFixSales.FocusedRowHandle);
         if (fixsales != null)
         {
            txtFixSalesQuota.Text = fixsales.Quota.ToString("#,##0.00");
            txtFixSalesCommission.Text = fixsales.FixSalesDetails.Commission.ToString("#,##0.00");
         }
         else
         {
            txtFixSalesQuota.Text = "";
            txtFixSalesCommission.Text = "";
         }
      }

      private void btnFixSalesSave_Click(object sender, EventArgs e)
      {
         if (m_Agent != null)
         {
            double commission = clsUtil.CheckValue(txtFixSalesCommission);
            if (commission > 0)
            {
               //AgentCommissionFixSales fixsales = (AgentCommissionFixSales)grdvFixSales.GetRow(grdvFixSales.FocusedRowHandle);
               AgentQuota fixsales = (AgentQuota) grdvFixSales.GetRow(grdvFixSales.FocusedRowHandle);
               if (fixsales != null)
               {
                  fixsales.FixSalesDetails.Commission = commission;
                  //FixSalesDao.Save(fixsales);
                  FixSalesQuotaDetailsDao.Save(fixsales.FixSalesDetails);
                  grdFixSales.RefreshDataSource();
               }
               else
               {
                  clsUtil.ShowMessageExclamation("Invalid item selected!", "Save Fix Sales Commission");
               }
            }
            else
            {
               clsUtil.ShowMessageExclamation("Invalid amount!", "Save Fix Sales Commission");
            }
         }
         else
         {
            clsUtil.ShowMessageExclamation("Invalid Agent selected!", "Save Fix Sales Commission");
         }
      }

      private void btnPerItem_Add_Click(object sender, EventArgs e)
      {
         TreeListNode node = treeItems.FocusedNode;
         /*if (node != null)
         {
            if (node.ParentNode != null)
               node = node.ParentNode;

            frmGenericPopup frm = new frmGenericPopup();
            ctlSelectItems_AgentCommission ctl = new ctlSelectItems_AgentCommission();

            AgentQuota quota = (AgentQuota) node.GetValue(eCol.ItemObject.ToString());
            ctl.Quota = quota;
            ctl.ViewMode = ctlSelectItems_AgentCommission.eViewMode.AddNew;
            frm.Text = "Select Items";
            frm.ControlBox = false;
            frm.ShowCtl(ctl);
            if (!ctl.Canceled)
            {
               //save new detail
               AgentQuotaItemDetails detail = new AgentQuotaItemDetails();
               detail.ItemName = ctl.ItemName;
               detail.LimitValue = 0;
               detail.PercentCommission = 0;
               detail.quota = quota;
               //detail.ExemptedItems = new List<AgentQuotaExemptItem>();

               try
               {
                  ItemDetailsDao.Save(detail);

                  treeItems.BeginUnboundLoad();
                  //add item to treeview
                  TreeListNode child = treeItems.AppendNode(null, node);
                  child.SetValue(eCol.ItemObject.ToString(), detail);
                  child.SetValue(eCol.ItemName.ToString(), detail.ItemName);
                  child.SetValue(eCol.LimitValue.ToString(), detail.LimitValue);
                  child.SetValue(eCol.Percentage.ToString(), detail.PercentCommission);
                  treeItems.EndUnboundLoad();

                  quota.ItemDetails.Add(detail);
               }
               catch (Exception ex)
               {
                  clsUtil.ShowMessageError("Error: " + ex.Message, "Save Item Detail");
               }
            }
         }*/
      }

      private void btnPerItem_Remove_Click(object sender, EventArgs e)
      {
         TreeListNode node = treeItems.FocusedNode;
         if (node != null)
         {
            if (node.ParentNode != null)
            {
               AgentQuotaItemDetails detail = (AgentQuotaItemDetails) node.GetValue(eCol.ItemObject.ToString());
               if (clsUtil.ShowMessageYesNo(string.Format("Remove item '{0}'?", detail.ItemName), "Remove Item") ==
                   DialogResult.Yes)
               {
                  try
                  {
                     ItemDetailsDao.Delete(detail);

                     AgentQuota quota = (AgentQuota) node.ParentNode.GetValue(eCol.ItemObject.ToString());
                     quota.ItemDetails.Remove(detail);
                     treeItems.BeginUnboundLoad();
                     node.ParentNode.Nodes.Remove(node);
                     treeItems.EndUnboundLoad();
                  }
                  catch (Exception ex)
                  {
                     clsUtil.ShowMessageError("Error: " + ex.Message, "Remove Item");
                  }
               }
            }
         }
      }

      private void treeItems_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
      {
         CheckSelectedNode();
      }

      private void CheckSelectedNode()
      {
         TreeListNode node = treeItems.FocusedNode;
         if (node != null)
         {
            if (node.GetValue(eCol.AgentQuota.ToString()) == null)
            {
               if (!node.HasChildren)
               {
                  AgentQuotaItemDetails detail = (AgentQuotaItemDetails) node.GetValue(eCol.ItemObject.ToString());
                  if (detail != null)
                  {
                     txtPerItem_Name.Text = detail.ItemName;
                     txtPerItem_SalesLimit.Text = detail.LimitValue.ToString(FMT_AMOUNT);
                     txtPerItem_SalesLimit.Enabled = true;
                     txtPerItem_Percentage.Text = detail.PercentCommission.ToString(FMT_AMOUNT);
                     txtPerItem_Percentage.Enabled = true;
                     btnPerItem_Save.Enabled = true;
                     btnPerItem_Remove.Enabled = true;
                     return;
                  }
               }
            }
         }

         txtPerItem_Name.Text = "";
         txtPerItem_SalesLimit.Text = "0.00";
         txtPerItem_SalesLimit.Enabled = false;
         txtPerItem_Percentage.Text = "0.00";
         txtPerItem_Percentage.Enabled = false;
         btnPerItem_Save.Enabled = false;
         btnPerItem_Remove.Enabled = false;
      }

      private void txtPerItem_SalesLimit_Enter(object sender, EventArgs e)
      {
         ((DevExpress.XtraEditors.TextEdit) sender).SelectAll();
      }

      private void btnPerItem_Save_Click(object sender, EventArgs e)
      {
         TreeListNode node = treeItems.FocusedNode;
         if (node != null)
         {
            if (node.ParentNode != null)
            {
               AgentQuotaItemDetails detail = (AgentQuotaItemDetails) node.GetValue(eCol.ItemObject.ToString());
               detail.LimitValue = clsUtil.CheckValue(txtPerItem_SalesLimit);
               detail.PercentCommission = clsUtil.CheckValue(txtPerItem_Percentage);

               try
               {
                  ItemDetailsDao.Save(detail);

                  //update node display
                  node.SetValue(eCol.LimitValue.ToString(), detail.LimitValue);
                  node.SetValue(eCol.Percentage.ToString(), detail.PercentCommission);
               }
               catch (Exception ex)
               {
                  clsUtil.ShowMessageError("Error: " + ex.Message, "Save Per Item Detail");
               }
            }
         }
      }

      private void treeItems_DoubleClick(object sender, EventArgs e)
      {
         TreeListNode node = treeItems.FocusedNode;
         /*if (node != null) temporary commented
         {
            if (node.GetValue(eCol.AgentQuota.ToString()) == null)
            {
               AgentQuotaItemDetails detail = (AgentQuotaItemDetails) node.GetValue(eCol.ItemObject.ToString());

               ctlSelectItems_AgentCommission ctl = new ctlSelectItems_AgentCommission();
               frmGenericPopup frm = new frmGenericPopup();

               ctl.ItemDetail = detail;
               ctl.ViewMode = ctlSelectItems_AgentCommission.eViewMode.Modify;
               frm.Text = "Modify Item Detail";
               frm.ControlBox = false;
               frm.ShowCtl(ctl);
               if (!ctl.Canceled)
               {
                  //save Item Detail
                  try
                  {
                     ItemDetailsDao.Save(ctl.ItemDetail);
                  }
                  catch (Exception ex)
                  {
                     clsUtil.ShowMessageError("Error: " + ex.Message, "Update Item Detail");
                  }
               }
            }
         }*/
      }

      private void btnFixCommissionRefresh_Click(object sender, EventArgs e)
      {
         GetFixCommisionDetails();
      }

      private void GetFixCommisionDetails()
      {
         Init_FixCommissions();
         if (m_Agent != null)
         {
            foreach (AgentCommission ac in m_lstCom)
            {
               DataRow row = tblFixCommission.Rows[ac.Invoice.InvoiceDate.Month - 1];
               row[(int) eColFixCom.SalesTotal] = Convert.ToDouble(row[(int) eColFixCom.SalesTotal].ToString()) +
                                                  ac.SalesTotal;
               row[(int) eColFixCom.SalesPerItem] = Convert.ToDouble(row[(int) eColFixCom.SalesPerItem].ToString()) +
                                                    ac.SalesItem + ac.SalesFab + ac.SalesTrading;
               row[(int) eColFixCom.SalesMisc] = Convert.ToDouble(row[(int) eColFixCom.SalesMisc].ToString()) +
                                                 ac.SalesMiscItems;
            }
         }
      }

      private void GetAnnualCommission()
      {
         double sales = 0, offset = 0, offset_total = 0;
         AgentQuota a_quota = null;

         grdAnnualCom.BeginUpdate();
         Init_AnnualCommissions();
         foreach (DataRow row in tblAnnualCommission.Rows)
         {
            sales = Convert.ToDouble(row[(Int32) eColAnnualCom.SalesTotal].ToString());

            //get quota applied
            a_quota = null;
            foreach (AgentQuota quota in m_lstQuota)
            {
               if (a_quota == null)
               {
                  if (sales >= quota.Quota)
                     a_quota = quota;
               }
               else
               {
                  if (quota.Quota > a_quota.Quota)
                     a_quota = quota;
               }
            }

            if (a_quota != null)
            {
               offset = sales - a_quota.Quota;
            }
            else
            {
               offset = sales;
            }

            row[(Int32) eColAnnualCom.SalesOffset] = offset;
            offset_total += offset;
         }

         txtAnnualCom_Percentage.Text = m_Agent.AnnualCommisionPercentage.ToString(FMT_AMOUNT);
         txtAnnualCom_OffsetSales.Text = offset_total.ToString(FMT_AMOUNT);
         txtAnnualCom_Commission.Text = (offset_total*(m_Agent.AnnualCommisionPercentage/100)).ToString(FMT_AMOUNT);

         grdAnnualCom.EndUpdate();
      }

      private void GetPerItemCommission()
      {
         if (m_Agent != null)
         {
            Init_PerItemCommission();

            treeItemCommission.BeginUnboundLoad();

            TreeListNode node = null;
            double Sales = 0, SalesItem = 0, Commission = 0, temp = 0;
            foreach (AgentCommission com in m_lstCom)
            {
               foreach (AgentCommissionItemDetails details in com.ItemDetails)
               {
                  node = treeItemCommission.Nodes[com.Invoice.InvoiceDate.Month - 1];
                  Sales = Convert.ToDouble(node.GetValue(eColItemCom.TotalSales.ToString()));
                  Sales += details.AmountSales;
                  node.SetValue(eColItemCom.TotalSales.ToString(), Sales);
                  foreach (TreeListNode childnode in node.Nodes)
                  {
                     if (childnode.GetValue(eColItemCom.AgentItem.ToString()).ToString() == details.ItemDetails.ItemName)
                     {
                        SalesItem = Convert.ToDouble(childnode.GetValue(eColItemCom.TotalSales.ToString()));
                        SalesItem += details.AmountSales;
                        childnode.SetValue(eColItemCom.TotalSales.ToString(), SalesItem);

                        break;
                     }
                  }
               }
            }

            //compute commission
            //get list of unique itemdetails
            AgentQuotaItemDetails AQ_detail = null;
            foreach (TreeListNode _node in treeItemCommission.Nodes)
            {
               foreach (TreeListNode _node2 in _node.Nodes)
               {
                  Sales = Convert.ToDouble(_node2.GetValue(eColItemCom.TotalSales.ToString()).ToString());
                  if (Sales > 0)
                  {
                     AQ_detail = GetItemQuota(_node2.GetValue(eColItemCom.AgentItem.ToString()).ToString(), Sales);
                     if (AQ_detail != null)
                     {
                        Commission = Sales*(AQ_detail.PercentCommission/100);

                        if (Commission > AQ_detail.LimitValue)
                           Commission = AQ_detail.LimitValue;

                        //update display
                        temp = Convert.ToDouble(_node2.GetValue(eColItemCom.Commission.ToString()).ToString());
                        temp += Commission;
                        _node2.SetValue(eColItemCom.Commission.ToString(), temp);

                        //update parent node
                        temp = Convert.ToDouble(_node.GetValue(eColItemCom.Commission.ToString()).ToString());
                        temp += Commission;
                        _node.SetValue(eColItemCom.Commission.ToString(), temp);
                     }
                  }
               }
            }


            treeItemCommission.EndUnboundLoad();
         }
      }

      private AgentQuotaItemDetails GetItemQuota(string ItemName, double sales)
      {
         AgentQuota ret = null;
         foreach (AgentQuota quota in m_lstQuota)
         {
            if (sales >= quota.Quota)
            {
               if (ret == null)
               {
                  ret = quota;
               }
               else
               {
                  if (quota.Quota > ret.Quota)
                     ret = quota;
               }
            }
         }

         if (ret == null)
            return null;

         foreach (AgentQuotaItemDetails detail in ret.ItemDetails)
         {
            if (detail.ItemName == ItemName)
               return detail;
         }
         return null;
      }

      private void Init_FixCommissions()
      {
         tblFixCommission.Rows.Clear();
         for (int i = 0; i < 12; i++)
         {
            tblFixCommission.Rows.Add(((eMonthNames) i).ToString(), 0, 0, 0);
         }
      }

      private void Init_AnnualCommissions()
      {
         tblAnnualCommission.Rows.Clear();
         for (int i = 0; i < 12; i++)
         {
            tblAnnualCommission.Rows.Add(((eMonthNames) i).ToString(),
                                         tblFixCommission.Rows[i][(Int32) eColFixCom.SalesTotal], 0);
         }
      }

      private void Init_PerItemCommission()
      {
         TreeListNode node = null, childnode = null;
         treeItemCommission.BeginUnboundLoad();
         treeItemCommission.Nodes.Clear();
         for (int i = 0; i < 12; i++)
         {
            node = treeItemCommission.AppendNode(null, null);
            node.SetValue(eColItemCom.Month.ToString(), ((eMonthNames) i).ToString());
            node.SetValue(eColItemCom.TotalSales.ToString(), 0);
            node.SetValue(eColItemCom.Commission.ToString(), 0);

            foreach (AgentQuota quota in m_lstQuota)
            {
               foreach (AgentQuotaItemDetails itemdetails in quota.ItemDetails)
               {
                  childnode = treeItemCommission.AppendNode(null, node);
                  childnode.SetValue(eColItemCom.AgentItem.ToString(), itemdetails.ItemName);
                  childnode.SetValue(eColItemCom.TotalSales.ToString(), 0);
                  childnode.SetValue(eColItemCom.Commission.ToString(), 0);
               }
               break;
            }
         }
         treeItemCommission.EndUnboundLoad();
      }

      private void grdvFixCommission_FocusedRowChanged(object sender,
                                                       DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
      {
         DataRow row = grdvFixCommission.GetDataRow(e.FocusedRowHandle);
         if (row != null)
         {
            double ComFixSales, ComPerItem;
            double TotalSales = (double) row[(int) eColFixCom.SalesTotal];
            double SalesItems = (double) row[(int) eColFixCom.SalesPerItem];

            //get what quota to use
            AgentQuota FixQuota = null;
            ComFixSales = 0;
            foreach (AgentQuota quota in m_lstQuota)
            {
               if (TotalSales >= quota.Quota)
                  FixQuota = quota;
            }

            if (FixQuota != null)
            {
               ComFixSales = FixQuota.FixSalesDetails.Commission;
            }
            txtFixCommission.Text = ComFixSales.ToString(FMT_AMOUNT);

            //get per item commission
            ComPerItem =
               Convert.ToDouble(
                  treeItemCommission.Nodes[e.FocusedRowHandle].GetValue(eColItemCom.Commission.ToString()).ToString());
            txtFixCommisionItem.Text = ComPerItem.ToString(FMT_AMOUNT);
            txtFixCommissionTotal.Text = (ComFixSales + ComPerItem).ToString(FMT_AMOUNT);
         }
      }

      private void btnItemCommissionRefresh_Click(object sender, EventArgs e)
      {
         ViewSelectedAgent();
      }

      private void btnAnnualCom_Save_Click(object sender, EventArgs e)
      {
         m_Agent.AnnualCommisionPercentage = clsUtil.CheckValue(txtAnnualCom_Percentage);
         try
         {
            AgentDao.Save(m_Agent);
            GetAnnualCommission();
         }
         catch (Exception ex)
         {
         }
      }
   }
}