#region

using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.Forms;
using Engeline_LuckyEnt.UI_Controls.Viewers;
using Engeline_LuckyEnt.UI_Controls.Reports;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using DevExpress.XtraReports.UI;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
    public partial class ctlReleaseOrder : UserControl
    {
        private ReleaseOrderDao roDao = null;
        private SalesInvoiceDao sivDao = null;
        private SalesInvoiceDetailsDao sivd_Dao = null;

        public ctlReleaseOrder()
        {
            InitializeComponent();
            roDao = new ReleaseOrderDao();
            sivDao = new SalesInvoiceDao();
            sivd_Dao = new SalesInvoiceDetailsDao();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clsUtil.getMainForm().CloseCurrentControl();
        }

        private void RefreshGridDataSource()
        {
            string DRList = "";
            DRList = roDao.GetDRList(DRList);
            IList<SalesInvoice> lstSIV = roDao.GetPendingDRs(DRList);
            tblData.Rows.Clear();
            foreach (SalesInvoice siv in lstSIV)
            {
                tblData.Rows.Add(false, siv.ID, siv.Customer, siv.AmountDue, siv.InvoiceDate);
            }
            grdDRItems.DataSource = tblData;
        }

        private void ctlReleaseOrder_Load(object sender, EventArgs e)
        {
            RefreshGridDataSource();
        }

        private void grdvDRItems_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.IsGetData && e.Column.FieldName == "bSelected")
            {
                e.Value = false;
            }
        }

        private void btnCreateRO_Click(object sender, EventArgs e)
        {
            if (CheckSelectedItem())
            {
                btnCreateRO.Enabled = false;
                btnCancel.Enabled = false;
                txtDriver.Text = "";
                txtNotes.Text = "";
                txtTruck.Text = "";
                popup1.Visible = true;
            }
            else
            {
                clsUtil.ShowMessageInformation("No DR selected!", "Release Order");
            }
        }

        private bool CheckSelectedItem()
        {
            bool b_isValid = false;
            for (int index = 0; index < tblData.Rows.Count; index++)
            {
                DataRow row = grdvDRItems.GetDataRow(index);
                if (Convert.ToBoolean(row["Checkbox"].ToString()))
                {
                    b_isValid = true;
                    break;
                }
            }

            return b_isValid;
        }

        private bool ValidateInput()
        {
            if (txtDriver.Text.Trim() != "" && txtTruck.Text.Trim() != "")
            {
                return true;
            }
            else
            {
                clsUtil.ShowMessageInformation("Driver and Truck should be stated when creating a Release Order!", "Release Order");
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (clsUtil.ShowMessageYesNo("Are you sure you want to creat Release Order for the selected items?", "Release Order")
                        == DialogResult.Yes)
                {
                    string DRlist = "";
                    for (int iIndex = 0; iIndex < tblData.Rows.Count; iIndex++)
                    {
                        DataRow row = grdvDRItems.GetDataRow(iIndex);
                        if (Convert.ToBoolean(row["Checkbox"].ToString()))
                        {
                            DRlist += string.Format("{0},", Convert.ToInt32(row["DR"].ToString()));
                        }
                    }

                    //1 ro per warehouse
                    IList<SalesInvoiceDetails> lstDetails = sivd_Dao.GetDRDetails(DRlist);
                    List<rptReleaseOrder> lstReport = new List<rptReleaseOrder>();
                   

                    foreach (SalesInvoiceDetails sivd in lstDetails)
                    {
                        rptReleaseOrder report = new rptReleaseOrder();
                        report.DR = sivd.salesinvoice.ID.ToString(clsUtil.FMT_ID);
                        report.itemName = string.Format("{0},{1}", sivd.item.Name, sivd.item.Description);
                        report.QTY = sivd.QTY1;
                        report.Unit = sivd.item.Unit;
                        report.WHName = sivd_Dao.GetWarehouseForReleaseOrder(sivd);

                        lstReport.Add(report);
                    }

                    lstReport.Sort(delegate(rptReleaseOrder r1, rptReleaseOrder r2) { return r1.WHName.CompareTo(r2.WHName); });
                    ReleaseOrder releaseOrderWarehouse = new ReleaseOrder();
                    IList<ReleaseOrder> lstReleaseOrder = new List<ReleaseOrder>();

                    string warehouse = "";
                    releaseOrderWarehouse.item = new List<Items>();
                    foreach (rptReleaseOrder rptRO in lstReport)
                    {
                        if (warehouse != "" && warehouse != rptRO.WHName)
                        {
                            lstReleaseOrder.Add(releaseOrderWarehouse);
                            releaseOrderWarehouse = null;
                            releaseOrderWarehouse = new ReleaseOrder();
                            releaseOrderWarehouse.item = new List<Items>();
                        }

                        releaseOrderWarehouse.DR_Number += rptRO.DR + ",";
                        releaseOrderWarehouse.Driver = txtDriver.Text;
                        releaseOrderWarehouse.Trx_Date = DateTime.Now;
                        releaseOrderWarehouse.Truck = txtTruck.Text;
                        releaseOrderWarehouse.Notes = txtNotes.Text;
                        releaseOrderWarehouse.Warehouse = rptRO.WHName;

                        Items i = new Items();
                        i.Name = rptRO.itemName;
                        i.totalQty = rptRO.QTY;

                        releaseOrderWarehouse.item.Add(i);

                        warehouse = rptRO.WHName;
                    }
                    //add last item
                    lstReleaseOrder.Add(releaseOrderWarehouse);

                    try
                    {
                        IList<ReleaseOrder> newListRO = new List<ReleaseOrder>();
                        foreach (ReleaseOrder ro in lstReleaseOrder)
                        {
                            roDao.Save(ro);
                            newListRO.Add(ro);
                        }
                        clsUtil.ShowMessageInformation("Successfully Created Release Order. Press 'OK' to see the printable Form", "Release Order");

                        //xrptReleaseOrders rptRO = new xrptReleaseOrders();
                        //rptRO.ro = ro;
                        //rptRO.ShowPreviewDialog();
                        CreateReleaseOrderForm(newListRO);
                        

                        RefreshGridDataSource();
                        btnCreateRO.Enabled = true;
                        btnCancel.Enabled = true;
                        popup1.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        clsUtil.ShowMessageError(string.Format("Error:\n{0}", ex.Message), "Release Order");
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnCreateRO.Enabled = true;
            btnCancel.Enabled = true;
            popup1.Visible = false;
        }

        private void CreateReleaseOrderForm(IList<ReleaseOrder> lstro)
        {
           IList<xrptReleaseOrders> rptList = new List<xrptReleaseOrders>();
            //rptMain.CreateDocument();

            foreach (ReleaseOrder ro in lstro)
            {
                xrptReleaseOrders reportRO = new xrptReleaseOrders();

                reportRO.xrlblReportTitle.Text = string.Format("Release Order: {0}", ro.ID.ToString(clsUtil.FMT_ID));
                reportRO.xrlblDate.Text = string.Format("Date: {0}", DateTime.Today.ToString());
                reportRO.xrlblDriver.Text = string.Format("Driver: {0}", ro.Driver);
                reportRO.xrlblTruck.Text = string.Format("Truck: {0}", ro.Truck);
                reportRO.xrlblWarehouse.Text = string.Format("Warehouse: {0}", ro.Warehouse);

                string itemName = "";
                Int32 totalQty = 0, nCount=1;
                foreach (Items i in ro.item)
                {
                    XRTableRow row = new XRTableRow();
                    XRTableCell cell1 = new XRTableCell();
                    XRTableCell cell2 = new XRTableCell();
                    if (itemName != "" && itemName != i.Name)
                    {
                        cell1.Text = itemName;
                        cell2.Text = totalQty.ToString();

                        row.Cells.Add(cell1);
                        row.Cells.Add(cell2);

                        reportRO.xrtblData.Rows.Add(row);
                        totalQty = 0;
                    }

                    itemName = i.Name;
                    totalQty += i.totalQty;

                    if (nCount == ro.item.Count)
                    {
                        XRTableRow rowx = new XRTableRow();
                        XRTableCell cell1x = new XRTableCell();
                        XRTableCell cell2x = new XRTableCell();

                        cell1x.Text = itemName;
                        cell2x.Text = totalQty.ToString();

                        rowx.Cells.Add(cell1x);
                        rowx.Cells.Add(cell2x);

                        reportRO.xrtblData.Rows.Add(rowx);
                    }

                    nCount += 1;
                }
                
                reportRO.CreateDocument();
                rptList.Add(reportRO);
            }


            for (int i = 1; i < lstro.Count; i++)
            {
                rptList[0].Pages.AddRange(rptList[i].Pages);
            }

            rptList[0].PrintingSystem.ContinuousPageNumbering = true;
            ReportPrintTool printTool = new ReportPrintTool(rptList[0]);
            printTool.ShowPreviewDialog();
        }

        private PointF setLocation(float X, float Y)
        {
            return new PointF(X, Y);
        }
    }
}
