namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
    partial class ctlViewInventory
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
            this.cboWarehouse = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtSearch = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
            this.btnChangePrice = new DevExpress.XtraEditors.SimpleButton();
            this.btnUnLockItem = new DevExpress.XtraEditors.SimpleButton();
            this.btnLockItem = new DevExpress.XtraEditors.SimpleButton();
            this.treeItems = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn11 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn12 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repoLink = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repoMemo = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn8 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn10 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn9 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn13 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboWarehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoMemo)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
            this.tlpMain.Controls.Add(this.pnlFooter, 0, 2);
            this.tlpMain.Controls.Add(this.treeItems, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpMain.Size = new System.Drawing.Size(903, 298);
            this.tlpMain.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.cboWarehouse);
            this.pnlHeader.Controls.Add(this.labelControl2);
            this.pnlHeader.Controls.Add(this.txtSearch);
            this.pnlHeader.Controls.Add(this.labelControl1);
            this.pnlHeader.Controls.Add(this.btnSearch);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(897, 71);
            this.pnlHeader.TabIndex = 0;
            // 
            // cboWarehouse
            // 
            this.cboWarehouse.Location = new System.Drawing.Point(75, 37);
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboWarehouse.Size = new System.Drawing.Size(165, 20);
            this.cboWarehouse.TabIndex = 5;
            this.cboWarehouse.SelectedIndexChanged += new System.EventHandler(this.cboWarehouse_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 40);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "&Warehouse";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(75, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(165, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "&Item Name";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(258, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(93, 28);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "&Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnChangePrice);
            this.pnlFooter.Controls.Add(this.btnUnLockItem);
            this.pnlFooter.Controls.Add(this.btnLockItem);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFooter.Location = new System.Drawing.Point(3, 249);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(897, 46);
            this.pnlFooter.TabIndex = 1;
            // 
            // btnChangePrice
            // 
            this.btnChangePrice.Location = new System.Drawing.Point(313, 12);
            this.btnChangePrice.Name = "btnChangePrice";
            this.btnChangePrice.Size = new System.Drawing.Size(106, 23);
            this.btnChangePrice.TabIndex = 2;
            this.btnChangePrice.Text = "&Change Price";
            this.btnChangePrice.Click += new System.EventHandler(this.btnChangePrice_Click);
            // 
            // btnUnLockItem
            // 
            this.btnUnLockItem.Enabled = false;
            this.btnUnLockItem.Location = new System.Drawing.Point(169, 12);
            this.btnUnLockItem.Name = "btnUnLockItem";
            this.btnUnLockItem.Size = new System.Drawing.Size(106, 23);
            this.btnUnLockItem.TabIndex = 1;
            this.btnUnLockItem.Text = "&Unlock Item";
            this.btnUnLockItem.Click += new System.EventHandler(this.btnUnLockItem_Click);
            // 
            // btnLockItem
            // 
            this.btnLockItem.Enabled = false;
            this.btnLockItem.Location = new System.Drawing.Point(24, 12);
            this.btnLockItem.Name = "btnLockItem";
            this.btnLockItem.Size = new System.Drawing.Size(106, 23);
            this.btnLockItem.TabIndex = 0;
            this.btnLockItem.Text = "&Lock Item";
            this.btnLockItem.Click += new System.EventHandler(this.btnLockItem_Click);
            // 
            // treeItems
            // 
            this.treeItems.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn11,
            this.treeListColumn12,
            this.treeListColumn1,
            this.treeListColumn13,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn6,
            this.treeListColumn5,
            this.treeListColumn7,
            this.treeListColumn4,
            this.treeListColumn8,
            this.treeListColumn10,
            this.treeListColumn9});
            this.treeItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeItems.Location = new System.Drawing.Point(3, 80);
            this.treeItems.Name = "treeItems";
            this.treeItems.OptionsBehavior.Editable = false;
            this.treeItems.OptionsBehavior.PopulateServiceColumns = true;
            this.treeItems.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeItems.OptionsView.EnableAppearanceEvenRow = true;
            this.treeItems.OptionsView.EnableAppearanceOddRow = true;
            this.treeItems.OptionsView.ShowIndicator = false;
            this.treeItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoMemo,
            this.repoLink});
            this.treeItems.Size = new System.Drawing.Size(897, 163);
            this.treeItems.TabIndex = 1;
            this.treeItems.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeItems_CustomDrawNodeCell);
            this.treeItems.Click += new System.EventHandler(this.treeItems_Click);
            // 
            // treeListColumn11
            // 
            this.treeListColumn11.Caption = "Code";
            this.treeListColumn11.FieldName = "Code";
            this.treeListColumn11.Name = "treeListColumn11";
            this.treeListColumn11.OptionsColumn.FixedWidth = true;
            this.treeListColumn11.Visible = true;
            this.treeListColumn11.VisibleIndex = 0;
            // 
            // treeListColumn12
            // 
            this.treeListColumn12.Caption = "Warehouse";
            this.treeListColumn12.FieldName = "Warehouse";
            this.treeListColumn12.Name = "treeListColumn12";
            this.treeListColumn12.Visible = true;
            this.treeListColumn12.VisibleIndex = 1;
            this.treeListColumn12.Width = 80;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "ItemName";
            this.treeListColumn1.FieldName = "ItemName";
            this.treeListColumn1.MinWidth = 33;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 2;
            this.treeListColumn1.Width = 170;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.treeListColumn2.Caption = "StockIn ID";
            this.treeListColumn2.ColumnEdit = this.repoLink;
            this.treeListColumn2.FieldName = "StockInID";
            this.treeListColumn2.Format.FormatString = "000000";
            this.treeListColumn2.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowMove = false;
            this.treeListColumn2.OptionsColumn.AllowSort = false;
            this.treeListColumn2.OptionsColumn.FixedWidth = true;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 4;
            this.treeListColumn2.Width = 100;
            // 
            // repoLink
            // 
            this.repoLink.AutoHeight = false;
            this.repoLink.Name = "repoLink";
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.treeListColumn3.Caption = "OnHand";
            this.treeListColumn3.FieldName = "OnHand_1";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.OptionsColumn.AllowMove = false;
            this.treeListColumn3.OptionsColumn.AllowSort = false;
            this.treeListColumn3.OptionsColumn.FixedWidth = true;
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 5;
            this.treeListColumn3.Width = 80;
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.treeListColumn6.Caption = "Capital";
            this.treeListColumn6.ColumnEdit = this.repoMemo;
            this.treeListColumn6.FieldName = "Capital";
            this.treeListColumn6.Format.FormatString = "{0:N2}";
            this.treeListColumn6.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColumn6.Name = "treeListColumn6";
            this.treeListColumn6.OptionsColumn.AllowMove = false;
            this.treeListColumn6.OptionsColumn.AllowSort = false;
            this.treeListColumn6.OptionsColumn.FixedWidth = true;
            this.treeListColumn6.Visible = true;
            this.treeListColumn6.VisibleIndex = 6;
            this.treeListColumn6.Width = 100;
            // 
            // repoMemo
            // 
            this.repoMemo.Name = "repoMemo";
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.treeListColumn5.Caption = "Base Price";
            this.treeListColumn5.FieldName = "BasePrice";
            this.treeListColumn5.Format.FormatString = "{0:N2}";
            this.treeListColumn5.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.OptionsColumn.AllowMove = false;
            this.treeListColumn5.OptionsColumn.AllowSort = false;
            this.treeListColumn5.OptionsColumn.FixedWidth = true;
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 7;
            this.treeListColumn5.Width = 100;
            // 
            // treeListColumn7
            // 
            this.treeListColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.treeListColumn7.Caption = "SellingPrice";
            this.treeListColumn7.ColumnEdit = this.repoMemo;
            this.treeListColumn7.FieldName = "SellingPrice_1";
            this.treeListColumn7.Name = "treeListColumn7";
            this.treeListColumn7.OptionsColumn.AllowMove = false;
            this.treeListColumn7.OptionsColumn.AllowSort = false;
            this.treeListColumn7.OptionsColumn.FixedWidth = true;
            this.treeListColumn7.Visible = true;
            this.treeListColumn7.VisibleIndex = 8;
            this.treeListColumn7.Width = 100;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.treeListColumn4.Caption = "OnHand_2";
            this.treeListColumn4.FieldName = "OnHand_2";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.OptionsColumn.AllowMove = false;
            this.treeListColumn4.OptionsColumn.AllowSort = false;
            this.treeListColumn4.OptionsColumn.FixedWidth = true;
            // 
            // treeListColumn8
            // 
            this.treeListColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.treeListColumn8.Caption = "SellingPrice_2";
            this.treeListColumn8.ColumnEdit = this.repoMemo;
            this.treeListColumn8.FieldName = "SellingPrice_2";
            this.treeListColumn8.Name = "treeListColumn8";
            this.treeListColumn8.OptionsColumn.AllowMove = false;
            this.treeListColumn8.OptionsColumn.AllowSort = false;
            this.treeListColumn8.OptionsColumn.FixedWidth = true;
            this.treeListColumn8.Width = 100;
            // 
            // treeListColumn10
            // 
            this.treeListColumn10.Caption = " ";
            this.treeListColumn10.FieldName = "LockIcon";
            this.treeListColumn10.Name = "treeListColumn10";
            this.treeListColumn10.OptionsColumn.AllowMove = false;
            this.treeListColumn10.OptionsColumn.AllowSort = false;
            this.treeListColumn10.OptionsColumn.FixedWidth = true;
            this.treeListColumn10.Visible = true;
            this.treeListColumn10.VisibleIndex = 9;
            this.treeListColumn10.Width = 30;
            // 
            // treeListColumn9
            // 
            this.treeListColumn9.Caption = "ItemObject";
            this.treeListColumn9.FieldName = "ItemObject";
            this.treeListColumn9.Name = "treeListColumn9";
            this.treeListColumn9.OptionsColumn.AllowMove = false;
            this.treeListColumn9.OptionsColumn.AllowSort = false;
            this.treeListColumn9.OptionsColumn.FixedWidth = true;
            // 
            // treeListColumn13
            // 
            this.treeListColumn13.Caption = "Unit";
            this.treeListColumn13.FieldName = "Unit";
            this.treeListColumn13.Name = "treeListColumn13";
            this.treeListColumn13.Visible = true;
            this.treeListColumn13.VisibleIndex = 3;
            // 
            // ctlViewInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "ctlViewInventory";
            this.Size = new System.Drawing.Size(903, 298);
            this.Load += new System.EventHandler(this.ctlViewInventory_Load);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboWarehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoMemo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.PanelControl pnlFooter;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.SimpleButton btnChangePrice;
        private DevExpress.XtraEditors.SimpleButton btnUnLockItem;
        private DevExpress.XtraEditors.SimpleButton btnLockItem;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        private DevExpress.XtraTreeList.TreeList treeItems;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn7;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn8;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn10;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repoLink;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repoMemo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn11;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn12;
        private DevExpress.XtraEditors.ComboBoxEdit cboWarehouse;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn13;
    }
}
