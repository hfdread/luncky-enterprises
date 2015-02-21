namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
   partial class ctlNoPriceItems
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
          this.grdItems = new DevExpress.XtraGrid.GridControl();
          this.grdvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
          this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.repMemo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
          this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.pnlFooter = new System.Windows.Forms.Panel();
          this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
          this.btnSetSellingPrice = new DevExpress.XtraEditors.SimpleButton();
          this.tlpMain.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.grdvItems)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.repMemo)).BeginInit();
          this.pnlFooter.SuspendLayout();
          this.SuspendLayout();
          // 
          // tlpMain
          // 
          this.tlpMain.ColumnCount = 1;
          this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
          this.tlpMain.Controls.Add(this.grdItems, 0, 0);
          this.tlpMain.Controls.Add(this.pnlFooter, 0, 1);
          this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
          this.tlpMain.Location = new System.Drawing.Point(0, 0);
          this.tlpMain.Name = "tlpMain";
          this.tlpMain.RowCount = 2;
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.95238F));
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
          this.tlpMain.Size = new System.Drawing.Size(1005, 483);
          this.tlpMain.TabIndex = 0;
          // 
          // grdItems
          // 
          this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
          this.grdItems.Location = new System.Drawing.Point(3, 3);
          this.grdItems.MainView = this.grdvItems;
          this.grdItems.Name = "grdItems";
          this.grdItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repMemo});
          this.grdItems.Size = new System.Drawing.Size(999, 420);
          this.grdItems.TabIndex = 0;
          this.grdItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvItems});
          // 
          // grdvItems
          // 
          this.grdvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
          this.grdvItems.GridControl = this.grdItems;
          this.grdvItems.Name = "grdvItems";
          this.grdvItems.OptionsBehavior.Editable = false;
          this.grdvItems.OptionsSelection.EnableAppearanceFocusedCell = false;
          this.grdvItems.OptionsSelection.MultiSelect = true;
          this.grdvItems.OptionsView.RowAutoHeight = true;
          this.grdvItems.OptionsView.ShowGroupPanel = false;
          this.grdvItems.OptionsView.ShowIndicator = false;
          this.grdvItems.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grdvItems_CustomUnboundColumnData);
          // 
          // gridColumn1
          // 
          this.gridColumn1.Caption = "ItemName";
          this.gridColumn1.ColumnEdit = this.repMemo;
          this.gridColumn1.FieldName = "ItemName";
          this.gridColumn1.Name = "gridColumn1";
          this.gridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.String;
          this.gridColumn1.Visible = true;
          this.gridColumn1.VisibleIndex = 0;
          this.gridColumn1.Width = 235;
          // 
          // repMemo
          // 
          this.repMemo.Name = "repMemo";
          // 
          // gridColumn2
          // 
          this.gridColumn2.Caption = "StockIn ID";
          this.gridColumn2.DisplayFormat.FormatString = "000000";
          this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
          this.gridColumn2.FieldName = "stockin.ID";
          this.gridColumn2.Name = "gridColumn2";
          this.gridColumn2.OptionsColumn.AllowEdit = false;
          this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
          this.gridColumn2.OptionsColumn.FixedWidth = true;
          this.gridColumn2.Visible = true;
          this.gridColumn2.VisibleIndex = 1;
          this.gridColumn2.Width = 70;
          // 
          // gridColumn3
          // 
          this.gridColumn3.Caption = "SOC ID";
          this.gridColumn3.DisplayFormat.FormatString = "000000";
          this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
          this.gridColumn3.FieldName = "stockin.statementofaccount.ID";
          this.gridColumn3.Name = "gridColumn3";
          this.gridColumn3.OptionsColumn.AllowEdit = false;
          this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
          this.gridColumn3.OptionsColumn.FixedWidth = true;
          this.gridColumn3.Visible = true;
          this.gridColumn3.VisibleIndex = 2;
          this.gridColumn3.Width = 70;
          // 
          // gridColumn4
          // 
          this.gridColumn4.Caption = "Warehouse";
          this.gridColumn4.FieldName = "warehouse";
          this.gridColumn4.Name = "gridColumn4";
          this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
          this.gridColumn4.OptionsColumn.FixedWidth = true;
          this.gridColumn4.UnboundType = DevExpress.Data.UnboundColumnType.String;
          this.gridColumn4.Visible = true;
          this.gridColumn4.VisibleIndex = 3;
          this.gridColumn4.Width = 150;
          // 
          // gridColumn5
          // 
          this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
          this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
          this.gridColumn5.Caption = "Date";
          this.gridColumn5.DisplayFormat.FormatString = "MM/dd/yyyy";
          this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
          this.gridColumn5.FieldName = "stockin.StockInDate";
          this.gridColumn5.Name = "gridColumn5";
          this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
          this.gridColumn5.OptionsColumn.FixedWidth = true;
          this.gridColumn5.Visible = true;
          this.gridColumn5.VisibleIndex = 4;
          this.gridColumn5.Width = 70;
          // 
          // gridColumn6
          // 
          this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
          this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
          this.gridColumn6.Caption = "QTY";
          this.gridColumn6.FieldName = "QTY_SI";
          this.gridColumn6.Name = "gridColumn6";
          this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
          this.gridColumn6.OptionsColumn.FixedWidth = true;
          this.gridColumn6.UnboundType = DevExpress.Data.UnboundColumnType.String;
          this.gridColumn6.Visible = true;
          this.gridColumn6.VisibleIndex = 5;
          this.gridColumn6.Width = 70;
          // 
          // gridColumn7
          // 
          this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
          this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
          this.gridColumn7.Caption = "Base Price";
          this.gridColumn7.FieldName = "BasePrice";
          this.gridColumn7.Name = "gridColumn7";
          this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
          this.gridColumn7.OptionsColumn.FixedWidth = true;
          this.gridColumn7.UnboundType = DevExpress.Data.UnboundColumnType.String;
          this.gridColumn7.Visible = true;
          this.gridColumn7.VisibleIndex = 6;
          this.gridColumn7.Width = 80;
          // 
          // gridColumn8
          // 
          this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
          this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
          this.gridColumn8.Caption = "Capital";
          this.gridColumn8.DisplayFormat.FormatString = "{0:N2}";
          this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
          this.gridColumn8.FieldName = "Capital";
          this.gridColumn8.Name = "gridColumn8";
          this.gridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
          this.gridColumn8.OptionsColumn.FixedWidth = true;
          this.gridColumn8.UnboundType = DevExpress.Data.UnboundColumnType.String;
          this.gridColumn8.Visible = true;
          this.gridColumn8.VisibleIndex = 7;
          // 
          // gridColumn9
          // 
          this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
          this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
          this.gridColumn9.Caption = "Selling Price1";
          this.gridColumn9.ColumnEdit = this.repMemo;
          this.gridColumn9.FieldName = "SellingPrice_1";
          this.gridColumn9.Name = "gridColumn9";
          this.gridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
          this.gridColumn9.OptionsColumn.FixedWidth = true;
          this.gridColumn9.UnboundType = DevExpress.Data.UnboundColumnType.String;
          this.gridColumn9.Visible = true;
          this.gridColumn9.VisibleIndex = 8;
          this.gridColumn9.Width = 85;
          // 
          // gridColumn10
          // 
          this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
          this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
          this.gridColumn10.Caption = "Selling Price2";
          this.gridColumn10.ColumnEdit = this.repMemo;
          this.gridColumn10.FieldName = "SellingPrice_2";
          this.gridColumn10.Name = "gridColumn10";
          this.gridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
          this.gridColumn10.OptionsColumn.FixedWidth = true;
          this.gridColumn10.UnboundType = DevExpress.Data.UnboundColumnType.String;
          this.gridColumn10.Width = 85;
          // 
          // pnlFooter
          // 
          this.pnlFooter.Controls.Add(this.btnCancel);
          this.pnlFooter.Controls.Add(this.btnSetSellingPrice);
          this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pnlFooter.Location = new System.Drawing.Point(3, 429);
          this.pnlFooter.Name = "pnlFooter";
          this.pnlFooter.Size = new System.Drawing.Size(999, 51);
          this.pnlFooter.TabIndex = 1;
          // 
          // btnCancel
          // 
          this.btnCancel.Location = new System.Drawing.Point(502, 12);
          this.btnCancel.Name = "btnCancel";
          this.btnCancel.Size = new System.Drawing.Size(145, 26);
          this.btnCancel.TabIndex = 1;
          this.btnCancel.Text = "&Cancel";
          this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
          // 
          // btnSetSellingPrice
          // 
          this.btnSetSellingPrice.Location = new System.Drawing.Point(351, 12);
          this.btnSetSellingPrice.Name = "btnSetSellingPrice";
          this.btnSetSellingPrice.Size = new System.Drawing.Size(145, 26);
          this.btnSetSellingPrice.TabIndex = 0;
          this.btnSetSellingPrice.Text = "&Set Selling Price";
          this.btnSetSellingPrice.Click += new System.EventHandler(this.btnSetSellingPrice_Click);
          // 
          // ctlNoPriceItems
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.tlpMain);
          this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.Name = "ctlNoPriceItems";
          this.Size = new System.Drawing.Size(1005, 483);
          this.Load += new System.EventHandler(this.ctlNoPriceItems_Load);
          this.tlpMain.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.grdvItems)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.repMemo)).EndInit();
          this.pnlFooter.ResumeLayout(false);
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private DevExpress.XtraGrid.GridControl grdItems;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvItems;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
      private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repMemo;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
      private System.Windows.Forms.Panel pnlFooter;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
      private DevExpress.XtraEditors.SimpleButton btnSetSellingPrice;

   }
}
