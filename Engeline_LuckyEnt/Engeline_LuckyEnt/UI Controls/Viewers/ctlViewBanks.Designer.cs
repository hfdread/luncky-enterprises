namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
   partial class ctlViewBanks
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
          this.bSrc = new System.Windows.Forms.BindingSource(this.components);
          this.dsData = new System.Data.DataSet();
          this.tblData = new System.Data.DataTable();
          this.dataColumn1 = new System.Data.DataColumn();
          this.dataColumn2 = new System.Data.DataColumn();
          this.dataColumn3 = new System.Data.DataColumn();
          this.dataColumn4 = new System.Data.DataColumn();
          this.grdBanks = new DevExpress.XtraGrid.GridControl();
          this.grdvBanks = new DevExpress.XtraGrid.Views.Grid.GridView();
          this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
          this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
          this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
          this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
          this.colDirty = new DevExpress.XtraGrid.Columns.GridColumn();
          this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
          this.btnSave = new DevExpress.XtraEditors.SimpleButton();
          this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
          this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
          ((System.ComponentModel.ISupportInitialize)(this.bSrc)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.dsData)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.tblData)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.grdBanks)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.grdvBanks)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
          this.pnlFooter.SuspendLayout();
          this.tlpMain.SuspendLayout();
          this.SuspendLayout();
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
            this.dataColumn4});
          this.tblData.TableName = "tblData";
          // 
          // dataColumn1
          // 
          this.dataColumn1.ColumnName = "ID";
          this.dataColumn1.DataType = typeof(int);
          // 
          // dataColumn2
          // 
          this.dataColumn2.ColumnName = "Name";
          // 
          // dataColumn3
          // 
          this.dataColumn3.ColumnName = "Description";
          // 
          // dataColumn4
          // 
          this.dataColumn4.ColumnName = "Dirty";
          this.dataColumn4.DataType = typeof(bool);
          // 
          // grdBanks
          // 
          this.grdBanks.DataSource = this.bSrc;
          this.grdBanks.Dock = System.Windows.Forms.DockStyle.Fill;
          this.grdBanks.Location = new System.Drawing.Point(3, 3);
          this.grdBanks.MainView = this.grdvBanks;
          this.grdBanks.Name = "grdBanks";
          this.grdBanks.Size = new System.Drawing.Size(382, 335);
          this.grdBanks.TabIndex = 1;
          this.grdBanks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvBanks,
            this.gridView1});
          // 
          // grdvBanks
          // 
          this.grdvBanks.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
          this.grdvBanks.GridControl = this.grdBanks;
          this.grdvBanks.Name = "grdvBanks";
          this.grdvBanks.OptionsView.EnableAppearanceEvenRow = true;
          this.grdvBanks.OptionsView.EnableAppearanceOddRow = true;
          this.grdvBanks.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
          this.grdvBanks.OptionsView.ShowGroupPanel = false;
          this.grdvBanks.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdvBanks_InitNewRow);
          this.grdvBanks.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdvBanks_CellValueChanged);
          this.grdvBanks.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grdvBanks_ValidateRow);
          // 
          // gridColumn1
          // 
          this.gridColumn1.Caption = "ID";
          this.gridColumn1.FieldName = "ID";
          this.gridColumn1.Name = "gridColumn1";
          // 
          // gridColumn2
          // 
          this.gridColumn2.Caption = "Name";
          this.gridColumn2.FieldName = "Name";
          this.gridColumn2.Name = "gridColumn2";
          this.gridColumn2.Visible = true;
          this.gridColumn2.VisibleIndex = 0;
          this.gridColumn2.Width = 259;
          // 
          // gridColumn3
          // 
          this.gridColumn3.Caption = "Short Description";
          this.gridColumn3.FieldName = "Description";
          this.gridColumn3.Name = "gridColumn3";
          this.gridColumn3.OptionsColumn.FixedWidth = true;
          this.gridColumn3.Visible = true;
          this.gridColumn3.VisibleIndex = 1;
          this.gridColumn3.Width = 120;
          // 
          // gridView1
          // 
          this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colName,
            this.colDescription,
            this.colDirty});
          this.gridView1.GridControl = this.grdBanks;
          this.gridView1.Name = "gridView1";
          // 
          // colID
          // 
          this.colID.FieldName = "ID";
          this.colID.Name = "colID";
          this.colID.Visible = true;
          this.colID.VisibleIndex = 0;
          // 
          // colName
          // 
          this.colName.FieldName = "Name";
          this.colName.Name = "colName";
          this.colName.Visible = true;
          this.colName.VisibleIndex = 1;
          // 
          // colDescription
          // 
          this.colDescription.FieldName = "Description";
          this.colDescription.Name = "colDescription";
          this.colDescription.Visible = true;
          this.colDescription.VisibleIndex = 2;
          // 
          // colDirty
          // 
          this.colDirty.FieldName = "Dirty";
          this.colDirty.Name = "colDirty";
          this.colDirty.Visible = true;
          this.colDirty.VisibleIndex = 3;
          // 
          // pnlFooter
          // 
          this.pnlFooter.Controls.Add(this.btnDelete);
          this.pnlFooter.Controls.Add(this.btnSave);
          this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pnlFooter.Location = new System.Drawing.Point(3, 344);
          this.pnlFooter.Name = "pnlFooter";
          this.pnlFooter.Size = new System.Drawing.Size(382, 46);
          this.pnlFooter.TabIndex = 0;
          // 
          // btnSave
          // 
          this.btnSave.Location = new System.Drawing.Point(75, 11);
          this.btnSave.Name = "btnSave";
          this.btnSave.Size = new System.Drawing.Size(111, 25);
          this.btnSave.TabIndex = 0;
          this.btnSave.Text = "&Save";
          this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
          // 
          // tlpMain
          // 
          this.tlpMain.ColumnCount = 2;
          this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 388F));
          this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
          this.tlpMain.Controls.Add(this.pnlFooter, 0, 1);
          this.tlpMain.Controls.Add(this.grdBanks, 0, 0);
          this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
          this.tlpMain.Location = new System.Drawing.Point(0, 0);
          this.tlpMain.Name = "tlpMain";
          this.tlpMain.RowCount = 2;
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
          this.tlpMain.Size = new System.Drawing.Size(410, 393);
          this.tlpMain.TabIndex = 0;
          // 
          // btnDelete
          // 
          this.btnDelete.Location = new System.Drawing.Point(205, 11);
          this.btnDelete.Name = "btnDelete";
          this.btnDelete.Size = new System.Drawing.Size(111, 25);
          this.btnDelete.TabIndex = 1;
          this.btnDelete.Text = "&Delete";
          this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
          // 
          // ctlViewBanks
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.tlpMain);
          this.Name = "ctlViewBanks";
          this.Size = new System.Drawing.Size(410, 393);
          this.Load += new System.EventHandler(this.ctlViewBanks_Load);
          ((System.ComponentModel.ISupportInitialize)(this.bSrc)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.dsData)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.tblData)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.grdBanks)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.grdvBanks)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
          this.pnlFooter.ResumeLayout(false);
          this.tlpMain.ResumeLayout(false);
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.BindingSource bSrc;
      private System.Data.DataSet dsData;
      private System.Data.DataTable tblData;
      private System.Data.DataColumn dataColumn1;
      private System.Data.DataColumn dataColumn2;
      private System.Data.DataColumn dataColumn3;
      private System.Data.DataColumn dataColumn4;
      private DevExpress.XtraGrid.GridControl grdBanks;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvBanks;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
      private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
      private DevExpress.XtraGrid.Columns.GridColumn colID;
      private DevExpress.XtraGrid.Columns.GridColumn colName;
      private DevExpress.XtraGrid.Columns.GridColumn colDescription;
      private DevExpress.XtraGrid.Columns.GridColumn colDirty;
      private DevExpress.XtraEditors.PanelControl pnlFooter;
      private DevExpress.XtraEditors.SimpleButton btnSave;
      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private DevExpress.XtraEditors.SimpleButton btnDelete;
   }
}
