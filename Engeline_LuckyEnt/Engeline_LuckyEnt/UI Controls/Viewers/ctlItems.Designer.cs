namespace Engeline_LuckyEnt.UI_Controls
{
   partial class ctlItems
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
          this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
          this.grdItems = new DevExpress.XtraGrid.GridControl();
          this.bSrc = new System.Windows.Forms.BindingSource(this.components);
          this.dsData = new System.Data.DataSet();
          this.tblItems = new System.Data.DataTable();
          this.dataColumn1 = new System.Data.DataColumn();
          this.dataColumn2 = new System.Data.DataColumn();
          this.dataColumn3 = new System.Data.DataColumn();
          this.dataColumn10 = new System.Data.DataColumn();
          this.dataColumn4 = new System.Data.DataColumn();
          this.dataColumn5 = new System.Data.DataColumn();
          this.dataColumn6 = new System.Data.DataColumn();
          this.dataColumn7 = new System.Data.DataColumn();
          this.dataColumn8 = new System.Data.DataColumn();
          this.dataColumn9 = new System.Data.DataColumn();
          this.dataColumn11 = new System.Data.DataColumn();
          
          this.grdvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
          this.ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
          this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
          this.Code = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.repCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
          this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
          this.tlpFooter = new System.Windows.Forms.TableLayoutPanel();
          this.btnSave = new DevExpress.XtraEditors.SimpleButton();
          this.btnImportCSV = new DevExpress.XtraEditors.SimpleButton();
          this.btnDeleteItem = new DevExpress.XtraEditors.SimpleButton();
          this.btnClose = new DevExpress.XtraEditors.SimpleButton();
          this.pnlHeader = new System.Windows.Forms.Panel();
          this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
          this.btnClearFilters = new DevExpress.XtraEditors.SimpleButton();
          this.btnFilter = new DevExpress.XtraEditors.SimpleButton();
          this.txtFilter = new DevExpress.XtraEditors.TextEdit();
          this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
          this.cmOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
          this.tlpMain.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.bSrc)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.dsData)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.tblItems)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.grdvItems)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.repCheckEdit)).BeginInit();
          this.tlpFooter.SuspendLayout();
          this.pnlHeader.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).BeginInit();
          this.SuspendLayout();
          // 
          // tlpMain
          // 
          this.tlpMain.ColumnCount = 1;
          this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
          this.tlpMain.Controls.Add(this.grdItems, 0, 1);
          this.tlpMain.Controls.Add(this.tlpFooter, 0, 2);
          this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
          this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
          this.tlpMain.Location = new System.Drawing.Point(0, 0);
          this.tlpMain.Name = "tlpMain";
          this.tlpMain.RowCount = 3;
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
          this.tlpMain.Size = new System.Drawing.Size(676, 488);
          this.tlpMain.TabIndex = 0;
          // 
          // grdItems
          // 
          this.grdItems.DataSource = this.bSrc;
          this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
          this.grdItems.Location = new System.Drawing.Point(3, 50);
          this.grdItems.MainView = this.grdvItems;
          this.grdItems.Name = "grdItems";
          this.grdItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCheckEdit});
          this.grdItems.Size = new System.Drawing.Size(670, 396);
          this.grdItems.TabIndex = 1;
          this.grdItems.ToolTipController = this.toolTipController1;
          this.grdItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvItems});
          // 
          // bSrc
          // 
          this.bSrc.DataMember = "tblItems";
          this.bSrc.DataSource = this.dsData;
          // 
          // dsData
          // 
          this.dsData.DataSetName = "dsData";
          this.dsData.Tables.AddRange(new System.Data.DataTable[] {
            this.tblItems});
          // 
          // tblItems
          // 
          this.tblItems.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn10,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn11,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9});
          this.tblItems.TableName = "tblItems";
          // 
          // dataColumn1
          // 
          this.dataColumn1.ColumnName = "ItemID";
          this.dataColumn1.DataType = typeof(int);
          // 
          // dataColumn2
          // 
          this.dataColumn2.ColumnName = "ItemName";
          // 
          // dataColumn3
          // 
          this.dataColumn3.ColumnName = "Description";
          // 
          // dataColumn10
          // 
          this.dataColumn10.ColumnName = "Code";
          // 
          // dataColumn4
          // 
          this.dataColumn4.ColumnName = "Price";
          this.dataColumn4.DataType = typeof(double);
          // 
          // dataColumn5
          // 
          this.dataColumn5.ColumnName = "Price2";
          this.dataColumn5.DataType = typeof(double);
          // 
          // dataColumn6
          // 
          this.dataColumn6.ColumnName = "MetersPerRoll";
          this.dataColumn6.DataType = typeof(int);
          //
          // dataColumn11
          //
          this.dataColumn11.ColumnName = "Unit";
          // 
          // dataColumn7
          // 
          this.dataColumn7.ColumnName = "LowThreshold";
          this.dataColumn7.DataType = typeof(int);
          // 
          // dataColumn8
          // 
          this.dataColumn8.ColumnName = "Dirty";
          this.dataColumn8.DataType = typeof(bool);
          // 
          // dataColumn9
          // 
          this.dataColumn9.ColumnName = "IsWire";
          this.dataColumn9.DataType = typeof(bool);
          // 
          // dataColumn11
          // 
          //this.dataColumn11.ColumnName = "Unit";
          // 
          // grdvItems
          // 
          this.grdvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ItemName,
            this.Description,
            this.Code,
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn2,
            this.gridColumn6});
          this.grdvItems.GridControl = this.grdItems;
          this.grdvItems.Name = "grdvItems";
          this.grdvItems.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
          this.grdvItems.OptionsView.ShowGroupPanel = false;
          this.grdvItems.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdvItems_InitNewRow);
          this.grdvItems.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdvItems_CellValueChanged);
          this.grdvItems.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grdvItems_ValidateRow);
          // 
          // ItemName
          // 
          this.ItemName.Caption = "Item Name";
          this.ItemName.FieldName = "ItemName";
          this.ItemName.Name = "ItemName";
          this.ItemName.Visible = true;
          this.ItemName.VisibleIndex = 0;
          this.ItemName.Width = 93;
          // 
          // Description
          // 
          this.Description.Caption = "Description";
          this.Description.FieldName = "Description";
          this.Description.Name = "Description";
          this.Description.Visible = true;
          this.Description.VisibleIndex = 1;
          this.Description.Width = 203;
          // 
          // Code
          // 
          this.Code.Caption = "Code";
          this.Code.FieldName = "Code";
          this.Code.Name = "Code";
          this.Code.Visible = true;
          this.Code.VisibleIndex = 2;
          this.Code.Width = 86;
          // 
          // gridColumn1
          // 
          this.gridColumn1.Caption = "Wire Type";
          this.gridColumn1.ColumnEdit = this.repCheckEdit;
          this.gridColumn1.FieldName = "IsWire";
          this.gridColumn1.Name = "gridColumn1";
          this.gridColumn1.OptionsColumn.AllowSize = false;
          this.gridColumn1.OptionsColumn.FixedWidth = true;
          // 
          // repCheckEdit
          // 
          this.repCheckEdit.AutoHeight = false;
          this.repCheckEdit.Name = "repCheckEdit";
          // 
          // gridColumn3
          // 
          this.gridColumn3.Caption = "Price";
          this.gridColumn3.DisplayFormat.FormatString = "#,##0.00";
          this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
          this.gridColumn3.FieldName = "Price";
          this.gridColumn3.Name = "gridColumn3";
          this.gridColumn3.OptionsColumn.FixedWidth = true;
          this.gridColumn3.Visible = true;
          this.gridColumn3.VisibleIndex = 3;
          this.gridColumn3.Width = 100;
          // 
          // gridColumn4
          // 
          this.gridColumn4.Caption = "Price/mtr";
          this.gridColumn4.DisplayFormat.FormatString = "#,##0.00";
          this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
          this.gridColumn4.FieldName = "Price2";
          this.gridColumn4.Name = "gridColumn4";
          this.gridColumn4.OptionsColumn.FixedWidth = true;
          this.gridColumn4.Width = 100;
          // 
          // gridColumn5
          // 
          this.gridColumn5.Caption = "Mtrs/roll";
          this.gridColumn5.FieldName = "MetersPerRoll";
          this.gridColumn5.Name = "gridColumn5";
          this.gridColumn5.OptionsColumn.FixedWidth = true;
          this.gridColumn5.Width = 70;
          // 
          // gridColumn2
          // 
          this.gridColumn2.Caption = "Unit";
          this.gridColumn2.FieldName = "Unit";
          this.gridColumn2.Name = "gridColumn2";
          this.gridColumn2.Visible = true;
          this.gridColumn2.VisibleIndex = 4;
          this.gridColumn2.Width = 80;
          // 
          // gridColumn6
          // 
          this.gridColumn6.Caption = "Low Threshold";
          this.gridColumn6.FieldName = "LowThreshold";
          this.gridColumn6.Name = "gridColumn6";
          this.gridColumn6.OptionsColumn.FixedWidth = true;
          this.gridColumn6.Visible = true;
          this.gridColumn6.VisibleIndex = 5;
          this.gridColumn6.Width = 95;
          // 
          // tlpFooter
          // 
          this.tlpFooter.ColumnCount = 7;
          this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
          this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
          this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
          this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
          this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
          this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
          this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
          this.tlpFooter.Controls.Add(this.btnSave, 2, 0);
          this.tlpFooter.Controls.Add(this.btnImportCSV, 0, 0);
          this.tlpFooter.Controls.Add(this.btnDeleteItem, 3, 0);
          this.tlpFooter.Controls.Add(this.btnClose, 6, 0);
          this.tlpFooter.Dock = System.Windows.Forms.DockStyle.Fill;
          this.tlpFooter.Location = new System.Drawing.Point(3, 452);
          this.tlpFooter.Name = "tlpFooter";
          this.tlpFooter.RowCount = 1;
          this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
          this.tlpFooter.Size = new System.Drawing.Size(670, 33);
          this.tlpFooter.TabIndex = 2;
          // 
          // btnSave
          // 
          this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
          this.btnSave.Enabled = false;
          this.btnSave.Location = new System.Drawing.Point(188, 3);
          this.btnSave.Name = "btnSave";
          this.btnSave.Size = new System.Drawing.Size(94, 27);
          this.btnSave.TabIndex = 1;
          this.btnSave.Text = "&Save";
          this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
          // 
          // btnImportCSV
          // 
          this.btnImportCSV.Dock = System.Windows.Forms.DockStyle.Fill;
          this.btnImportCSV.Location = new System.Drawing.Point(3, 3);
          this.btnImportCSV.Name = "btnImportCSV";
          this.btnImportCSV.Size = new System.Drawing.Size(94, 27);
          this.btnImportCSV.TabIndex = 0;
          this.btnImportCSV.Text = "Import CSV";
          this.btnImportCSV.Click += new System.EventHandler(this.btnImportCSV_Click);
          // 
          // btnDeleteItem
          // 
          this.btnDeleteItem.Dock = System.Windows.Forms.DockStyle.Fill;
          this.btnDeleteItem.Enabled = false;
          this.btnDeleteItem.Location = new System.Drawing.Point(288, 3);
          this.btnDeleteItem.Name = "btnDeleteItem";
          this.btnDeleteItem.Size = new System.Drawing.Size(94, 27);
          this.btnDeleteItem.TabIndex = 2;
          this.btnDeleteItem.Text = "&Delete Item";
          this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
          // 
          // btnClose
          // 
          this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
          this.btnClose.Location = new System.Drawing.Point(573, 3);
          this.btnClose.Name = "btnClose";
          this.btnClose.Size = new System.Drawing.Size(94, 27);
          this.btnClose.TabIndex = 3;
          this.btnClose.Text = "&Close";
          this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
          // 
          // pnlHeader
          // 
          this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.pnlHeader.Controls.Add(this.btnEdit);
          this.pnlHeader.Controls.Add(this.btnClearFilters);
          this.pnlHeader.Controls.Add(this.btnFilter);
          this.pnlHeader.Controls.Add(this.txtFilter);
          this.pnlHeader.Controls.Add(this.labelControl1);
          this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pnlHeader.Location = new System.Drawing.Point(3, 3);
          this.pnlHeader.Name = "pnlHeader";
          this.pnlHeader.Size = new System.Drawing.Size(670, 41);
          this.pnlHeader.TabIndex = 0;
          // 
          // btnEdit
          // 
          this.btnEdit.Location = new System.Drawing.Point(572, 9);
          this.btnEdit.Name = "btnEdit";
          this.btnEdit.Size = new System.Drawing.Size(95, 20);
          this.btnEdit.TabIndex = 4;
          this.btnEdit.Text = "&Modify List";
          this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
          // 
          // btnClearFilters
          // 
          this.btnClearFilters.Location = new System.Drawing.Point(269, 11);
          this.btnClearFilters.Name = "btnClearFilters";
          this.btnClearFilters.Size = new System.Drawing.Size(72, 20);
          this.btnClearFilters.TabIndex = 3;
          this.btnClearFilters.Text = "&Clear Filters";
          this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
          // 
          // btnFilter
          // 
          this.btnFilter.Location = new System.Drawing.Point(191, 11);
          this.btnFilter.Name = "btnFilter";
          this.btnFilter.Size = new System.Drawing.Size(72, 20);
          this.btnFilter.TabIndex = 2;
          this.btnFilter.Text = "Filter";
          this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
          // 
          // txtFilter
          // 
          this.txtFilter.Location = new System.Drawing.Point(43, 11);
          this.txtFilter.Name = "txtFilter";
          this.txtFilter.Size = new System.Drawing.Size(142, 20);
          this.txtFilter.TabIndex = 1;
          // 
          // labelControl1
          // 
          this.labelControl1.Location = new System.Drawing.Point(13, 14);
          this.labelControl1.Name = "labelControl1";
          this.labelControl1.Size = new System.Drawing.Size(24, 13);
          this.labelControl1.TabIndex = 0;
          this.labelControl1.Text = "&Filter";
          // 
          // cmOptions
          // 
          this.cmOptions.Name = "cmOptions";
          this.cmOptions.Size = new System.Drawing.Size(61, 4);
          // 
          // ctlItems
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.tlpMain);
          this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.Name = "ctlItems";
          this.Size = new System.Drawing.Size(676, 488);
          this.Load += new System.EventHandler(this.ctlItems_Load);
          this.tlpMain.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.bSrc)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.dsData)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.tblItems)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.grdvItems)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.repCheckEdit)).EndInit();
          this.tlpFooter.ResumeLayout(false);
          this.pnlHeader.ResumeLayout(false);
          this.pnlHeader.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private DevExpress.XtraGrid.GridControl grdItems;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvItems;
      private DevExpress.XtraGrid.Columns.GridColumn ItemName;
      private DevExpress.XtraGrid.Columns.GridColumn Description;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
      private System.Windows.Forms.BindingSource bSrc;
      private System.Data.DataSet dsData;
      private System.Data.DataTable tblItems;
      private System.Data.DataColumn dataColumn1;
      private System.Data.DataColumn dataColumn2;
      private System.Data.DataColumn dataColumn3;
      private System.Data.DataColumn dataColumn4;
      private System.Data.DataColumn dataColumn5;
      private System.Data.DataColumn dataColumn6;
      private System.Data.DataColumn dataColumn7;
      private System.Data.DataColumn dataColumn8;
      private System.Data.DataColumn dataColumn11;
      private System.Windows.Forms.TableLayoutPanel tlpFooter;
      private DevExpress.XtraEditors.SimpleButton btnSave;
      private DevExpress.XtraEditors.SimpleButton btnClose;
      private System.Windows.Forms.Panel pnlHeader;
      private DevExpress.XtraEditors.SimpleButton btnImportCSV;
      private DevExpress.XtraEditors.SimpleButton btnFilter;
      private DevExpress.XtraEditors.TextEdit txtFilter;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.SimpleButton btnClearFilters;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
      private DevExpress.XtraEditors.SimpleButton btnEdit;
      private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckEdit;
      private System.Data.DataColumn dataColumn9;
      private DevExpress.Utils.ToolTipController toolTipController1;
      private DevExpress.XtraEditors.SimpleButton btnDeleteItem;
      private System.Windows.Forms.ContextMenuStrip cmOptions;
      private DevExpress.XtraGrid.Columns.GridColumn Code;
      private System.Data.DataColumn dataColumn10;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
   }
}
