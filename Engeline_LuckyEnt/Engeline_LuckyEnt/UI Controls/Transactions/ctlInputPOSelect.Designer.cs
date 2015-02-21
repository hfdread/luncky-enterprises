namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
   partial class ctlInputPOSelect
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
          this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
          this.pnlHeader = new System.Windows.Forms.Panel();
          this.cboStatus = new System.Windows.Forms.ComboBox();
          this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
          this.pnlFooter = new System.Windows.Forms.Panel();
          this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
          this.btnOK = new DevExpress.XtraEditors.SimpleButton();
          this.grdPO = new DevExpress.XtraGrid.GridControl();
          this.grdvPO = new DevExpress.XtraGrid.Views.Grid.GridView();
          this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
          this.tlpMain.SuspendLayout();
          this.pnlHeader.SuspendLayout();
          this.pnlFooter.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.grdPO)).BeginInit();
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
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.33813F));
          this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
          this.tlpMain.Size = new System.Drawing.Size(541, 361);
          this.tlpMain.TabIndex = 0;
          // 
          // pnlHeader
          // 
          this.pnlHeader.Controls.Add(this.cboStatus);
          this.pnlHeader.Controls.Add(this.labelControl1);
          this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pnlHeader.Location = new System.Drawing.Point(3, 3);
          this.pnlHeader.Name = "pnlHeader";
          this.pnlHeader.Size = new System.Drawing.Size(535, 31);
          this.pnlHeader.TabIndex = 0;
          // 
          // cboStatus
          // 
          this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cboStatus.FormattingEnabled = true;
          this.cboStatus.Items.AddRange(new object[] {
            "Paid",
            "Unpaid"});
          this.cboStatus.Location = new System.Drawing.Point(66, 7);
          this.cboStatus.Name = "cboStatus";
          this.cboStatus.Size = new System.Drawing.Size(158, 21);
          this.cboStatus.TabIndex = 1;
          this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
          // 
          // labelControl1
          // 
          this.labelControl1.Location = new System.Drawing.Point(8, 10);
          this.labelControl1.Name = "labelControl1";
          this.labelControl1.Size = new System.Drawing.Size(38, 13);
          this.labelControl1.TabIndex = 0;
          this.labelControl1.Text = "STATUS";
          // 
          // pnlFooter
          // 
          this.pnlFooter.Controls.Add(this.btnCancel);
          this.pnlFooter.Controls.Add(this.btnOK);
          this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pnlFooter.Location = new System.Drawing.Point(3, 292);
          this.pnlFooter.Name = "pnlFooter";
          this.pnlFooter.Size = new System.Drawing.Size(535, 66);
          this.pnlFooter.TabIndex = 2;
          // 
          // btnCancel
          // 
          this.btnCancel.Location = new System.Drawing.Point(270, 7);
          this.btnCancel.Name = "btnCancel";
          this.btnCancel.Size = new System.Drawing.Size(85, 29);
          this.btnCancel.TabIndex = 1;
          this.btnCancel.Text = "&Cancel";
          this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
          // 
          // btnOK
          // 
          this.btnOK.Location = new System.Drawing.Point(179, 7);
          this.btnOK.Name = "btnOK";
          this.btnOK.Size = new System.Drawing.Size(85, 29);
          this.btnOK.TabIndex = 0;
          this.btnOK.Text = "&OK";
          this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
          // 
          // grdPO
          // 
          this.grdPO.Dock = System.Windows.Forms.DockStyle.Fill;
          this.grdPO.Location = new System.Drawing.Point(3, 40);
          this.grdPO.MainView = this.grdvPO;
          this.grdPO.Name = "grdPO";
          this.grdPO.Size = new System.Drawing.Size(535, 246);
          this.grdPO.TabIndex = 1;
          this.grdPO.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvPO});
          // 
          // grdvPO
          // 
          this.grdvPO.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn4});
          this.grdvPO.GridControl = this.grdPO;
          this.grdvPO.Name = "grdvPO";
          this.grdvPO.OptionsBehavior.Editable = false;
          this.grdvPO.OptionsBehavior.FocusLeaveOnTab = true;
          this.grdvPO.OptionsSelection.EnableAppearanceFocusedCell = false;
          this.grdvPO.OptionsView.ShowGroupPanel = false;
          this.grdvPO.OptionsView.ShowIndicator = false;
          this.grdvPO.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grdvPO_CustomUnboundColumnData);
          // 
          // gridColumn1
          // 
          this.gridColumn1.Caption = "PO Number";
          this.gridColumn1.DisplayFormat.FormatString = "000000";
          this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
          this.gridColumn1.FieldName = "ID";
          this.gridColumn1.Name = "gridColumn1";
          this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
          this.gridColumn1.OptionsColumn.FixedWidth = true;
          this.gridColumn1.Visible = true;
          this.gridColumn1.VisibleIndex = 0;
          this.gridColumn1.Width = 83;
          // 
          // gridColumn3
          // 
          this.gridColumn3.Caption = "Date";
          this.gridColumn3.DisplayFormat.FormatString = "MMM dd, yyyy";
          this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
          this.gridColumn3.FieldName = "TransactionDate";
          this.gridColumn3.Name = "gridColumn3";
          this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
          this.gridColumn3.OptionsColumn.FixedWidth = true;
          this.gridColumn3.Visible = true;
          this.gridColumn3.VisibleIndex = 2;
          this.gridColumn3.Width = 94;
          // 
          // gridColumn2
          // 
          this.gridColumn2.Caption = "Supplier";
          this.gridColumn2.FieldName = "Supplier";
          this.gridColumn2.Name = "gridColumn2";
          this.gridColumn2.Visible = true;
          this.gridColumn2.VisibleIndex = 1;
          this.gridColumn2.Width = 129;
          // 
          // gridColumn4
          // 
          this.gridColumn4.Caption = "Status";
          this.gridColumn4.FieldName = "Payment";
          this.gridColumn4.Name = "gridColumn4";
          this.gridColumn4.OptionsColumn.AllowSize = false;
          this.gridColumn4.OptionsColumn.FixedWidth = true;
          this.gridColumn4.UnboundType = DevExpress.Data.UnboundColumnType.String;
          this.gridColumn4.Width = 90;
          // 
          // ctlInputPOSelect
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.tlpMain);
          this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.Name = "ctlInputPOSelect";
          this.Size = new System.Drawing.Size(541, 361);
          this.Load += new System.EventHandler(this.ctlInputPOSelect_Load);
          this.tlpMain.ResumeLayout(false);
          this.pnlHeader.ResumeLayout(false);
          this.pnlHeader.PerformLayout();
          this.pnlFooter.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.grdPO)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.grdvPO)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private System.Windows.Forms.Panel pnlHeader;
      private System.Windows.Forms.Panel pnlFooter;
      private DevExpress.XtraGrid.GridControl grdPO;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvPO;
      private System.Windows.Forms.ComboBox cboStatus;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
      private DevExpress.XtraEditors.SimpleButton btnOK;
   }
}
