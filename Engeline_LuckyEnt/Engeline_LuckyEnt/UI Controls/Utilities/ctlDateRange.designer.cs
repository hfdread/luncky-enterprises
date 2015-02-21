namespace Engeline_LuckyEnt.UI_Controls
{
   partial class ctlDateRange
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
         this.cboRange = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
         this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
         this.label2 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // cboRange
         // 
         this.cboRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cboRange.FormattingEnabled = true;
         this.cboRange.Location = new System.Drawing.Point(6, 3);
         this.cboRange.Name = "cboRange";
         this.cboRange.Size = new System.Drawing.Size(120, 21);
         this.cboRange.TabIndex = 0;
         this.cboRange.SelectedIndexChanged += new System.EventHandler(this.cboRange_SelectedIndexChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(139, 6);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(31, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "From";
         // 
         // dtpDateFrom
         // 
         this.dtpDateFrom.CustomFormat = "MMM dd, yyyy";
         this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.dtpDateFrom.Location = new System.Drawing.Point(176, 3);
         this.dtpDateFrom.Name = "dtpDateFrom";
         this.dtpDateFrom.Size = new System.Drawing.Size(109, 21);
         this.dtpDateFrom.TabIndex = 2;
         // 
         // dtpDateTo
         // 
         this.dtpDateTo.CustomFormat = "MMM dd, yyyy";
         this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.dtpDateTo.Location = new System.Drawing.Point(323, 3);
         this.dtpDateTo.Name = "dtpDateTo";
         this.dtpDateTo.Size = new System.Drawing.Size(109, 21);
         this.dtpDateTo.TabIndex = 4;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(298, 6);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(19, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "To";
         // 
         // ctlDateRange
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.label2);
         this.Controls.Add(this.dtpDateTo);
         this.Controls.Add(this.dtpDateFrom);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.cboRange);
         this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ctlDateRange";
         this.Size = new System.Drawing.Size(442, 28);
         this.Load += new System.EventHandler(this.ctlDateRange_Load);
         this.Resize += new System.EventHandler(this.ctlDateRange_Resize);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ComboBox cboRange;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.DateTimePicker dtpDateFrom;
      private System.Windows.Forms.DateTimePicker dtpDateTo;
      private System.Windows.Forms.Label label2;
   }
}
