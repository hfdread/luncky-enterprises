namespace Engeline_LuckyEnt.UI_Controls.Utilities
{
   partial class ctlRequestSend
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
         this.tmrCheck = new System.Windows.Forms.Timer(this.components);
         this.pnlMain = new DevExpress.XtraEditors.PanelControl();
         this.marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
         this.lblRequest = new DevExpress.XtraEditors.LabelControl();
         this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
         ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
         this.pnlMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // tmrCheck
         // 
         this.tmrCheck.Interval = 2000;
         this.tmrCheck.Tick += new System.EventHandler(this.tmrCheck_Tick);
         // 
         // pnlMain
         // 
         this.pnlMain.Controls.Add(this.btnCancel);
         this.pnlMain.Controls.Add(this.lblRequest);
         this.pnlMain.Controls.Add(this.marqueeProgressBarControl1);
         this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlMain.Location = new System.Drawing.Point(0, 0);
         this.pnlMain.Name = "pnlMain";
         this.pnlMain.Size = new System.Drawing.Size(354, 157);
         this.pnlMain.TabIndex = 0;
         // 
         // marqueeProgressBarControl1
         // 
         this.marqueeProgressBarControl1.Location = new System.Drawing.Point(10, 41);
         this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
         this.marqueeProgressBarControl1.Size = new System.Drawing.Size(334, 24);
         this.marqueeProgressBarControl1.TabIndex = 0;
         // 
         // lblRequest
         // 
         this.lblRequest.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblRequest.Appearance.Options.UseFont = true;
         this.lblRequest.Location = new System.Drawing.Point(101, 16);
         this.lblRequest.Name = "lblRequest";
         this.lblRequest.Size = new System.Drawing.Size(152, 19);
         this.lblRequest.TabIndex = 1;
         this.lblRequest.Text = "Sending request ...";
         // 
         // btnCancel
         // 
         this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnCancel.Appearance.Options.UseFont = true;
         this.btnCancel.Location = new System.Drawing.Point(120, 88);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(107, 27);
         this.btnCancel.TabIndex = 2;
         this.btnCancel.Text = "&Cancel";
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // ctlRequestSend
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.pnlMain);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlRequestSend";
         this.Size = new System.Drawing.Size(354, 157);
         this.Load += new System.EventHandler(this.ctlRequestSend_Load);
         ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
         this.pnlMain.ResumeLayout(false);
         this.pnlMain.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.marqueeProgressBarControl1.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Timer tmrCheck;
      private DevExpress.XtraEditors.PanelControl pnlMain;
      private DevExpress.XtraEditors.LabelControl lblRequest;
      private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
   }
}
