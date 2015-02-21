namespace Engeline_LuckyEnt
{
    partial class frmMain2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssLoggedInUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.navBarMenu = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarMaintenance = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarMaintenance_Vans = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarMaintenance_Shipping = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarMaintenance_WHSetting = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarMaintenance_Users = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarViewers = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarViewers_Contacts = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarViewers_Inventory = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarViewers_PO = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarViewers_SOC = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarViewers_StockIn = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarViewers_ReturnedItems = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarViewers_SIV = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarViewers_LoanedItems = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarViewers_Agents = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarViewers_ItemBundles = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarViewers_Banks = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarViewers_Warehouse = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarViewers_ArrivedShipment = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarViewers_DamagedMissing = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarTransactions = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarTransactions_ItemRegistration = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarTransactions_SOC = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarTransactions_PO = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarTransactions_ReleaseOrder = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarTransactions_StockIn = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarTransactions_SICash = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarTransactions_SIAcct = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarTransactions_SIDR = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarTrans_NoPriceItems = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarUsers = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarUsers_Login = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarUsers_Logout = new DevExpress.XtraNavBar.NavBarItem();
            this.tlpBody = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.btnCloseAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrevious = new DevExpress.XtraEditors.SimpleButton();
            this.cboOpenWindows = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody = new DevExpress.XtraEditors.PanelControl();
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.navBarViewers_RequestApproval = new DevExpress.XtraNavBar.NavBarItem();
            this.statusStrip1.SuspendLayout();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarMenu)).BeginInit();
            this.tlpBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboOpenWindows.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLoggedInUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 517);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(888, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssLoggedInUser
            // 
            this.tssLoggedInUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tssLoggedInUser.Name = "tssLoggedInUser";
            this.tssLoggedInUser.Size = new System.Drawing.Size(93, 17);
            this.tssLoggedInUser.Text = "Logged in User: --";
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.navBarMenu, 0, 0);
            this.tlpMain.Controls.Add(this.tlpBody, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(888, 517);
            this.tlpMain.TabIndex = 1;
            // 
            // navBarMenu
            // 
            this.navBarMenu.ActiveGroup = this.navBarViewers;
            this.navBarMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarMenu.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarViewers,
            this.navBarTransactions,
            this.navBarUsers,
            this.navBarMaintenance});
            this.navBarMenu.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarUsers_Login,
            this.navBarUsers_Logout,
            this.navBarViewers_Contacts,
            this.navBarViewers_Banks,
            this.navBarViewers_Agents,
            this.navBarViewers_Inventory,
            this.navBarViewers_PO,
            this.navBarViewers_StockIn,
            this.navBarViewers_ReturnedItems,
            this.navBarViewers_LoanedItems,
            this.navBarViewers_ItemBundles,
            this.navBarTransactions_ItemRegistration,
            this.navBarTransactions_PO,
            this.navBarTransactions_StockIn,
            this.navBarTransactions_SICash,
            this.navBarTransactions_SIAcct,
            this.navBarTransactions_SIDR,
            this.navBarViewers_Warehouse,
            this.navBarMaintenance_WHSetting,
            this.navBarTrans_NoPriceItems,
            this.navBarTransactions_SOC,
            this.navBarMaintenance_Vans,
            this.navBarMaintenance_Shipping,
            this.navBarViewers_SOC,
            this.navBarViewers_ArrivedShipment,
            this.navBarViewers_SIV,
            this.navBarViewers_DamagedMissing,
            this.navBarTransactions_ReleaseOrder,
            this.navBarMaintenance_Users,
            this.navBarViewers_RequestApproval});
            this.navBarMenu.Location = new System.Drawing.Point(3, 3);
            this.navBarMenu.Name = "navBarMenu";
            this.navBarMenu.OptionsNavPane.ExpandedWidth = 140;
            this.navBarMenu.Size = new System.Drawing.Size(182, 511);
            this.navBarMenu.TabIndex = 0;
            this.navBarMenu.Text = "navBarControl1";
            this.navBarMenu.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinNavigationPaneViewInfoRegistrator("DevExpress Style");
            // 
            // navBarMaintenance
            // 
            this.navBarMaintenance.Caption = "Maintenance";
            this.navBarMaintenance.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarMaintenance_Vans),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarMaintenance_Shipping),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarMaintenance_WHSetting),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarMaintenance_Users)});
            this.navBarMaintenance.Name = "navBarMaintenance";
            // 
            // navBarMaintenance_Vans
            // 
            this.navBarMaintenance_Vans.Caption = "Pickup Vans";
            this.navBarMaintenance_Vans.Name = "navBarMaintenance_Vans";
            this.navBarMaintenance_Vans.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarMaintenance_Vans_LinkClicked);
            // 
            // navBarMaintenance_Shipping
            // 
            this.navBarMaintenance_Shipping.Caption = "Shipping Companies";
            this.navBarMaintenance_Shipping.Name = "navBarMaintenance_Shipping";
            this.navBarMaintenance_Shipping.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarMaintenance_Shipping_LinkClicked);
            // 
            // navBarMaintenance_WHSetting
            // 
            this.navBarMaintenance_WHSetting.Caption = "Warehouse";
            this.navBarMaintenance_WHSetting.Name = "navBarMaintenance_WHSetting";
            this.navBarMaintenance_WHSetting.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarMaintenance_WHSetting_LinkClicked);
            // 
            // navBarMaintenance_Users
            // 
            this.navBarMaintenance_Users.Caption = "User Account";
            this.navBarMaintenance_Users.Name = "navBarMaintenance_Users";
            this.navBarMaintenance_Users.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarMaintenance_Users_LinkClicked);
            // 
            // navBarViewers
            // 
            this.navBarViewers.Caption = "Viewers";
            this.navBarViewers.Expanded = true;
            this.navBarViewers.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarViewers_Contacts),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarViewers_Inventory),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarViewers_PO),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarViewers_SOC),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarViewers_StockIn),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarViewers_ReturnedItems),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarViewers_SIV),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarViewers_LoanedItems),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarViewers_Agents),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarViewers_ItemBundles),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarViewers_Banks),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarViewers_Warehouse),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarViewers_ArrivedShipment),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarViewers_DamagedMissing),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarViewers_RequestApproval)});
            this.navBarViewers.Name = "navBarViewers";
            this.navBarViewers.TopVisibleLinkIndex = 3;
            // 
            // navBarViewers_Contacts
            // 
            this.navBarViewers_Contacts.Caption = "Contacts";
            this.navBarViewers_Contacts.Name = "navBarViewers_Contacts";
            this.navBarViewers_Contacts.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarViewers_Contacts_LinkClicked);
            // 
            // navBarViewers_Inventory
            // 
            this.navBarViewers_Inventory.Caption = "Inventory";
            this.navBarViewers_Inventory.Name = "navBarViewers_Inventory";
            this.navBarViewers_Inventory.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarViewers_Inventory_LinkClicked);
            // 
            // navBarViewers_PO
            // 
            this.navBarViewers_PO.Caption = "Purchase Orders";
            this.navBarViewers_PO.Name = "navBarViewers_PO";
            this.navBarViewers_PO.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarViewers_PO_LinkClicked);
            // 
            // navBarViewers_SOC
            // 
            this.navBarViewers_SOC.Caption = "Statment of Account";
            this.navBarViewers_SOC.Name = "navBarViewers_SOC";
            this.navBarViewers_SOC.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarViewers_SOC_LinkClicked);
            // 
            // navBarViewers_StockIn
            // 
            this.navBarViewers_StockIn.Caption = "Stock In";
            this.navBarViewers_StockIn.Name = "navBarViewers_StockIn";
            this.navBarViewers_StockIn.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarViewers_StockIn_LinkClicked);
            // 
            // navBarViewers_ReturnedItems
            // 
            this.navBarViewers_ReturnedItems.Caption = "Returned Items";
            this.navBarViewers_ReturnedItems.Name = "navBarViewers_ReturnedItems";
            // 
            // navBarViewers_SIV
            // 
            this.navBarViewers_SIV.Caption = "Sales Invoice";
            this.navBarViewers_SIV.Name = "navBarViewers_SIV";
            this.navBarViewers_SIV.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarViewers_SIV_LinkClicked);
            // 
            // navBarViewers_LoanedItems
            // 
            this.navBarViewers_LoanedItems.Caption = "Loaned Items";
            this.navBarViewers_LoanedItems.Name = "navBarViewers_LoanedItems";
            // 
            // navBarViewers_Agents
            // 
            this.navBarViewers_Agents.Caption = "Agents";
            this.navBarViewers_Agents.Name = "navBarViewers_Agents";
            this.navBarViewers_Agents.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarViewers_Agents_LinkClicked);
            // 
            // navBarViewers_ItemBundles
            // 
            this.navBarViewers_ItemBundles.Caption = "Item Bundles";
            this.navBarViewers_ItemBundles.Name = "navBarViewers_ItemBundles";
            // 
            // navBarViewers_Banks
            // 
            this.navBarViewers_Banks.Caption = "Banks";
            this.navBarViewers_Banks.Name = "navBarViewers_Banks";
            this.navBarViewers_Banks.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarViewers_Banks_LinkClicked);
            // 
            // navBarViewers_Warehouse
            // 
            this.navBarViewers_Warehouse.Caption = "Warehouse";
            this.navBarViewers_Warehouse.Name = "navBarViewers_Warehouse";
            this.navBarViewers_Warehouse.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarViewers_Warehouse_LinkClicked);
            // 
            // navBarViewers_ArrivedShipment
            // 
            this.navBarViewers_ArrivedShipment.Caption = "Arrived Shipments";
            this.navBarViewers_ArrivedShipment.Name = "navBarViewers_ArrivedShipment";
            this.navBarViewers_ArrivedShipment.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarViewers_ArrivedShipment_LinkClicked);
            // 
            // navBarViewers_DamagedMissing
            // 
            this.navBarViewers_DamagedMissing.Caption = "Damaged & Missing";
            this.navBarViewers_DamagedMissing.Name = "navBarViewers_DamagedMissing";
            this.navBarViewers_DamagedMissing.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarViewers_DamagedMissing_LinkClicked);
            // 
            // navBarTransactions
            // 
            this.navBarTransactions.Caption = "Transactions";
            this.navBarTransactions.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarTransactions_ItemRegistration),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarTransactions_SOC),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarTransactions_PO),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarTransactions_ReleaseOrder),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarTransactions_StockIn),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarTransactions_SICash),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarTransactions_SIAcct),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarTransactions_SIDR),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarTrans_NoPriceItems)});
            this.navBarTransactions.Name = "navBarTransactions";
            // 
            // navBarTransactions_ItemRegistration
            // 
            this.navBarTransactions_ItemRegistration.Caption = "Item Registration";
            this.navBarTransactions_ItemRegistration.Name = "navBarTransactions_ItemRegistration";
            this.navBarTransactions_ItemRegistration.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarTransactions_ItemRegistration_LinkClicked);
            // 
            // navBarTransactions_SOC
            // 
            this.navBarTransactions_SOC.Caption = "Statement of Accounts";
            this.navBarTransactions_SOC.Name = "navBarTransactions_SOC";
            this.navBarTransactions_SOC.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarTransactions_SOC_LinkClicked);
            // 
            // navBarTransactions_PO
            // 
            this.navBarTransactions_PO.Caption = "Purchase Order";
            this.navBarTransactions_PO.Name = "navBarTransactions_PO";
            this.navBarTransactions_PO.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarTransactions_PO_LinkClicked);
            // 
            // navBarTransactions_ReleaseOrder
            // 
            this.navBarTransactions_ReleaseOrder.Caption = "Release Order";
            this.navBarTransactions_ReleaseOrder.Name = "navBarTransactions_ReleaseOrder";
            this.navBarTransactions_ReleaseOrder.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarTransactions_ReleaseOrder_LinkClicked);
            // 
            // navBarTransactions_StockIn
            // 
            this.navBarTransactions_StockIn.Caption = "Stock In";
            this.navBarTransactions_StockIn.Name = "navBarTransactions_StockIn";
            this.navBarTransactions_StockIn.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarTransactions_StockIn_LinkClicked);
            // 
            // navBarTransactions_SICash
            // 
            this.navBarTransactions_SICash.Caption = "SIV - Cash";
            this.navBarTransactions_SICash.Name = "navBarTransactions_SICash";
            this.navBarTransactions_SICash.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarTransactions_SICash_LinkClicked);
            // 
            // navBarTransactions_SIAcct
            // 
            this.navBarTransactions_SIAcct.Caption = "SIV - Accounts";
            this.navBarTransactions_SIAcct.Name = "navBarTransactions_SIAcct";
            this.navBarTransactions_SIAcct.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarTransactions_SIAcct_LinkClicked);
            // 
            // navBarTransactions_SIDR
            // 
            this.navBarTransactions_SIDR.Caption = "SIV - D.R.";
            this.navBarTransactions_SIDR.Name = "navBarTransactions_SIDR";
            this.navBarTransactions_SIDR.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarTransactions_SIDR_LinkClicked);
            // 
            // navBarTrans_NoPriceItems
            // 
            this.navBarTrans_NoPriceItems.Caption = "No Price Items";
            this.navBarTrans_NoPriceItems.Name = "navBarTrans_NoPriceItems";
            this.navBarTrans_NoPriceItems.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarTrans_NoPriceItems_LinkClicked);
            // 
            // navBarUsers
            // 
            this.navBarUsers.Caption = "Users";
            this.navBarUsers.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarUsers_Login),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarUsers_Logout)});
            this.navBarUsers.Name = "navBarUsers";
            // 
            // navBarUsers_Login
            // 
            this.navBarUsers_Login.Caption = "Login";
            this.navBarUsers_Login.Name = "navBarUsers_Login";
            this.navBarUsers_Login.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarUsers_Login_LinkClicked);
            // 
            // navBarUsers_Logout
            // 
            this.navBarUsers_Logout.Caption = "Logout";
            this.navBarUsers_Logout.Name = "navBarUsers_Logout";
            this.navBarUsers_Logout.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarUsers_Logout_LinkClicked);
            // 
            // tlpBody
            // 
            this.tlpBody.ColumnCount = 1;
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBody.Controls.Add(this.pnlHeader, 0, 0);
            this.tlpBody.Controls.Add(this.pnlBody, 0, 1);
            this.tlpBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBody.Location = new System.Drawing.Point(191, 3);
            this.tlpBody.Name = "tlpBody";
            this.tlpBody.RowCount = 2;
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.06849F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.9315F));
            this.tlpBody.Size = new System.Drawing.Size(694, 511);
            this.tlpBody.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnCloseAll);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.btnNext);
            this.pnlHeader.Controls.Add(this.btnPrevious);
            this.pnlHeader.Controls.Add(this.cboOpenWindows);
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Controls.Add(this.lblTime);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(688, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnCloseAll
            // 
            this.btnCloseAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseAll.Location = new System.Drawing.Point(626, 43);
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.Size = new System.Drawing.Size(52, 23);
            this.btnCloseAll.TabIndex = 17;
            this.btnCloseAll.Text = "Close All";
            this.btnCloseAll.Click += new System.EventHandler(this.btnCloseAll_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(579, 43);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(41, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(390, 43);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(27, 23);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Location = new System.Drawing.Point(357, 43);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(27, 23);
            this.btnPrevious.TabIndex = 13;
            this.btnPrevious.Text = "<";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // cboOpenWindows
            // 
            this.cboOpenWindows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOpenWindows.Location = new System.Drawing.Point(423, 46);
            this.cboOpenWindows.Name = "cboOpenWindows";
            this.cboOpenWindows.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboOpenWindows.Size = new System.Drawing.Size(150, 20);
            this.cboOpenWindows.TabIndex = 14;
            this.cboOpenWindows.SelectedIndexChanged += new System.EventHandler(this.cboOpenWindows_SelectedIndexChanged);
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Location = new System.Drawing.Point(10, 46);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(15, 13);
            this.lblSubTitle.TabIndex = 7;
            this.lblSubTitle.Text = "[]";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.Location = new System.Drawing.Point(503, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(179, 22);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "label1";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(9, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(152, 19);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Lucky Enterprises";
            // 
            // pnlBody
            // 
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(3, 79);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(688, 429);
            this.pnlBody.TabIndex = 1;
            // 
            // tmrTime
            // 
            this.tmrTime.Enabled = true;
            this.tmrTime.Interval = 1000;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
            // 
            // navBarViewers_RequestApproval
            // 
            this.navBarViewers_RequestApproval.Caption = "Request Approval";
            this.navBarViewers_RequestApproval.Name = "navBarViewers_RequestApproval";
            this.navBarViewers_RequestApproval.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarViewers_RequestApproval_LinkClicked);
            // 
            // frmMain2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 539);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmMain2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Engeline";
            this.Load += new System.EventHandler(this.frmMain2_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarMenu)).EndInit();
            this.tlpBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboOpenWindows.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssLoggedInUser;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private DevExpress.XtraNavBar.NavBarControl navBarMenu;
        private DevExpress.XtraNavBar.NavBarGroup navBarViewers;
        private DevExpress.XtraNavBar.NavBarItem navBarViewers_Agents;
        private DevExpress.XtraNavBar.NavBarItem navBarViewers_Banks;
        private DevExpress.XtraNavBar.NavBarItem navBarViewers_Contacts;
        private DevExpress.XtraNavBar.NavBarGroup navBarUsers;
        private DevExpress.XtraNavBar.NavBarItem navBarUsers_Login;
        private DevExpress.XtraNavBar.NavBarItem navBarUsers_Logout;
        private System.Windows.Forms.TableLayoutPanel tlpBody;
        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.PanelControl pnlBody;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblTime;
        public DevExpress.XtraEditors.ComboBoxEdit cboOpenWindows;
        private DevExpress.XtraEditors.SimpleButton btnCloseAll;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnPrevious;
        private System.Windows.Forms.Timer tmrTime;
        private DevExpress.XtraNavBar.NavBarItem navBarViewers_Inventory;
        private DevExpress.XtraNavBar.NavBarItem navBarViewers_PO;
        private DevExpress.XtraNavBar.NavBarItem navBarViewers_StockIn;
        private DevExpress.XtraNavBar.NavBarItem navBarViewers_ReturnedItems;
        private DevExpress.XtraNavBar.NavBarItem navBarViewers_LoanedItems;
        private DevExpress.XtraNavBar.NavBarItem navBarViewers_ItemBundles;
        private DevExpress.XtraNavBar.NavBarGroup navBarTransactions;
        private DevExpress.XtraNavBar.NavBarItem navBarTransactions_ItemRegistration;
        private DevExpress.XtraNavBar.NavBarItem navBarTransactions_PO;
        private DevExpress.XtraNavBar.NavBarItem navBarTransactions_StockIn;
        private DevExpress.XtraNavBar.NavBarItem navBarTransactions_SICash;
        private DevExpress.XtraNavBar.NavBarItem navBarTransactions_SIAcct;
        private DevExpress.XtraNavBar.NavBarItem navBarTransactions_SIDR;
        private DevExpress.XtraNavBar.NavBarItem navBarViewers_Warehouse;
        private DevExpress.XtraNavBar.NavBarGroup navBarMaintenance;
        private DevExpress.XtraNavBar.NavBarItem navBarMaintenance_WHSetting;
        private DevExpress.XtraNavBar.NavBarItem navBarTrans_NoPriceItems;
        private DevExpress.XtraNavBar.NavBarItem navBarTransactions_SOC;
        private DevExpress.XtraNavBar.NavBarItem navBarMaintenance_Vans;
        private DevExpress.XtraNavBar.NavBarItem navBarMaintenance_Shipping;
        private DevExpress.XtraNavBar.NavBarItem navBarViewers_SOC;
        private DevExpress.XtraNavBar.NavBarItem navBarViewers_ArrivedShipment;
        private DevExpress.XtraNavBar.NavBarItem navBarViewers_SIV;
        private DevExpress.XtraNavBar.NavBarItem navBarViewers_DamagedMissing;
        private DevExpress.XtraNavBar.NavBarItem navBarTransactions_ReleaseOrder;
        private DevExpress.XtraNavBar.NavBarItem navBarMaintenance_Users;
        private DevExpress.XtraNavBar.NavBarItem navBarViewers_RequestApproval;
    }
}