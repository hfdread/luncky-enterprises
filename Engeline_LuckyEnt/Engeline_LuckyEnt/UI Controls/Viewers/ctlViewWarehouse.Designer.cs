namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
    partial class ctlViewWarehouse
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
            this.wSrc = new System.Windows.Forms.BindingSource(this.components);
            this.dsData = new System.Data.DataSet();
            this.tblData = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.grdWarehouse = new DevExpress.XtraGrid.GridControl();
            this.grdvWarehouse = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.wSrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblData)).BeginInit();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWarehouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvWarehouse)).BeginInit();
            this.SuspendLayout();
            // 
            // wSrc
            // 
            this.wSrc.DataMember = "tblData";
            this.wSrc.DataSource = this.dsData;
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
            this.dataColumn5,
            this.dataColumn6});
            this.tblData.TableName = "tblData";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "ID";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Name";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Address";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "Phone";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "Fax";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "Dirty";
            this.dataColumn6.DataType = typeof(bool);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 742F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tlpMain.Controls.Add(this.panelControl1, 0, 1);
            this.tlpMain.Controls.Add(this.grdWarehouse, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpMain.Size = new System.Drawing.Size(767, 393);
            this.tlpMain.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnDelete);
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 344);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(736, 46);
            this.panelControl1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(435, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 26);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(220, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 26);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grdWarehouse
            // 
            this.grdWarehouse.DataSource = this.wSrc;
            this.grdWarehouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWarehouse.Location = new System.Drawing.Point(3, 3);
            this.grdWarehouse.MainView = this.grdvWarehouse;
            this.grdWarehouse.Name = "grdWarehouse";
            this.grdWarehouse.Size = new System.Drawing.Size(736, 335);
            this.grdWarehouse.TabIndex = 1;
            this.grdWarehouse.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvWarehouse});
            // 
            // grdvWarehouse
            // 
            this.grdvWarehouse.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.grdvWarehouse.GridControl = this.grdWarehouse;
            this.grdvWarehouse.Name = "grdvWarehouse";
            this.grdvWarehouse.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvWarehouse.OptionsView.EnableAppearanceOddRow = true;
            this.grdvWarehouse.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdvWarehouse.OptionsView.ShowGroupPanel = false;
            this.grdvWarehouse.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdvWarehouse_InitNewRow);
            this.grdvWarehouse.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdvWarehouse_CellValueChanged);
            this.grdvWarehouse.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grdvWarehouse_ValidateRow);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Warehouse ID";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 91;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Name";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 205;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Address";
            this.gridColumn3.FieldName = "Address";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 250;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Fax";
            this.gridColumn4.FieldName = "Fax";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 90;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Phone";
            this.gridColumn5.FieldName = "Phone";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 90;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(328, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 26);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ctlViewWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "ctlViewWarehouse";
            this.Size = new System.Drawing.Size(767, 393);
            this.Load += new System.EventHandler(this.ctlViewWarehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wSrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblData)).EndInit();
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWarehouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvWarehouse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //+manually added datasources
        private System.Windows.Forms.BindingSource wSrc;
        private System.Data.DataSet dsData;
        private System.Data.DataTable tblData;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        //-
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdWarehouse;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvWarehouse;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
    }
}
