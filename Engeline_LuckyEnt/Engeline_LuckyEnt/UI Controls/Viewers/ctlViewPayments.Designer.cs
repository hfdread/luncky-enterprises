namespace DexterHardware_v2.UI_Controls.Viewers
{
   partial class ctlViewPayments
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
         DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
         this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
         this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
         this.btnGetUnreviewedPayments = new DevExpress.XtraEditors.SimpleButton();
         this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.dtRange = new DexterHardware_v2.UI_Controls.ctlDateRange();
         this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
         this.btnClose = new DevExpress.XtraEditors.SimpleButton();
         this.btnUpdateStatus = new DevExpress.XtraEditors.SimpleButton();
         this.chkSelectAll = new DevExpress.XtraEditors.CheckEdit();
         this.grdPayments = new DevExpress.XtraGrid.GridControl();
         this.grdvPayments = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
         this.tlpMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
         this.pnlHeader.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
         this.pnlFooter.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.chkSelectAll.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdPayments)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvPayments)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
         this.SuspendLayout();
         // 
         // tlpMain
         // 
         this.tlpMain.ColumnCount = 1;
         this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
         this.tlpMain.Controls.Add(this.pnlFooter, 0, 2);
         this.tlpMain.Controls.Add(this.grdPayments, 0, 1);
         this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tlpMain.Location = new System.Drawing.Point(0, 0);
         this.tlpMain.Name = "tlpMain";
         this.tlpMain.RowCount = 3;
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
         this.tlpMain.Size = new System.Drawing.Size(886, 426);
         this.tlpMain.TabIndex = 0;
         // 
         // pnlHeader
         // 
         this.pnlHeader.Controls.Add(this.btnGetUnreviewedPayments);
         this.pnlHeader.Controls.Add(this.btnRefresh);
         this.pnlHeader.Controls.Add(this.labelControl1);
         this.pnlHeader.Controls.Add(this.dtRange);
         this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlHeader.Location = new System.Drawing.Point(3, 3);
         this.pnlHeader.Name = "pnlHeader";
         this.pnlHeader.Size = new System.Drawing.Size(880, 43);
         this.pnlHeader.TabIndex = 2;
         // 
         // btnGetUnreviewedPayments
         // 
         this.btnGetUnreviewedPayments.Location = new System.Drawing.Point(589, 11);
         this.btnGetUnreviewedPayments.Name = "btnGetUnreviewedPayments";
         this.btnGetUnreviewedPayments.Size = new System.Drawing.Size(174, 22);
         this.btnGetUnreviewedPayments.TabIndex = 6;
         this.btnGetUnreviewedPayments.Text = "&Get Unreviewed Payments";
         this.btnGetUnreviewedPayments.Click += new System.EventHandler(this.btnGetUnreviewedPayments_Click);
         // 
         // btnRefresh
         // 
         this.btnRefresh.Location = new System.Drawing.Point(481, 11);
         this.btnRefresh.Name = "btnRefresh";
         this.btnRefresh.Size = new System.Drawing.Size(102, 22);
         this.btnRefresh.TabIndex = 5;
         this.btnRefresh.Text = "&Refresh";
         this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(5, 15);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(23, 13);
         this.labelControl1.TabIndex = 1;
         this.labelControl1.Text = "&Date";
         // 
         // dtRange
         // 
         this.dtRange.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.dtRange.Location = new System.Drawing.Point(37, 8);
         this.dtRange.Name = "dtRange";
         this.dtRange.Size = new System.Drawing.Size(442, 28);
         this.dtRange.TabIndex = 0;
         this.dtRange.DateSelectionChanged += new System.EventHandler(this.dtRange_DateSelectionChanged);
         // 
         // pnlFooter
         // 
         this.pnlFooter.Controls.Add(this.btnClose);
         this.pnlFooter.Controls.Add(this.btnUpdateStatus);
         this.pnlFooter.Controls.Add(this.chkSelectAll);
         this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlFooter.Location = new System.Drawing.Point(3, 385);
         this.pnlFooter.Name = "pnlFooter";
         this.pnlFooter.Size = new System.Drawing.Size(880, 38);
         this.pnlFooter.TabIndex = 3;
         // 
         // btnClose
         // 
         this.btnClose.Location = new System.Drawing.Point(773, 8);
         this.btnClose.Name = "btnClose";
         this.btnClose.Size = new System.Drawing.Size(102, 22);
         this.btnClose.TabIndex = 7;
         this.btnClose.Text = "&Close";
         this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
         // 
         // btnUpdateStatus
         // 
         this.btnUpdateStatus.Location = new System.Drawing.Point(665, 8);
         this.btnUpdateStatus.Name = "btnUpdateStatus";
         this.btnUpdateStatus.Size = new System.Drawing.Size(102, 22);
         this.btnUpdateStatus.TabIndex = 6;
         this.btnUpdateStatus.Text = "&Update Status";
         this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
         // 
         // chkSelectAll
         // 
         this.chkSelectAll.Location = new System.Drawing.Point(5, 10);
         this.chkSelectAll.Name = "chkSelectAll";
         this.chkSelectAll.Properties.Caption = "&Check All";
         this.chkSelectAll.Size = new System.Drawing.Size(95, 19);
         this.chkSelectAll.TabIndex = 0;
         this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
         // 
         // grdPayments
         // 
         this.grdPayments.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdPayments.Location = new System.Drawing.Point(3, 52);
         this.grdPayments.MainView = this.grdvPayments;
         this.grdPayments.Name = "grdPayments";
         this.grdPayments.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
         this.grdPayments.Size = new System.Drawing.Size(880, 327);
         this.grdPayments.TabIndex = 4;
         this.grdPayments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvPayments});
         // 
         // grdvPayments
         // 
         this.grdvPayments.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn11,
            this.gridColumn4,
            this.gridColumn7,
            this.gridColumn5,
            this.gridColumn6});
         styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Red;
         styleFormatCondition1.Appearance.Options.UseForeColor = true;
         styleFormatCondition1.ApplyToRow = true;
         styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
         styleFormatCondition1.Expression = "[Canceled] == true";
         this.grdvPayments.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
         this.grdvPayments.GridControl = this.grdPayments;
         this.grdvPayments.Name = "grdvPayments";
         this.grdvPayments.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdvPayments.OptionsView.EnableAppearanceEvenRow = true;
         this.grdvPayments.OptionsView.EnableAppearanceOddRow = true;
         this.grdvPayments.OptionsView.ShowGroupPanel = false;
         this.grdvPayments.OptionsView.ShowIndicator = false;
         this.grdvPayments.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdvPayments_CellValueChanging);
         // 
         // gridColumn3
         // 
         this.gridColumn3.Caption = "Date";
         this.gridColumn3.DisplayFormat.FormatString = "MMM dd, yyyy";
         this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
         this.gridColumn3.FieldName = "PaymentDate";
         this.gridColumn3.Name = "gridColumn3";
         this.gridColumn3.OptionsColumn.AllowEdit = false;
         this.gridColumn3.OptionsColumn.AllowMove = false;
         this.gridColumn3.OptionsColumn.FixedWidth = true;
         this.gridColumn3.Visible = true;
         this.gridColumn3.VisibleIndex = 0;
         // 
         // gridColumn2
         // 
         this.gridColumn2.Caption = "Customer";
         this.gridColumn2.FieldName = "Customer";
         this.gridColumn2.Name = "gridColumn2";
         this.gridColumn2.OptionsColumn.AllowEdit = false;
         this.gridColumn2.Visible = true;
         this.gridColumn2.VisibleIndex = 1;
         this.gridColumn2.Width = 63;
         // 
         // gridColumn11
         // 
         this.gridColumn11.Caption = "Bank";
         this.gridColumn11.FieldName = "PDCdetail.bank.ShortDescription";
         this.gridColumn11.Name = "gridColumn11";
         this.gridColumn11.OptionsColumn.AllowEdit = false;
         this.gridColumn11.OptionsColumn.FixedWidth = true;
         this.gridColumn11.Visible = true;
         this.gridColumn11.VisibleIndex = 2;
         this.gridColumn11.Width = 130;
         // 
         // gridColumn4
         // 
         this.gridColumn4.Caption = "Account #";
         this.gridColumn4.FieldName = "PDCdetail.AccountNumber";
         this.gridColumn4.Name = "gridColumn4";
         this.gridColumn4.OptionsColumn.AllowEdit = false;
         this.gridColumn4.OptionsColumn.FixedWidth = true;
         this.gridColumn4.Visible = true;
         this.gridColumn4.VisibleIndex = 3;
         this.gridColumn4.Width = 120;
         // 
         // gridColumn7
         // 
         this.gridColumn7.Caption = "Check No.";
         this.gridColumn7.FieldName = "PDCdetail.CheckNumber";
         this.gridColumn7.Name = "gridColumn7";
         this.gridColumn7.OptionsColumn.AllowEdit = false;
         this.gridColumn7.OptionsColumn.FixedWidth = true;
         this.gridColumn7.Visible = true;
         this.gridColumn7.VisibleIndex = 4;
         this.gridColumn7.Width = 120;
         // 
         // gridColumn5
         // 
         this.gridColumn5.Caption = "Amount";
         this.gridColumn5.DisplayFormat.FormatString = "{0:N2}";
         this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.gridColumn5.FieldName = "Amount";
         this.gridColumn5.Name = "gridColumn5";
         this.gridColumn5.OptionsColumn.AllowEdit = false;
         this.gridColumn5.OptionsColumn.AllowMove = false;
         this.gridColumn5.OptionsColumn.FixedWidth = true;
         this.gridColumn5.Visible = true;
         this.gridColumn5.VisibleIndex = 5;
         this.gridColumn5.Width = 90;
         // 
         // gridColumn6
         // 
         this.gridColumn6.Caption = "Status";
         this.gridColumn6.ColumnEdit = this.repositoryItemCheckEdit1;
         this.gridColumn6.FieldName = "Reviewed";
         this.gridColumn6.Name = "gridColumn6";
         this.gridColumn6.OptionsColumn.AllowMove = false;
         this.gridColumn6.OptionsColumn.FixedWidth = true;
         this.gridColumn6.UnboundType = DevExpress.Data.UnboundColumnType.String;
         this.gridColumn6.Visible = true;
         this.gridColumn6.VisibleIndex = 6;
         this.gridColumn6.Width = 65;
         // 
         // repositoryItemCheckEdit1
         // 
         this.repositoryItemCheckEdit1.AutoHeight = false;
         this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
         // 
         // ctlViewPayments
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tlpMain);
         this.Name = "ctlViewPayments";
         this.Size = new System.Drawing.Size(886, 426);
         this.Load += new System.EventHandler(this.ctlViewPayments_Load);
         this.tlpMain.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
         this.pnlHeader.ResumeLayout(false);
         this.pnlHeader.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
         this.pnlFooter.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.chkSelectAll.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdPayments)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvPayments)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private DevExpress.XtraEditors.PanelControl pnlHeader;
      private DevExpress.XtraEditors.SimpleButton btnRefresh;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private ctlDateRange dtRange;
      private DevExpress.XtraEditors.SimpleButton btnGetUnreviewedPayments;
      private DevExpress.XtraEditors.PanelControl pnlFooter;
      private DevExpress.XtraGrid.GridControl grdPayments;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvPayments;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
      private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
      private DevExpress.XtraEditors.CheckEdit chkSelectAll;
      private DevExpress.XtraEditors.SimpleButton btnUpdateStatus;
      private DevExpress.XtraEditors.SimpleButton btnClose;
   }
}
