namespace DexterHardware_v2.UI_Controls.Transactions
{
   partial class ctlSelectItems_Bundle
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
         this.ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.pnlHeader = new System.Windows.Forms.Panel();
         this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
         this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
         this.txtSearch = new DevExpress.XtraEditors.TextEdit();
         this.label1 = new System.Windows.Forms.Label();
         this.pnlFooter = new System.Windows.Forms.Panel();
         this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
         this.btnAddItem = new DevExpress.XtraEditors.SimpleButton();
         this.tlpMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvItems)).BeginInit();
         this.pnlHeader.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
         this.pnlFooter.SuspendLayout();
         this.SuspendLayout();
         // 
         // tlpMain
         // 
         this.tlpMain.ColumnCount = 1;
         this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.Controls.Add(this.grdItems, 0, 1);
         this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
         this.tlpMain.Controls.Add(this.pnlFooter, 0, 2);
         this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tlpMain.Location = new System.Drawing.Point(0, 0);
         this.tlpMain.Name = "tlpMain";
         this.tlpMain.RowCount = 3;
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.05085F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
         this.tlpMain.Size = new System.Drawing.Size(609, 398);
         this.tlpMain.TabIndex = 0;
         // 
         // grdItems
         // 
         this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdItems.Location = new System.Drawing.Point(3, 72);
         this.grdItems.MainView = this.grdvItems;
         this.grdItems.Name = "grdItems";
         this.grdItems.Size = new System.Drawing.Size(603, 247);
         this.grdItems.TabIndex = 1;
         this.grdItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvItems});
         this.grdItems.Leave += new System.EventHandler(this.grdItems_Leave);
         // 
         // grdvItems
         // 
         this.grdvItems.Appearance.SelectedRow.BackColor = System.Drawing.Color.White;
         this.grdvItems.Appearance.SelectedRow.BorderColor = System.Drawing.Color.Black;
         this.grdvItems.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
         this.grdvItems.Appearance.SelectedRow.Options.UseBackColor = true;
         this.grdvItems.Appearance.SelectedRow.Options.UseBorderColor = true;
         this.grdvItems.Appearance.SelectedRow.Options.UseForeColor = true;
         this.grdvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.ItemName,
            this.Description,
            this.gridColumn3});
         this.grdvItems.GridControl = this.grdItems;
         this.grdvItems.Name = "grdvItems";
         this.grdvItems.OptionsBehavior.Editable = false;
         this.grdvItems.OptionsBehavior.FocusLeaveOnTab = true;
         this.grdvItems.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdvItems.OptionsSelection.EnableAppearanceHideSelection = false;
         this.grdvItems.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
         this.grdvItems.OptionsView.ShowGroupPanel = false;
         this.grdvItems.OptionsView.ShowIndicator = false;
         this.grdvItems.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grdvItems_CustomUnboundColumnData);
         this.grdvItems.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdvItems_FocusedRowChanged);
         // 
         // gridColumn1
         // 
         this.gridColumn1.Caption = "gridColumn1";
         this.gridColumn1.FieldName = "ID";
         this.gridColumn1.Name = "gridColumn1";
         // 
         // ItemName
         // 
         this.ItemName.Caption = "Item Name";
         this.ItemName.FieldName = "Name";
         this.ItemName.Name = "ItemName";
         this.ItemName.Visible = true;
         this.ItemName.VisibleIndex = 0;
         this.ItemName.Width = 205;
         // 
         // Description
         // 
         this.Description.Caption = "Description";
         this.Description.FieldName = "Description";
         this.Description.Name = "Description";
         this.Description.Visible = true;
         this.Description.VisibleIndex = 1;
         this.Description.Width = 235;
         // 
         // gridColumn3
         // 
         this.gridColumn3.Caption = "Price";
         this.gridColumn3.DisplayFormat.FormatString = "0:N2";
         this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.gridColumn3.FieldName = "UnitPrice";
         this.gridColumn3.ImageAlignment = System.Drawing.StringAlignment.Far;
         this.gridColumn3.Name = "gridColumn3";
         this.gridColumn3.OptionsColumn.AllowSize = false;
         this.gridColumn3.OptionsColumn.FixedWidth = true;
         this.gridColumn3.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
         this.gridColumn3.Visible = true;
         this.gridColumn3.VisibleIndex = 2;
         this.gridColumn3.Width = 81;
         // 
         // pnlHeader
         // 
         this.pnlHeader.Controls.Add(this.radioGroup1);
         this.pnlHeader.Controls.Add(this.btnSearch);
         this.pnlHeader.Controls.Add(this.txtSearch);
         this.pnlHeader.Controls.Add(this.label1);
         this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlHeader.Location = new System.Drawing.Point(3, 3);
         this.pnlHeader.Name = "pnlHeader";
         this.pnlHeader.Size = new System.Drawing.Size(603, 63);
         this.pnlHeader.TabIndex = 0;
         // 
         // radioGroup1
         // 
         this.radioGroup1.Location = new System.Drawing.Point(3, 7);
         this.radioGroup1.Name = "radioGroup1";
         this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "&Normal Items"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "&Fabricated Items")});
         this.radioGroup1.Size = new System.Drawing.Size(303, 21);
         this.radioGroup1.TabIndex = 0;
         // 
         // btnSearch
         // 
         this.btnSearch.Location = new System.Drawing.Point(218, 34);
         this.btnSearch.Name = "btnSearch";
         this.btnSearch.Size = new System.Drawing.Size(88, 20);
         this.btnSearch.TabIndex = 3;
         this.btnSearch.Text = "Search";
         this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
         // 
         // txtSearch
         // 
         this.txtSearch.Location = new System.Drawing.Point(44, 34);
         this.txtSearch.Name = "txtSearch";
         this.txtSearch.Size = new System.Drawing.Size(168, 20);
         this.txtSearch.TabIndex = 2;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(-2, 37);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(40, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "&Search";
         // 
         // pnlFooter
         // 
         this.pnlFooter.Controls.Add(this.btnCancel);
         this.pnlFooter.Controls.Add(this.btnAddItem);
         this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlFooter.Location = new System.Drawing.Point(3, 325);
         this.pnlFooter.Name = "pnlFooter";
         this.pnlFooter.Size = new System.Drawing.Size(603, 70);
         this.pnlFooter.TabIndex = 2;
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(307, 11);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(88, 28);
         this.btnCancel.TabIndex = 1;
         this.btnCancel.Text = "&Cancel";
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // btnAddItem
         // 
         this.btnAddItem.Location = new System.Drawing.Point(208, 11);
         this.btnAddItem.Name = "btnAddItem";
         this.btnAddItem.Size = new System.Drawing.Size(88, 28);
         this.btnAddItem.TabIndex = 0;
         this.btnAddItem.Text = "&Add Item";
         this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
         // 
         // ctlSelectItems_Bundle
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tlpMain);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlSelectItems_Bundle";
         this.Size = new System.Drawing.Size(609, 398);
         this.Load += new System.EventHandler(this.ctlSelectItems_PO_Load);
         this.tlpMain.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvItems)).EndInit();
         this.pnlHeader.ResumeLayout(false);
         this.pnlHeader.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
         this.pnlFooter.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private DevExpress.XtraGrid.GridControl grdItems;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvItems;
      private DevExpress.XtraGrid.Columns.GridColumn ItemName;
      private DevExpress.XtraGrid.Columns.GridColumn Description;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
      private System.Windows.Forms.Panel pnlHeader;
      private DevExpress.XtraEditors.SimpleButton btnSearch;
      private DevExpress.XtraEditors.TextEdit txtSearch;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Panel pnlFooter;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
      private DevExpress.XtraEditors.SimpleButton btnAddItem;
      private DevExpress.XtraEditors.RadioGroup radioGroup1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
   }
}
