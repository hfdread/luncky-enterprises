namespace DexterHardware_v2.UI_Controls.Utilities
{
   partial class ctlSelectItem
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
         this.pnlHeader = new System.Windows.Forms.Panel();
         this.grdItems = new DevExpress.XtraGrid.GridControl();
         this.grdvItems = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.ItemName = new DevExpress.XtraGrid.Columns.GridColumn();
         this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
         this.txtSearch = new DevExpress.XtraEditors.TextEdit();
         this.label1 = new System.Windows.Forms.Label();
         this.tlpMain.SuspendLayout();
         this.pnlHeader.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvItems)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // tlpMain
         // 
         this.tlpMain.ColumnCount = 1;
         this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
         this.tlpMain.Controls.Add(this.grdItems, 0, 1);
         this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tlpMain.Location = new System.Drawing.Point(0, 0);
         this.tlpMain.Name = "tlpMain";
         this.tlpMain.RowCount = 2;
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.Size = new System.Drawing.Size(515, 285);
         this.tlpMain.TabIndex = 0;
         // 
         // pnlHeader
         // 
         this.pnlHeader.Controls.Add(this.btnSearch);
         this.pnlHeader.Controls.Add(this.txtSearch);
         this.pnlHeader.Controls.Add(this.label1);
         this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlHeader.Location = new System.Drawing.Point(3, 3);
         this.pnlHeader.Name = "pnlHeader";
         this.pnlHeader.Size = new System.Drawing.Size(509, 35);
         this.pnlHeader.TabIndex = 0;
         // 
         // grdItems
         // 
         this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdItems.Location = new System.Drawing.Point(3, 44);
         this.grdItems.MainView = this.grdvItems;
         this.grdItems.Name = "grdItems";
         this.grdItems.Size = new System.Drawing.Size(509, 238);
         this.grdItems.TabIndex = 1;
         this.grdItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvItems});
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
         // btnSearch
         // 
         this.btnSearch.Location = new System.Drawing.Point(220, 7);
         this.btnSearch.Name = "btnSearch";
         this.btnSearch.Size = new System.Drawing.Size(88, 20);
         this.btnSearch.TabIndex = 5;
         this.btnSearch.Text = "Search";
         this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
         // 
         // txtSearch
         // 
         this.txtSearch.Location = new System.Drawing.Point(46, 7);
         this.txtSearch.Name = "txtSearch";
         this.txtSearch.Size = new System.Drawing.Size(168, 20);
         this.txtSearch.TabIndex = 4;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(0, 10);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(40, 13);
         this.label1.TabIndex = 3;
         this.label1.Text = "&Search";
         // 
         // ctlSelectItem
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tlpMain);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlSelectItem";
         this.Size = new System.Drawing.Size(515, 285);
         this.Load += new System.EventHandler(this.ctlSelectItem_Load);
         this.tlpMain.ResumeLayout(false);
         this.pnlHeader.ResumeLayout(false);
         this.pnlHeader.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvItems)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private System.Windows.Forms.Panel pnlHeader;
      private DevExpress.XtraGrid.GridControl grdItems;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvItems;
      private DevExpress.XtraGrid.Columns.GridColumn ItemName;
      private DevExpress.XtraGrid.Columns.GridColumn Description;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
      private DevExpress.XtraEditors.SimpleButton btnSearch;
      private DevExpress.XtraEditors.TextEdit txtSearch;
      private System.Windows.Forms.Label label1;
   }
}
