#region

using System;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using MyHibernate;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.Forms
{
    public partial class frmDBConnect : Form
    {
        public frmDBConnect()
        {
            InitializeComponent();
        }

        private void frmDBConnect_Load(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtServer.Text.Trim() == "")
            {
                clsUtil.ShowMessageExclamation("Invalid server name!", "DB Connection");
                txtServer.Focus();
            }

            if (txtPassword.Text.Trim() == "")
            {
                clsUtil.ShowMessageExclamation("Invalid password!", "DB Connection");
                txtServer.Focus();
            }

            SimpleAES aes = new SimpleAES();
            clsDBConnect db = new clsDBConnect();
            db.DB_Server = txtServer.Text;
            db.DB_Password = aes.EncryptToString(txtPassword.Text);
            db.DB_User = "root";
            db.SaveSettings();

            //try connection
            txtServer.Enabled = false;
            txtPassword.Enabled = false;
            btnCancel.Enabled = false;
            btnConnect.Enabled = false;

            UsersDao dao = new UsersDao();
            dao.getSession();
            //User user = dao.CreateAdmin();
            if (!dao.IsInitialized())
            {
                clsUtil.ShowMessageError(string.Format("DB Connection error!\nErrorMsg: {0}", dao.ErrorMessage), "DB Setup");
                txtServer.Enabled = true;
                txtPassword.Enabled = true;
                btnCancel.Enabled = true;
                btnConnect.Enabled = true;
                txtServer.SelectAll();
                txtServer.Focus();
            }
            else
            {
                dao.CreateAdminUser();
                this.Hide();
                frmMain2 frm = new frmMain2();
                frm.ShowDialog();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
