#region

using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.Forms;
using Engeline_LuckyEnt.UI_Controls.Transactions;
using Engeline_LuckyEnt.UI_Controls.Viewers;
using MyHibernate.DataAccessLayer;
using MyHibernate.BusinessObjects;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Reports
{
    public partial class xrptReleaseOrders : DevExpress.XtraReports.UI.XtraReport
    {
        private ReleaseOrderDao roDao = null;
        private SalesInvoiceDetailsDao sivd_dao = null;

        public ReleaseOrder ro { get; set; }

        public xrptReleaseOrders()
        {
            InitializeComponent();
            roDao = new ReleaseOrderDao();
            sivd_dao = new SalesInvoiceDetailsDao();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //xrlblReportTitle.Text = string.Format("Release Order: {0}", ro.ID.ToString(clsUtil.FMT_ID));
            //xrlblDate.Text = string.Format("Date: {0}", DateTime.Today.ToString());
            //xrlblDriver.Text = string.Format("Driver: {0}", ro.Driver);
            //xrlblTruck.Text = string.Format("Truck: {0}", ro.Truck);

            //IList<SalesInvoiceDetails> lstDetails = sivd_dao.GetDRDetails(ro.DR_Number);
            //List<rptReleaseOrder> lstReport = new List<rptReleaseOrder>();

            //foreach (SalesInvoiceDetails sivd in lstDetails)
            //{
            //    rptReleaseOrder report = new rptReleaseOrder();
            //    report.DR = sivd.salesinvoice.ID.ToString(clsUtil.FMT_ID);
            //    report.itemName =string.Format("{0},{1}",sivd.item.Name, sivd.item.Description);
            //    report.QTY = sivd.QTY1;
            //    report.Unit = sivd.item.Unit;
            //    report.WHName = sivd_dao.GetWarehouseForReleaseOrder(sivd);

            //    lstReport.Add(report);
            //}

            //lstReport.Sort(delegate(rptReleaseOrder r1, rptReleaseOrder r2) { return r1.WHName.CompareTo(r2.WHName); });

            
            //foreach (rptReleaseOrder xReport in lstReport)
            //{
            //    XRTableRow row = new XRTableRow();
            //    XRTableCell cell1 = new XRTableCell();
            //    XRTableCell cell2 = new XRTableCell();
            //    XRTableCell cell3 = new XRTableCell();

            //    xrlblWarehouse.Text = xReport.WHName;
            //    cell1.Text = xReport.WHName;
            //    cell2.Text = string.Format("{0} - {1} {2}", xReport.itemName, xReport.QTY, xReport.Unit);
            //    cell3.Text = xReport.DR;

            //    row.Cells.Add(cell1);
            //    row.Cells.Add(cell2);
            //    row.Cells.Add(cell3);

            //    xrtblData.BeginInit();
            //        xrtblData.Rows.Add(row);
            //    xrtblData.EndInit();


            //    this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            //}
            

            
        }
    }
}