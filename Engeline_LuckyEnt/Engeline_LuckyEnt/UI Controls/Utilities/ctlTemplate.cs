#region

using System;
using System.Windows.Forms;

#endregion

namespace DexterHardware_v2.UI_Controls.Utilities
{
   public partial class ctlTemplate : UserControl
   {
      public UserControl Parent_ctl { get; set; }
      public bool Canceled { get; set; }

      public ctlTemplate()
      {
         InitializeComponent();
      }

      private void ctlTemplate_Load(object sender, EventArgs e)
      {
         //Form Initialization
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         Canceled = true;

         //show next ctl
         //if (Parent_ctl != null)
         //{
         //   clsUtil.getMainForm().LoadLastCtl();
         //}
         //else
         //{
         //   ctlTemplate ctl = new ctlTemplate();
         //   clsUtil.getMainForm().LoadCtl(ctl, true, "Title", "SubTitle", false);
         //}
      }
   }
}