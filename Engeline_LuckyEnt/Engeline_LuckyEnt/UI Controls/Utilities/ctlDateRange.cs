#region

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Engeline_LuckyEnt.UI_Controls
{
   public partial class ctlDateRange : UserControl
   {
      private const int HEIGHT = 28;
      private const int WIDTH = 442;

      public enum eDateSelection
      {
         Today = 0,
         Yesterday,
         ThisWeek,
         LastWeek,
         ThisMonth,
         LastMonth,
         ThisYear,
         LastYear,
         Custom
      }

      private eDateSelection m_DateSelection = eDateSelection.Today;

      public ctlDateRange()
      {
         InitializeComponent();

         cboRange.Items.Add("Today");
         cboRange.Items.Add("Yesterday");
         cboRange.Items.Add("This Week");
         cboRange.Items.Add("Last Week");
         cboRange.Items.Add("This Month");
         cboRange.Items.Add("Last Month");
         cboRange.Items.Add("This Year");
         cboRange.Items.Add("Last Year");
         cboRange.Items.Add("Custom");
      }

      public event EventHandler DateSelectionChanged
      {
         add { cboRange.SelectedIndexChanged += value; }
         remove { cboRange.SelectedIndexChanged -= value; }
      }

      private void ctlDateRange_Load(object sender, EventArgs e)
      {
         SetDateSelection(eDateSelection.Today);
      }

      public DateTime getDateFrom()
      {
         return Convert.ToDateTime(dtpDateFrom.Value.ToString("MMM dd, yyyy") + " 12:00 AM");
      }

      public DateTime getDateTo()
      {
         return Convert.ToDateTime(dtpDateTo.Value.ToString("MMM dd, yyyy") + " 11:59:59 PM");
      }

      public string GetDateRange(string sFormat="")
      {
         string ret = "";
         if (sFormat == "")
            sFormat = "MMM dd, yyyy";

         switch (m_DateSelection)
         {            
            case eDateSelection.Today:
            case eDateSelection.Yesterday:
               return dtpDateFrom.Value.ToString("MMM dd, yyyy");
            case eDateSelection.ThisMonth:
            case eDateSelection.LastMonth:
               return dtpDateFrom.Value.ToString("yyyy MMMMM");
            case eDateSelection.ThisYear:
            case eDateSelection.LastYear:
               return dtpDateFrom.Value.ToString("yyyy");
            default:
               return dtpDateFrom.Value.ToString("MMM dd, yyyy");
         }
         return ret;
      }

      public bool IsValidRange()
      {
         return dtpDateFrom.Value.Date <= dtpDateTo.Value.Date;
      }

      public eDateSelection GetDateSelection()
      {
         return m_DateSelection;
      }

      public void SetDateSelection(eDateSelection eSel)
      {
         m_DateSelection = eSel;
         cboRange.SelectedIndex = (int) eSel;
         //switch (eSel)
         //{ 
         //    case eDateSelection.Today:
         //        cboRange.Text = "Today";
         //        break;
         //    case eDateSelection.Yesterday:
         //        cboRange.Text = "Yesterday";
         //        break;
         //    case eDateSelection.ThisWeek:
         //        cboRange.Text = "This Week";
         //        break;
         //    case eDateSelection.LastWeek:
         //        cboRange.Text = "Last Week";
         //        break;
         //    case eDateSelection.ThisMonth:
         //        cboRange.Text = "This Month";
         //        break;
         //    case eDateSelection.LastMonth:
         //        cboRange.Text = "Last Month";
         //        break;
         //    case eDateSelection.ThisYear:
         //        cboRange.Text = "This Year";
         //        break;
         //    case eDateSelection.LastYear:
         //        cboRange.Text = "Last Year";
         //        break;
         //    case eDateSelection.Custom:
         //        cboRange.Text = "Custom";
         //        break;
         //}
      }

      private void cboRange_SelectedIndexChanged(object sender, EventArgs e)
      {
         bool bEnable = false;
         DateTime dtNow = DateTime.Now.Date;
         int iDaysOfMonth = 0;

         if (cboRange.SelectedIndex == -1)
            cboRange.SelectedIndex = 0;

         switch (cboRange.Text)
         {
            case "Today":
               dtpDateFrom.Value = dtNow;
               dtpDateTo.Value = dtNow;
               break;
            case "Yesterday":
               dtpDateFrom.Value = dtNow.AddDays(-1);
               dtpDateTo.Value = dtpDateFrom.Value;
               break;
            case "This Week":
               dtpDateFrom.Value = dtNow.AddDays((int) (dtNow.DayOfWeek - DayOfWeek.Monday)*-1);
               dtpDateTo.Value = dtpDateFrom.Value.AddDays(6);
               break;
            case "Last Week":
               dtpDateFrom.Value = dtNow.AddDays(((int) (dtNow.DayOfWeek - DayOfWeek.Monday)*-1) - 7);
               dtpDateTo.Value = dtpDateFrom.Value.AddDays(6);
               break;
            case "This Month":
               iDaysOfMonth = DateTime.DaysInMonth(dtNow.Year, dtNow.Month);
               dtpDateFrom.Value =
                  DateTime.Parse(string.Format("{0} 1, {1} 12:00 AM", dtNow.ToString("MMM"), dtNow.Year));
               dtpDateTo.Value =
                  DateTime.Parse(string.Format("{0} {1}, {2} 12:00 AM", dtNow.ToString("MMM"), iDaysOfMonth, dtNow.Year));
               ;
               break;
            case "Last Month":
               dtNow = dtNow.AddMonths(-1);
               iDaysOfMonth = DateTime.DaysInMonth(dtNow.Year, dtNow.Month);
               dtpDateFrom.Value =
                  DateTime.Parse(string.Format("{0} 1, {1} 12:00 AM", dtNow.ToString("MMM"), dtNow.Year));
               dtpDateTo.Value =
                  DateTime.Parse(string.Format("{0} {1}, {2} 12:00 AM", dtNow.ToString("MMM"), iDaysOfMonth, dtNow.Year));
               ;
               break;
            case "This Year":
               dtNow = DateTime.Parse(string.Format("Dec 1, {0} 12:00 AM", (int) DateTime.Now.Year));
               iDaysOfMonth = DateTime.DaysInMonth(dtNow.Year, dtNow.Month);

               dtpDateFrom.Value = DateTime.Parse(string.Format("Jan 1, {0} 12:00 AM", dtNow.Year));
               dtpDateTo.Value = DateTime.Parse(string.Format("Dec {0}, {1} 12:00 AM", iDaysOfMonth, dtNow.Year));
               ;
               break;
            case "Last Year":
               dtNow = DateTime.Parse(string.Format("Dec 1, {0} 12:00 AM", (int) DateTime.Now.AddYears(-1).Year));
               iDaysOfMonth = DateTime.DaysInMonth(dtNow.Year, dtNow.Month);

               dtpDateFrom.Value = DateTime.Parse(string.Format("Jan 1, {0} 12:00 AM", dtNow.Year));
               dtpDateTo.Value = DateTime.Parse(string.Format("Dec {0}, {1} 12:00 AM", iDaysOfMonth, dtNow.Year));
               ;
               break;
            case "Custom":
               dtpDateFrom.Value = DateTime.Now.Date;
               dtpDateTo.Value = DateTime.Now.Date;
               bEnable = true;
               break;
         }

         m_DateSelection = (eDateSelection) cboRange.SelectedIndex;

         dtpDateTo.Enabled = bEnable;
         dtpDateFrom.Enabled = bEnable;
      }

      private void ctlDateRange_Resize(object sender, EventArgs e)
      {
         this.Size = new Size(WIDTH, HEIGHT);
      }

      public void SetDateFrom(DateTime from)
      {
         dtpDateFrom.Value = from.Date;
      }

      public void SetDateTo(DateTime to)
      {
         dtpDateTo.Value = to.Date;
      }

      public void DisableCustomDate()
      {
         int index = cboRange.Items.IndexOf("Custom");
         if(index>=0)
         {
            cboRange.Items.RemoveAt(index);
         }
      }
   }
}