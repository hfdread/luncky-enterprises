#region
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.UI_Controls;
using Engeline_LuckyEnt.UI_Controls.Viewers;
using Engeline_LuckyEnt.Forms;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
#endregion

namespace Engeline_LuckyEnt.UI_Controls.Utilities
{
    public partial class ctlTrucking : UserControl
    {
        private VantrackersDao mVantrackersDao = null;
        
        public ctlViewArriveShipment_Trucking trucking { get; set; }
        public string VanNumber = "";

        public ctlTrucking()
        {
            InitializeComponent();
            mVantrackersDao = new VantrackersDao();
        }

        private void ctlTrucking_Load(object sender, EventArgs e)
        {
            txtVanNumber.Text = VanNumber;
            LoadVanTrackers();
        }

        private void LoadVanTrackers()
        {
            IList<Vantrackers> lst = mVantrackersDao.getAllRecords();
            cboTrucking.Properties.Items.Clear();
            foreach (Vantrackers v in lst)
            {
                cboTrucking.Properties.Items.Add(v);
            }

            cboTrucking.SelectedIndex = 0;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Vantrackers v = new Vantrackers();
            v= (Vantrackers)cboTrucking.SelectedItem;
            trucking.setTrucking(v, txtVanNumber.Text);
        }
    }
}
