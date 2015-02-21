namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
    partial class ctlReleaseOrder
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
            this.popup1 = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.grdDRItems = new DevExpress.XtraGrid.GridControl();
            this.bSrc = new System.Windows.Forms.BindingSource(this.components);
            this.dsData = new System.Data.DataSet();
            this.tblData = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.grdvDRItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoCheckBox = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnCreateRO = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtDriver = new DevExpress.XtraEditors.TextEdit();
            this.txtTruck = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtNotes = new DevExpress.XtraEditors.MemoEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popup1)).BeginInit();
            this.popup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDRItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvDRItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoCheckBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDriver.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTruck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.panelControl1, 0, 0);
            this.tlpMain.Controls.Add(this.panelControl2, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlpMain.Size = new System.Drawing.Size(664, 501);
            this.tlpMain.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.popup1);
            this.panelControl1.Controls.Add(this.grdDRItems);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(658, 440);
            this.panelControl1.TabIndex = 0;
            // 
            // popup1
            // 
            this.popup1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popup1.Controls.Add(this.panelControl3);
            this.popup1.Location = new System.Drawing.Point(184, 116);
            this.popup1.Name = "popup1";
            this.popup1.Size = new System.Drawing.Size(316, 170);
            this.popup1.TabIndex = 1;
            this.popup1.Visible = false;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnClose);
            this.panelControl3.Controls.Add(this.labelControl3);
            this.panelControl3.Controls.Add(this.txtTruck);
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Controls.Add(this.txtDriver);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Controls.Add(this.btnSave);
            this.panelControl3.Controls.Add(this.txtNotes);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(316, 170);
            this.panelControl3.TabIndex = 0;
            // 
            // grdDRItems
            // 
            this.grdDRItems.DataSource = this.bSrc;
            this.grdDRItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDRItems.Location = new System.Drawing.Point(2, 2);
            this.grdDRItems.MainView = this.grdvDRItems;
            this.grdDRItems.Name = "grdDRItems";
            this.grdDRItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoCheckBox});
            this.grdDRItems.Size = new System.Drawing.Size(654, 436);
            this.grdDRItems.TabIndex = 0;
            this.grdDRItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvDRItems});
            // 
            // bSrc
            // 
            this.bSrc.DataMember = "tblData";
            this.bSrc.DataSource = this.dsData;
            // 
            // dsData
            // 
            this.dsData.DataSetName = "NewDataSet";
            this.dsData.Tables.AddRange(new System.Data.DataTable[] {
            this.tblData});
            // 
            // tblData
            // 
            this.tblData.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5});
            this.tblData.TableName = "tblData";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Checkbox";
            this.dataColumn1.DataType = typeof(bool);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "DR";
            this.dataColumn2.DataType = typeof(int);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Customer";
            this.dataColumn3.DataType = typeof(object);
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "AmountDue";
            this.dataColumn4.DataType = typeof(double);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "InvoiceDate";
            // 
            // grdvDRItems
            // 
            this.grdvDRItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.grdvDRItems.GridControl = this.grdDRItems;
            this.grdvDRItems.Name = "grdvDRItems";
            this.grdvDRItems.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvDRItems.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvDRItems.OptionsView.EnableAppearanceOddRow = true;
            this.grdvDRItems.OptionsView.ShowGroupPanel = false;
            this.grdvDRItems.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grdvDRItems_CustomUnboundColumnData);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = " ";
            this.gridColumn5.ColumnEdit = this.repoCheckBox;
            this.gridColumn5.FieldName = "Checkbox";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.FixedWidth = true;
            this.gridColumn5.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 50;
            // 
            // repoCheckBox
            // 
            this.repoCheckBox.AutoHeight = false;
            this.repoCheckBox.Name = "repoCheckBox";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "DR#";
            this.gridColumn1.DisplayFormat.FormatString = "000000";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "DR";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 110;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Customer";
            this.gridColumn2.FieldName = "Customer";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 184;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Total Amount Due";
            this.gridColumn3.DisplayFormat.FormatString = "#,##0.00";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "AmountDue";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 130;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Transaction Date";
            this.gridColumn4.FieldName = "InvoiceDate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 130;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnCancel);
            this.panelControl2.Controls.Add(this.btnCreateRO);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(3, 449);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(658, 49);
            this.panelControl2.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(336, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreateRO
            // 
            this.btnCreateRO.Location = new System.Drawing.Point(223, 9);
            this.btnCreateRO.Name = "btnCreateRO";
            this.btnCreateRO.Size = new System.Drawing.Size(86, 30);
            this.btnCreateRO.TabIndex = 0;
            this.btnCreateRO.Text = "C&reate  R. O.";
            this.btnCreateRO.Click += new System.EventHandler(this.btnCreateRO_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(68, 137);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(29, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Driver";
            // 
            // txtDriver
            // 
            this.txtDriver.Location = new System.Drawing.Point(68, 14);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.Size = new System.Drawing.Size(162, 20);
            this.txtDriver.TabIndex = 2;
            // 
            // txtTruck
            // 
            this.txtTruck.Location = new System.Drawing.Point(68, 40);
            this.txtTruck.Name = "txtTruck";
            this.txtTruck.Size = new System.Drawing.Size(162, 20);
            this.txtTruck.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Truck #";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(24, 69);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(28, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(68, 66);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(228, 65);
            this.txtNotes.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(155, 137);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Cl&ose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctlReleaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "ctlReleaseOrder";
            this.Size = new System.Drawing.Size(664, 501);
            this.Load += new System.EventHandler(this.ctlReleaseOrder_Load);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popup1)).EndInit();
            this.popup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDRItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvDRItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoCheckBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDriver.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTruck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotes.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnCreateRO;
        private DevExpress.XtraGrid.GridControl grdDRItems;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvDRItems;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repoCheckBox;
        private System.Windows.Forms.BindingSource bSrc;
        private System.Data.DataSet dsData;
        private System.Data.DataTable tblData;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private DevExpress.XtraBars.PopupControlContainer popup1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtTruck;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtDriver;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.MemoEdit txtNotes;
    }
}
