namespace DexterHardware_v2.UI_Controls.Utilities
{
   partial class ctlTemplate
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
         this.dsData = new System.Data.DataSet();
         this.tblData = new System.Data.DataTable();
         this.bSrc = new System.Windows.Forms.BindingSource(this.components);
         this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
         this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
         this.pnlFooter = new DevExpress.XtraEditors.PanelControl();
         this.btnClose = new DevExpress.XtraEditors.SimpleButton();
         this.btnOK = new DevExpress.XtraEditors.SimpleButton();
         this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
         this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
         ((System.ComponentModel.ISupportInitialize)(this.dsData)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.tblData)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.bSrc)).BeginInit();
         this.tlpMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
         this.pnlHeader.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).BeginInit();
         this.pnlFooter.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // dsData
         // 
         this.dsData.DataSetName = "NewDataSet";
         this.dsData.Tables.AddRange(new System.Data.DataTable[] {
            this.tblData});
         // 
         // tblData
         // 
         this.tblData.TableName = "tblData";
         // 
         // bSrc
         // 
         this.bSrc.DataMember = "tblData";
         this.bSrc.DataSource = this.dsData;
         // 
         // tlpMain
         // 
         this.tlpMain.ColumnCount = 1;
         this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
         this.tlpMain.Controls.Add(this.pnlFooter, 0, 2);
         this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tlpMain.Location = new System.Drawing.Point(0, 0);
         this.tlpMain.Name = "tlpMain";
         this.tlpMain.RowCount = 3;
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
         this.tlpMain.Size = new System.Drawing.Size(500, 366);
         this.tlpMain.TabIndex = 0;
         // 
         // pnlHeader
         // 
         this.pnlHeader.Controls.Add(this.textEdit1);
         this.pnlHeader.Controls.Add(this.labelControl1);
         this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlHeader.Location = new System.Drawing.Point(3, 3);
         this.pnlHeader.Name = "pnlHeader";
         this.pnlHeader.Size = new System.Drawing.Size(494, 94);
         this.pnlHeader.TabIndex = 0;
         // 
         // pnlFooter
         // 
         this.pnlFooter.Controls.Add(this.btnClose);
         this.pnlFooter.Controls.Add(this.btnOK);
         this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pnlFooter.Location = new System.Drawing.Point(3, 312);
         this.pnlFooter.Name = "pnlFooter";
         this.pnlFooter.Size = new System.Drawing.Size(494, 51);
         this.pnlFooter.TabIndex = 1;
         // 
         // btnClose
         // 
         this.btnClose.Location = new System.Drawing.Point(250, 12);
         this.btnClose.Name = "btnClose";
         this.btnClose.Size = new System.Drawing.Size(71, 27);
         this.btnClose.TabIndex = 1;
         this.btnClose.Text = "&Close";
         this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
         // 
         // btnOK
         // 
         this.btnOK.Location = new System.Drawing.Point(173, 12);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(71, 27);
         this.btnOK.TabIndex = 0;
         this.btnOK.Text = "&OK";
         // 
         // labelControl1
         // 
         this.labelControl1.Location = new System.Drawing.Point(5, 23);
         this.labelControl1.Name = "labelControl1";
         this.labelControl1.Size = new System.Drawing.Size(63, 13);
         this.labelControl1.TabIndex = 0;
         this.labelControl1.Text = "labelControl1";
         // 
         // textEdit1
         // 
         this.textEdit1.Location = new System.Drawing.Point(85, 20);
         this.textEdit1.Name = "textEdit1";
         this.textEdit1.Size = new System.Drawing.Size(114, 20);
         this.textEdit1.TabIndex = 1;
         // 
         // ctlTemplate
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tlpMain);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlTemplate";
         this.Size = new System.Drawing.Size(500, 366);
         this.Load += new System.EventHandler(this.ctlTemplate_Load);
         ((System.ComponentModel.ISupportInitialize)(this.dsData)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.tblData)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.bSrc)).EndInit();
         this.tlpMain.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
         this.pnlHeader.ResumeLayout(false);
         this.pnlHeader.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pnlFooter)).EndInit();
         this.pnlFooter.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Data.DataSet dsData;
      private System.Data.DataTable tblData;
      private System.Windows.Forms.BindingSource bSrc;
      private System.Windows.Forms.TableLayoutPanel tlpMain;
      private DevExpress.XtraEditors.PanelControl pnlHeader;
      private DevExpress.XtraEditors.PanelControl pnlFooter;
      private DevExpress.XtraEditors.SimpleButton btnClose;
      private DevExpress.XtraEditors.SimpleButton btnOK;
      private DevExpress.XtraEditors.TextEdit textEdit1;
      private DevExpress.XtraEditors.LabelControl labelControl1;
   }
}
