namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
   partial class ctlPurchaseOrder
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
          DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
          this.colQTY2 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
          this.pnlHeader = new System.Windows.Forms.Panel();
          this.txtNotes = new DevExpress.XtraEditors.MemoEdit();
          this.label7 = new System.Windows.Forms.Label();
          this.cboStatus = new System.Windows.Forms.ComboBox();
          this.label6 = new System.Windows.Forms.Label();
          this.dtDate = new System.Windows.Forms.DateTimePicker();
          this.label5 = new System.Windows.Forms.Label();
          this.txtGracePeriod = new DevExpress.XtraEditors.TextEdit();
          this.label4 = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this.lblPONumber = new System.Windows.Forms.Label();
          this.label2 = new System.Windows.Forms.Label();
          this.cboCustomer = new System.Windows.Forms.ComboBox();
          this.lblSupplier = new System.Windows.Forms.Label();
          this.txtAddress = new DevExpress.XtraEditors.MemoEdit();
          this.pnlFooter = new System.Windows.Forms.Panel();
          this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
          this.btnSave = new DevExpress.XtraEditors.SimpleButton();
          this.lblTotal = new System.Windows.Forms.Label();
          this.label8 = new System.Windows.Forms.Label();
          this.pnlBody = new DevExpress.XtraEditors.PanelControl();
          this.btnAddMiscItem = new DevExpress.XtraEditors.SimpleButton();
          this.btnRemoveItem = new DevExpress.XtraEditors.SimpleButton();
          this.btnAddItem = new DevExpress.XtraEditors.SimpleButton();
          this.grdItems = new DevExpress.XtraGrid.GridControl();
          this.grdvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
          this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
          this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
          this.bSrc = new System.Windows.Forms.BindingSource(this.components);
          this.dsData = new System.Data.DataSet();
          this.tblItems = new System.Data.DataTable();
          this.dataColumn1 = new System.Data.DataColumn();
          this.dataColumn2 = new System.Data.DataColumn();
          this.tlpMain.SuspendLayout();
          this.pnlHeader.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.txtGracePeriod.Properties)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
          this.pnlFooter.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
          this.pnlBody.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.grdvItems)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.bSrc)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.dsData)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.tblItems)).BeginInit();
          this.SuspendLayout();
          // 
          // colQTY2
          // 
          this.colQTY2.Caption = "QTY2";
          this.colQTY2.FieldName = "QTY2";
          this.colQTY2.Name = "colQTY2";
          this.colQTY2.OptionsColumn.AllowMove = false;
          this.colQTY2.OptionsColumn.AllowSize = false;
          this.colQTY2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
          this.colQTY2.OptionsColumn.FixedWidth = true;
          this.colQTY2.OptionsFilter.AllowFilter = false;
          this.colQTY2.Width = 60;
          // 
          // tlpMain
          // 
          this.tlpMain.ColumnCount = 1;
          this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
          this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
          this.tlpMain.Controls.Add(this.pnlFooter, 0, 2);
          this.tlpMain.Controls.Add(this.pnlBody, 0, 1);
          this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
          this.tlpMain.Location = new System.Drawing.Point(0, 0);
          this.tlpMain.Name = "tlpMain";
          this.tlpMain.RowCount = 3;
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 155F));
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.82758F));
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 114F));
          this.tlpMain.Size = new System.Drawing.Size(752, 525);
          this.tlpMain.TabIndex = 0;
          // 
          // pnlHeader
          // 
          this.pnlHeader.Controls.Add(this.txtNotes);
          this.pnlHeader.Controls.Add(this.label7);
          this.pnlHeader.Controls.Add(this.cboStatus);
          this.pnlHeader.Controls.Add(this.label6);
          this.pnlHeader.Controls.Add(this.dtDate);
          this.pnlHeader.Controls.Add(this.label5);
          this.pnlHeader.Controls.Add(this.txtGracePeriod);
          this.pnlHeader.Controls.Add(this.label4);
          this.pnlHeader.Controls.Add(this.label3);
          this.pnlHeader.Controls.Add(this.lblPONumber);
          this.pnlHeader.Controls.Add(this.label2);
          this.pnlHeader.Controls.Add(this.cboCustomer);
          this.pnlHeader.Controls.Add(this.lblSupplier);
          this.pnlHeader.Controls.Add(this.txtAddress);
          this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pnlHeader.Location = new System.Drawing.Point(3, 3);
          this.pnlHeader.Name = "pnlHeader";
          this.pnlHeader.Size = new System.Drawing.Size(746, 149);
          this.pnlHeader.TabIndex = 1;
          // 
          // txtNotes
          // 
          this.txtNotes.Location = new System.Drawing.Point(414, 84);
          this.txtNotes.Name = "txtNotes";
          this.txtNotes.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
          this.txtNotes.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
          this.txtNotes.Properties.AppearanceDisabled.Options.UseBackColor = true;
          this.txtNotes.Properties.AppearanceDisabled.Options.UseForeColor = true;
          this.txtNotes.Size = new System.Drawing.Size(187, 62);
          this.txtNotes.TabIndex = 13;
          this.txtNotes.TabStop = false;
          // 
          // label7
          // 
          this.label7.AutoSize = true;
          this.label7.Location = new System.Drawing.Point(364, 87);
          this.label7.Name = "label7";
          this.label7.Size = new System.Drawing.Size(35, 13);
          this.label7.TabIndex = 12;
          this.label7.Text = "Notes";
          // 
          // cboStatus
          // 
          this.cboStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
          this.cboStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cboStatus.FormattingEnabled = true;
          this.cboStatus.Items.AddRange(new object[] {
            "OK",
            "NG",
            "PENDING"});
          this.cboStatus.Location = new System.Drawing.Point(414, 58);
          this.cboStatus.Name = "cboStatus";
          this.cboStatus.Size = new System.Drawing.Size(120, 21);
          this.cboStatus.TabIndex = 11;
          // 
          // label6
          // 
          this.label6.AutoSize = true;
          this.label6.Location = new System.Drawing.Point(364, 61);
          this.label6.Name = "label6";
          this.label6.Size = new System.Drawing.Size(38, 13);
          this.label6.TabIndex = 10;
          this.label6.Text = "Status";
          // 
          // dtDate
          // 
          this.dtDate.CustomFormat = "MMM dd, yyyy";
          this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
          this.dtDate.Location = new System.Drawing.Point(414, 31);
          this.dtDate.Name = "dtDate";
          this.dtDate.Size = new System.Drawing.Size(120, 21);
          this.dtDate.TabIndex = 9;
          // 
          // label5
          // 
          this.label5.AutoSize = true;
          this.label5.Location = new System.Drawing.Point(364, 35);
          this.label5.Name = "label5";
          this.label5.Size = new System.Drawing.Size(30, 13);
          this.label5.TabIndex = 8;
          this.label5.Text = "Date";
          // 
          // txtGracePeriod
          // 
          this.txtGracePeriod.Location = new System.Drawing.Point(82, 58);
          this.txtGracePeriod.Name = "txtGracePeriod";
          this.txtGracePeriod.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
          this.txtGracePeriod.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
          this.txtGracePeriod.Properties.AppearanceDisabled.Options.UseBackColor = true;
          this.txtGracePeriod.Properties.AppearanceDisabled.Options.UseForeColor = true;
          this.txtGracePeriod.Size = new System.Drawing.Size(90, 20);
          this.txtGracePeriod.TabIndex = 5;
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Location = new System.Drawing.Point(14, 87);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(46, 13);
          this.label4.TabIndex = 6;
          this.label4.Text = "Address";
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Location = new System.Drawing.Point(14, 61);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(68, 13);
          this.label3.TabIndex = 4;
          this.label3.Text = "Grace Period";
          // 
          // lblPONumber
          // 
          this.lblPONumber.BackColor = System.Drawing.Color.White;
          this.lblPONumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.lblPONumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblPONumber.Location = new System.Drawing.Point(82, 4);
          this.lblPONumber.Name = "lblPONumber";
          this.lblPONumber.Size = new System.Drawing.Size(90, 21);
          this.lblPONumber.TabIndex = 1;
          this.lblPONumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(14, 8);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(61, 13);
          this.label2.TabIndex = 0;
          this.label2.Text = "PO Number";
          // 
          // cboCustomer
          // 
          this.cboCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
          this.cboCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
          this.cboCustomer.FormattingEnabled = true;
          this.cboCustomer.Location = new System.Drawing.Point(82, 31);
          this.cboCustomer.Name = "cboCustomer";
          this.cboCustomer.Size = new System.Drawing.Size(187, 21);
          this.cboCustomer.TabIndex = 3;
          this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.cboCustomer_SelectedIndexChanged);
          // 
          // lblSupplier
          // 
          this.lblSupplier.AutoSize = true;
          this.lblSupplier.Location = new System.Drawing.Point(14, 34);
          this.lblSupplier.Name = "lblSupplier";
          this.lblSupplier.Size = new System.Drawing.Size(62, 13);
          this.lblSupplier.TabIndex = 2;
          this.lblSupplier.Text = "Warehouse";
          // 
          // txtAddress
          // 
          this.txtAddress.Enabled = false;
          this.txtAddress.Location = new System.Drawing.Point(82, 84);
          this.txtAddress.Name = "txtAddress";
          this.txtAddress.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
          this.txtAddress.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
          this.txtAddress.Properties.AppearanceDisabled.Options.UseBackColor = true;
          this.txtAddress.Properties.AppearanceDisabled.Options.UseForeColor = true;
          this.txtAddress.Size = new System.Drawing.Size(187, 62);
          this.txtAddress.TabIndex = 7;
          this.txtAddress.TabStop = false;
          // 
          // pnlFooter
          // 
          this.pnlFooter.Controls.Add(this.btnCancel);
          this.pnlFooter.Controls.Add(this.btnSave);
          this.pnlFooter.Controls.Add(this.lblTotal);
          this.pnlFooter.Controls.Add(this.label8);
          this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pnlFooter.Location = new System.Drawing.Point(3, 414);
          this.pnlFooter.Name = "pnlFooter";
          this.pnlFooter.Size = new System.Drawing.Size(746, 108);
          this.pnlFooter.TabIndex = 2;
          // 
          // btnCancel
          // 
          this.btnCancel.Location = new System.Drawing.Point(377, 53);
          this.btnCancel.Name = "btnCancel";
          this.btnCancel.Size = new System.Drawing.Size(91, 25);
          this.btnCancel.TabIndex = 10;
          this.btnCancel.Text = "&Cancel";
          this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
          // 
          // btnSave
          // 
          this.btnSave.Location = new System.Drawing.Point(280, 53);
          this.btnSave.Name = "btnSave";
          this.btnSave.Size = new System.Drawing.Size(91, 25);
          this.btnSave.TabIndex = 9;
          this.btnSave.Text = "&Save";
          this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
          // 
          // lblTotal
          // 
          this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.lblTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblTotal.Location = new System.Drawing.Point(617, 5);
          this.lblTotal.Name = "lblTotal";
          this.lblTotal.Size = new System.Drawing.Size(128, 26);
          this.lblTotal.TabIndex = 8;
          this.lblTotal.Text = "TOTAL";
          this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          // 
          // label8
          // 
          this.label8.AutoSize = true;
          this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label8.Location = new System.Drawing.Point(553, 10);
          this.label8.Name = "label8";
          this.label8.Size = new System.Drawing.Size(48, 16);
          this.label8.TabIndex = 7;
          this.label8.Text = "TOTAL";
          // 
          // pnlBody
          // 
          this.pnlBody.Controls.Add(this.btnAddMiscItem);
          this.pnlBody.Controls.Add(this.btnRemoveItem);
          this.pnlBody.Controls.Add(this.btnAddItem);
          this.pnlBody.Controls.Add(this.grdItems);
          this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pnlBody.Location = new System.Drawing.Point(3, 158);
          this.pnlBody.Name = "pnlBody";
          this.pnlBody.Size = new System.Drawing.Size(746, 250);
          this.pnlBody.TabIndex = 3;
          // 
          // btnAddMiscItem
          // 
          this.btnAddMiscItem.Location = new System.Drawing.Point(195, 219);
          this.btnAddMiscItem.Name = "btnAddMiscItem";
          this.btnAddMiscItem.Size = new System.Drawing.Size(91, 25);
          this.btnAddMiscItem.TabIndex = 2;
          this.btnAddMiscItem.Text = "Add &MISC Item";
          this.btnAddMiscItem.Click += new System.EventHandler(this.btnAddMiscItem_Click);
          // 
          // btnRemoveItem
          // 
          this.btnRemoveItem.Location = new System.Drawing.Point(98, 219);
          this.btnRemoveItem.Name = "btnRemoveItem";
          this.btnRemoveItem.Size = new System.Drawing.Size(91, 25);
          this.btnRemoveItem.TabIndex = 1;
          this.btnRemoveItem.Text = "&Remove Item";
          this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
          // 
          // btnAddItem
          // 
          this.btnAddItem.Location = new System.Drawing.Point(1, 219);
          this.btnAddItem.Name = "btnAddItem";
          this.btnAddItem.Size = new System.Drawing.Size(91, 25);
          this.btnAddItem.TabIndex = 0;
          this.btnAddItem.Text = "&Add Item";
          this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
          // 
          // grdItems
          // 
          this.grdItems.Dock = System.Windows.Forms.DockStyle.Top;
          this.grdItems.Location = new System.Drawing.Point(2, 2);
          this.grdItems.MainView = this.grdvItems;
          this.grdItems.Name = "grdItems";
          this.grdItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
          this.grdItems.Size = new System.Drawing.Size(742, 211);
          this.grdItems.TabIndex = 0;
          this.grdItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvItems,
            this.gridView2});
          // 
          // grdvItems
          // 
          this.grdvItems.Appearance.Row.Options.UseTextOptions = true;
          this.grdvItems.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
          this.grdvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.colQTY2,
            this.gridColumn7});
          styleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.White;
          styleFormatCondition2.Appearance.Options.UseForeColor = true;
          styleFormatCondition2.Column = this.colQTY2;
          styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
          styleFormatCondition2.Expression = "[QTY2] == 0";
          this.grdvItems.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition2});
          this.grdvItems.GridControl = this.grdItems;
          this.grdvItems.Name = "grdvItems";
          this.grdvItems.OptionsBehavior.Editable = false;
          this.grdvItems.OptionsSelection.EnableAppearanceFocusedCell = false;
          this.grdvItems.OptionsView.RowAutoHeight = true;
          this.grdvItems.OptionsView.ShowGroupPanel = false;
          this.grdvItems.OptionsView.ShowIndicator = false;
          this.grdvItems.RowCellDefaultAlignment += new DevExpress.XtraGrid.Views.Base.RowCellAlignmentEventHandler(this.grdvItems_RowCellDefaultAlignment);
          this.grdvItems.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grdvItems_CustomUnboundColumnData);
          // 
          // gridColumn1
          // 
          this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
          this.gridColumn1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
          this.gridColumn1.Caption = "Item";
          this.gridColumn1.ColumnEdit = this.repositoryItemMemoEdit1;
          this.gridColumn1.FieldName = "ItemName";
          this.gridColumn1.Name = "gridColumn1";
          this.gridColumn1.OptionsColumn.AllowMove = false;
          this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
          this.gridColumn1.OptionsFilter.AllowFilter = false;
          this.gridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.String;
          this.gridColumn1.Visible = true;
          this.gridColumn1.VisibleIndex = 0;
          this.gridColumn1.Width = 179;
          // 
          // repositoryItemMemoEdit1
          // 
          this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
          // 
          // gridColumn2
          // 
          this.gridColumn2.Caption = "Unit Price";
          this.gridColumn2.DisplayFormat.FormatString = "#,##0.00";
          this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
          this.gridColumn2.FieldName = "UnitPrice";
          this.gridColumn2.Name = "gridColumn2";
          this.gridColumn2.OptionsColumn.AllowMove = false;
          this.gridColumn2.OptionsColumn.AllowSize = false;
          this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
          this.gridColumn2.OptionsColumn.FixedWidth = true;
          this.gridColumn2.OptionsFilter.AllowFilter = false;
          this.gridColumn2.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
          this.gridColumn2.Visible = true;
          this.gridColumn2.VisibleIndex = 1;
          this.gridColumn2.Width = 100;
          // 
          // gridColumn3
          // 
          this.gridColumn3.Caption = "Discount";
          this.gridColumn3.FieldName = "Discount";
          this.gridColumn3.Name = "gridColumn3";
          this.gridColumn3.OptionsColumn.AllowMove = false;
          this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
          this.gridColumn3.OptionsColumn.FixedWidth = true;
          this.gridColumn3.OptionsFilter.AllowFilter = false;
          this.gridColumn3.Visible = true;
          this.gridColumn3.VisibleIndex = 2;
          this.gridColumn3.Width = 100;
          // 
          // gridColumn4
          // 
          this.gridColumn4.Caption = "Discounted Price";
          this.gridColumn4.DisplayFormat.FormatString = "#,##0.00";
          this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
          this.gridColumn4.FieldName = "DiscountedPrice";
          this.gridColumn4.Name = "gridColumn4";
          this.gridColumn4.OptionsColumn.AllowMove = false;
          this.gridColumn4.OptionsColumn.AllowSize = false;
          this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
          this.gridColumn4.OptionsColumn.FixedWidth = true;
          this.gridColumn4.OptionsFilter.AllowFilter = false;
          this.gridColumn4.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
          this.gridColumn4.Visible = true;
          this.gridColumn4.VisibleIndex = 3;
          this.gridColumn4.Width = 100;
          // 
          // gridColumn5
          // 
          this.gridColumn5.Caption = "QTY1";
          this.gridColumn5.FieldName = "QTY1";
          this.gridColumn5.Name = "gridColumn5";
          this.gridColumn5.OptionsColumn.AllowMove = false;
          this.gridColumn5.OptionsColumn.AllowSize = false;
          this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
          this.gridColumn5.OptionsColumn.FixedWidth = true;
          this.gridColumn5.OptionsFilter.AllowFilter = false;
          this.gridColumn5.Visible = true;
          this.gridColumn5.VisibleIndex = 4;
          this.gridColumn5.Width = 60;
          // 
          // gridColumn7
          // 
          this.gridColumn7.Caption = "Sub-Total";
          this.gridColumn7.DisplayFormat.FormatString = "#,##0.00";
          this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
          this.gridColumn7.FieldName = "SubTotal";
          this.gridColumn7.Name = "gridColumn7";
          this.gridColumn7.OptionsColumn.AllowMove = false;
          this.gridColumn7.OptionsColumn.AllowSize = false;
          this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
          this.gridColumn7.OptionsColumn.FixedWidth = true;
          this.gridColumn7.OptionsFilter.AllowFilter = false;
          this.gridColumn7.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
          this.gridColumn7.Visible = true;
          this.gridColumn7.VisibleIndex = 5;
          this.gridColumn7.Width = 90;
          // 
          // gridView2
          // 
          this.gridView2.GridControl = this.grdItems;
          this.gridView2.Name = "gridView2";
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
            this.dataColumn2});
          this.tblItems.TableName = "tblItems";
          // 
          // dataColumn1
          // 
          this.dataColumn1.ColumnName = "ItemName";
          // 
          // dataColumn2
          // 
          this.dataColumn2.ColumnName = "UnitPrice";
          this.dataColumn2.DataType = typeof(double);
          // 
          // ctlPurchaseOrder
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.Controls.Add(this.tlpMain);
          this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.Name = "ctlPurchaseOrder";
          this.Size = new System.Drawing.Size(752, 525);
          this.Load += new System.EventHandler(this.ctlPurchaseOrder_Load);
          this.tlpMain.ResumeLayout(false);
          this.pnlHeader.ResumeLayout(false);
          this.pnlHeader.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.txtGracePeriod.Properties)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
          this.pnlFooter.ResumeLayout(false);
          this.pnlFooter.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
          this.pnlBody.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.grdvItems)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.bSrc)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.dsData)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.tblItems)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private System.Windows.Forms.Panel pnlHeader;
      private DevExpress.XtraGrid.GridControl grdItems;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvItems;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
      private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
      private System.Windows.Forms.BindingSource bSrc;
      private System.Data.DataSet dsData;
      private System.Data.DataTable tblItems;
      private System.Data.DataColumn dataColumn1;
      private System.Data.DataColumn dataColumn2;
      private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
      private DevExpress.XtraGrid.Columns.GridColumn colQTY2;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
      private System.Windows.Forms.Label lblSupplier;
      private System.Windows.Forms.Label lblPONumber;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private DevExpress.XtraEditors.TextEdit txtGracePeriod;
      private System.Windows.Forms.Label label4;
      private DevExpress.XtraEditors.MemoEdit txtAddress;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.DateTimePicker dtDate;
      private System.Windows.Forms.ComboBox cboStatus;
      private System.Windows.Forms.Label label6;
      private DevExpress.XtraEditors.MemoEdit txtNotes;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Panel pnlFooter;
      private DevExpress.XtraEditors.SimpleButton btnAddItem;
      private DevExpress.XtraEditors.SimpleButton btnRemoveItem;
      private DevExpress.XtraEditors.PanelControl pnlBody;
      private System.Windows.Forms.Label lblTotal;
      private System.Windows.Forms.Label label8;
      private DevExpress.XtraEditors.SimpleButton btnSave;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
      public System.Windows.Forms.ComboBox cboCustomer;
      private DevExpress.XtraEditors.SimpleButton btnAddMiscItem;
   }
}
