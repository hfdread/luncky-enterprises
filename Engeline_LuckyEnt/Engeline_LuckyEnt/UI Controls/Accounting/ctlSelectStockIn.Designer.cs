namespace DexterHardware_v2.UI_Controls.Accounting
{
   partial class ctlSelectStockIn
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
         this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
         this.dtRange = new DexterHardware_v2.UI_Controls.ctlDateRange();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
         this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
         this.btnOK = new DevExpress.XtraEditors.SimpleButton();
         this.grdSI = new DevExpress.XtraGrid.GridControl();
         this.grdvSI = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
         this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.chkSelectAll = new DevExpress.XtraEditors.CheckEdit();
         this.tlpMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
         this.pnlHeader.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
         this.pnlFooter.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdSI)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvSI)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.chkSelectAll.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // tlpMain
         // 
         this.tlpMain.ColumnCount = 1;
         this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
         this.tlpMain.Controls.Add(this.pnlFooter, 0, 2);
         this.tlpMain.Controls.Add(this.grdSI, 0, 1);
         this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tlpMain.Location = new System.Drawing.Point(0, 0);
         this.tlpMain.Name = "tlpMain";
         this.tlpMain.RowCount = 3;
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.37634F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
         this.tlpMain.Size = new System.Drawing.Size(612, 372);
         this.tlpMain.TabIndex = 0;
         // 
         // pnlHeader
         // 
         this.pnlHeader.Controls.Add(this.btnRefresh);
         this.pnlHeader.Controls.Add(this.dtRange);
         this.pnlHeader.Controls.Add(this.labelControl1);
         this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlHeader.Location = new System.Drawing.Point(3, 3);
         this.pnlHeader.Name = "pnlHeader";
         this.pnlHeader.Size = new System.Drawing.Size(606, 41);
         this.pnlHeader.TabIndex = 0;
         // 
         // btnRefresh
         // 
         this.btnRefresh.Location = new System.Drawing.Point(486, 8);
         this.btnRefresh.Name = "btnRefresh";
         this.btnRefresh.Size = new System.Drawing.Size(109, 25);
         this.btnRefresh.TabIndex = 2;
         this.btnRefresh.Text = "&Refresh";
         this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
         // 
         // dtRange
         // 
         this.dtRange.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.dtRange.Location = new System.Drawing.Point(38, 6);
         this.dtRange.Name = "dtRange";
         this.dtRange.Size = new System.Drawing.Size(442, 28);
         this.dtRange.TabIndex = 1;
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(5, 13);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(23, 13);
         this.labelControl1.TabIndex = 0;
         this.labelControl1.Text = "&Date";
         // 
         // pnlFooter
         // 
         this.pnlFooter.Controls.Add(this.chkSelectAll);
         this.pnlFooter.Controls.Add(this.btnCancel);
         this.pnlFooter.Controls.Add(this.btnOK);
         this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlFooter.Location = new System.Drawing.Point(3, 325);
         this.pnlFooter.Name = "pnlFooter";
         this.pnlFooter.Size = new System.Drawing.Size(606, 44);
         this.pnlFooter.TabIndex = 2;
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(306, 10);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(109, 25);
         this.btnCancel.TabIndex = 2;
         this.btnCancel.Text = "&Cancel";
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // btnOK
         // 
         this.btnOK.Location = new System.Drawing.Point(191, 10);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(109, 25);
         this.btnOK.TabIndex = 1;
         this.btnOK.Text = "&OK";
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // grdSI
         // 
         this.grdSI.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdSI.Location = new System.Drawing.Point(3, 50);
         this.grdSI.MainView = this.grdvSI;
         this.grdSI.Name = "grdSI";
         this.grdSI.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
         this.grdSI.Size = new System.Drawing.Size(606, 269);
         this.grdSI.TabIndex = 1;
         this.grdSI.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvSI});
         // 
         // grdvSI
         // 
         this.grdvSI.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
         this.grdvSI.GridControl = this.grdSI;
         this.grdvSI.Name = "grdvSI";
         this.grdvSI.OptionsView.EnableAppearanceEvenRow = true;
         this.grdvSI.OptionsView.EnableAppearanceOddRow = true;
         this.grdvSI.OptionsView.ShowGroupPanel = false;
         this.grdvSI.OptionsView.ShowIndicator = false;
         // 
         // gridColumn6
         // 
         this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
         this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.gridColumn6.Caption = " ";
         this.gridColumn6.ColumnEdit = this.repositoryItemCheckEdit1;
         this.gridColumn6.FieldName = "Selected";
         this.gridColumn6.Name = "gridColumn6";
         this.gridColumn6.OptionsColumn.FixedWidth = true;
         this.gridColumn6.Visible = true;
         this.gridColumn6.VisibleIndex = 0;
         this.gridColumn6.Width = 30;
         // 
         // repositoryItemCheckEdit1
         // 
         this.repositoryItemCheckEdit1.AutoHeight = false;
         this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
         // 
         // gridColumn1
         // 
         this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
         this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.gridColumn1.Caption = "Date";
         this.gridColumn1.DisplayFormat.FormatString = "MM/dd/yy";
         this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
         this.gridColumn1.FieldName = "StockInDate";
         this.gridColumn1.Name = "gridColumn1";
         this.gridColumn1.OptionsColumn.AllowEdit = false;
         this.gridColumn1.OptionsColumn.FixedWidth = true;
         this.gridColumn1.Visible = true;
         this.gridColumn1.VisibleIndex = 1;
         this.gridColumn1.Width = 80;
         // 
         // gridColumn2
         // 
         this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
         this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.gridColumn2.Caption = "Arrival Date";
         this.gridColumn2.DisplayFormat.FormatString = "MM/dd/yy";
         this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
         this.gridColumn2.FieldName = "ArrivalDate";
         this.gridColumn2.Name = "gridColumn2";
         this.gridColumn2.OptionsColumn.AllowEdit = false;
         this.gridColumn2.OptionsColumn.FixedWidth = true;
         this.gridColumn2.Visible = true;
         this.gridColumn2.VisibleIndex = 2;
         this.gridColumn2.Width = 80;
         // 
         // gridColumn3
         // 
         this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
         this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.gridColumn3.Caption = "PO ID";
         this.gridColumn3.DisplayFormat.FormatString = "000000";
         this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.gridColumn3.FieldName = "purchaseorder.ID";
         this.gridColumn3.Name = "gridColumn3";
         this.gridColumn3.OptionsColumn.AllowEdit = false;
         this.gridColumn3.OptionsColumn.FixedWidth = true;
         this.gridColumn3.Visible = true;
         this.gridColumn3.VisibleIndex = 3;
         this.gridColumn3.Width = 90;
         // 
         // gridColumn4
         // 
         this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
         this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.gridColumn4.Caption = "Supplier";
         this.gridColumn4.FieldName = "purchaseorder.Supplier";
         this.gridColumn4.Name = "gridColumn4";
         this.gridColumn4.OptionsColumn.AllowEdit = false;
         this.gridColumn4.Visible = true;
         this.gridColumn4.VisibleIndex = 4;
         this.gridColumn4.Width = 227;
         // 
         // gridColumn5
         // 
         this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
         this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.gridColumn5.Caption = "Amount";
         this.gridColumn5.DisplayFormat.FormatString = "{0:N2}";
         this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.gridColumn5.FieldName = "AmountDue";
         this.gridColumn5.Name = "gridColumn5";
         this.gridColumn5.OptionsColumn.AllowEdit = false;
         this.gridColumn5.OptionsColumn.FixedWidth = true;
         this.gridColumn5.Visible = true;
         this.gridColumn5.VisibleIndex = 5;
         this.gridColumn5.Width = 95;
         // 
         // chkSelectAll
         // 
         this.chkSelectAll.Location = new System.Drawing.Point(4, 13);
         this.chkSelectAll.Name = "chkSelectAll";
         this.chkSelectAll.Properties.Caption = "Select All";
         this.chkSelectAll.Size = new System.Drawing.Size(97, 19);
         this.chkSelectAll.TabIndex = 0;
         this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
         // 
         // ctlSelectStockIn
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tlpMain);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlSelectStockIn";
         this.Size = new System.Drawing.Size(612, 372);
         this.Load += new System.EventHandler(this.ctlSelectStockIn_Load);
         this.tlpMain.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
         this.pnlHeader.ResumeLayout(false);
         this.pnlHeader.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
         this.pnlFooter.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdSI)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvSI)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.chkSelectAll.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private DevExpress.XtraEditors.PanelControl pnlHeader;
      private DevExpress.XtraEditors.PanelControl pnlFooter;
      private DevExpress.XtraGrid.GridControl grdSI;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvSI;
      private ctlDateRange dtRange;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.SimpleButton btnRefresh;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
      private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
      private DevExpress.XtraEditors.SimpleButton btnOK;
      private DevExpress.XtraEditors.CheckEdit chkSelectAll;
   }
}
