namespace DexterHardware_v2.UI_Controls.Transactions
{
   partial class ctlReturnedItems
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
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
         this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
         this.lblPaymentType = new DevExpress.XtraEditors.LabelControl();
         this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
         this.lblInvoicePO = new DevExpress.XtraEditors.LabelControl();
         this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
         this.lblInvoiceDate = new DevExpress.XtraEditors.LabelControl();
         this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
         this.lblCustomer = new DevExpress.XtraEditors.LabelControl();
         this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
         this.lblReceiptNo = new DevExpress.XtraEditors.LabelControl();
         this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
         this.lblInvoiceNo = new DevExpress.XtraEditors.LabelControl();
         this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
         this.lblTotal = new DevExpress.XtraEditors.LabelControl();
         this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
         this.txtNotes = new DevExpress.XtraEditors.MemoEdit();
         this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
         this.btnClose = new DevExpress.XtraEditors.SimpleButton();
         this.btnSave = new DevExpress.XtraEditors.SimpleButton();
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
         this.grdvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.colSID_Index = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.repoMemo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
         this.colItemPrice = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colQTY_Invoice = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colQTY_Returned = new DevExpress.XtraGrid.Columns.GridColumn();
         this.colSubTotal = new DevExpress.XtraGrid.Columns.GridColumn();
         this.tlpMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
         this.pnlHeader.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
         this.pnlFooter.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.bSrc)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dsData)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.tblItems)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvItems)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoMemo)).BeginInit();
         this.SuspendLayout();
         // 
         // labelControl1
         // 
         this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DimGray;
         this.labelControl1.Appearance.Options.UseForeColor = true;
         this.labelControl1.Location = new System.Drawing.Point(5, 5);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(55, 13);
         this.labelControl1.TabIndex = 0;
         this.labelControl1.Text = "Invoice No.";
         // 
         // tlpMain
         // 
         this.tlpMain.ColumnCount = 1;
         this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
         this.tlpMain.Controls.Add(this.pnlFooter, 0, 2);
         this.tlpMain.Controls.Add(this.grdItems, 0, 1);
         this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tlpMain.Location = new System.Drawing.Point(0, 0);
         this.tlpMain.Name = "tlpMain";
         this.tlpMain.RowCount = 3;
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
         this.tlpMain.Size = new System.Drawing.Size(723, 472);
         this.tlpMain.TabIndex = 0;
         // 
         // pnlHeader
         // 
         this.pnlHeader.Controls.Add(this.lblPaymentType);
         this.pnlHeader.Controls.Add(this.labelControl7);
         this.pnlHeader.Controls.Add(this.lblInvoicePO);
         this.pnlHeader.Controls.Add(this.labelControl6);
         this.pnlHeader.Controls.Add(this.lblInvoiceDate);
         this.pnlHeader.Controls.Add(this.labelControl5);
         this.pnlHeader.Controls.Add(this.lblCustomer);
         this.pnlHeader.Controls.Add(this.labelControl4);
         this.pnlHeader.Controls.Add(this.lblReceiptNo);
         this.pnlHeader.Controls.Add(this.labelControl3);
         this.pnlHeader.Controls.Add(this.lblInvoiceNo);
         this.pnlHeader.Controls.Add(this.labelControl1);
         this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlHeader.Location = new System.Drawing.Point(3, 3);
         this.pnlHeader.Name = "pnlHeader";
         this.pnlHeader.Size = new System.Drawing.Size(717, 66);
         this.pnlHeader.TabIndex = 0;
         // 
         // lblPaymentType
         // 
         this.lblPaymentType.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.lblPaymentType.Appearance.Options.UseFont = true;
         this.lblPaymentType.Location = new System.Drawing.Point(325, 43);
         this.lblPaymentType.Name = "lblPaymentType";
         this.lblPaymentType.Size = new System.Drawing.Size(15, 13);
         this.lblPaymentType.TabIndex = 12;
         this.lblPaymentType.Text = "PO";
         // 
         // labelControl7
         // 
         this.labelControl7.Appearance.ForeColor = System.Drawing.Color.DimGray;
         this.labelControl7.Appearance.Options.UseForeColor = true;
         this.labelControl7.Location = new System.Drawing.Point(245, 43);
         this.labelControl7.Name = "labelControl7";
         this.labelControl7.Size = new System.Drawing.Size(69, 13);
         this.labelControl7.TabIndex = 11;
         this.labelControl7.Text = "Payment Type";
         // 
         // lblInvoicePO
         // 
         this.lblInvoicePO.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.lblInvoicePO.Appearance.Options.UseFont = true;
         this.lblInvoicePO.Location = new System.Drawing.Point(325, 24);
         this.lblInvoicePO.Name = "lblInvoicePO";
         this.lblInvoicePO.Size = new System.Drawing.Size(15, 13);
         this.lblInvoicePO.TabIndex = 10;
         this.lblInvoicePO.Text = "PO";
         // 
         // labelControl6
         // 
         this.labelControl6.Appearance.ForeColor = System.Drawing.Color.DimGray;
         this.labelControl6.Appearance.Options.UseForeColor = true;
         this.labelControl6.Location = new System.Drawing.Point(245, 24);
         this.labelControl6.Name = "labelControl6";
         this.labelControl6.Size = new System.Drawing.Size(42, 13);
         this.labelControl6.TabIndex = 9;
         this.labelControl6.Text = "P.O. No.";
         // 
         // lblInvoiceDate
         // 
         this.lblInvoiceDate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.lblInvoiceDate.Appearance.Options.UseFont = true;
         this.lblInvoiceDate.Location = new System.Drawing.Point(325, 5);
         this.lblInvoiceDate.Name = "lblInvoiceDate";
         this.lblInvoiceDate.Size = new System.Drawing.Size(62, 13);
         this.lblInvoiceDate.TabIndex = 8;
         this.lblInvoiceDate.Text = "Invoice No.";
         // 
         // labelControl5
         // 
         this.labelControl5.Appearance.ForeColor = System.Drawing.Color.DimGray;
         this.labelControl5.Appearance.Options.UseForeColor = true;
         this.labelControl5.Location = new System.Drawing.Point(245, 5);
         this.labelControl5.Name = "labelControl5";
         this.labelControl5.Size = new System.Drawing.Size(61, 13);
         this.labelControl5.TabIndex = 7;
         this.labelControl5.Text = "Invoice Date";
         // 
         // lblCustomer
         // 
         this.lblCustomer.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.lblCustomer.Appearance.Options.UseFont = true;
         this.lblCustomer.Location = new System.Drawing.Point(85, 43);
         this.lblCustomer.Name = "lblCustomer";
         this.lblCustomer.Size = new System.Drawing.Size(55, 13);
         this.lblCustomer.TabIndex = 6;
         this.lblCustomer.Text = "Customer";
         // 
         // labelControl4
         // 
         this.labelControl4.Appearance.ForeColor = System.Drawing.Color.DimGray;
         this.labelControl4.Appearance.Options.UseForeColor = true;
         this.labelControl4.Location = new System.Drawing.Point(5, 43);
         this.labelControl4.Name = "labelControl4";
         this.labelControl4.Size = new System.Drawing.Size(46, 13);
         this.labelControl4.TabIndex = 5;
         this.labelControl4.Text = "Customer";
         // 
         // lblReceiptNo
         // 
         this.lblReceiptNo.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.lblReceiptNo.Appearance.Options.UseFont = true;
         this.lblReceiptNo.Location = new System.Drawing.Point(85, 24);
         this.lblReceiptNo.Name = "lblReceiptNo";
         this.lblReceiptNo.Size = new System.Drawing.Size(57, 13);
         this.lblReceiptNo.TabIndex = 4;
         this.lblReceiptNo.Text = "ReceiptNo";
         // 
         // labelControl3
         // 
         this.labelControl3.Appearance.ForeColor = System.Drawing.Color.DimGray;
         this.labelControl3.Appearance.Options.UseForeColor = true;
         this.labelControl3.Location = new System.Drawing.Point(5, 24);
         this.labelControl3.Name = "labelControl3";
         this.labelControl3.Size = new System.Drawing.Size(56, 13);
         this.labelControl3.TabIndex = 3;
         this.labelControl3.Text = "Receipt No.";
         // 
         // lblInvoiceNo
         // 
         this.lblInvoiceNo.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
         this.lblInvoiceNo.Appearance.Options.UseFont = true;
         this.lblInvoiceNo.Location = new System.Drawing.Point(85, 5);
         this.lblInvoiceNo.Name = "lblInvoiceNo";
         this.lblInvoiceNo.Size = new System.Drawing.Size(62, 13);
         this.lblInvoiceNo.TabIndex = 2;
         this.lblInvoiceNo.Text = "Invoice No.";
         // 
         // pnlFooter
         // 
         this.pnlFooter.Controls.Add(this.lblTotal);
         this.pnlFooter.Controls.Add(this.labelControl8);
         this.pnlFooter.Controls.Add(this.txtNotes);
         this.pnlFooter.Controls.Add(this.labelControl2);
         this.pnlFooter.Controls.Add(this.btnClose);
         this.pnlFooter.Controls.Add(this.btnSave);
         this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlFooter.Location = new System.Drawing.Point(3, 369);
         this.pnlFooter.Name = "pnlFooter";
         this.pnlFooter.Size = new System.Drawing.Size(717, 100);
         this.pnlFooter.TabIndex = 1;
         // 
         // lblTotal
         // 
         this.lblTotal.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
         this.lblTotal.Appearance.ForeColor = System.Drawing.Color.Black;
         this.lblTotal.Appearance.Options.UseFont = true;
         this.lblTotal.Appearance.Options.UseForeColor = true;
         this.lblTotal.Appearance.Options.UseTextOptions = true;
         this.lblTotal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.lblTotal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
         this.lblTotal.Location = new System.Drawing.Point(562, 7);
         this.lblTotal.Name = "lblTotal";
         this.lblTotal.Size = new System.Drawing.Size(138, 23);
         this.lblTotal.TabIndex = 3;
         this.lblTotal.Text = "0.00";
         // 
         // labelControl8
         // 
         this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
         this.labelControl8.Appearance.ForeColor = System.Drawing.Color.Black;
         this.labelControl8.Appearance.Options.UseFont = true;
         this.labelControl8.Appearance.Options.UseForeColor = true;
         this.labelControl8.Location = new System.Drawing.Point(493, 7);
         this.labelControl8.Name = "labelControl8";
         this.labelControl8.Size = new System.Drawing.Size(63, 23);
         this.labelControl8.TabIndex = 2;
         this.labelControl8.Text = "TOTAL";
         // 
         // txtNotes
         // 
         this.txtNotes.Location = new System.Drawing.Point(39, 5);
         this.txtNotes.Name = "txtNotes";
         this.txtNotes.Size = new System.Drawing.Size(267, 50);
         this.txtNotes.TabIndex = 1;
         // 
         // labelControl2
         // 
         this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
         this.labelControl2.Appearance.Options.UseForeColor = true;
         this.labelControl2.Location = new System.Drawing.Point(5, 5);
         this.labelControl2.Name = "labelControl2";
         this.labelControl2.Size = new System.Drawing.Size(28, 13);
         this.labelControl2.TabIndex = 0;
         this.labelControl2.Text = "Notes";
         // 
         // btnClose
         // 
         this.btnClose.Location = new System.Drawing.Point(629, 57);
         this.btnClose.Name = "btnClose";
         this.btnClose.Size = new System.Drawing.Size(71, 27);
         this.btnClose.TabIndex = 5;
         this.btnClose.Text = "&Close";
         this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
         // 
         // btnSave
         // 
         this.btnSave.Location = new System.Drawing.Point(552, 57);
         this.btnSave.Name = "btnSave";
         this.btnSave.Size = new System.Drawing.Size(71, 27);
         this.btnSave.TabIndex = 4;
         this.btnSave.Text = "&Save";
         this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
         // 
         // grdItems
         // 
         this.grdItems.DataSource = this.bSrc;
         this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdItems.Location = new System.Drawing.Point(3, 75);
         this.grdItems.MainView = this.grdvItems;
         this.grdItems.Name = "grdItems";
         this.grdItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoMemo});
         this.grdItems.Size = new System.Drawing.Size(717, 288);
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
            this.dataColumn6});
         this.tblItems.TableName = "tblItems";
         // 
         // dataColumn1
         // 
         this.dataColumn1.ColumnName = "SID_Index";
         this.dataColumn1.DataType = typeof(int);
         // 
         // dataColumn2
         // 
         this.dataColumn2.ColumnName = "ItemName";
         // 
         // dataColumn3
         // 
         this.dataColumn3.ColumnName = "ItemPrice";
         // 
         // dataColumn4
         // 
         this.dataColumn4.ColumnName = "QTY_Invoice";
         // 
         // dataColumn5
         // 
         this.dataColumn5.ColumnName = "QTY_Returned";
         this.dataColumn5.DataType = typeof(int);
         // 
         // dataColumn6
         // 
         this.dataColumn6.ColumnName = "SubTotal";
         this.dataColumn6.DataType = typeof(double);
         // 
         // grdvItems
         // 
         this.grdvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSID_Index,
            this.colItemName,
            this.colItemPrice,
            this.colQTY_Invoice,
            this.colQTY_Returned,
            this.colSubTotal});
         this.grdvItems.GridControl = this.grdItems;
         this.grdvItems.Name = "grdvItems";
         this.grdvItems.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
         this.grdvItems.OptionsView.EnableAppearanceEvenRow = true;
         this.grdvItems.OptionsView.EnableAppearanceOddRow = true;
         this.grdvItems.OptionsView.RowAutoHeight = true;
         this.grdvItems.OptionsView.ShowGroupPanel = false;
         this.grdvItems.OptionsView.ShowIndicator = false;
         this.grdvItems.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grdvItems_ValidateRow);
         // 
         // colSID_Index
         // 
         this.colSID_Index.FieldName = "SID_Index";
         this.colSID_Index.Name = "colSID_Index";
         this.colSID_Index.OptionsColumn.AllowEdit = false;
         this.colSID_Index.OptionsColumn.AllowFocus = false;
         this.colSID_Index.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
         // 
         // colItemName
         // 
         this.colItemName.Caption = "Item Name";
         this.colItemName.ColumnEdit = this.repoMemo;
         this.colItemName.FieldName = "ItemName";
         this.colItemName.Name = "colItemName";
         this.colItemName.OptionsColumn.AllowEdit = false;
         this.colItemName.OptionsColumn.AllowFocus = false;
         this.colItemName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
         this.colItemName.Visible = true;
         this.colItemName.VisibleIndex = 0;
         this.colItemName.Width = 226;
         // 
         // repoMemo
         // 
         this.repoMemo.Name = "repoMemo";
         // 
         // colItemPrice
         // 
         this.colItemPrice.AppearanceCell.Options.UseTextOptions = true;
         this.colItemPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.colItemPrice.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
         this.colItemPrice.Caption = "Item Price";
         this.colItemPrice.ColumnEdit = this.repoMemo;
         this.colItemPrice.FieldName = "ItemPrice";
         this.colItemPrice.Name = "colItemPrice";
         this.colItemPrice.OptionsColumn.AllowEdit = false;
         this.colItemPrice.OptionsColumn.AllowFocus = false;
         this.colItemPrice.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
         this.colItemPrice.OptionsColumn.FixedWidth = true;
         this.colItemPrice.Visible = true;
         this.colItemPrice.VisibleIndex = 1;
         this.colItemPrice.Width = 120;
         // 
         // colQTY_Invoice
         // 
         this.colQTY_Invoice.AppearanceCell.Options.UseTextOptions = true;
         this.colQTY_Invoice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.colQTY_Invoice.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
         this.colQTY_Invoice.Caption = "QTY";
         this.colQTY_Invoice.ColumnEdit = this.repoMemo;
         this.colQTY_Invoice.FieldName = "QTY_Invoice";
         this.colQTY_Invoice.Name = "colQTY_Invoice";
         this.colQTY_Invoice.OptionsColumn.AllowEdit = false;
         this.colQTY_Invoice.OptionsColumn.AllowFocus = false;
         this.colQTY_Invoice.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
         this.colQTY_Invoice.OptionsColumn.FixedWidth = true;
         this.colQTY_Invoice.Visible = true;
         this.colQTY_Invoice.VisibleIndex = 2;
         this.colQTY_Invoice.Width = 85;
         // 
         // colQTY_Returned
         // 
         this.colQTY_Returned.AppearanceCell.Options.UseTextOptions = true;
         this.colQTY_Returned.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.colQTY_Returned.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
         this.colQTY_Returned.Caption = "Returned";
         this.colQTY_Returned.FieldName = "QTY_Returned";
         this.colQTY_Returned.Name = "colQTY_Returned";
         this.colQTY_Returned.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
         this.colQTY_Returned.OptionsColumn.FixedWidth = true;
         this.colQTY_Returned.Visible = true;
         this.colQTY_Returned.VisibleIndex = 3;
         this.colQTY_Returned.Width = 80;
         // 
         // colSubTotal
         // 
         this.colSubTotal.AppearanceCell.Options.UseTextOptions = true;
         this.colSubTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.colSubTotal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
         this.colSubTotal.Caption = "Sub Total";
         this.colSubTotal.DisplayFormat.FormatString = "{0:N2}";
         this.colSubTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.colSubTotal.FieldName = "SubTotal";
         this.colSubTotal.Name = "colSubTotal";
         this.colSubTotal.OptionsColumn.AllowEdit = false;
         this.colSubTotal.OptionsColumn.AllowFocus = false;
         this.colSubTotal.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
         this.colSubTotal.OptionsColumn.FixedWidth = true;
         this.colSubTotal.Visible = true;
         this.colSubTotal.VisibleIndex = 4;
         this.colSubTotal.Width = 85;
         // 
         // ctlReturnedItems
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tlpMain);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlReturnedItems";
         this.Size = new System.Drawing.Size(723, 472);
         this.Load += new System.EventHandler(this.ctlReturnedItems_Load);
         this.tlpMain.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
         this.pnlHeader.ResumeLayout(false);
         this.pnlHeader.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
         this.pnlFooter.ResumeLayout(false);
         this.pnlFooter.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.bSrc)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dsData)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.tblItems)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvItems)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoMemo)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.LabelControl labelControl1;
      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private DevExpress.XtraEditors.PanelControl pnlHeader;
      private DevExpress.XtraEditors.PanelControl pnlFooter;
      private DevExpress.XtraEditors.SimpleButton btnClose;
      private DevExpress.XtraEditors.SimpleButton btnSave;
      private System.Data.DataSet dsData;
      private System.Windows.Forms.BindingSource bSrc;
      private DevExpress.XtraGrid.GridControl grdItems;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvItems;
      private DevExpress.XtraEditors.LabelControl lblInvoiceNo;
      private DevExpress.XtraEditors.LabelControl lblPaymentType;
      private DevExpress.XtraEditors.LabelControl labelControl7;
      private DevExpress.XtraEditors.LabelControl lblInvoicePO;
      private DevExpress.XtraEditors.LabelControl labelControl6;
      private DevExpress.XtraEditors.LabelControl lblInvoiceDate;
      private DevExpress.XtraEditors.LabelControl labelControl5;
      private DevExpress.XtraEditors.LabelControl lblCustomer;
      private DevExpress.XtraEditors.LabelControl labelControl4;
      private DevExpress.XtraEditors.LabelControl lblReceiptNo;
      private DevExpress.XtraEditors.LabelControl labelControl3;
      private DevExpress.XtraEditors.LabelControl labelControl2;
      private DevExpress.XtraEditors.LabelControl lblTotal;
      private DevExpress.XtraEditors.LabelControl labelControl8;
      private DevExpress.XtraEditors.MemoEdit txtNotes;
      private System.Data.DataTable tblItems;
      private System.Data.DataColumn dataColumn1;
      private System.Data.DataColumn dataColumn2;
      private System.Data.DataColumn dataColumn3;
      private System.Data.DataColumn dataColumn4;
      private System.Data.DataColumn dataColumn5;
      private System.Data.DataColumn dataColumn6;
      private DevExpress.XtraGrid.Columns.GridColumn colSID_Index;
      private DevExpress.XtraGrid.Columns.GridColumn colItemName;
      private DevExpress.XtraGrid.Columns.GridColumn colItemPrice;
      private DevExpress.XtraGrid.Columns.GridColumn colQTY_Invoice;
      private DevExpress.XtraGrid.Columns.GridColumn colQTY_Returned;
      private DevExpress.XtraGrid.Columns.GridColumn colSubTotal;
      private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repoMemo;
   }
}
