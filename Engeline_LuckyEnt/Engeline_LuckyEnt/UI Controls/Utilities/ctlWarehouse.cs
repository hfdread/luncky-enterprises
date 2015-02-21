using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using Engeline_LuckyEnt.UI_Controls;
using Engeline_LuckyEnt.UI_Controls.Utilities;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.Forms;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

namespace Engeline_LuckyEnt.UI_Controls.Utilities
{
    public partial class ctlWarehouse : UserControl
    {
        private WarehouseDao WHDao = null;
        private Warehouse m_SelectedWarehouse = null;

        public ctlWarehouse()
        {
            InitializeComponent();
            WHDao = new WarehouseDao();
            m_SelectedWarehouse = new Warehouse();
        }

        private void DisableEdit()
        {
            txtCode.Properties.ReadOnly = true;
            txtName.Properties.ReadOnly = true;
            txtAddress.Properties.ReadOnly = true;
            txtPhone.Properties.ReadOnly = true;
            txtFax.Properties.ReadOnly = true;
        }

        private void ctlWarehouse_Load(object sender, EventArgs e)
        {
            DisableEdit();

            //load warehouse
            LoadWarehouseList();
        }

        private void LoadWarehouseList()
        {
            //load warehouse datasource
            IList<Warehouse> lst = WHDao.getAllRecords();
            cboWarehouse.DataSource = lst;
            cboWarehouse.SelectedIndex = -1;

            //get data from selected warehouse
            foreach (Warehouse wh in lst)
            {
                if (wh.isDefault)
                {
                    txtCode.Text = wh.ID;
                    txtName.Text = wh.Name;
                    txtAddress.Text = wh.Address;
                    txtPhone.Text = wh.Phone;
                    txtFax.Text = wh.Fax;
                }
            }
        }

        private void cboWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboWarehouse.SelectedIndex == -1)
            //{
            //    clsUtil.ShowMessage("No warehouse Selected!", "Warehouse Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            Warehouse W = (Warehouse)cboWarehouse.SelectedValue;
            if (null != W)
            {
                m_SelectedWarehouse = W;
                ShowSelectedWarehouse();
            }
            else
            {
                ClearForm();
            }
        }

        private void ShowSelectedWarehouse()
        {
            txtCode.Text = m_SelectedWarehouse.ID.ToString();
            txtName.Text = m_SelectedWarehouse.Name.ToString();
            txtAddress.Text = m_SelectedWarehouse.Address.ToString();
            txtPhone.Text = m_SelectedWarehouse.Phone.ToString();
            txtFax.Text = m_SelectedWarehouse.Fax.ToString();
        }

        private void ClearForm()
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtFax.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            m_SelectedWarehouse.ID = txtCode.Text;
            m_SelectedWarehouse.Name = txtName.Text;
            m_SelectedWarehouse.Address = txtAddress.Text;
            m_SelectedWarehouse.Phone = txtPhone.Text;
            m_SelectedWarehouse.Fax = txtFax.Text;
            m_SelectedWarehouse.isDefault = true;

            try
            {
                //set isdefault=false to all first
                IList<Warehouse> lst = WHDao.getAllRecords();
                foreach (Warehouse wh in lst)
                { 
                    wh.isDefault = false;
                    WHDao.Save(wh);
                }

                //update isdefault=true to selected warehouse
                WHDao.Save(m_SelectedWarehouse);
                MessageBox.Show("Warehouse Selected!", "Warehouse Select", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Warehouse Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.getMainForm().CloseCurrentControl();
        }

        private void ctlWarehouse_VisibleChanged(object sender, EventArgs e)
        {
            UserControl myUC = sender as UserControl;
            if (myUC.Visible)
                LoadWarehouseList();
        }

    }
}
