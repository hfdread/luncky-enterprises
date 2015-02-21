using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Engeline_LuckyEnt.UI_Controls;
using Engeline_LuckyEnt.UI_Controls.Utilities;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.Forms;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
    public partial class ctlContacts : UserControl
    {
        private ContactsDao mContactsDao = null;

        private Contacts m_SelectedContact = null;
        private BanksDao mBanksDao = null;
        private Boolean m_bRunOnce = false;

        private enum eOperation
        {
            AddContact = 0,
            EditContact,
            ViewContacts
        }

        private eOperation m_OperationType;

        public ctlContacts()
        {
            InitializeComponent();
            mContactsDao = new ContactsDao();
            mBanksDao = new BanksDao();
        }

        private void ctlContacts_Load(object sender, EventArgs e)
        {
            m_OperationType = eOperation.ViewContacts;
            LockForm(true);
            m_bRunOnce = true;
            
            //load TERMS
            LoadTerms();
            
            //load banks
            LoadBankList();

            //load contacts filter
            LoadContactsFilter();

            //load contacts
            LoadContactsList();
            if (grdvContacts.RowCount > 0)
                grdvContacts.SelectRow(0);

            SetButton();
        }

        private void LoadBankList()
        {
            //remove existing items first
            cboBankRef1.Properties.Items.Clear();
            cboBankRef2.Properties.Items.Clear();
            cboBankRef3.Properties.Items.Clear();
            cboBankRef4.Properties.Items.Clear();
            cboBankRef5.Properties.Items.Clear();

            IList<Banks> lstBanks = mBanksDao.getAllRecords();
            foreach (Banks bank in lstBanks)
            {
                cboBankRef1.Properties.Items.Add(bank);
                cboBankRef2.Properties.Items.Add(bank);
                cboBankRef3.Properties.Items.Add(bank);
                cboBankRef4.Properties.Items.Add(bank);
                cboBankRef5.Properties.Items.Add(bank);
            }

            cboBankRef1.SelectedIndex = -1;
            cboBankRef2.SelectedIndex = -1;
            cboBankRef3.SelectedIndex = -1;
            cboBankRef4.SelectedIndex = -1;
            cboBankRef5.SelectedIndex = -1;

       }

        private void LoadTerms()
        {
            for (int i = 0; i <= 120; i++)
            {
                cboTerms.Properties.Items.Add(i);
                cboTermsPDC.Properties.Items.Add(i);
            }
        }

        private void LoadContactsFilter()
        {
            cboContactType.Items.Add("ALL");
            foreach (String s in Contacts.GetContactTypes())
            {
                /*if (clsUtil.GetUserPermissions().ContactsViewSuppliersManila == 0 &&
                    s == Contacts.GetContactType(Contacts.eContactType.SuppliersManila))
                {
                }
                else
                {*/
                    cboContactType.Items.Add(s);
                    cboContactType2.Items.Add(s);
                //}
            }
            cboContactType.SelectedIndex = 0;
            cboContactType2.SelectedIndex = 0;
        }

        private void LoadContactsList()
        {
            grdContacts.DataSource = mContactsDao.getAllRecords();
        }

        private void SetButton()
        {
            if (m_OperationType == eOperation.AddContact || m_OperationType == eOperation.EditContact)
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Text = "&Save";
                btnClose.Text = "&Cancel";
            }
            else
            {
                Boolean chk = CheckSelectedContact();
                btnAdd.Enabled = true;
                if (grdvContacts.RowCount <= 0 || chk)
                    btnEdit.Enabled = false;
                else
                    btnEdit.Enabled = true;
                btnDelete.Text = "&Delete";
                btnClose.Text = "&Close";
            }
        }

        private void ClearForm()
        {
            lblIDNumber.Text = "";

            //Contact Information
            txtCompanyName.Text = "";
            txtCompanyAddress.Text = "";
            txtCompanyTelNo.Text = "";
            txtAgent.Text = "";

            cboTerms.Text = "0";
            cboTermsPDC.Text = "0";
            txtCreditLimit.Text = "0";

            cboContactType2.Text = "";
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtMobileNo.Text = "";
            txtLandLineNo.Text = "";
            txtFaxNo.Text = "";
            txtAddress.Text = "";

            //Contact Persons
            txtContactAccountingName1.Text = "";
            txtContactAccountingNum1.Text = "";
            txtContactPurchasingName.Text = "";
            txtContactPurchasingNum.Text = "";
            txtContactHeadOfficeName.Text = "";
            txtContactHeadOfficeNum.Text = "";

            //Business Reference
            txtBR_Name1.Text = "";
            txtBR_Address1.Text = "";
            txtBR_ContactPerson1.Text = "";
            txtBR_Number1.Text = "";
            txtBR_Name2.Text = "";
            txtBR_Address2.Text = "";
            txtBR_ContactPerson2.Text = "";
            txtBR_Number2.Text = "";
            txtBR_Name3.Text = "";
            txtBR_Address3.Text = "";
            txtBR_ContactPerson3.Text = "";
            txtBR_Number3.Text = "";

            //Bank Reference
            cboBankRef1.Text = "";
            txtBank_Branch1.Text = "";
            txtBank_AccountNo1.Text = "";
            txtBank_Number1.Text = "";
            cboBankRef2.Text = "";
            txtBank_Branch2.Text = "";
            txtBank_AccountNo2.Text = "";
            txtBank_Number2.Text = "";
            cboBankRef3.Text = "";
            txtBank_Branch3.Text = "";
            txtBank_AccountNo3.Text = "";
            txtBank_Number3.Text = "";
            //additional banks
            cboBankRef4.Text = "";
            txtBank_Branch4.Text = "";
            txtBank_AccountNo4.Text = "";
            txtBank_Number4.Text = "";
            cboBankRef5.Text = "";
            txtBank_Branch5.Text = "";
            txtBank_AccountNo5.Text = "";
            txtBank_Number5.Text = "";

            //Company Data
            txtCD_TIN.Text = "";
            txtCD_BIRNo.Text = "";
            txtCD_SECNo1.Text = "";
            txtCD_C13.Text = "";
            txtCD_SECNo2.Text = "";
            txtCD_NonVatReg.Text = "";
            txtCD_VatReg.Text = "";

            //Company Officials
            txtCO_Name1.Text = "";
            txtCO_Address1.Text = "";
            txtCO_Number1.Text = "";
            txtCO_Designation1.Text = "";
            txtCO_Name2.Text = "";
            txtCO_Address2.Text = "";
            txtCO_Number2.Text = "";
            txtCO_Designation2.Text = "";
            txtCO_Name3.Text = "";
            txtCO_Address3.Text = "";
            txtCO_Number3.Text = "";
            txtCO_Designation3.Text = "";

            //Stock Holders
            txtSH_Name1.Text = "";
            txtSH_Address1.Text = "";
            txtSH_Number1.Text = "";
            txtSH_Name2.Text = "";
            txtSH_Address2.Text = "";
            txtSH_Number2.Text = "";
            txtSH_Name3.Text = "";
            txtSH_Address3.Text = "";
            txtSH_Number3.Text = "";
        }

        private void LockForm(bool bLock)
        {
            grdContacts.Enabled = bLock;
            cboContactType.Enabled = bLock;

            //Contact Information
            txtCompanyName.Enabled = !bLock;
            txtCompanyAddress.Enabled = !bLock;
            txtCompanyTelNo.Enabled = !bLock;
            txtAgent.Enabled = !bLock;

            cboTerms.Enabled = !bLock;
            cboTermsPDC.Enabled = !bLock;
            txtCreditLimit.Enabled = !bLock;

            cboContactType2.Enabled = !bLock;
            txtFirstName.Enabled = !bLock;
            txtMiddleName.Enabled = !bLock;
            txtLastName.Enabled = !bLock;
            txtMobileNo.Enabled = !bLock;
            txtLandLineNo.Enabled = !bLock;
            txtFaxNo.Enabled = !bLock;
            txtAddress.Enabled = !bLock;

            //Contact Persons
            txtContactAccountingName1.Enabled = !bLock;
            txtContactAccountingNum1.Enabled = !bLock;
            txtContactPurchasingName.Enabled = !bLock;
            txtContactPurchasingNum.Enabled = !bLock;
            txtContactHeadOfficeName.Enabled = !bLock;
            txtContactHeadOfficeNum.Enabled = !bLock;

            //Business Reference
            txtBR_Name1.Enabled = !bLock;
            txtBR_Address1.Enabled = !bLock;
            txtBR_ContactPerson1.Enabled = !bLock;
            txtBR_Number1.Enabled = !bLock;
            txtBR_Name2.Enabled = !bLock;
            txtBR_Address2.Enabled = !bLock;
            txtBR_ContactPerson2.Enabled = !bLock;
            txtBR_Number2.Enabled = !bLock;
            txtBR_Name3.Enabled = !bLock;
            txtBR_Address3.Enabled = !bLock;
            txtBR_ContactPerson3.Enabled = !bLock;
            txtBR_Number3.Enabled = !bLock;

            //Bank Reference
            cboBankRef1.Enabled = !bLock;
            txtBank_Branch1.Enabled = !bLock;
            txtBank_AccountNo1.Enabled = !bLock;
            txtBank_Number1.Enabled = !bLock;
            cboBankRef2.Enabled = !bLock;
            txtBank_Branch2.Enabled = !bLock;
            txtBank_AccountNo2.Enabled = !bLock;
            txtBank_Number2.Enabled = !bLock;
            cboBankRef3.Enabled = !bLock;
            txtBank_Branch3.Enabled = !bLock;
            txtBank_AccountNo3.Enabled = !bLock;
            txtBank_Number3.Enabled = !bLock;
            //additional banks
            cboBankRef4.Enabled = !bLock;
            txtBank_Branch4.Enabled = !bLock;
            txtBank_AccountNo4.Enabled = !bLock;
            txtBank_Number4.Enabled = !bLock;
            cboBankRef5.Enabled = !bLock;
            txtBank_Branch5.Enabled = !bLock;
            txtBank_AccountNo5.Enabled = !bLock;
            txtBank_Number5.Enabled = !bLock;

            //Company Data
            txtCD_TIN.Enabled = !bLock;
            txtCD_BIRNo.Enabled = !bLock;
            txtCD_SECNo1.Enabled = !bLock;
            txtCD_C13.Enabled = !bLock;
            txtCD_SECNo2.Enabled = !bLock;
            txtCD_NonVatReg.Enabled = !bLock;
            txtCD_VatReg.Enabled = !bLock;

            //Company Officials
            txtCO_Name1.Enabled = !bLock;
            txtCO_Address1.Enabled = !bLock;
            txtCO_Number1.Enabled = !bLock;
            txtCO_Designation1.Enabled = !bLock;
            txtCO_Name2.Enabled = !bLock;
            txtCO_Address2.Enabled = !bLock;
            txtCO_Number2.Enabled = !bLock;
            txtCO_Designation2.Enabled = !bLock;
            txtCO_Name3.Enabled = !bLock;
            txtCO_Address3.Enabled = !bLock;
            txtCO_Number3.Enabled = !bLock;
            txtCO_Designation3.Enabled = !bLock;

            //Stock Holders
            txtSH_Name1.Enabled = !bLock;
            txtSH_Address1.Enabled = !bLock;
            txtSH_Number1.Enabled = !bLock;
            txtSH_Name2.Enabled = !bLock;
            txtSH_Address2.Enabled = !bLock;
            txtSH_Number2.Enabled = !bLock;
            txtSH_Name3.Enabled = !bLock;
            txtSH_Address3.Enabled = !bLock;
            txtSH_Number3.Enabled = !bLock;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            m_OperationType = eOperation.AddContact;
            ClearForm();
            LockForm(false);
            SetButton();
            tabContactInfo.Select();
            txtCompanyName.Focus();
        }

       

        private void btnEdit_Click(object sender, EventArgs e)
        {
            m_OperationType = eOperation.EditContact;
            //ClearForm();
            LockForm(false);
            SetButton();
            tabContactInfo.Select();
            txtCompanyName.Focus();
        }

        private void cboContactType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboContactType.SelectedIndex >= 0)
            {
                switch (cboContactType.Text.ToLower())
                {
                    case "all":
                        grdContacts.DataSource = mContactsDao.getAllRecords();
                        grdContacts.RefreshDataSource();
                        GetSelectedContactShowDetails();
                        break;
                    case "customers":
                        grdContacts.DataSource = mContactsDao.getAllCustomers();
                        break;
                    case "suppliers":
                       // if (clsUtil.getMainForm().g_Permissions.ContactsViewSuppliersManila == 0)
                        //    grdContacts.DataSource = mContactsDao.getAllSuppliers(true);
                       // else
                        grdContacts.DataSource = mContactsDao.getAllSuppliers(false);
                        break;
                    default:
                        grdContacts.DataSource = mContactsDao.GetAllRecordsByField("ContactType",
                                                                                  Contacts.GetContactType(cboContactType.Text));
                        grdContacts.RefreshDataSource();
                        GetSelectedContactShowDetails();
                        break;
                }

                if (grdContacts.DefaultView.RowCount == 0 )
                {
                    btnEdit.Enabled = false;
                }
                else 
                {
                    btnEdit.Enabled = true;
                }
            }
            else
            {
                //do nothing         
            }
        }

        private void grdvContacts_FocusedRowChanged(object sender,
                                                 DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetSelectedContactShowDetails();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Text == "&Delete")
            {
                if (
                   clsUtil.ShowMessage("Delete selected contact?", "Delete Contact", MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (m_SelectedContact != null)
                    {
                        try
                        {
                            mContactsDao.Delete(m_SelectedContact);
                            grdvContacts.DeleteRow(grdvContacts.GetSelectedRows()[0]);
                            GetSelectedContactShowDetails();
                            Boolean chk = CheckSelectedContact();
                            if (grdvContacts.RowCount <= 0 || chk)
                                btnEdit.Enabled = false;
                        }
                        catch
                        {
                            clsUtil.ShowMessageError(mContactsDao.ErrorMessage, "Error");
                        }
                    }
                }
            }
            else if (btnDelete.Text == "&Save")
            {
                if (m_OperationType == eOperation.AddContact)
                {
                    //new contact
                    m_SelectedContact = new Contacts();
                }

                m_SelectedContact.CompanyName = txtCompanyName.Text;
                m_SelectedContact.CompanyAddress = clsUtil.ParseString(txtCompanyAddress.Text,0,45);
                m_SelectedContact.CompanyContactNumber = txtCompanyTelNo.Text;

                try
                {
                    m_SelectedContact.Terms = Convert.ToInt32(cboTerms.Text);
                }
                catch
                {
                    m_SelectedContact.Terms = 0;
                }

                try
                {
                    m_SelectedContact.Terms_PDC = Convert.ToInt32(cboTermsPDC.Text);
                }
                catch
                {
                    m_SelectedContact.Terms_PDC = 0;
                }

                try
                {
                    m_SelectedContact.CreditLimit = Convert.ToDouble(txtCreditLimit.Text);
                }
                catch
                {
                    m_SelectedContact.CreditLimit = 0;
                }

                m_SelectedContact.ContactType = Contacts.GetContactType(cboContactType2.Text);

                if (m_SelectedContact.ContactType == -1)
                {
                    clsUtil.ShowMessageExclamation("Invalid contact type!", "Save Contact");
                    cboContactType2.Focus();
                    return;
                }

                m_SelectedContact.SalesRepresentative = txtAgent.Text;
                m_SelectedContact.FirstName = clsUtil.CleanStringFromGarbage(txtFirstName.Text);
                m_SelectedContact.MiddleName = txtMiddleName.Text;
                m_SelectedContact.LastName = txtLastName.Text;
                m_SelectedContact.MobileNumber = txtMobileNo.Text;
                m_SelectedContact.LandlineNumber = txtLandLineNo.Text;
                m_SelectedContact.FaxNumber = txtFaxNo.Text;
                m_SelectedContact.Address = txtAddress.Text;

                m_SelectedContact.Comp_Contact_Number_Accounting = txtContactAccountingNum1.Text;
                m_SelectedContact.Comp_Contact_Person_Accounting = txtContactAccountingName1.Text;
                m_SelectedContact.Comp_Contact_Person_HeadOffice = txtContactHeadOfficeName.Text;
                m_SelectedContact.Comp_Contact_Number_HeadOffice = txtContactHeadOfficeNum.Text;
                m_SelectedContact.Comp_Contact_Person_Purchasing = txtContactPurchasingName.Text;
                m_SelectedContact.Comp_Contact_Number_Purchasing = txtContactPurchasingNum.Text;

                m_SelectedContact.BusinessRef_Name1 = txtBR_Name1.Text;
                m_SelectedContact.BusinessRef_Number1 = txtBR_Number1.Text;
                m_SelectedContact.BusinessRef_ContactPerson1 = txtBR_ContactPerson1.Text;
                m_SelectedContact.BusinessRef_Address1 = clsUtil.ParseString(txtBR_Address1.Text,0,45);

                m_SelectedContact.BusinessRef_Name2 = txtBR_Name2.Text;
                m_SelectedContact.BusinessRef_Number2 = txtBR_Number2.Text;
                m_SelectedContact.BusinessRef_ContactPerson2 = txtBR_ContactPerson2.Text;
                m_SelectedContact.BusinessRef_Address2 = clsUtil.ParseString(txtBR_Address2.Text,0,45);

                m_SelectedContact.BusinessRef_Name3 = txtBR_Name3.Text;
                m_SelectedContact.BusinessRef_Number3 = txtBR_Number3.Text;
                m_SelectedContact.BusinessRef_ContactPerson3 = txtBR_ContactPerson3.Text;
                m_SelectedContact.BusinessRef_Address3 = clsUtil.ParseString(txtBR_Address3.Text,0,45);

                //bank 1
                m_SelectedContact.BankAccountNum1 = txtBank_AccountNo1.Text;
                m_SelectedContact.BankBranch1 = txtBank_Branch1.Text;
                m_SelectedContact.BankContactNumber1 = txtBank_Number1.Text;
                if (cboBankRef1.SelectedIndex != -1)
                    m_SelectedContact.BankRef1 = (Banks)cboBankRef1.SelectedItem;
                else
                    m_SelectedContact.BankRef1 = null;

                //bank 2
                m_SelectedContact.BankAccountNum2 = txtBank_AccountNo2.Text;
                m_SelectedContact.BankBranch2 = txtBank_Branch2.Text;
                m_SelectedContact.BankContactNumber2 = txtBank_Number2.Text;
                if (cboBankRef2.SelectedIndex != -1)
                    m_SelectedContact.BankRef2 = (Banks)cboBankRef2.SelectedItem;
                else
                    m_SelectedContact.BankRef2 = null;

                //bank 3
                m_SelectedContact.BankAccountNum3 = txtBank_AccountNo3.Text;
                m_SelectedContact.BankBranch3 = txtBank_Branch3.Text;
                m_SelectedContact.BankContactNumber3 = txtBank_Number3.Text;
                if (cboBankRef3.SelectedIndex != -1)
                    m_SelectedContact.BankRef3 = (Banks)cboBankRef3.SelectedItem;
                else
                    m_SelectedContact.BankRef3 = null;

                //bank 4
                m_SelectedContact.BankAccountNum4 = txtBank_AccountNo4.Text;
                m_SelectedContact.BankBranch4 = txtBank_Branch4.Text;
                m_SelectedContact.BankContactNumber4 = txtBank_Number4.Text;
                if (cboBankRef4.SelectedIndex != -1)
                    m_SelectedContact.BankRef4 = (Banks)cboBankRef4.SelectedItem;
                else
                    m_SelectedContact.BankRef4 = null;

                //bank 5
                m_SelectedContact.BankAccountNum5 = txtBank_AccountNo5.Text;
                m_SelectedContact.BankBranch5 = txtBank_Branch5.Text;
                m_SelectedContact.BankContactNumber5 = txtBank_Number5.Text;
                if (cboBankRef5.SelectedIndex != -1)
                    m_SelectedContact.BankRef5 = (Banks)cboBankRef5.SelectedItem;
                else
                    m_SelectedContact.BankRef5 = null;

                m_SelectedContact.Comp_BIR_Acc_No = txtCD_BIRNo.Text;
                m_SelectedContact.Comp_C13 = txtCD_C13.Text;
                m_SelectedContact.Comp_Non_Vat_Reg = txtCD_NonVatReg.Text;
                m_SelectedContact.Comp_SEC_Acc_No1 = txtCD_SECNo1.Text;
                m_SelectedContact.Comp_SEC_Acc_No2 = txtCD_SECNo2.Text;
                m_SelectedContact.Comp_TIN = txtCD_TIN.Text;

                m_SelectedContact.CompanyOfficial_Name1 = txtCO_Name1.Text;
                m_SelectedContact.CompanyOfficial_Number1 = txtCO_Number1.Text;
                m_SelectedContact.CompanyOfficial_Designation1 = txtCO_Designation1.Text;
                m_SelectedContact.CompanyOfficial_Address1 = clsUtil.ParseString(txtCO_Address1.Text,0,45);

                m_SelectedContact.CompanyOfficial_Name2 = txtCO_Name2.Text;
                m_SelectedContact.CompanyOfficial_Number2 = txtCO_Number2.Text;
                m_SelectedContact.CompanyOfficial_Designation2 = txtCO_Designation2.Text;
                m_SelectedContact.CompanyOfficial_Address2 = clsUtil.ParseString(txtCO_Address2.Text,0,45);

                m_SelectedContact.CompanyOfficial_Name3 = txtCO_Name3.Text;
                m_SelectedContact.CompanyOfficial_Number3 = txtCO_Number3.Text;
                m_SelectedContact.CompanyOfficial_Designation3 = txtCO_Designation3.Text;
                m_SelectedContact.CompanyOfficial_Address3 = clsUtil.ParseString(txtCO_Address3.Text,0,45);

                m_SelectedContact.StockHolderName1 = txtSH_Name1.Text;
                m_SelectedContact.StockHolderNumber1 = txtSH_Number1.Text;
                m_SelectedContact.StockHolderAddress1 = clsUtil.ParseString(txtSH_Address1.Text,0,45);

                m_SelectedContact.StockHolderName2 = txtSH_Name2.Text;
                m_SelectedContact.StockHolderNumber2 = txtSH_Number2.Text;
                m_SelectedContact.StockHolderAddress2 = clsUtil.ParseString(txtSH_Address2.Text,0,45);

                m_SelectedContact.StockHolderName3 = txtSH_Name3.Text;
                m_SelectedContact.StockHolderNumber3 = txtSH_Number3.Text;
                m_SelectedContact.StockHolderAddress3 = clsUtil.ParseString(txtSH_Address3.Text,0,45);

                try
                {
                    mContactsDao.Save(m_SelectedContact);
                    MessageBox.Show("Contact saved!", "Save Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (m_OperationType == eOperation.AddContact)
                    {
                        IList<Contacts> lst = (IList<Contacts>)grdContacts.DataSource;
                        lst.Add(m_SelectedContact);
                        grdContacts.DataSource = lst;
                        grdvContacts.RefreshData();

                        grdvContacts.OptionsSelection.MultiSelect = true;
                        grdvContacts.ClearSelection();
                        grdvContacts.SelectRow(lst.Count - 1);
                        //grdvContacts.OptionsSelection.MultiSelect = false;
                    }
                    else
                    {
                        grdvContacts.SetRowCellValue(grdvContacts.GetSelectedRows()[0], "ContactName",
                                                     m_SelectedContact.ToString());
                    }
                    m_OperationType = eOperation.ViewContacts;
                    SetButton();
                    LockForm(true);
                    //btnClose.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Save Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GetSelectedContactShowDetails()
        {
            Contacts C = (Contacts)grdvContacts.GetRow(grdvContacts.FocusedRowHandle);
            if (null != C)
            {
                m_SelectedContact = C;
                ShowContactDetails();
            }
            else
            {
                ClearForm();
            }
        }

        private Boolean CheckSelectedContact()
        {
            Contacts C = (Contacts)grdvContacts.GetRow(grdvContacts.FocusedRowHandle);
            if (null == C)
                return true;
            else
                return false;
        }

        private void ShowContactDetails()
        {
            lblIDNumber.Text = m_SelectedContact.ID.ToString();

            txtCompanyName.Text = m_SelectedContact.CompanyName;
            txtCompanyAddress.Text = m_SelectedContact.CompanyAddress;
            txtCompanyTelNo.Text = m_SelectedContact.CompanyContactNumber;
            txtAgent.Text = m_SelectedContact.SalesRepresentative;
            //if (m_SelectedContact.Agent != null)
            //    txtAgent.Text = m_SelectedContact.Agent.ToString();
            //else
            //    txtAgent.Text = "";

            cboTerms.Text = m_SelectedContact.Terms.ToString();
            cboTermsPDC.Text = m_SelectedContact.Terms_PDC.ToString();
            txtCreditLimit.Text = m_SelectedContact.CreditLimit.ToString("#,##0.00");

            cboContactType2.Text = Contacts.GetContactType((Contacts.eContactType)m_SelectedContact.ContactType);
            txtFirstName.Text = m_SelectedContact.FirstName;
            txtMiddleName.Text = m_SelectedContact.MiddleName;
            txtLastName.Text = m_SelectedContact.LastName;
            txtMobileNo.Text = m_SelectedContact.MobileNumber;
            txtLandLineNo.Text = m_SelectedContact.LandlineNumber;
            txtFaxNo.Text = m_SelectedContact.FaxNumber;
            txtAddress.Text = m_SelectedContact.Address;

            txtContactAccountingName1.Text = m_SelectedContact.Comp_Contact_Person_Accounting;
            txtContactAccountingNum1.Text = m_SelectedContact.Comp_Contact_Number_Accounting;
            txtContactHeadOfficeName.Text = m_SelectedContact.Comp_Contact_Person_HeadOffice;
            txtContactHeadOfficeNum.Text = m_SelectedContact.Comp_Contact_Number_HeadOffice;
            txtContactPurchasingName.Text = m_SelectedContact.Comp_Contact_Person_Purchasing;
            txtContactPurchasingNum.Text = m_SelectedContact.Comp_Contact_Number_Purchasing;

            txtBR_Name1.Text = m_SelectedContact.BusinessRef_Name1;
            txtBR_Number1.Text = m_SelectedContact.BusinessRef_Number1;
            txtBR_ContactPerson1.Text = m_SelectedContact.BusinessRef_ContactPerson1;
            txtBR_Address1.Text = m_SelectedContact.BusinessRef_Address1;

            txtBR_Name2.Text = m_SelectedContact.BusinessRef_Name2;
            txtBR_Number2.Text = m_SelectedContact.BusinessRef_Number2;
            txtBR_ContactPerson2.Text = m_SelectedContact.BusinessRef_ContactPerson2;
            txtBR_Address2.Text = m_SelectedContact.BusinessRef_Address2;

            txtBR_Name3.Text = m_SelectedContact.BusinessRef_Name3;
            txtBR_Number3.Text = m_SelectedContact.BusinessRef_Number3;
            txtBR_ContactPerson3.Text = m_SelectedContact.BusinessRef_ContactPerson3;
            txtBR_Address3.Text = m_SelectedContact.BusinessRef_Address3;

            txtBank_AccountNo1.Text = m_SelectedContact.BankAccountNum1;
            txtBank_Branch1.Text = m_SelectedContact.BankBranch1;
            txtBank_Number1.Text = m_SelectedContact.BankContactNumber1;
            if (m_SelectedContact.BankRef1 != null)
                cboBankRef1.SelectedIndex = clsUtil.GetComboItemIndexBanks(cboBankRef1, m_SelectedContact.BankRef1);
            else
                cboBankRef1.SelectedIndex = -1;

            txtBank_AccountNo2.Text = m_SelectedContact.BankAccountNum2;
            txtBank_Branch2.Text = m_SelectedContact.BankBranch2;
            txtBank_Number2.Text = m_SelectedContact.BankContactNumber2;
            if (m_SelectedContact.BankRef2 != null)
                cboBankRef2.SelectedIndex = clsUtil.GetComboItemIndexBanks(cboBankRef2, m_SelectedContact.BankRef2);
            else
                cboBankRef2.SelectedIndex = -1;

            txtBank_AccountNo3.Text = m_SelectedContact.BankAccountNum3;
            txtBank_Branch3.Text = m_SelectedContact.BankBranch3;
            txtBank_Number3.Text = m_SelectedContact.BankContactNumber3;
            if (m_SelectedContact.BankRef3 != null)
                cboBankRef3.SelectedIndex = clsUtil.GetComboItemIndexBanks(cboBankRef3, m_SelectedContact.BankRef3);
            else
                cboBankRef3.SelectedIndex = -1;

            txtBank_AccountNo4.Text = m_SelectedContact.BankAccountNum4;
            txtBank_Branch4.Text = m_SelectedContact.BankBranch4;
            txtBank_Number4.Text = m_SelectedContact.BankContactNumber4;
            if (m_SelectedContact.BankRef4 != null)
                cboBankRef4.SelectedIndex = clsUtil.GetComboItemIndexBanks(cboBankRef4, m_SelectedContact.BankRef4);
            else
                cboBankRef4.SelectedIndex = -1;

            txtBank_AccountNo5.Text = m_SelectedContact.BankAccountNum5;
            txtBank_Branch5.Text = m_SelectedContact.BankBranch5;
            txtBank_Number5.Text = m_SelectedContact.BankContactNumber5;
            if (m_SelectedContact.BankRef5 != null)
                cboBankRef5.SelectedIndex = clsUtil.GetComboItemIndexBanks(cboBankRef5, m_SelectedContact.BankRef5);
            else
                cboBankRef5.SelectedIndex = -1;

            txtCD_BIRNo.Text = m_SelectedContact.Comp_BIR_Acc_No;
            txtCD_C13.Text = m_SelectedContact.Comp_C13;
            txtCD_NonVatReg.Text = m_SelectedContact.Comp_Non_Vat_Reg;
            txtCD_SECNo1.Text = m_SelectedContact.Comp_SEC_Acc_No1;
            txtCD_SECNo2.Text = m_SelectedContact.Comp_SEC_Acc_No2;
            txtCD_TIN.Text = m_SelectedContact.Comp_TIN;

            txtCO_Name1.Text = m_SelectedContact.CompanyOfficial_Name1;
            txtCO_Number1.Text = m_SelectedContact.CompanyOfficial_Number1;
            txtCO_Designation1.Text = m_SelectedContact.CompanyOfficial_Designation1;
            txtCO_Address1.Text = m_SelectedContact.CompanyOfficial_Address1;

            txtCO_Name2.Text = m_SelectedContact.CompanyOfficial_Name2;
            txtCO_Number2.Text = m_SelectedContact.CompanyOfficial_Number2;
            txtCO_Designation2.Text = m_SelectedContact.CompanyOfficial_Designation2;
            txtCO_Address2.Text = m_SelectedContact.CompanyOfficial_Address2;

            txtCO_Name3.Text = m_SelectedContact.CompanyOfficial_Name3;
            txtCO_Number3.Text = m_SelectedContact.CompanyOfficial_Number3;
            txtCO_Designation3.Text = m_SelectedContact.CompanyOfficial_Designation3;
            txtCO_Address3.Text = m_SelectedContact.CompanyOfficial_Address3;

            txtSH_Name1.Text = m_SelectedContact.StockHolderName1;
            txtSH_Number1.Text = m_SelectedContact.StockHolderNumber1;
            txtSH_Address1.Text = m_SelectedContact.StockHolderAddress1;

            txtSH_Name2.Text = m_SelectedContact.StockHolderName2;
            txtSH_Number2.Text = m_SelectedContact.StockHolderNumber2;
            txtSH_Address2.Text = m_SelectedContact.StockHolderAddress2;

            txtSH_Name3.Text = m_SelectedContact.StockHolderName3;
            txtSH_Number3.Text = m_SelectedContact.StockHolderNumber3;
            txtSH_Address3.Text = m_SelectedContact.StockHolderAddress3;
        }

        private void grdvContacts_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            Contacts c = (Contacts)grdvContacts.GetRow(e.RowHandle);
            if (e.IsGetData && e.Column.FieldName == "ContactName")
            {
                e.Value = c.ToString();
            }
            else if (e.IsGetData && e.Column.FieldName == "_CreditVal")
            {
                e.Value = c.CreditLimit - c.CreditUsed;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnClose.Text == "&Close")
            {
                clsUtil.getMainForm().CloseCurrentControl();
            }
            else
            {
                //cancel
                ClearForm();
                m_SelectedContact = (Contacts)getSelectedCContact();
                if (m_SelectedContact != null)
                    ShowContactDetails();
                else
                    ClearForm();

                LockForm(true);
                m_OperationType = eOperation.ViewContacts;
                SetButton();
            }
        }

        private Contacts getSelectedCContact()
        {
            return (Contacts)grdvContacts.GetRow(grdvContacts.FocusedRowHandle);
        }

        private void txtCreditLimit_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            txtCreditLimit.Text = clsUtil.ParseDouble(txtCreditLimit.Text).ToString(clsUtil.FMT_AMOUNT);
        }

        private void ctlContacts_VisibleChanged(object sender, EventArgs e)
        {
            UserControl myUC = sender as UserControl;
            if (myUC.Visible == true && !m_bRunOnce)
            {
                LoadBankList();
                GetSelectedContactShowDetails();
            }

            if (m_bRunOnce)
                m_bRunOnce = false;
        }

    }
}
