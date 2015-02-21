#region

using System;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Utilities
{
   public partial class ctlRequestSend : UserControl
   {
      private RequestApprovalDao ApprovalDao = new RequestApprovalDao();

      public bool Canceled { get; set; }
      public RequestApproval m_Request { get; set; }

      public ctlRequestSend()
      {
         InitializeComponent();
      }

      public ctlRequestSend(RequestApproval ra)
      {
         InitializeComponent();
         m_Request = ra;
      }

      private void ctlRequestSend_Load(object sender, EventArgs e)
      {
         //save request
         try
         {
            ApprovalDao.Save(m_Request);
            tmrCheck.Enabled = true;
         }
         catch
         {
            clsUtil.ShowMessageError("An error occurred while sending request!", "Request Approval");
            lblRequest.Text = "Send request error!";
         }
      }

      private void tmrCheck_Tick(object sender, EventArgs e)
      {
         //check for request status
         RequestApproval ra = ApprovalDao.GetById(m_Request.ID);
         if (ra.Status != (int) RequestApproval.eStatus.Pending)
         {
            tmrCheck.Enabled = false;
            m_Request.Status = ra.Status;
            Canceled = false;
            this.ParentForm.Close();
         }
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         //remove request
         try
         {
            tmrCheck.Enabled = false;
            ApprovalDao.Delete(m_Request);
         }
         catch
         {
         }

         Canceled = true;
         this.ParentForm.Close();
      }
   }
}