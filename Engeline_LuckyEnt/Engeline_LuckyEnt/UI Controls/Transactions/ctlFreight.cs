#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
   public partial class ctlFreight : UserControl
   {
      private FreightDao FreightDao = new FreightDao();
      private StockInDao StockInDao = new StockInDao();

      public object PreviousCtl { get; set; }
      public Freight freight { get; set; }
      public bool Canceled { get; set; }
      public IList<StockIn> m_lstStockIn { get; set; }

      public ctlFreight()
      {
         InitializeComponent();
         Canceled = false;
      }

      private void ctlFreight_Load(object sender, EventArgs e)
      {
         if (freight != null)
         {
            m_lstStockIn = FreightDao.GetAllStockInByFreightID(freight.ID);
            foreach (StockIn si in m_lstStockIn)
            {
               si.Selected = true;
            }
            grdSI.DataSource = m_lstStockIn;

            lblFreightID.Text = freight.ID.ToString("000");
            txtFreightAmount.Text = freight.Total_Amount.ToString("#,##0.00");
            txtSIAmount.Text = freight.SI_Amount.ToString("#,##0.00");
         }
         else
         {
            lblFreightID.Text = "xxx";
            txtFreightAmount.Focus();

            //show StockIn
            grdSI.DataSource = m_lstStockIn;
         }
      }

      private void grdvSI_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
      {
         grdvSI.UpdateCurrentRow();
      }

      private void grdvSI_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
      {
         UpdateDisplay();
      }

      private void UpdateDisplay()
      {
         txtSIAmount.Text = ComputeTotal().ToString("#,##0.00");

         double AmountFreight, AmountSI;
         AmountFreight = clsUtil.CheckValue(txtFreightAmount);
         AmountSI = clsUtil.CheckValue(txtSIAmount);

         if (AmountFreight == 0 || AmountSI == 0)
            txtFreightPercent.Text = "0.00%";
         else
            txtFreightPercent.Text = string.Format("{0}%", (AmountFreight/AmountSI*100).ToString("0.00"));
      }

      private double ComputeTotal()
      {
         double Total = 0;
         foreach (StockIn si in m_lstStockIn)
         {
            if (si.Selected)
            {
               Total += si.AmountDue;
            }
         }
         return Total;
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         Canceled = true;
         this.ParentForm.Close();
      }

      private void repCheckBox_EditValueChanged(object sender, EventArgs e)
      {
      }

      private void txtFreightAmount_EditValueChanged(object sender, EventArgs e)
      {
         UpdateDisplay();
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
         UpdateDisplay();

         double AmountFreight = clsUtil.CheckValue(txtFreightAmount);
         double AmountSI = clsUtil.CheckValue(txtSIAmount);
         double FreightPercent = 0;
         if (AmountSI == 0 || AmountFreight == 0)
         {
            clsUtil.ShowMessage("Invalid amount!", "Save Freight", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
         }
         else
         {
            FreightPercent = AmountFreight/AmountSI*100;
         }

         if (freight == null)
         {
            //new freight
            freight = new Freight();
         }
         else
         {
            freight = FreightDao.GetById(freight.ID);
         }

         freight.SI_Amount = AmountSI;
         freight.Total_Amount = AmountFreight;
         freight.FreightPercentage = FreightPercent;

         IList<StockIn> lst = new List<StockIn>();
         foreach (StockIn si in m_lstStockIn)
         {
            if (si.Selected)
            {
               lst.Add(si);
            }
         }

         try
         {
            FreightDao.Save(freight, lst);
            Canceled = false;
            this.ParentForm.Close();
         }
         catch (Exception ex)
         {
            clsUtil.ShowMessageError("Error:\n" + ex.Message, "Save Freight");
         }
      }
   }
}