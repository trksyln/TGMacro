
using CSInputs.ReadInput;
using CSInputs.Structs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TGMacro
{
    public partial class frmActionEditor : Form
    {
        public Interfaces.IMacroAction Action = null;
        private CSInputs.Enums.KeyboardKeys _secondaryKey;
        private CSInputs.Enums.MouseKeys _secondaryMouseKey;

        private CSInputs.Enums.KeyboardKeys SecondaryKey { get => _secondaryKey; set { _secondaryKey = value; if (_secondaryKey != 0) { SecondaryMouseKey = 0; } } }

        private CSInputs.Enums.MouseKeys SecondaryMouseKey { get => _secondaryMouseKey; set { _secondaryMouseKey = value; if (_secondaryMouseKey != 0) { SecondaryKey = 0; } } }

        private bool _isListeningForTriggerKey = false;

        private bool IsListeningForKey
        {
            get => _isListeningForTriggerKey; set
            {
                _isListeningForTriggerKey = value;
                viewKeys();
                cbActionType.Enabled= !value;
            }
        }

        private void LoadLanguage()
        {
            txtKeySetter.Text = Statics.AppSession.ActiveLanguage.text_click_here_to_set_key;
            lblActionType.Text = Statics.AppSession.ActiveLanguage.text_action_type;
            lblKey.Text = Statics.AppSession.ActiveLanguage.txt_keys;
            lblText.Text = Statics.AppSession.ActiveLanguage.string_text;
            lblKeyStatus.Text = Statics.AppSession.ActiveLanguage.text_key_status;
            lblPosition.Text = Statics.AppSession.ActiveLanguage.text_position;
            lblPositioning.Text = Statics.AppSession.ActiveLanguage.text_positioning;
            lblWaitAmount.Text = Statics.AppSession.ActiveLanguage.text_wait_amount;

            cbKeyStatus.Items.Add(Statics.AppSession.ActiveLanguage.text_key_status_01);
            cbKeyStatus.Items.Add(Statics.AppSession.ActiveLanguage.text_key_status_02);
            cbKeyStatus.Items.Add(Statics.AppSession.ActiveLanguage.text_key_status_03);
            cbKeyStatus.SelectedIndex = 0;

            cbMouseMoveMethod.Items.Add(Statics.AppSession.ActiveLanguage.text_mouse_move_method_01_abs);
            cbMouseMoveMethod.Items.Add(Statics.AppSession.ActiveLanguage.text_mouse_move_method_02_rel);
            cbMouseMoveMethod.SelectedIndex = 0;
            lblGrabCurInfo.Text = Statics.AppSession.ActiveLanguage.info_grab_cursor_position;

            cbActionType.Items.Add(Statics.AppSession.ActiveLanguage.text_action_type_01_mouse_move);
            cbActionType.Items.Add(Statics.AppSession.ActiveLanguage.text_action_type_02_mouse_button);
            cbActionType.Items.Add(Statics.AppSession.ActiveLanguage.text_action_type_03_keyboard_button);
            cbActionType.Items.Add(Statics.AppSession.ActiveLanguage.text_action_type_04_wait);
            cbActionType.Items.Add(Statics.AppSession.ActiveLanguage.text_action_type_05_text);
            cbActionType.SelectedIndex = 0;
            lblGrabCurInfo.Text = Statics.AppSession.ActiveLanguage.text_grab_cursor_position;
            toolTip1.SetToolTip(cbMouseMoveMethod, Statics.AppSession.ActiveLanguage.text_mouse_move_method_info);

            btnSave.Text = Statics.AppSession.ActiveLanguage.btnSave;
        }

        private void viewKeys()
        {
            if (IsListeningForKey)
            {
                return;
            }

            if (SecondaryKey != CSInputs.Enums.KeyboardKeys.None)
            {
                txtKeySetter.Text = SecondaryKey.ToString();
            }
            else if (SecondaryMouseKey != CSInputs.Enums.MouseKeys.None)
            {
                txtKeySetter.Text = SecondaryMouseKey.ToString();
            }
            else
            {
                txtKeySetter.Text = Statics.AppSession.ActiveLanguage.text_click_here_to_set_key;
            }

            txtKeySetter.Enabled = true;
        }
        public frmActionEditor(Interfaces.IMacroAction action = null)
        {
            InitializeComponent();
            Action = action;
            Shown += FrmActionEditor_Shown;

        }

        private void FrmActionEditor_Shown(object sender, EventArgs e)
        {
            TopMost = Statics.AppSession.TopMost;
            registerEvents();
            LoadLanguage();
            Statics.AppSession.InputListener.KeyboardInputs += Hook_KeyboardInputs;
            Statics.AppSession.InputListener.MouseInputs += InputListener_MouseInputs;
            if (Action == null)
            {
                Action = new Actions.KeyboardKeyAction();
            }
            else
            {
                fillForm();
            }
        }


        private void fillForm()
        {
            switch (Action.ActionType)
            {
                case Enums.ActionTypes.MoveMouse:
                    cbActionType.SelectedIndex = (int)Enums.ActionTypes.MoveMouse;
                    cbMouseMoveMethod.SelectedIndex = (int)(Action as Actions.MouseMoveAction).MouseMoveMethod;
                    mPosX.Value = (Action as Actions.MouseMoveAction).MousePos.X;
                    mPosY.Value = (Action as Actions.MouseMoveAction).MousePos.Y;
                    break;
                case Enums.ActionTypes.MouseButton:
                    cbActionType.SelectedIndex = (int)Enums.ActionTypes.MouseButton;
                    cbMouseMoveMethod.SelectedIndex = (int)(Action as Actions.MouseKeyAction).MouseMoveMethod;
                    cbKeyStatus.SelectedIndex = (int)(Action as Actions.MouseKeyAction).KeyMethod;
                    mPosX.Value = (Action as Actions.MouseKeyAction).MousePos.X;
                    mPosY.Value = (Action as Actions.MouseKeyAction).MousePos.Y;
                    SecondaryMouseKey = (Action as Actions.MouseKeyAction).MouseKey;
                    viewKeys();
                    break;
                case Enums.ActionTypes.KeyboardKey:
                    cbActionType.SelectedIndex = (int)Enums.ActionTypes.KeyboardKey;
                    cbKeyStatus.SelectedIndex = (int)(Action as Actions.KeyboardKeyAction).KeyMethod;
                    SecondaryKey = (Action as Actions.KeyboardKeyAction).KeyboardKey;
                    viewKeys();
                    break;
                case Enums.ActionTypes.Wait:
                    cbActionType.SelectedIndex = (int)Enums.ActionTypes.Wait;
                    txtSleepAmount.Value = (Action as Actions.WaitAction).SleepAmount;
                    break;
                case Enums.ActionTypes.Text:
                    cbActionType.SelectedIndex = (int)Enums.ActionTypes.Text;
                    txtText.Text = (Action as Actions.TextAction).Text;
                    break;
            }
        }

        private void registerEvents()
        {
            txtKeySetter.MouseUp += keySetterClick;
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

            KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                {
                    Close();
                }
            };
            btnSave.Click += (s, e) =>
            {
                switch (cbActionType.SelectedIndex)
                {
                    case (int)Enums.ActionTypes.MoveMouse:
                        Action = new Actions.MouseMoveAction();
                        (Action as Actions.MouseMoveAction).MouseMoveMethod = (CSInputs.Enums.MousePositioning)cbMouseMoveMethod.SelectedIndex;
                        (Action as Actions.MouseMoveAction).MousePos = new Point((int)mPosX.Value, (int)mPosY.Value);
                        break;
                    case (int)Enums.ActionTypes.MouseButton:
                        if (SecondaryMouseKey == 0)
                        {
                            MessageBox.Show(Statics.AppSession.ActiveLanguage.info_no_key_selected, "Err");
                            return;
                        }
                        Action = new Actions.MouseKeyAction();
                        (Action as Actions.MouseKeyAction).KeyMethod = (Enums.KeyPressMethods)cbKeyStatus.SelectedIndex;
                        (Action as Actions.MouseKeyAction).MouseMoveMethod = (CSInputs.Enums.MousePositioning)cbMouseMoveMethod.SelectedIndex;
                        (Action as Actions.MouseKeyAction).MouseKey = SecondaryMouseKey;
                        (Action as Actions.MouseKeyAction).MousePos = new Point((int)mPosX.Value, (int)mPosY.Value);
                        break;
                    case (int)Enums.ActionTypes.KeyboardKey:
                        if (SecondaryKey == 0)
                        {
                            MessageBox.Show(Statics.AppSession.ActiveLanguage.info_no_key_selected, "Err");
                            return;
                        }
                        Action = new Actions.KeyboardKeyAction();
                        (Action as Actions.KeyboardKeyAction).KeyMethod = (Enums.KeyPressMethods)cbKeyStatus.SelectedIndex;
                        (Action as Actions.KeyboardKeyAction).KeyboardKey = SecondaryKey;
                        break;
                    case (int)Enums.ActionTypes.Wait:
                        Action = new Actions.WaitAction();
                        (Action as Actions.WaitAction).SleepAmount = (int)txtSleepAmount.Value;
                        break;
                    case (int)Enums.ActionTypes.Text:
                        if (txtText.TextLength < 1)
                        {
                            MessageBox.Show(Statics.AppSession.ActiveLanguage.info_no_text, "Err");
                            return;
                        }
                        Action = new Actions.TextAction();
                        (Action as Actions.TextAction).Text = txtText.Text;
                        break;
                }
                DialogResult = DialogResult.OK;
            };

            cbActionType.SelectedIndexChanged += (s, e) =>
            {
                SecondaryKey = CSInputs.Enums.KeyboardKeys.None;
                SecondaryMouseKey = CSInputs.Enums.MouseKeys.None;
                switch (cbActionType.SelectedIndex)
                {
                    case (int)Enums.ActionTypes.MoveMouse:
                        setPresetMouseMove();
                        break;
                    case (int)Enums.ActionTypes.MouseButton:
                        setPresetMouseKey();
                        break;
                    case (int)Enums.ActionTypes.KeyboardKey:
                        setPresetKeyboardKey();
                        break;
                    case (int)Enums.ActionTypes.Wait:
                        setPresetWait();
                        break;
                    case (int)Enums.ActionTypes.Text:
                        setPresetText();
                        break;
                }
            };
        }

        private void InputListener_MouseInputs(MouseData data, ref ModifierKey modifierKey)
        {
            if (IsListeningForKey && (Enums.ActionTypes)cbActionType.SelectedIndex == Enums.ActionTypes.MouseButton && data.Flags == CSInputs.Enums.KeyFlags.Up)
            {
                SecondaryMouseKey = data.Key;
                IsListeningForKey = false;
            }
        }
        private void Hook_KeyboardInputs(KeyboardData data, ref ModifierKey modifierKey)
        {
            if (modifierKey.Alt && data.Key == CSInputs.Enums.KeyboardKeys.X && data.Flags == CSInputs.Enums.KeyFlags.Down)
            {
                mPosX.Value = Cursor.Position.X;
                mPosY.Value = Cursor.Position.Y;
            }
            if (IsListeningForKey && data.Key == CSInputs.Enums.KeyboardKeys.Escape)
            {
                IsListeningForKey = false;
                return;
            }
            if (IsListeningForKey && (Enums.ActionTypes)cbActionType.SelectedIndex == Enums.ActionTypes.KeyboardKey)
            {
                SecondaryKey = data.Key;
                IsListeningForKey = false;
            }
        }
        private void keySetterClick(object sender, EventArgs e)
        {
            txtKeySetter.Enabled = false;
            if (IsListeningForKey)
            {
                return;
            }

            IsListeningForKey = !IsListeningForKey;
            if (IsListeningForKey)
            {
                txtKeySetter.Text = Statics.AppSession.ActiveLanguage.text_press_any_key_to_set;
            }
        }


        private void reset()
        {
            pnlKeyStatus.Visible = false;
            pnlKeys.Visible = false;
            pnlMouseMoveMethod.Visible = false;
            pnlMousePos.Visible = false;
            pnlSleepAmount.Visible = false;
            pnlText.Visible = false;
        }

        private void setPresetMouseKey()
        {
            reset();
            pnlKeys.Visible = true;
            pnlMouseMoveMethod.Visible = true;
            pnlKeyStatus.Visible = true;
            pnlMousePos.Visible = true;
        }

        private void setPresetKeyboardKey()
        {
            reset();
            pnlKeyStatus.Visible = true;
            pnlKeys.Visible = true;
        }

        private void setPresetMouseMove()
        {
            reset();
            pnlMouseMoveMethod.Visible = true;
            pnlMousePos.Visible = true;
        }

        private void setPresetWait()
        {
            reset();
            pnlSleepAmount.Visible = true;
        }
        private void setPresetText()
        {
            reset();
            pnlText.Visible = true;
        }

    }
}
