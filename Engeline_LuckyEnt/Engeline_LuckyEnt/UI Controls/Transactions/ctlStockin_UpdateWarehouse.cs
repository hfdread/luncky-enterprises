#region
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.Forms;
using Engeline_LuckyEnt.UI_Controls.Viewers;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using DevExpress.XtraEditors;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
    public partial class ctlStockin_UpdateWarehouse : UserControl
    {
        private WarehouseDao WHDao = null;
        private Warehouse m_warehouse = null;

        public ctlStockIn stockin = null;

        public ctlStockin_UpdateWarehouse()
        {
            InitializeComponent();
            WHDao = new WarehouseDao();
            m_warehouse = new Warehouse();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            stockin.UpdateWarehouse(m_warehouse);
            this.ParentForm.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void ctlStockin_UpdateWarehouse_Load(object sender, EventArgs e)
        {
            IList<Warehouse> lstW = WHDao.getAllRecords();
            cboWarehouse.DataSource = lstW;
            m_warehouse = lstW[0];
        }

        private void cboWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            Warehouse W = (Warehouse)cboWarehouse.SelectedValue;
            if (null != W)
            {
                m_warehouse = W;
                ShowSelectedWarehouse();
            }
            else
            {
                ClearForm();
            }
        }

        private void ShowSelectedWarehouse()
        {
            txtCode.Text = m_warehouse.ID.ToString();
            txtName.Text = m_warehouse.Name.ToString();
            txtAddress.Text = m_warehouse.Address.ToString();
            txtPhone.Text = m_warehouse.Phone.ToString();
            txtFax.Text = m_warehouse.Fax.ToString();
        }

        private void ClearForm()
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtFax.Text = "";
        }
    }
}
