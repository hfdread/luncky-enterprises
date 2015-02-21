#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
   public partial class ctlViewBanks : UserControl
   {
      private BanksDao BankDao = new BanksDao();

      private enum eFlds
      {
         ID = 0,
         Name,
         Description,
         Dirty
      }

      public ctlViewBanks()
      {
         InitializeComponent();
      }

      private void grdvBanks_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
      {
         DataRow row = grdvBanks.GetDataRow(e.RowHandle);
         row[(int) eFlds.ID] = 0;
         row[(int) eFlds.Dirty] = true;
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         IList<Banks> lst = new List<Banks>();

         foreach (DataRow row in tblData.Rows)
         {
            if (Convert.ToBoolean(row[(int) eFlds.Dirty].ToString()) == true)
            {
               Banks bank = new Banks();
               bank.ID = clsUtil.ParseInt32(row[(int) eFlds.ID].ToString());
               bank.Name = row[(int) eFlds.Name].ToString();
               bank.ShortDescription = row[(int) eFlds.Description].ToString();
               lst.Add(bank);
               row[(int)eFlds.Dirty] = false;
            }
         }
         if (lst.Count > 0)
         {
            try
            {
               BankDao.SaveBatch(lst);
               clsUtil.ShowMessage("Banks saved!", "Save Banks", MessageBoxButtons.OK, MessageBoxIcon.Information);
               tblData.Rows.Clear();
               ListBanks();
            }
            catch (Exception ex)
            {
               clsUtil.ShowMessageError("Error: " + ex.Message, "Save Banks");
            }
         }
      }

      private void ctlViewBanks_Load(object sender, EventArgs e)
      {
          ListBanks();
      }

      private void ListBanks()
      {
          IList<Banks> lst = BankDao.getAllRecords();
          foreach (Banks bank in lst)
          {
              tblData.Rows.Add(bank.ID, bank.Name, bank.ShortDescription, false);
          }
      }
      private void grdvBanks_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
      {
         DataRow row = grdvBanks.GetDataRow(e.RowHandle);

         if (row[(int) eFlds.Name].ToString().Trim() == "")
         {
            clsUtil.ShowMessageError("Invalid name!", "Update Bank");
            e.Valid = false;
         }

         if (row[(int) eFlds.Description].ToString().Trim() == "")
         {
            clsUtil.ShowMessageError("Invalid short description!", "Update Bank");
            e.Valid = false;
         }
      }

      private void grdvBanks_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
      {
         DataRow row = grdvBanks.GetDataRow(e.RowHandle);
         row[(int) eFlds.Dirty] = true;
      }

      private void btnDelete_Click(object sender, EventArgs e)
      {
          DataRow row = grdvBanks.GetDataRow(grdvBanks.FocusedRowHandle);
          if (row != null)
          {
              if (clsUtil.ShowMessageYesNo(string.Format("Are you sure you want to delete bank '{0}'?", row[(int)eFlds.Description].ToString()), "Delete Bank") == DialogResult.No)
                  return;
              Banks bank = BankDao.GetById(Convert.ToInt32(row[(Int32)eFlds.ID].ToString()));
              try
              {
                  BankDao.Delete(bank);

                  //remove item from list
                  tblData.Rows.RemoveAt(grdvBanks.GetDataSourceRowIndex(grdvBanks.FocusedRowHandle));
                  grdBanks.RefreshDataSource();
              }
              catch (Exception ex)
              {
                  clsUtil.ShowMessageError(ex, "Delete Bank");
              }
          }
      }

   }
}