#region

using System;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls
{
    public partial class ctlUserLogin : UserControl
    {
        //
        private UsersDao UsersDao = new UsersDao();


        public bool Canceled = false;

        public ctlUserLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Users user = UsersDao.GetByName("UserName", txtUserName.Text);
            if (user != null)
            {
                //check password
                SimpleAES aes = new SimpleAES();
                string password = "";
                try
                {
                    password = aes.DecryptString(user.UserPassword);
                }
                catch (Exception)
                {
                    password = "<Error>";
                }

                if (password == "<Error>")
                {
                    MessageBox.Show("Password is corrupted and cannot be recognized!", "Login", MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    txtPassword.SelectAll();
                    txtPassword.Focus();
                }
                else
                {
                    if (password == txtPassword.Text)
                    {
                        //correct login
                        frmMain2 frm = clsUtil.getMainForm();
                        if (frm != null)
                        {
                            frm.g_LoggedInUser = user;
                            CloseForm();                            
                        }
                        else
                        {
                            clsUtil.ShowMessage("Unable to get Main Form!", "Login User", MessageBoxButtons.OK,
                                              MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password is incorrect!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtPassword.SelectAll();
                        txtPassword.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("User is not registered!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Text = "";
                txtUserName.SelectAll();
                txtUserName.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Canceled = true;
            CloseForm();
        }

        private void CloseForm()
        {
            Form frm = (Form)this.Parent.Parent;
            frm.Close();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            ((DevExpress.XtraEditors.TextEdit)sender).SelectAll();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnLogin.PerformClick();
            }
        }

        private void ctlUserLogin_Load(object sender, EventArgs e)
        {
            //make sure Admin user already exists
            UsersDao.CreateAdminUser();

            //auto login
            //txtUserName.Text = "Admin";
            //txtPassword.Text = "password";
            //btnLogin.PerformClick();
        }

        private void txtPassword_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnLogin.PerformClick();
            }
        }
    }
}