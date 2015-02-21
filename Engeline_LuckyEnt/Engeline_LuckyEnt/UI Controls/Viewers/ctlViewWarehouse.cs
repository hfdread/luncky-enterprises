#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
    public partial class ctlViewWarehouse : UserControl
    {
        private WarehouseDao WHDao = null;

        public ctlViewWarehouse()
        {
            InitializeComponent();
            WHDao = new WarehouseDao();
        }

        private enum eFlds
        {
            ID,
            Name,
            Address,
            Phone,
            Fax,
            Dirty
        }

        private void grdvWarehouse_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow row =  grdvWarehouse.GetDataRow(e.RowHandle);
            row[(int)eFlds.Dirty] = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IList<Warehouse> lst = new List<Warehouse>();

            foreach (DataRow row in tblData.Rows)
            {
                if (Convert.ToBoolean(row[(int)eFlds.Dirty].ToString()) == true)
                {
                    Warehouse wh = new Warehouse();
                    wh.ID = row[(int)eFlds.ID].ToString();
                    wh.Name = row[(int)eFlds.Name].ToString();
                    wh.Address = row[(int)eFlds.Address].ToString();
                    wh.Phone = row[(int)eFlds.Phone].ToString();
                    wh.Fax = row[(int)eFlds.Fax].ToString();
                    lst.Add(wh);
                    row[(int)eFlds.Dirty] = false;
                }
            }

            if (lst.Count > 0)
            {
                try
                {
                    WHDao.SaveBatch(lst);
                    clsUtil.ShowMessage("Warehouse saved!", "Save Warehouse", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    clsUtil.ShowMessageError("Error: " + ex.Message, "Save Warehouse");
                }
            }
           
        }

        private void ctlViewWarehouse_Load(object sender, EventArgs e)
        {
            IList<Warehouse> lst = WHDao.getAllRecords();
            foreach (Warehouse wh in lst)
            {
                tblData.Rows.Add(wh.ID, wh.Name, wh.Address, wh.Phone, wh.Fax, false);
            }
        }

        private void grdvWarehouse_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow row = grdvWarehouse.GetDataRow(e.RowHandle);

            if (row[(int)eFlds.ID].ToString().Trim() == "")
            {
                clsUtil.ShowMessageError("Invalid ID!", "Update Warehouse");
                e.Valid = false;
            }

            if (row[(int)eFlds.Name].ToString().Trim() == "")
            {
                clsUtil.ShowMessageError("Invalid Warehouse Name!", "Update Warehouse");
                e.Valid = false;
            }
        }

        private void grdvWarehouse_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow row = grdvWarehouse.GetDataRow(e.RowHandle);
            row[(int)eFlds.Dirty] = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsUtil.getMainForm().CloseCurrentControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow row = grdvWarehouse.GetDataRow(grdvWarehouse.FocusedRowHandle);
            if (row != null)
            {
                if (clsUtil.ShowMessageYesNo(string.Format("Are you sure you want to delete warehouse '{0}'?", row[(int)eFlds.Name].ToString()), "Delete Warehouse") == DialogResult.No)
                    return;
                Warehouse WH = WHDao.GetByName("ID", row[(Int32)eFlds.ID].ToString());
                try
                {
                    WHDao.Delete(WH);

                    //remove item from list
                    tblData.Rows.RemoveAt(grdvWarehouse.GetDataSourceRowIndex(grdvWarehouse.FocusedRowHandle));
                    grdWarehouse.RefreshDataSource();
                }
                catch (Exception ex)
                {
                    clsUtil.ShowMessageError(ex, "Delete Warehouse");
                }

            }
        }
    }
}
