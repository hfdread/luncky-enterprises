namespace Engeline_LuckyEnt.UI_Controls.Accounting
{
   partial class ctlPaymentPDC
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
         this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.cboBank = new DevExpress.XtraEditors.ComboBoxEdit();
         this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
         this.txtAccountNo = new DevExpress.XtraEditors.TextEdit();
         this.txtCheckNo = new DevExpress.XtraEditors.TextEdit();
         this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
         this.txtAmount = new DevExpress.XtraEditors.TextEdit();
         this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
         this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
         this.dtCheckDate = new DevExpress.XtraEditors.DateEdit();
         this.btnOK = new DevExpress.XtraEditors.SimpleButton();
         this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
         ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
         this.panelControl1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboBank.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtAccountNo.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtCheckNo.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dtCheckDate.Properties.VistaTimeProperties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dtCheckDate.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // panelControl1
         // 
         this.panelControl1.Controls.Add(this.simpleButton1);
         this.panelControl1.Controls.Add(this.btnOK);
         this.panelControl1.Controls.Add(this.dtCheckDate);
         this.panelControl1.Controls.Add(this.labelControl5);
         this.panelControl1.Controls.Add(this.txtAmount);
         this.panelControl1.Controls.Add(this.labelControl4);
         this.panelControl1.Controls.Add(this.txtCheckNo);
         this.panelControl1.Controls.Add(this.labelControl3);
         this.panelControl1.Controls.Add(this.txtAccountNo);
         this.panelControl1.Controls.Add(this.labelControl2);
         this.panelControl1.Controls.Add(this.cboBank);
         this.panelControl1.Controls.Add(this.labelControl1);
         this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panelControl1.Location = new System.Drawing.Point(0, 0);
         this.panelControl1.Name = "panelControl1";
         this.panelControl1.Size = new System.Drawing.Size(258, 226);
         this.panelControl1.TabIndex = 0;
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(10, 20);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(23, 13);
         this.labelControl1.TabIndex = 0;
         this.labelControl1.Text = "&Bank";
         // 
         // cboBank
         // 
         this.cboBank.Location = new System.Drawing.Point(82, 17);
         this.cboBank.Name = "cboBank";
         this.cboBank.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboBank.Size = new System.Drawing.Size(162, 20);
         this.cboBank.TabIndex = 1;
         // 
         // labelControl2
         // 
         this.labelControl2.Location = new System.Drawing.Point(10, 48);
         this.labelControl2.Name = "labelControl2";
         this.labelControl2.Size = new System.Drawing.Size(59, 13);
         this.labelControl2.TabIndex = 2;
         this.labelControl2.Text = "&Account No.";
         // 
         // txtAccountNo
         // 
         this.txtAccountNo.Location = new System.Drawing.Point(82, 43);
         this.txtAccountNo.Name = "txtAccountNo";
         this.txtAccountNo.Size = new System.Drawing.Size(162, 20);
         this.txtAccountNo.TabIndex = 3;
         this.txtAccountNo.Enter += new System.EventHandler(this.txtAmount_Enter);
         // 
         // txtCheckNo
         // 
         this.txtCheckNo.Location = new System.Drawing.Point(82, 69);
         this.txtCheckNo.Name = "txtCheckNo";
         this.txtCheckNo.Size = new System.Drawing.Size(162, 20);
         this.txtCheckNo.TabIndex = 5;
         this.txtCheckNo.Enter += new System.EventHandler(this.txtAmount_Enter);
         // 
         // labelControl3
         // 
         this.labelControl3.Location = new System.Drawing.Point(10, 72);
         this.labelControl3.Name = "labelControl3";
         this.labelControl3.Size = new System.Drawing.Size(49, 13);
         this.labelControl3.TabIndex = 4;
         this.labelControl3.Text = "Check &No.";
         // 
         // txtAmount
         // 
         this.txtAmount.EditValue = "";
         this.txtAmount.Location = new System.Drawing.Point(82, 121);
         this.txtAmount.Name = "txtAmount";
         this.txtAmount.Properties.Appearance.Options.UseTextOptions = true;
         this.txtAmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.txtAmount.Properties.DisplayFormat.FormatString = "{0:N2}";
         this.txtAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
         this.txtAmount.Size = new System.Drawing.Size(88, 20);
         this.txtAmount.TabIndex = 9;
         this.txtAmount.Enter += new System.EventHandler(this.txtAmount_Enter);
         // 
         // labelControl4
         // 
         this.labelControl4.Location = new System.Drawing.Point(10, 124);
         this.labelControl4.Name = "labelControl4";
         this.labelControl4.Size = new System.Drawing.Size(37, 13);
         this.labelControl4.TabIndex = 8;
         this.labelControl4.Text = "A&mount";
         // 
         // labelControl5
         // 
         this.labelControl5.Location = new System.Drawing.Point(10, 98);
         this.labelControl5.Name = "labelControl5";
         this.labelControl5.Size = new System.Drawing.Size(55, 13);
         this.labelControl5.TabIndex = 6;
         this.labelControl5.Text = "Check &Date";
         // 
         // dtCheckDate
         // 
         this.dtCheckDate.EditValue = new System.DateTime(2011, 1, 7, 19, 39, 9, 64);
         this.dtCheckDate.Location = new System.Drawing.Point(82, 95);
         this.dtCheckDate.Name = "dtCheckDate";
         this.dtCheckDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.dtCheckDate.Properties.DisplayFormat.FormatString = "MMM dd, yyyy";
         this.dtCheckDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
         this.dtCheckDate.Properties.EditFormat.FormatString = "MMM dd, yyyy";
         this.dtCheckDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
         this.dtCheckDate.Properties.Mask.EditMask = "MMM dd, yyyy";
         this.dtCheckDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
         this.dtCheckDate.Size = new System.Drawing.Size(162, 20);
         this.dtCheckDate.TabIndex = 7;
         // 
         // btnOK
         // 
         this.btnOK.Location = new System.Drawing.Point(63, 167);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(63, 23);
         this.btnOK.TabIndex = 10;
         this.btnOK.Text = "&OK";
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // simpleButton1
         // 
         this.simpleButton1.Location = new System.Drawing.Point(132, 167);
         this.simpleButton1.Name = "simpleButton1";
         this.simpleButton1.Size = new System.Drawing.Size(63, 23);
         this.simpleButton1.TabIndex = 11;
         this.simpleButton1.Text = "&Cancel";
         this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
         // 
         // ctlPaymentPDC
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.panelControl1);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlPaymentPDC";
         this.Size = new System.Drawing.Size(258, 226);
         this.Load += new System.EventHandler(this.ctlPaymentPDC_Load);
         ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
         this.panelControl1.ResumeLayout(false);
         this.panelControl1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.cboBank.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtAccountNo.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtCheckNo.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtAmount.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dtCheckDate.Properties.VistaTimeProperties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dtCheckDate.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.PanelControl panelControl1;
      private DevExpress.XtraEditors.TextEdit txtCheckNo;
      private DevExpress.XtraEditors.LabelControl labelControl3;
      private DevExpress.XtraEditors.TextEdit txtAccountNo;
      private DevExpress.XtraEditors.LabelControl labelControl2;
      private DevExpress.XtraEditors.ComboBoxEdit cboBank;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.DateEdit dtCheckDate;
      private DevExpress.XtraEditors.LabelControl labelControl5;
      private DevExpress.XtraEditors.TextEdit txtAmount;
      private DevExpress.XtraEditors.LabelControl labelControl4;
      private DevExpress.XtraEditors.SimpleButton simpleButton1;
      private DevExpress.XtraEditors.SimpleButton btnOK;
   }
}
