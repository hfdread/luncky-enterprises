namespace DexterHardware_v2.UI_Controls.Accounting
{
   partial class ctlCounterSelectInvoice
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
         this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
         this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
         this.btnGetInvoices = new DevExpress.XtraEditors.SimpleButton();
         this.cboDay = new DevExpress.XtraEditors.ComboBoxEdit();
         this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
         this.cboMonth = new DevExpress.XtraEditors.ComboBoxEdit();
         this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
         this.cboYear = new DevExpress.XtraEditors.ComboBoxEdit();
         this.cboCustomer = new DevExpress.XtraEditors.ComboBoxEdit();
         this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
         this.chkSelectAll = new DevExpress.XtraEditors.CheckEdit();
         this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
         this.btnCreateCounter = new DevExpress.XtraEditors.SimpleButton();
         this.grdInvoices = new DevExpress.XtraGrid.GridControl();
         this.grdvInvoices = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.repoCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
         this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.tlpMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
         this.pnlHeader.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboDay.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboMonth.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboYear.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboCustomer.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
         this.pnlFooter.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.chkSelectAll.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdInvoices)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvInvoices)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoCheck)).BeginInit();
         this.SuspendLayout();
         // 
         // tlpMain
         // 
         this.tlpMain.ColumnCount = 1;
         this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
         this.tlpMain.Controls.Add(this.pnlFooter, 0, 2);
         this.tlpMain.Controls.Add(this.grdInvoices, 0, 1);
         this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tlpMain.Location = new System.Drawing.Point(0, 0);
         this.tlpMain.Name = "tlpMain";
         this.tlpMain.RowCount = 3;
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
         this.tlpMain.Size = new System.Drawing.Size(640, 527);
         this.tlpMain.TabIndex = 0;
         // 
         // pnlHeader
         // 
         this.pnlHeader.Controls.Add(this.labelControl5);
         this.pnlHeader.Controls.Add(this.btnGetInvoices);
         this.pnlHeader.Controls.Add(this.cboDay);
         this.pnlHeader.Controls.Add(this.labelControl4);
         this.pnlHeader.Controls.Add(this.cboMonth);
         this.pnlHeader.Controls.Add(this.labelControl3);
         this.pnlHeader.Controls.Add(this.cboYear);
         this.pnlHeader.Controls.Add(this.cboCustomer);
         this.pnlHeader.Controls.Add(this.labelControl2);
         this.pnlHeader.Controls.Add(this.labelControl1);
         this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlHeader.Location = new System.Drawing.Point(3, 3);
         this.pnlHeader.Name = "pnlHeader";
         this.pnlHeader.Size = new System.Drawing.Size(634, 98);
         this.pnlHeader.TabIndex = 0;
         // 
         // labelControl5
         // 
         this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelControl5.Appearance.Options.UseFont = true;
         this.labelControl5.Location = new System.Drawing.Point(12, 31);
         this.labelControl5.Name = "labelControl5";
         this.labelControl5.Size = new System.Drawing.Size(57, 14);
         this.labelControl5.TabIndex = 9;
         this.labelControl5.Text = "Due Date";
         // 
         // btnGetInvoices
         // 
         this.btnGetInvoices.Location = new System.Drawing.Point(269, 70);
         this.btnGetInvoices.Name = "btnGetInvoices";
         this.btnGetInvoices.Size = new System.Drawing.Size(93, 20);
         this.btnGetInvoices.TabIndex = 8;
         this.btnGetInvoices.Text = "&Get Invoices";
         this.btnGetInvoices.Click += new System.EventHandler(this.btnGetInvoices_Click);
         // 
         // cboDay
         // 
         this.cboDay.Location = new System.Drawing.Point(182, 70);
         this.cboDay.Name = "cboDay";
         this.cboDay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboDay.Size = new System.Drawing.Size(64, 20);
         this.cboDay.TabIndex = 7;
         // 
         // labelControl4
         // 
         this.labelControl4.Appearance.ForeColor = System.Drawing.Color.DimGray;
         this.labelControl4.Appearance.Options.UseForeColor = true;
         this.labelControl4.Location = new System.Drawing.Point(182, 51);
         this.labelControl4.Name = "labelControl4";
         this.labelControl4.Size = new System.Drawing.Size(19, 13);
         this.labelControl4.TabIndex = 6;
         this.labelControl4.Text = "&Day";
         // 
         // cboMonth
         // 
         this.cboMonth.Location = new System.Drawing.Point(82, 70);
         this.cboMonth.Name = "cboMonth";
         this.cboMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboMonth.Size = new System.Drawing.Size(94, 20);
         this.cboMonth.TabIndex = 5;
         this.cboMonth.SelectedIndexChanged += new System.EventHandler(this.cboMonth_SelectedIndexChanged);
         // 
         // labelControl3
         // 
         this.labelControl3.Appearance.ForeColor = System.Drawing.Color.DimGray;
         this.labelControl3.Appearance.Options.UseForeColor = true;
         this.labelControl3.Location = new System.Drawing.Point(82, 51);
         this.labelControl3.Name = "labelControl3";
         this.labelControl3.Size = new System.Drawing.Size(30, 13);
         this.labelControl3.TabIndex = 4;
         this.labelControl3.Text = "&Month";
         // 
         // cboYear
         // 
         this.cboYear.Location = new System.Drawing.Point(12, 70);
         this.cboYear.Name = "cboYear";
         this.cboYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboYear.Size = new System.Drawing.Size(64, 20);
         this.cboYear.TabIndex = 3;
         this.cboYear.SelectedIndexChanged += new System.EventHandler(this.cboYear_SelectedIndexChanged);
         // 
         // cboCustomer
         // 
         this.cboCustomer.Location = new System.Drawing.Point(64, 5);
         this.cboCustomer.Name = "cboCustomer";
         this.cboCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboCustomer.Size = new System.Drawing.Size(298, 20);
         this.cboCustomer.TabIndex = 1;
         // 
         // labelControl2
         // 
         this.labelControl2.Appearance.ForeColor = System.Drawing.Color.DimGray;
         this.labelControl2.Appearance.Options.UseForeColor = true;
         this.labelControl2.Location = new System.Drawing.Point(12, 8);
         this.labelControl2.Name = "labelControl2";
         this.labelControl2.Size = new System.Drawing.Size(46, 13);
         this.labelControl2.TabIndex = 0;
         this.labelControl2.Text = "&Customer";
         // 
         // labelControl1
         // 
         this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DimGray;
         this.labelControl1.Appearance.Options.UseForeColor = true;
         this.labelControl1.Location = new System.Drawing.Point(12, 51);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(22, 13);
         this.labelControl1.TabIndex = 2;
         this.labelControl1.Text = "&Year";
         // 
         // pnlFooter
         // 
         this.pnlFooter.Controls.Add(this.chkSelectAll);
         this.pnlFooter.Controls.Add(this.btnCancel);
         this.pnlFooter.Controls.Add(this.btnCreateCounter);
         this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlFooter.Location = new System.Drawing.Point(3, 488);
         this.pnlFooter.Name = "pnlFooter";
         this.pnlFooter.Size = new System.Drawing.Size(634, 36);
         this.pnlFooter.TabIndex = 2;
         // 
         // chkSelectAll
         // 
         this.chkSelectAll.Location = new System.Drawing.Point(10, 9);
         this.chkSelectAll.Name = "chkSelectAll";
         this.chkSelectAll.Properties.Caption = "&Select All";
         this.chkSelectAll.Size = new System.Drawing.Size(126, 19);
         this.chkSelectAll.TabIndex = 0;
         this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(320, 6);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(93, 25);
         this.btnCancel.TabIndex = 2;
         this.btnCancel.Text = "C&ancel";
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // btnCreateCounter
         // 
         this.btnCreateCounter.Location = new System.Drawing.Point(221, 6);
         this.btnCreateCounter.Name = "btnCreateCounter";
         this.btnCreateCounter.Size = new System.Drawing.Size(93, 25);
         this.btnCreateCounter.TabIndex = 1;
         this.btnCreateCounter.Text = "&Create Counter";
         this.btnCreateCounter.Click += new System.EventHandler(this.btnCreateCounter_Click);
         // 
         // grdInvoices
         // 
         this.grdInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
         this.grdInvoices.Location = new System.Drawing.Point(3, 107);
         this.grdInvoices.MainView = this.grdvInvoices;
         this.grdInvoices.Name = "grdInvoices";
         this.grdInvoices.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoCheck});
         this.grdInvoices.Size = new System.Drawing.Size(634, 375);
         this.grdInvoices.TabIndex = 1;
         this.grdInvoices.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvInvoices});
         // 
         // grdvInvoices
         // 
         this.grdvInvoices.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn6,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn7});
         this.grdvInvoices.GridControl = this.grdInvoices;
         this.grdvInvoices.Name = "grdvInvoices";
         this.grdvInvoices.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdvInvoices.OptionsView.EnableAppearanceEvenRow = true;
         this.grdvInvoices.OptionsView.EnableAppearanceOddRow = true;
         this.grdvInvoices.OptionsView.ShowGroupPanel = false;
         this.grdvInvoices.OptionsView.ShowIndicator = false;
         this.grdvInvoices.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grdvInvoices_CustomUnboundColumnData);
         // 
         // gridColumn1
         // 
         this.gridColumn1.Caption = " ";
         this.gridColumn1.ColumnEdit = this.repoCheck;
         this.gridColumn1.FieldName = "Selected";
         this.gridColumn1.Name = "gridColumn1";
         this.gridColumn1.OptionsColumn.AllowMove = false;
         this.gridColumn1.OptionsColumn.FixedWidth = true;
         this.gridColumn1.Visible = true;
         this.gridColumn1.VisibleIndex = 0;
         this.gridColumn1.Width = 25;
         // 
         // repoCheck
         // 
         this.repoCheck.AutoHeight = false;
         this.repoCheck.Name = "repoCheck";
         // 
         // gridColumn6
         // 
         this.gridColumn6.Caption = "Customer";
         this.gridColumn6.FieldName = "Customer";
         this.gridColumn6.Name = "gridColumn6";
         this.gridColumn6.OptionsColumn.AllowEdit = false;
         this.gridColumn6.Visible = true;
         this.gridColumn6.VisibleIndex = 1;
         this.gridColumn6.Width = 172;
         // 
         // gridColumn2
         // 
         this.gridColumn2.Caption = "Invoice #";
         this.gridColumn2.DisplayFormat.FormatString = "000000";
         this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.gridColumn2.FieldName = "ID";
         this.gridColumn2.Name = "gridColumn2";
         this.gridColumn2.OptionsColumn.AllowEdit = false;
         this.gridColumn2.OptionsColumn.AllowMove = false;
         this.gridColumn2.OptionsColumn.FixedWidth = true;
         this.gridColumn2.Visible = true;
         this.gridColumn2.VisibleIndex = 2;
         this.gridColumn2.Width = 85;
         // 
         // gridColumn3
         // 
         this.gridColumn3.Caption = "Date";
         this.gridColumn3.DisplayFormat.FormatString = "MM/dd/yyyy";
         this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
         this.gridColumn3.FieldName = "InvoiceDate";
         this.gridColumn3.Name = "gridColumn3";
         this.gridColumn3.OptionsColumn.AllowEdit = false;
         this.gridColumn3.OptionsColumn.AllowMove = false;
         this.gridColumn3.OptionsColumn.FixedWidth = true;
         this.gridColumn3.Visible = true;
         this.gridColumn3.VisibleIndex = 3;
         this.gridColumn3.Width = 72;
         // 
         // gridColumn4
         // 
         this.gridColumn4.Caption = "Due Date";
         this.gridColumn4.DisplayFormat.FormatString = "MM/dd/yyyy";
         this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
         this.gridColumn4.FieldName = "duedate";
         this.gridColumn4.Name = "gridColumn4";
         this.gridColumn4.OptionsColumn.AllowEdit = false;
         this.gridColumn4.OptionsColumn.AllowMove = false;
         this.gridColumn4.OptionsColumn.FixedWidth = true;
         this.gridColumn4.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
         this.gridColumn4.Visible = true;
         this.gridColumn4.VisibleIndex = 4;
         this.gridColumn4.Width = 72;
         // 
         // gridColumn5
         // 
         this.gridColumn5.Caption = "Amount";
         this.gridColumn5.DisplayFormat.FormatString = "{0:N2}";
         this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.gridColumn5.FieldName = "AmountDue";
         this.gridColumn5.Name = "gridColumn5";
         this.gridColumn5.OptionsColumn.AllowEdit = false;
         this.gridColumn5.OptionsColumn.AllowMove = false;
         this.gridColumn5.OptionsColumn.FixedWidth = true;
         this.gridColumn5.Visible = true;
         this.gridColumn5.VisibleIndex = 5;
         this.gridColumn5.Width = 80;
         // 
         // gridColumn7
         // 
         this.gridColumn7.Caption = "Status";
         this.gridColumn7.FieldName = "invoicestatus";
         this.gridColumn7.Name = "gridColumn7";
         this.gridColumn7.OptionsColumn.AllowEdit = false;
         this.gridColumn7.OptionsColumn.FixedWidth = true;
         this.gridColumn7.UnboundType = DevExpress.Data.UnboundColumnType.String;
         this.gridColumn7.Visible = true;
         this.gridColumn7.VisibleIndex = 6;
         this.gridColumn7.Width = 85;
         // 
         // ctlCounterSelectInvoice
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tlpMain);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlCounterSelectInvoice";
         this.Size = new System.Drawing.Size(640, 527);
         this.Load += new System.EventHandler(this.ctlCounterSelectInvoice_Load);
         this.tlpMain.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
         this.pnlHeader.ResumeLayout(false);
         this.pnlHeader.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboDay.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboMonth.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboYear.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboCustomer.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
         this.pnlFooter.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.chkSelectAll.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdInvoices)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvInvoices)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repoCheck)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private DevExpress.XtraEditors.PanelControl pnlHeader;
      private DevExpress.XtraEditors.PanelControl pnlFooter;
      private DevExpress.XtraEditors.ComboBoxEdit cboDay;
      private DevExpress.XtraEditors.LabelControl labelControl4;
      private DevExpress.XtraEditors.ComboBoxEdit cboMonth;
      private DevExpress.XtraEditors.LabelControl labelControl3;
      private DevExpress.XtraEditors.ComboBoxEdit cboYear;
      private DevExpress.XtraEditors.ComboBoxEdit cboCustomer;
      private DevExpress.XtraEditors.LabelControl labelControl2;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraGrid.GridControl grdInvoices;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvInvoices;
      private DevExpress.XtraEditors.SimpleButton btnGetInvoices;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
      private DevExpress.XtraEditors.SimpleButton btnCreateCounter;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
      private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repoCheck;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
      private DevExpress.XtraEditors.LabelControl labelControl5;
      private DevExpress.XtraEditors.CheckEdit chkSelectAll;
   }
}
