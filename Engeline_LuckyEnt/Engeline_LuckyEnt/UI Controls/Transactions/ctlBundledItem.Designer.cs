namespace DexterHardware_v2.UI_Controls.Transactions
{
   partial class ctlBundledItem
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
         this.pnlMain = new DevExpress.XtraEditors.PanelControl();
         this.txtPriceOverride = new DevExpress.XtraEditors.TextEdit();
         this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
         this.txtDescription = new DevExpress.XtraEditors.TextEdit();
         this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
         this.txtName = new DevExpress.XtraEditors.TextEdit();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.pnlBody = new DevExpress.XtraEditors.PanelControl();
         this.lblTotal = new DevExpress.XtraEditors.LabelControl();
         this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
         this.btnClearAll = new DevExpress.XtraEditors.SimpleButton();
         this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
         this.btnAddItem = new DevExpress.XtraEditors.SimpleButton();
         this.grdItems = new DevExpress.XtraGrid.GridControl();
         this.bSrc = new System.Windows.Forms.BindingSource(this.components);
         this.dsData = new System.Data.DataSet();
         this.tblItems = new System.Data.DataTable();
         this.dataColumn1 = new System.Data.DataColumn();
         this.dataColumn2 = new System.Data.DataColumn();
         this.dataColumn3 = new System.Data.DataColumn();
         this.dataColumn4 = new System.Data.DataColumn();
         this.dataColumn5 = new System.Data.DataColumn();
         this.dataColumn6 = new System.Data.DataColumn();
         this.dataColumn7 = new System.Data.DataColumn();
         this.grdvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.colItemID = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colQTY = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colSubTotal = new DevExpress.XtraGrid.Columns.GridColumn();
         this.ItemLookup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
         this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
         this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
         this.btnSave = new DevExpress.XtraEditors.SimpleButton();
         this.repoMemo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
         this.tlpMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
         this.pnlMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtPriceOverride.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
         this.pnlBody.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.bSrc)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dsData)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.tblItems)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvItems)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemLookup)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
         this.pnlFooter.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.repoMemo)).BeginInit();
         this.SuspendLayout();
         // 
         // tlpMain
         // 
         this.tlpMain.ColumnCount = 1;
         this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.Controls.Add(this.pnlMain, 0, 0);
         this.tlpMain.Controls.Add(this.pnlBody, 0, 1);
         this.tlpMain.Controls.Add(this.pnlFooter, 0, 2);
         this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tlpMain.Location = new System.Drawing.Point(0, 0);
         this.tlpMain.Name = "tlpMain";
         this.tlpMain.RowCount = 3;
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.27746F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
         this.tlpMain.Size = new System.Drawing.Size(610, 421);
         this.tlpMain.TabIndex = 0;
         // 
         // pnlMain
         // 
         this.pnlMain.Controls.Add(this.txtPriceOverride);
         this.pnlMain.Controls.Add(this.labelControl4);
         this.pnlMain.Controls.Add(this.txtDescription);
         this.pnlMain.Controls.Add(this.labelControl2);
         this.pnlMain.Controls.Add(this.txtName);
         this.pnlMain.Controls.Add(this.labelControl1);
         this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlMain.Location = new System.Drawing.Point(3, 3);
         this.pnlMain.Name = "pnlMain";
         this.pnlMain.Size = new System.Drawing.Size(604, 70);
         this.pnlMain.TabIndex = 0;
         // 
         // txtPriceOverride
         // 
         this.txtPriceOverride.Location = new System.Drawing.Point(457, 32);
         this.txtPriceOverride.Name = "txtPriceOverride";
         this.txtPriceOverride.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txtPriceOverride.Properties.Appearance.Options.UseFont = true;
         this.txtPriceOverride.Properties.Appearance.Options.UseTextOptions = true;
         this.txtPriceOverride.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.txtPriceOverride.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
         this.txtPriceOverride.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
         this.txtPriceOverride.Properties.AppearanceDisabled.Options.UseBackColor = true;
         this.txtPriceOverride.Properties.AppearanceDisabled.Options.UseForeColor = true;
         this.txtPriceOverride.Size = new System.Drawing.Size(137, 26);
         this.txtPriceOverride.TabIndex = 5;
         // 
         // labelControl4
         // 
         this.labelControl4.Location = new System.Drawing.Point(383, 40);
         this.labelControl4.Name = "labelControl4";
         this.labelControl4.Size = new System.Drawing.Size(68, 13);
         this.labelControl4.TabIndex = 4;
         this.labelControl4.Text = "&Price Override";
         // 
         // txtDescription
         // 
         this.txtDescription.Location = new System.Drawing.Point(70, 38);
         this.txtDescription.Name = "txtDescription";
         this.txtDescription.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
         this.txtDescription.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
         this.txtDescription.Properties.AppearanceDisabled.Options.UseBackColor = true;
         this.txtDescription.Properties.AppearanceDisabled.Options.UseForeColor = true;
         this.txtDescription.Size = new System.Drawing.Size(166, 20);
         this.txtDescription.TabIndex = 3;
         // 
         // labelControl2
         // 
         this.labelControl2.Location = new System.Drawing.Point(5, 41);
         this.labelControl2.Name = "labelControl2";
         this.labelControl2.Size = new System.Drawing.Size(53, 13);
         this.labelControl2.TabIndex = 2;
         this.labelControl2.Text = "&Description";
         // 
         // txtName
         // 
         this.txtName.Location = new System.Drawing.Point(70, 12);
         this.txtName.Name = "txtName";
         this.txtName.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
         this.txtName.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
         this.txtName.Properties.AppearanceDisabled.Options.UseBackColor = true;
         this.txtName.Properties.AppearanceDisabled.Options.UseForeColor = true;
         this.txtName.Size = new System.Drawing.Size(166, 20);
         this.txtName.TabIndex = 1;
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(5, 15);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(27, 13);
         this.labelControl1.TabIndex = 0;
         this.labelControl1.Text = "&Name";
         // 
         // pnlBody
         // 
         this.pnlBody.Controls.Add(this.lblTotal);
         this.pnlBody.Controls.Add(this.labelControl3);
         this.pnlBody.Controls.Add(this.btnClearAll);
         this.pnlBody.Controls.Add(this.btnRemove);
         this.pnlBody.Controls.Add(this.btnAddItem);
         this.pnlBody.Controls.Add(this.grdItems);
         this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlBody.Location = new System.Drawing.Point(3, 79);
         this.pnlBody.Name = "pnlBody";
         this.pnlBody.Size = new System.Drawing.Size(604, 277);
         this.pnlBody.TabIndex = 1;
         // 
         // lblTotal
         // 
         this.lblTotal.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblTotal.Appearance.Options.UseFont = true;
         this.lblTotal.Appearance.Options.UseTextOptions = true;
         this.lblTotal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.lblTotal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
         this.lblTotal.Location = new System.Drawing.Point(457, 249);
         this.lblTotal.Name = "lblTotal";
         this.lblTotal.Size = new System.Drawing.Size(142, 18);
         this.lblTotal.TabIndex = 5;
         this.lblTotal.Text = "0.00";
         // 
         // labelControl3
         // 
         this.labelControl3.Location = new System.Drawing.Point(419, 253);
         this.labelControl3.Name = "labelControl3";
         this.labelControl3.Size = new System.Drawing.Size(32, 13);
         this.labelControl3.TabIndex = 4;
         this.labelControl3.Text = "TOTAL";
         // 
         // btnClearAll
         // 
         this.btnClearAll.Location = new System.Drawing.Point(176, 248);
         this.btnClearAll.Name = "btnClearAll";
         this.btnClearAll.Size = new System.Drawing.Size(81, 22);
         this.btnClearAll.TabIndex = 3;
         this.btnClearAll.Text = "Clear A&ll";
         this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
         // 
         // btnRemove
         // 
         this.btnRemove.Location = new System.Drawing.Point(89, 248);
         this.btnRemove.Name = "btnRemove";
         this.btnRemove.Size = new System.Drawing.Size(81, 22);
         this.btnRemove.TabIndex = 2;
         this.btnRemove.Text = "&Remove Item";
         this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
         // 
         // btnAddItem
         // 
         this.btnAddItem.Location = new System.Drawing.Point(2, 248);
         this.btnAddItem.Name = "btnAddItem";
         this.btnAddItem.Size = new System.Drawing.Size(81, 22);
         this.btnAddItem.TabIndex = 1;
         this.btnAddItem.Text = "&Add Item";
         this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
         // 
         // grdItems
         // 
         this.grdItems.DataSource = this.bSrc;
         this.grdItems.Dock = System.Windows.Forms.DockStyle.Top;
         this.grdItems.Location = new System.Drawing.Point(2, 2);
         this.grdItems.MainView = this.grdvItems;
         this.grdItems.Name = "grdItems";
         this.grdItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookup,
            this.repoMemo});
         this.grdItems.Size = new System.Drawing.Size(600, 240);
         this.grdItems.TabIndex = 0;
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
         this.dsData.DataSetName = "NewDataSet";
         this.dsData.Tables.AddRange(new System.Data.DataTable[] {
            this.tblItems});
         // 
         // tblItems
         // 
         this.tblItems.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7});
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
         this.dataColumn3.ColumnName = "QTY";
         this.dataColumn3.DataType = typeof(int);
         // 
         // dataColumn4
         // 
         this.dataColumn4.ColumnName = "UnitPrice";
         this.dataColumn4.DataType = typeof(double);
         // 
         // dataColumn5
         // 
         this.dataColumn5.ColumnName = "SubTotal";
         this.dataColumn5.DataType = typeof(double);
         // 
         // dataColumn6
         // 
         this.dataColumn6.ColumnName = "FabItem";
         this.dataColumn6.DataType = typeof(bool);
         // 
         // dataColumn7
         // 
         this.dataColumn7.ColumnName = "Description";
         // 
         // grdvItems
         // 
         this.grdvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemID,
            this.colItemName,
            this.colQTY,
            this.colUnitPrice,
            this.colSubTotal});
         this.grdvItems.GridControl = this.grdItems;
         this.grdvItems.Name = "grdvItems";
         this.grdvItems.OptionsView.RowAutoHeight = true;
         this.grdvItems.OptionsView.ShowGroupPanel = false;
         this.grdvItems.OptionsView.ShowIndicator = false;
         this.grdvItems.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grdvItems_ValidateRow);
         // 
         // colItemID
         // 
         this.colItemID.FieldName = "ItemID";
         this.colItemID.Name = "colItemID";
         this.colItemID.Width = 117;
         // 
         // colItemName
         // 
         this.colItemName.ColumnEdit = this.repoMemo;
         this.colItemName.FieldName = "ItemName";
         this.colItemName.Name = "colItemName";
         this.colItemName.OptionsColumn.AllowFocus = false;
         this.colItemName.Visible = true;
         this.colItemName.VisibleIndex = 0;
         this.colItemName.Width = 285;
         // 
         // colQTY
         // 
         this.colQTY.FieldName = "QTY";
         this.colQTY.Name = "colQTY";
         this.colQTY.OptionsColumn.FixedWidth = true;
         this.colQTY.Visible = true;
         this.colQTY.VisibleIndex = 1;
         this.colQTY.Width = 85;
         // 
         // colUnitPrice
         // 
         this.colUnitPrice.DisplayFormat.FormatString = "{0:N2}";
         this.colUnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.colUnitPrice.FieldName = "UnitPrice";
         this.colUnitPrice.Name = "colUnitPrice";
         this.colUnitPrice.OptionsColumn.FixedWidth = true;
         this.colUnitPrice.Visible = true;
         this.colUnitPrice.VisibleIndex = 2;
         this.colUnitPrice.Width = 100;
         // 
         // colSubTotal
         // 
         this.colSubTotal.DisplayFormat.FormatString = "{0:N2}";
         this.colSubTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.colSubTotal.FieldName = "SubTotal";
         this.colSubTotal.Name = "colSubTotal";
         this.colSubTotal.OptionsColumn.AllowEdit = false;
         this.colSubTotal.OptionsColumn.AllowFocus = false;
         this.colSubTotal.OptionsColumn.FixedWidth = true;
         this.colSubTotal.Visible = true;
         this.colSubTotal.VisibleIndex = 3;
         this.colSubTotal.Width = 100;
         // 
         // ItemLookup
         // 
         this.ItemLookup.AutoHeight = false;
         this.ItemLookup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.ItemLookup.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ItemID", 65, DevExpress.Utils.FormatType.None, "000000", true, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 200, "Item Name")});
         this.ItemLookup.DisplayMember = "Name";
         this.ItemLookup.DropDownRows = 10;
         this.ItemLookup.Name = "ItemLookup";
         this.ItemLookup.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.DoubleClick;
         this.ItemLookup.SortColumnIndex = 1;
         this.ItemLookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
         // 
         // pnlFooter
         // 
         this.pnlFooter.Controls.Add(this.btnCancel);
         this.pnlFooter.Controls.Add(this.btnSave);
         this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlFooter.Location = new System.Drawing.Point(3, 362);
         this.pnlFooter.Name = "pnlFooter";
         this.pnlFooter.Size = new System.Drawing.Size(604, 56);
         this.pnlFooter.TabIndex = 2;
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(305, 14);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(91, 28);
         this.btnCancel.TabIndex = 1;
         this.btnCancel.Text = "&Cancel";
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // btnSave
         // 
         this.btnSave.Location = new System.Drawing.Point(208, 14);
         this.btnSave.Name = "btnSave";
         this.btnSave.Size = new System.Drawing.Size(91, 28);
         this.btnSave.TabIndex = 0;
         this.btnSave.Text = "&Save";
         this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
         // 
         // repoMemo
         // 
         this.repoMemo.Name = "repoMemo";
         // 
         // ctlBundledItem
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tlpMain);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlBundledItem";
         this.Size = new System.Drawing.Size(610, 421);
         this.Load += new System.EventHandler(this.ctlBundledItem_Load);
         this.tlpMain.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
         this.pnlMain.ResumeLayout(false);
         this.pnlMain.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtPriceOverride.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
         this.pnlBody.ResumeLayout(false);
         this.pnlBody.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.bSrc)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dsData)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.tblItems)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvItems)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ItemLookup)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
         this.pnlFooter.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.repoMemo)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private DevExpress.XtraGrid.GridControl grdItems;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvItems;
      private System.Windows.Forms.BindingSource bSrc;
      private System.Data.DataSet dsData;
      private System.Data.DataTable tblItems;
      private System.Data.DataColumn dataColumn1;
      private System.Data.DataColumn dataColumn2;
      private System.Data.DataColumn dataColumn3;
      private System.Data.DataColumn dataColumn4;
      private System.Data.DataColumn dataColumn5;
      private DevExpress.XtraGrid.Columns.GridColumn colItemID;
      private DevExpress.XtraGrid.Columns.GridColumn colItemName;
      private DevExpress.XtraGrid.Columns.GridColumn colQTY;
      private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
      private DevExpress.XtraGrid.Columns.GridColumn colSubTotal;
      private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookup;
      private DevExpress.XtraEditors.PanelControl pnlMain;
      private DevExpress.XtraEditors.TextEdit txtDescription;
      private DevExpress.XtraEditors.LabelControl labelControl2;
      private DevExpress.XtraEditors.TextEdit txtName;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.PanelControl pnlBody;
      private DevExpress.XtraEditors.SimpleButton btnClearAll;
      private DevExpress.XtraEditors.SimpleButton btnRemove;
      private DevExpress.XtraEditors.SimpleButton btnAddItem;
      private DevExpress.XtraEditors.LabelControl lblTotal;
      private DevExpress.XtraEditors.LabelControl labelControl3;
      private DevExpress.XtraEditors.PanelControl pnlFooter;
      private System.Data.DataColumn dataColumn6;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
      private DevExpress.XtraEditors.SimpleButton btnSave;
      private DevExpress.XtraEditors.TextEdit txtPriceOverride;
      private DevExpress.XtraEditors.LabelControl labelControl4;
      private System.Data.DataColumn dataColumn7;
      private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repoMemo;
   }
}
