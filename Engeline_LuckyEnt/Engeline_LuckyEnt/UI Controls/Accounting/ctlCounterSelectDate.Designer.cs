namespace DexterHardware_v2.UI_Controls.Accounting
{
   partial class ctlCounterSelectDate
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
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
         this.cboCustomer = new DevExpress.XtraEditors.ComboBoxEdit();
         this.cboYear = new DevExpress.XtraEditors.ComboBoxEdit();
         this.cboMonth = new DevExpress.XtraEditors.ComboBoxEdit();
         this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
         this.cboDay = new DevExpress.XtraEditors.ComboBoxEdit();
         this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
         ((System.ComponentModel.ISupportInitialize)(this.cboCustomer.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboYear.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboMonth.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboDay.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(15, 42);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(22, 13);
         this.labelControl1.TabIndex = 0;
         this.labelControl1.Text = "Year";
         // 
         // labelControl2
         // 
         this.labelControl2.Location = new System.Drawing.Point(15, 14);
         this.labelControl2.Name = "labelControl2";
         this.labelControl2.Size = new System.Drawing.Size(46, 13);
         this.labelControl2.TabIndex = 1;
         this.labelControl2.Text = "Customer";
         // 
         // cboCustomer
         // 
         this.cboCustomer.Location = new System.Drawing.Point(67, 11);
         this.cboCustomer.Name = "cboCustomer";
         this.cboCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboCustomer.Size = new System.Drawing.Size(181, 20);
         this.cboCustomer.TabIndex = 2;
         // 
         // cboYear
         // 
         this.cboYear.Location = new System.Drawing.Point(15, 61);
         this.cboYear.Name = "cboYear";
         this.cboYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboYear.Size = new System.Drawing.Size(64, 20);
         this.cboYear.TabIndex = 3;
         // 
         // cboMonth
         // 
         this.cboMonth.Location = new System.Drawing.Point(85, 61);
         this.cboMonth.Name = "cboMonth";
         this.cboMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboMonth.Size = new System.Drawing.Size(94, 20);
         this.cboMonth.TabIndex = 5;
         // 
         // labelControl3
         // 
         this.labelControl3.Location = new System.Drawing.Point(85, 42);
         this.labelControl3.Name = "labelControl3";
         this.labelControl3.Size = new System.Drawing.Size(30, 13);
         this.labelControl3.TabIndex = 4;
         this.labelControl3.Text = "Month";
         // 
         // cboDay
         // 
         this.cboDay.Location = new System.Drawing.Point(185, 61);
         this.cboDay.Name = "cboDay";
         this.cboDay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboDay.Size = new System.Drawing.Size(64, 20);
         this.cboDay.TabIndex = 7;
         // 
         // labelControl4
         // 
         this.labelControl4.Location = new System.Drawing.Point(185, 42);
         this.labelControl4.Name = "labelControl4";
         this.labelControl4.Size = new System.Drawing.Size(22, 13);
         this.labelControl4.TabIndex = 6;
         this.labelControl4.Text = "Year";
         // 
         // ctlCounterSelectDate
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.cboDay);
         this.Controls.Add(this.labelControl4);
         this.Controls.Add(this.cboMonth);
         this.Controls.Add(this.labelControl3);
         this.Controls.Add(this.cboYear);
         this.Controls.Add(this.cboCustomer);
         this.Controls.Add(this.labelControl2);
         this.Controls.Add(this.labelControl1);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlCounterSelectDate";
         this.Size = new System.Drawing.Size(262, 117);
         this.Load += new System.EventHandler(this.ctlCounterSelectDate_Load);
         ((System.ComponentModel.ISupportInitialize)(this.cboCustomer.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboYear.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboMonth.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.cboDay.Properties)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.LabelControl labelControl2;
      private DevExpress.XtraEditors.ComboBoxEdit cboCustomer;
      private DevExpress.XtraEditors.ComboBoxEdit cboYear;
      private DevExpress.XtraEditors.ComboBoxEdit cboMonth;
      private DevExpress.XtraEditors.LabelControl labelControl3;
      private DevExpress.XtraEditors.ComboBoxEdit cboDay;
      private DevExpress.XtraEditors.LabelControl labelControl4;
   }
}
