#region

using System.Windows.Forms;

#endregion

namespace Engeline_LuckyEnt.Forms
{
    public partial class frmGenericPopup : Form
    {
        public frmGenericPopup()
        {
            InitializeComponent();
        }

        public void ShowCtl(Control ctl)
        {
            ctl.Visible = false;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(ctl);
            this.Bounds = ctl.Bounds;
            ctl.Dock = DockStyle.Fill;
            ctl.Visible = true;

            this.ShowDialog();
        }

        public void ShowRequestAprroval(Control ctl)
        {
            ControlBox = false;
            Text = "Approval Request";
            ShowCtl(ctl);
        }
    }
}