namespace Engeline_LuckyEnt.UI_Controls.Utilities
{
   partial class ctlRequestApproval
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
          this.btnClose = new DevExpress.XtraEditors.SimpleButton();
          this.btnDecline = new DevExpress.XtraEditors.SimpleButton();
          this.btnApprove = new DevExpress.XtraEditors.SimpleButton();
          this.txtMessage = new DevExpress.XtraEditors.MemoEdit();
          this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
          this.txtRequestType = new DevExpress.XtraEditors.TextEdit();
          this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
          this.txtTerminal = new DevExpress.XtraEditors.TextEdit();
          this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
          this.txtTime = new DevExpress.XtraEditors.TextEdit();
          this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
          this.txtSender = new DevExpress.XtraEditors.TextEdit();
          this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
          ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
          this.pnlMain.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.txtMessage.Properties)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.txtRequestType.Properties)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.txtTerminal.Properties)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.txtSender.Properties)).BeginInit();
          this.SuspendLayout();
          // 
          // pnlMain
          // 
          this.pnlMain.Controls.Add(this.btnClose);
          this.pnlMain.Controls.Add(this.btnDecline);
          this.pnlMain.Controls.Add(this.btnApprove);
          this.pnlMain.Controls.Add(this.txtMessage);
          this.pnlMain.Controls.Add(this.labelControl5);
          this.pnlMain.Controls.Add(this.txtRequestType);
          this.pnlMain.Controls.Add(this.labelControl4);
          this.pnlMain.Controls.Add(this.txtTerminal);
          this.pnlMain.Controls.Add(this.labelControl3);
          this.pnlMain.Controls.Add(this.txtTime);
          this.pnlMain.Controls.Add(this.labelControl2);
          this.pnlMain.Controls.Add(this.txtSender);
          this.pnlMain.Controls.Add(this.labelControl1);
          this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
          this.pnlMain.Location = new System.Drawing.Point(0, 0);
          this.pnlMain.Name = "pnlMain";
          this.pnlMain.Size = new System.Drawing.Size(386, 333);
          this.pnlMain.TabIndex = 0;
          // 
          // btnClose
          // 
          this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.btnClose.Appearance.Options.UseFont = true;
          this.btnClose.Location = new System.Drawing.Point(152, 260);
          this.btnClose.Name = "btnClose";
          this.btnClose.Size = new System.Drawing.Size(83, 34);
          this.btnClose.TabIndex = 12;
          this.btnClose.Text = "&Close";
          this.btnClose.Visible = false;
          this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
          // 
          // btnDecline
          // 
          this.btnDecline.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.btnDecline.Appearance.Options.UseFont = true;
          this.btnDecline.Location = new System.Drawing.Point(196, 260);
          this.btnDecline.Name = "btnDecline";
          this.btnDecline.Size = new System.Drawing.Size(83, 34);
          this.btnDecline.TabIndex = 11;
          this.btnDecline.Text = "&Decline";
          this.btnDecline.Click += new System.EventHandler(this.btnDecline_Click);
          // 
          // btnApprove
          // 
          this.btnApprove.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.btnApprove.Appearance.Options.UseFont = true;
          this.btnApprove.Location = new System.Drawing.Point(107, 260);
          this.btnApprove.Name = "btnApprove";
          this.btnApprove.Size = new System.Drawing.Size(83, 34);
          this.btnApprove.TabIndex = 10;
          this.btnApprove.Text = "&Approve";
          this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
          // 
          // txtMessage
          // 
          this.txtMessage.Location = new System.Drawing.Point(81, 119);
          this.txtMessage.Name = "txtMessage";
          this.txtMessage.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
          this.txtMessage.Properties.AppearanceReadOnly.Options.UseBackColor = true;
          this.txtMessage.Properties.ReadOnly = true;
          this.txtMessage.Size = new System.Drawing.Size(294, 118);
          this.txtMessage.TabIndex = 9;
          // 
          // labelControl5
          // 
          this.labelControl5.Location = new System.Drawing.Point(9, 121);
          this.labelControl5.Name = "labelControl5";
          this.labelControl5.Size = new System.Drawing.Size(42, 13);
          this.labelControl5.TabIndex = 8;
          this.labelControl5.Text = "Message";
          // 
          // txtRequestType
          // 
          this.txtRequestType.Enabled = false;
          this.txtRequestType.Location = new System.Drawing.Point(81, 93);
          this.txtRequestType.Name = "txtRequestType";
          this.txtRequestType.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
          this.txtRequestType.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
          this.txtRequestType.Properties.AppearanceDisabled.Options.UseBackColor = true;
          this.txtRequestType.Properties.AppearanceDisabled.Options.UseForeColor = true;
          this.txtRequestType.Size = new System.Drawing.Size(164, 20);
          this.txtRequestType.TabIndex = 7;
          // 
          // labelControl4
          // 
          this.labelControl4.Location = new System.Drawing.Point(9, 96);
          this.labelControl4.Name = "labelControl4";
          this.labelControl4.Size = new System.Drawing.Size(67, 13);
          this.labelControl4.TabIndex = 6;
          this.labelControl4.Text = "Request Type";
          // 
          // txtTerminal
          // 
          this.txtTerminal.Enabled = false;
          this.txtTerminal.Location = new System.Drawing.Point(81, 67);
          this.txtTerminal.Name = "txtTerminal";
          this.txtTerminal.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
          this.txtTerminal.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
          this.txtTerminal.Properties.AppearanceDisabled.Options.UseBackColor = true;
          this.txtTerminal.Properties.AppearanceDisabled.Options.UseForeColor = true;
          this.txtTerminal.Size = new System.Drawing.Size(164, 20);
          this.txtTerminal.TabIndex = 5;
          // 
          // labelControl3
          // 
          this.labelControl3.Location = new System.Drawing.Point(9, 70);
          this.labelControl3.Name = "labelControl3";
          this.labelControl3.Size = new System.Drawing.Size(40, 13);
          this.labelControl3.TabIndex = 4;
          this.labelControl3.Text = "Terminal";
          // 
          // txtTime
          // 
          this.txtTime.Enabled = false;
          this.txtTime.Location = new System.Drawing.Point(81, 41);
          this.txtTime.Name = "txtTime";
          this.txtTime.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
          this.txtTime.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
          this.txtTime.Properties.AppearanceDisabled.Options.UseBackColor = true;
          this.txtTime.Properties.AppearanceDisabled.Options.UseForeColor = true;
          this.txtTime.Size = new System.Drawing.Size(164, 20);
          this.txtTime.TabIndex = 3;
          // 
          // labelControl2
          // 
          this.labelControl2.Location = new System.Drawing.Point(9, 44);
          this.labelControl2.Name = "labelControl2";
          this.labelControl2.Size = new System.Drawing.Size(22, 13);
          this.labelControl2.TabIndex = 2;
          this.labelControl2.Text = "Time";
          // 
          // txtSender
          // 
          this.txtSender.Enabled = false;
          this.txtSender.Location = new System.Drawing.Point(81, 15);
          this.txtSender.Name = "txtSender";
          this.txtSender.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
          this.txtSender.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
          this.txtSender.Properties.AppearanceDisabled.Options.UseBackColor = true;
          this.txtSender.Properties.AppearanceDisabled.Options.UseForeColor = true;
          this.txtSender.Size = new System.Drawing.Size(164, 20);
          this.txtSender.TabIndex = 1;
          // 
          // labelControl1
          // 
          this.labelControl1.Location = new System.Drawing.Point(9, 18);
          this.labelControl1.Name = "labelControl1";
          this.labelControl1.Size = new System.Drawing.Size(34, 13);
          this.labelControl1.TabIndex = 0;
          this.labelControl1.Text = "Sender";
          // 
          // ctlRequestApproval
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.pnlMain);
          this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.Name = "ctlRequestApproval";
          this.Size = new System.Drawing.Size(386, 333);
          this.Load += new System.EventHandler(this.ctlRequestApproval_Load);
          ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
          this.pnlMain.ResumeLayout(false);
          this.pnlMain.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.txtMessage.Properties)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.txtRequestType.Properties)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.txtTerminal.Properties)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.txtTime.Properties)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.txtSender.Properties)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.PanelControl pnlMain;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.TextEdit txtTerminal;
      private DevExpress.XtraEditors.LabelControl labelControl3;
      private DevExpress.XtraEditors.TextEdit txtTime;
      private DevExpress.XtraEditors.LabelControl labelControl2;
      private DevExpress.XtraEditors.TextEdit txtSender;
      private DevExpress.XtraEditors.TextEdit txtRequestType;
      private DevExpress.XtraEditors.LabelControl labelControl4;
      private DevExpress.XtraEditors.LabelControl labelControl5;
      private DevExpress.XtraEditors.MemoEdit txtMessage;
      private DevExpress.XtraEditors.SimpleButton btnDecline;
      private DevExpress.XtraEditors.SimpleButton btnApprove;
      private DevExpress.XtraEditors.SimpleButton btnClose;
   }
}
