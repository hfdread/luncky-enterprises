namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
   partial class ctlInputPO
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
          this.btnSelectPO = new DevExpress.XtraEditors.SimpleButton();
          this.txtPONumber = new DevExpress.XtraEditors.TextEdit();
          this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
          ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
          this.pnlMain.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.txtPONumber.Properties)).BeginInit();
          this.SuspendLayout();
          // 
          // pnlMain
          // 
          this.pnlMain.Controls.Add(this.btnCancel);
          this.pnlMain.Controls.Add(this.btnOK);
          this.pnlMain.Controls.Add(this.btnSelectPO);
          this.pnlMain.Controls.Add(this.txtPONumber);
          this.pnlMain.Controls.Add(this.labelControl1);
          this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pnlMain.Location = new System.Drawing.Point(0, 0);
          this.pnlMain.Name = "pnlMain";
          this.pnlMain.Size = new System.Drawing.Size(342, 171);
          this.pnlMain.TabIndex = 0;
          // 
          // btnCancel
          // 
          this.btnCancel.Location = new System.Drawing.Point(227, 91);
          this.btnCancel.Name = "btnCancel";
          this.btnCancel.Size = new System.Drawing.Size(100, 33);
          this.btnCancel.TabIndex = 4;
          this.btnCancel.Text = "&Cancel";
          this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
          // 
          // btnOK
          // 
          this.btnOK.Location = new System.Drawing.Point(121, 91);
          this.btnOK.Name = "btnOK";
          this.btnOK.Size = new System.Drawing.Size(100, 33);
          this.btnOK.TabIndex = 3;
          this.btnOK.Text = "&OK";
          this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
          // 
          // btnSelectPO
          // 
          this.btnSelectPO.Location = new System.Drawing.Point(15, 91);
          this.btnSelectPO.Name = "btnSelectPO";
          this.btnSelectPO.Size = new System.Drawing.Size(100, 33);
          this.btnSelectPO.TabIndex = 2;
          this.btnSelectPO.Text = "&Select From List";
          this.btnSelectPO.Click += new System.EventHandler(this.btnSelectPO_Click);
          // 
          // txtPONumber
          // 
          this.txtPONumber.Location = new System.Drawing.Point(99, 22);
          this.txtPONumber.Name = "txtPONumber";
          this.txtPONumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.txtPONumber.Properties.Appearance.Options.UseFont = true;
          this.txtPONumber.Properties.Appearance.Options.UseTextOptions = true;
          this.txtPONumber.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
          this.txtPONumber.Size = new System.Drawing.Size(228, 26);
          this.txtPONumber.TabIndex = 1;
          // 
          // labelControl1
          // 
          this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.labelControl1.Location = new System.Drawing.Point(15, 28);
          this.labelControl1.Name = "labelControl1";
          this.labelControl1.Size = new System.Drawing.Size(78, 16);
          this.labelControl1.TabIndex = 0;
          this.labelControl1.Text = "SOC Number";
          // 
          // ctlInputPO
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.pnlMain);
          this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.Name = "ctlInputPO";
          this.Size = new System.Drawing.Size(342, 171);
          ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
          this.pnlMain.ResumeLayout(false);
          this.pnlMain.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.txtPONumber.Properties)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.PanelControl pnlMain;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.TextEdit txtPONumber;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
      private DevExpress.XtraEditors.SimpleButton btnOK;
      private DevExpress.XtraEditors.SimpleButton btnSelectPO;
   }
}
