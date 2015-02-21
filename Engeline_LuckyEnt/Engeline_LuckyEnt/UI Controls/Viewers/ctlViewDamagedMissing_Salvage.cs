#region

using System;
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
    public partial class ctlViewDamagedMissing_Salvage : UserControl
    {
        public DamagedMissing m_DM { get; set; }

        public ctlViewDamagedMissing_Salvage()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }

        private void ctlViewDamagedMissing_Salvage_Load(object sender, EventArgs e)
        {
            if (m_DM != null)
            {
                lblDmg.Text = m_DM.Damage_Qty.ToString();
                lblMissing.Text = m_DM.Missing_Qty.ToString();
                lblStockInID.Text = m_DM.stockin.returnID();
                lblItem.Text = m_DM.item.ToString();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //validate Input
            Int32 inputDamage=0, inputMissing=0, damage=0, missing=0, totalSalvage=0;

            if(txtDmg.Text != "")
                inputDamage = Convert.ToInt32(txtDmg.Text);
            if(txtMissing.Text != "")
                inputMissing = Convert.ToInt32(txtMissing.Text);
            damage = Convert.ToInt32(lblDmg.Text);
            missing = Convert.ToInt32(lblMissing.Text);
            totalSalvage = Convert.ToInt32(lblTotalSalvage.Text);

            if (inputDamage > damage)
            {
                clsUtil.ShowMessageExclamation("Specified damages to be salvage is greater than the recorded damage quantity!", "Salvage Form");
                return;
            }

            if (inputMissing > missing)
            {
                clsUtil.ShowMessageExclamation("Specified missing to be salvage is greater than the recorded missing quantity!", "Salvage Form");
                return;
            }

            if (missing <= 0 && damage <= 0)
            {
                clsUtil.ShowMessageExclamation("Cannot Create Stock In, damage and missing balance are 0","Salvage Form");
                return;
            }

            ctlStockIn ctl = new ctlStockIn();
            m_DM.SalvageQuantity = inputDamage + inputMissing;
            ctl.m_DMItem = m_DM;
            clsUtil.getMainForm().LoadCtl(ctl, false, "New Stock In", "Stock In for Salavaged Items", false);
            btnCancel.PerformClick();
        }

        private void computeTotal()
        {
            Int32 dmg=0, missing=0, total=0;
            if(txtDmg.Text != "")
                dmg = Convert.ToInt32(txtDmg.Text);
            if(txtMissing.Text != "")
                missing = Convert.ToInt32(txtMissing.Text);

            total = dmg + missing;
            lblTotalSalvage.Text = total.ToString();
        }

        private void txtDmg_EditValueChanged(object sender, EventArgs e)
        {
            computeTotal();
        }

        private void txtMissing_EditValueChanged(object sender, EventArgs e)
        {
            computeTotal();
        }
    }
}
