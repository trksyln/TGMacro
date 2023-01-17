using System.Drawing;
using System.Windows.Forms;

namespace TGMacro
{

    public partial class ucMacroItem : UserControl
    {
        private MacroItem macro;
        public MacroItem Macro
        {
            get => macro;
            set { macro = value; refreshUI(); }
        }

        public ucMacroItem(MacroItem item, Control parent)
        {
            InitializeComponent();
            BackColor = SystemColors.Control;
            Macro = item;
            Parent = parent;
            registerEvents();

            toolTip1.SetToolTip(pnlEnable, Statics.AppSession.ActiveLanguage.enable_disable_macro);
            toolTip1.SetToolTip(btnEdit, Statics.AppSession.ActiveLanguage.edit_macro);
            toolTip1.SetToolTip(btnDelete, Statics.AppSession.ActiveLanguage.macro_delete_title);
        }

        private void updateMacroStatus()
        {
            Macro.Enable = !Macro.Enable;
            if (Macro.Enable)
            {
                pnlEnable.BackColor = Color.FromArgb(76, 213, 18);
                lblMacroName.ForeColor = Color.Black;
            }
            else
            {
                pnlEnable.BackColor = Color.FromArgb(230, 71, 30);
                lblMacroName.ForeColor = Color.DarkRed;
                picRunning.Visible = false;
            }
        }
        private void registerEvents()
        {
            foreach (Control item in Controls)
            {
                if (item.GetType() != typeof(Button))
                {
                    item.Click += (s, e) => updateMacroStatus();
                }
            }
            Click += (s, e) => updateMacroStatus();

            btnEdit.Click += (s, e) =>
            {
                bool prevVal = Statics.AppSession.Enable;
                Statics.AppSession.Enable = false;

                frmMacroEditor mEditor = new frmMacroEditor(Macro);
                if (mEditor.ShowDialog() == DialogResult.OK)
                {
                    Macro = mEditor.Macro;
                }
                Statics.AppSession.Enable = prevVal;
            };
            btnDelete.Click += (s, e) =>
            {
                if (MessageBox.Show(Statics.AppSession.ActiveLanguage.btn_macro_delete.Replace("{macroname}", Macro.Name), Statics.AppSession.ActiveLanguage.macro_delete_title, MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    ((FlowLayoutPanel)this.Parent).Controls.Remove(this);
                    macro.Trigger.Dispose();
                    macro.Dispose();
                    macro = null;
                    Dispose();
                }
            };
        }

        private void refreshUI()
        {
            Macro.Trigger.TriggerRunningStatusChanged += () =>
                {
                    if (IsHandleCreated)
                    {
                        Invoke((MethodInvoker)delegate { picRunning.Visible = Macro.Trigger.RunState != Enums.TriggerRunState.Stop; });
                    }
                };

            picTriggerType.BackgroundImage = macro.Icon;
            lblMacroName.Text = macro.Name;
            if (Macro.Trigger != null)
            {
                switch (Macro.Trigger.TriggerType)
                {
                    case Enums.TriggerTypes.Mouse:
                        lblKeyInfo.Text = (Macro.Trigger as Triggers.MouseTrigger).PrimaryKey != CSInputs.Enums.KeyboardKeys.None ? (Macro.Trigger as Triggers.MouseTrigger).PrimaryKey + " + " + (Macro.Trigger as Triggers.MouseTrigger).SecondaryKey : (Macro.Trigger as Triggers.MouseTrigger).SecondaryKey.ToString();
                        break;
                    case Enums.TriggerTypes.Keyboard:
                        lblKeyInfo.Text = (Macro.Trigger as Triggers.KeyboardTrigger).PrimaryKey != CSInputs.Enums.KeyboardKeys.None ? (Macro.Trigger as Triggers.KeyboardTrigger).PrimaryKey + " + " + (Macro.Trigger as Triggers.KeyboardTrigger).SecondaryKey : (Macro.Trigger as Triggers.KeyboardTrigger).SecondaryKey.ToString();
                        break;
                    case Enums.TriggerTypes.Pixel:
                        lblKeyInfo.Text = "By Color";
                        break;
                }
            }

            updateMacroStatus();
        }

    }
}
