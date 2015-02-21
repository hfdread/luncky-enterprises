namespace DexterHardware_v2.UI_Controls
{
   partial class ctlDailySalesSummary
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
         this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
         this.dtDateRange = new DexterHardware_v2.UI_Controls.ctlDateRange();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
         this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
         this.btnCLose = new DevExpress.XtraEditors.SimpleButton();
         this.tabData = new DevExpress.XtraTab.XtraTabControl();
         this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
         this.treeInvoice = new DevExpress.XtraTreeList.TreeList();
         this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
         this.treeListColumn18 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
         this.treePayments = new DevExpress.XtraTreeList.TreeList();
         this.treeListColumn8 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn11 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn12 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn10 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn9 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn15 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn16 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn17 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn13 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn14 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
         this.treeListColumn19 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.tlpMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
         this.pnlHeader.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
         this.pnlFooter.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.tabData)).BeginInit();
         this.tabData.SuspendLayout();
         this.xtraTabPage1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.treeInvoice)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
         this.xtraTabPage2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.treePayments)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
         this.SuspendLayout();
         // 
         // tlpMain
         // 
         this.tlpMain.ColumnCount = 1;
         this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
         this.tlpMain.Controls.Add(this.pnlFooter, 0, 2);
         this.tlpMain.Controls.Add(this.tabData, 0, 1);
         this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tlpMain.Location = new System.Drawing.Point(0, 0);
         this.tlpMain.Name = "tlpMain";
         this.tlpMain.RowCount = 3;
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
         this.tlpMain.Size = new System.Drawing.Size(944, 515);
         this.tlpMain.TabIndex = 0;
         // 
         // pnlHeader
         // 
         this.pnlHeader.Controls.Add(this.dtDateRange);
         this.pnlHeader.Controls.Add(this.labelControl1);
         this.pnlHeader.Controls.Add(this.btnRefresh);
         this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlHeader.Location = new System.Drawing.Point(3, 3);
         this.pnlHeader.Name = "pnlHeader";
         this.pnlHeader.Size = new System.Drawing.Size(938, 43);
         this.pnlHeader.TabIndex = 0;
         // 
         // dtDateRange
         // 
         this.dtDateRange.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.dtDateRange.Location = new System.Drawing.Point(44, 7);
         this.dtDateRange.Name = "dtDateRange";
         this.dtDateRange.Size = new System.Drawing.Size(442, 28);
         this.dtDateRange.TabIndex = 1;
         this.dtDateRange.DateSelectionChanged += new System.EventHandler(this.dtDateRange_DateSelectionChanged);
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(14, 14);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(23, 13);
         this.labelControl1.TabIndex = 0;
         this.labelControl1.Text = "Date";
         // 
         // btnRefresh
         // 
         this.btnRefresh.Location = new System.Drawing.Point(493, 10);
         this.btnRefresh.Name = "btnRefresh";
         this.btnRefresh.Size = new System.Drawing.Size(75, 23);
         this.btnRefresh.TabIndex = 2;
         this.btnRefresh.Text = "&Refresh";
         this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
         // 
         // pnlFooter
         // 
         this.pnlFooter.Controls.Add(this.btnCLose);
         this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlFooter.Location = new System.Drawing.Point(3, 476);
         this.pnlFooter.Name = "pnlFooter";
         this.pnlFooter.Size = new System.Drawing.Size(938, 36);
         this.pnlFooter.TabIndex = 1;
         // 
         // btnCLose
         // 
         this.btnCLose.Location = new System.Drawing.Point(875, 5);
         this.btnCLose.Name = "btnCLose";
         this.btnCLose.Size = new System.Drawing.Size(58, 27);
         this.btnCLose.TabIndex = 0;
         this.btnCLose.Text = "&Close";
         this.btnCLose.Click += new System.EventHandler(this.simpleButton1_Click);
         // 
         // tabData
         // 
         this.tabData.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabData.Location = new System.Drawing.Point(3, 52);
         this.tabData.Name = "tabData";
         this.tabData.SelectedTabPage = this.xtraTabPage1;
         this.tabData.Size = new System.Drawing.Size(938, 418);
         this.tabData.TabIndex = 2;
         this.tabData.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
         // 
         // xtraTabPage1
         // 
         this.xtraTabPage1.Controls.Add(this.treeInvoice);
         this.xtraTabPage1.Name = "xtraTabPage1";
         this.xtraTabPage1.Size = new System.Drawing.Size(932, 390);
         this.xtraTabPage1.Text = "Invoices";
         // 
         // treeInvoice
         // 
         this.treeInvoice.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn5,
            this.treeListColumn6,
            this.treeListColumn7,
            this.treeListColumn18});
         this.treeInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
         this.treeInvoice.Location = new System.Drawing.Point(0, 0);
         this.treeInvoice.Name = "treeInvoice";
         this.treeInvoice.OptionsView.ShowIndicator = false;
         this.treeInvoice.OptionsView.ShowVertLines = false;
         this.treeInvoice.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
         this.treeInvoice.Size = new System.Drawing.Size(932, 390);
         this.treeInvoice.TabIndex = 0;
         this.treeInvoice.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeInvoice_NodeCellStyle);
         // 
         // treeListColumn1
         // 
         this.treeListColumn1.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.treeListColumn1.Caption = "Group";
         this.treeListColumn1.FieldName = "Group";
         this.treeListColumn1.Name = "treeListColumn1";
         this.treeListColumn1.OptionsColumn.AllowEdit = false;
         this.treeListColumn1.OptionsColumn.AllowFocus = false;
         this.treeListColumn1.OptionsColumn.AllowMove = false;
         this.treeListColumn1.OptionsColumn.FixedWidth = true;
         this.treeListColumn1.Visible = true;
         this.treeListColumn1.VisibleIndex = 0;
         this.treeListColumn1.Width = 120;
         // 
         // treeListColumn2
         // 
         this.treeListColumn2.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn2.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.treeListColumn2.Caption = "SIV ID";
         this.treeListColumn2.FieldName = "SIV_ID";
         this.treeListColumn2.Format.FormatString = "000000";
         this.treeListColumn2.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn2.Name = "treeListColumn2";
         this.treeListColumn2.OptionsColumn.AllowEdit = false;
         this.treeListColumn2.OptionsColumn.AllowFocus = false;
         this.treeListColumn2.OptionsColumn.AllowMove = false;
         this.treeListColumn2.OptionsColumn.AllowSort = false;
         this.treeListColumn2.OptionsColumn.FixedWidth = true;
         this.treeListColumn2.Visible = true;
         this.treeListColumn2.VisibleIndex = 1;
         this.treeListColumn2.Width = 80;
         // 
         // treeListColumn3
         // 
         this.treeListColumn3.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn3.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.treeListColumn3.Caption = "Receipt #";
         this.treeListColumn3.FieldName = "ReceiptNo";
         this.treeListColumn3.Name = "treeListColumn3";
         this.treeListColumn3.OptionsColumn.AllowEdit = false;
         this.treeListColumn3.OptionsColumn.AllowFocus = false;
         this.treeListColumn3.OptionsColumn.AllowMove = false;
         this.treeListColumn3.OptionsColumn.AllowSort = false;
         this.treeListColumn3.OptionsColumn.FixedWidth = true;
         this.treeListColumn3.Visible = true;
         this.treeListColumn3.VisibleIndex = 2;
         this.treeListColumn3.Width = 80;
         // 
         // treeListColumn4
         // 
         this.treeListColumn4.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.treeListColumn4.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.treeListColumn4.Caption = "Date";
         this.treeListColumn4.FieldName = "Date";
         this.treeListColumn4.Format.FormatString = "MM/dd/yy";
         this.treeListColumn4.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
         this.treeListColumn4.Name = "treeListColumn4";
         this.treeListColumn4.OptionsColumn.AllowEdit = false;
         this.treeListColumn4.OptionsColumn.AllowFocus = false;
         this.treeListColumn4.OptionsColumn.AllowMove = false;
         this.treeListColumn4.OptionsColumn.AllowSort = false;
         this.treeListColumn4.OptionsColumn.FixedWidth = true;
         this.treeListColumn4.Visible = true;
         this.treeListColumn4.VisibleIndex = 3;
         this.treeListColumn4.Width = 80;
         // 
         // treeListColumn5
         // 
         this.treeListColumn5.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.treeListColumn5.Caption = "Customer";
         this.treeListColumn5.FieldName = "Customer";
         this.treeListColumn5.Name = "treeListColumn5";
         this.treeListColumn5.OptionsColumn.AllowEdit = false;
         this.treeListColumn5.OptionsColumn.AllowFocus = false;
         this.treeListColumn5.OptionsColumn.AllowMove = false;
         this.treeListColumn5.Visible = true;
         this.treeListColumn5.VisibleIndex = 4;
         // 
         // treeListColumn6
         // 
         this.treeListColumn6.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn6.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.treeListColumn6.Caption = "Amount";
         this.treeListColumn6.FieldName = "Amount";
         this.treeListColumn6.Format.FormatString = "{0:N2}";
         this.treeListColumn6.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn6.Name = "treeListColumn6";
         this.treeListColumn6.OptionsColumn.AllowEdit = false;
         this.treeListColumn6.OptionsColumn.AllowFocus = false;
         this.treeListColumn6.OptionsColumn.AllowMove = false;
         this.treeListColumn6.OptionsColumn.AllowSort = false;
         this.treeListColumn6.OptionsColumn.FixedWidth = true;
         this.treeListColumn6.Visible = true;
         this.treeListColumn6.VisibleIndex = 5;
         this.treeListColumn6.Width = 100;
         // 
         // treeListColumn7
         // 
         this.treeListColumn7.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.treeListColumn7.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.treeListColumn7.Caption = "Canceled";
         this.treeListColumn7.ColumnEdit = this.repositoryItemCheckEdit1;
         this.treeListColumn7.FieldName = "Canceled";
         this.treeListColumn7.Name = "treeListColumn7";
         this.treeListColumn7.OptionsColumn.AllowEdit = false;
         this.treeListColumn7.OptionsColumn.AllowFocus = false;
         this.treeListColumn7.OptionsColumn.AllowMove = false;
         this.treeListColumn7.OptionsColumn.AllowSort = false;
         this.treeListColumn7.OptionsColumn.FixedWidth = true;
         this.treeListColumn7.Visible = true;
         this.treeListColumn7.VisibleIndex = 6;
         // 
         // repositoryItemCheckEdit1
         // 
         this.repositoryItemCheckEdit1.AutoHeight = false;
         this.repositoryItemCheckEdit1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
         this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
         this.repositoryItemCheckEdit1.PictureChecked = global::DexterHardware_v2.Properties.Resources.erase;
         // 
         // treeListColumn18
         // 
         this.treeListColumn18.Caption = " ";
         this.treeListColumn18.FieldName = "ItemObject";
         this.treeListColumn18.Name = "treeListColumn18";
         // 
         // xtraTabPage2
         // 
         this.xtraTabPage2.Controls.Add(this.treePayments);
         this.xtraTabPage2.Name = "xtraTabPage2";
         this.xtraTabPage2.Size = new System.Drawing.Size(932, 390);
         this.xtraTabPage2.Text = "Payments";
         // 
         // treePayments
         // 
         this.treePayments.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn8,
            this.treeListColumn11,
            this.treeListColumn12,
            this.treeListColumn10,
            this.treeListColumn9,
            this.treeListColumn15,
            this.treeListColumn16,
            this.treeListColumn17,
            this.treeListColumn13,
            this.treeListColumn14,
            this.treeListColumn19});
         this.treePayments.Dock = System.Windows.Forms.DockStyle.Fill;
         this.treePayments.Location = new System.Drawing.Point(0, 0);
         this.treePayments.Name = "treePayments";
         this.treePayments.OptionsBehavior.PopulateServiceColumns = true;
         this.treePayments.OptionsView.ShowIndicator = false;
         this.treePayments.OptionsView.ShowVertLines = false;
         this.treePayments.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2});
         this.treePayments.Size = new System.Drawing.Size(932, 390);
         this.treePayments.TabIndex = 1;
         this.treePayments.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treePayments_NodeCellStyle);
         // 
         // treeListColumn8
         // 
         this.treeListColumn8.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.treeListColumn8.Caption = "Group";
         this.treeListColumn8.FieldName = "Group";
         this.treeListColumn8.Name = "treeListColumn8";
         this.treeListColumn8.OptionsColumn.AllowEdit = false;
         this.treeListColumn8.OptionsColumn.AllowFocus = false;
         this.treeListColumn8.OptionsColumn.AllowMove = false;
         this.treeListColumn8.OptionsColumn.AllowSort = false;
         this.treeListColumn8.OptionsColumn.FixedWidth = true;
         this.treeListColumn8.Visible = true;
         this.treeListColumn8.VisibleIndex = 0;
         this.treeListColumn8.Width = 120;
         // 
         // treeListColumn11
         // 
         this.treeListColumn11.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.treeListColumn11.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.treeListColumn11.Caption = "Date";
         this.treeListColumn11.FieldName = "Date";
         this.treeListColumn11.Format.FormatString = "MM/dd/yy";
         this.treeListColumn11.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
         this.treeListColumn11.Name = "treeListColumn11";
         this.treeListColumn11.OptionsColumn.AllowEdit = false;
         this.treeListColumn11.OptionsColumn.AllowFocus = false;
         this.treeListColumn11.OptionsColumn.AllowMove = false;
         this.treeListColumn11.OptionsColumn.AllowSort = false;
         this.treeListColumn11.OptionsColumn.FixedWidth = true;
         this.treeListColumn11.Visible = true;
         this.treeListColumn11.VisibleIndex = 1;
         this.treeListColumn11.Width = 80;
         // 
         // treeListColumn12
         // 
         this.treeListColumn12.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.treeListColumn12.Caption = "Customer";
         this.treeListColumn12.FieldName = "Customer";
         this.treeListColumn12.Name = "treeListColumn12";
         this.treeListColumn12.OptionsColumn.AllowEdit = false;
         this.treeListColumn12.OptionsColumn.AllowFocus = false;
         this.treeListColumn12.OptionsColumn.AllowMove = false;
         this.treeListColumn12.OptionsColumn.AllowSort = false;
         this.treeListColumn12.Visible = true;
         this.treeListColumn12.VisibleIndex = 2;
         // 
         // treeListColumn10
         // 
         this.treeListColumn10.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.treeListColumn10.Caption = "Bank";
         this.treeListColumn10.FieldName = "Bank";
         this.treeListColumn10.Name = "treeListColumn10";
         this.treeListColumn10.OptionsColumn.AllowEdit = false;
         this.treeListColumn10.OptionsColumn.AllowFocus = false;
         this.treeListColumn10.OptionsColumn.AllowMove = false;
         this.treeListColumn10.OptionsColumn.AllowSort = false;
         this.treeListColumn10.OptionsColumn.FixedWidth = true;
         this.treeListColumn10.Visible = true;
         this.treeListColumn10.VisibleIndex = 3;
         this.treeListColumn10.Width = 90;
         // 
         // treeListColumn9
         // 
         this.treeListColumn9.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.treeListColumn9.Caption = "Check No.";
         this.treeListColumn9.FieldName = "CheckNo";
         this.treeListColumn9.Name = "treeListColumn9";
         this.treeListColumn9.OptionsColumn.AllowEdit = false;
         this.treeListColumn9.OptionsColumn.AllowFocus = false;
         this.treeListColumn9.OptionsColumn.AllowMove = false;
         this.treeListColumn9.OptionsColumn.AllowSort = false;
         this.treeListColumn9.OptionsColumn.FixedWidth = true;
         this.treeListColumn9.Visible = true;
         this.treeListColumn9.VisibleIndex = 4;
         this.treeListColumn9.Width = 80;
         // 
         // treeListColumn15
         // 
         this.treeListColumn15.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.treeListColumn15.Caption = "Acct. No.";
         this.treeListColumn15.FieldName = "AccountNo";
         this.treeListColumn15.Name = "treeListColumn15";
         this.treeListColumn15.OptionsColumn.AllowEdit = false;
         this.treeListColumn15.OptionsColumn.AllowFocus = false;
         this.treeListColumn15.OptionsColumn.AllowMove = false;
         this.treeListColumn15.OptionsColumn.AllowSort = false;
         this.treeListColumn15.OptionsColumn.FixedWidth = true;
         this.treeListColumn15.Visible = true;
         this.treeListColumn15.VisibleIndex = 5;
         this.treeListColumn15.Width = 90;
         // 
         // treeListColumn16
         // 
         this.treeListColumn16.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.treeListColumn16.Caption = "Status";
         this.treeListColumn16.FieldName = "Status";
         this.treeListColumn16.Name = "treeListColumn16";
         this.treeListColumn16.OptionsColumn.AllowEdit = false;
         this.treeListColumn16.OptionsColumn.AllowFocus = false;
         this.treeListColumn16.OptionsColumn.AllowMove = false;
         this.treeListColumn16.OptionsColumn.AllowSort = false;
         this.treeListColumn16.OptionsColumn.FixedWidth = true;
         this.treeListColumn16.Visible = true;
         this.treeListColumn16.VisibleIndex = 6;
         this.treeListColumn16.Width = 90;
         // 
         // treeListColumn17
         // 
         this.treeListColumn17.Caption = "Check Date";
         this.treeListColumn17.FieldName = "CheckDate";
         this.treeListColumn17.Format.FormatString = "MM/dd/yy";
         this.treeListColumn17.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
         this.treeListColumn17.Name = "treeListColumn17";
         this.treeListColumn17.OptionsColumn.AllowEdit = false;
         this.treeListColumn17.OptionsColumn.AllowFocus = false;
         this.treeListColumn17.OptionsColumn.AllowMove = false;
         this.treeListColumn17.OptionsColumn.AllowSort = false;
         this.treeListColumn17.OptionsColumn.FixedWidth = true;
         this.treeListColumn17.Visible = true;
         this.treeListColumn17.VisibleIndex = 7;
         // 
         // treeListColumn13
         // 
         this.treeListColumn13.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn13.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.treeListColumn13.Caption = "Amount";
         this.treeListColumn13.FieldName = "Amount";
         this.treeListColumn13.Format.FormatString = "{0:N2}";
         this.treeListColumn13.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn13.Name = "treeListColumn13";
         this.treeListColumn13.OptionsColumn.AllowEdit = false;
         this.treeListColumn13.OptionsColumn.AllowFocus = false;
         this.treeListColumn13.OptionsColumn.AllowMove = false;
         this.treeListColumn13.OptionsColumn.AllowSort = false;
         this.treeListColumn13.OptionsColumn.FixedWidth = true;
         this.treeListColumn13.Visible = true;
         this.treeListColumn13.VisibleIndex = 8;
         this.treeListColumn13.Width = 100;
         // 
         // treeListColumn14
         // 
         this.treeListColumn14.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.treeListColumn14.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.treeListColumn14.Caption = "Canceled";
         this.treeListColumn14.ColumnEdit = this.repositoryItemCheckEdit2;
         this.treeListColumn14.FieldName = "Canceled";
         this.treeListColumn14.Name = "treeListColumn14";
         this.treeListColumn14.OptionsColumn.AllowEdit = false;
         this.treeListColumn14.OptionsColumn.AllowFocus = false;
         this.treeListColumn14.OptionsColumn.AllowMove = false;
         this.treeListColumn14.OptionsColumn.AllowSort = false;
         this.treeListColumn14.OptionsColumn.FixedWidth = true;
         this.treeListColumn14.Visible = true;
         this.treeListColumn14.VisibleIndex = 9;
         // 
         // repositoryItemCheckEdit2
         // 
         this.repositoryItemCheckEdit2.AutoHeight = false;
         this.repositoryItemCheckEdit2.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
         this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
         this.repositoryItemCheckEdit2.PictureChecked = global::DexterHardware_v2.Properties.Resources.erase;
         // 
         // treeListColumn19
         // 
         this.treeListColumn19.Caption = " ";
         this.treeListColumn19.FieldName = "ItemObject";
         this.treeListColumn19.Name = "treeListColumn19";
         // 
         // ctlDailySalesSummary
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tlpMain);
         this.Name = "ctlDailySalesSummary";
         this.Size = new System.Drawing.Size(944, 515);
         this.Load += new System.EventHandler(this.ctlDailySalesSummary_Load);
         this.tlpMain.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
         this.pnlHeader.ResumeLayout(false);
         this.pnlHeader.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
         this.pnlFooter.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.tabData)).EndInit();
         this.tabData.ResumeLayout(false);
         this.xtraTabPage1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.treeInvoice)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
         this.xtraTabPage2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.treePayments)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private DevExpress.XtraEditors.PanelControl pnlHeader;
      private DevExpress.XtraEditors.PanelControl pnlFooter;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.SimpleButton btnCLose;
      private ctlDateRange dtDateRange;
      private DevExpress.XtraEditors.SimpleButton btnRefresh;
      private DevExpress.XtraTab.XtraTabControl tabData;
      private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
      private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
      private DevExpress.XtraTreeList.TreeList treeInvoice;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn7;
      private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
      private DevExpress.XtraTreeList.TreeList treePayments;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn8;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn11;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn12;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn10;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn9;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn15;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn16;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn13;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn14;
      private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn17;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn18;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn19;
   }
}
