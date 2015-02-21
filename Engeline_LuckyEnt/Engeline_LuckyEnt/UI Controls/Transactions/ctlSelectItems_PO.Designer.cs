namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
   partial class ctlSelectItems_PO
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
         this.ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.pnlHeader = new System.Windows.Forms.Panel();
         this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
         this.txtSearch = new DevExpress.XtraEditors.TextEdit();
         this.label1 = new System.Windows.Forms.Label();
         this.pnlFooter = new System.Windows.Forms.Panel();
         this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
         this.btnAddItem = new DevExpress.XtraEditors.SimpleButton();
         this.txtQTY2 = new System.Windows.Forms.TextBox();
         this.lblQTY2 = new System.Windows.Forms.Label();
         this.txtPrice2 = new System.Windows.Forms.TextBox();
         this.lblPrice2 = new System.Windows.Forms.Label();
         this.txtQTY1 = new System.Windows.Forms.TextBox();
         this.lblQTY1 = new System.Windows.Forms.Label();
         this.txtPrice1 = new System.Windows.Forms.TextBox();
         this.lblPrice1 = new System.Windows.Forms.Label();
         this.cboDiscount = new DevExpress.XtraEditors.ComboBoxEdit();
         this.label2 = new System.Windows.Forms.Label();
         this.tlpMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvItems)).BeginInit();
         this.pnlHeader.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
         this.pnlFooter.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboDiscount.Properties)).BeginInit();
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
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.05085F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 123F));
         this.tlpMain.Size = new System.Drawing.Size(609, 401);
         this.tlpMain.TabIndex = 0;
         // 
         // grdItems
         // 
         this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdItems.Location = new System.Drawing.Point(3, 43);
         this.grdItems.MainView = this.grdvItems;
         this.grdItems.Name = "grdItems";
         this.grdItems.Size = new System.Drawing.Size(603, 232);
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
            this.ItemName,
            this.Description,
            this.gridColumn3,
            this.gridColumn4});
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
         this.gridColumn3.FieldName = "UnitPrice";
         this.gridColumn3.ImageAlignment = System.Drawing.StringAlignment.Far;
         this.gridColumn3.Name = "gridColumn3";
         this.gridColumn3.OptionsColumn.AllowSize = false;
         this.gridColumn3.OptionsColumn.FixedWidth = true;
         this.gridColumn3.UnboundType = DevExpress.Data.UnboundColumnType.String;
         this.gridColumn3.Visible = true;
         this.gridColumn3.VisibleIndex = 2;
         this.gridColumn3.Width = 81;
         // 
         // gridColumn4
         // 
         this.gridColumn4.Caption = "On Hand";
         this.gridColumn4.FieldName = "OnHand";
         this.gridColumn4.Name = "gridColumn4";
         this.gridColumn4.OptionsColumn.AllowSize = false;
         this.gridColumn4.OptionsColumn.FixedWidth = true;
         this.gridColumn4.UnboundType = DevExpress.Data.UnboundColumnType.String;
         this.gridColumn4.Visible = true;
         this.gridColumn4.VisibleIndex = 3;
         this.gridColumn4.Width = 78;
         // 
         // pnlHeader
         // 
         this.pnlHeader.Controls.Add(this.btnSearch);
         this.pnlHeader.Controls.Add(this.txtSearch);
         this.pnlHeader.Controls.Add(this.label1);
         this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlHeader.Location = new System.Drawing.Point(3, 3);
         this.pnlHeader.Name = "pnlHeader";
         this.pnlHeader.Size = new System.Drawing.Size(603, 34);
         this.pnlHeader.TabIndex = 0;
         // 
         // btnSearch
         // 
         this.btnSearch.Location = new System.Drawing.Point(218, 8);
         this.btnSearch.Name = "btnSearch";
         this.btnSearch.Size = new System.Drawing.Size(88, 20);
         this.btnSearch.TabIndex = 2;
         this.btnSearch.Text = "Search";
         this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
         // 
         // txtSearch
         // 
         this.txtSearch.Location = new System.Drawing.Point(44, 8);
         this.txtSearch.Name = "txtSearch";
         this.txtSearch.Size = new System.Drawing.Size(168, 20);
         this.txtSearch.TabIndex = 1;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(-2, 11);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(40, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "&Search";
         // 
         // pnlFooter
         // 
         this.pnlFooter.Controls.Add(this.btnCancel);
         this.pnlFooter.Controls.Add(this.btnAddItem);
         this.pnlFooter.Controls.Add(this.txtQTY2);
         this.pnlFooter.Controls.Add(this.lblQTY2);
         this.pnlFooter.Controls.Add(this.txtPrice2);
         this.pnlFooter.Controls.Add(this.lblPrice2);
         this.pnlFooter.Controls.Add(this.txtQTY1);
         this.pnlFooter.Controls.Add(this.lblQTY1);
         this.pnlFooter.Controls.Add(this.txtPrice1);
         this.pnlFooter.Controls.Add(this.lblPrice1);
         this.pnlFooter.Controls.Add(this.cboDiscount);
         this.pnlFooter.Controls.Add(this.label2);
         this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlFooter.Location = new System.Drawing.Point(3, 281);
         this.pnlFooter.Name = "pnlFooter";
         this.pnlFooter.Size = new System.Drawing.Size(603, 117);
         this.pnlFooter.TabIndex = 2;
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(307, 76);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(88, 28);
         this.btnCancel.TabIndex = 11;
         this.btnCancel.Text = "&Cancel";
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // btnAddItem
         // 
         this.btnAddItem.Location = new System.Drawing.Point(208, 76);
         this.btnAddItem.Name = "btnAddItem";
         this.btnAddItem.Size = new System.Drawing.Size(88, 28);
         this.btnAddItem.TabIndex = 10;
         this.btnAddItem.Text = "&Add Item";
         this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
         // 
         // txtQTY2
         // 
         this.txtQTY2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txtQTY2.Location = new System.Drawing.Point(420, 3);
         this.txtQTY2.Name = "txtQTY2";
         this.txtQTY2.Size = new System.Drawing.Size(73, 21);
         this.txtQTY2.TabIndex = 5;
         this.txtQTY2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtQTY2.TextChanged += new System.EventHandler(this.txtQTY2_TextChanged);
         this.txtQTY2.Enter += new System.EventHandler(this.txtQTY2_Enter);
         // 
         // lblQTY2
         // 
         this.lblQTY2.AutoSize = true;
         this.lblQTY2.Location = new System.Drawing.Point(359, 6);
         this.lblQTY2.Name = "lblQTY2";
         this.lblQTY2.Size = new System.Drawing.Size(27, 13);
         this.lblQTY2.TabIndex = 4;
         this.lblQTY2.Text = "QTY";
         // 
         // txtPrice2
         // 
         this.txtPrice2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txtPrice2.Location = new System.Drawing.Point(420, 30);
         this.txtPrice2.Name = "txtPrice2";
         this.txtPrice2.Size = new System.Drawing.Size(73, 21);
         this.txtPrice2.TabIndex = 9;
         this.txtPrice2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtPrice2.TextChanged += new System.EventHandler(this.txtPrice2_TextChanged);
         this.txtPrice2.Enter += new System.EventHandler(this.txtPrice2_Enter);
         // 
         // lblPrice2
         // 
         this.lblPrice2.AutoSize = true;
         this.lblPrice2.Location = new System.Drawing.Point(359, 33);
         this.lblPrice2.Name = "lblPrice2";
         this.lblPrice2.Size = new System.Drawing.Size(30, 13);
         this.lblPrice2.TabIndex = 8;
         this.lblPrice2.Text = "Price";
         // 
         // txtQTY1
         // 
         this.txtQTY1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txtQTY1.Location = new System.Drawing.Point(280, 3);
         this.txtQTY1.Name = "txtQTY1";
         this.txtQTY1.Size = new System.Drawing.Size(73, 21);
         this.txtQTY1.TabIndex = 3;
         this.txtQTY1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtQTY1.TextChanged += new System.EventHandler(this.txtQTY1_TextChanged);
         this.txtQTY1.Enter += new System.EventHandler(this.txtQTY1_Enter);
         // 
         // lblQTY1
         // 
         this.lblQTY1.AutoSize = true;
         this.lblQTY1.Location = new System.Drawing.Point(226, 6);
         this.lblQTY1.Name = "lblQTY1";
         this.lblQTY1.Size = new System.Drawing.Size(27, 13);
         this.lblQTY1.TabIndex = 2;
         this.lblQTY1.Text = "QTY";
         // 
         // txtPrice1
         // 
         this.txtPrice1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txtPrice1.Location = new System.Drawing.Point(280, 30);
         this.txtPrice1.Name = "txtPrice1";
         this.txtPrice1.Size = new System.Drawing.Size(73, 21);
         this.txtPrice1.TabIndex = 7;
         this.txtPrice1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         this.txtPrice1.TextChanged += new System.EventHandler(this.txtPrice1_TextChanged);
         this.txtPrice1.Enter += new System.EventHandler(this.txtPrice1_Enter);
         // 
         // lblPrice1
         // 
         this.lblPrice1.AutoSize = true;
         this.lblPrice1.Location = new System.Drawing.Point(226, 33);
         this.lblPrice1.Name = "lblPrice1";
         this.lblPrice1.Size = new System.Drawing.Size(48, 13);
         this.lblPrice1.TabIndex = 6;
         this.lblPrice1.Text = "Price/roll";
         // 
         // cboDiscount
         // 
         this.cboDiscount.Location = new System.Drawing.Point(52, 3);
         this.cboDiscount.Name = "cboDiscount";
         this.cboDiscount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboDiscount.Size = new System.Drawing.Size(160, 20);
         this.cboDiscount.TabIndex = 1;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(-2, 6);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(48, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "&Discount";
         // 
         // ctlSelectItems_PO
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tlpMain);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlSelectItems_PO";
         this.Size = new System.Drawing.Size(609, 401);
         this.Load += new System.EventHandler(this.ctlSelectItems_PO_Load);
         this.tlpMain.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvItems)).EndInit();
         this.pnlHeader.ResumeLayout(false);
         this.pnlHeader.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
         this.pnlFooter.ResumeLayout(false);
         this.pnlFooter.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboDiscount.Properties)).EndInit();
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
      private System.Windows.Forms.Panel pnlHeader;
      private DevExpress.XtraEditors.SimpleButton btnSearch;
      private DevExpress.XtraEditors.TextEdit txtSearch;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Panel pnlFooter;
      private DevExpress.XtraEditors.ComboBoxEdit cboDiscount;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label lblPrice1;
      private System.Windows.Forms.TextBox txtPrice1;
      private System.Windows.Forms.TextBox txtQTY1;
      private System.Windows.Forms.Label lblQTY1;
      private System.Windows.Forms.TextBox txtQTY2;
      private System.Windows.Forms.Label lblQTY2;
      private System.Windows.Forms.TextBox txtPrice2;
      private System.Windows.Forms.Label lblPrice2;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
      private DevExpress.XtraEditors.SimpleButton btnAddItem;
   }
}
