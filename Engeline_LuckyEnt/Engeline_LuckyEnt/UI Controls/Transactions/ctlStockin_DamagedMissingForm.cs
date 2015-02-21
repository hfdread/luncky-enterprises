#region

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Engeline_LuckyEnt.Classes;
using Engeline_LuckyEnt.Forms;
using Engeline_LuckyEnt.UI_Controls.Viewers;
using MyHibernate.BusinessObjects;
using MyHibernate.DataAccessLayer;
using DevExpress.XtraEditors;

#endregion

namespace Engeline_LuckyEnt.UI_Controls.Transactions
{
    public partial class ctlStockin_DamagedMissingForm : UserControl
    {
        private DamagedMissingDao dmDao = new DamagedMissingDao();
        private StockInDao siDao = new StockInDao();

        public string trxType = "";
        public StockIn stockin { get; set; }
        public StockInDetails sid { get; set; }
        public ctlStockIn previousCtl { get; set; }
        public Int32 origQtyOnHand=0;

        public ctlStockin_DamagedMissingForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (stockin != null)
            {
                if (txtValue.Text == "" || Convert.ToInt32(txtValue.Text) <= 0)
                {
                    clsUtil.ShowMessageExclamation(string.Format("{0} ITEMS quantity must be greather than 0", trxType.ToUpper()),
                        string.Format("{0} ITEMS", trxType.ToUpper()));
                }
                else
                {
                    DamagedMissing dm = new DamagedMissing();
                    Int32 qtyDM = 0;

                    dm.stockin = stockin;
                    dm.item = sid.item;
                    dm.Original_Qty = Convert.ToInt32(txtOrigQty.Text);


                    if (trxType == "damage")
                    {
                        dm.Damage_Qty = Convert.ToInt32(txtValue.Text);
                        dm.Missing_Qty = 0;
                        qtyDM = dm.Damage_Qty;

                        if (origQtyOnHand < dm.Damage_Qty)
                        {
                            clsUtil.ShowMessageInformation("Damaged quantity is greater than the remaining Quantity Onhand!", "Damaged Items");
                            return;
                        }

                        
                    }
                    else if (trxType == "missing")
                    {
                        dm.Missing_Qty = Convert.ToInt32(txtValue.Text);
                        dm.Damage_Qty = 0;
                        qtyDM = dm.Missing_Qty;

                        if(origQtyOnHand < dm.Missing_Qty)
                        {
                            clsUtil.ShowMessageInformation("Missing quantity is greater than the remaining Quantity Onhand!", "Missing Items");
                            return;
                        }
                    }

                    dm.TrxDate = DateTime.Now;
                    dm.ReStock = false;
                    dm.Warehouse = sid.WarehouseStockin;
                    dm.SellingPrice = sid.Price1;

                    try
                    {
                        dmDao.Save(dm);

                        //update items qty on hand
                        sid.QTY1 = sid.QTY_OnHand1 - qtyDM;
                        foreach (StockInDetails xsid in stockin.details)
                        {
                            if (xsid.ID == sid.ID)
                            {
                                xsid.QTY_OnHand1 = sid.QTY1;
                            }
                        }
                        siDao.SaveDMitems(stockin, sid.ID, sid.item.ID, qtyDM);

                        clsUtil.ShowMessage("Successfully Saved!", "Save Damaged/Missing Items", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        previousCtl.m_DMItem = dm;
                        btnClose.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        clsUtil.ShowMessage("Error:\n" + ex.Message, "Save Damaged/Missing Items", MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void ctlStockin_DamagedMissingForm_Load(object sender, EventArgs e)
        {
            if (sid != null)
            {
                txtOrigQty.Text = sid.QTY1.ToString();
                lblOnHand.Text = sid.QTY_OnHand1.ToString();
                origQtyOnHand = sid.QTY_OnHand1;

                if (sid.QTY_OnHand1 == 0)
                    txtValue.Enabled = false;
            }

            if (trxType == "damage")
                lblCaption.Text = "Damaged QTY";
            else if (trxType == "missing")
                lblCaption.Text = "Missing QTY";
        }
    }
}
