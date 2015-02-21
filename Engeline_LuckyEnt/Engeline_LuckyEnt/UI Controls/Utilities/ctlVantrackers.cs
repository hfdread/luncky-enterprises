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
    public partial class ctlVantrackers : UserControl
    {
        private VantrackersDao mVantrackersDao = null;

        private enum eFlds
        {
            ID,
            VanName,
            Dirty
        }

        public ctlVantrackers()
        {
            InitializeComponent();
            mVantrackersDao = new VantrackersDao();
        }

        private void ctlVantrackers_Load(object sender, EventArgs e)
        {
            IList<Vantrackers> lstVan = mVantrackersDao.getAllRecords();
            foreach (Vantrackers v in lstVan)
            {
                tblData.Rows.Add(v.ID, v.VanName, false);
            }
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow row = gridView1.GetDataRow(e.RowHandle);
            row[(int)eFlds.Dirty] = true;
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow row = gridView1.GetDataRow(e.RowHandle);
            if (row[(int)eFlds.VanName].ToString().Trim() == "")
            {
                clsUtil.ShowMessageError("Invalid Van Name!", "Update Van");
                e.Valid = false;
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow row = gridView1.GetDataRow(e.RowHandle);
            row[(int)eFlds.Dirty] = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (row != null)
            {
                if (clsUtil.ShowMessageYesNo(string.Format("Are you sure you want to delete van '{0}'?", row[(int)eFlds.VanName].ToString()), "Delete Van") == DialogResult.No)
                    return;

                Int32 selID = Convert.ToInt32(row[(Int32)eFlds.ID].ToString());
                Vantrackers van = mVantrackersDao.GetById(selID);
                try
                {
                    mVantrackersDao.Delete(van);

                    //remove from list
                    tblData.Rows.RemoveAt(gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle));
                    grdVans.RefreshDataSource();
                }
                catch(Exception ex)
                {
                    clsUtil.ShowMessageError(ex, "Delete Warehouse");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsUtil.getMainForm().CloseCurrentControl();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IList<Vantrackers> lst = new List<Vantrackers>();

            foreach (DataRow row in tblData.Rows)
            {
                if (Convert.ToBoolean(row[(int)eFlds.Dirty].ToString()) == true)
                {
                    Vantrackers van = new Vantrackers();
                    van.VanName = row[(int)eFlds.VanName].ToString();
                    lst.Add(van);
                    row[(int)eFlds.Dirty] = false;
                }
            }

            if (lst.Count > 0)
            {
                try
                {
                    mVantrackersDao.SaveBatch(lst);
                    clsUtil.ShowMessage("Van saved!", "Save Van", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    clsUtil.ShowMessageError("Error: " + ex.Message, "Save Van");
                }
            }
        }
    }
}
