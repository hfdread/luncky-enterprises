#region

using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using Engeline_LuckyEnt.Forms;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.UI_Controls;
using Engeline_LuckyEnt.UI_Controls.Utilities;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Viewers
{
    public partial class ctlViewArriveShipment_Trucking : UserControl
    {
        private StatementofAccountDao socDao = null;
        private StatementofAccount SOC = null;
        private StatementofAccountDetailsDao socdDao = null;
        public int soc_id { get; set; }

        public ctlViewArriveShipment_Trucking()
        {
            InitializeComponent();

            socDao = new StatementofAccountDao();
            socdDao = new StatementofAccountDetailsDao();
            SOC = new StatementofAccount();
        }

        private void ctlViewArriveShipment_Trucking_Load(object sender, EventArgs e)
        {
            if (soc_id > 0)
            {
                SOC = socDao.GetById(soc_id);
                txtInvoiceNo.Text = SOC.ID.ToString(clsUtil.FMT_ID);
                grdVans.DataSource = socdDao.GetDetailsByVan(SOC);
            }
        }

        private void grdvVans_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            StatementofAccountDetails details = (StatementofAccountDetails)grdvVans.GetRow(e.RowHandle);

            if (e.IsGetData && e.Column.FieldName == "Trucking")
            {
                e.Value = details.VanTracker;
            }

            if (e.IsGetData && e.Column.FieldName == "Destination")
            {
                if (details.WhDestination == null)
                    e.Value = details.CustomerDestination;

                if (details.CustomerDestination == null)
                    e.Value = details.WhDestination;

                if(details.CustomerDestination == null && details.WhDestination == null)
                    e.Value = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void mnu_Trucking_Click(object sender, EventArgs e)
        {
            ctlTrucking ctl = new ctlTrucking();
            frmGenericPopup frm = new frmGenericPopup();
            StatementofAccountDetails details = (StatementofAccountDetails) grdvVans.GetFocusedRow();

            if (grdvVans.SelectedRowsCount > 1)
            {
                foreach (int rowID in grdvVans.GetSelectedRows())
                {
                    StatementofAccountDetails xsocd = (StatementofAccountDetails)grdvVans.GetRow(rowID);
                    ctl.VanNumber += xsocd.VanNumber + ",";
                }

                ctl.VanNumber = ctl.VanNumber.Remove(ctl.VanNumber.LastIndexOf(","));
            }
            else
            {
                ctl.VanNumber = details.VanNumber;
            }

            
            ctl.trucking = this;
            frm.Text = "Select Trucking";
            frm.ShowCtl(ctl);
        }

        private void mnu_Destination_Click(object sender, EventArgs e)
        {
            ctlDestination ctl = new ctlDestination();
            frmGenericPopup frm = new frmGenericPopup();
            StatementofAccountDetails details = (StatementofAccountDetails)grdvVans.GetFocusedRow();

            if (grdvVans.SelectedRowsCount > 1)
            {
                foreach (int rowID in grdvVans.GetSelectedRows())
                {
                    StatementofAccountDetails xsocd = (StatementofAccountDetails)grdvVans.GetRow(rowID);
                    ctl.VanNumber += xsocd.VanNumber + ","; 
                }

                ctl.VanNumber = ctl.VanNumber.Remove(ctl.VanNumber.LastIndexOf(","));
            }
            else
            {
                ctl.VanNumber = details.VanNumber;
            }

            ctl.trucking = this;
            frm.Text = "Select Destination";
            frm.ShowCtl(ctl);
        }

        public void setTrucking(Vantrackers v, string VanNumber )
        {
            StatementofAccount newSOC = new StatementofAccount();

            char[] separator = {','};

            foreach (StatementofAccountDetails socd in SOC.details)
            {
                if (VanNumber.IndexOf(',') > 0)
                {
                    foreach (string van in VanNumber.Split(separator))
                    {
                        if (socd.VanNumber == van)
                            socd.VanTracker = v;
                    }
                }
                else
                {
                    if (socd.VanNumber == VanNumber)
                        socd.VanTracker = v;
                }

                newSOC.details.Add(socd);
            }

            SOC.details.Clear();
            SOC.details = newSOC.details;

            AssignDataSource(SOC);
        }

        public void setDestination(Contacts c, string VanNumber)
        {
            StatementofAccount newSOC = new StatementofAccount();

            char[] separator = { ',' };

            foreach (StatementofAccountDetails socd in SOC.details)
            {
                if (VanNumber.IndexOf(',') > 0)
                {
                    foreach (string van in VanNumber.Split(separator))
                    {
                        if (socd.VanNumber == van)
                        {
                            socd.CustomerDestination = c;
                            socd.WhDestination = null;
                        }
                    }
                }
                else
                {
                    if (socd.VanNumber == VanNumber)
                    {
                        socd.CustomerDestination = c;
                        socd.WhDestination = null;
                    }
                }

                newSOC.details.Add(socd);
            }

            SOC.details.Clear();
            SOC.details = newSOC.details;

            AssignDataSource(SOC);
        }

        public void setDestination(Warehouse w, string VanNumber)
        {
            StatementofAccount newSOC = new StatementofAccount();
            char[] separator = { ',' };

            foreach (StatementofAccountDetails socd in SOC.details)
            {
                if (VanNumber.IndexOf(',') > 0)
                {
                    foreach (string van in VanNumber.Split(separator))
                    {
                        if (socd.VanNumber == van)
                        {
                            socd.WhDestination = w;
                            socd.CustomerDestination = null;
                        }
                    }
                }
                else
                {
                    if (socd.VanNumber == VanNumber)
                    {
                        socd.WhDestination = w;
                        socd.CustomerDestination = null;
                    }
                }

                newSOC.details.Add(socd);
            }

            SOC.details.Clear();
            SOC.details = newSOC.details;

            AssignDataSource(SOC);
        }
       
        private void AssignDataSource(StatementofAccount soc)
        {
            IList<StatementofAccountDetails> lstDetails = new List<StatementofAccountDetails>();
            //grdVans.DataSource = socdDao.GetDetailsByVan(SOC);
            string VanNumber = "";
            foreach (StatementofAccountDetails details in soc.details)
            {
                if (VanNumber != details.VanNumber)
                {
                    lstDetails.Add(details);
                    VanNumber = details.VanNumber;
                }
            }

            grdVans.DataSource = lstDetails;
            grdVans.RefreshDataSource();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                socDao.Save(SOC);
                clsUtil.ShowMessageInformation("Trucking successfully Saved!", "Select Trucking");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Select Trucking", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
