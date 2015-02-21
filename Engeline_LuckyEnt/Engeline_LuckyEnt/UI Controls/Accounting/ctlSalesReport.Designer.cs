namespace DexterHardware_v2.UI_Controls.Accounting
{
   partial class ctlSalesReport
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
         this.btnPrintReport = new DevExpress.XtraEditors.SimpleButton();
         this.cboAgent = new DevExpress.XtraEditors.ComboBoxEdit();
         this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
         this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
         this.cboCustomer = new DevExpress.XtraEditors.ComboBoxEdit();
         this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.dtDateRange = new DexterHardware_v2.UI_Controls.ctlDateRange();
         this.treeItems = new DevExpress.XtraTreeList.TreeList();
         this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn8 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn9 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn10 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn11 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.tlpFooter = new System.Windows.Forms.TableLayoutPanel();
         this.treeCommission = new DevExpress.XtraTreeList.TreeList();
         this.treeListColumn19 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn12 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn13 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn14 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn15 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn17 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn18 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn16 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn20 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn21 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.pnlTotal = new DevExpress.XtraEditors.PanelControl();
         this.lblProfit = new DevExpress.XtraEditors.LabelControl();
         this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
         this.lblTotalSales = new DevExpress.XtraEditors.LabelControl();
         this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
         this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
         this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
         this.treeListColumn22 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.tlpMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
         this.pnlHeader.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboAgent.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboCustomer.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.treeItems)).BeginInit();
         this.tlpFooter.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.treeCommission)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlTotal)).BeginInit();
         this.pnlTotal.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
         this.pnlFooter.SuspendLayout();
         this.SuspendLayout();
         // 
         // tlpMain
         // 
         this.tlpMain.ColumnCount = 1;
         this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
         this.tlpMain.Controls.Add(this.treeItems, 0, 1);
         this.tlpMain.Controls.Add(this.tlpFooter, 0, 3);
         this.tlpMain.Controls.Add(this.pnlFooter, 0, 2);
         this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tlpMain.Location = new System.Drawing.Point(0, 0);
         this.tlpMain.Name = "tlpMain";
         this.tlpMain.RowCount = 4;
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.Size = new System.Drawing.Size(1007, 481);
         this.tlpMain.TabIndex = 0;
         // 
         // pnlHeader
         // 
         this.pnlHeader.Controls.Add(this.btnPrintReport);
         this.pnlHeader.Controls.Add(this.cboAgent);
         this.pnlHeader.Controls.Add(this.labelControl3);
         this.pnlHeader.Controls.Add(this.btnRefresh);
         this.pnlHeader.Controls.Add(this.cboCustomer);
         this.pnlHeader.Controls.Add(this.labelControl2);
         this.pnlHeader.Controls.Add(this.labelControl1);
         this.pnlHeader.Controls.Add(this.dtDateRange);
         this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlHeader.Location = new System.Drawing.Point(3, 3);
         this.pnlHeader.Name = "pnlHeader";
         this.pnlHeader.Size = new System.Drawing.Size(1001, 86);
         this.pnlHeader.TabIndex = 0;
         // 
         // btnPrintReport
         // 
         this.btnPrintReport.Location = new System.Drawing.Point(796, 53);
         this.btnPrintReport.Name = "btnPrintReport";
         this.btnPrintReport.Size = new System.Drawing.Size(151, 22);
         this.btnPrintReport.TabIndex = 7;
         this.btnPrintReport.Text = "Print Report";
         this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
         // 
         // cboAgent
         // 
         this.cboAgent.Location = new System.Drawing.Point(68, 31);
         this.cboAgent.Name = "cboAgent";
         this.cboAgent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboAgent.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
         this.cboAgent.Size = new System.Drawing.Size(280, 20);
         this.cboAgent.TabIndex = 6;
         this.cboAgent.SelectedIndexChanged += new System.EventHandler(this.cboAgent_SelectedIndexChanged);
         // 
         // labelControl3
         // 
         this.labelControl3.Location = new System.Drawing.Point(5, 34);
         this.labelControl3.Name = "labelControl3";
         this.labelControl3.Size = new System.Drawing.Size(29, 13);
         this.labelControl3.TabIndex = 5;
         this.labelControl3.Text = "Agent";
         // 
         // btnRefresh
         // 
         this.btnRefresh.Location = new System.Drawing.Point(639, 53);
         this.btnRefresh.Name = "btnRefresh";
         this.btnRefresh.Size = new System.Drawing.Size(151, 22);
         this.btnRefresh.TabIndex = 4;
         this.btnRefresh.Text = "Refresh";
         this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
         // 
         // cboCustomer
         // 
         this.cboCustomer.Location = new System.Drawing.Point(68, 5);
         this.cboCustomer.Name = "cboCustomer";
         this.cboCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboCustomer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
         this.cboCustomer.Size = new System.Drawing.Size(280, 20);
         this.cboCustomer.TabIndex = 3;
         // 
         // labelControl2
         // 
         this.labelControl2.Location = new System.Drawing.Point(5, 8);
         this.labelControl2.Name = "labelControl2";
         this.labelControl2.Size = new System.Drawing.Size(46, 13);
         this.labelControl2.TabIndex = 2;
         this.labelControl2.Text = "Customer";
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(5, 62);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(23, 13);
         this.labelControl1.TabIndex = 1;
         this.labelControl1.Text = "Date";
         // 
         // dtDateRange
         // 
         this.dtDateRange.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.dtDateRange.Location = new System.Drawing.Point(63, 53);
         this.dtDateRange.Name = "dtDateRange";
         this.dtDateRange.Size = new System.Drawing.Size(442, 28);
         this.dtDateRange.TabIndex = 0;
         // 
         // treeItems
         // 
         this.treeItems.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn5,
            this.treeListColumn6,
            this.treeListColumn7,
            this.treeListColumn8,
            this.treeListColumn9,
            this.treeListColumn10,
            this.treeListColumn11,
            this.treeListColumn22});
         this.treeItems.Dock = System.Windows.Forms.DockStyle.Fill;
         this.treeItems.Location = new System.Drawing.Point(3, 95);
         this.treeItems.Name = "treeItems";
         this.treeItems.OptionsBehavior.Editable = false;
         this.treeItems.OptionsBehavior.PopulateServiceColumns = true;
         this.treeItems.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.treeItems.OptionsView.ShowIndicator = false;
         this.treeItems.Size = new System.Drawing.Size(1001, 173);
         this.treeItems.TabIndex = 1;
         // 
         // treeListColumn1
         // 
         this.treeListColumn1.Caption = " ";
         this.treeListColumn1.FieldName = " ";
         this.treeListColumn1.Name = "treeListColumn1";
         this.treeListColumn1.Visible = true;
         this.treeListColumn1.VisibleIndex = 0;
         this.treeListColumn1.Width = 170;
         // 
         // treeListColumn2
         // 
         this.treeListColumn2.Caption = "Item";
         this.treeListColumn2.FieldName = "Item";
         this.treeListColumn2.Name = "treeListColumn2";
         this.treeListColumn2.Visible = true;
         this.treeListColumn2.VisibleIndex = 1;
         this.treeListColumn2.Width = 172;
         // 
         // treeListColumn3
         // 
         this.treeListColumn3.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn3.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn3.Caption = "QTY";
         this.treeListColumn3.FieldName = "QTY";
         this.treeListColumn3.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn3.Name = "treeListColumn3";
         this.treeListColumn3.OptionsColumn.AllowSort = false;
         this.treeListColumn3.OptionsColumn.FixedWidth = true;
         this.treeListColumn3.Visible = true;
         this.treeListColumn3.VisibleIndex = 2;
         this.treeListColumn3.Width = 35;
         // 
         // treeListColumn4
         // 
         this.treeListColumn4.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn4.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn4.Caption = "Capital";
         this.treeListColumn4.FieldName = "Capital";
         this.treeListColumn4.Format.FormatString = "{0:N2}";
         this.treeListColumn4.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn4.Name = "treeListColumn4";
         this.treeListColumn4.OptionsColumn.AllowMove = false;
         this.treeListColumn4.OptionsColumn.AllowSort = false;
         this.treeListColumn4.OptionsColumn.FixedWidth = true;
         this.treeListColumn4.Visible = true;
         this.treeListColumn4.VisibleIndex = 3;
         this.treeListColumn4.Width = 80;
         // 
         // treeListColumn5
         // 
         this.treeListColumn5.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn5.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn5.Caption = "Freight";
         this.treeListColumn5.FieldName = "Freight";
         this.treeListColumn5.Format.FormatString = "{0:N2}";
         this.treeListColumn5.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn5.Name = "treeListColumn5";
         this.treeListColumn5.OptionsColumn.AllowMove = false;
         this.treeListColumn5.OptionsColumn.AllowSort = false;
         this.treeListColumn5.OptionsColumn.FixedWidth = true;
         this.treeListColumn5.Visible = true;
         this.treeListColumn5.VisibleIndex = 4;
         this.treeListColumn5.Width = 80;
         // 
         // treeListColumn6
         // 
         this.treeListColumn6.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn6.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn6.Caption = "Selling Price";
         this.treeListColumn6.FieldName = "Selling Price";
         this.treeListColumn6.Format.FormatString = "{0:N2}";
         this.treeListColumn6.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn6.Name = "treeListColumn6";
         this.treeListColumn6.OptionsColumn.AllowMove = false;
         this.treeListColumn6.OptionsColumn.AllowSort = false;
         this.treeListColumn6.OptionsColumn.FixedWidth = true;
         this.treeListColumn6.Visible = true;
         this.treeListColumn6.VisibleIndex = 5;
         this.treeListColumn6.Width = 80;
         // 
         // treeListColumn7
         // 
         this.treeListColumn7.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn7.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn7.Caption = "Agent Price";
         this.treeListColumn7.FieldName = "Agent Price";
         this.treeListColumn7.Format.FormatString = "{0:N2}";
         this.treeListColumn7.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn7.Name = "treeListColumn7";
         this.treeListColumn7.OptionsColumn.AllowMove = false;
         this.treeListColumn7.OptionsColumn.AllowSort = false;
         this.treeListColumn7.OptionsColumn.FixedWidth = true;
         this.treeListColumn7.Visible = true;
         this.treeListColumn7.VisibleIndex = 6;
         this.treeListColumn7.Width = 80;
         // 
         // treeListColumn8
         // 
         this.treeListColumn8.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn8.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn8.Caption = "Customer Price";
         this.treeListColumn8.FieldName = "Customer Price";
         this.treeListColumn8.Format.FormatString = "{0:N2}";
         this.treeListColumn8.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn8.Name = "treeListColumn8";
         this.treeListColumn8.OptionsColumn.AllowMove = false;
         this.treeListColumn8.OptionsColumn.AllowSort = false;
         this.treeListColumn8.OptionsColumn.FixedWidth = true;
         this.treeListColumn8.Visible = true;
         this.treeListColumn8.VisibleIndex = 7;
         this.treeListColumn8.Width = 80;
         // 
         // treeListColumn9
         // 
         this.treeListColumn9.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn9.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn9.Caption = "Price Up";
         this.treeListColumn9.FieldName = "Price Up";
         this.treeListColumn9.Format.FormatString = "{0:N2}";
         this.treeListColumn9.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn9.Name = "treeListColumn9";
         this.treeListColumn9.OptionsColumn.AllowMove = false;
         this.treeListColumn9.OptionsColumn.AllowSort = false;
         this.treeListColumn9.OptionsColumn.FixedWidth = true;
         this.treeListColumn9.Visible = true;
         this.treeListColumn9.VisibleIndex = 8;
         this.treeListColumn9.Width = 80;
         // 
         // treeListColumn10
         // 
         this.treeListColumn10.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn10.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn10.Caption = "Gross Sales";
         this.treeListColumn10.FieldName = "Gross Sales";
         this.treeListColumn10.Format.FormatString = "{0:N2}";
         this.treeListColumn10.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn10.Name = "treeListColumn10";
         this.treeListColumn10.OptionsColumn.AllowMove = false;
         this.treeListColumn10.OptionsColumn.AllowSort = false;
         this.treeListColumn10.OptionsColumn.FixedWidth = true;
         this.treeListColumn10.Visible = true;
         this.treeListColumn10.VisibleIndex = 9;
         this.treeListColumn10.Width = 90;
         // 
         // treeListColumn11
         // 
         this.treeListColumn11.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn11.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn11.Caption = "Profit";
         this.treeListColumn11.FieldName = "Profit";
         this.treeListColumn11.Format.FormatString = "{0:N2}";
         this.treeListColumn11.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn11.Name = "treeListColumn11";
         this.treeListColumn11.OptionsColumn.AllowMove = false;
         this.treeListColumn11.OptionsColumn.AllowSort = false;
         this.treeListColumn11.OptionsColumn.FixedWidth = true;
         this.treeListColumn11.Visible = true;
         this.treeListColumn11.VisibleIndex = 10;
         this.treeListColumn11.Width = 80;
         // 
         // tlpFooter
         // 
         this.tlpFooter.ColumnCount = 2;
         this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.43756F));
         this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.56244F));
         this.tlpFooter.Controls.Add(this.treeCommission, 0, 0);
         this.tlpFooter.Controls.Add(this.pnlTotal, 1, 0);
         this.tlpFooter.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tlpFooter.Location = new System.Drawing.Point(3, 304);
         this.tlpFooter.Name = "tlpFooter";
         this.tlpFooter.RowCount = 1;
         this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpFooter.Size = new System.Drawing.Size(1001, 174);
         this.tlpFooter.TabIndex = 2;
         // 
         // treeCommission
         // 
         this.treeCommission.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn19,
            this.treeListColumn12,
            this.treeListColumn13,
            this.treeListColumn14,
            this.treeListColumn15,
            this.treeListColumn17,
            this.treeListColumn18,
            this.treeListColumn16,
            this.treeListColumn20,
            this.treeListColumn21});
         this.treeCommission.Dock = System.Windows.Forms.DockStyle.Fill;
         this.treeCommission.Location = new System.Drawing.Point(3, 3);
         this.treeCommission.Name = "treeCommission";
         this.treeCommission.OptionsBehavior.Editable = false;
         this.treeCommission.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.treeCommission.OptionsView.ShowIndicator = false;
         this.treeCommission.Size = new System.Drawing.Size(618, 168);
         this.treeCommission.TabIndex = 0;
         // 
         // treeListColumn19
         // 
         this.treeListColumn19.Caption = "AgentID";
         this.treeListColumn19.FieldName = "AgentID";
         this.treeListColumn19.Name = "treeListColumn19";
         // 
         // treeListColumn12
         // 
         this.treeListColumn12.Caption = "Agent";
         this.treeListColumn12.FieldName = "Agent";
         this.treeListColumn12.Name = "treeListColumn12";
         this.treeListColumn12.Visible = true;
         this.treeListColumn12.VisibleIndex = 0;
         this.treeListColumn12.Width = 97;
         // 
         // treeListColumn13
         // 
         this.treeListColumn13.Caption = "Period";
         this.treeListColumn13.FieldName = "Period";
         this.treeListColumn13.Name = "treeListColumn13";
         this.treeListColumn13.OptionsColumn.AllowSort = false;
         this.treeListColumn13.OptionsColumn.FixedWidth = true;
         this.treeListColumn13.Visible = true;
         this.treeListColumn13.VisibleIndex = 1;
         this.treeListColumn13.Width = 70;
         // 
         // treeListColumn14
         // 
         this.treeListColumn14.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn14.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn14.Caption = "Fixed Sales";
         this.treeListColumn14.FieldName = "Fixed Sales";
         this.treeListColumn14.Format.FormatString = "{0:N2}";
         this.treeListColumn14.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn14.Name = "treeListColumn14";
         this.treeListColumn14.OptionsColumn.AllowSort = false;
         this.treeListColumn14.OptionsColumn.FixedWidth = true;
         this.treeListColumn14.Visible = true;
         this.treeListColumn14.VisibleIndex = 2;
         // 
         // treeListColumn15
         // 
         this.treeListColumn15.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn15.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn15.Caption = "Per Item";
         this.treeListColumn15.FieldName = "Per Item";
         this.treeListColumn15.Format.FormatString = "{0:N2}";
         this.treeListColumn15.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn15.Name = "treeListColumn15";
         this.treeListColumn15.OptionsColumn.AllowSort = false;
         this.treeListColumn15.OptionsColumn.FixedWidth = true;
         this.treeListColumn15.Visible = true;
         this.treeListColumn15.VisibleIndex = 3;
         // 
         // treeListColumn17
         // 
         this.treeListColumn17.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn17.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn17.Caption = "Fab Sales";
         this.treeListColumn17.FieldName = "Fab Sales";
         this.treeListColumn17.Format.FormatString = "{0:N2}";
         this.treeListColumn17.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn17.Name = "treeListColumn17";
         this.treeListColumn17.OptionsColumn.AllowSort = false;
         this.treeListColumn17.OptionsColumn.FixedWidth = true;
         this.treeListColumn17.Visible = true;
         this.treeListColumn17.VisibleIndex = 4;
         // 
         // treeListColumn18
         // 
         this.treeListColumn18.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn18.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn18.Caption = "Trading Sales";
         this.treeListColumn18.FieldName = "Trading Sales";
         this.treeListColumn18.Format.FormatString = "{0:N2}";
         this.treeListColumn18.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn18.Name = "treeListColumn18";
         this.treeListColumn18.OptionsColumn.AllowSort = false;
         this.treeListColumn18.OptionsColumn.FixedWidth = true;
         this.treeListColumn18.Visible = true;
         this.treeListColumn18.VisibleIndex = 6;
         // 
         // treeListColumn16
         // 
         this.treeListColumn16.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn16.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn16.Caption = "Misc Sales";
         this.treeListColumn16.FieldName = "Misc Sales";
         this.treeListColumn16.Format.FormatString = "{0:N2}";
         this.treeListColumn16.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn16.Name = "treeListColumn16";
         this.treeListColumn16.OptionsColumn.AllowSort = false;
         this.treeListColumn16.OptionsColumn.FixedWidth = true;
         this.treeListColumn16.Visible = true;
         this.treeListColumn16.VisibleIndex = 5;
         // 
         // treeListColumn20
         // 
         this.treeListColumn20.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn20.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn20.Caption = "Fix Com.";
         this.treeListColumn20.FieldName = "Fix Com.";
         this.treeListColumn20.Format.FormatString = "{0:N2}";
         this.treeListColumn20.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn20.Name = "treeListColumn20";
         this.treeListColumn20.OptionsColumn.AllowSort = false;
         this.treeListColumn20.OptionsColumn.FixedWidth = true;
         this.treeListColumn20.Width = 80;
         // 
         // treeListColumn21
         // 
         this.treeListColumn21.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn21.AppearanceHeader.Options.UseTextOptions = true;
         this.treeListColumn21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn21.Caption = "Per Item Com.";
         this.treeListColumn21.FieldName = "Per Item Com.";
         this.treeListColumn21.Format.FormatString = "{0:N2}";
         this.treeListColumn21.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn21.Name = "treeListColumn21";
         this.treeListColumn21.OptionsColumn.AllowSort = false;
         this.treeListColumn21.OptionsColumn.FixedWidth = true;
         this.treeListColumn21.Width = 80;
         // 
         // pnlTotal
         // 
         this.pnlTotal.Controls.Add(this.lblProfit);
         this.pnlTotal.Controls.Add(this.labelControl7);
         this.pnlTotal.Controls.Add(this.lblTotalSales);
         this.pnlTotal.Controls.Add(this.labelControl5);
         this.pnlTotal.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlTotal.Location = new System.Drawing.Point(627, 3);
         this.pnlTotal.Name = "pnlTotal";
         this.pnlTotal.Size = new System.Drawing.Size(371, 168);
         this.pnlTotal.TabIndex = 1;
         // 
         // lblProfit
         // 
         this.lblProfit.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
         this.lblProfit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.lblProfit.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
         this.lblProfit.Location = new System.Drawing.Point(189, 43);
         this.lblProfit.Name = "lblProfit";
         this.lblProfit.Size = new System.Drawing.Size(142, 19);
         this.lblProfit.TabIndex = 5;
         this.lblProfit.Text = "0.00";
         // 
         // labelControl7
         // 
         this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
         this.labelControl7.Location = new System.Drawing.Point(12, 43);
         this.labelControl7.Name = "labelControl7";
         this.labelControl7.Size = new System.Drawing.Size(94, 19);
         this.labelControl7.TabIndex = 4;
         this.labelControl7.Text = "Total Profit";
         // 
         // lblTotalSales
         // 
         this.lblTotalSales.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
         this.lblTotalSales.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.lblTotalSales.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
         this.lblTotalSales.Location = new System.Drawing.Point(189, 18);
         this.lblTotalSales.Name = "lblTotalSales";
         this.lblTotalSales.Size = new System.Drawing.Size(142, 19);
         this.lblTotalSales.TabIndex = 3;
         this.lblTotalSales.Text = "0.00";
         // 
         // labelControl5
         // 
         this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
         this.labelControl5.Location = new System.Drawing.Point(12, 18);
         this.labelControl5.Name = "labelControl5";
         this.labelControl5.Size = new System.Drawing.Size(91, 19);
         this.labelControl5.TabIndex = 2;
         this.labelControl5.Text = "Total Sales";
         // 
         // pnlFooter
         // 
         this.pnlFooter.Controls.Add(this.labelControl4);
         this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlFooter.Location = new System.Drawing.Point(3, 274);
         this.pnlFooter.Name = "pnlFooter";
         this.pnlFooter.Size = new System.Drawing.Size(1001, 24);
         this.pnlFooter.TabIndex = 3;
         // 
         // labelControl4
         // 
         this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.labelControl4.Location = new System.Drawing.Point(5, 6);
         this.labelControl4.Name = "labelControl4";
         this.labelControl4.Size = new System.Drawing.Size(138, 13);
         this.labelControl4.TabIndex = 3;
         this.labelControl4.Text = "Agent Commission Sales";
         // 
         // treeListColumn22
         // 
         this.treeListColumn22.Caption = "ItemObject";
         this.treeListColumn22.FieldName = "ItemObject";
         this.treeListColumn22.Name = "treeListColumn22";
         // 
         // ctlSalesReport
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.Controls.Add(this.tlpMain);
         this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.Name = "ctlSalesReport";
         this.Size = new System.Drawing.Size(1007, 481);
         this.Load += new System.EventHandler(this.ctlSalesReport_Load);
         this.tlpMain.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
         this.pnlHeader.ResumeLayout(false);
         this.pnlHeader.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboAgent.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboCustomer.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.treeItems)).EndInit();
         this.tlpFooter.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.treeCommission)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlTotal)).EndInit();
         this.pnlTotal.ResumeLayout(false);
         this.pnlTotal.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
         this.pnlFooter.ResumeLayout(false);
         this.pnlFooter.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private DevExpress.XtraEditors.PanelControl pnlHeader;
      private ctlDateRange dtDateRange;
      private DevExpress.XtraEditors.ComboBoxEdit cboCustomer;
      private DevExpress.XtraEditors.LabelControl labelControl2;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.SimpleButton btnRefresh;
      private DevExpress.XtraTreeList.TreeList treeItems;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn7;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn8;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn9;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn10;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn11;
      private DevExpress.XtraEditors.ComboBoxEdit cboAgent;
      private DevExpress.XtraEditors.LabelControl labelControl3;
      private System.Windows.Forms.TableLayoutPanel tlpFooter;
      private DevExpress.XtraEditors.PanelControl pnlFooter;
      private DevExpress.XtraEditors.LabelControl labelControl4;
      private DevExpress.XtraTreeList.TreeList treeCommission;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn12;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn13;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn14;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn15;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn16;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn17;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn18;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn19;
      private DevExpress.XtraEditors.PanelControl pnlTotal;
      private DevExpress.XtraEditors.LabelControl labelControl5;
      private DevExpress.XtraEditors.LabelControl lblProfit;
      private DevExpress.XtraEditors.LabelControl labelControl7;
      private DevExpress.XtraEditors.LabelControl lblTotalSales;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn20;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn21;
      private DevExpress.XtraEditors.SimpleButton btnPrintReport;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn22;
   }
}
