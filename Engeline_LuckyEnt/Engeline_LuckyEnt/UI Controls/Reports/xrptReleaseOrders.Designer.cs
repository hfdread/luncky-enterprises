namespace Engeline_LuckyEnt.UI_Controls.Reports
{
    partial class xrptReleaseOrders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrlblWarehouse = new DevExpress.XtraReports.UI.XRLabel();
            this.xrtblData = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPageBreak1 = new DevExpress.XtraReports.UI.XRPageBreak();
            this.xrlblReportTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblTruck = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblDriver = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrtblData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrlblWarehouse,
            this.xrtblData,
            this.xrPageBreak1,
            this.xrlblReportTitle,
            this.xrlblDate,
            this.xrlblTruck,
            this.xrlblDriver});
            this.Detail.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Detail.HeightF = 234.375F;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StylePriority.UseFont = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.Detail.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.Detail_BeforePrint);
            // 
            // xrlblWarehouse
            // 
            this.xrlblWarehouse.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrlblWarehouse.LocationFloat = new DevExpress.Utils.PointFloat(13.54167F, 152.0833F);
            this.xrlblWarehouse.Name = "xrlblWarehouse";
            this.xrlblWarehouse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblWarehouse.SizeF = new System.Drawing.SizeF(254.5138F, 23F);
            this.xrlblWarehouse.StylePriority.UseFont = false;
            this.xrlblWarehouse.Text = "xrlblTruck";
            // 
            // xrtblData
            // 
            this.xrtblData.LocationFloat = new DevExpress.Utils.PointFloat(57.29167F, 188.625F);
            this.xrtblData.Name = "xrtblData";
            this.xrtblData.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrtblData.SizeF = new System.Drawing.SizeF(579.3749F, 25F);
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "Item Name";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell1.Weight = 2.345631094719284D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "Total Qty";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell2.Weight = 0.89436856637865336D;
            // 
            // xrPageBreak1
            // 
            this.xrPageBreak1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 222.375F);
            this.xrPageBreak1.Name = "xrPageBreak1";
            // 
            // xrlblReportTitle
            // 
            this.xrlblReportTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrlblReportTitle.LocationFloat = new DevExpress.Utils.PointFloat(273.9583F, 0F);
            this.xrlblReportTitle.Name = "xrlblReportTitle";
            this.xrlblReportTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblReportTitle.SizeF = new System.Drawing.SizeF(253.1251F, 29.25F);
            this.xrlblReportTitle.StylePriority.UseFont = false;
            this.xrlblReportTitle.StylePriority.UseTextAlignment = false;
            this.xrlblReportTitle.Text = "xrlblReportTitle";
            this.xrlblReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrlblDate
            // 
            this.xrlblDate.LocationFloat = new DevExpress.Utils.PointFloat(13.54167F, 34.79166F);
            this.xrlblDate.Name = "xrlblDate";
            this.xrlblDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblDate.SizeF = new System.Drawing.SizeF(207.2917F, 23F);
            this.xrlblDate.Text = "xrlblDate";
            // 
            // xrlblTruck
            // 
            this.xrlblTruck.LocationFloat = new DevExpress.Utils.PointFloat(351.0417F, 75.95834F);
            this.xrlblTruck.Name = "xrlblTruck";
            this.xrlblTruck.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblTruck.SizeF = new System.Drawing.SizeF(254.5138F, 23F);
            this.xrlblTruck.Text = "xrlblTruck";
            // 
            // xrlblDriver
            // 
            this.xrlblDriver.LocationFloat = new DevExpress.Utils.PointFloat(13.54167F, 75.95834F);
            this.xrlblDriver.Name = "xrlblDriver";
            this.xrlblDriver.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrlblDriver.SizeF = new System.Drawing.SizeF(295.8333F, 23F);
            this.xrlblDriver.Text = "xrlblDriver";
            // 
            // TopMargin
            // 
            this.TopMargin.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopMargin.HeightF = 119F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.StylePriority.UseFont = false;
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageFooter
            // 
            this.PageFooter.Name = "PageFooter";
            // 
            // xrptReleaseOrders
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageFooter});
            this.Margins = new System.Drawing.Printing.Margins(63, 67, 119, 100);
            this.Version = "11.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrtblData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        public DevExpress.XtraReports.UI.XRLabel xrlblDriver;
        public DevExpress.XtraReports.UI.XRLabel xrlblTruck;
        public DevExpress.XtraReports.UI.XRLabel xrlblReportTitle;
        public DevExpress.XtraReports.UI.XRLabel xrlblDate;
        public DevExpress.XtraReports.UI.XRLabel xrlblWarehouse;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRPageBreak xrPageBreak1;
        public DevExpress.XtraReports.UI.XRTable xrtblData;
    }
}
