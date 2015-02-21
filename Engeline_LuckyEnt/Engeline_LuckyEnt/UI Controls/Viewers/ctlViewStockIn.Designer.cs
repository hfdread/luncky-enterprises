namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
   partial class ctlViewStockIn
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
          this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
          this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
          this.btnUnpaidSI = new DevExpress.XtraEditors.SimpleButton();
          this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
          this.dtRange = new Engeline_LuckyEnt.UI_Controls.ctlDateRange();
          this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
          this.btnAddFreight = new DevExpress.XtraEditors.SimpleButton();
          this.btnCancelStockIn = new DevExpress.XtraEditors.SimpleButton();
          this.btnNewStockIn = new DevExpress.XtraEditors.SimpleButton();
          this.btnViewStockIn = new DevExpress.XtraEditors.SimpleButton();
          this.grdStockin = new DevExpress.XtraGrid.GridControl();
          this.CMMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
          this.mnuViewStockIn = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
          this.mnuNewStockIn = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuCancelStockIn = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuAddFreight = new System.Windows.Forms.ToolStripMenuItem();
          this.grdvStockin = new DevExpress.XtraGrid.Views.Grid.GridView();
          this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
          this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
          this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
          this.tlpMain.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
          this.pnlHeader.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
          this.pnlFooter.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.grdStockin)).BeginInit();
          this.CMMenu.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.grdvStockin)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
          this.SuspendLayout();
          // 
          // tlpMain
          // 
          this.tlpMain.ColumnCount = 1;
          this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
          this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
          this.tlpMain.Controls.Add(this.pnlFooter, 0, 2);
          this.tlpMain.Controls.Add(this.grdStockin, 0, 1);
          this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
          this.tlpMain.Location = new System.Drawing.Point(0, 0);
          this.tlpMain.Name = "tlpMain";
          this.tlpMain.RowCount = 3;
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
          this.tlpMain.Size = new System.Drawing.Size(888, 568);
          this.tlpMain.TabIndex = 0;
          // 
          // pnlHeader
          // 
          this.pnlHeader.Controls.Add(this.btnPrint);
          this.pnlHeader.Controls.Add(this.btnUnpaidSI);
          this.pnlHeader.Controls.Add(this.btnRefresh);
          this.pnlHeader.Controls.Add(this.dtRange);
          this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pnlHeader.Location = new System.Drawing.Point(3, 3);
          this.pnlHeader.Name = "pnlHeader";
          this.pnlHeader.Size = new System.Drawing.Size(882, 47);
          this.pnlHeader.TabIndex = 0;
          // 
          // btnPrint
          // 
          this.btnPrint.Location = new System.Drawing.Point(730, 11);
          this.btnPrint.Name = "btnPrint";
          this.btnPrint.Size = new System.Drawing.Size(115, 23);
          this.btnPrint.TabIndex = 3;
          this.btnPrint.Text = "&Print";
          this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
          // 
          // btnUnpaidSI
          // 
          this.btnUnpaidSI.Location = new System.Drawing.Point(609, 11);
          this.btnUnpaidSI.Name = "btnUnpaidSI";
          this.btnUnpaidSI.Size = new System.Drawing.Size(115, 23);
          this.btnUnpaidSI.TabIndex = 2;
          this.btnUnpaidSI.Text = "&Unpaid SI";
          this.btnUnpaidSI.Click += new System.EventHandler(this.btnUnpaidSI_Click);
          // 
          // btnRefresh
          // 
          this.btnRefresh.Location = new System.Drawing.Point(488, 11);
          this.btnRefresh.Name = "btnRefresh";
          this.btnRefresh.Size = new System.Drawing.Size(115, 23);
          this.btnRefresh.TabIndex = 1;
          this.btnRefresh.Text = "&Refresh";
          this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
          // 
          // dtRange
          // 
          this.dtRange.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.dtRange.Location = new System.Drawing.Point(14, 11);
          this.dtRange.Name = "dtRange";
          this.dtRange.Size = new System.Drawing.Size(442, 28);
          this.dtRange.TabIndex = 0;
          this.dtRange.DateSelectionChanged += new System.EventHandler(this.dtRange_DateSelectionChanged);
          // 
          // pnlFooter
          // 
          this.pnlFooter.Controls.Add(this.btnAddFreight);
          this.pnlFooter.Controls.Add(this.btnCancelStockIn);
          this.pnlFooter.Controls.Add(this.btnNewStockIn);
          this.pnlFooter.Controls.Add(this.btnViewStockIn);
          this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pnlFooter.Location = new System.Drawing.Point(3, 506);
          this.pnlFooter.Name = "pnlFooter";
          this.pnlFooter.Size = new System.Drawing.Size(882, 59);
          this.pnlFooter.TabIndex = 1;
          // 
          // btnAddFreight
          // 
          this.btnAddFreight.Location = new System.Drawing.Point(771, 15);
          this.btnAddFreight.Name = "btnAddFreight";
          this.btnAddFreight.Size = new System.Drawing.Size(104, 28);
          this.btnAddFreight.TabIndex = 3;
          this.btnAddFreight.Text = "&Add Freight";
          this.btnAddFreight.Click += new System.EventHandler(this.btnAddFreight_Click);
          // 
          // btnCancelStockIn
          // 
          this.btnCancelStockIn.Location = new System.Drawing.Point(661, 15);
          this.btnCancelStockIn.Name = "btnCancelStockIn";
          this.btnCancelStockIn.Size = new System.Drawing.Size(104, 28);
          this.btnCancelStockIn.TabIndex = 2;
          this.btnCancelStockIn.Text = "&Cancel Stock In";
          this.btnCancelStockIn.Click += new System.EventHandler(this.btnCancelStockIn_Click);
          // 
          // btnNewStockIn
          // 
          this.btnNewStockIn.Location = new System.Drawing.Point(455, 15);
          this.btnNewStockIn.Name = "btnNewStockIn";
          this.btnNewStockIn.Size = new System.Drawing.Size(104, 28);
          this.btnNewStockIn.TabIndex = 1;
          this.btnNewStockIn.Text = "&New Stock In";
          this.btnNewStockIn.Click += new System.EventHandler(this.btnNewStockIn_Click);
          // 
          // btnViewStockIn
          // 
          this.btnViewStockIn.Location = new System.Drawing.Point(345, 15);
          this.btnViewStockIn.Name = "btnViewStockIn";
          this.btnViewStockIn.Size = new System.Drawing.Size(104, 28);
          this.btnViewStockIn.TabIndex = 0;
          this.btnViewStockIn.Text = "&View Stock In";
          this.btnViewStockIn.Click += new System.EventHandler(this.btnViewStockIn_Click);
          // 
          // grdStockin
          // 
          this.grdStockin.ContextMenuStrip = this.CMMenu;
          this.grdStockin.Dock = System.Windows.Forms.DockStyle.Fill;
          this.grdStockin.Location = new System.Drawing.Point(3, 56);
          this.grdStockin.MainView = this.grdvStockin;
          this.grdStockin.Name = "grdStockin";
          this.grdStockin.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
          this.grdStockin.Size = new System.Drawing.Size(882, 444);
          this.grdStockin.TabIndex = 2;
          this.grdStockin.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvStockin});
          this.grdStockin.Click += new System.EventHandler(this.grdStockin_Click);
          // 
          // CMMenu
          // 
          this.CMMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewStockIn,
            this.toolStripMenuItem1,
            this.mnuNewStockIn,
            this.mnuCancelStockIn,
            this.mnuAddFreight});
          this.CMMenu.Name = "CMMenu";
          this.CMMenu.Size = new System.Drawing.Size(156, 98);
          // 
          // mnuViewStockIn
          // 
          this.mnuViewStockIn.Name = "mnuViewStockIn";
          this.mnuViewStockIn.Size = new System.Drawing.Size(155, 22);
          this.mnuViewStockIn.Text = "View Stock In";
          this.mnuViewStockIn.Click += new System.EventHandler(this.mnuViewStockIn_Click);
          // 
          // toolStripMenuItem1
          // 
          this.toolStripMenuItem1.Name = "toolStripMenuItem1";
          this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
          // 
          // mnuNewStockIn
          // 
          this.mnuNewStockIn.Name = "mnuNewStockIn";
          this.mnuNewStockIn.Size = new System.Drawing.Size(155, 22);
          this.mnuNewStockIn.Text = "New Stock In";
          this.mnuNewStockIn.Click += new System.EventHandler(this.mnuNewStockIn_Click);
          // 
          // mnuCancelStockIn
          // 
          this.mnuCancelStockIn.Name = "mnuCancelStockIn";
          this.mnuCancelStockIn.Size = new System.Drawing.Size(155, 22);
          this.mnuCancelStockIn.Text = "Cancel Stock In";
          this.mnuCancelStockIn.Click += new System.EventHandler(this.mnuCancelStockIn_Click);
          // 
          // mnuAddFreight
          // 
          this.mnuAddFreight.Name = "mnuAddFreight";
          this.mnuAddFreight.Size = new System.Drawing.Size(155, 22);
          this.mnuAddFreight.Text = "Add Freight";
          this.mnuAddFreight.Click += new System.EventHandler(this.mnuAddFreight_Click);
          // 
          // grdvStockin
          // 
          this.grdvStockin.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn9});
          this.grdvStockin.GridControl = this.grdStockin;
          this.grdvStockin.Name = "grdvStockin";
          this.grdvStockin.OptionsBehavior.Editable = false;
          this.grdvStockin.OptionsBehavior.FocusLeaveOnTab = true;
          this.grdvStockin.OptionsCustomization.AllowColumnMoving = false;
          this.grdvStockin.OptionsNavigation.UseTabKey = false;
          this.grdvStockin.OptionsSelection.EnableAppearanceFocusedCell = false;
          this.grdvStockin.OptionsView.ShowGroupPanel = false;
          this.grdvStockin.OptionsView.ShowIndicator = false;
          this.grdvStockin.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grdvStockin_RowCellClick);
          // 
          // gridColumn1
          // 
          this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
          this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
          this.gridColumn1.Caption = "StockIn No.";
          this.gridColumn1.DisplayFormat.FormatString = "000000";
          this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
          this.gridColumn1.FieldName = "ID";
          this.gridColumn1.Name = "gridColumn1";
          this.gridColumn1.OptionsColumn.AllowSize = false;
          this.gridColumn1.OptionsColumn.FixedWidth = true;
          this.gridColumn1.Visible = true;
          this.gridColumn1.VisibleIndex = 0;
          this.gridColumn1.Width = 85;
          // 
          // repositoryItemHyperLinkEdit1
          // 
          this.repositoryItemHyperLinkEdit1.AutoHeight = false;
          this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
          // 
          // gridColumn2
          // 
          this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
          this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
          this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
          this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
          this.gridColumn2.Caption = "Date";
          this.gridColumn2.DisplayFormat.FormatString = "MM/dd/yyyy";
          this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
          this.gridColumn2.FieldName = "StockInDate";
          this.gridColumn2.Name = "gridColumn2";
          this.gridColumn2.OptionsColumn.FixedWidth = true;
          this.gridColumn2.Visible = true;
          this.gridColumn2.VisibleIndex = 1;
          this.gridColumn2.Width = 85;
          // 
          // gridColumn3
          // 
          this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
          this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
          this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
          this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
          this.gridColumn3.Caption = "Arrival Date";
          this.gridColumn3.DisplayFormat.FormatString = "MM/dd/yyyy";
          this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
          this.gridColumn3.FieldName = "ArrivalDate";
          this.gridColumn3.Name = "gridColumn3";
          this.gridColumn3.OptionsColumn.FixedWidth = true;
          this.gridColumn3.Visible = true;
          this.gridColumn3.VisibleIndex = 2;
          this.gridColumn3.Width = 85;
          // 
          // gridColumn4
          // 
          this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
          this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
          this.gridColumn4.Caption = "SOC ID";
          this.gridColumn4.ColumnEdit = this.repositoryItemHyperLinkEdit1;
          this.gridColumn4.DisplayFormat.FormatString = "000000";
          this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
          this.gridColumn4.FieldName = "statementofaccount.ID";
          this.gridColumn4.Name = "gridColumn4";
          this.gridColumn4.OptionsColumn.FixedWidth = true;
          this.gridColumn4.Visible = true;
          this.gridColumn4.VisibleIndex = 3;
          // 
          // gridColumn5
          // 
          this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
          this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
          this.gridColumn5.Caption = "Supplier";
          this.gridColumn5.FieldName = "statementofaccount.Supplier";
          this.gridColumn5.Name = "gridColumn5";
          this.gridColumn5.Visible = true;
          this.gridColumn5.VisibleIndex = 4;
          this.gridColumn5.Width = 137;
          // 
          // gridColumn6
          // 
          this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
          this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
          this.gridColumn6.Caption = "Amount";
          this.gridColumn6.DisplayFormat.FormatString = "{0:N2}";
          this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
          this.gridColumn6.FieldName = "AmountDue";
          this.gridColumn6.Name = "gridColumn6";
          this.gridColumn6.OptionsColumn.FixedWidth = true;
          this.gridColumn6.Visible = true;
          this.gridColumn6.VisibleIndex = 5;
          this.gridColumn6.Width = 100;
          // 
          // gridColumn9
          // 
          this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
          this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
          this.gridColumn9.Caption = "Paid";
          this.gridColumn9.ColumnEdit = this.repositoryItemCheckEdit2;
          this.gridColumn9.FieldName = "Paid";
          this.gridColumn9.Name = "gridColumn9";
          this.gridColumn9.OptionsColumn.FixedWidth = true;
          this.gridColumn9.Visible = true;
          this.gridColumn9.VisibleIndex = 6;
          this.gridColumn9.Width = 65;
          // 
          // repositoryItemCheckEdit2
          // 
          this.repositoryItemCheckEdit2.AutoHeight = false;
          this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
          // 
          // repositoryItemCheckEdit1
          // 
          this.repositoryItemCheckEdit1.AutoHeight = false;
          this.repositoryItemCheckEdit1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
          this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
          // 
          // ctlViewStockIn
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.tlpMain);
          this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.Name = "ctlViewStockIn";
          this.Size = new System.Drawing.Size(888, 568);
          this.Load += new System.EventHandler(this.ctlViewStockIn_Load);
          this.tlpMain.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
          this.pnlHeader.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
          this.pnlFooter.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.grdStockin)).EndInit();
          this.CMMenu.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.grdvStockin)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private DevExpress.XtraEditors.PanelControl pnlHeader;
      private DevExpress.XtraEditors.PanelControl pnlFooter;
      private DevExpress.XtraGrid.GridControl grdStockin;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvStockin;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
      private DevExpress.XtraEditors.SimpleButton btnRefresh;
      private Engeline_LuckyEnt.UI_Controls.ctlDateRange dtRange;
      private System.Windows.Forms.ContextMenuStrip CMMenu;
      private System.Windows.Forms.ToolStripMenuItem mnuViewStockIn;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem mnuNewStockIn;
      private System.Windows.Forms.ToolStripMenuItem mnuCancelStockIn;
      private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
      private DevExpress.XtraEditors.SimpleButton btnNewStockIn;
      private DevExpress.XtraEditors.SimpleButton btnViewStockIn;
      private DevExpress.XtraEditors.SimpleButton btnCancelStockIn;
      private System.Windows.Forms.ToolStripMenuItem mnuAddFreight;
      private DevExpress.XtraEditors.SimpleButton btnAddFreight;
      private DevExpress.XtraEditors.SimpleButton btnUnpaidSI;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
      private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
      private DevExpress.XtraEditors.SimpleButton btnPrint;
      private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
   }
}
