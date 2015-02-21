#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.UI_Controls.Transactions;
using Engeline_LuckyEnt.Forms;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
//using Engeline_LuckyEnt.Reports;
#endregion

namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
    public partial class ctlViewArriveShipment : UserControl
    {
        private StatementofAccountDao SOCDao = null;
        private StatementofAccount m_statement = null;
        private bool m_bIsLoading = true;

        private enum eCol
        {
            SOC_ID,
            Supplier,
            Shipping,
            VoyageNumber,
            BillofLeading,
            ItemObject
        }

        public ctlViewArriveShipment()
        {
            InitializeComponent();
            SOCDao = new StatementofAccountDao();
        }

        private void ctlViewArriveShipment_Load(object sender, EventArgs e)
        {
            m_statement = new StatementofAccount();
            m_bIsLoading = false;
            btnRefresh.PerformClick();
        }

        private void grdvSOC_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            StatementofAccount SOC = (StatementofAccount)grdvSOC.GetRow(e.RowHandle);

            if (e.IsGetData && e.Column.FieldName == "Shipping")
            {
                e.Value = SOC.ShippingCompany.CompanyName + "-" + SOC.ShipName;
            }

            if (e.IsGetData && e.Column.FieldName == "From")
            {
                e.Value = SOC.Supplier.CompanyName + "," + SOC.Supplier.FirstName + " " + SOC.Supplier.LastName;
            }

            if (e.IsGetData && e.Column.FieldName == "Paid")
            {
                if (SOC.Payment == 0)//paid
                    e.Value = true;
                else
                    e.Value = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            grdSOC.DataSource = SOCDao.GetAllArrivedShipment(dtRange.getDateFrom(), dtRange.getDateTo());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            clsUtil.getMainForm().CloseCurrentControl();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            StatementofAccount SOC = (StatementofAccount)grdvSOC.GetRow(grdvSOC.FocusedRowHandle);
            if (SOC != null)
            {
                ctlStateofAccounts ctl = new ctlStateofAccounts();

                ctl.SOC = SOC;
                clsUtil.getMainForm().LoadCtl(ctl, false, string.Format("SOC [{0}]", SOC.ID.ToString(clsUtil.FMT_ID)), "", false);
            }
        }

        private void dtRange_DateSelectionChanged(object sender, EventArgs e)
        {
            if (m_bIsLoading)
                return;

            if (dtRange.GetDateSelection() != ctlDateRange.eDateSelection.Custom)
                btnRefresh.PerformClick();
        }

        private void mnu_SetTrucking_Click(object sender, EventArgs e)
        {
            ctlViewArriveShipment_Trucking ctl = new ctlViewArriveShipment_Trucking();
            frmGenericPopup frm = new frmGenericPopup();
            StatementofAccount soc = (StatementofAccount)grdvSOC.GetRow(grdvSOC.FocusedRowHandle);
            ctl.soc_id = soc.ID;
            frm.Text = "Set Trucking";
            frm.ShowCtl(ctl);
        }
    }
}
