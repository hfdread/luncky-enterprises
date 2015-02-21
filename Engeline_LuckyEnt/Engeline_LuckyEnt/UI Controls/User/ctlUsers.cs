using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Engeline_LuckyEnt.Forms;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

namespace Engeline_LuckyEnt.UI_Controls.User
{
    public partial class ctlUsers : UserControl
    {
        private UsersDao UsersDao = new UsersDao();
        private UserPermissionsDao PermissionsDao = new UserPermissionsDao();

        public ctlUsers()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ctlUserDetails ctl = new ctlUserDetails();
            frmGenericPopup frm = new frmGenericPopup();

            frm.Text = "Create New User";
            frm.ShowCtl(ctl);
            if (!ctl.Canceled)
            {
                List<Users> lst = (List<Users>)grdUsers.DataSource;
                lst.Add(ctl.user);
                grdUsers.RefreshDataSource();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grdViewUsers.FocusedRowHandle >= 0)
            {
                Users user = (Users)grdViewUsers.GetRow(grdViewUsers.FocusedRowHandle);
                if (user != null)
                {
                    ctlUserDetails ctl = new ctlUserDetails();
                    frmGenericPopup frm = new frmGenericPopup();

                    ctl.user = user;
                    frm.ShowCtl(ctl);
                    if (!ctl.Canceled)
                    {
                        //List<Users> lst = (List<Users>)grdUsers.DataSource;
                        //lst.Add(ctl.user);
                        grdUsers.RefreshDataSource();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grdViewUsers.FocusedRowHandle >= 0)
            {
                Users user = (Users)grdViewUsers.GetRow(grdViewUsers.FocusedRowHandle);
                if (user != null)
                {
                    if (
                       MessageBox.Show("Delete seleted user?", "Delete User", MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            UsersDao.Delete(user);
                            List<Users> lst = (List<Users>)grdUsers.DataSource;
                            lst.Remove(user);
                            grdUsers.RefreshDataSource();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void ctlUsers_Load(object sender, EventArgs e)
        {
            grdUsers.DataSource = UsersDao.getAllRecords();
        }

        private void grdViewUsers_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData && e.Column.FieldName == "Type")
            {
                Users user = (Users)e.Row;

                switch (user.UserType)
                {
                    case Users.eUserType.Accounting:
                        e.Value = Users.eUserType.Accounting;
                        break;
                    case Users.eUserType.Admin:
                        e.Value = Users.eUserType.Admin;
                        break;
                    case Users.eUserType.Encoder:
                        e.Value = Users.eUserType.Encoder;
                        break;
                    case Users.eUserType.Sales:
                        e.Value = Users.eUserType.Sales;
                        break;
                    default:
                        e.Value = "";
                        break;
                }
            }
            else if (e.IsGetData && e.Column.FieldName == "_password")
            {
                e.Value = "******";
            }
        }
    }
}
