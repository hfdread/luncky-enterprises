namespace Engeline_LuckyEnt.UI_Controls.Utilities
{
    partial class ctlDestination
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkCustomer = new DevExpress.XtraEditors.CheckEdit();
            this.chkWarehouse = new DevExpress.XtraEditors.CheckEdit();
            this.txtVanNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboDestination = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWarehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVanNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDestination.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.panelControl1, 0, 0);
            this.tlpMain.Controls.Add(this.panelControl2, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpMain.Size = new System.Drawing.Size(276, 171);
            this.tlpMain.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkCustomer);
            this.panelControl1.Controls.Add(this.chkWarehouse);
            this.panelControl1.Controls.Add(this.txtVanNumber);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.cboDestination);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(270, 120);
            this.panelControl1.TabIndex = 0;
            // 
            // chkCustomer
            // 
            this.chkCustomer.Location = new System.Drawing.Point(25, 67);
            this.chkCustomer.Name = "chkCustomer";
            this.chkCustomer.Properties.Caption = "Customer";
            this.chkCustomer.Size = new System.Drawing.Size(75, 19);
            this.chkCustomer.TabIndex = 9;
            this.chkCustomer.CheckedChanged += new System.EventHandler(this.chkCustomer_CheckedChanged_1);
            // 
            // chkWarehouse
            // 
            this.chkWarehouse.Location = new System.Drawing.Point(25, 42);
            this.chkWarehouse.Name = "chkWarehouse";
            this.chkWarehouse.Properties.Caption = "Warehouse";
            this.chkWarehouse.Size = new System.Drawing.Size(85, 19);
            this.chkWarehouse.TabIndex = 8;
            this.chkWarehouse.CheckedChanged += new System.EventHandler(this.chkWarehouse_CheckedChanged_1);
            // 
            // txtVanNumber
            // 
            this.txtVanNumber.EditValue = "000";
            this.txtVanNumber.Location = new System.Drawing.Point(125, 15);
            this.txtVanNumber.Name = "txtVanNumber";
            this.txtVanNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVanNumber.Properties.Appearance.Options.UseFont = true;
            this.txtVanNumber.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.txtVanNumber.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtVanNumber.Properties.ReadOnly = true;
            this.txtVanNumber.Size = new System.Drawing.Size(121, 20);
            this.txtVanNumber.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(27, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Van Number";
            // 
            // cboDestination
            // 
            this.cboDestination.Location = new System.Drawing.Point(125, 41);
            this.cboDestination.Name = "cboDestination";
            this.cboDestination.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDestination.Size = new System.Drawing.Size(121, 20);
            this.cboDestination.TabIndex = 7;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton2);
            this.panelControl2.Controls.Add(this.btnSave);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(3, 129);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(270, 39);
            this.panelControl2.TabIndex = 1;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(137, 6);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 25);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "Cancel";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(56, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Set";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctlDestination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "ctlDestination";
            this.Size = new System.Drawing.Size(276, 171);
            this.Load += new System.EventHandler(this.ctlDestination_Load);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWarehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVanNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDestination.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.TextEdit txtVanNumber;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboDestination;
        private DevExpress.XtraEditors.CheckEdit chkCustomer;
        private DevExpress.XtraEditors.CheckEdit chkWarehouse;
    }
}
