namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
    partial class ctlViewArriveShipment_Trucking
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
            this.txtInvoiceNo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.grdVans = new DevExpress.XtraGrid.GridControl();
            this.cmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_Trucking = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_Destination = new System.Windows.Forms.ToolStripMenuItem();
            this.grdvVans = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repoCheckBox = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVans)).BeginInit();
            this.cmMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdvVans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.panelControl1, 0, 0);
            this.tlpMain.Controls.Add(this.panelControl2, 0, 1);
            this.tlpMain.Controls.Add(this.panelControl3, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpMain.Size = new System.Drawing.Size(432, 403);
            this.tlpMain.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtInvoiceNo);
            this.panelControl1.Controls.Add(this.labelControl9);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(426, 49);
            this.panelControl1.TabIndex = 0;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Appearance.BackColor = System.Drawing.Color.White;
            this.txtInvoiceNo.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtInvoiceNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.txtInvoiceNo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtInvoiceNo.Location = new System.Drawing.Point(56, 15);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(109, 22);
            this.txtInvoiceNo.TabIndex = 29;
            this.txtInvoiceNo.Text = "000";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(13, 20);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(33, 13);
            this.labelControl9.TabIndex = 28;
            this.labelControl9.Text = "SoC ID";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.grdVans);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(3, 58);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(426, 297);
            this.panelControl2.TabIndex = 1;
            // 
            // grdVans
            // 
            this.grdVans.ContextMenuStrip = this.cmMenu;
            this.grdVans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdVans.Location = new System.Drawing.Point(2, 2);
            this.grdVans.MainView = this.grdvVans;
            this.grdVans.Name = "grdVans";
            this.grdVans.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoCheckBox});
            this.grdVans.Size = new System.Drawing.Size(422, 293);
            this.grdVans.TabIndex = 0;
            this.grdVans.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvVans});
            // 
            // cmMenu
            // 
            this.cmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_Trucking,
            this.mnu_Destination});
            this.cmMenu.Name = "cmMenu";
            this.cmMenu.Size = new System.Drawing.Size(153, 70);
            // 
            // mnu_Trucking
            // 
            this.mnu_Trucking.Name = "mnu_Trucking";
            this.mnu_Trucking.Size = new System.Drawing.Size(152, 22);
            this.mnu_Trucking.Text = "Trucking";
            this.mnu_Trucking.Click += new System.EventHandler(this.mnu_Trucking_Click);
            // 
            // mnu_Destination
            // 
            this.mnu_Destination.Name = "mnu_Destination";
            this.mnu_Destination.Size = new System.Drawing.Size(152, 22);
            this.mnu_Destination.Text = "Destination";
            this.mnu_Destination.Click += new System.EventHandler(this.mnu_Destination_Click);
            // 
            // grdvVans
            // 
            this.grdvVans.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.grdvVans.GridControl = this.grdVans;
            this.grdvVans.Name = "grdvVans";
            this.grdvVans.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvVans.OptionsSelection.MultiSelect = true;
            this.grdvVans.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvVans.OptionsView.EnableAppearanceOddRow = true;
            this.grdvVans.OptionsView.ShowGroupPanel = false;
            this.grdvVans.OptionsView.ShowIndicator = false;
            this.grdvVans.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grdvVans_CustomUnboundColumnData);
            // 
            // repoCheckBox
            // 
            this.repoCheckBox.AutoHeight = false;
            this.repoCheckBox.Name = "repoCheckBox";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Van Number";
            this.gridColumn1.FieldName = "VanNumber";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Trucking";
            this.gridColumn2.FieldName = "Trucking";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Destination";
            this.gridColumn3.FieldName = "Destination";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnCancel);
            this.panelControl3.Controls.Add(this.btnSave);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(3, 361);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(426, 39);
            this.panelControl3.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(215, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Close";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(121, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctlViewArriveShipment_Trucking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "ctlViewArriveShipment_Trucking";
            this.Size = new System.Drawing.Size(432, 403);
            this.Load += new System.EventHandler(this.ctlViewArriveShipment_Trucking_Load);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVans)).EndInit();
            this.cmMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdvVans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl txtInvoiceNo;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl grdVans;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvVans;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.ContextMenuStrip cmMenu;
        private System.Windows.Forms.ToolStripMenuItem mnu_Trucking;
        private System.Windows.Forms.ToolStripMenuItem mnu_Destination;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repoCheckBox;
    }
}
