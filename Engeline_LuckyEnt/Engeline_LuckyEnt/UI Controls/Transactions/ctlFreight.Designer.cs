namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
   partial class ctlFreight
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
         this.pnlBody = new DevExpress.XtraEditors.PanelControl();
         this.txtFreightPercent = new DevExpress.XtraEditors.TextEdit();
         this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
         this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
         this.btnSave = new DevExpress.XtraEditors.SimpleButton();
         this.grdSI = new DevExpress.XtraGrid.GridControl();
         this.grdvSI = new DevExpress.XtraGrid.Views.Grid.GridView();
         this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.repCheckBox = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
         this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
         this.txtSIAmount = new DevExpress.XtraEditors.TextEdit();
         this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
         this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
         this.txtFreightAmount = new DevExpress.XtraEditors.TextEdit();
         this.lblFreightID = new DevExpress.XtraEditors.LabelControl();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
         this.pnlBody.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtFreightPercent.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdSI)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvSI)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.repCheckBox)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtSIAmount.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtFreightAmount.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // pnlBody
         // 
         this.pnlBody.Controls.Add(this.txtFreightPercent);
         this.pnlBody.Controls.Add(this.labelControl4);
         this.pnlBody.Controls.Add(this.btnCancel);
         this.pnlBody.Controls.Add(this.btnSave);
         this.pnlBody.Controls.Add(this.grdSI);
         this.pnlBody.Controls.Add(this.txtSIAmount);
         this.pnlBody.Controls.Add(this.labelControl3);
         this.pnlBody.Controls.Add(this.labelControl2);
         this.pnlBody.Controls.Add(this.txtFreightAmount);
         this.pnlBody.Controls.Add(this.lblFreightID);
         this.pnlBody.Controls.Add(this.labelControl1);
         this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlBody.Location = new System.Drawing.Point(0, 0);
         this.pnlBody.Name = "pnlBody";
         this.pnlBody.Size = new System.Drawing.Size(391, 339);
         this.pnlBody.TabIndex = 0;
         // 
         // txtFreightPercent
         // 
         this.txtFreightPercent.Location = new System.Drawing.Point(252, 72);
         this.txtFreightPercent.Name = "txtFreightPercent";
         this.txtFreightPercent.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txtFreightPercent.Properties.Appearance.Options.UseFont = true;
         this.txtFreightPercent.Properties.Appearance.Options.UseTextOptions = true;
         this.txtFreightPercent.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.txtFreightPercent.Size = new System.Drawing.Size(49, 20);
         this.txtFreightPercent.TabIndex = 10;
         // 
         // labelControl4
         // 
         this.labelControl4.Location = new System.Drawing.Point(198, 75);
         this.labelControl4.Name = "labelControl4";
         this.labelControl4.Size = new System.Drawing.Size(48, 13);
         this.labelControl4.TabIndex = 9;
         this.labelControl4.Text = "Freight %";
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(198, 272);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(86, 30);
         this.btnCancel.TabIndex = 8;
         this.btnCancel.Text = "&Cancel";
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // btnSave
         // 
         this.btnSave.Location = new System.Drawing.Point(106, 272);
         this.btnSave.Name = "btnSave";
         this.btnSave.Size = new System.Drawing.Size(86, 30);
         this.btnSave.TabIndex = 7;
         this.btnSave.Text = "&Save";
         this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
         // 
         // grdSI
         // 
         this.grdSI.Location = new System.Drawing.Point(5, 98);
         this.grdSI.MainView = this.grdvSI;
         this.grdSI.Name = "grdSI";
         this.grdSI.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCheckBox});
         this.grdSI.Size = new System.Drawing.Size(381, 168);
         this.grdSI.TabIndex = 6;
         this.grdSI.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvSI});
         // 
         // grdvSI
         // 
         this.grdvSI.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn3});
         this.grdvSI.GridControl = this.grdSI;
         this.grdvSI.Name = "grdvSI";
         this.grdvSI.OptionsBehavior.FocusLeaveOnTab = true;
         this.grdvSI.OptionsSelection.EnableAppearanceFocusedCell = false;
         this.grdvSI.OptionsSelection.EnableAppearanceFocusedRow = false;
         this.grdvSI.OptionsSelection.EnableAppearanceHideSelection = false;
         this.grdvSI.OptionsView.ShowGroupPanel = false;
         this.grdvSI.OptionsView.ShowIndicator = false;
         this.grdvSI.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdvSI_CellValueChanged);
         this.grdvSI.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.grdvSI_RowUpdated);
         // 
         // gridColumn1
         // 
         this.gridColumn1.Caption = " ";
         this.gridColumn1.ColumnEdit = this.repCheckBox;
         this.gridColumn1.FieldName = "Selected";
         this.gridColumn1.Name = "gridColumn1";
         this.gridColumn1.OptionsColumn.AllowSize = false;
         this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
         this.gridColumn1.OptionsColumn.FixedWidth = true;
         this.gridColumn1.Visible = true;
         this.gridColumn1.VisibleIndex = 0;
         this.gridColumn1.Width = 25;
         // 
         // repCheckBox
         // 
         this.repCheckBox.AutoHeight = false;
         this.repCheckBox.Name = "repCheckBox";
         this.repCheckBox.EditValueChanged += new System.EventHandler(this.repCheckBox_EditValueChanged);
         // 
         // gridColumn2
         // 
         this.gridColumn2.Caption = "Stock In No.";
         this.gridColumn2.DisplayFormat.FormatString = "000000";
         this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.gridColumn2.FieldName = "ID";
         this.gridColumn2.Name = "gridColumn2";
         this.gridColumn2.OptionsColumn.AllowEdit = false;
         this.gridColumn2.OptionsColumn.AllowSize = false;
         this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
         this.gridColumn2.OptionsColumn.FixedWidth = true;
         this.gridColumn2.Visible = true;
         this.gridColumn2.VisibleIndex = 1;
         this.gridColumn2.Width = 80;
         // 
         // gridColumn4
         // 
         this.gridColumn4.Caption = "Supplier";
         this.gridColumn4.FieldName = "purchaseorder.Supplier";
         this.gridColumn4.Name = "gridColumn4";
         this.gridColumn4.OptionsColumn.AllowEdit = false;
         this.gridColumn4.Visible = true;
         this.gridColumn4.VisibleIndex = 2;
         this.gridColumn4.Width = 56;
         // 
         // gridColumn3
         // 
         this.gridColumn3.Caption = "Amount";
         this.gridColumn3.DisplayFormat.FormatString = "{0:N2}";
         this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.gridColumn3.FieldName = "AmountDue";
         this.gridColumn3.Name = "gridColumn3";
         this.gridColumn3.OptionsColumn.AllowEdit = false;
         this.gridColumn3.OptionsColumn.FixedWidth = true;
         this.gridColumn3.Visible = true;
         this.gridColumn3.VisibleIndex = 3;
         this.gridColumn3.Width = 100;
         // 
         // txtSIAmount
         // 
         this.txtSIAmount.Location = new System.Drawing.Point(87, 72);
         this.txtSIAmount.Name = "txtSIAmount";
         this.txtSIAmount.Size = new System.Drawing.Size(84, 20);
         this.txtSIAmount.TabIndex = 5;
         // 
         // labelControl3
         // 
         this.labelControl3.Location = new System.Drawing.Point(5, 75);
         this.labelControl3.Name = "labelControl3";
         this.labelControl3.Size = new System.Drawing.Size(76, 13);
         this.labelControl3.TabIndex = 4;
         this.labelControl3.Text = "StockIn Amount";
         // 
         // labelControl2
         // 
         this.labelControl2.Location = new System.Drawing.Point(5, 48);
         this.labelControl2.Name = "labelControl2";
         this.labelControl2.Size = new System.Drawing.Size(74, 13);
         this.labelControl2.TabIndex = 3;
         this.labelControl2.Text = "Freight Amount";
         // 
         // txtFreightAmount
         // 
         this.txtFreightAmount.Location = new System.Drawing.Point(87, 43);
         this.txtFreightAmount.Name = "txtFreightAmount";
         this.txtFreightAmount.Size = new System.Drawing.Size(84, 20);
         this.txtFreightAmount.TabIndex = 2;
         this.txtFreightAmount.EditValueChanged += new System.EventHandler(this.txtFreightAmount_EditValueChanged);
         // 
         // lblFreightID
         // 
         this.lblFreightID.Appearance.BackColor = System.Drawing.Color.White;
         this.lblFreightID.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblFreightID.Appearance.Options.UseBackColor = true;
         this.lblFreightID.Appearance.Options.UseFont = true;
         this.lblFreightID.Appearance.Options.UseTextOptions = true;
         this.lblFreightID.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.lblFreightID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
         this.lblFreightID.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
         this.lblFreightID.Location = new System.Drawing.Point(87, 15);
         this.lblFreightID.Name = "lblFreightID";
         this.lblFreightID.Size = new System.Drawing.Size(52, 22);
         this.lblFreightID.TabIndex = 1;
         this.lblFreightID.Text = "000";
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(5, 20);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(48, 13);
         this.labelControl1.TabIndex = 0;
         this.labelControl1.Text = "Freight ID";
         // 
         // ctlFreight
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.pnlBody);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlFreight";
         this.Size = new System.Drawing.Size(391, 339);
         this.Load += new System.EventHandler(this.ctlFreight_Load);
         ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
         this.pnlBody.ResumeLayout(false);
         this.pnlBody.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtFreightPercent.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdSI)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grdvSI)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.repCheckBox)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtSIAmount.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtFreightAmount.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.PanelControl pnlBody;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.TextEdit txtFreightAmount;
      private DevExpress.XtraEditors.LabelControl lblFreightID;
      private DevExpress.XtraEditors.TextEdit txtSIAmount;
      private DevExpress.XtraEditors.LabelControl labelControl3;
      private DevExpress.XtraEditors.LabelControl labelControl2;
      private DevExpress.XtraGrid.GridControl grdSI;
      private DevExpress.XtraGrid.Views.Grid.GridView grdvSI;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
      private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckBox;
      private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
      private DevExpress.XtraEditors.SimpleButton btnSave;
      private DevExpress.XtraEditors.TextEdit txtFreightPercent;
      private DevExpress.XtraEditors.LabelControl labelControl4;
   }
}
