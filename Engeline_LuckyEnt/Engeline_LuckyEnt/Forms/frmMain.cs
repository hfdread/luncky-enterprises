#region includes

using System;
using System.Threading;
using System.Windows.Forms;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

using System.Collections.Generic;

namespace Engeline_LuckyEnt.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            IList<Person> lst = new List<Person>();
            for (int x = 0; x < 10; x++)
            {
                Person p = new Person();
                p.ID = x + 1;
                p.FName = string.Format("{0} - Bert",x+1);
                p.LName = string.Format("{0} - Betowski", x + 1);
                lst.Add(p);
            }

            grdP.DataSource = lst;
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            Person p = (Person)e.Row;
            if (e.Column.FieldName == "_X")
            {
                e.Value = p.ID.ToString();
            }
        }
    }
}
