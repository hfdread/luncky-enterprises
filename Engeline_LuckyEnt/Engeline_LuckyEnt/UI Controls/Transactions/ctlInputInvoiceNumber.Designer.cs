namespace DexterHardware_v2.UI_Controls.Transactions
{
   partial class ctlInputInvoiceNumber
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
         this.btnOK = new DevExpress.XtraEditors.SimpleButton();
         this.pnlMain = new DevExpress.XtraEditors.PanelControl();
         this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
         this.txtPONumber = new DevExpress.XtraEditors.TextEdit();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
         this.pnlMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtPONumber.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // btnOK
         // 
         this.btnOK.Location = new System.Drawing.Point(52, 71);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(73, 22);
         this.btnOK.TabIndex = 3;
         this.btnOK.Text = "&OK";
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // pnlMain
         // 
         this.pnlMain.Controls.Add(this.btnCancel);
         this.pnlMain.Controls.Add(this.btnOK);
         this.pnlMain.Controls.Add(this.txtPONumber);
         this.pnlMain.Controls.Add(this.labelControl1);
         this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlMain.Location = new System.Drawing.Point(0, 0);
         this.pnlMain.Name = "pnlMain";
         this.pnlMain.Size = new System.Drawing.Size(256, 134);
         this.pnlMain.TabIndex = 1;
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(131, 71);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(73, 22);
         this.btnCancel.TabIndex = 4;
         this.btnCancel.Text = "&Cancel";
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // txtPONumber
         // 
         this.txtPONumber.Location = new System.Drawing.Point(92, 22);
         this.txtPONumber.Name = "txtPONumber";
         this.txtPONumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.txtPONumber.Properties.Appearance.Options.UseFont = true;
         this.txtPONumber.Properties.Appearance.Options.UseTextOptions = true;
         this.txtPONumber.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
         this.txtPONumber.Size = new System.Drawing.Size(148, 26);
         this.txtPONumber.TabIndex = 1;
         // 
         // labelControl1
         // 
         this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.labelControl1.Appearance.Options.UseFont = true;
         this.labelControl1.Location = new System.Drawing.Point(16, 28);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(71, 16);
         this.labelControl1.TabIndex = 0;
         this.labelControl1.Text = "Invoice No.";
         // 
         // ctlInputInvoiceNumber
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.pnlMain);
         this.Name = "ctlInputInvoiceNumber";
         this.Size = new System.Drawing.Size(256, 134);
         ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
         this.pnlMain.ResumeLayout(false);
         this.pnlMain.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtPONumber.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.SimpleButton btnOK;
      private DevExpress.XtraEditors.PanelControl pnlMain;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      public DevExpress.XtraEditors.TextEdit txtPONumber;
   }
}
