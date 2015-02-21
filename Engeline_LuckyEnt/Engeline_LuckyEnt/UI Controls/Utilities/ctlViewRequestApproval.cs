#region

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using Engeline_LuckyEnt.Forms;
using Engeline_LuckyEnt.Classes;
#endregion

namespace Engeline_LuckyEnt.UI_Controls.Utilities
{
   public partial class ctlViewRequestApproval : UserControl
   {
      public UserControl Parent_ctl { get; set; }
      public bool Canceled { get; set; }

      private RequestApprovalDao mRequestApprovalDao = new RequestApprovalDao();

      public ctlViewRequestApproval()
      {
         InitializeComponent();
      }

      private void ctlTemplate_Load(object sender, EventArgs e)
      {
         //Form Initialization
         btnRefresh.PerformClick();
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

      private void btnRefresh_Click(object sender, EventArgs e)
      {
         //get all aprroval requests pending approval
         grdRA.DataSource = mRequestApprovalDao.getAllPendingRequest();
      }

      private void grdRA_DoubleClick(object sender, EventArgs e)
      {
         RequestApproval ra = (RequestApproval)grdvRA.GetRow(grdvRA.FocusedRowHandle);
         if(ra!=null)
         {
            //check if ra is still available
            ra = mRequestApprovalDao.GetById(ra.ID);
            if(ra==null)
            {
               grdvRA.DeleteRow(grdvRA.FocusedRowHandle);
               clsUtil.ShowMessageExclamation("Request is no longer available!", "Approval Request");
               return;
            }

            ctlRequestApproval ctl = new ctlRequestApproval();
            ctl.m_Request = ra;

            frmGenericPopup frm = new frmGenericPopup();
            frm.Text = "Approval Needed";
            frm.ShowCtl(ctl);

            btnRefresh.PerformClick();
         }
      }

      private void timer1_Tick(object sender, EventArgs e)
      {
         btnRefresh.PerformClick();
      }

      private void btnClose_Click_1(object sender, EventArgs e)
      {
         clsUtil.getMainForm().CloseCurrentControl();
      }
   }
}