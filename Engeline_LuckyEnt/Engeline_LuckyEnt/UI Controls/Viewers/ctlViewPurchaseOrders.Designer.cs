namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
   partial class ctlViewPurchaseOrders
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
          this.pnlHeader = new System.Windows.Forms.Panel();
          this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
          this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
          this.dtRange = new Engeline_LuckyEnt.UI_Controls.ctlDateRange();
          this.pnlFooter = new System.Windows.Forms.Panel();
          this.btnClose = new DevExpress.XtraEditors.SimpleButton();
          this.btnCancelPO = new DevExpress.XtraEditors.SimpleButton();
          this.btnNewPO = new DevExpress.XtraEditors.SimpleButton();
          this.btnViewPO = new DevExpress.XtraEditors.SimpleButton();
          this.grdPO = new DevExpress.XtraGrid.GridControl();
          this.CMMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
          this.mnuViewPO = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
          this.mnuNewPO = new System.Windows.Forms.ToolStripMenuItem();
          this.mnuCancelPO = new System.Windows.Forms.ToolStripMenuItem();
          this.grdvPO = new DevExpress.XtraGrid.Views.Grid.GridView();
          this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.tlpMain.SuspendLayout();
          this.pnlHeader.SuspendLayout();
          this.pnlFooter.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.grdPO)).BeginInit();
          this.CMMenu.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.grdvPO)).BeginInit();
          this.SuspendLayout();
          // 
          // tlpMain
          // 
          this.tlpMain.ColumnCount = 1;
          this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
          this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
          this.tlpMain.Controls.Add(this.pnlFooter, 0, 2);
          this.tlpMain.Controls.Add(this.grdPO, 0, 1);
          this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
          this.tlpMain.Location = new System.Drawing.Point(0, 0);
          this.tlpMain.Name = "tlpMain";
          this.tlpMain.RowCount = 3;
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.17636F));
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
          this.tlpMain.Size = new System.Drawing.Size(914, 533);
          this.tlpMain.TabIndex = 0;
          // 
          // pnlHeader
          // 
          this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.pnlHeader.Controls.Add(this.btnPrint);
          this.pnlHeader.Controls.Add(this.btnRefresh);
          this.pnlHeader.Controls.Add(this.dtRange);
          this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pnlHeader.Location = new System.Drawing.Point(3, 3);
          this.pnlHeader.Name = "pnlHeader";
          this.pnlHeader.Size = new System.Drawing.Size(908, 48);
          this.pnlHeader.TabIndex = 0;
          // 
          // btnPrint
          // 
          this.btnPrint.Location = new System.Drawing.Point(598, 10);
          this.btnPrint.Name = "btnPrint";
          this.btnPrint.Size = new System.Drawing.Size(115, 23);
          this.btnPrint.TabIndex = 4;
          this.btnPrint.Text = "&Print";
          this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
          // 
          // btnRefresh
          // 
          this.btnRefresh.Location = new System.Drawing.Point(477, 10);
          this.btnRefresh.Name = "btnRefresh";
          this.btnRefresh.Size = new System.Drawing.Size(115, 23);
          this.btnRefresh.TabIndex = 3;
          this.btnRefresh.Text = "&Refresh";
          this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
          // 
          // dtRange
          // 
          this.dtRange.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.dtRange.Location = new System.Drawing.Point(3, 10);
          this.dtRange.Name = "dtRange";
          this.dtRange.Size = new System.Drawing.Size(442, 28);
          this.dtRange.TabIndex = 2;
          this.dtRange.DateSelectionChanged += new System.EventHandler(this.dtRange_DateSelectionChanged);
          // 
          // pnlFooter
          // 
          this.pnlFooter.Controls.Add(this.btnClose);
          this.pnlFooter.Controls.Add(this.btnCancelPO);
          this.pnlFooter.Controls.Add(this.btnNewPO);
          this.pnlFooter.Controls.Add(this.btnViewPO);
          this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pnlFooter.Location = new System.Drawing.Point(3, 461);
          this.pnlFooter.Name = "pnlFooter";
          this.pnlFooter.Size = new System.Drawing.Size(908, 69);
          this.pnlFooter.TabIndex = 1;
          // 
          // btnClose
          // 
          this.btnClose.Location = new System.Drawing.Point(534, 14);
          this.btnClose.Name = "btnClose";
          this.btnClose.Size = new System.Drawing.Size(116, 31);
          this.btnClose.TabIndex = 3;
          this.btnClose.Text = "Close";
          this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
          // 
          // btnCancelPO
          // 
          this.btnCancelPO.Location = new System.Drawing.Point(412, 14);
          this.btnCancelPO.Name = "btnCancelPO";
          this.btnCancelPO.Size = new System.Drawing.Size(116, 31);
          this.btnCancelPO.TabIndex = 2;
          this.btnCancelPO.Text = "&Cancel P.O.";
          this.btnCancelPO.Click += new System.EventHandler(this.btnCancelPO_Click);
          // 
          // btnNewPO
          // 
          this.btnNewPO.Location = new System.Drawing.Point(778, 13);
          this.btnNewPO.Name = "btnNewPO";
          this.btnNewPO.Size = new System.Drawing.Size(116, 31);
          this.btnNewPO.TabIndex = 1;
          this.btnNewPO.Text = "&New P.O.";
          this.btnNewPO.Visible = false;
          this.btnNewPO.Click += new System.EventHandler(this.btnNewPO_Click);
          // 
          // btnViewPO
          // 
          this.btnViewPO.Location = new System.Drawing.Point(290, 14);
          this.btnViewPO.Name = "btnViewPO";
          this.btnViewPO.Size = new System.Drawing.Size(116, 31);
          this.btnViewPO.TabIndex = 0;
          this.btnViewPO.Text = "&View P.O.";
          this.btnViewPO.Click += new System.EventHandler(this.btnViewPO_Click);
          // 
          // grdPO
          // 
          this.grdPO.ContextMenuStrip = this.CMMenu;
          this.grdPO.Location = new System.Drawing.Point(3, 57);
          this.grdPO.MainView = this.grdvPO;
          this.grdPO.Name = "grdPO";
          this.grdPO.Size = new System.Drawing.Size(908, 398);
          this.grdPO.TabIndex = 2;
          this.grdPO.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvPO});
          // 
          // CMMenu
          // 
          this.CMMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewPO,
            this.toolStripMenuItem1,
            this.mnuNewPO,
            this.mnuCancelPO});
          this.CMMenu.Name = "CMMenu";
          this.CMMenu.Size = new System.Drawing.Size(195, 76);
          // 
          // mnuViewPO
          // 
          this.mnuViewPO.Name = "mnuViewPO";
          this.mnuViewPO.Size = new System.Drawing.Size(194, 22);
          this.mnuViewPO.Text = "View PO";
          this.mnuViewPO.Click += new System.EventHandler(this.mnuViewPO_Click);
          // 
          // toolStripMenuItem1
          // 
          this.toolStripMenuItem1.Name = "toolStripMenuItem1";
          this.toolStripMenuItem1.Size = new System.Drawing.Size(191, 6);
          // 
          // mnuNewPO
          // 
          this.mnuNewPO.Name = "mnuNewPO";
          this.mnuNewPO.Size = new System.Drawing.Size(194, 22);
          this.mnuNewPO.Text = "New Purchase Order";
          this.mnuNewPO.Visible = false;
          this.mnuNewPO.Click += new System.EventHandler(this.mnuNewPO_Click);
          // 
          // mnuCancelPO
          // 
          this.mnuCancelPO.Name = "mnuCancelPO";
          this.mnuCancelPO.Size = new System.Drawing.Size(194, 22);
          this.mnuCancelPO.Text = "Cancel Purchase Order";
          this.mnuCancelPO.Visible = false;
          this.mnuCancelPO.Click += new System.EventHandler(this.mnuCancelPO_Click);
          // 
          // grdvPO
          // 
          this.grdvPO.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn7});
          this.grdvPO.GridControl = this.grdPO;
          this.grdvPO.Name = "grdvPO";
          this.grdvPO.OptionsBehavior.Editable = false;
          this.grdvPO.OptionsSelection.EnableAppearanceFocusedCell = false;
          this.grdvPO.OptionsView.ShowGroupPanel = false;
          this.grdvPO.OptionsView.ShowIndicator = false;
          this.grdvPO.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grdvPO_CustomUnboundColumnData);
          // 
          // gridColumn1
          // 
          this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
          this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
          this.gridColumn1.Caption = "PO ID";
          this.gridColumn1.DisplayFormat.FormatString = "000000";
          this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
          this.gridColumn1.FieldName = "ID";
          this.gridColumn1.Name = "gridColumn1";
          this.gridColumn1.OptionsColumn.AllowMove = false;
          this.gridColumn1.OptionsColumn.AllowSize = false;
          this.gridColumn1.OptionsColumn.FixedWidth = true;
          this.gridColumn1.Visible = true;
          this.gridColumn1.VisibleIndex = 0;
          // 
          // gridColumn2
          // 
          this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
          this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
          this.gridColumn2.Caption = "Date";
          this.gridColumn2.DisplayFormat.FormatString = "MM/dd/yyyy";
          this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
          this.gridColumn2.FieldName = "TransactionDate";
          this.gridColumn2.Name = "gridColumn2";
          this.gridColumn2.OptionsColumn.AllowMove = false;
          this.gridColumn2.OptionsColumn.FixedWidth = true;
          this.gridColumn2.Visible = true;
          this.gridColumn2.VisibleIndex = 1;
          this.gridColumn2.Width = 85;
          // 
          // gridColumn3
          // 
          this.gridColumn3.Caption = "Warehouse";
          this.gridColumn3.FieldName = "warehouse";
          this.gridColumn3.Name = "gridColumn3";
          this.gridColumn3.OptionsColumn.AllowMove = false;
          this.gridColumn3.UnboundType = DevExpress.Data.UnboundColumnType.String;
          this.gridColumn3.Visible = true;
          this.gridColumn3.VisibleIndex = 2;
          this.gridColumn3.Width = 215;
          // 
          // gridColumn4
          // 
          this.gridColumn4.Caption = "Amount";
          this.gridColumn4.DisplayFormat.FormatString = "{0:N2}";
          this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
          this.gridColumn4.FieldName = "AmountDue";
          this.gridColumn4.Name = "gridColumn4";
          this.gridColumn4.OptionsColumn.AllowMove = false;
          this.gridColumn4.OptionsColumn.FixedWidth = true;
          this.gridColumn4.Visible = true;
          this.gridColumn4.VisibleIndex = 3;
          this.gridColumn4.Width = 100;
          // 
          // gridColumn5
          // 
          this.gridColumn5.Caption = "Status";
          this.gridColumn5.FieldName = "PO_Status";
          this.gridColumn5.Name = "gridColumn5";
          this.gridColumn5.OptionsColumn.AllowMove = false;
          this.gridColumn5.OptionsColumn.FixedWidth = true;
          this.gridColumn5.UnboundType = DevExpress.Data.UnboundColumnType.String;
          this.gridColumn5.Visible = true;
          this.gridColumn5.VisibleIndex = 4;
          // 
          // gridColumn6
          // 
          this.gridColumn6.Caption = "Excess";
          this.gridColumn6.FieldName = "PO_Excess";
          this.gridColumn6.Name = "gridColumn6";
          this.gridColumn6.OptionsColumn.AllowMove = false;
          this.gridColumn6.OptionsColumn.FixedWidth = true;
          this.gridColumn6.UnboundType = DevExpress.Data.UnboundColumnType.String;
          this.gridColumn6.Visible = true;
          this.gridColumn6.VisibleIndex = 5;
          // 
          // gridColumn8
          // 
          this.gridColumn8.Caption = "Canceled";
          this.gridColumn8.FieldName = "Canceled";
          this.gridColumn8.Name = "gridColumn8";
          this.gridColumn8.OptionsColumn.FixedWidth = true;
          this.gridColumn8.Visible = true;
          this.gridColumn8.VisibleIndex = 6;
          // 
          // gridColumn7
          // 
          this.gridColumn7.Caption = "Entered By";
          this.gridColumn7.FieldName = "user.UserName";
          this.gridColumn7.Name = "gridColumn7";
          this.gridColumn7.OptionsColumn.AllowMove = false;
          this.gridColumn7.Visible = true;
          this.gridColumn7.VisibleIndex = 7;
          this.gridColumn7.Width = 239;
          // 
          // ctlViewPurchaseOrders
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.tlpMain);
          this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.Name = "ctlViewPurchaseOrders";
          this.Size = new System.Drawing.Size(914, 533);
          this.Load += new System.EventHandler(this.ctlViewPurchaseOrders_Load);
          this.tlpMain.ResumeLayout(false);
          this.pnlHeader.ResumeLayout(false);
          this.pnlFooter.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.grdPO)).EndInit();
          this.CMMenu.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.grdvPO)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private System.Windows.Forms.Panel pnlHeader;
      private System.Windows.Forms.Panel pnlFooter;
      private DevExpress.XtraGrid.GridControl grdPO;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvPO;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
      private DevExpress.XtraEditors.SimpleButton btnRefresh;
      private ctlDateRange dtRange;
      private System.Windows.Forms.ContextMenuStrip CMMenu;
      private System.Windows.Forms.ToolStripMenuItem mnuViewPO;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem mnuNewPO;
      private System.Windows.Forms.ToolStripMenuItem mnuCancelPO;
      private DevExpress.XtraEditors.SimpleButton btnCancelPO;
      private DevExpress.XtraEditors.SimpleButton btnNewPO;
      private DevExpress.XtraEditors.SimpleButton btnViewPO;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
      private DevExpress.XtraEditors.SimpleButton btnPrint;
      private DevExpress.XtraEditors.SimpleButton btnClose;
   }
}
