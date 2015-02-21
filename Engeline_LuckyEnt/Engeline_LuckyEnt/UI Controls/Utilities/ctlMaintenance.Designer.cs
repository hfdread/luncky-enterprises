namespace DexterHardware_v2.UI_Controls.Utilities
{
   partial class ctlMaintenance
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
         this.cboShowSellingPrice = new DevExpress.XtraEditors.ComboBoxEdit();
         this.btnSave = new DevExpress.XtraEditors.SimpleButton();
         ((System.ComponentModel.ISupportInitialize)(this.cboShowSellingPrice.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(14, 24);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(85, 13);
         this.labelControl1.TabIndex = 0;
         this.labelControl1.Text = "Show Selling Price";
         // 
         // cboShowSellingPrice
         // 
         this.cboShowSellingPrice.Location = new System.Drawing.Point(119, 21);
         this.cboShowSellingPrice.Name = "cboShowSellingPrice";
         this.cboShowSellingPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
         this.cboShowSellingPrice.Properties.Items.AddRange(new object[] {
            "NO",
            "YES"});
         this.cboShowSellingPrice.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
         this.cboShowSellingPrice.Size = new System.Drawing.Size(74, 20);
         this.cboShowSellingPrice.TabIndex = 1;
         // 
         // btnSave
         // 
         this.btnSave.Location = new System.Drawing.Point(144, 84);
         this.btnSave.Name = "btnSave";
         this.btnSave.Size = new System.Drawing.Size(100, 23);
         this.btnSave.TabIndex = 2;
         this.btnSave.Text = "&Update Settings";
         this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
         // 
         // ctlMaintenance
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.Controls.Add(this.btnSave);
         this.Controls.Add(this.cboShowSellingPrice);
         this.Controls.Add(this.labelControl1);
         this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
         this.Name = "ctlMaintenance";
         this.Size = new System.Drawing.Size(389, 141);
         this.Load += new System.EventHandler(this.ctlMaintenance_Load);
         ((System.ComponentModel.ISupportInitialize)(this.cboShowSellingPrice.Properties)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DevExpress.XtraEditors.LabelControl labelControl1;
      private DevExpress.XtraEditors.ComboBoxEdit cboShowSellingPrice;
      private DevExpress.XtraEditors.SimpleButton btnSave;
   }
}
