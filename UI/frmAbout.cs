using System.Diagnostics;
using System.Windows.Forms;

namespace TGMacro
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            Shown += FrmAbout_Shown;
        }

        private void FrmAbout_Shown(object sender, System.EventArgs ee)
        {
            TopMost = Statics.AppSession.TopMost;
            button1.Click += (s, e) => Process.Start("https://www.buymeacoffee.com/trksyln");
            label1.Text = label1.Text.Replace("{0}", Statics.AppSession.Version);
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
        }

    }
}
