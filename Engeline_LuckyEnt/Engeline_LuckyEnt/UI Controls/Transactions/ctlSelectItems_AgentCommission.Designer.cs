namespace DexterHardware_v2.UI_Controls.Transactions
{
   partial class ctlSelectItems_AgentCommission
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
         this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
         this.txtSearch = new DevExpress.XtraEditors.TextEdit();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
         this.btnAddTradingItems = new DevExpress.XtraEditors.SimpleButton();
         this.btnAddFabricatedItem = new DevExpress.XtraEditors.SimpleButton();
         this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
         this.btnSave = new DevExpress.XtraEditors.SimpleButton();
         this.grdItems = new DevExpress.XtraGrid.GridControl();
         this.grdvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.colCheckBox = new DevExpress.XtraGrid.Columns.GridColumn();
         this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
         this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.tlpMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
         this.pnlHeader.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
         this.pnlFooter.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvItems)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
         this.SuspendLayout();
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
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
         this.tlpMain.Size = new System.Drawing.Size(479, 494);
         this.tlpMain.TabIndex = 0;
         // 
         // pnlHeader
         // 
         this.pnlHeader.Controls.Add(this.btnSearch);
         this.pnlHeader.Controls.Add(this.txtSearch);
         this.pnlHeader.Controls.Add(this.labelControl1);
         this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlHeader.Location = new System.Drawing.Point(3, 3);
         this.pnlHeader.Name = "pnlHeader";
         this.pnlHeader.Size = new System.Drawing.Size(473, 41);
         this.pnlHeader.TabIndex = 0;
         // 
         // btnSearch
         // 
         this.btnSearch.Location = new System.Drawing.Point(223, 10);
         this.btnSearch.Name = "btnSearch";
         this.btnSearch.Size = new System.Drawing.Size(77, 20);
         this.btnSearch.TabIndex = 2;
         this.btnSearch.Text = "S&earch";
         this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
         // 
         // txtSearch
         // 
         this.txtSearch.Location = new System.Drawing.Point(52, 10);
         this.txtSearch.Name = "txtSearch";
         this.txtSearch.Size = new System.Drawing.Size(165, 20);
         this.txtSearch.TabIndex = 1;
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(13, 13);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(33, 13);
         this.labelControl1.TabIndex = 0;
         this.labelControl1.Text = "&Search";
         // 
         // pnlFooter
         // 
         this.pnlFooter.Controls.Add(this.btnAddTradingItems);
         this.pnlFooter.Controls.Add(this.btnAddFabricatedItem);
         this.pnlFooter.Controls.Add(this.btnCancel);
         this.pnlFooter.Controls.Add(this.btnSave);
         this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlFooter.Location = new System.Drawing.Point(3, 403);
         this.pnlFooter.Name = "pnlFooter";
         this.pnlFooter.Size = new System.Drawing.Size(473, 88);
         this.pnlFooter.TabIndex = 2;
         // 
         // btnAddTradingItems
         // 
         this.btnAddTradingItems.Location = new System.Drawing.Point(239, 5);
         this.btnAddTradingItems.Name = "btnAddTradingItems";
         this.btnAddTradingItems.Size = new System.Drawing.Size(135, 27);
         this.btnAddTradingItems.TabIndex = 1;
         this.btnAddTradingItems.Text = "Add &Trading Items";
         this.btnAddTradingItems.Click += new System.EventHandler(this.btnAddTradingItems_Click);
         // 
         // btnAddFabricatedItem
         // 
         this.btnAddFabricatedItem.Location = new System.Drawing.Point(98, 5);
         this.btnAddFabricatedItem.Name = "btnAddFabricatedItem";
         this.btnAddFabricatedItem.Size = new System.Drawing.Size(135, 27);
         this.btnAddFabricatedItem.TabIndex = 0;
         this.btnAddFabricatedItem.Text = "Add &Fabricated Items";
         this.btnAddFabricatedItem.Click += new System.EventHandler(this.btnAddFabricatedItem_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(239, 56);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(78, 27);
         this.btnCancel.TabIndex = 3;
         this.btnCancel.Text = "&Cancel";
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // btnSave
         // 
         this.btnSave.Location = new System.Drawing.Point(155, 56);
         this.btnSave.Name = "btnSave";
         this.btnSave.Size = new System.Drawing.Size(78, 27);
         this.btnSave.TabIndex = 2;
         this.btnSave.Text = "&Save";
         this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
         // 
         // grdItems
         // 
         this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdItems.Location = new System.Drawing.Point(3, 50);
         this.grdItems.MainView = this.grdvItems;
         this.grdItems.Name = "grdItems";
         this.grdItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
         this.grdItems.Size = new System.Drawing.Size(473, 347);
         this.grdItems.TabIndex = 1;
         this.grdItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvItems});
         // 
         // grdvItems
         // 
         this.grdvItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCheckBox,
            this.gridColumn1,
            this.gridColumn2});
         this.grdvItems.GridControl = this.grdItems;
         this.grdvItems.Name = "grdvItems";
         this.grdvItems.OptionsBehavior.Editable = false;
         this.grdvItems.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdvItems.OptionsView.EnableAppearanceEvenRow = true;
         this.grdvItems.OptionsView.EnableAppearanceOddRow = true;
         this.grdvItems.OptionsView.ShowGroupPanel = false;
         this.grdvItems.OptionsView.ShowIndicator = false;
         // 
         // colCheckBox
         // 
         this.colCheckBox.Caption = " ";
         this.colCheckBox.ColumnEdit = this.repositoryItemCheckEdit1;
         this.colCheckBox.FieldName = "Selected";
         this.colCheckBox.Name = "colCheckBox";
         this.colCheckBox.OptionsColumn.AllowSize = false;
         this.colCheckBox.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
         this.colCheckBox.OptionsColumn.FixedWidth = true;
         this.colCheckBox.Visible = true;
         this.colCheckBox.VisibleIndex = 0;
         this.colCheckBox.Width = 35;
         // 
         // repositoryItemCheckEdit1
         // 
         this.repositoryItemCheckEdit1.AutoHeight = false;
         this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
         // 
         // gridColumn1
         // 
         this.gridColumn1.Caption = "Item Name";
         this.gridColumn1.FieldName = "Name";
         this.gridColumn1.Name = "gridColumn1";
         this.gridColumn1.Visible = true;
         this.gridColumn1.VisibleIndex = 1;
         this.gridColumn1.Width = 215;
         // 
         // gridColumn2
         // 
         this.gridColumn2.Caption = "Description";
         this.gridColumn2.FieldName = "Description";
         this.gridColumn2.Name = "gridColumn2";
         this.gridColumn2.Visible = true;
         this.gridColumn2.VisibleIndex = 2;
         this.gridColumn2.Width = 219;
         // 
         // ctlSelectItems_AgentCommission
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tlpMain);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlSelectItems_AgentCommission";
         this.Size = new System.Drawing.Size(479, 494);
         this.Load += new System.EventHandler(this.ctlSelectItems_AgentCommission_Load);
         this.tlpMain.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
         this.pnlHeader.ResumeLayout(false);
         this.pnlHeader.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
         this.pnlFooter.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvItems)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private DevExpress.XtraEditors.PanelControl pnlHeader;
      private DevExpress.XtraEditors.PanelControl pnlFooter;
      private DevExpress.XtraEditors.SimpleButton btnSearch;
      private DevExpress.XtraEditors.TextEdit txtSearch;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraGrid.GridControl grdItems;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvItems;
      private DevExpress.XtraGrid.Columns.GridColumn colCheckBox;
      private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
      private DevExpress.XtraEditors.SimpleButton btnSave;
      private DevExpress.XtraEditors.SimpleButton btnAddTradingItems;
      private DevExpress.XtraEditors.SimpleButton btnAddFabricatedItem;
   }
}
