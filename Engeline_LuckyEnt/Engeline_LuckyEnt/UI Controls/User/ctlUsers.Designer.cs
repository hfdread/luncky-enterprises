namespace Engeline_LuckyEnt.UI_Controls.User
{
    partial class ctlUsers
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
            this.grdUsers = new DevExpress.XtraGrid.GridControl();
            this.grdViewUsers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnPermissions = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewUsers)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.grdUsers, 0, 0);
            this.tlpMain.Controls.Add(this.pnlFooter, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.7347F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.26531F));
            this.tlpMain.Size = new System.Drawing.Size(468, 270);
            this.tlpMain.TabIndex = 1;
            // 
            // grdUsers
            // 
            this.grdUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUsers.Location = new System.Drawing.Point(3, 3);
            this.grdUsers.MainView = this.grdViewUsers;
            this.grdUsers.Name = "grdUsers";
            this.grdUsers.Size = new System.Drawing.Size(462, 228);
            this.grdUsers.TabIndex = 0;
            this.grdUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewUsers});
            // 
            // grdViewUsers
            // 
            this.grdViewUsers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.grdViewUsers.GridControl = this.grdUsers;
            this.grdViewUsers.Name = "grdViewUsers";
            this.grdViewUsers.OptionsBehavior.Editable = false;
            this.grdViewUsers.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdViewUsers.OptionsView.ShowGroupPanel = false;
            this.grdViewUsers.OptionsView.ShowIndicator = false;
            this.grdViewUsers.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grdViewUsers_CustomUnboundColumnData);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnPermissions);
            this.pnlFooter.Controls.Add(this.btnDelete);
            this.pnlFooter.Controls.Add(this.btnEdit);
            this.pnlFooter.Controls.Add(this.btnAdd);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFooter.Location = new System.Drawing.Point(3, 237);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(462, 30);
            this.pnlFooter.TabIndex = 1;
            // 
            // btnPermissions
            // 
            this.btnPermissions.Location = new System.Drawing.Point(310, 3);
            this.btnPermissions.Name = "btnPermissions";
            this.btnPermissions.Size = new System.Drawing.Size(70, 27);
            this.btnPermissions.TabIndex = 3;
            this.btnPermissions.Text = "&Permissions";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(234, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 27);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(158, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(70, 27);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(82, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(70, 27);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "&Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "User Name";
            this.gridColumn1.FieldName = "UserName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 160;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Password";
            this.gridColumn2.DisplayFormat.FormatString = "*******";
            this.gridColumn2.FieldName = "_password";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 834;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "User Type";
            this.gridColumn3.FieldName = "Type";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowSize = false;
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 113;
            // 
            // ctlUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "ctlUsers";
            this.Size = new System.Drawing.Size(468, 270);
            this.Load += new System.EventHandler(this.ctlUsers_Load);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewUsers)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private DevExpress.XtraGrid.GridControl grdUsers;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewUsers;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.Panel pnlFooter;
        private DevExpress.XtraEditors.SimpleButton btnPermissions;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
    }
}
