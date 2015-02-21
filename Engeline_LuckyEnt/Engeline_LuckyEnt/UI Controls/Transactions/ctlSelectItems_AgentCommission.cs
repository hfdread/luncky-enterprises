#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DexterHardware_v2.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace DexterHardware_v2.UI_Controls.Transactions
{
   public partial class ctlSelectItems_AgentCommission : UserControl
   {
      private ItemDao ItemDao = new ItemDao();

      public AgentQuota Quota { get; set; }
      public AgentQuotaItemDetails ItemDetail { get; set; }
      public string ItemName { get; set; }
      public bool Canceled { get; set; }
      public eViewMode ViewMode { get; set; }

      public enum eViewMode
      {
         AddNew,
         Modify
      }

      public ctlSelectItems_AgentCommission()
      {
         InitializeComponent();
      }

      private void btnSearch_Click(object sender, EventArgs e)
      {
         if (txtSearch.Text != "")
         {
            string Condition = "";
            Condition = cUtil.GenerateFilterCondition(txtSearch.Text);
            Condition = string.Format("I.Name like '{0}' or I.Description like '{0}'", Condition);
            IList<Items> lstItems = ItemDao.getAllByCondition(Condition);
            grdItems.DataSource = lstItems;
         }
      }

      private void ctlSelectItems_AgentCommission_Load(object sender, EventArgs e)
      {
         if (ViewMode == eViewMode.AddNew)
         {
            grdvItems.Columns[0].Visible = false;
            txtSearch.Focus();
         }
         else
         {
            btnAddFabricatedItem.Enabled = false;
            btnAddTradingItems.Enabled = false;
            btnSearch.Enabled = false;
            txtSearch.Enabled = false;
            ShowItemDetails();
            grdvItems.OptionsBehavior.Editable = true;
         }
      }

      private void ShowItemDetails()
      {
         string Condition = "";
         Condition = cUtil.GenerateFilterCondition(ItemDetail.ItemName);
         Condition = string.Format("I.Name like '{0}' or I.Description like '{0}'", Condition);
         IList<Items> lstItems = ItemDao.getAllByCondition(Condition);
         foreach (Items item in lstItems)
         {
            item.Selected = true;

            //check if item is part of exempted items
            foreach (AgentQuotaExemptItem e in ItemDetail.ExemptedItems)
            {
               if (item.ID == e.ItemID)
               {
                  item.Selected = false;
                  break;
               }
            }
         }
         grdItems.DataSource = lstItems;
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         Canceled = true;
         this.ParentForm.Close();
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         if (ViewMode == eViewMode.AddNew)
         {
            if (grdvItems.RowCount == 0)
            {
               cUtil.ShowMessageExclamation("No items to save!", "Save Per Item Details");
            }
            ItemName = txtSearch.Text;
            Canceled = false;
            this.ParentForm.Close();
         }
         else
         {
            //modify mode, get exception items
            //ItemDetail.ExemptedItems = new List<AgentQuotaExemptItem>();
            foreach (Items i in (IList<Items>) grdItems.DataSource)
            {
               if (!i.Selected)
               {
                  AgentQuotaExemptItem item = new AgentQuotaExemptItem();
                  item.ItemID = i.ID;
                  ItemDetail.ExemptedItems.Add(item);
               }
            }

            Canceled = false;
            this.ParentForm.Close();
         }
      }

      private void btnAddFabricatedItem_Click(object sender, EventArgs e)
      {
         //check if already added
         foreach (AgentQuotaItemDetails detail in Quota.ItemDetails)
         {
            if (detail.ItemName.ToLower() == "fabricated items")
            {
               cUtil.ShowMessageExclamation("Fabricated Items already added!", "Add Per Item Details");
               return;
            }
         }

         ItemName = "Fabricated Items";
         Canceled = false;
         this.ParentForm.Close();
      }

      private void btnAddTradingItems_Click(object sender, EventArgs e)
      {
         //check if already added
         foreach (AgentQuotaItemDetails detail in Quota.ItemDetails)
         {
            if (detail.ItemName.ToLower() == "trading items")
            {
               cUtil.ShowMessageExclamation("Trading Items already added!", "Add Per Item Details");
               return;
            }
         }

         ItemName = "Trading Items";
         Canceled = false;
         this.ParentForm.Close();
      }
   }
}