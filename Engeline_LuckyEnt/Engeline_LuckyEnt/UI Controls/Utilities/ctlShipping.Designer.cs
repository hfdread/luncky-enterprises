namespace Engeline_LuckyEnt.UI_Controls.Utilities
{
    partial class ctlShipping
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
            this.grdShipping = new DevExpress.XtraGrid.GridControl();
            this.shipSrc = new System.Windows.Forms.BindingSource(this.components);
            this.dsData = new System.Data.DataSet();
            this.tblData = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.grdvShipping = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdShipping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipSrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvShipping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpMain.Controls.Add(this.panelControl1, 0, 0);
            this.tlpMain.Controls.Add(this.panelControl2, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.Size = new System.Drawing.Size(774, 401);
            this.tlpMain.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.grdShipping);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(743, 345);
            this.panelControl1.TabIndex = 0;
            // 
            // grdShipping
            // 
            this.grdShipping.DataSource = this.shipSrc;
            this.grdShipping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdShipping.Location = new System.Drawing.Point(2, 2);
            this.grdShipping.MainView = this.grdvShipping;
            this.grdShipping.Name = "grdShipping";
            this.grdShipping.Size = new System.Drawing.Size(739, 341);
            this.grdShipping.TabIndex = 0;
            this.grdShipping.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvShipping});
            // 
            // shipSrc
            // 
            this.shipSrc.DataMember = "tblData";
            this.shipSrc.DataSource = this.dsData;
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
            this.dataColumn1.ColumnName = "ID";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "CompanyName";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Contact1";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "Contact2";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "Dirty";
            // 
            // grdvShipping
            // 
            this.grdvShipping.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.grdvShipping.GridControl = this.grdShipping;
            this.grdvShipping.Name = "grdvShipping";
            this.grdvShipping.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvShipping.OptionsView.EnableAppearanceOddRow = true;
            this.grdvShipping.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdvShipping.OptionsView.ShowGroupPanel = false;
            this.grdvShipping.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdvShipping_InitNewRow);
            this.grdvShipping.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdvShipping_CellValueChanged);
            this.grdvShipping.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grdvShipping_ValidateRow);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "CompanyName";
            this.gridColumn2.FieldName = "CompanyName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 220;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Contact #1";
            this.gridColumn3.FieldName = "Contact1";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 100;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Contact #2";
            this.gridColumn4.FieldName = "Contact2";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 100;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Controls.Add(this.btnDelete);
            this.panelControl2.Controls.Add(this.btnSave);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(3, 354);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(743, 44);
            this.panelControl2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(411, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(321, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(231, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctlShipping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "ctlShipping";
            this.Size = new System.Drawing.Size(774, 401);
            this.Load += new System.EventHandler(this.ctlShipping_Load);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdShipping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shipSrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvShipping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //+manual
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        //-

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdShipping;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvShipping;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Data.DataSet dsData;
        private System.Data.DataTable tblData;
        private System.Windows.Forms.BindingSource shipSrc;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}
