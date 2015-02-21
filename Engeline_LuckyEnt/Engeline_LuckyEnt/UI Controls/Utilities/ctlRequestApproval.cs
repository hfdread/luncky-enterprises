#region

using System;
using System.Windows.Forms;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Utilities
{
   public partial class ctlRequestApproval : UserControl
   {
      private RequestApprovalDao ApprovalDao = new RequestApprovalDao();
      public RequestApproval m_Request { get; set; }

      public ctlRequestApproval()
      {
         InitializeComponent();
      }

      public ctlRequestApproval(RequestApproval ra)
      {
         InitializeComponent();
         m_Request = ra;
      }

      private void ctlRequestApproval_Load(object sender, EventArgs e)
      {
         txtSender.Text = m_Request.Sender.UserName;
         txtTime.Text = m_Request.RequestDate.ToString("MMM dd,yyyy hh:mm tt");
         txtTerminal.Text = m_Request.Terminal;
         txtRequestType.Text = ((RequestApproval.eRequestType) m_Request.RequestType).ToString();
         txtMessage.Text = m_Request.Message;

         if(m_Request.Status != RequestApproval.eStatus.Pending)
         {
            //this request is already approved or declined
            btnApprove.Visible = false;
            btnDecline.Visible = false;
            btnClose.Visible = true;
         }
      }

      private void btnDecline_Click(object sender, EventArgs e)
      {
         m_Request.Status = RequestApproval.eStatus.Declined;

         try
         {
            ApprovalDao.Save(m_Request);
         }
         catch
         {
         }
         this.ParentForm.Close();
      }

      private void btnApprove_Click(object sender, EventArgs e)
      {
         m_Request.Status = RequestApproval.eStatus.Approved;

         try
         {
            ApprovalDao.Save(m_Request);
         }
         catch
         {
         }
         this.ParentForm.Close();
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         this.ParentForm.Close();
      }
   }
}