#region

using System;
using Engeline_LuckyEnt.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Utilities
{
   public partial class ctlCompanyProfile : DevExpress.XtraEditors.XtraUserControl
   {
      private CompanyProfileDao m_Dao = new CompanyProfileDao();
      private CompanyProfile m_CompanyProfile = null;

      public ctlCompanyProfile()
      {
         InitializeComponent();
      }

      private void btnUpdate_Click(object sender, EventArgs e)
      {
         if (txtCompnayName.Text.Trim() == "")
         {
            clsUtil.ShowMessageExclamation("Invalid company name!", "Update Company Profile");
            txtCompnayName.Focus();
            return;
         }

         m_CompanyProfile.CompanyName = txtCompnayName.Text;
         m_CompanyProfile.Address = txtAddress.Text;
         m_CompanyProfile.SSS = txtSSS.Text;
         m_CompanyProfile.TIN = txtTIN.Text;
         m_CompanyProfile.Phone = txtPhone.Text;
         m_CompanyProfile.Fax = txtFax.Text;
         m_CompanyProfile.Email = txtEmail.Text;
         m_CompanyProfile.Website = txtWebsite.Text;

         try
         {
            m_Dao.Save(m_CompanyProfile);
            clsUtil.ShowMessageInformation("Company Profile updated!", "Update");
         }
         catch
         {
            clsUtil.ShowMessageError(m_Dao.ErrorMessage, "Update");
         }
      }

      private void ctlCompanyProfile_Load(object sender, EventArgs e)
      {
         m_CompanyProfile = m_Dao.GetCompanyProfile();
         if (m_CompanyProfile == null)
            m_CompanyProfile = new CompanyProfile();

         //show details
         txtCompnayName.Text = m_CompanyProfile.CompanyName;
         txtAddress.Text = m_CompanyProfile.Address;
         txtPhone.Text = m_CompanyProfile.Phone;
         txtFax.Text = m_CompanyProfile.Fax;
         txtEmail.Text = m_CompanyProfile.Email;
         txtWebsite.Text = m_CompanyProfile.Website;
         txtSSS.Text = m_CompanyProfile.SSS;
         txtTIN.Text = m_CompanyProfile.TIN;
      }
   }
}