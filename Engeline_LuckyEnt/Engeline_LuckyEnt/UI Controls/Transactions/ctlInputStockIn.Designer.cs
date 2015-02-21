namespace DexterHardware_v2.UI_Controls.Transactions
{
   partial class ctlInputStockIn
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
         this.pnlMain = new DevExpress.XtraEditors.PanelControl();
         this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
         this.btnOK = new DevExpress.XtraEditors.SimpleButton();
         this.txtPONumber = new DevExpress.XtraEditors.TextEdit();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
         this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
         this.grdResult = new DevExpress.XtraGrid.GridControl();
         this.grdvResult = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
         this.txtxSearchString = new DevExpress.XtraEditors.TextEdit();
         this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
         ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
         this.pnlMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtPONumber.Properties)).BeginInit();
         this.tlpMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
         this.pnlFooter.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvResult)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtxSearchString.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // pnlMain
         // 
         this.pnlMain.Controls.Add(this.btnCancel);
         this.pnlMain.Controls.Add(this.btnOK);
         this.pnlMain.Controls.Add(this.txtPONumber);
         this.pnlMain.Controls.Add(this.labelControl1);
         this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlMain.Location = new System.Drawing.Point(3, 3);
         this.pnlMain.Name = "pnlMain";
         this.pnlMain.Size = new System.Drawing.Size(333, 101);
         this.pnlMain.TabIndex = 0;
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(227, 56);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(100, 33);
         this.btnCancel.TabIndex = 3;
         this.btnCancel.Text = "&Cancel";
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // btnOK
         // 
         this.btnOK.Location = new System.Drawing.Point(121, 56);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(100, 33);
         this.btnOK.TabIndex = 2;
         this.btnOK.Text = "&OK";
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // txtPONumber
         // 
         this.txtPONumber.Location = new System.Drawing.Point(123, 14);
         this.txtPONumber.Name = "txtPONumber";
         this.txtPONumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txtPONumber.Properties.Appearance.Options.UseFont = true;
         this.txtPONumber.Properties.Appearance.Options.UseTextOptions = true;
         this.txtPONumber.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.txtPONumber.Size = new System.Drawing.Size(204, 26);
         this.txtPONumber.TabIndex = 1;
         // 
         // labelControl1
         // 
         this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelControl1.Appearance.Options.UseFont = true;
         this.labelControl1.Location = new System.Drawing.Point(5, 17);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(102, 16);
         this.labelControl1.TabIndex = 0;
         this.labelControl1.Text = "StockIn Number";
         // 
         // tlpMain
         // 
         this.tlpMain.ColumnCount = 1;
         this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tlpMain.Controls.Add(this.pnlMain, 0, 0);
         this.tlpMain.Controls.Add(this.pnlFooter, 0, 1);
         this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tlpMain.Location = new System.Drawing.Point(0, 0);
         this.tlpMain.Name = "tlpMain";
         this.tlpMain.RowCount = 2;
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 107F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tlpMain.Size = new System.Drawing.Size(339, 317);
         this.tlpMain.TabIndex = 0;
         // 
         // pnlFooter
         // 
         this.pnlFooter.Controls.Add(this.grdResult);
         this.pnlFooter.Controls.Add(this.btnSearch);
         this.pnlFooter.Controls.Add(this.txtxSearchString);
         this.pnlFooter.Controls.Add(this.labelControl3);
         this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlFooter.Location = new System.Drawing.Point(3, 110);
         this.pnlFooter.Name = "pnlFooter";
         this.pnlFooter.Size = new System.Drawing.Size(333, 204);
         this.pnlFooter.TabIndex = 1;
         // 
         // grdResult
         // 
         this.grdResult.Location = new System.Drawing.Point(2, 35);
         this.grdResult.MainView = this.grdvResult;
         this.grdResult.Name = "grdResult";
         this.grdResult.Size = new System.Drawing.Size(329, 162);
         this.grdResult.TabIndex = 5;
         this.grdResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvResult});
         // 
         // grdvResult
         // 
         this.grdvResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
         this.grdvResult.GridControl = this.grdResult;
         this.grdvResult.Name = "grdvResult";
         this.grdvResult.OptionsBehavior.Editable = false;
         this.grdvResult.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdvResult.OptionsView.ShowGroupPanel = false;
         this.grdvResult.OptionsView.ShowIndicator = false;
         this.grdvResult.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grdvResult_SelectionChanged);
         // 
         // gridColumn1
         // 
         this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
         this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
         this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.gridColumn1.Caption = "SI No.";
         this.gridColumn1.DisplayFormat.FormatString = "000000";
         this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.gridColumn1.FieldName = "ID";
         this.gridColumn1.Name = "gridColumn1";
         this.gridColumn1.OptionsColumn.FixedWidth = true;
         this.gridColumn1.Visible = true;
         this.gridColumn1.VisibleIndex = 0;
         // 
         // gridColumn2
         // 
         this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
         this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.gridColumn2.Caption = "Supplier";
         this.gridColumn2.FieldName = "purchaseorder.Supplier";
         this.gridColumn2.Name = "gridColumn2";
         this.gridColumn2.Visible = true;
         this.gridColumn2.VisibleIndex = 1;
         this.gridColumn2.Width = 168;
         // 
         // gridColumn3
         // 
         this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
         this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
         this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.gridColumn3.Caption = "Date";
         this.gridColumn3.DisplayFormat.FormatString = "MM/dd/yy";
         this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
         this.gridColumn3.FieldName = "StockInDate";
         this.gridColumn3.Name = "gridColumn3";
         this.gridColumn3.OptionsColumn.FixedWidth = true;
         this.gridColumn3.Visible = true;
         this.gridColumn3.VisibleIndex = 2;
         this.gridColumn3.Width = 80;
         // 
         // btnSearch
         // 
         this.btnSearch.Location = new System.Drawing.Point(251, 9);
         this.btnSearch.Name = "btnSearch";
         this.btnSearch.Size = new System.Drawing.Size(76, 20);
         this.btnSearch.TabIndex = 4;
         this.btnSearch.Text = "Search";
         this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
         // 
         // txtxSearchString
         // 
         this.txtxSearchString.Location = new System.Drawing.Point(75, 9);
         this.txtxSearchString.Name = "txtxSearchString";
         this.txtxSearchString.Size = new System.Drawing.Size(170, 20);
         this.txtxSearchString.TabIndex = 3;
         // 
         // labelControl3
         // 
         this.labelControl3.Location = new System.Drawing.Point(5, 12);
         this.labelControl3.Name = "labelControl3";
         this.labelControl3.Size = new System.Drawing.Size(58, 13);
         this.labelControl3.TabIndex = 2;
         this.labelControl3.Text = "Search Item";
         // 
         // ctlInputStockIn
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tlpMain);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlInputStockIn";
         this.Size = new System.Drawing.Size(339, 317);
         this.Load += new System.EventHandler(this.ctlInputStockIn_Load);
         ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
         this.pnlMain.ResumeLayout(false);
         this.pnlMain.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtPONumber.Properties)).EndInit();
         this.tlpMain.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
         this.pnlFooter.ResumeLayout(false);
         this.pnlFooter.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvResult)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtxSearchString.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.PanelControl pnlMain;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
      private DevExpress.XtraEditors.SimpleButton btnOK;
      private DevExpress.XtraEditors.TextEdit txtPONumber;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private DevExpress.XtraEditors.PanelControl pnlFooter;
      private DevExpress.XtraEditors.TextEdit txtxSearchString;
      private DevExpress.XtraEditors.LabelControl labelControl3;
      private DevExpress.XtraEditors.SimpleButton btnSearch;
      private DevExpress.XtraGrid.GridControl grdResult;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvResult;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
   }
}
