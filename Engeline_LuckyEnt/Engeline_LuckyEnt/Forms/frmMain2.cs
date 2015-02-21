#region

using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using Engeline_LuckyEnt.Forms;
using Engeline_LuckyEnt.UI_Controls;
using Engeline_LuckyEnt.Classes;
//using DexterHardware_v2.UI_Controls.Accounting;
using Engeline_LuckyEnt.UI_Controls.Transactions;
using Engeline_LuckyEnt.UI_Controls.Utilities;
using Engeline_LuckyEnt.UI_Controls.Viewers;
using Engeline_LuckyEnt.UI_Controls.User;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt
{
    public partial class frmMain2 : DevExpress.XtraEditors.XtraForm
    {
        public static frmMain2 m_frmMainInstance = null;
        private UsersDao UsersDao = null;
        //private UserPermissionsDao mUserPermissionsDao = null;
        //private SalesInvoiceDao mSalesInvoiceDao = null;

        private UserControl m_CurrentControl = null;
        private bool m_bAllowLoad = false;

        private const string DEFAULT_TITLE = "Lucky Enterprises";

        public Users g_LoggedInUser { get; set; }
        public UserPermissions g_Permissions { get; set; }

        public frmMain2()
        {
            InitializeComponent();

            UsersDao = new UsersDao();
            //mUserPermissionsDao = new UserPermissionsDao();
            //mSalesInvoiceDao = new SalesInvoiceDao();

            m_frmMainInstance = this;
        }

        private void navBarViewers_Contacts_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            /*ContactsDao dao = new ContactsDao();
            IList<Contacts> _contacts = dao.getAllCustomers();

            MessageBox.Show(_contacts[0].Address);*/

            ctlContacts ctl = new ctlContacts();
            LoadCtl(ctl, true, "Contacts List", "Manage Contacts", true);

        }

        public void LoadCtl(object ctl, bool bDispose, string Title1, string Title2, bool bDockFill)
        {
            if (bDockFill)
                LoadCtl(ctl, bDispose, Title1, Title2, bDockFill, DockStyle.Fill);
            else
                LoadCtl(ctl, bDispose, Title1, Title2, false, DockStyle.None);
            return;            
            
           

            int index;
            pnlBody.Hide();
            pnlBody.Visible = false;
            ((UserControl)ctl).Visible = false;

            //dispose current ctl on display
            if (bDispose)
            {
                pnlBody.Controls.Clear();
            }

            //add control to container
            index = pnlBody.Controls.Count - 1;
            if (index >= 0)
            {
                //hide last shown control
                pnlBody.Controls[index].Visible = false;
            }
            pnlBody.Controls.Add((UserControl)ctl);

            //save titles
            ((UserControl)ctl).Tag = Title1 + ";" + Title2;

            lblTitle.Text = Title1;
            lblSubTitle.Text = Title2;

            if (bDockFill)
                ((UserControl)ctl).Dock = DockStyle.Fill;

            ((UserControl)ctl).Visible = true;
            pnlBody.Show();
            pnlBody.Visible = true;
        }

        public void LoadCtl(object ctl, bool bDispose, string Title1, string Title2, bool bDockFill, DockStyle dockStyle)
        {
            int index;

            //check if same control already in view
            index = cboOpenWindows.Properties.Items.IndexOf(Title1);
            if (index != -1)
            {
                //control already added, show this control
                if (index != cboOpenWindows.SelectedIndex)
                {
                    cboOpenWindows.SelectedIndex = index;
                }
                return;
            }

            pnlBody.Hide();
            pnlBody.Visible = false;

            //hide current control displayed
            if (m_CurrentControl != null)
                m_CurrentControl.Visible = false;

            m_CurrentControl = (UserControl)ctl;
            m_CurrentControl.Visible = false;

            //dispose current ctl on display
            if (bDispose)
            {
                //this is no longer used
                //pnlBody.Controls.Clear();
                //cboOpenWindows.Properties.Items.Clear();
            }
            pnlBody.Controls.Add((UserControl)ctl);

            m_bAllowLoad = false;
            cboOpenWindows.Properties.Items.Add(Title1);
            cboOpenWindows.SelectedIndex = cboOpenWindows.Properties.Items.Count - 1;
            cboOpenWindows.ToolTip = Title1;
            m_bAllowLoad = true;
            CheckButtonStates();

            //save titles
            //((UserControl) ctl).Tag = Title1 + ";" + Title2;
            m_CurrentControl.Tag = Title1 + ";" + Title2; ;

            lblTitle.Text = Title1;
            lblSubTitle.Text = Title2;

            if (bDockFill)
            {
                m_CurrentControl.Dock = dockStyle;
            }
            else
            {
                m_CurrentControl.Dock = DockStyle.None;
            }

            m_CurrentControl.Visible = true;
            pnlBody.Show();
            pnlBody.Visible = true;
        }

        private void LoadCtl(int index)
        {
            m_CurrentControl.Visible = false;

            m_CurrentControl = (UserControl)pnlBody.Controls[index];

            string sTitle = m_CurrentControl.Tag.ToString();
            int iSeparator = sTitle.IndexOf(";", 0);

            lblTitle.Text = sTitle.Substring(0, iSeparator);
            lblSubTitle.Text = sTitle.Substring(iSeparator + 1);
            cboOpenWindows.ToolTip = lblTitle.Text;
            CheckButtonStates();
            m_CurrentControl.Visible = true;
        }

        private void CheckButtonStates()
        {
            if (cboOpenWindows.Properties.Items.Count < 2)
            {
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
            }
            else
            {


                if (cboOpenWindows.SelectedIndex == cboOpenWindows.Properties.Items.Count - 1)
                {
                    btnNext.Enabled = false;
                    btnPrevious.Enabled = true;
                }
                else if (cboOpenWindows.SelectedIndex == 0)
                {
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = true;
                }
                else
                {
                    btnNext.Enabled = true;
                    btnPrevious.Enabled = true;
                }
            }

            if (cboOpenWindows.Properties.Items.Count > 0)
            {
                btnClose.Enabled = true;
                btnCloseAll.Enabled = true;
            }
            else
            {
                btnClose.Enabled = false;
                btnCloseAll.Enabled = false;
            }
        }

        private void frmMain2_Load(object sender, EventArgs e)
        {
            DisableFunctions(true);
            HideUnusedMenuButtons();
            navBarUsers_Login.Enabled = true;
            navBarUsers_Logout.Enabled = false;
            lblTime.Text = DateTime.Now.ToString("MMM dd, yyyy hh:mm tt");

            //remove old request approvals
            /*RequestApprovalDao mApprovalDao = new RequestApprovalDao(); temporary no request approval yet
            mApprovalDao.RemoveOldPendingRequests(DateTime.Now.AddHours(-3));*/

            Thread.Sleep(5000);
            //DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();

            //make company profile if it doesn't exist
            CompanyProfileDao dao = new CompanyProfileDao();
            CompanyProfile cp = dao.GetCompanyProfile();
            if (cp == null)
            {
                cp = new CompanyProfile();
                cp.CompanyName = "Company A";
                try
                {
                    dao.Save(cp);
                }
                catch
                {
                    clsUtil.ShowMessageError(dao.ErrorMessage, "Create Company Profile");
                }
            }

            CheckButtonStates();

            this.WindowState = FormWindowState.Maximized;
            this.Refresh();
            this.Show();

            ctlUserLogin ctl = new ctlUserLogin();
            ShowLogin(ctl);
            tmrTime.Enabled = true;
        }

        private void ShowLogin(ctlUserLogin ctl)
        {
            //ctlUserLogin ctl = new ctlUserLogin();
            frmGenericPopup frm = new frmGenericPopup();

            frm.Text = "User Login";
            frm.ShowCtl(ctl);

            if (!ctl.Canceled)
            {
                //successful login, apply user restrictions
                DisableFunctions(false);
                navBarUsers_Login.Enabled = false;
                navBarUsers_Logout.Enabled = true;

                //ApplyUserRestrictions();

                //Expand Transctions
                 //temporary not yet to implement, [hcf]
                //navBarTransactions.Expanded = true;
                navBarViewers.Expanded = true;

                tssLoggedInUser.Text = string.Format("Logged in user: {0}", g_LoggedInUser.UserName);

                //check arrived shipments
                StatementofAccountDao socdao = new StatementofAccountDao();
                IList<StatementofAccount> lstSoC = socdao.GetAllArrivedShipment(DateTime.Today, DateTime.Today);
                if (lstSoC.Count > 0)
                {
                    clsUtil.ShowMessageExclamation(string.Format("{0} Shipment(s) Arrived.", lstSoC.Count), "Shipments");
                }

                //check SIV for counter
                 //temporary not yet to implement, [hcf]
                /*SalesInvoiceDao dao = new SalesInvoiceDao();
                DateTime dueDate = SalesInvoice.GetDueDate(DateTime.Now, 0);
                if (dao.getAllRecordsForCounter(0, dueDate).Count > 0)
                {
                    clsUtil.ShowMessageInformation("Some Invoice are ready for counter!", "Counter");
                }

                //check PDC for clearing
                PaymentsPDCDao dao2 = new PaymentsPDCDao();
                if (dao2.GetChecksForClearing(DateTime.Now).Count > 0)
                {
                    clsUtil.ShowMessageInformation("Some Checks are ready for clearing today!", "Checks for Clearing");
                }*/
            }
        }

        public void CloseCurrentControl()
        {
            int index = cboOpenWindows.SelectedIndex;

            //remove ctl
            m_bAllowLoad = false;
            m_CurrentControl.Visible = false;
            try
            {
                pnlBody.Controls.RemoveAt(index);
                cboOpenWindows.Properties.Items.RemoveAt(index);
            }
            catch (Exception)
            {
            }

            //get new index
            if (cboOpenWindows.Properties.Items.Count > 0)
            {
                if (index <= cboOpenWindows.Properties.Items.Count - 1)
                { }
                else
                {
                    index--;
                }
                if (index >= 0)
                {
                    cboOpenWindows.SelectedIndex = index;
                    LoadCtl(index);
                }
                m_bAllowLoad = true;
            }
            else
            {
                cboOpenWindows.Text = "";
                lblTitle.Text = DEFAULT_TITLE;
                lblSubTitle.Text = "";
                cboOpenWindows.ToolTip = "";
            }
            CheckButtonStates();
        }

        private void DisableFunctions(bool bSet)
        {
            //Disable functions
            navBarViewers.Visible = !bSet;
            navBarTransactions.Visible = !bSet;
            navBarMaintenance.Visible = !bSet;
            //navBarAccounting.Visible = !bSet; temporary 
            //navBarMaintenance.Visible = !bSet; temporary
        }

        private void navBarViewers_Banks_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlViewBanks ctl = new ctlViewBanks();
            LoadCtl(ctl, true, "Banks", "Manage Banks List", true);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (cboOpenWindows.Properties.Items.Count > 1 && cboOpenWindows.SelectedIndex > 0)
                cboOpenWindows.SelectedIndex = cboOpenWindows.SelectedIndex - 1;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cboOpenWindows.Properties.Items.Count > 1 && cboOpenWindows.SelectedIndex < cboOpenWindows.Properties.Items.Count - 1)
                cboOpenWindows.SelectedIndex = cboOpenWindows.SelectedIndex + 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseCurrentControl();
        }

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            if (clsUtil.ShowMessageYesNo("This will close ALL open windows.\nDo you wish to proceed?", "Close All Windows") == DialogResult.Yes)
            {
                //close all open windows
                m_bAllowLoad = false;
                m_CurrentControl = null;

                pnlBody.Controls.Clear();
                cboOpenWindows.Properties.Items.Clear();
                cboOpenWindows.Text = "";

                lblTitle.Text = DEFAULT_TITLE;
                lblSubTitle.Text = "";
                cboOpenWindows.ToolTip = "";
                CheckButtonStates();
            }
        }

        private void cboOpenWindows_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_bAllowLoad)
                return;

            if (cboOpenWindows.SelectedIndex != -1)
            {
                LoadCtl(cboOpenWindows.SelectedIndex);
                cboOpenWindows.ToolTip = cboOpenWindows.Text;
                return;
            }
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("MMM dd, yyyy hh:mm tt");
        }

        private void navBarUsers_Logout_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (clsUtil.ShowMessage("Logout user?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
             DialogResult.Yes)
            {
                //Disable functions
                pnlBody.Controls.Clear();
                DisableFunctions(true);

                navBarUsers_Login.Enabled = true;
                navBarUsers_Logout.Enabled = false;

                ctlUserLogin ctl = new ctlUserLogin();
                ShowLogin(ctl);
            }
        }

        private void navBarViewers_Agents_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlViewAgents ctl = new ctlViewAgents();
            clsUtil.getMainForm().LoadCtl(ctl, true, "View Agent Commission Settings", "", false);
        }

        private void navBarUsers_Login_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlUserLogin ctl = new ctlUserLogin();
            ShowLogin(ctl);
        }

        private void navBarViewers_Inventory_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlViewInventory ctl = new ctlViewInventory();
            clsUtil.getMainForm().LoadCtl(ctl, true, "Inventory Viewer", "", true, DockStyle.Left);
        }

        private void navBarViewers_PO_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlViewPurchaseOrders ctl = new ctlViewPurchaseOrders();
            LoadCtl(ctl, true, "Purchase Orders", "", true, DockStyle.Left);
        }

        private void navBarViewers_StockIn_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlViewStockIn ctl = new ctlViewStockIn();
            LoadCtl(ctl, true, "Manage Stock In", "", true, DockStyle.Left);
        }

        private void navBarTransactions_ItemRegistration_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlItems ctl = new ctlItems();
            LoadCtl(ctl, true, "Item Registration", "Manage Items", true);
        }

        private void navBarTransactions_PO_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            /*if (clsUtil.GetUserPermissions().PO_Add != 1)
            {
                clsUtil.ShowMessagePermissionNotAllowed();
                return;
            }*/
            
            ctlPurchaseOrder ctl = new ctlPurchaseOrder();
            LoadCtl(ctl, true, "New Purchase Order", "", false);
        }

        private void navBarTransactions_StockIn_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
           /* if (clsUtil.GetUserPermissions().SI_Add != 1)
            {
                clsUtil.ShowMessagePermissionNotAllowed();
                return;
            }*/
            ctlStockIn ctl = new ctlStockIn();
            LoadCtl(ctl, true, "New Stock In", "", false);
        }

        private void navBarTransactions_SICash_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            /*if (clsUtil.GetUserPermissions().SIV_Add != 1)
            {
                clsUtil.ShowMessagePermissionNotAllowed();
                return;
            }*/
            ctlSalesInvoice ctl = new ctlSalesInvoice();
            ctl.m_InvoiceType = SalesInvoice.eInvoiceType.Cash;
            clsUtil.getMainForm().LoadCtl(ctl, false, "New Cash Invoice", "", false);
        }

        private void navBarTransactions_SIDR_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            /*if (clsUtil.GetUserPermissions().SIV_Add != 1)
            {
                clsUtil.ShowMessagePermissionNotAllowed();
                return;
            }*/
            ctlSalesInvoice ctl = new ctlSalesInvoice();
            ctl.m_InvoiceType = SalesInvoice.eInvoiceType.DeliveryReceipt;
            clsUtil.getMainForm().LoadCtl(ctl, false, "New Delivery Receipt", "", false);
        }


        private void HideUnusedMenuButtons()
        {
            navBarTransactions_PO.Visible = false;
            navBarViewers_ReturnedItems.Visible = false;
            navBarViewers_LoanedItems.Visible = false;
            navBarViewers_ItemBundles.Visible = false;
            navBarViewers_PO.Visible = false;
        }

        private void navBarViewers_Warehouse_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlViewWarehouse ctl = new ctlViewWarehouse();
            LoadCtl(ctl, true, "Warehouse", "Manage Warehouse List", true);
        }

        private void navBarMaintenance_WHSetting_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlWarehouse ctl = new ctlWarehouse();
            LoadCtl(ctl, true, "Warehouse Information", "Update Warehouse profile", false);
        }

        private void navBarTrans_NoPriceItems_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlNoPriceItems ctl = new ctlNoPriceItems();
            clsUtil.getMainForm().LoadCtl(ctl, true, "Set Item Price", "", true, DockStyle.Left);
        }

        private void navBarTransactions_SOC_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlStateofAccounts ctl = new ctlStateofAccounts();
            clsUtil.getMainForm().LoadCtl(ctl, true, "New Statement of Account", "Add a Statement of Account", true, DockStyle.Left);
        }

        private void navBarMaintenance_Vans_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlVantrackers ctl = new ctlVantrackers();
            clsUtil.getMainForm().LoadCtl(ctl, true, "Vans", "Add a Van", true, DockStyle.Left);
        }

        private void navBarMaintenance_Shipping_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlShipping ctl = new ctlShipping();
            clsUtil.getMainForm().LoadCtl(ctl, true, "Shipping Companies", "Add a Shipping Company", true, DockStyle.Left);
        }

        private void navBarViewers_SOC_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlViewStatement ctl = new ctlViewStatement();
            clsUtil.getMainForm().LoadCtl(ctl, true, "Statement of Accounts Viewer", "", false);
        }

        private void navBarViewers_ArrivedShipment_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlViewArriveShipment ctl = new ctlViewArriveShipment();
            clsUtil.getMainForm().LoadCtl(ctl, true, "Arrived Shipments", "", true, DockStyle.Left);
        }

        private void navBarViewers_SIV_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlViewSalesInvoice ctl = new ctlViewSalesInvoice();
            LoadCtl(ctl, true, "Sales Invoice Stock In", "", true, DockStyle.Left);
        }

        private void navBarTransactions_SIAcct_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlSalesInvoice ctl = new ctlSalesInvoice();
            ctl.m_InvoiceType = SalesInvoice.eInvoiceType.Accounts;
            clsUtil.getMainForm().LoadCtl(ctl, false, "New Account Invoice", "", false);
        }

        private void navBarViewers_DamagedMissing_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlViewDamagedMissing ctl = new ctlViewDamagedMissing();
            clsUtil.getMainForm().LoadCtl(ctl, false, "Damaged & Missing", "", false);
        }

        private void navBarTransactions_ReleaseOrder_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlReleaseOrder ctl = new ctlReleaseOrder();
            clsUtil.getMainForm().LoadCtl(ctl, false, "Release Order", "", true, DockStyle.Left);
        }

        private void navBarMaintenance_Users_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlUsers ctl = new ctlUsers();
            LoadCtl(ctl, true, "User Accounts", "Manage User Accounts", false);
        }

        private void navBarViewers_RequestApproval_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ctlViewRequestApproval ctl = new ctlViewRequestApproval();
            LoadCtl(ctl, true, "Request Approval", "Request Approvals", false);
        }
    }
}