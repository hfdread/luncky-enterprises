#region

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

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Utilities
{
    public partial class ctlShipping : UserControl
    {
        private ShippingDao shipDao = null;
        private Shipping m_shipping = null;

        private enum eFlds
        {
            ID,
            CompanyName,
            Contact1,
            Contact2,
            Dirty
        }

        public ctlShipping()
        {
            InitializeComponent();
            shipDao = new ShippingDao();
            m_shipping = new Shipping();
        }

        private void ctlShipping_Load(object sender, EventArgs e)
        {
            LoadShippers();
        }

        private void LoadShippers()
        {
            IList<Shipping> lst = shipDao.getAllRecords();
            foreach (Shipping S in lst)
            {
                tblData.Rows.Add(S.ID, S.CompanyName, S.Contact1, S.Contact2, false);
            }
        }

        private void grdvShipping_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow row = grdvShipping.GetDataRow(e.RowHandle);
            row[(int)eFlds.Dirty] = true;
        }

        private void grdvShipping_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow row = grdvShipping.GetDataRow(e.RowHandle);
            row[(int)eFlds.Dirty] = true;
        }

        private void grdvShipping_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow row = grdvShipping.GetDataRow(e.RowHandle);
            if (row[(int)eFlds.CompanyName].ToString().Trim() == "")
            {
                clsUtil.ShowMessageError("Invalid Company Name!", "Update Shipping");
                e.Valid = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow row = grdvShipping.GetDataRow(grdvShipping.FocusedRowHandle);
            if (row != null)
            {
                if (clsUtil.ShowMessageYesNo(string.Format("Are you sure you want to delete Shipping '{0}'?", row[(int)eFlds.CompanyName].ToString()), "Delete Shipping") == DialogResult.No)
                    return;
                Shipping ship = shipDao.GetById(Convert.ToInt32(row[(Int32)eFlds.ID].ToString()));
                try
                {
                    shipDao.Delete(ship);

                    //remove from list
                    tblData.Rows.RemoveAt(grdvShipping.GetDataSourceRowIndex(grdvShipping.FocusedRowHandle));
                    grdShipping.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    clsUtil.ShowMessageError(ex, "Delete Shipping");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IList<Shipping> lst = new List<Shipping>();

            foreach (DataRow row in tblData.Rows)
            {
                if (Convert.ToBoolean(row[(int)eFlds.Dirty].ToString()) == true)
                {
                    Shipping ship = new Shipping();
                    ship.ID = clsUtil.ParseInt32(row[(int)eFlds.ID].ToString());
                    ship.CompanyName = row[(int)eFlds.CompanyName].ToString();
                    ship.Contact1 = row[(int)eFlds.Contact1].ToString();
                    ship.Contact2 = row[(int)eFlds.Contact2].ToString();
                    lst.Add(ship);
                    row[(int)eFlds.Dirty] = false;
                }
            }

            if (lst.Count > 0)
            {
                try
                {
                    shipDao.SaveBatch(lst);
                    clsUtil.ShowMessage("Shipping saved!", "Save Shipping", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    clsUtil.ShowMessageError("Error: " + ex.Message, "Save Shipping");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsUtil.getMainForm().CloseCurrentControl();
        }
    }
}
