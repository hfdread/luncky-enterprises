namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
    partial class ctlViewArriveShipment
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtRange = new Engeline_LuckyEnt.UI_Controls.ctlDateRange();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grdSOC = new DevExpress.XtraGrid.GridControl();
            this.grdvSOC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.cmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_SetTrucking = new System.Windows.Forms.ToolStripMenuItem();
            this.tlpMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSOC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvSOC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.panel3.SuspendLayout();
            this.cmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.panel1, 0, 0);
            this.tlpMain.Controls.Add(this.panel2, 0, 1);
            this.tlpMain.Controls.Add(this.panel3, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.Size = new System.Drawing.Size(781, 514);
            this.tlpMain.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtRange);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 44);
            this.panel1.TabIndex = 0;
            // 
            // dtRange
            // 
            this.dtRange.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtRange.Location = new System.Drawing.Point(23, 8);
            this.dtRange.Name = "dtRange";
            this.dtRange.Size = new System.Drawing.Size(442, 28);
            this.dtRange.TabIndex = 6;
            this.dtRange.DateSelectionChanged += new System.EventHandler(this.dtRange_DateSelectionChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(508, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(117, 28);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grdSOC);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(775, 408);
            this.panel2.TabIndex = 1;
            // 
            // grdSOC
            // 
            this.grdSOC.ContextMenuStrip = this.cmMenu;
            this.grdSOC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSOC.Location = new System.Drawing.Point(0, 0);
            this.grdSOC.MainView = this.grdvSOC;
            this.grdSOC.Name = "grdSOC";
            this.grdSOC.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdSOC.Size = new System.Drawing.Size(775, 408);
            this.grdSOC.TabIndex = 0;
            this.grdSOC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvSOC});
            // 
            // grdvSOC
            // 
            this.grdvSOC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.grdvSOC.GridControl = this.grdSOC;
            this.grdvSOC.Name = "grdvSOC";
            this.grdvSOC.OptionsBehavior.Editable = false;
            this.grdvSOC.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvSOC.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvSOC.OptionsView.EnableAppearanceOddRow = true;
            this.grdvSOC.OptionsView.ShowGroupPanel = false;
            this.grdvSOC.OptionsView.ShowIndicator = false;
            this.grdvSOC.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grdvSOC_CustomUnboundColumnData);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "SoC ID";
            this.gridColumn1.DisplayFormat.FormatString = "000000";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Supplier";
            this.gridColumn2.FieldName = "From";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 216;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Shipping";
            this.gridColumn3.FieldName = "Shipping";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 170;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Voyage Number";
            this.gridColumn4.FieldName = "VoyageNumber";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 90;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Bill of Leading";
            this.gridColumn5.FieldName = "BillofLeading";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowMove = false;
            this.gridColumn5.OptionsColumn.FixedWidth = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 90;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Paid";
            this.gridColumn6.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn6.FieldName = "Paid";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowMove = false;
            this.gridColumn6.OptionsColumn.FixedWidth = true;
            this.gridColumn6.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 50;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnView);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 467);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(775, 44);
            this.panel3.TabIndex = 2;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(276, 7);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 30);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "&View SoC";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(399, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmMenu
            // 
            this.cmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_SetTrucking});
            this.cmMenu.Name = "cmMenu";
            this.cmMenu.Size = new System.Drawing.Size(153, 48);
            // 
            // mnu_SetTrucking
            // 
            this.mnu_SetTrucking.Name = "mnu_SetTrucking";
            this.mnu_SetTrucking.Size = new System.Drawing.Size(152, 22);
            this.mnu_SetTrucking.Text = "Set Trucking";
            this.mnu_SetTrucking.Click += new System.EventHandler(this.mnu_SetTrucking_Click);
            // 
            // ctlViewArriveShipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "ctlViewArriveShipment";
            this.Size = new System.Drawing.Size(781, 514);
            this.Load += new System.EventHandler(this.ctlViewArriveShipment_Load);
            this.tlpMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSOC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvSOC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.cmMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.GridControl grdSOC;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvSOC;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private ctlDateRange dtRange;
        private System.Windows.Forms.ContextMenuStrip cmMenu;
        private System.Windows.Forms.ToolStripMenuItem mnu_SetTrucking;
    }
}
