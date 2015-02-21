#region
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.Forms;
using Engeline_LuckyEnt.UI_Controls;
using Engeline_LuckyEnt.UI_Controls.Viewers;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
#endregion

namespace Engeline_LuckyEnt.UI_Controls.Utilities
{
    public partial class ctlDestination : UserControl
    {
        private WarehouseDao mWarehouseDao = null;
        private ContactsDao mContactsDao = null;

        public string VanNumber = "";
        public ctlViewArriveShipment_Trucking trucking { get; set; }

        public ctlDestination()
        {
            InitializeComponent();
            mWarehouseDao = new WarehouseDao();
            mContactsDao = new ContactsDao();
        }

        private void ctlDestination_Load(object sender, EventArgs e)
        {
            txtVanNumber.Text = VanNumber;
        }

        private void LoadWarehouse()
        {
            IList<Warehouse> lst = mWarehouseDao.getAllRecords();
            cboDestination.Properties.Items.Clear();
            foreach (Warehouse W in lst)
            {
                cboDestination.Properties.Items.Add(W);
            }
        }

        private void LoadCustomerList()
        {
            IList<Contacts> lst = mContactsDao.getAllCustomers();
            cboDestination.Properties.Items.Clear();
            foreach (Contacts C in lst)
            {
                cboDestination.Properties.Items.Add(C);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboDestination.SelectedText == "" || cboDestination.SelectedIndex == -1)
            {
                clsUtil.ShowMessageExclamation("Please select the Destination!", "Select Destination");
                return;
            }

            if (chkWarehouse.Checked)
            {
                Warehouse W = (Warehouse)cboDestination.SelectedItem;
                trucking.setDestination(W, txtVanNumber.Text);
            }

            if (chkCustomer.Checked)
            {
                Contacts C = (Contacts)cboDestination.SelectedItem;
                trucking.setDestination(C, txtVanNumber.Text);
            }
        }

        private void chkWarehouse_CheckedChanged_1(object sender, EventArgs e)
        {
            cboDestination.Text = "";
            cboDestination.Properties.Items.Clear();

            if (chkWarehouse.Checked)
            {
                chkCustomer.Checked = false;
                LoadWarehouse();
            }
        }

        private void chkCustomer_CheckedChanged_1(object sender, EventArgs e)
        {
            cboDestination.Text = "";
            cboDestination.Properties.Items.Clear();

            if (chkCustomer.Checked)
            {
                chkWarehouse.Checked = false;
                LoadCustomerList();
            }
        }
    }
}
