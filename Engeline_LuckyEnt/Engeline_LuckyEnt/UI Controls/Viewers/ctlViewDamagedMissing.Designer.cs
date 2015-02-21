namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
    partial class ctlViewDamagedMissing
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.cboType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboItem = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboStockin = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtRange = new Engeline_LuckyEnt.UI_Controls.ctlDateRange();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.grdDamagedMissing = new DevExpress.XtraGrid.GridControl();
            this.cmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu_stockin = new System.Windows.Forms.ToolStripMenuItem();
            this.grdvDamagedMissing = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoCheckbox = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStockin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDamagedMissing)).BeginInit();
            this.cmMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdvDamagedMissing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoCheckbox)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.panelControl1, 0, 0);
            this.tlpMain.Controls.Add(this.panelControl2, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(730, 415);
            this.tlpMain.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnRefresh);
            this.panelControl1.Controls.Add(this.cboType);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.cboItem);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.cboStockin);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.dtRange);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(724, 107);
            this.panelControl1.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(477, 57);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(102, 28);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cboType
            // 
            this.cboType.EditValue = "ALL";
            this.cboType.Location = new System.Drawing.Point(327, 39);
            this.cboType.Name = "cboType";
            this.cboType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboType.Properties.Items.AddRange(new object[] {
            "ALL",
            "Damaged",
            "Missing"});
            this.cboType.Size = new System.Drawing.Size(110, 20);
            this.cboType.TabIndex = 11;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(288, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Type";
            // 
            // cboItem
            // 
            this.cboItem.EditValue = "";
            this.cboItem.Location = new System.Drawing.Point(76, 65);
            this.cboItem.Name = "cboItem";
            this.cboItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboItem.Size = new System.Drawing.Size(185, 20);
            this.cboItem.TabIndex = 9;
            this.cboItem.SelectedIndexChanged += new System.EventHandler(this.cboItem_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 68);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(22, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Item";
            // 
            // cboStockin
            // 
            this.cboStockin.EditValue = "";
            this.cboStockin.Location = new System.Drawing.Point(76, 39);
            this.cboStockin.Name = "cboStockin";
            this.cboStockin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboStockin.Size = new System.Drawing.Size(120, 20);
            this.cboStockin.TabIndex = 7;
            this.cboStockin.SelectedIndexChanged += new System.EventHandler(this.cboStockin_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 42);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "StockIn ID";
            // 
            // dtRange
            // 
            this.dtRange.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtRange.Location = new System.Drawing.Point(5, 5);
            this.dtRange.Name = "dtRange";
            this.dtRange.Size = new System.Drawing.Size(442, 28);
            this.dtRange.TabIndex = 3;
            this.dtRange.DateSelectionChanged += new System.EventHandler(this.dtRange_DateSelectionChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.grdDamagedMissing);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(3, 116);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(724, 296);
            this.panelControl2.TabIndex = 1;
            // 
            // grdDamagedMissing
            // 
            this.grdDamagedMissing.ContextMenuStrip = this.cmMenu;
            this.grdDamagedMissing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDamagedMissing.Location = new System.Drawing.Point(2, 2);
            this.grdDamagedMissing.MainView = this.grdvDamagedMissing;
            this.grdDamagedMissing.Name = "grdDamagedMissing";
            this.grdDamagedMissing.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoCheckbox});
            this.grdDamagedMissing.Size = new System.Drawing.Size(720, 292);
            this.grdDamagedMissing.TabIndex = 0;
            this.grdDamagedMissing.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvDamagedMissing});
            // 
            // cmMenu
            // 
            this.cmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_stockin});
            this.cmMenu.Name = "cmMenu";
            this.cmMenu.Size = new System.Drawing.Size(153, 48);
            // 
            // menu_stockin
            // 
            this.menu_stockin.Name = "menu_stockin";
            this.menu_stockin.Size = new System.Drawing.Size(152, 22);
            this.menu_stockin.Text = "Create StockIn";
            this.menu_stockin.Click += new System.EventHandler(this.menu_stockin_Click);
            // 
            // grdvDamagedMissing
            // 
            this.grdvDamagedMissing.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.grdvDamagedMissing.GridControl = this.grdDamagedMissing;
            this.grdvDamagedMissing.Name = "grdvDamagedMissing";
            this.grdvDamagedMissing.OptionsBehavior.Editable = false;
            this.grdvDamagedMissing.OptionsBehavior.ReadOnly = true;
            this.grdvDamagedMissing.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvDamagedMissing.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Stock In ID";
            this.gridColumn1.DisplayFormat.FormatString = "000000";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "stockin.ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Item";
            this.gridColumn2.FieldName = "item";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Original QTY";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "Original_Qty";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Missing QTY";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "Missing_Qty";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Damaged QTY";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "Damage_Qty";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Date";
            this.gridColumn6.DisplayFormat.FormatString = "MM/dd/yyyy";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "TrxDate";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "ReStock?";
            this.gridColumn7.ColumnEdit = this.repoCheckbox;
            this.gridColumn7.FieldName = "ReStock";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // repoCheckbox
            // 
            this.repoCheckbox.AutoHeight = false;
            this.repoCheckbox.Name = "repoCheckbox";
            this.repoCheckbox.ReadOnly = true;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "New Stock In ID";
            this.gridColumn8.FieldName = "NewStockinID";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // ctlViewDamagedMissing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "ctlViewDamagedMissing";
            this.Size = new System.Drawing.Size(730, 415);
            this.Load += new System.EventHandler(this.ctlViewDamagedMissing_Load);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStockin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDamagedMissing)).EndInit();
            this.cmMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdvDamagedMissing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoCheckbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl grdDamagedMissing;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvDamagedMissing;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repoCheckbox;
        private ctlDateRange dtRange;
        private DevExpress.XtraEditors.ComboBoxEdit cboType;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboItem;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cboStockin;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private System.Windows.Forms.ContextMenuStrip cmMenu;
        private System.Windows.Forms.ToolStripMenuItem menu_stockin;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
    }
}
