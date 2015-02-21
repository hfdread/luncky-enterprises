#region

using System;
using System.Windows.Forms;
using Engeline_LuckyEnt.Forms;
using MyHibernate;
using MyHibernate.DataAccessLayer;
using NHibernate;

#endregion

namespace Engeline_LuckyEnt
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            clsDBConnect db = new clsDBConnect();

            if (db.IsValid())
            {
                //check NHibernate
                UsersDao dao = new UsersDao();
                if (dao.IsInitialized())
                    Application.Run(new frmMain2());
                else
                {
                    MessageBox.Show("NHibernate Error: " + dao.ErrorMessage);
                }
            }
            else
            Application.Run(new frmDBConnect());  
        }
    }
}
