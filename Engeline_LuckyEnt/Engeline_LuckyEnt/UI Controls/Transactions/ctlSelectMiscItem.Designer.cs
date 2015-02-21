namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
   partial class ctlSelectMiscItem
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
         this.pnlMain = new System.Windows.Forms.Panel();
         this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
         this.btnAddItem = new DevExpress.XtraEditors.SimpleButton();
         this.txtTotalAmount = new DevExpress.XtraEditors.TextEdit();
         this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
         this.txtUnitPrice = new DevExpress.XtraEditors.TextEdit();
         this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
         this.txtQTY = new DevExpress.XtraEditors.TextEdit();
         this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
         this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
         this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
         this.txtItemName = new DevExpress.XtraEditors.TextEdit();
         this.radioGrp1 = new DevExpress.XtraEditors.RadioGroup();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.pnlMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtTotalAmount.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtUnitPrice.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtQTY.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.radioGrp1.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // pnlMain
         // 
         this.pnlMain.Controls.Add(this.btnCancel);
         this.pnlMain.Controls.Add(this.btnAddItem);
         this.pnlMain.Controls.Add(this.txtTotalAmount);
         this.pnlMain.Controls.Add(this.labelControl5);
         this.pnlMain.Controls.Add(this.txtUnitPrice);
         this.pnlMain.Controls.Add(this.labelControl4);
         this.pnlMain.Controls.Add(this.txtQTY);
         this.pnlMain.Controls.Add(this.labelControl3);
         this.pnlMain.Controls.Add(this.txtDescription);
         this.pnlMain.Controls.Add(this.labelControl2);
         this.pnlMain.Controls.Add(this.txtItemName);
         this.pnlMain.Controls.Add(this.radioGrp1);
         this.pnlMain.Controls.Add(this.labelControl1);
         this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlMain.Location = new System.Drawing.Point(0, 0);
         this.pnlMain.Name = "pnlMain";
         this.pnlMain.Size = new System.Drawing.Size(300, 348);
         this.pnlMain.TabIndex = 0;
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(153, 281);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(86, 28);
         this.btnCancel.TabIndex = 12;
         this.btnCancel.Text = "&Cancel";
         this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
         // 
         // btnAddItem
         // 
         this.btnAddItem.Location = new System.Drawing.Point(61, 281);
         this.btnAddItem.Name = "btnAddItem";
         this.btnAddItem.Size = new System.Drawing.Size(86, 28);
         this.btnAddItem.TabIndex = 11;
         this.btnAddItem.Text = "&Add Item";
         this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
         // 
         // txtTotalAmount
         // 
         this.txtTotalAmount.EditValue = "";
         this.txtTotalAmount.Enabled = false;
         this.txtTotalAmount.Location = new System.Drawing.Point(100, 238);
         this.txtTotalAmount.Name = "txtTotalAmount";
         this.txtTotalAmount.Properties.Appearance.Options.UseTextOptions = true;
         this.txtTotalAmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.txtTotalAmount.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
         this.txtTotalAmount.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
         this.txtTotalAmount.Properties.AppearanceDisabled.Options.UseBackColor = true;
         this.txtTotalAmount.Properties.AppearanceDisabled.Options.UseForeColor = true;
         this.txtTotalAmount.Size = new System.Drawing.Size(87, 20);
         this.txtTotalAmount.TabIndex = 10;
         // 
         // labelControl5
         // 
         this.labelControl5.Location = new System.Drawing.Point(16, 241);
         this.labelControl5.Name = "labelControl5";
         this.labelControl5.Size = new System.Drawing.Size(64, 13);
         this.labelControl5.TabIndex = 9;
         this.labelControl5.Text = "Total Amount";
         // 
         // txtUnitPrice
         // 
         this.txtUnitPrice.EditValue = "";
         this.txtUnitPrice.Location = new System.Drawing.Point(100, 212);
         this.txtUnitPrice.Name = "txtUnitPrice";
         this.txtUnitPrice.Properties.Appearance.Options.UseTextOptions = true;
         this.txtUnitPrice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.txtUnitPrice.Size = new System.Drawing.Size(87, 20);
         this.txtUnitPrice.TabIndex = 8;
         this.txtUnitPrice.EditValueChanged += new System.EventHandler(this.txtQTY_EditValueChanged);
         this.txtUnitPrice.Enter += new System.EventHandler(this.txtInput_Enter);
         // 
         // labelControl4
         // 
         this.labelControl4.Location = new System.Drawing.Point(16, 215);
         this.labelControl4.Name = "labelControl4";
         this.labelControl4.Size = new System.Drawing.Size(45, 13);
         this.labelControl4.TabIndex = 7;
         this.labelControl4.Text = "Unit Price";
         // 
         // txtQTY
         // 
         this.txtQTY.Location = new System.Drawing.Point(100, 186);
         this.txtQTY.Name = "txtQTY";
         this.txtQTY.Properties.Appearance.Options.UseTextOptions = true;
         this.txtQTY.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
         this.txtQTY.Size = new System.Drawing.Size(87, 20);
         this.txtQTY.TabIndex = 6;
         this.txtQTY.EditValueChanged += new System.EventHandler(this.txtQTY_EditValueChanged);
         this.txtQTY.Enter += new System.EventHandler(this.txtInput_Enter);
         // 
         // labelControl3
         // 
         this.labelControl3.Location = new System.Drawing.Point(16, 189);
         this.labelControl3.Name = "labelControl3";
         this.labelControl3.Size = new System.Drawing.Size(42, 13);
         this.labelControl3.TabIndex = 5;
         this.labelControl3.Text = "Quantity";
         // 
         // txtDescription
         // 
         this.txtDescription.Location = new System.Drawing.Point(100, 89);
         this.txtDescription.Name = "txtDescription";
         this.txtDescription.Size = new System.Drawing.Size(185, 91);
         this.txtDescription.TabIndex = 4;
         this.txtDescription.Enter += new System.EventHandler(this.txtDescription_Enter);
         // 
         // labelControl2
         // 
         this.labelControl2.Location = new System.Drawing.Point(16, 92);
         this.labelControl2.Name = "labelControl2";
         this.labelControl2.Size = new System.Drawing.Size(78, 13);
         this.labelControl2.TabIndex = 3;
         this.labelControl2.Text = "Item Description";
         // 
         // txtItemName
         // 
         this.txtItemName.Location = new System.Drawing.Point(100, 63);
         this.txtItemName.Name = "txtItemName";
         this.txtItemName.Size = new System.Drawing.Size(185, 20);
         this.txtItemName.TabIndex = 2;
         this.txtItemName.Enter += new System.EventHandler(this.txtInput_Enter);
         // 
         // radioGrp1
         // 
         this.radioGrp1.Location = new System.Drawing.Point(16, 14);
         this.radioGrp1.Name = "radioGrp1";
         this.radioGrp1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Trading Item"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Fabricated Item")});
         this.radioGrp1.Size = new System.Drawing.Size(269, 27);
         this.radioGrp1.TabIndex = 0;
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(16, 66);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(52, 13);
         this.labelControl1.TabIndex = 1;
         this.labelControl1.Text = "Item Name";
         // 
         // ctlSelectMiscItem
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.pnlMain);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlSelectMiscItem";
         this.Size = new System.Drawing.Size(300, 348);
         this.pnlMain.ResumeLayout(false);
         this.pnlMain.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.txtTotalAmount.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtUnitPrice.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtQTY.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.radioGrp1.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel pnlMain;
      private DevExpress.XtraEditors.RadioGroup radioGrp1;
      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.TextEdit txtUnitPrice;
      private DevExpress.XtraEditors.LabelControl labelControl4;
      private DevExpress.XtraEditors.TextEdit txtQTY;
      private DevExpress.XtraEditors.LabelControl labelControl3;
      private DevExpress.XtraEditors.MemoEdit txtDescription;
      private DevExpress.XtraEditors.LabelControl labelControl2;
      private DevExpress.XtraEditors.TextEdit txtItemName;
      private DevExpress.XtraEditors.TextEdit txtTotalAmount;
      private DevExpress.XtraEditors.LabelControl labelControl5;
      private DevExpress.XtraEditors.SimpleButton btnCancel;
      private DevExpress.XtraEditors.SimpleButton btnAddItem;
   }
}
