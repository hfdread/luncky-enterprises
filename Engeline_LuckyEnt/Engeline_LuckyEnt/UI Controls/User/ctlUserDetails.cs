using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms;
using Engeline_LuckyEnt.Forms;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

namespace Engeline_LuckyEnt.UI_Controls.User
{
    public partial class ctlUserDetails : UserControl
    {
        public Users user { get; set; }
        public bool Canceled;

        private UsersDao UsersDao = new UsersDao();
        private SimpleAES aes = new SimpleAES();

        public ctlUserDetails()
        {
            InitializeComponent();
            Canceled = false;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            //validate user
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Invalid user name!", "Save User");
                txtUserName.Focus();
                return;
            }

            if (txtPassword.Text == "")
            {
                MessageBox.Show("Invalid password!", "Save User");
                txtPassword.Focus();
                return;
            }

            if (cboUserType.SelectedIndex == -1)
            {
                MessageBox.Show("Invalid user type!", "Save User");
                cboUserType.Focus();
                return;
            }

            if (user == null)
            {
                //add new user
                user = new Users();
            }

            user.UserName = txtUserName.Text;
            user.UserPassword = aes.EncryptToString(txtPassword.Text);
            user.UserType = (Users.eUserType)cboUserType.SelectedItem;

            try
            {
                UsersDao.Save(user);
                CloseForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctlUserDetails_Load(object sender, EventArgs e)
        {
            //load user types
            cboUserType.Items.Add(Users.eUserType.Admin);
            cboUserType.Items.Add(Users.eUserType.Accounting);
            cboUserType.Items.Add(Users.eUserType.Sales);
            cboUserType.Items.Add(Users.eUserType.Encoder);

            if (user != null)
            {
                txtUserName.Text = user.UserName;
                txtPassword.Text = aes.DecryptString(user.UserPassword);
                cboUserType.Text = user.GetUserTypeString((int)user.UserType);
            }
        }
    }
}
