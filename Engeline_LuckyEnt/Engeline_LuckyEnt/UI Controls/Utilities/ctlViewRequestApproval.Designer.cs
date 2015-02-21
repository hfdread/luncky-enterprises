namespace Engeline_LuckyEnt.UI_Controls.Utilities
{
   partial class ctlViewRequestApproval
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
         this.dsData = new System.Data.DataSet();
         this.tblData = new System.Data.DataTable();
         this.bSrc = new System.Windows.Forms.BindingSource(this.components);
         this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
         this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
         this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
         this.pnlBody = new DevExpress.XtraEditors.PanelControl();
         this.grdRA = new DevExpress.XtraGrid.GridControl();
         this.grdvRA = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.timer1 = new System.Windows.Forms.Timer(this.components);
         this.btnClose = new DevExpress.XtraEditors.SimpleButton();
         ((System.ComponentModel.ISupportInitialize)(this.dsData)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.tblData)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.bSrc)).BeginInit();
         this.tlpMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
         this.pnlFooter.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
         this.pnlBody.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdRA)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvRA)).BeginInit();
         this.SuspendLayout();
         // 
         // dsData
         // 
         this.dsData.DataSetName = "NewDataSet";
         this.dsData.Tables.AddRange(new System.Data.DataTable[] {
            this.tblData});
         // 
         // tblData
         // 
         this.tblData.TableName = "tblData";
         // 
         // bSrc
         // 
         this.bSrc.DataMember = "tblData";
         this.bSrc.DataSource = this.dsData;
         // 
         // tlpMain
         // 
         this.tlpMain.ColumnCount = 1;
         this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.Controls.Add(this.pnlFooter, 0, 1);
         this.tlpMain.Controls.Add(this.pnlBody, 0, 0);
         this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tlpMain.Location = new System.Drawing.Point(0, 0);
         this.tlpMain.Name = "tlpMain";
         this.tlpMain.RowCount = 2;
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tlpMain.Size = new System.Drawing.Size(542, 366);
         this.tlpMain.TabIndex = 0;
         // 
         // pnlFooter
         // 
         this.pnlFooter.Controls.Add(this.btnClose);
         this.pnlFooter.Controls.Add(this.btnRefresh);
         this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlFooter.Location = new System.Drawing.Point(3, 312);
         this.pnlFooter.Name = "pnlFooter";
         this.pnlFooter.Size = new System.Drawing.Size(536, 51);
         this.pnlFooter.TabIndex = 1;
         // 
         // btnRefresh
         // 
         this.btnRefresh.Location = new System.Drawing.Point(188, 12);
         this.btnRefresh.Name = "btnRefresh";
         this.btnRefresh.Size = new System.Drawing.Size(112, 27);
         this.btnRefresh.TabIndex = 0;
         this.btnRefresh.Text = "&Refresh";
         this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
         // 
         // pnlBody
         // 
         this.pnlBody.Controls.Add(this.grdRA);
         this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlBody.Location = new System.Drawing.Point(3, 3);
         this.pnlBody.Name = "pnlBody";
         this.pnlBody.Size = new System.Drawing.Size(536, 303);
         this.pnlBody.TabIndex = 2;
         // 
         // grdRA
         // 
         this.grdRA.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdRA.Location = new System.Drawing.Point(2, 2);
         this.grdRA.MainView = this.grdvRA;
         this.grdRA.Name = "grdRA";
         this.grdRA.Size = new System.Drawing.Size(532, 299);
         this.grdRA.TabIndex = 3;
         this.grdRA.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvRA});
         this.grdRA.DoubleClick += new System.EventHandler(this.grdRA_DoubleClick);
         // 
         // grdvRA
         // 
         this.grdvRA.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
         this.grdvRA.GridControl = this.grdRA;
         this.grdvRA.Name = "grdvRA";
         this.grdvRA.OptionsBehavior.Editable = false;
         this.grdvRA.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdvRA.OptionsView.ShowGroupPanel = false;
         this.grdvRA.OptionsView.ShowIndicator = false;
         // 
         // gridColumn1
         // 
         this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
         this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.gridColumn1.Caption = "Type";
         this.gridColumn1.FieldName = "RequestType";
         this.gridColumn1.Name = "gridColumn1";
         this.gridColumn1.OptionsColumn.AllowMove = false;
         this.gridColumn1.OptionsColumn.AllowSize = false;
         this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
         this.gridColumn1.OptionsColumn.FixedWidth = true;
         this.gridColumn1.Visible = true;
         this.gridColumn1.VisibleIndex = 0;
         this.gridColumn1.Width = 120;
         // 
         // gridColumn2
         // 
         this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
         this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.gridColumn2.Caption = "Date/Time";
         this.gridColumn2.DisplayFormat.FormatString = "MM/dd/yy HH:mm tt";
         this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
         this.gridColumn2.FieldName = "RequestDate";
         this.gridColumn2.Name = "gridColumn2";
         this.gridColumn2.OptionsColumn.AllowMove = false;
         this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
         this.gridColumn2.OptionsColumn.FixedWidth = true;
         this.gridColumn2.Visible = true;
         this.gridColumn2.VisibleIndex = 1;
         this.gridColumn2.Width = 150;
         // 
         // gridColumn3
         // 
         this.gridColumn3.Caption = "User";
         this.gridColumn3.FieldName = "Sender.UserName";
         this.gridColumn3.Name = "gridColumn3";
         this.gridColumn3.OptionsColumn.AllowMove = false;
         this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
         this.gridColumn3.Visible = true;
         this.gridColumn3.VisibleIndex = 2;
         this.gridColumn3.Width = 188;
         // 
         // gridColumn4
         // 
         this.gridColumn4.Caption = "Terminal";
         this.gridColumn4.FieldName = "Terminal";
         this.gridColumn4.Name = "gridColumn4";
         this.gridColumn4.OptionsColumn.AllowMove = false;
         this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
         this.gridColumn4.OptionsColumn.FixedWidth = true;
         this.gridColumn4.Visible = true;
         this.gridColumn4.VisibleIndex = 3;
         this.gridColumn4.Width = 100;
         // 
         // timer1
         // 
         this.timer1.Interval = 5000;
         this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
         // 
         // btnClose
         // 
         this.btnClose.Location = new System.Drawing.Point(306, 12);
         this.btnClose.Name = "btnClose";
         this.btnClose.Size = new System.Drawing.Size(112, 27);
         this.btnClose.TabIndex = 1;
         this.btnClose.Text = "&Close";
         this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
         // 
         // ctlViewRequestApproval
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tlpMain);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlViewRequestApproval";
         this.Size = new System.Drawing.Size(542, 366);
         this.Load += new System.EventHandler(this.ctlTemplate_Load);
         ((System.ComponentModel.ISupportInitialize)(this.dsData)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.tblData)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.bSrc)).EndInit();
         this.tlpMain.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
         this.pnlFooter.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
         this.pnlBody.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.grdRA)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvRA)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Data.DataSet dsData;
      private System.Data.DataTable tblData;
      private System.Windows.Forms.BindingSource bSrc;
      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private DevExpress.XtraEditors.PanelControl pnlFooter;
      private DevExpress.XtraEditors.SimpleButton btnRefresh;
      private DevExpress.XtraEditors.PanelControl pnlBody;
      private DevExpress.XtraGrid.GridControl grdRA;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvRA;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
      private System.Windows.Forms.Timer timer1;
      private DevExpress.XtraEditors.SimpleButton btnClose;
   }
}
