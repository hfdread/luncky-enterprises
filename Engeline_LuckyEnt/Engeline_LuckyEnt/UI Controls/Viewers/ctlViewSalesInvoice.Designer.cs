namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
   partial class ctlViewSalesInvoice
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
          this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
          this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
          this.cboDeliverStatus = new DevExpress.XtraEditors.ComboBoxEdit();
          this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
          this.cboStatus = new DevExpress.XtraEditors.ComboBoxEdit();
          this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
          this.cboCustomer = new DevExpress.XtraEditors.ComboBoxEdit();
          this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
          this.dtRange = new Engeline_LuckyEnt.UI_Controls.ctlDateRange();
          this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
          this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
          this.btnClose = new DevExpress.XtraEditors.SimpleButton();
          this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
          this.grdInvoices = new DevExpress.XtraGrid.GridControl();
          this.cmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
          this.mnuViewInvoice = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuBadDebt = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuReceivePayment = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuDelivered = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
          this.mnuCancelInvoice = new System.Windows.Forms.ToolStripMenuItem();
          this.grdvInvoices = new DevExpress.XtraGrid.Views.Grid.GridView();
          this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.repoLink = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
          this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.repoCheckBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
          this.colTerms = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.repoCheckBox = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
          this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.tlpMain.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
          this.pnlHeader.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.cboDeliverStatus.Properties)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.cboCustomer.Properties)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
          this.pnlFooter.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.grdInvoices)).BeginInit();
          this.cmMenu.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.grdvInvoices)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.repoLink)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.repoCheckBox2)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.repoCheckBox)).BeginInit();
          this.SuspendLayout();
          // 
          // tlpMain
          // 
          this.tlpMain.ColumnCount = 1;
          this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
          this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
          this.tlpMain.Controls.Add(this.pnlFooter, 0, 2);
          this.tlpMain.Controls.Add(this.grdInvoices, 0, 1);
          this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
          this.tlpMain.Location = new System.Drawing.Point(0, 0);
          this.tlpMain.Name = "tlpMain";
          this.tlpMain.RowCount = 3;
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
          this.tlpMain.Size = new System.Drawing.Size(918, 533);
          this.tlpMain.TabIndex = 0;
          // 
          // pnlHeader
          // 
          this.pnlHeader.Controls.Add(this.cboDeliverStatus);
          this.pnlHeader.Controls.Add(this.btnRefresh);
          this.pnlHeader.Controls.Add(this.cboStatus);
          this.pnlHeader.Controls.Add(this.labelControl3);
          this.pnlHeader.Controls.Add(this.cboCustomer);
          this.pnlHeader.Controls.Add(this.labelControl2);
          this.pnlHeader.Controls.Add(this.dtRange);
          this.pnlHeader.Controls.Add(this.labelControl1);
          this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pnlHeader.Location = new System.Drawing.Point(3, 3);
          this.pnlHeader.Name = "pnlHeader";
          this.pnlHeader.Size = new System.Drawing.Size(912, 92);
          this.pnlHeader.TabIndex = 0;
          // 
          // cboDeliverStatus
          // 
          this.cboDeliverStatus.EditValue = "ALL";
          this.cboDeliverStatus.Location = new System.Drawing.Point(193, 62);
          this.cboDeliverStatus.Name = "cboDeliverStatus";
          this.cboDeliverStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
          this.cboDeliverStatus.Properties.Items.AddRange(new object[] {
            "ALL",
            "Undelivered",
            "Delivered"});
          this.cboDeliverStatus.Size = new System.Drawing.Size(104, 20);
          this.cboDeliverStatus.TabIndex = 7;
          this.cboDeliverStatus.SelectedIndexChanged += new System.EventHandler(this.cboDeliverStatus_SelectedIndexChanged);
          // 
          // btnRefresh
          // 
          this.btnRefresh.Location = new System.Drawing.Point(417, 54);
          this.btnRefresh.Name = "btnRefresh";
          this.btnRefresh.Size = new System.Drawing.Size(109, 28);
          this.btnRefresh.TabIndex = 6;
          this.btnRefresh.Text = "&Refresh";
          this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
          // 
          // cboStatus
          // 
          this.cboStatus.EditValue = "ALL";
          this.cboStatus.Location = new System.Drawing.Point(98, 62);
          this.cboStatus.Name = "cboStatus";
          this.cboStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
          this.cboStatus.Properties.Items.AddRange(new object[] {
            "ALL",
            "Unpaid",
            "Partial",
            "Paid"});
          this.cboStatus.Size = new System.Drawing.Size(88, 20);
          this.cboStatus.TabIndex = 5;
          this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
          // 
          // labelControl3
          // 
          this.labelControl3.Location = new System.Drawing.Point(16, 65);
          this.labelControl3.Name = "labelControl3";
          this.labelControl3.Size = new System.Drawing.Size(76, 13);
          this.labelControl3.TabIndex = 4;
          this.labelControl3.Text = "&Payment Status";
          // 
          // cboCustomer
          // 
          this.cboCustomer.Location = new System.Drawing.Point(98, 36);
          this.cboCustomer.Name = "cboCustomer";
          this.cboCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
          this.cboCustomer.Size = new System.Drawing.Size(199, 20);
          this.cboCustomer.TabIndex = 3;
          this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.cboCustomer_SelectedIndexChanged);
          // 
          // labelControl2
          // 
          this.labelControl2.Location = new System.Drawing.Point(16, 39);
          this.labelControl2.Name = "labelControl2";
          this.labelControl2.Size = new System.Drawing.Size(46, 13);
          this.labelControl2.TabIndex = 2;
          this.labelControl2.Text = "&Customer";
          // 
          // dtRange
          // 
          this.dtRange.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.dtRange.Location = new System.Drawing.Point(93, 4);
          this.dtRange.Name = "dtRange";
          this.dtRange.Size = new System.Drawing.Size(442, 28);
          this.dtRange.TabIndex = 1;
          this.dtRange.DateSelectionChanged += new System.EventHandler(this.dtRange_DateSelectionChanged);
          // 
          // labelControl1
          // 
          this.labelControl1.Location = new System.Drawing.Point(16, 13);
          this.labelControl1.Name = "labelControl1";
          this.labelControl1.Size = new System.Drawing.Size(23, 13);
          this.labelControl1.TabIndex = 0;
          this.labelControl1.Text = "&Date";
          // 
          // pnlFooter
          // 
          this.pnlFooter.Controls.Add(this.btnClose);
          this.pnlFooter.Controls.Add(this.btnPrint);
          this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pnlFooter.Location = new System.Drawing.Point(3, 479);
          this.pnlFooter.Name = "pnlFooter";
          this.pnlFooter.Size = new System.Drawing.Size(912, 51);
          this.pnlFooter.TabIndex = 2;
          // 
          // btnClose
          // 
          this.btnClose.Location = new System.Drawing.Point(459, 11);
          this.btnClose.Name = "btnClose";
          this.btnClose.Size = new System.Drawing.Size(109, 28);
          this.btnClose.TabIndex = 8;
          this.btnClose.Text = "&Close";
          this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
          // 
          // btnPrint
          // 
          this.btnPrint.Location = new System.Drawing.Point(344, 11);
          this.btnPrint.Name = "btnPrint";
          this.btnPrint.Size = new System.Drawing.Size(109, 28);
          this.btnPrint.TabIndex = 7;
          this.btnPrint.Text = "&Print";
          this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
          // 
          // grdInvoices
          // 
          this.grdInvoices.ContextMenuStrip = this.cmMenu;
          this.grdInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
          this.grdInvoices.Location = new System.Drawing.Point(3, 101);
          this.grdInvoices.MainView = this.grdvInvoices;
          this.grdInvoices.Name = "grdInvoices";
          this.grdInvoices.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoCheckBox,
            this.repoLink,
            this.repoCheckBox2});
          this.grdInvoices.Size = new System.Drawing.Size(912, 372);
          this.grdInvoices.TabIndex = 1;
          this.grdInvoices.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvInvoices});
          this.grdInvoices.Click += new System.EventHandler(this.grdInvoices_Click);
          // 
          // cmMenu
          // 
          this.cmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewInvoice,
            this.mnuBadDebt,
            this.mnuReceivePayment,
            this.mnuDelivered,
            this.toolStripMenuItem1,
            this.mnuCancelInvoice});
          this.cmMenu.Name = "cmMenu";
          this.cmMenu.Size = new System.Drawing.Size(165, 120);
          this.cmMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cmMenu_Opening);
          // 
          // mnuViewInvoice
          // 
          this.mnuViewInvoice.Name = "mnuViewInvoice";
          this.mnuViewInvoice.Size = new System.Drawing.Size(164, 22);
          this.mnuViewInvoice.Text = "View Invoice";
          this.mnuViewInvoice.Click += new System.EventHandler(this.mnuViewInvoice_Click);
          // 
          // mnuBadDebt
          // 
          this.mnuBadDebt.Name = "mnuBadDebt";
          this.mnuBadDebt.Size = new System.Drawing.Size(164, 22);
          this.mnuBadDebt.Text = "Set as Bad Debt";
          this.mnuBadDebt.Visible = false;
          this.mnuBadDebt.Click += new System.EventHandler(this.mnuBadDebt_Click);
          // 
          // mnuReceivePayment
          // 
          this.mnuReceivePayment.Name = "mnuReceivePayment";
          this.mnuReceivePayment.Size = new System.Drawing.Size(164, 22);
          this.mnuReceivePayment.Text = "Receive Payment";
          this.mnuReceivePayment.Click += new System.EventHandler(this.mnuReceivePayment_Click);
          // 
          // mnuDelivered
          // 
          this.mnuDelivered.Name = "mnuDelivered";
          this.mnuDelivered.Size = new System.Drawing.Size(164, 22);
          this.mnuDelivered.Text = "Delivered";
          this.mnuDelivered.Click += new System.EventHandler(this.mnuDelivered_Click);
          // 
          // toolStripMenuItem1
          // 
          this.toolStripMenuItem1.Name = "toolStripMenuItem1";
          this.toolStripMenuItem1.Size = new System.Drawing.Size(161, 6);
          // 
          // mnuCancelInvoice
          // 
          this.mnuCancelInvoice.Name = "mnuCancelInvoice";
          this.mnuCancelInvoice.Size = new System.Drawing.Size(164, 22);
          this.mnuCancelInvoice.Text = "Cancel Invoice";
          this.mnuCancelInvoice.Click += new System.EventHandler(this.mnuCancelInvoice_Click);
          // 
          // grdvInvoices
          // 
          this.grdvInvoices.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.colTerms,
            this.gridColumn9,
            this.gridColumn10});
          styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Red;
          styleFormatCondition1.Appearance.Options.UseForeColor = true;
          styleFormatCondition1.ApplyToRow = true;
          styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
          styleFormatCondition1.Expression = "[Canceled] == true";
          this.grdvInvoices.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
          this.grdvInvoices.GridControl = this.grdInvoices;
          this.grdvInvoices.Name = "grdvInvoices";
          this.grdvInvoices.OptionsBehavior.Editable = false;
          this.grdvInvoices.OptionsSelection.EnableAppearanceFocusedCell = false;
          this.grdvInvoices.OptionsSelection.MultiSelect = true;
          this.grdvInvoices.OptionsView.EnableAppearanceEvenRow = true;
          this.grdvInvoices.OptionsView.EnableAppearanceOddRow = true;
          this.grdvInvoices.OptionsView.ShowGroupPanel = false;
          this.grdvInvoices.OptionsView.ShowIndicator = false;
          this.grdvInvoices.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grdvInvoices_RowCellClick);
          this.grdvInvoices.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grdvInvoices_CustomUnboundColumnData);
          // 
          // gridColumn1
          // 
          this.gridColumn1.Caption = "Invoice ID";
          this.gridColumn1.ColumnEdit = this.repoLink;
          this.gridColumn1.DisplayFormat.FormatString = "000000";
          this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
          this.gridColumn1.FieldName = "ID";
          this.gridColumn1.Name = "gridColumn1";
          this.gridColumn1.OptionsColumn.AllowMove = false;
          this.gridColumn1.OptionsColumn.FixedWidth = true;
          this.gridColumn1.Visible = true;
          this.gridColumn1.VisibleIndex = 0;
          this.gridColumn1.Width = 85;
          // 
          // repoLink
          // 
          this.repoLink.AutoHeight = false;
          this.repoLink.Name = "repoLink";
          this.repoLink.SingleClick = true;
          this.repoLink.Click += new System.EventHandler(this.repoLink_Click);
          // 
          // gridColumn3
          // 
          this.gridColumn3.Caption = "Date";
          this.gridColumn3.DisplayFormat.FormatString = "MMM dd, yyyy";
          this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
          this.gridColumn3.FieldName = "InvoiceDate";
          this.gridColumn3.Name = "gridColumn3";
          this.gridColumn3.OptionsColumn.AllowMove = false;
          this.gridColumn3.OptionsColumn.FixedWidth = true;
          this.gridColumn3.Visible = true;
          this.gridColumn3.VisibleIndex = 1;
          // 
          // gridColumn4
          // 
          this.gridColumn4.Caption = "PO No.";
          this.gridColumn4.DisplayFormat.FormatString = "000000";
          this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
          this.gridColumn4.FieldName = "PO_Number";
          this.gridColumn4.Name = "gridColumn4";
          this.gridColumn4.OptionsColumn.AllowMove = false;
          this.gridColumn4.OptionsColumn.FixedWidth = true;
          this.gridColumn4.Visible = true;
          this.gridColumn4.VisibleIndex = 2;
          this.gridColumn4.Width = 85;
          // 
          // gridColumn2
          // 
          this.gridColumn2.Caption = "Customer";
          this.gridColumn2.FieldName = "Customer";
          this.gridColumn2.Name = "gridColumn2";
          this.gridColumn2.Visible = true;
          this.gridColumn2.VisibleIndex = 3;
          this.gridColumn2.Width = 215;
          // 
          // gridColumn5
          // 
          this.gridColumn5.Caption = "Amount";
          this.gridColumn5.DisplayFormat.FormatString = "{0:N2}";
          this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
          this.gridColumn5.FieldName = "AmountDue";
          this.gridColumn5.Name = "gridColumn5";
          this.gridColumn5.OptionsColumn.AllowMove = false;
          this.gridColumn5.OptionsColumn.FixedWidth = true;
          this.gridColumn5.Visible = true;
          this.gridColumn5.VisibleIndex = 4;
          this.gridColumn5.Width = 90;
          // 
          // gridColumn6
          // 
          this.gridColumn6.Caption = "Status";
          this.gridColumn6.FieldName = "_PaymentStatus";
          this.gridColumn6.Name = "gridColumn6";
          this.gridColumn6.OptionsColumn.AllowMove = false;
          this.gridColumn6.OptionsColumn.FixedWidth = true;
          this.gridColumn6.UnboundType = DevExpress.Data.UnboundColumnType.String;
          this.gridColumn6.Visible = true;
          this.gridColumn6.VisibleIndex = 5;
          this.gridColumn6.Width = 80;
          // 
          // gridColumn7
          // 
          this.gridColumn7.Caption = "Payment";
          this.gridColumn7.FieldName = "_PaymentType";
          this.gridColumn7.Name = "gridColumn7";
          this.gridColumn7.OptionsColumn.AllowMove = false;
          this.gridColumn7.OptionsColumn.FixedWidth = true;
          this.gridColumn7.UnboundType = DevExpress.Data.UnboundColumnType.String;
          this.gridColumn7.Visible = true;
          this.gridColumn7.VisibleIndex = 6;
          this.gridColumn7.Width = 80;
          // 
          // gridColumn8
          // 
          this.gridColumn8.Caption = "Delivered ?";
          this.gridColumn8.ColumnEdit = this.repoCheckBox2;
          this.gridColumn8.FieldName = "is_delivered";
          this.gridColumn8.Name = "gridColumn8";
          this.gridColumn8.OptionsColumn.AllowMove = false;
          this.gridColumn8.OptionsColumn.FixedWidth = true;
          this.gridColumn8.Visible = true;
          this.gridColumn8.VisibleIndex = 7;
          this.gridColumn8.Width = 80;
          // 
          // repoCheckBox2
          // 
          this.repoCheckBox2.AutoHeight = false;
          this.repoCheckBox2.Name = "repoCheckBox2";
          // 
          // colTerms
          // 
          this.colTerms.AppearanceCell.Options.UseTextOptions = true;
          this.colTerms.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
          this.colTerms.Caption = "Terms";
          this.colTerms.FieldName = "_Terms";
          this.colTerms.Name = "colTerms";
          this.colTerms.OptionsColumn.AllowMove = false;
          this.colTerms.OptionsColumn.FixedWidth = true;
          this.colTerms.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
          this.colTerms.Visible = true;
          this.colTerms.VisibleIndex = 8;
          this.colTerms.Width = 50;
          // 
          // gridColumn9
          // 
          this.gridColumn9.Caption = "Bad Debt";
          this.gridColumn9.ColumnEdit = this.repoCheckBox;
          this.gridColumn9.FieldName = "BadDebt";
          this.gridColumn9.Name = "gridColumn9";
          this.gridColumn9.OptionsColumn.AllowMove = false;
          this.gridColumn9.OptionsColumn.FixedWidth = true;
          this.gridColumn9.Width = 70;
          // 
          // repoCheckBox
          // 
          this.repoCheckBox.AutoHeight = false;
          this.repoCheckBox.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
          this.repoCheckBox.Name = "repoCheckBox";
          // 
          // gridColumn10
          // 
          this.gridColumn10.Caption = "Canceled";
          this.gridColumn10.ColumnEdit = this.repoCheckBox2;
          this.gridColumn10.FieldName = "Deleted";
          this.gridColumn10.Name = "gridColumn10";
          this.gridColumn10.OptionsColumn.FixedWidth = true;
          this.gridColumn10.Visible = true;
          this.gridColumn10.VisibleIndex = 9;
          // 
          // ctlViewSalesInvoice
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.tlpMain);
          this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.Name = "ctlViewSalesInvoice";
          this.Size = new System.Drawing.Size(918, 533);
          this.Load += new System.EventHandler(this.ctlViewSalesInvoice_Load);
          this.tlpMain.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
          this.pnlHeader.ResumeLayout(false);
          this.pnlHeader.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.cboDeliverStatus.Properties)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.cboCustomer.Properties)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
          this.pnlFooter.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.grdInvoices)).EndInit();
          this.cmMenu.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.grdvInvoices)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.repoLink)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.repoCheckBox2)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.repoCheckBox)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private DevExpress.XtraEditors.PanelControl pnlHeader;
      private DevExpress.XtraEditors.PanelControl pnlFooter;
      private DevExpress.XtraGrid.GridControl grdInvoices;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvInvoices;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
      private DevExpress.XtraGrid.Columns.GridColumn colTerms;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
      private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repoCheckBox;
      private ctlDateRange dtRange;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.ComboBoxEdit cboCustomer;
      private DevExpress.XtraEditors.LabelControl labelControl2;
      private DevExpress.XtraEditors.ComboBoxEdit cboStatus;
      private DevExpress.XtraEditors.LabelControl labelControl3;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
      private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repoLink;
      private DevExpress.XtraEditors.SimpleButton btnRefresh;
      private System.Windows.Forms.ContextMenuStrip cmMenu;
      private System.Windows.Forms.ToolStripMenuItem mnuViewInvoice;
      private System.Windows.Forms.ToolStripMenuItem mnuBadDebt;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem mnuCancelInvoice;
      private DevExpress.XtraEditors.SimpleButton btnPrint;
      private System.Windows.Forms.ToolStripMenuItem mnuReceivePayment;
      private DevExpress.XtraEditors.SimpleButton btnClose;
      private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repoCheckBox2;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
      private DevExpress.XtraEditors.ComboBoxEdit cboDeliverStatus;
      private System.Windows.Forms.ToolStripMenuItem mnuDelivered;
   }
}
