namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
    partial class ctlViewDamagedMissing_Salvage
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblDmg = new DevExpress.XtraEditors.LabelControl();
            this.txtDmg = new DevExpress.XtraEditors.TextEdit();
            this.txtMissing = new DevExpress.XtraEditors.TextEdit();
            this.lblMissing = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblStockInID = new DevExpress.XtraEditors.LabelControl();
            this.lblItem = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalSalvage = new DevExpress.XtraEditors.LabelControl();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDmg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMissing.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.panelControl1, 0, 0);
            this.tlpMain.Controls.Add(this.panelControl2, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(326, 290);
            this.tlpMain.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblItem);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.lblStockInID);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(320, 46);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lblTotalSalvage);
            this.panelControl2.Controls.Add(this.btnCancel);
            this.panelControl2.Controls.Add(this.btnOk);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.txtMissing);
            this.panelControl2.Controls.Add(this.lblMissing);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.txtDmg);
            this.panelControl2.Controls.Add(this.lblDmg);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(3, 55);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(320, 232);
            this.panelControl2.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(43, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Damage: ";
            // 
            // lblDmg
            // 
            this.lblDmg.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDmg.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblDmg.Location = new System.Drawing.Point(115, 17);
            this.lblDmg.Name = "lblDmg";
            this.lblDmg.Size = new System.Drawing.Size(12, 23);
            this.lblDmg.TabIndex = 1;
            this.lblDmg.Text = "0";
            // 
            // txtDmg
            // 
            this.txtDmg.Location = new System.Drawing.Point(167, 18);
            this.txtDmg.Name = "txtDmg";
            this.txtDmg.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDmg.Properties.Appearance.Options.UseFont = true;
            this.txtDmg.Size = new System.Drawing.Size(100, 22);
            this.txtDmg.TabIndex = 2;
            this.txtDmg.EditValueChanged += new System.EventHandler(this.txtDmg_EditValueChanged);
            // 
            // txtMissing
            // 
            this.txtMissing.Location = new System.Drawing.Point(167, 59);
            this.txtMissing.Name = "txtMissing";
            this.txtMissing.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMissing.Properties.Appearance.Options.UseFont = true;
            this.txtMissing.Size = new System.Drawing.Size(100, 22);
            this.txtMissing.TabIndex = 5;
            this.txtMissing.EditValueChanged += new System.EventHandler(this.txtMissing_EditValueChanged);
            // 
            // lblMissing
            // 
            this.lblMissing.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMissing.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMissing.Location = new System.Drawing.Point(115, 58);
            this.lblMissing.Name = "lblMissing";
            this.lblMissing.Size = new System.Drawing.Size(12, 23);
            this.lblMissing.TabIndex = 4;
            this.lblMissing.Text = "0";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(43, 63);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(51, 18);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Missing:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(43, 116);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(93, 18);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Total Salvage:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(75, 168);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 28);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(165, 168);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(16, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(98, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Previous StockIn ID:";
            // 
            // lblStockInID
            // 
            this.lblStockInID.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockInID.Location = new System.Drawing.Point(122, 8);
            this.lblStockInID.Name = "lblStockInID";
            this.lblStockInID.Size = new System.Drawing.Size(21, 13);
            this.lblStockInID.TabIndex = 1;
            this.lblStockInID.Text = "000";
            // 
            // lblItem
            // 
            this.lblItem.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(48, 27);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(87, 13);
            this.lblItem.TabIndex = 3;
            this.lblItem.Text = "Name, Description";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(16, 27);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(26, 13);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "Item:";
            // 
            // lblTotalSalvage
            // 
            this.lblTotalSalvage.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSalvage.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblTotalSalvage.Location = new System.Drawing.Point(165, 115);
            this.lblTotalSalvage.Name = "lblTotalSalvage";
            this.lblTotalSalvage.Size = new System.Drawing.Size(12, 23);
            this.lblTotalSalvage.TabIndex = 11;
            this.lblTotalSalvage.Text = "0";
            // 
            // ctlViewDamagedMissing_Salvage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "ctlViewDamagedMissing_Salvage";
            this.Size = new System.Drawing.Size(326, 290);
            this.Load += new System.EventHandler(this.ctlViewDamagedMissing_Salvage_Load);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDmg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMissing.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtDmg;
        private DevExpress.XtraEditors.LabelControl lblDmg;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtMissing;
        private DevExpress.XtraEditors.LabelControl lblMissing;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblItem;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblStockInID;
        private DevExpress.XtraEditors.LabelControl lblTotalSalvage;
    }
}
