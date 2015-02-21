namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
   partial class ctlSalesInvoiceChangePrice
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
         this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
         this.btnOK = new DevExpress.XtraEditors.SimpleButton();
         this.chkApplyToAll = new DevExpress.XtraEditors.CheckEdit();
         this.grpCustomerPrice = new DevExpress.XtraEditors.GroupControl();
         this.txtDiscountCustomer = new DevExpress.XtraEditors.TextEdit();
         this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
         this.lblUnitCustomer = new DevExpress.XtraEditors.LabelControl();
         this.txtPriceCustomer = new DevExpress.XtraEditors.TextEdit();
         this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
         this.grpAgentPrice = new DevExpress.XtraEditors.GroupControl();
         this.txtDiscountAgent = new DevExpress.XtraEditors.TextEdit();
         this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
         this.lblUnitAgent = new DevExpress.XtraEditors.LabelControl();
         this.txtAgentPrice = new DevExpress.XtraEditors.TextEdit();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.btnResetAgentPrice = new DevExpress.XtraEditors.SimpleButton();
         this.btnResetCustomerPrice = new DevExpress.XtraEditors.SimpleButton();
         ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
         this.pnlBody.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.chkApplyToAll.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpCustomerPrice)).BeginInit();
         this.grpCustomerPrice.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtDiscountCustomer.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtPriceCustomer.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpAgentPrice)).BeginInit();
         this.grpAgentPrice.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtDiscountAgent.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtAgentPrice.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // pnlBody
         // 
         this.pnlBody.Controls.Add(this.btnCancel);
         this.pnlBody.Controls.Add(this.btnOK);
         this.pnlBody.Controls.Add(this.chkApplyToAll);
         this.pnlBody.Controls.Add(this.grpCustomerPrice);
         this.pnlBody.Controls.Add(this.grpAgentPrice);
         this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlBody.Location = new System.Drawing.Point(0, 0);
         this.pnlBody.Name = "pnlBody";
         this.pnlBody.Size = new System.Drawing.Size(279, 369);
         this.pnlBody.TabIndex = 0;
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(142, 297);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(69, 32);
         this.btnCancel.TabIndex = 4;
         this.btnCancel.Text = "&Cancel";
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // btnOK
         // 
         this.btnOK.Location = new System.Drawing.Point(67, 297);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(69, 32);
         this.btnOK.TabIndex = 3;
         this.btnOK.Text = "&OK";
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // chkApplyToAll
         // 
         this.chkApplyToAll.Location = new System.Drawing.Point(11, 261);
         this.chkApplyToAll.Name = "chkApplyToAll";
         this.chkApplyToAll.Properties.Caption = "&Apply to all items";
         this.chkApplyToAll.Size = new System.Drawing.Size(114, 19);
         this.chkApplyToAll.TabIndex = 2;
         // 
         // grpCustomerPrice
         // 
         this.grpCustomerPrice.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.grpCustomerPrice.Appearance.Options.UseFont = true;
         this.grpCustomerPrice.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.grpCustomerPrice.AppearanceCaption.Options.UseFont = true;
         this.grpCustomerPrice.Controls.Add(this.btnResetCustomerPrice);
         this.grpCustomerPrice.Controls.Add(this.txtDiscountCustomer);
         this.grpCustomerPrice.Controls.Add(this.labelControl3);
         this.grpCustomerPrice.Controls.Add(this.lblUnitCustomer);
         this.grpCustomerPrice.Controls.Add(this.txtPriceCustomer);
         this.grpCustomerPrice.Controls.Add(this.labelControl5);
         this.grpCustomerPrice.Location = new System.Drawing.Point(13, 139);
         this.grpCustomerPrice.Name = "grpCustomerPrice";
         this.grpCustomerPrice.Size = new System.Drawing.Size(253, 116);
         this.grpCustomerPrice.TabIndex = 1;
         this.grpCustomerPrice.Text = "Customer\'s Price";
         // 
         // txtDiscountCustomer
         // 
         this.txtDiscountCustomer.Location = new System.Drawing.Point(62, 67);
         this.txtDiscountCustomer.Name = "txtDiscountCustomer";
         this.txtDiscountCustomer.Properties.Appearance.Options.UseTextOptions = true;
         this.txtDiscountCustomer.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
         this.txtDiscountCustomer.Size = new System.Drawing.Size(104, 20);
         this.txtDiscountCustomer.TabIndex = 4;
         // 
         // labelControl3
         // 
         this.labelControl3.Location = new System.Drawing.Point(14, 70);
         this.labelControl3.Name = "labelControl3";
         this.labelControl3.Size = new System.Drawing.Size(41, 13);
         this.labelControl3.TabIndex = 3;
         this.labelControl3.Text = "Discount";
         // 
         // lblUnitCustomer
         // 
         this.lblUnitCustomer.Location = new System.Drawing.Point(172, 44);
         this.lblUnitCustomer.Name = "lblUnitCustomer";
         this.lblUnitCustomer.Size = new System.Drawing.Size(15, 13);
         this.lblUnitCustomer.TabIndex = 2;
         this.lblUnitCustomer.Text = "/pc";
         // 
         // txtPriceCustomer
         // 
         this.txtPriceCustomer.Location = new System.Drawing.Point(62, 41);
         this.txtPriceCustomer.Name = "txtPriceCustomer";
         this.txtPriceCustomer.Properties.Appearance.Options.UseTextOptions = true;
         this.txtPriceCustomer.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.txtPriceCustomer.Size = new System.Drawing.Size(104, 20);
         this.txtPriceCustomer.TabIndex = 1;
         // 
         // labelControl5
         // 
         this.labelControl5.Location = new System.Drawing.Point(14, 44);
         this.labelControl5.Name = "labelControl5";
         this.labelControl5.Size = new System.Drawing.Size(23, 13);
         this.labelControl5.TabIndex = 0;
         this.labelControl5.Text = "Price";
         // 
         // grpAgentPrice
         // 
         this.grpAgentPrice.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.grpAgentPrice.Appearance.Options.UseFont = true;
         this.grpAgentPrice.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.grpAgentPrice.AppearanceCaption.Options.UseFont = true;
         this.grpAgentPrice.Controls.Add(this.btnResetAgentPrice);
         this.grpAgentPrice.Controls.Add(this.txtDiscountAgent);
         this.grpAgentPrice.Controls.Add(this.labelControl2);
         this.grpAgentPrice.Controls.Add(this.lblUnitAgent);
         this.grpAgentPrice.Controls.Add(this.txtAgentPrice);
         this.grpAgentPrice.Controls.Add(this.labelControl1);
         this.grpAgentPrice.Location = new System.Drawing.Point(13, 8);
         this.grpAgentPrice.Name = "grpAgentPrice";
         this.grpAgentPrice.Size = new System.Drawing.Size(253, 116);
         this.grpAgentPrice.TabIndex = 0;
         this.grpAgentPrice.Text = "Agent\'s Price";
         // 
         // txtDiscountAgent
         // 
         this.txtDiscountAgent.Location = new System.Drawing.Point(62, 68);
         this.txtDiscountAgent.Name = "txtDiscountAgent";
         this.txtDiscountAgent.Properties.Appearance.Options.UseTextOptions = true;
         this.txtDiscountAgent.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
         this.txtDiscountAgent.Size = new System.Drawing.Size(104, 20);
         this.txtDiscountAgent.TabIndex = 4;
         // 
         // labelControl2
         // 
         this.labelControl2.Location = new System.Drawing.Point(14, 71);
         this.labelControl2.Name = "labelControl2";
         this.labelControl2.Size = new System.Drawing.Size(41, 13);
         this.labelControl2.TabIndex = 3;
         this.labelControl2.Text = "Discount";
         // 
         // lblUnitAgent
         // 
         this.lblUnitAgent.Location = new System.Drawing.Point(172, 45);
         this.lblUnitAgent.Name = "lblUnitAgent";
         this.lblUnitAgent.Size = new System.Drawing.Size(15, 13);
         this.lblUnitAgent.TabIndex = 2;
         this.lblUnitAgent.Text = "/pc";
         // 
         // txtAgentPrice
         // 
         this.txtAgentPrice.Location = new System.Drawing.Point(62, 42);
         this.txtAgentPrice.Name = "txtAgentPrice";
         this.txtAgentPrice.Properties.Appearance.Options.UseTextOptions = true;
         this.txtAgentPrice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.txtAgentPrice.Size = new System.Drawing.Size(104, 20);
         this.txtAgentPrice.TabIndex = 1;
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(14, 45);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(23, 13);
         this.labelControl1.TabIndex = 0;
         this.labelControl1.Text = "Price";
         // 
         // btnResetAgentPrice
         // 
         this.btnResetAgentPrice.Location = new System.Drawing.Point(193, 42);
         this.btnResetAgentPrice.Name = "btnResetAgentPrice";
         this.btnResetAgentPrice.Size = new System.Drawing.Size(48, 20);
         this.btnResetAgentPrice.TabIndex = 5;
         this.btnResetAgentPrice.Text = "Reset";
         this.btnResetAgentPrice.Click += new System.EventHandler(this.btnResetAgentPrice_Click);
         // 
         // btnResetCustomerPrice
         // 
         this.btnResetCustomerPrice.Location = new System.Drawing.Point(193, 41);
         this.btnResetCustomerPrice.Name = "btnResetCustomerPrice";
         this.btnResetCustomerPrice.Size = new System.Drawing.Size(48, 20);
         this.btnResetCustomerPrice.TabIndex = 6;
         this.btnResetCustomerPrice.Text = "Reset";
         this.btnResetCustomerPrice.Click += new System.EventHandler(this.btnResetCustomerPrice_Click);
         // 
         // ctlSalesInvoiceChangePrice
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.pnlBody);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlSalesInvoiceChangePrice";
         this.Size = new System.Drawing.Size(279, 369);
         this.Load += new System.EventHandler(this.ctlSalesInvoiceChangePrice_Load);
         ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
         this.pnlBody.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.chkApplyToAll.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpCustomerPrice)).EndInit();
         this.grpCustomerPrice.ResumeLayout(false);
         this.grpCustomerPrice.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtDiscountCustomer.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtPriceCustomer.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.grpAgentPrice)).EndInit();
         this.grpAgentPrice.ResumeLayout(false);
         this.grpAgentPrice.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtDiscountAgent.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtAgentPrice.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.PanelControl pnlBody;
      private DevExpress.XtraEditors.GroupControl grpAgentPrice;
      private DevExpress.XtraEditors.GroupControl grpCustomerPrice;
      private DevExpress.XtraEditors.TextEdit txtDiscountAgent;
      private DevExpress.XtraEditors.LabelControl labelControl2;
      private DevExpress.XtraEditors.LabelControl lblUnitAgent;
      private DevExpress.XtraEditors.TextEdit txtAgentPrice;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.TextEdit txtDiscountCustomer;
      private DevExpress.XtraEditors.LabelControl labelControl3;
      private DevExpress.XtraEditors.LabelControl lblUnitCustomer;
      private DevExpress.XtraEditors.TextEdit txtPriceCustomer;
      private DevExpress.XtraEditors.LabelControl labelControl5;
      private DevExpress.XtraEditors.CheckEdit chkApplyToAll;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
      private DevExpress.XtraEditors.SimpleButton btnOK;
      private DevExpress.XtraEditors.SimpleButton btnResetCustomerPrice;
      private DevExpress.XtraEditors.SimpleButton btnResetAgentPrice;
   }
}
