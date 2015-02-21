#region 

using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.Forms;
using Engeline_LuckyEnt.UI_Controls.Transactions;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
    public partial class ctlViewDamagedMissing : UserControl
    {
        private DamagedMissingDao dmDao = null;
        private ItemDao itemDao = null;
        private StockInDao siDao = null;
        private bool m_bIsLoading = true;

        public ctlViewDamagedMissing()
        {
            InitializeComponent();

            dmDao = new DamagedMissingDao();
            itemDao = new ItemDao();
            siDao = new StockInDao();
        }

        private void ctlViewDamagedMissing_Load(object sender, EventArgs e)
        {
            //get item list
            IList<Items> lstItem = itemDao.getAllRecords();
            cboItem.Properties.Items.Add("ALL");
            foreach (Items item in lstItem)
            {
                cboItem.Properties.Items.Add(item);
            }
            cboItem.SelectedIndex = 0;
            
            //get stockin list
            IList<StockIn> lstSI = siDao.getAllRecords();
            cboStockin.Properties.Items.Add("ALL");
            foreach(StockIn si in lstSI)
            {
                cboStockin.Properties.Items.Add(si.returnID());
            }
            cboStockin.SelectedIndex = 0;

            m_bIsLoading = false;
            btnRefresh.PerformClick();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string Type = cboType.SelectedItem.ToString();
            StockIn si = null;
            try
            {
                if (cboStockin.SelectedIndex != 0)
                {
                    int sID = Convert.ToInt32(cboStockin.SelectedItem);
                    si = siDao.GetById(sID);
                }
            }
            catch (Exception ex)
            {
                clsUtil.ShowMessageError("Invalid Stock In ID");
            }
            Items item = null;
            if (cboItem.SelectedIndex != 0)
            {
                try
                {
                    item = (Items)cboItem.SelectedItem;
                }
                catch (Exception ex)
                {
                    clsUtil.ShowMessageError(string.Format("No such item exist: {0}", cboItem.SelectedText),"Item Error!");
                }
            }

            IList<DamagedMissing> lstDM = dmDao.GetAllRecordsByCriteria(si, item, Type, dtRange.getDateFrom(), dtRange.getDateTo());
            grdDamagedMissing.DataSource = lstDM;
        }

        private void cboStockin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_bIsLoading)
                return;

            btnRefresh.PerformClick();
        }

        private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_bIsLoading)
                return;

            btnRefresh.PerformClick();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_bIsLoading)
                return;

            btnRefresh.PerformClick();
        }

        private void menu_stockin_Click(object sender, EventArgs e)
        {
            ctlViewDamagedMissing_Salvage ctl = new ctlViewDamagedMissing_Salvage();
            frmGenericPopup frm = new frmGenericPopup();

            ctl.m_DM = (DamagedMissing)grdvDamagedMissing.GetRow(grdvDamagedMissing.FocusedRowHandle);
            frm.Text = "Salvage Form";
            frm.ShowCtl(ctl);
        }

        private void dtRange_DateSelectionChanged(object sender, EventArgs e)
        {
            if (m_bIsLoading)
                return;

            btnRefresh.PerformClick();
        }
    }
}
