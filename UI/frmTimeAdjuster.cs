using System.Windows.Forms;

namespace TGMacro
{
    public partial class frmTimeAdjuster : Form
    {
        public int SleepAdjustValue => (int)numericUpDown1.Value;
        public frmTimeAdjuster()
        {
            InitializeComponent();
            Shown += FrmTimeAdjuster_Shown;
            label1.Text = Statics.AppSession.ActiveLanguage.text_adjust_time_info;
        }

        private void FrmTimeAdjuster_Shown(object sender, System.EventArgs ee)
        {
            TopMost = Statics.AppSession.TopMost;

            btnClose.Click += (s, e) => Close();
            lblTitle.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    Sys.WindowHandling.ReleaseCapture();
                    Sys.WindowHandling.SendMessage(Handle, Sys.WindowHandling.WM_NCLBUTTONDOWN, Sys.WindowHandling.HT_CAPTION, 0);
                }
            };
            pnlTop.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    Sys.WindowHandling.ReleaseCapture();
                    Sys.WindowHandling.SendMessage(Handle, Sys.WindowHandling.WM_NCLBUTTONDOWN, Sys.WindowHandling.HT_CAPTION, 0);
                }
            };

            Statics.AppSession.TopMostStatusChanged += (s, e) =>
            {
                TopMost = Statics.AppSession.TopMost;
            };
            btnSave.Click += (s, e) =>
            {
                DialogResult = DialogResult.OK;
            };
        }
    }
}
