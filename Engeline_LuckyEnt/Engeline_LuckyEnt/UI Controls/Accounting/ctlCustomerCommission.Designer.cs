namespace DexterHardware_v2.UI_Controls.Accounting
{
   partial class ctlCustomerCommission
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
         this.tlpBody = new System.Windows.Forms.TableLayoutPanel();
         this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
         this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
         this.btnRelease = new DevExpress.XtraEditors.SimpleButton();
         this.btnReleasePrint = new DevExpress.XtraEditors.SimpleButton();
         this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
         this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
         this.dtRange = new DexterHardware_v2.UI_Controls.ctlDateRange();
         this.grdCommission = new DevExpress.XtraGrid.GridControl();
         this.grdvCommission = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.repoLink = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
         this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.pnlSide = new DevExpress.XtraEditors.PanelControl();
         this.lstCustomers = new DevExpress.XtraEditors.ListBoxControl();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.btnClose = new DevExpress.XtraEditors.SimpleButton();
         this.tlpMain.SuspendLayout();
         this.tlpBody.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
         this.pnlFooter.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
         this.pnlHeader.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdCommission)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvCommission)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoLink)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlSide)).BeginInit();
         this.pnlSide.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.lstCustomers)).BeginInit();
         this.SuspendLayout();
         // 
         // tlpMain
         // 
         this.tlpMain.ColumnCount = 2;
         this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195F));
         this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tlpMain.Controls.Add(this.tlpBody, 1, 0);
         this.tlpMain.Controls.Add(this.pnlSide, 0, 0);
         this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tlpMain.Location = new System.Drawing.Point(0, 0);
         this.tlpMain.Name = "tlpMain";
         this.tlpMain.RowCount = 1;
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tlpMain.Size = new System.Drawing.Size(924, 513);
         this.tlpMain.TabIndex = 0;
         // 
         // tlpBody
         // 
         this.tlpBody.ColumnCount = 1;
         this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpBody.Controls.Add(this.pnlFooter, 0, 2);
         this.tlpBody.Controls.Add(this.pnlHeader, 0, 0);
         this.tlpBody.Controls.Add(this.grdCommission, 0, 1);
         this.tlpBody.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tlpBody.Location = new System.Drawing.Point(198, 3);
         this.tlpBody.Name = "tlpBody";
         this.tlpBody.RowCount = 3;
         this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
         this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.94521F));
         this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
         this.tlpBody.Size = new System.Drawing.Size(723, 507);
         this.tlpBody.TabIndex = 1;
         // 
         // pnlFooter
         // 
         this.pnlFooter.Controls.Add(this.btnClose);
         this.pnlFooter.Controls.Add(this.btnPrint);
         this.pnlFooter.Controls.Add(this.btnRelease);
         this.pnlFooter.Controls.Add(this.btnReleasePrint);
         this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlFooter.Location = new System.Drawing.Point(3, 461);
         this.pnlFooter.Name = "pnlFooter";
         this.pnlFooter.Size = new System.Drawing.Size(717, 43);
         this.pnlFooter.TabIndex = 2;
         // 
         // btnPrint
         // 
         this.btnPrint.Location = new System.Drawing.Point(423, 8);
         this.btnPrint.Name = "btnPrint";
         this.btnPrint.Size = new System.Drawing.Size(118, 27);
         this.btnPrint.TabIndex = 2;
         this.btnPrint.Text = "&Print";
         this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
         // 
         // btnRelease
         // 
         this.btnRelease.Location = new System.Drawing.Point(299, 8);
         this.btnRelease.Name = "btnRelease";
         this.btnRelease.Size = new System.Drawing.Size(118, 27);
         this.btnRelease.TabIndex = 1;
         this.btnRelease.Text = "&Release";
         this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
         // 
         // btnReleasePrint
         // 
         this.btnReleasePrint.Location = new System.Drawing.Point(175, 8);
         this.btnReleasePrint.Name = "btnReleasePrint";
         this.btnReleasePrint.Size = new System.Drawing.Size(118, 27);
         this.btnReleasePrint.TabIndex = 0;
         this.btnReleasePrint.Text = "Release && Print";
         this.btnReleasePrint.Click += new System.EventHandler(this.btnReleasePrint_Click);
         // 
         // pnlHeader
         // 
         this.pnlHeader.Controls.Add(this.btnRefresh);
         this.pnlHeader.Controls.Add(this.dtRange);
         this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlHeader.Location = new System.Drawing.Point(3, 3);
         this.pnlHeader.Name = "pnlHeader";
         this.pnlHeader.Size = new System.Drawing.Size(717, 46);
         this.pnlHeader.TabIndex = 0;
         // 
         // btnRefresh
         // 
         this.btnRefresh.Location = new System.Drawing.Point(453, 10);
         this.btnRefresh.Name = "btnRefresh";
         this.btnRefresh.Size = new System.Drawing.Size(94, 27);
         this.btnRefresh.TabIndex = 1;
         this.btnRefresh.Text = "&Refresh";
         this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
         // 
         // dtRange
         // 
         this.dtRange.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.dtRange.Location = new System.Drawing.Point(5, 9);
         this.dtRange.Name = "dtRange";
         this.dtRange.Size = new System.Drawing.Size(442, 28);
         this.dtRange.TabIndex = 0;
         this.dtRange.DateSelectionChanged += new System.EventHandler(this.dtRange_DateSelectionChanged);
         // 
         // grdCommission
         // 
         this.grdCommission.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdCommission.Location = new System.Drawing.Point(3, 55);
         this.grdCommission.MainView = this.grdvCommission;
         this.grdCommission.Name = "grdCommission";
         this.grdCommission.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoLink});
         this.grdCommission.Size = new System.Drawing.Size(717, 400);
         this.grdCommission.TabIndex = 1;
         this.grdCommission.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvCommission});
         // 
         // grdvCommission
         // 
         this.grdvCommission.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
         this.grdvCommission.GridControl = this.grdCommission;
         this.grdvCommission.Name = "grdvCommission";
         this.grdvCommission.OptionsBehavior.Editable = false;
         this.grdvCommission.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdvCommission.OptionsView.ShowGroupPanel = false;
         this.grdvCommission.OptionsView.ShowIndicator = false;
         this.grdvCommission.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grdvCommission_RowCellClick);
         this.grdvCommission.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grdvCommission_CustomUnboundColumnData);
         // 
         // gridColumn1
         // 
         this.gridColumn1.Caption = "Invoice Date";
         this.gridColumn1.DisplayFormat.FormatString = "MMM dd, yyyy";
         this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
         this.gridColumn1.FieldName = "Invoice.InvoiceDate";
         this.gridColumn1.Name = "gridColumn1";
         this.gridColumn1.OptionsColumn.AllowMove = false;
         this.gridColumn1.OptionsColumn.FixedWidth = true;
         this.gridColumn1.Visible = true;
         this.gridColumn1.VisibleIndex = 0;
         this.gridColumn1.Width = 100;
         // 
         // gridColumn2
         // 
         this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
         this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.gridColumn2.Caption = "Invoice ID";
         this.gridColumn2.ColumnEdit = this.repoLink;
         this.gridColumn2.DisplayFormat.FormatString = "000000";
         this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.gridColumn2.FieldName = "Invoice.ID";
         this.gridColumn2.Name = "gridColumn2";
         this.gridColumn2.OptionsColumn.AllowMove = false;
         this.gridColumn2.OptionsColumn.FixedWidth = true;
         this.gridColumn2.Visible = true;
         this.gridColumn2.VisibleIndex = 1;
         this.gridColumn2.Width = 85;
         // 
         // repoLink
         // 
         this.repoLink.AutoHeight = false;
         this.repoLink.Name = "repoLink";
         // 
         // gridColumn3
         // 
         this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
         this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.gridColumn3.Caption = "Counter ID";
         this.gridColumn3.DisplayFormat.FormatString = "000000";
         this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.gridColumn3.FieldName = "Invoice.CounterID";
         this.gridColumn3.Name = "gridColumn3";
         this.gridColumn3.OptionsColumn.AllowMove = false;
         this.gridColumn3.OptionsColumn.FixedWidth = true;
         this.gridColumn3.Visible = true;
         this.gridColumn3.VisibleIndex = 2;
         this.gridColumn3.Width = 85;
         // 
         // gridColumn4
         // 
         this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
         this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.gridColumn4.Caption = "Invoice Amt";
         this.gridColumn4.DisplayFormat.FormatString = "{0:N2}";
         this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.gridColumn4.FieldName = "Invoice.AmountDue";
         this.gridColumn4.Name = "gridColumn4";
         this.gridColumn4.OptionsColumn.AllowMove = false;
         this.gridColumn4.OptionsColumn.FixedWidth = true;
         this.gridColumn4.Visible = true;
         this.gridColumn4.VisibleIndex = 3;
         this.gridColumn4.Width = 85;
         // 
         // gridColumn5
         // 
         this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
         this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.gridColumn5.Caption = "Commission";
         this.gridColumn5.DisplayFormat.FormatString = "{0:N2}";
         this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.gridColumn5.FieldName = "Amount";
         this.gridColumn5.Name = "gridColumn5";
         this.gridColumn5.OptionsColumn.AllowMove = false;
         this.gridColumn5.OptionsColumn.FixedWidth = true;
         this.gridColumn5.Visible = true;
         this.gridColumn5.VisibleIndex = 4;
         this.gridColumn5.Width = 85;
         // 
         // gridColumn6
         // 
         this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
         this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.gridColumn6.Caption = "%";
         this.gridColumn6.DisplayFormat.FormatString = "{0:N2}";
         this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.gridColumn6.FieldName = "Percent";
         this.gridColumn6.Name = "gridColumn6";
         this.gridColumn6.OptionsColumn.AllowMove = false;
         this.gridColumn6.OptionsColumn.FixedWidth = true;
         this.gridColumn6.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
         this.gridColumn6.Visible = true;
         this.gridColumn6.VisibleIndex = 5;
         this.gridColumn6.Width = 35;
         // 
         // gridColumn7
         // 
         this.gridColumn7.Caption = "Status";
         this.gridColumn7.FieldName = "CommissionStatus";
         this.gridColumn7.Name = "gridColumn7";
         this.gridColumn7.UnboundType = DevExpress.Data.UnboundColumnType.String;
         this.gridColumn7.Visible = true;
         this.gridColumn7.VisibleIndex = 6;
         this.gridColumn7.Width = 238;
         // 
         // pnlSide
         // 
         this.pnlSide.Controls.Add(this.lstCustomers);
         this.pnlSide.Controls.Add(this.labelControl1);
         this.pnlSide.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlSide.Location = new System.Drawing.Point(3, 3);
         this.pnlSide.Name = "pnlSide";
         this.pnlSide.Size = new System.Drawing.Size(189, 507);
         this.pnlSide.TabIndex = 0;
         // 
         // lstCustomers
         // 
         this.lstCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
         this.lstCustomers.Location = new System.Drawing.Point(2, 16);
         this.lstCustomers.Name = "lstCustomers";
         this.lstCustomers.Size = new System.Drawing.Size(185, 489);
         this.lstCustomers.TabIndex = 1;
         // 
         // labelControl1
         // 
         this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
         this.labelControl1.Location = new System.Drawing.Point(2, 2);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(91, 14);
         this.labelControl1.TabIndex = 0;
         this.labelControl1.Text = "&Customers List";
         // 
         // btnClose
         // 
         this.btnClose.Location = new System.Drawing.Point(594, 8);
         this.btnClose.Name = "btnClose";
         this.btnClose.Size = new System.Drawing.Size(118, 27);
         this.btnClose.TabIndex = 3;
         this.btnClose.Text = "&Close";
         this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
         // 
         // ctlCustomerCommission
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tlpMain);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlCustomerCommission";
         this.Size = new System.Drawing.Size(924, 513);
         this.Load += new System.EventHandler(this.ctlCustomerCommission_Load);
         this.tlpMain.ResumeLayout(false);
         this.tlpBody.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
         this.pnlFooter.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
         this.pnlHeader.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdCommission)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvCommission)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoLink)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlSide)).EndInit();
         this.pnlSide.ResumeLayout(false);
         this.pnlSide.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.lstCustomers)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private System.Windows.Forms.TableLayoutPanel tlpBody;
      private DevExpress.XtraEditors.PanelControl pnlFooter;
      private DevExpress.XtraEditors.SimpleButton btnReleasePrint;
      private DevExpress.XtraEditors.PanelControl pnlHeader;
      private DevExpress.XtraGrid.GridControl grdCommission;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvCommission;
      private DevExpress.XtraEditors.PanelControl pnlSide;
      private DevExpress.XtraEditors.SimpleButton btnRefresh;
      private ctlDateRange dtRange;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.ListBoxControl lstCustomers;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
      private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repoLink;
      private DevExpress.XtraEditors.SimpleButton btnPrint;
      private DevExpress.XtraEditors.SimpleButton btnRelease;
      private DevExpress.XtraEditors.SimpleButton btnClose;
   }
}
