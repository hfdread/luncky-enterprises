#region

using System;
using System.Windows.Forms;
using DexterHardware_v2.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace DexterHardware_v2.UI_Controls.Utilities
{
   public partial class ctlMaintenance : UserControl
   {
      private SettingsDao dao = new SettingsDao();

      public ctlMaintenance()
      {
         InitializeComponent();
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         if(dao.SetSetting(Settings.eSettings.ShowSellingPrice.ToString(), cboShowSellingPrice.SelectedIndex.ToString())==0)
         {
            cUtil.ShowMessageInformation("Settings saved!","Save Settings");
         }
         else
         {
            cUtil.ShowMessageError("Error: " + dao.ErrorMessage, "Save Settings");
         }
      }

      private void ctlMaintenance_Load(object sender, EventArgs e)
      {
         //get current settings
         Settings s = dao.GetSetting(Settings.eSettings.ShowSellingPrice.ToString());
         if(s!=null)
         {
            if (s.Value == "1")
               cboShowSellingPrice.SelectedIndex = 1;
            else
            {
               cboShowSellingPrice.SelectedIndex = 0;
            }
         }
         else
         {
            cboShowSellingPrice.SelectedIndex = 1;
         }
      }
   }
}