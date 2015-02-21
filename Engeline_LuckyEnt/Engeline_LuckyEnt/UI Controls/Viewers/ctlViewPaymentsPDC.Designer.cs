namespace DexterHardware_v2.UI_Controls.Viewers
{
   partial class ctlViewPaymentsPDC
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
         this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
         this.grcChangeCheckStatus = new DevExpress.XtraEditors.GroupControl();
         this.btnCheckReturned = new DevExpress.XtraEditors.SimpleButton();
         this.btnBounced = new DevExpress.XtraEditors.SimpleButton();
         this.btnCheckGood = new DevExpress.XtraEditors.SimpleButton();
         this.lblRecordsFound = new DevExpress.XtraEditors.LabelControl();
         this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
         this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
         this.txtSearchField = new DevExpress.XtraEditors.TextEdit();
         this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
         this.cboSearchFilter = new DevExpress.XtraEditors.ComboBoxEdit();
         this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
         this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
         this.grdChecks = new DevExpress.XtraGrid.GridControl();
         this.grdvChecks = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
         this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
         this.chkViewCheckForClearing = new DevExpress.XtraEditors.CheckEdit();
         this.cboStatus = new DevExpress.XtraEditors.ComboBoxEdit();
         this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.dtRange = new DexterHardware_v2.UI_Controls.ctlDateRange();
         this.tlpMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
         this.pnlFooter.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grcChangeCheckStatus)).BeginInit();
         this.grcChangeCheckStatus.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtSearchField.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboSearchFilter.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdChecks)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvChecks)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
         this.pnlHeader.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.chkViewCheckForClearing.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // tlpMain
         // 
         this.tlpMain.ColumnCount = 1;
         this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.Controls.Add(this.pnlFooter, 0, 2);
         this.tlpMain.Controls.Add(this.grdChecks, 0, 1);
         this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
         this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tlpMain.Location = new System.Drawing.Point(0, 0);
         this.tlpMain.Name = "tlpMain";
         this.tlpMain.RowCount = 3;
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 103F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.84265F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 135F));
         this.tlpMain.Size = new System.Drawing.Size(858, 483);
         this.tlpMain.TabIndex = 0;
         // 
         // pnlFooter
         // 
         this.pnlFooter.Controls.Add(this.grcChangeCheckStatus);
         this.pnlFooter.Controls.Add(this.lblRecordsFound);
         this.pnlFooter.Controls.Add(this.labelControl6);
         this.pnlFooter.Controls.Add(this.btnSearch);
         this.pnlFooter.Controls.Add(this.txtSearchField);
         this.pnlFooter.Controls.Add(this.labelControl5);
         this.pnlFooter.Controls.Add(this.cboSearchFilter);
         this.pnlFooter.Controls.Add(this.labelControl4);
         this.pnlFooter.Controls.Add(this.labelControl3);
         this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlFooter.Location = new System.Drawing.Point(3, 351);
         this.pnlFooter.Name = "pnlFooter";
         this.pnlFooter.Size = new System.Drawing.Size(852, 129);
         this.pnlFooter.TabIndex = 2;
         // 
         // grcChangeCheckStatus
         // 
         this.grcChangeCheckStatus.Controls.Add(this.btnCheckReturned);
         this.grcChangeCheckStatus.Controls.Add(this.btnBounced);
         this.grcChangeCheckStatus.Controls.Add(this.btnCheckGood);
         this.grcChangeCheckStatus.Location = new System.Drawing.Point(665, 5);
         this.grcChangeCheckStatus.Name = "grcChangeCheckStatus";
         this.grcChangeCheckStatus.Size = new System.Drawing.Size(182, 116);
         this.grcChangeCheckStatus.TabIndex = 10;
         this.grcChangeCheckStatus.Text = "Change Check Status";
         // 
         // btnCheckReturned
         // 
         this.btnCheckReturned.Location = new System.Drawing.Point(17, 81);
         this.btnCheckReturned.Name = "btnCheckReturned";
         this.btnCheckReturned.Size = new System.Drawing.Size(136, 22);
         this.btnCheckReturned.TabIndex = 10;
         this.btnCheckReturned.Text = "Re&turned";
         this.btnCheckReturned.Click += new System.EventHandler(this.btnCheckReturned_Click);
         // 
         // btnBounced
         // 
         this.btnBounced.Location = new System.Drawing.Point(17, 53);
         this.btnBounced.Name = "btnBounced";
         this.btnBounced.Size = new System.Drawing.Size(136, 22);
         this.btnBounced.TabIndex = 9;
         this.btnBounced.Text = "&Bounced";
         this.btnBounced.Click += new System.EventHandler(this.btnBounced_Click);
         // 
         // btnCheckGood
         // 
         this.btnCheckGood.Location = new System.Drawing.Point(17, 25);
         this.btnCheckGood.Name = "btnCheckGood";
         this.btnCheckGood.Size = new System.Drawing.Size(136, 22);
         this.btnCheckGood.TabIndex = 8;
         this.btnCheckGood.Text = "&Good";
         this.btnCheckGood.Click += new System.EventHandler(this.btnCheckGood_Click);
         // 
         // lblRecordsFound
         // 
         this.lblRecordsFound.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblRecordsFound.Location = new System.Drawing.Point(92, 73);
         this.lblRecordsFound.Name = "lblRecordsFound";
         this.lblRecordsFound.Size = new System.Drawing.Size(14, 13);
         this.lblRecordsFound.TabIndex = 9;
         this.lblRecordsFound.Text = "00";
         // 
         // labelControl6
         // 
         this.labelControl6.Location = new System.Drawing.Point(14, 73);
         this.labelControl6.Name = "labelControl6";
         this.labelControl6.Size = new System.Drawing.Size(72, 13);
         this.labelControl6.TabIndex = 8;
         this.labelControl6.Text = "Records Found";
         // 
         // btnSearch
         // 
         this.btnSearch.Location = new System.Drawing.Point(184, 70);
         this.btnSearch.Name = "btnSearch";
         this.btnSearch.Size = new System.Drawing.Size(102, 22);
         this.btnSearch.TabIndex = 7;
         this.btnSearch.Text = "&Search";
         this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
         // 
         // txtSearchField
         // 
         this.txtSearchField.Location = new System.Drawing.Point(90, 47);
         this.txtSearchField.Name = "txtSearchField";
         this.txtSearchField.Size = new System.Drawing.Size(196, 20);
         this.txtSearchField.TabIndex = 6;
         // 
         // labelControl5
         // 
         this.labelControl5.Location = new System.Drawing.Point(14, 50);
         this.labelControl5.Name = "labelControl5";
         this.labelControl5.Size = new System.Drawing.Size(58, 13);
         this.labelControl5.TabIndex = 5;
         this.labelControl5.Text = "Search &Field";
         // 
         // cboSearchFilter
         // 
         this.cboSearchFilter.Location = new System.Drawing.Point(90, 21);
         this.cboSearchFilter.Name = "cboSearchFilter";
         this.cboSearchFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboSearchFilter.Properties.Items.AddRange(new object[] {
            "Account No.",
            "Check No.",
            "Bank"});
         this.cboSearchFilter.Size = new System.Drawing.Size(196, 20);
         this.cboSearchFilter.TabIndex = 4;
         // 
         // labelControl4
         // 
         this.labelControl4.Location = new System.Drawing.Point(14, 24);
         this.labelControl4.Name = "labelControl4";
         this.labelControl4.Size = new System.Drawing.Size(60, 13);
         this.labelControl4.TabIndex = 2;
         this.labelControl4.Text = "S&earch Filter";
         // 
         // labelControl3
         // 
         this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelControl3.Location = new System.Drawing.Point(14, 5);
         this.labelControl3.Name = "labelControl3";
         this.labelControl3.Size = new System.Drawing.Size(39, 13);
         this.labelControl3.TabIndex = 0;
         this.labelControl3.Text = "Search";
         // 
         // grdChecks
         // 
         this.grdChecks.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdChecks.Location = new System.Drawing.Point(3, 106);
         this.grdChecks.MainView = this.grdvChecks;
         this.grdChecks.Name = "grdChecks";
         this.grdChecks.Size = new System.Drawing.Size(852, 239);
         this.grdChecks.TabIndex = 0;
         this.grdChecks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvChecks});
         // 
         // grdvChecks
         // 
         this.grdvChecks.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
         this.grdvChecks.GridControl = this.grdChecks;
         this.grdvChecks.Name = "grdvChecks";
         this.grdvChecks.OptionsBehavior.Editable = false;
         this.grdvChecks.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdvChecks.OptionsView.EnableAppearanceEvenRow = true;
         this.grdvChecks.OptionsView.EnableAppearanceOddRow = true;
         this.grdvChecks.OptionsView.ShowGroupPanel = false;
         this.grdvChecks.OptionsView.ShowIndicator = false;
         this.grdvChecks.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grdvChecks_CustomUnboundColumnData);
         // 
         // gridColumn7
         // 
         this.gridColumn7.Caption = "Customer";
         this.gridColumn7.FieldName = "Customer";
         this.gridColumn7.Name = "gridColumn7";
         this.gridColumn7.Visible = true;
         this.gridColumn7.VisibleIndex = 0;
         this.gridColumn7.Width = 198;
         // 
         // gridColumn1
         // 
         this.gridColumn1.Caption = "Bank";
         this.gridColumn1.FieldName = "PDCdetail.bank.ShortDescription";
         this.gridColumn1.Name = "gridColumn1";
         this.gridColumn1.OptionsColumn.AllowMove = false;
         this.gridColumn1.OptionsColumn.FixedWidth = true;
         this.gridColumn1.Visible = true;
         this.gridColumn1.VisibleIndex = 1;
         this.gridColumn1.Width = 150;
         // 
         // gridColumn2
         // 
         this.gridColumn2.Caption = "Account #";
         this.gridColumn2.FieldName = "PDCdetail.AccountNumber";
         this.gridColumn2.Name = "gridColumn2";
         this.gridColumn2.OptionsColumn.AllowMove = false;
         this.gridColumn2.OptionsColumn.FixedWidth = true;
         this.gridColumn2.Visible = true;
         this.gridColumn2.VisibleIndex = 2;
         this.gridColumn2.Width = 100;
         // 
         // gridColumn3
         // 
         this.gridColumn3.Caption = "Check No.";
         this.gridColumn3.FieldName = "PDCdetail.CheckNumber";
         this.gridColumn3.Name = "gridColumn3";
         this.gridColumn3.OptionsColumn.AllowMove = false;
         this.gridColumn3.OptionsColumn.FixedWidth = true;
         this.gridColumn3.Visible = true;
         this.gridColumn3.VisibleIndex = 3;
         this.gridColumn3.Width = 100;
         // 
         // gridColumn4
         // 
         this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
         this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.gridColumn4.Caption = "Amount";
         this.gridColumn4.DisplayFormat.FormatString = "{0:N2}";
         this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.gridColumn4.FieldName = "PDCdetail.Amount";
         this.gridColumn4.Name = "gridColumn4";
         this.gridColumn4.OptionsColumn.AllowMove = false;
         this.gridColumn4.OptionsColumn.FixedWidth = true;
         this.gridColumn4.Visible = true;
         this.gridColumn4.VisibleIndex = 4;
         this.gridColumn4.Width = 90;
         // 
         // gridColumn5
         // 
         this.gridColumn5.Caption = "Check Date";
         this.gridColumn5.DisplayFormat.FormatString = "MMM dd, yyyy";
         this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
         this.gridColumn5.FieldName = "PDCdetail.CheckDate";
         this.gridColumn5.Name = "gridColumn5";
         this.gridColumn5.OptionsColumn.AllowMove = false;
         this.gridColumn5.OptionsColumn.FixedWidth = true;
         this.gridColumn5.Visible = true;
         this.gridColumn5.VisibleIndex = 5;
         this.gridColumn5.Width = 90;
         // 
         // gridColumn6
         // 
         this.gridColumn6.Caption = "Status";
         this.gridColumn6.FieldName = "CheckStatus";
         this.gridColumn6.Name = "gridColumn6";
         this.gridColumn6.OptionsColumn.AllowMove = false;
         this.gridColumn6.OptionsColumn.FixedWidth = true;
         this.gridColumn6.UnboundType = DevExpress.Data.UnboundColumnType.String;
         this.gridColumn6.Visible = true;
         this.gridColumn6.VisibleIndex = 6;
         this.gridColumn6.Width = 100;
         // 
         // pnlHeader
         // 
         this.pnlHeader.Controls.Add(this.btnRefresh);
         this.pnlHeader.Controls.Add(this.chkViewCheckForClearing);
         this.pnlHeader.Controls.Add(this.cboStatus);
         this.pnlHeader.Controls.Add(this.labelControl2);
         this.pnlHeader.Controls.Add(this.labelControl1);
         this.pnlHeader.Controls.Add(this.dtRange);
         this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlHeader.Location = new System.Drawing.Point(3, 3);
         this.pnlHeader.Name = "pnlHeader";
         this.pnlHeader.Size = new System.Drawing.Size(852, 97);
         this.pnlHeader.TabIndex = 1;
         // 
         // btnRefresh
         // 
         this.btnRefresh.Location = new System.Drawing.Point(386, 61);
         this.btnRefresh.Name = "btnRefresh";
         this.btnRefresh.Size = new System.Drawing.Size(102, 25);
         this.btnRefresh.TabIndex = 5;
         this.btnRefresh.Text = "&Refresh";
         this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
         // 
         // chkViewCheckForClearing
         // 
         this.chkViewCheckForClearing.Location = new System.Drawing.Point(59, 64);
         this.chkViewCheckForClearing.Name = "chkViewCheckForClearing";
         this.chkViewCheckForClearing.Properties.Caption = "&View Checks for Clearing Today";
         this.chkViewCheckForClearing.Size = new System.Drawing.Size(182, 19);
         this.chkViewCheckForClearing.TabIndex = 4;
         this.chkViewCheckForClearing.CheckedChanged += new System.EventHandler(this.chkViewCheckForClearing_CheckedChanged);
         // 
         // cboStatus
         // 
         this.cboStatus.Location = new System.Drawing.Point(61, 5);
         this.cboStatus.Name = "cboStatus";
         this.cboStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboStatus.Properties.Items.AddRange(new object[] {
            "ALL",
            "For Deposit",
            "Good",
            "Returned",
            "Bounced"});
         this.cboStatus.Size = new System.Drawing.Size(126, 20);
         this.cboStatus.TabIndex = 3;
         // 
         // labelControl2
         // 
         this.labelControl2.Location = new System.Drawing.Point(14, 8);
         this.labelControl2.Name = "labelControl2";
         this.labelControl2.Size = new System.Drawing.Size(31, 13);
         this.labelControl2.TabIndex = 2;
         this.labelControl2.Text = "St&atus";
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(14, 35);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(23, 13);
         this.labelControl1.TabIndex = 1;
         this.labelControl1.Text = "&Date";
         // 
         // dtRange
         // 
         this.dtRange.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.dtRange.Location = new System.Drawing.Point(55, 27);
         this.dtRange.Name = "dtRange";
         this.dtRange.Size = new System.Drawing.Size(442, 28);
         this.dtRange.TabIndex = 0;
         this.dtRange.DateSelectionChanged += new System.EventHandler(this.dtRange_DateSelectionChanged);
         // 
         // ctlViewPaymentsPDC
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tlpMain);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlViewPaymentsPDC";
         this.Size = new System.Drawing.Size(858, 483);
         this.Load += new System.EventHandler(this.ctlViewPaymentsPDC_Load);
         this.tlpMain.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
         this.pnlFooter.ResumeLayout(false);
         this.pnlFooter.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grcChangeCheckStatus)).EndInit();
         this.grcChangeCheckStatus.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.txtSearchField.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboSearchFilter.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdChecks)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvChecks)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
         this.pnlHeader.ResumeLayout(false);
         this.pnlHeader.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.chkViewCheckForClearing.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboStatus.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private DevExpress.XtraGrid.GridControl grdChecks;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvChecks;
      private DevExpress.XtraEditors.PanelControl pnlFooter;
      private DevExpress.XtraEditors.PanelControl pnlHeader;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
      private DevExpress.XtraEditors.ComboBoxEdit cboStatus;
      private DevExpress.XtraEditors.LabelControl labelControl2;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private ctlDateRange dtRange;
      private DevExpress.XtraEditors.CheckEdit chkViewCheckForClearing;
      private DevExpress.XtraEditors.SimpleButton btnRefresh;
      private DevExpress.XtraEditors.LabelControl labelControl3;
      private DevExpress.XtraEditors.SimpleButton btnSearch;
      private DevExpress.XtraEditors.TextEdit txtSearchField;
      private DevExpress.XtraEditors.LabelControl labelControl5;
      private DevExpress.XtraEditors.ComboBoxEdit cboSearchFilter;
      private DevExpress.XtraEditors.LabelControl labelControl4;
      private DevExpress.XtraEditors.LabelControl lblRecordsFound;
      private DevExpress.XtraEditors.LabelControl labelControl6;
      private DevExpress.XtraEditors.GroupControl grcChangeCheckStatus;
      private DevExpress.XtraEditors.SimpleButton btnCheckReturned;
      private DevExpress.XtraEditors.SimpleButton btnBounced;
      private DevExpress.XtraEditors.SimpleButton btnCheckGood;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
   }
}
