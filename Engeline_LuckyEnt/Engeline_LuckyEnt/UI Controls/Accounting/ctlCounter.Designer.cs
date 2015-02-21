namespace DexterHardware_v2.UI_Controls.Accounting
{
   partial class ctlCounter
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
         this.components = new System.ComponentModel.Container();
         DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
         DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition();
         this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
         this.btnPaymentWithholding = new DevExpress.XtraEditors.SimpleButton();
         this.btnPaymentCancel = new DevExpress.XtraEditors.SimpleButton();
         this.btnPaymentAdd = new DevExpress.XtraEditors.SimpleButton();
         this.btnClose = new DevExpress.XtraEditors.SimpleButton();
         this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
         this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
         this.lblBalance = new System.Windows.Forms.Label();
         this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
         this.lblAmountDue = new System.Windows.Forms.Label();
         this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
         this.lblDueDate = new DevExpress.XtraEditors.LabelControl();
         this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
         this.lblCounterID = new DevExpress.XtraEditors.LabelControl();
         this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
         this.lblCustomer = new DevExpress.XtraEditors.LabelControl();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
         this.grdPayments = new DevExpress.XtraGrid.GridControl();
         this.grdvPayments = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.treeInvoice = new DevExpress.XtraTreeList.TreeList();
         this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
         this.treeListColumn8 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.treeListColumn9 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
         this.dsData = new System.Data.DataSet();
         this.tblData = new System.Data.DataTable();
         this.bSrc = new System.Windows.Forms.BindingSource(this.components);
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
         this.pnlFooter.SuspendLayout();
         this.tlpMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
         this.pnlHeader.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdPayments)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvPayments)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.treeInvoice)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dsData)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.tblData)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.bSrc)).BeginInit();
         this.SuspendLayout();
         // 
         // pnlFooter
         // 
         this.pnlFooter.Controls.Add(this.btnPaymentWithholding);
         this.pnlFooter.Controls.Add(this.btnPaymentCancel);
         this.pnlFooter.Controls.Add(this.btnPaymentAdd);
         this.pnlFooter.Controls.Add(this.btnClose);
         this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlFooter.Location = new System.Drawing.Point(3, 498);
         this.pnlFooter.Name = "pnlFooter";
         this.pnlFooter.Size = new System.Drawing.Size(752, 49);
         this.pnlFooter.TabIndex = 4;
         // 
         // btnPaymentWithholding
         // 
         this.btnPaymentWithholding.Location = new System.Drawing.Point(217, 11);
         this.btnPaymentWithholding.Name = "btnPaymentWithholding";
         this.btnPaymentWithholding.Size = new System.Drawing.Size(100, 27);
         this.btnPaymentWithholding.TabIndex = 3;
         this.btnPaymentWithholding.Text = "&Withholding";
         this.btnPaymentWithholding.Click += new System.EventHandler(this.btnPaymentWithholding_Click);
         // 
         // btnPaymentCancel
         // 
         this.btnPaymentCancel.Location = new System.Drawing.Point(111, 11);
         this.btnPaymentCancel.Name = "btnPaymentCancel";
         this.btnPaymentCancel.Size = new System.Drawing.Size(100, 27);
         this.btnPaymentCancel.TabIndex = 2;
         this.btnPaymentCancel.Text = "&Cancel Payment";
         this.btnPaymentCancel.Click += new System.EventHandler(this.btnPaymentCancel_Click);
         // 
         // btnPaymentAdd
         // 
         this.btnPaymentAdd.Location = new System.Drawing.Point(5, 11);
         this.btnPaymentAdd.Name = "btnPaymentAdd";
         this.btnPaymentAdd.Size = new System.Drawing.Size(100, 27);
         this.btnPaymentAdd.TabIndex = 1;
         this.btnPaymentAdd.Text = "&Add Payment";
         this.btnPaymentAdd.Click += new System.EventHandler(this.btnPaymentAdd_Click);
         // 
         // btnClose
         // 
         this.btnClose.Location = new System.Drawing.Point(676, 11);
         this.btnClose.Name = "btnClose";
         this.btnClose.Size = new System.Drawing.Size(71, 27);
         this.btnClose.TabIndex = 0;
         this.btnClose.Text = "&Close";
         this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
         // 
         // tlpMain
         // 
         this.tlpMain.ColumnCount = 1;
         this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
         this.tlpMain.Controls.Add(this.pnlFooter, 0, 4);
         this.tlpMain.Controls.Add(this.labelControl6, 0, 2);
         this.tlpMain.Controls.Add(this.grdPayments, 0, 3);
         this.tlpMain.Controls.Add(this.treeInvoice, 0, 1);
         this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tlpMain.Location = new System.Drawing.Point(0, 0);
         this.tlpMain.Name = "tlpMain";
         this.tlpMain.RowCount = 5;
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
         this.tlpMain.Size = new System.Drawing.Size(758, 550);
         this.tlpMain.TabIndex = 1;
         // 
         // pnlHeader
         // 
         this.pnlHeader.Controls.Add(this.lblBalance);
         this.pnlHeader.Controls.Add(this.labelControl2);
         this.pnlHeader.Controls.Add(this.lblAmountDue);
         this.pnlHeader.Controls.Add(this.labelControl5);
         this.pnlHeader.Controls.Add(this.lblDueDate);
         this.pnlHeader.Controls.Add(this.labelControl4);
         this.pnlHeader.Controls.Add(this.lblCounterID);
         this.pnlHeader.Controls.Add(this.labelControl3);
         this.pnlHeader.Controls.Add(this.lblCustomer);
         this.pnlHeader.Controls.Add(this.labelControl1);
         this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlHeader.Location = new System.Drawing.Point(3, 3);
         this.pnlHeader.Name = "pnlHeader";
         this.pnlHeader.Size = new System.Drawing.Size(752, 68);
         this.pnlHeader.TabIndex = 0;
         // 
         // lblBalance
         // 
         this.lblBalance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblBalance.Location = new System.Drawing.Point(240, 45);
         this.lblBalance.Name = "lblBalance";
         this.lblBalance.Size = new System.Drawing.Size(75, 13);
         this.lblBalance.TabIndex = 10;
         this.lblBalance.Text = "0.00";
         this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // labelControl2
         // 
         this.labelControl2.Appearance.ForeColor = System.Drawing.Color.DimGray;
         this.labelControl2.Appearance.Options.UseForeColor = true;
         this.labelControl2.Location = new System.Drawing.Point(175, 45);
         this.labelControl2.Name = "labelControl2";
         this.labelControl2.Size = new System.Drawing.Size(37, 13);
         this.labelControl2.TabIndex = 9;
         this.labelControl2.Text = "Balance";
         // 
         // lblAmountDue
         // 
         this.lblAmountDue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblAmountDue.Location = new System.Drawing.Point(240, 26);
         this.lblAmountDue.Name = "lblAmountDue";
         this.lblAmountDue.Size = new System.Drawing.Size(75, 13);
         this.lblAmountDue.TabIndex = 8;
         this.lblAmountDue.Text = "0.00";
         this.lblAmountDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // labelControl5
         // 
         this.labelControl5.Appearance.ForeColor = System.Drawing.Color.DimGray;
         this.labelControl5.Appearance.Options.UseForeColor = true;
         this.labelControl5.Location = new System.Drawing.Point(175, 26);
         this.labelControl5.Name = "labelControl5";
         this.labelControl5.Size = new System.Drawing.Size(59, 13);
         this.labelControl5.TabIndex = 7;
         this.labelControl5.Text = "Amount Due";
         // 
         // lblDueDate
         // 
         this.lblDueDate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.lblDueDate.Appearance.Options.UseFont = true;
         this.lblDueDate.Location = new System.Drawing.Point(78, 45);
         this.lblDueDate.Name = "lblDueDate";
         this.lblDueDate.Size = new System.Drawing.Size(42, 13);
         this.lblDueDate.TabIndex = 6;
         this.lblDueDate.Text = "000000";
         // 
         // labelControl4
         // 
         this.labelControl4.Appearance.ForeColor = System.Drawing.Color.DimGray;
         this.labelControl4.Appearance.Options.UseForeColor = true;
         this.labelControl4.Location = new System.Drawing.Point(11, 45);
         this.labelControl4.Name = "labelControl4";
         this.labelControl4.Size = new System.Drawing.Size(45, 13);
         this.labelControl4.TabIndex = 5;
         this.labelControl4.Text = "Due Date";
         // 
         // lblCounterID
         // 
         this.lblCounterID.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.lblCounterID.Appearance.Options.UseFont = true;
         this.lblCounterID.Location = new System.Drawing.Point(78, 26);
         this.lblCounterID.Name = "lblCounterID";
         this.lblCounterID.Size = new System.Drawing.Size(42, 13);
         this.lblCounterID.TabIndex = 4;
         this.lblCounterID.Text = "000000";
         // 
         // labelControl3
         // 
         this.labelControl3.Appearance.ForeColor = System.Drawing.Color.DimGray;
         this.labelControl3.Appearance.Options.UseForeColor = true;
         this.labelControl3.Location = new System.Drawing.Point(11, 26);
         this.labelControl3.Name = "labelControl3";
         this.labelControl3.Size = new System.Drawing.Size(59, 13);
         this.labelControl3.TabIndex = 3;
         this.labelControl3.Text = "Counter No.";
         // 
         // lblCustomer
         // 
         this.lblCustomer.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.lblCustomer.Appearance.Options.UseFont = true;
         this.lblCustomer.Location = new System.Drawing.Point(78, 7);
         this.lblCustomer.Name = "lblCustomer";
         this.lblCustomer.Size = new System.Drawing.Size(55, 13);
         this.lblCustomer.TabIndex = 2;
         this.lblCustomer.Text = "Customer";
         // 
         // labelControl1
         // 
         this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DimGray;
         this.labelControl1.Appearance.Options.UseForeColor = true;
         this.labelControl1.Location = new System.Drawing.Point(11, 7);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(46, 13);
         this.labelControl1.TabIndex = 0;
         this.labelControl1.Text = "Customer";
         // 
         // labelControl6
         // 
         this.labelControl6.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
         this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.labelControl6.Appearance.Options.UseBackColor = true;
         this.labelControl6.Appearance.Options.UseFont = true;
         this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
         this.labelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
         this.labelControl6.Dock = System.Windows.Forms.DockStyle.Fill;
         this.labelControl6.Location = new System.Drawing.Point(3, 276);
         this.labelControl6.Name = "labelControl6";
         this.labelControl6.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
         this.labelControl6.Size = new System.Drawing.Size(752, 17);
         this.labelControl6.TabIndex = 3;
         this.labelControl6.Text = "Payments";
         // 
         // grdPayments
         // 
         this.grdPayments.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdPayments.Location = new System.Drawing.Point(3, 299);
         this.grdPayments.MainView = this.grdvPayments;
         this.grdPayments.Name = "grdPayments";
         this.grdPayments.Size = new System.Drawing.Size(752, 193);
         this.grdPayments.TabIndex = 4;
         this.grdPayments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvPayments});
         // 
         // grdvPayments
         // 
         this.grdvPayments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16});
         styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Red;
         styleFormatCondition1.Appearance.Options.UseForeColor = true;
         styleFormatCondition1.ApplyToRow = true;
         styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
         styleFormatCondition1.Expression = "[Canceled] == true";
         this.grdvPayments.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
         this.grdvPayments.GridControl = this.grdPayments;
         this.grdvPayments.Name = "grdvPayments";
         this.grdvPayments.OptionsBehavior.Editable = false;
         this.grdvPayments.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdvPayments.OptionsView.EnableAppearanceEvenRow = true;
         this.grdvPayments.OptionsView.EnableAppearanceOddRow = true;
         this.grdvPayments.OptionsView.ShowGroupPanel = false;
         this.grdvPayments.OptionsView.ShowIndicator = false;
         this.grdvPayments.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grdvPayments_CustomUnboundColumnData);
         // 
         // gridColumn9
         // 
         this.gridColumn9.Caption = "Date";
         this.gridColumn9.DisplayFormat.FormatString = "MMM dd, yyyy";
         this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
         this.gridColumn9.FieldName = "PaymentDate";
         this.gridColumn9.Name = "gridColumn9";
         this.gridColumn9.OptionsColumn.FixedWidth = true;
         this.gridColumn9.Visible = true;
         this.gridColumn9.VisibleIndex = 0;
         this.gridColumn9.Width = 100;
         // 
         // gridColumn10
         // 
         this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
         this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.gridColumn10.Caption = "Amount";
         this.gridColumn10.DisplayFormat.FormatString = "{0:N2}";
         this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.gridColumn10.FieldName = "Amount";
         this.gridColumn10.Name = "gridColumn10";
         this.gridColumn10.OptionsColumn.FixedWidth = true;
         this.gridColumn10.Visible = true;
         this.gridColumn10.VisibleIndex = 1;
         this.gridColumn10.Width = 100;
         // 
         // gridColumn11
         // 
         this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
         this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.gridColumn11.Caption = "Type";
         this.gridColumn11.FieldName = "paymenttype";
         this.gridColumn11.Name = "gridColumn11";
         this.gridColumn11.OptionsColumn.FixedWidth = true;
         this.gridColumn11.UnboundType = DevExpress.Data.UnboundColumnType.String;
         this.gridColumn11.Visible = true;
         this.gridColumn11.VisibleIndex = 2;
         this.gridColumn11.Width = 85;
         // 
         // gridColumn12
         // 
         this.gridColumn12.Caption = "Acc. No.";
         this.gridColumn12.FieldName = "PDCdetail.AccountNumber";
         this.gridColumn12.Name = "gridColumn12";
         this.gridColumn12.OptionsColumn.FixedWidth = true;
         this.gridColumn12.Visible = true;
         this.gridColumn12.VisibleIndex = 3;
         this.gridColumn12.Width = 159;
         // 
         // gridColumn13
         // 
         this.gridColumn13.Caption = "Check No.";
         this.gridColumn13.FieldName = "PDCdetail.CheckNumber";
         this.gridColumn13.Name = "gridColumn13";
         this.gridColumn13.OptionsColumn.FixedWidth = true;
         this.gridColumn13.Visible = true;
         this.gridColumn13.VisibleIndex = 4;
         this.gridColumn13.Width = 100;
         // 
         // gridColumn14
         // 
         this.gridColumn14.Caption = "Check Date";
         this.gridColumn14.DisplayFormat.FormatString = "MMM dd, yyyy";
         this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
         this.gridColumn14.FieldName = "PDCdetail.CheckDate";
         this.gridColumn14.Name = "gridColumn14";
         this.gridColumn14.OptionsColumn.FixedWidth = true;
         this.gridColumn14.Visible = true;
         this.gridColumn14.VisibleIndex = 5;
         this.gridColumn14.Width = 110;
         // 
         // gridColumn15
         // 
         this.gridColumn15.Caption = "Status";
         this.gridColumn15.FieldName = "checkstatus";
         this.gridColumn15.Name = "gridColumn15";
         this.gridColumn15.OptionsColumn.FixedWidth = true;
         this.gridColumn15.UnboundType = DevExpress.Data.UnboundColumnType.String;
         this.gridColumn15.Visible = true;
         this.gridColumn15.VisibleIndex = 6;
         this.gridColumn15.Width = 100;
         // 
         // gridColumn16
         // 
         this.gridColumn16.Name = "gridColumn16";
         this.gridColumn16.OptionsColumn.AllowFocus = false;
         this.gridColumn16.OptionsColumn.AllowMove = false;
         this.gridColumn16.OptionsColumn.AllowShowHide = false;
         this.gridColumn16.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
         this.gridColumn16.OptionsColumn.ReadOnly = true;
         this.gridColumn16.Visible = true;
         this.gridColumn16.VisibleIndex = 7;
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
            this.treeListColumn8,
            this.treeListColumn9});
         this.treeInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
         styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
         styleFormatCondition2.Appearance.Options.UseBackColor = true;
         styleFormatCondition2.ApplyToRow = true;
         styleFormatCondition2.Expression = "IsNull([ItemObject])";
         this.treeInvoice.FormatConditions.AddRange(new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition[] {
            styleFormatCondition2});
         this.treeInvoice.Location = new System.Drawing.Point(3, 77);
         this.treeInvoice.Name = "treeInvoice";
         this.treeInvoice.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.treeInvoice.OptionsView.ShowIndicator = false;
         this.treeInvoice.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2});
         this.treeInvoice.Size = new System.Drawing.Size(752, 193);
         this.treeInvoice.TabIndex = 5;
         this.treeInvoice.CellValueChanging += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeInvoice_CellValueChanging);
         // 
         // treeListColumn1
         // 
         this.treeListColumn1.Caption = "Invoice ID";
         this.treeListColumn1.FieldName = "ID";
         this.treeListColumn1.Format.FormatString = "000000";
         this.treeListColumn1.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn1.Name = "treeListColumn1";
         this.treeListColumn1.OptionsColumn.AllowEdit = false;
         this.treeListColumn1.OptionsColumn.FixedWidth = true;
         this.treeListColumn1.Visible = true;
         this.treeListColumn1.VisibleIndex = 0;
         this.treeListColumn1.Width = 85;
         // 
         // treeListColumn2
         // 
         this.treeListColumn2.Caption = "Date";
         this.treeListColumn2.FieldName = "InvoiceDate";
         this.treeListColumn2.Format.FormatString = "MMM dd, yyyy";
         this.treeListColumn2.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
         this.treeListColumn2.Name = "treeListColumn2";
         this.treeListColumn2.OptionsColumn.AllowEdit = false;
         this.treeListColumn2.OptionsColumn.FixedWidth = true;
         this.treeListColumn2.Visible = true;
         this.treeListColumn2.VisibleIndex = 1;
         // 
         // treeListColumn3
         // 
         this.treeListColumn3.Caption = "PO No.";
         this.treeListColumn3.FieldName = "PO_Number";
         this.treeListColumn3.Format.FormatString = "000000";
         this.treeListColumn3.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn3.Name = "treeListColumn3";
         this.treeListColumn3.OptionsColumn.AllowEdit = false;
         this.treeListColumn3.OptionsColumn.FixedWidth = true;
         this.treeListColumn3.Visible = true;
         this.treeListColumn3.VisibleIndex = 2;
         this.treeListColumn3.Width = 85;
         // 
         // treeListColumn4
         // 
         this.treeListColumn4.Caption = "Customer";
         this.treeListColumn4.FieldName = "Customer";
         this.treeListColumn4.Name = "treeListColumn4";
         this.treeListColumn4.OptionsColumn.AllowEdit = false;
         this.treeListColumn4.Visible = true;
         this.treeListColumn4.VisibleIndex = 3;
         // 
         // treeListColumn5
         // 
         this.treeListColumn5.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn5.Caption = "Amount";
         this.treeListColumn5.FieldName = "AmountDue";
         this.treeListColumn5.Format.FormatString = "{0:N2}";
         this.treeListColumn5.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn5.Name = "treeListColumn5";
         this.treeListColumn5.OptionsColumn.AllowEdit = false;
         this.treeListColumn5.OptionsColumn.FixedWidth = true;
         this.treeListColumn5.Visible = true;
         this.treeListColumn5.VisibleIndex = 4;
         this.treeListColumn5.Width = 90;
         // 
         // treeListColumn6
         // 
         this.treeListColumn6.Caption = "Status";
         this.treeListColumn6.FieldName = "PaymentStatus";
         this.treeListColumn6.Name = "treeListColumn6";
         this.treeListColumn6.OptionsColumn.AllowEdit = false;
         this.treeListColumn6.OptionsColumn.FixedWidth = true;
         this.treeListColumn6.Visible = true;
         this.treeListColumn6.VisibleIndex = 5;
         this.treeListColumn6.Width = 80;
         // 
         // treeListColumn7
         // 
         this.treeListColumn7.Caption = "Withheld";
         this.treeListColumn7.ColumnEdit = this.repositoryItemCheckEdit2;
         this.treeListColumn7.FieldName = "Withheld";
         this.treeListColumn7.Name = "treeListColumn7";
         this.treeListColumn7.OptionsColumn.FixedWidth = true;
         this.treeListColumn7.Visible = true;
         this.treeListColumn7.VisibleIndex = 6;
         this.treeListColumn7.Width = 65;
         // 
         // repositoryItemCheckEdit2
         // 
         this.repositoryItemCheckEdit2.AutoHeight = false;
         this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
         // 
         // treeListColumn8
         // 
         this.treeListColumn8.AppearanceCell.Options.UseTextOptions = true;
         this.treeListColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.treeListColumn8.Caption = "W. Amount";
         this.treeListColumn8.FieldName = "WithheldAmount";
         this.treeListColumn8.Format.FormatString = "{0:N2}";
         this.treeListColumn8.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.treeListColumn8.Name = "treeListColumn8";
         this.treeListColumn8.OptionsColumn.AllowEdit = false;
         this.treeListColumn8.OptionsColumn.FixedWidth = true;
         this.treeListColumn8.Visible = true;
         this.treeListColumn8.VisibleIndex = 7;
         // 
         // treeListColumn9
         // 
         this.treeListColumn9.Caption = "ItemObject";
         this.treeListColumn9.FieldName = "ItemObject";
         this.treeListColumn9.Name = "treeListColumn9";
         this.treeListColumn9.OptionsColumn.AllowEdit = false;
         this.treeListColumn9.OptionsColumn.FixedWidth = true;
         // 
         // dsData
         // 
         this.dsData.DataSetName = "NewDataSet";
         this.dsData.Tables.AddRange(new System.Data.DataTable[] {
            this.tblData});
         // 
         // tblData
         // 
         this.tblData.TableName = "tblData";
         // 
         // bSrc
         // 
         this.bSrc.DataMember = "tblData";
         this.bSrc.DataSource = this.dsData;
         // 
         // ctlCounter
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tlpMain);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlCounter";
         this.Size = new System.Drawing.Size(758, 550);
         this.Load += new System.EventHandler(this.ctlCounter_Load);
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
         this.pnlFooter.ResumeLayout(false);
         this.tlpMain.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
         this.pnlHeader.ResumeLayout(false);
         this.pnlHeader.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdPayments)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvPayments)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.treeInvoice)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dsData)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.tblData)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.bSrc)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.PanelControl pnlFooter;
      private DevExpress.XtraEditors.SimpleButton btnClose;
      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private DevExpress.XtraEditors.PanelControl pnlHeader;
      private System.Data.DataSet dsData;
      private System.Data.DataTable tblData;
      private System.Windows.Forms.BindingSource bSrc;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.LabelControl lblCustomer;
      private DevExpress.XtraEditors.LabelControl lblCounterID;
      private DevExpress.XtraEditors.LabelControl labelControl3;
      private System.Windows.Forms.Label lblAmountDue;
      private DevExpress.XtraEditors.LabelControl labelControl5;
      private DevExpress.XtraEditors.LabelControl lblDueDate;
      private DevExpress.XtraEditors.LabelControl labelControl4;
      private System.Windows.Forms.Label lblBalance;
      private DevExpress.XtraEditors.LabelControl labelControl2;
      private DevExpress.XtraEditors.LabelControl labelControl6;
      private DevExpress.XtraGrid.GridControl grdPayments;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvPayments;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
      private DevExpress.XtraEditors.SimpleButton btnPaymentWithholding;
      private DevExpress.XtraEditors.SimpleButton btnPaymentCancel;
      private DevExpress.XtraEditors.SimpleButton btnPaymentAdd;
      private DevExpress.XtraTreeList.TreeList treeInvoice;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn7;
      private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn8;
      private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn9;

   }
}
