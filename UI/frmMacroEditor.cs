
using CSInputs.ReadInput;
using CSInputs.Structs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace TGMacro
{
    public partial class frmMacroEditor : Form
    {
        #region Recording stuff

        private bool IsTesting = false;
        private bool _isRecording = false;
        public bool IsRecording
        {
            get => _isRecording; set
            {
                _isRecording = value;
                recordCheck();
            }
        }

        private readonly Stopwatch st = new Stopwatch();

        private void recordCheck()
        {
            if (IsRecording)
            {
                btnRecord.Image = Properties.Resources.stop_record_16;
                btnRecord.Text = Statics.AppSession.ActiveLanguage.btn_record_on;
            }
            else
            {
                btnRecord.Image = Properties.Resources.record_16;
                btnRecord.Text = Statics.AppSession.ActiveLanguage.btn_record_off;
            }
        }

        private void addAction(Interfaces.IMacroAction action)
        {
            actionTable.Rows.Add(action, action.Icon, action.VisibleText, action.VisibleValue);
            if (dtActions.SelectedRows.Count > 0)
            {
                dtActions.FirstDisplayedScrollingRowIndex = dtActions.Rows[dtActions.Rows.Count - 1].Index;
            }
        }

        private void Record()
        {
            if (IsRecording)
            {
                st.Start();
            }
            else
            {
                st.Reset();
                st.Stop();
            }
            IsRecording = !IsRecording;
        }
        #endregion
        private CSInputs.Enums.KeyboardKeys _secondaryKey;
        private CSInputs.Enums.MouseKeys _secondaryMouseKey;
        private CSInputs.Enums.KeyboardKeys PrimaryKey;

        private CSInputs.Enums.KeyboardKeys SecondaryKey { get => _secondaryKey; set { _secondaryKey = value; if (_secondaryKey != 0) { SecondaryMouseKey = 0; } } }
        private CSInputs.Enums.MouseKeys SecondaryMouseKey { get => _secondaryMouseKey; set { _secondaryMouseKey = value; if (_secondaryMouseKey != 0) { SecondaryKey = 0; } } }
        private bool _isListeningForTriggerKey = false;

        private bool IsListeningForKey
        {
            get => _isListeningForTriggerKey; set
            {
                _isListeningForTriggerKey = value;
                ViewKeysOnKeySetterTextBox();
            }
        }
        public MacroItem Macro;
        private readonly bool LoadScript = false;
        private ActionTable actionTable;
        private Thread TestActionThread;
        public frmMacroEditor(MacroItem macro = null, bool loadScript = false)
        {
            InitializeComponent();
            TopMost = Statics.AppSession.TopMost;
            Macro = macro;
            LoadScript = loadScript;
            Shown += FrmMacroEditor_Shown;
        }

        private void LoadLanguage()
        {
            grpActions.Text = Statics.AppSession.ActiveLanguage.text_actions;
            grpName.Text = Statics.AppSession.ActiveLanguage.text_macro_name;
            grpTrigger.Text = Statics.AppSession.ActiveLanguage.text_triggering;

            toolTip1.SetToolTip(btnAddAction, Statics.AppSession.ActiveLanguage.btnAddAction);
            toolTip1.SetToolTip(btnEditAction, Statics.AppSession.ActiveLanguage.btnEditActions);
            toolTip1.SetToolTip(btnClone, Statics.AppSession.ActiveLanguage.btnCloneActions);
            toolTip1.SetToolTip(btnDeleteAction, Statics.AppSession.ActiveLanguage.btnDeleteActions);
            toolTip1.SetToolTip(btnActionMoveUp, Statics.AppSession.ActiveLanguage.btnMoveActionUp);
            toolTip1.SetToolTip(btnActionMoveDown, Statics.AppSession.ActiveLanguage.btnMoveActionsDown);
            toolTip1.SetToolTip(btnImportScript, Statics.AppSession.ActiveLanguage.btnImportActionsFromScript);
            toolTip1.SetToolTip(btnRecord, Statics.AppSession.ActiveLanguage.btnRecord_off);
            toolTip1.SetToolTip(btnClear, Statics.AppSession.ActiveLanguage.btnClearActions);
            toolTip1.SetToolTip(btnAdjustTiming, Statics.AppSession.ActiveLanguage.text_adjust_timing);
            toolTip1.SetToolTip(btnMultiAction, Statics.AppSession.ActiveLanguage.btnMultiAdd);

            lblTrgKeys.Text = Statics.AppSession.ActiveLanguage.txt_keys;
            lblTrgMethod.Text = Statics.AppSession.ActiveLanguage.txt_when;
            lblTrgType.Text = Statics.AppSession.ActiveLanguage.text_trigger_action_by;
            lblGrabInfo.Text = Statics.AppSession.ActiveLanguage.info_color_box;
            lblGrabInfo2.Text = Statics.AppSession.ActiveLanguage.info_getting_color_and_position;
            lblColor.Text = Statics.AppSession.ActiveLanguage.text_color;
            lblColorPos.Text = Statics.AppSession.ActiveLanguage.text_color_position;

            cbTriggerType.Items.Clear();
            cbTriggerType.Items.Add(Statics.AppSession.ActiveLanguage.text_key_events);
            cbTriggerType.Items.Add(Statics.AppSession.ActiveLanguage.text_pixel_events);

            btnSave.Text = Statics.AppSession.ActiveLanguage.btnSave;
            btnTest.Text = Statics.AppSession.ActiveLanguage.btnTest;

            cbMousePositioning.Items.Add(Statics.AppSession.ActiveLanguage.text_mouse_move_method_01_abs);
            cbMousePositioning.Items.Add(Statics.AppSession.ActiveLanguage.text_mouse_move_method_02_rel);
            cbMousePositioning.SelectedIndex = 0;

            grpRecord.Text = Statics.AppSession.ActiveLanguage.text_record_settings;
            lblMouseCapPos.Text = Statics.AppSession.ActiveLanguage.text_capture_mouse_pos;

            txtKeySetter.Text = Statics.AppSession.ActiveLanguage.text_click_here_to_set_key;

            lblRecordThis.Text = Statics.AppSession.ActiveLanguage.text_record;
            cbDelays.Text = Statics.AppSession.ActiveLanguage.text_keys;
            cbKeyboardKeys.Text = Statics.AppSession.ActiveLanguage.text_keyboard_keys;
            cbMouseButtons.Text = Statics.AppSession.ActiveLanguage.text_mouse_buttons;
            cbMouseMovements.Text = Statics.AppSession.ActiveLanguage.text_mouse_movements;
            btnRecord.Text = Statics.AppSession.ActiveLanguage.btn_record_off;

        }
        private void setDataSource()
        {
            actionTable = new ActionTable();
            actionTable.Columns.Add("", typeof(Interfaces.IMacroAction));
            actionTable.Columns.Add(" ", typeof(Image));
            actionTable.Columns.Add(Statics.AppSession.ActiveLanguage.text_action, typeof(string));
            actionTable.Columns.Add(Statics.AppSession.ActiveLanguage.text_value, typeof(string));

            dtActions.DataSource = actionTable;
            dtActions.ScrollBars = ScrollBars.Vertical;
        }
        private void ViewKeysOnKeySetterTextBox()
        {
            if (IsListeningForKey)
            {
                return;
            }

            if (PrimaryKey != CSInputs.Enums.KeyboardKeys.None && SecondaryKey != CSInputs.Enums.KeyboardKeys.None)
            {
                txtKeySetter.Text = PrimaryKey + " + " + SecondaryKey;
            }
            else if (PrimaryKey == CSInputs.Enums.KeyboardKeys.None && SecondaryKey != CSInputs.Enums.KeyboardKeys.None)
            {
                txtKeySetter.Text = SecondaryKey.ToString();
            }
            else if (PrimaryKey != CSInputs.Enums.KeyboardKeys.None && SecondaryMouseKey != CSInputs.Enums.MouseKeys.None)
            {
                txtKeySetter.Text = PrimaryKey + " + " + SecondaryMouseKey;
            }
            else if (PrimaryKey == CSInputs.Enums.KeyboardKeys.None && SecondaryMouseKey != CSInputs.Enums.MouseKeys.None)
            {
                txtKeySetter.Text = SecondaryMouseKey.ToString();
            }
            else
            {
                txtKeySetter.Text = Statics.AppSession.ActiveLanguage.text_click_here_to_set_key;
            }

            txtKeySetter.Enabled = true;
        }
        private void FrmMacroEditor_Shown(object sender, EventArgs e)
        {
            LoadLanguage();
            RegisterEvents();
            setDataSource();

            if (Macro == null)
            {
                Macro = new MacroItem();
                txtMacroName.Text = "Macro " + (Statics.AppSession.Macros.Count + 1);
                setKeyEventPreset();
                if (LoadScript)
                {
                    ScriptParser.LoadScriptTo(actionTable);
                }
            }
            else
            {
                FillTheForm();
            }

            Statics.AppSession.InputListener.KeyboardInputs += KeyboardInputs;
            Statics.AppSession.InputListener.MouseInputs += MouseInputs;
            Statics.AppSession.InputListener.MouseMovements += MouseMovements;

        }

        #region Presets
        private void setKeyEventPreset()
        {
            cbTriggerMethod.Items.Clear();
            cbTriggerMethod.Items.Add(Statics.AppSession.ActiveLanguage.text_key_press);
            cbTriggerMethod.Items.Add(Statics.AppSession.ActiveLanguage.text_key_hold);
            cbTriggerMethod.Items.Add(Statics.AppSession.ActiveLanguage.text_key_toggle);
            cbTriggerType.SelectedIndex = 0;
            cbTriggerMethod.SelectedIndex = 0;
            pnl_colors.Visible = false;
            pnl_keys.Visible = true;

        }

        private void setPresetColor()
        {
            cbTriggerMethod.Items.Clear();
            cbTriggerMethod.Items.Add(Statics.AppSession.ActiveLanguage.text_color_matches);
            cbTriggerMethod.Items.Add(Statics.AppSession.ActiveLanguage.text_color_not_matches);
            cbTriggerType.SelectedIndex = 1;
            cbTriggerMethod.SelectedIndex = 0;

            pnl_colors.Visible = true;
            pnl_keys.Visible = false;

        }
        #endregion

        private void FillTheForm()
        {
            txtMacroName.Text = Macro.Name;
            if (Macro.Trigger != null)
            {
                switch (Macro.Trigger.TriggerType)
                {
                    case Enums.TriggerTypes.Mouse:
                        setKeyEventPreset();
                        Triggers.MouseTrigger trgMouse = (Triggers.MouseTrigger)Macro.Trigger;
                        cbTriggerMethod.SelectedIndex = (int)trgMouse.Method;
                        PrimaryKey = trgMouse.PrimaryKey;
                        SecondaryMouseKey = trgMouse.SecondaryKey;
                        ViewKeysOnKeySetterTextBox();
                        break;
                    case Enums.TriggerTypes.Keyboard:
                        setKeyEventPreset();
                        Triggers.KeyboardTrigger trgKeyboard = (Triggers.KeyboardTrigger)Macro.Trigger;
                        cbTriggerMethod.SelectedIndex = (int)trgKeyboard.Method;
                        PrimaryKey = trgKeyboard.PrimaryKey;
                        SecondaryKey = trgKeyboard.SecondaryKey;
                        ViewKeysOnKeySetterTextBox();
                        break;
                    case Enums.TriggerTypes.Pixel:
                        setPresetColor();
                        Triggers.ColorTrigger trgColor = (Triggers.ColorTrigger)Macro.Trigger;
                        cbTriggerMethod.SelectedIndex = (int)trgColor.Method;
                        pnlSelectedColor.BackColor = trgColor.Color;
                        mPosX.Value = trgColor.Pos.X;
                        mPosY.Value = trgColor.Pos.Y;
                        break;
                }
            }
            if (Macro.Trigger.Actions.Count > 0)
            {
                foreach (Interfaces.IMacroAction item in Macro.Trigger.Actions)
                {
                    actionTable.Rows.Add(item, item.Icon, item.VisibleText, item.VisibleValue);
                }
            }
        }
        #region Inputs
        private void MouseMovements(MouseData data, ref ModifierKey modifierKey)
        {
            if (IsRecording && cbMouseMovements.Checked)
            {
                if (st.ElapsedMilliseconds > 10 && cbDelays.Checked)
                {
                    addAction(new Actions.WaitAction() { SleepAmount = (int)st.ElapsedMilliseconds });
                }

                addAction(new Actions.MouseMoveAction()
                {
                    MouseMoveMethod = cbMousePositioning.SelectedIndex == 0 ? CSInputs.Enums.MousePositioning.Absolute : CSInputs.Enums.MousePositioning.Relative,
                    MousePos = cbMousePositioning.SelectedIndex == 0 ? Cursor.Position : new Point(data.PositionRelative.X, data.PositionRelative.Y)
                });
                st.Restart();
            }
        }
        private void MouseInputs(MouseData data, ref ModifierKey modifierKey)
        {
            if (IsRecording && cbMouseButtons.Checked)
            {
                if (st.ElapsedMilliseconds > 10 && cbDelays.Checked)
                {
                    addAction(new Actions.WaitAction() { SleepAmount = (int)st.ElapsedMilliseconds });
                }

                addAction(new Actions.MouseKeyAction()
                {
                    MouseKey = data.Key,
                    KeyMethod = data.Flags == CSInputs.Enums.KeyFlags.Up ? Enums.KeyPressMethods.Up : Enums.KeyPressMethods.Down,
                    MousePos = cbMousePositioning.SelectedIndex == 0 ? Cursor.Position : new Point(data.PositionRelative.X, data.PositionRelative.Y),
                    MouseMoveMethod = cbMousePositioning.SelectedIndex == 0 ? CSInputs.Enums.MousePositioning.Absolute : CSInputs.Enums.MousePositioning.Relative
                });
                st.Restart();
            }

            if (IsListeningForKey && cbTriggerType.SelectedIndex == 0 && data.Flags == CSInputs.Enums.KeyFlags.Up)
            {
                SetTriggerPrimayKeyIfPressed(modifierKey);
                SecondaryMouseKey = data.Key;
                IsListeningForKey = false;
            }
        }
        private void SetTriggerPrimayKeyIfPressed(ModifierKey modifierKey)
        {
            if (modifierKey.Control)
            {
                PrimaryKey = CSInputs.Enums.KeyboardKeys.Ctrl;
            }
            else if (modifierKey.Shift)
            {
                PrimaryKey = CSInputs.Enums.KeyboardKeys.Shift;
            }
            else if (modifierKey.Alt)
            {
                PrimaryKey = CSInputs.Enums.KeyboardKeys.Alt;
            }
            else
            {
                PrimaryKey = CSInputs.Enums.KeyboardKeys.None;
            }
        }
        private void KeyboardInputs(KeyboardData data, ref ModifierKey modifierKey)
        {
            if (modifierKey.Control && data.Key == CSInputs.Enums.KeyboardKeys.F10 && data.Flags == CSInputs.Enums.KeyFlags.Up)
            {
                Record();
            }

            if (IsTesting && data.Key == CSInputs.Enums.KeyboardKeys.Escape)
            {
                CancelTesting();
            }

            if (IsRecording && cbKeyboardKeys.Checked)
            {
                if (st.ElapsedMilliseconds > 49 && cbDelays.Checked)
                {
                    addAction(new Actions.WaitAction() { SleepAmount = (int)st.ElapsedMilliseconds });
                }

                if (modifierKey.Windows && data.Flags == CSInputs.Enums.KeyFlags.Up)
                {
                    addAction(new Actions.KeyboardKeyAction()
                    {
                        KeyboardKey = data.Key,
                        KeyMethod = Enums.KeyPressMethods.Press,
                    });
                }
                else
                {
                    addAction(new Actions.KeyboardKeyAction()
                    {
                        KeyboardKey = data.Key,
                        KeyMethod = data.Flags == CSInputs.Enums.KeyFlags.Up ? Enums.KeyPressMethods.Up : Enums.KeyPressMethods.Down,
                    });
                }

                st.Restart();
                return;
            }

            if (IsListeningForKey && data.Key == CSInputs.Enums.KeyboardKeys.Escape)
            {
                IsListeningForKey = false;
                return;
            }
            if (IsListeningForKey && cbTriggerType.SelectedIndex == 0)
            {
                if (!Enum.IsDefined(typeof(Enums.KeysForTrigger), (Enums.KeysForTrigger)data.Key))
                {
                    return;
                }

                SetTriggerPrimayKeyIfPressed(modifierKey);
                SecondaryKey = data.Key;
                IsListeningForKey = false;
            }
            if (cbTriggerType.SelectedIndex == 1)
            {
                if (modifierKey.Alt && data.Key == CSInputs.Enums.KeyboardKeys.C && data.Flags == CSInputs.Enums.KeyFlags.Down)
                {
                    pnlSelectedColor.BackColor = Statics.SharedMethods.GetColorAt(Cursor.Position);
                }
                if (modifierKey.Alt && data.Key == CSInputs.Enums.KeyboardKeys.X && data.Flags == CSInputs.Enums.KeyFlags.Down)
                {
                    mPosX.Value = Cursor.Position.X;
                    mPosY.Value = Cursor.Position.Y;
                }
            }
        }
        #endregion

        private Interfaces.IMacroAction[] GetActions()
        {
            List<Interfaces.IMacroAction> actList = new List<Interfaces.IMacroAction>();
            for (int i = 0; i < actionTable.Rows.Count; i++)
            {
                actList.Add((Interfaces.IMacroAction)actionTable.Rows[i][0]);
            }

            return actList.ToArray();
        }
        private void RegisterEvents()
        {
            dtActions.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0)
                    return;

                Interfaces.IMacroAction act = (Interfaces.IMacroAction)actionTable.Rows[e.RowIndex][0];
                frmActionEditor actEditor = new frmActionEditor(act);
                if (actEditor.ShowDialog() == DialogResult.OK)
                {
                    actionTable.Rows[dtActions.SelectedRows[0].Index][0] = actEditor.Action;
                    actionTable.Rows[dtActions.SelectedRows[0].Index][1] = actEditor.Action.Icon;
                    actionTable.Rows[dtActions.SelectedRows[0].Index][2] = actEditor.Action.VisibleText;
                    actionTable.Rows[dtActions.SelectedRows[0].Index][3] = actEditor.Action.VisibleValue;
                }
                dtActions.FirstDisplayedScrollingRowIndex = dtActions.SelectedRows[0].Index;
            };
            btnAdjustTiming.Click += (s, e) =>
            {
                AdjustTiming();
            };
            btnClear.Click += (s, e) =>
            {
                ClearActions();
            };
            btnRecord.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    Record();
                }
            };

            txtKeySetter.MouseUp += EventKeySetterClick;
            btnClose.Click += (s, e) => Close();
            btnMin.Click += (s, e) => WindowState = FormWindowState.Minimized;

            lblTitle.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    DragWindow();
                }
            };
            pnlTop.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    DragWindow();
                }
            };


            btnImportScript.Click += (s, e) =>
            {
                ScriptParser.LoadScriptTo(actionTable);
            };
            btnTest.Click += (s, e) =>
            {
                if (dtActions.Rows.Count < 1)
                {
                    MessageBox.Show(Statics.AppSession.ActiveLanguage.info_no_action_to_key, "Err");
                    return;
                }
                if (!CheckActions())
                {
                    return;
                }

                if (TestActionThread == null || !TestActionThread.IsAlive)
                {
                    StartTesting();
                }
                else
                {
                    CancelTesting();
                }
            };
            dtActions.BindingContextChanged += (s, e) =>
            {
                dtActions.Columns[0].Visible = false;
                dtActions.Columns[1].Width = 20;
                dtActions.Columns[2].Width = (dtActions.Width - 21) / 2;
                dtActions.Columns[3].Width = (dtActions.Width - 21) / 2;
            };
            btnSave.Click += (s, e) =>
            {
                SaveMacro();
            };

            Statics.AppSession.TopMostStatusChanged += (s, e) =>
            {
                TopMost = Statics.AppSession.TopMost;
            };
            btnMultiAction.Click += (s, e) =>
            {
                if (dtActions.SelectedRows.Count < 2)
                {
                    return;
                }

                frmActionEditor actEditor = new frmActionEditor();
                if (actEditor.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < actionTable.Rows.Count; i++)
                    {
                        DataRow r = actionTable.NewRow();
                        Interfaces.IMacroAction act = (Interfaces.IMacroAction)actEditor.Action.Clone();
                        r[0] = act;
                        r[1] = act.Icon;
                        r[2] = act.VisibleText;
                        r[3] = act.VisibleValue;
                        actionTable.Rows.InsertAt(r, i++);
                    }
                    MoveSelectedRowsUp();
                    dtActions.ClearSelection();
                }
            };
            btnAddAction.Click += (s, e) =>
            {
                frmActionEditor actEditor = new frmActionEditor();
                if (actEditor.ShowDialog() == DialogResult.OK)
                {
                    if (dtActions.SelectedRows.Count > 0)
                    {
                        int rIndex = dtActions.SelectedRows[0].Index;
                        DataRow r = actionTable.NewRow();
                        r[0] = actEditor.Action;
                        r[1] = actEditor.Action.Icon;
                        r[2] = actEditor.Action.VisibleText;
                        r[3] = actEditor.Action.VisibleValue;
                        actionTable.Rows.InsertAt(r, rIndex + 1);
                        dtActions.ClearSelection();
                        dtActions.Rows[rIndex + 1].Selected = true;
                    }
                    else
                    {
                        actionTable.Rows.Add(actEditor.Action, actEditor.Action.Icon, actEditor.Action.VisibleText, actEditor.Action.VisibleValue);
                        dtActions.Rows[dtActions.Rows.Count - 1].Selected = true;
                    }
                }

                if (dtActions.SelectedRows.Count > 0)
                {
                    dtActions.FirstDisplayedScrollingRowIndex = dtActions.SelectedRows[0].Index;
                }
            };
            btnDeleteAction.Click += (s, e) =>
            {
                if (dtActions.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dtActions.SelectedRows)
                    {
                        actionTable.Rows.RemoveAt(row.Index);
                    }
                }
            };
            btnEditAction.Click += (s, e) =>
            {
                EditAction();
            };
            btnClone.Click += (s, e) =>
            {
                CloneSelectedAction();
            };
            btnActionMoveUp.Click += (s, e) =>
            {
                MoveSelectedRowsUp();
            };
            btnActionMoveDown.Click += (s, e) =>
            {
                MoveSelectedRowsDown();
            };

            cbTriggerType.SelectedIndexChanged += (s, e) =>
                {
                    PrimaryKey = 0;
                    SecondaryKey = 0;
                    SecondaryMouseKey = 0;
                    ViewKeysOnKeySetterTextBox();
                    if (cbTriggerType.SelectedIndex == 0)
                    {
                        setKeyEventPreset();
                    }
                    else
                    {
                        setPresetColor();
                    }
                };

            pnlSelectedColor.Click += (s, e) =>
            {
                colorDialog1.Color = pnlSelectedColor.BackColor;
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    pnlSelectedColor.BackColor = colorDialog1.Color;
                }
            };
        }
        private void ClearActions()
        {
            if (actionTable.Rows.Count < 1)
            {
                return;
            }

            if (MessageBox.Show(Statics.AppSession.ActiveLanguage.info_clear_all_actions, "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                actionTable.Clear();
            }
        }
        private void DragWindow()
        {
            Sys.WindowHandling.ReleaseCapture();
            Sys.WindowHandling.SendMessage(Handle, Sys.WindowHandling.WM_NCLBUTTONDOWN, Sys.WindowHandling.HT_CAPTION, 0);
        }
        private void EditAction()
        {
            if (dtActions.SelectedRows.Count > 0)
            {
                Interfaces.IMacroAction act = (Interfaces.IMacroAction)actionTable.Rows[dtActions.SelectedRows[0].Index][0];
                frmActionEditor actEditor = new frmActionEditor(act);
                if (actEditor.ShowDialog() == DialogResult.OK)
                {
                    actionTable.Rows[dtActions.SelectedRows[0].Index][0] = actEditor.Action;
                    actionTable.Rows[dtActions.SelectedRows[0].Index][1] = actEditor.Action.Icon;
                    actionTable.Rows[dtActions.SelectedRows[0].Index][2] = actEditor.Action.VisibleText;
                    actionTable.Rows[dtActions.SelectedRows[0].Index][3] = actEditor.Action.VisibleValue;
                }
                dtActions.FirstDisplayedScrollingRowIndex = dtActions.SelectedRows[0].Index;
            }
        }
        private void CloneSelectedAction()
        {
            if (dtActions.SelectedRows.Count > 0)
            {
                int toSelect = dtActions.SelectedRows.Count;
                for (int i = toSelect - 1; i >= 0; i--)
                {
                    Interfaces.IMacroAction act = (Interfaces.IMacroAction)(actionTable.Rows[dtActions.SelectedRows[i].Index][0] as Interfaces.IMacroAction).Clone();
                    actionTable.Rows.Add(act, act.Icon, act.VisibleText, act.VisibleValue);
                }
                dtActions.ClearSelection();
                for (int i = dtActions.Rows.Count - toSelect; i < dtActions.Rows.Count; i++)
                {
                    dtActions.Rows[i].Selected = true;
                }
                dtActions.FirstDisplayedScrollingRowIndex = dtActions.SelectedRows[0].Index;
            }
        }
        private void AdjustTiming()
        {
            if (actionTable.Rows.Count < 1)
            {
                return;
            }

            frmTimeAdjuster frm = new frmTimeAdjuster();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < actionTable.Rows.Count; i++)
                {
                    if (actionTable.Rows[i][0].GetType() == typeof(Actions.WaitAction))
                    {
                        Actions.WaitAction act = (Actions.WaitAction)actionTable.Rows[i][0];
                        act.SleepAmount += frm.SleepAdjustValue;
                        if (act.SleepAmount < 0)
                        {
                            act.SleepAmount = 0;
                        }

                        actionTable.Rows[i][3] = act.VisibleValue;
                    }
                }
            }
        }
        private void TestActions()
        {
            Interfaces.IMacroAction[] acts = GetActions();
            btnTest.Invoke((MethodInvoker)delegate
            {
                progressBar1.Maximum = acts.Length;
                progressBar1.Value = 0;
                progressBar1.Visible = true;
            });
            for (int i = 0; i < acts.Length; i++)
            {
                acts[i].DoJob();
                progressBar1.Invoke((MethodInvoker)delegate
                {
                    progressBar1.Value = i;
                });
            }
            btnTest.Invoke((MethodInvoker)delegate
            {
                CancelTesting();
            });
        }
        private void StartTesting()
        {
            if (IsRecording)
            {
                Record();
            }

            Enabled = false;
            IsTesting = true;
            TestActionThread = new Thread(() => TestActions())
            {
                IsBackground = true
            };
            TestActionThread.Start();
            btnTest.Text = Statics.AppSession.ActiveLanguage.btnTest_on;
        }
        private void CancelTesting()
        {
            Enabled = true;
            IsTesting = false;
            TestActionThread.Abort();
            btnTest.Text = Statics.AppSession.ActiveLanguage.btnTest;
            progressBar1.Value = progressBar1.Maximum;
            progressBar1.Visible = false;
        }
        private void MoveSelectedRowsDown()
        {
            if (dtActions.SelectedRows.Count > 0)
            {
                int rowToStart = 0;
                int biggestIndex = 0;
                List<DataRow> rowsToMove = new List<DataRow>();
                for (int i = 0; i < dtActions.SelectedRows.Count; i++)
                {
                    if (biggestIndex < dtActions.SelectedRows[i].Index)
                    {
                        biggestIndex = dtActions.SelectedRows[i].Index;
                    }
                }

                if (biggestIndex >= dtActions.Rows.Count - 1)
                {
                    return;
                }

                for (int i = 0; i < dtActions.SelectedRows.Count; i++)
                {
                    DataRow roww = ((DataRowView)dtActions.SelectedRows[i].DataBoundItem).Row;
                    rowsToMove.Add(roww);
                }

                foreach (DataRow item in rowsToMove.OrderByDescending(t => actionTable.Rows.IndexOf(t)))
                {
                    int rIndex = actionTable.MoveRow(item, ActionTable.TableRowDirection.Down);
                    if (rowToStart < rIndex)
                    {
                        rowToStart = rIndex;
                    }
                }
                dtActions.ClearSelection();
                for (int i = 0; i < rowsToMove.Count; i++)
                {
                    dtActions.Rows[rowToStart - i].Selected = true;
                }

                dtActions.FirstDisplayedScrollingRowIndex = dtActions.SelectedRows[0].Index;
            }
        }
        private void MoveSelectedRowsUp()
        {
            if (dtActions.SelectedRows.Count > 0)
            {
                int rowToStart = 0;
                int smallestIndex = int.MaxValue;
                List<DataRow> rowsToMove = new List<DataRow>();
                for (int i = 0; i < dtActions.SelectedRows.Count; i++)
                {
                    if (smallestIndex > dtActions.SelectedRows[i].Index)
                    {
                        smallestIndex = dtActions.SelectedRows[i].Index;
                    }
                }

                if (smallestIndex < 1)
                {
                    return;
                }

                for (int i = 0; i < dtActions.SelectedRows.Count; i++)
                {
                    DataRow roww = ((DataRowView)dtActions.SelectedRows[i].DataBoundItem).Row;
                    rowsToMove.Add(roww);
                }

                foreach (DataRow item in rowsToMove.OrderBy(t => actionTable.Rows.IndexOf(t)))
                {
                    int rIndex = actionTable.MoveRow(item, ActionTable.TableRowDirection.Up);
                    if (rowToStart < rIndex)
                    {
                        rowToStart = rIndex;
                    }
                }
                dtActions.ClearSelection();
                for (int i = 0; i < rowsToMove.Count; i++)
                {
                    dtActions.Rows[rowToStart - i].Selected = true;
                }

                dtActions.FirstDisplayedScrollingRowIndex = dtActions.SelectedRows[0].Index;
            }
        }
        private void EventKeySetterClick(object sender, EventArgs e)
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

        private bool CheckActions()
        {
            #region Check down and up key ratio
            IEnumerable<Actions.KeyboardKeyAction> key_acts_test = GetActions().Where(t => t.ActionType == Enums.ActionTypes.KeyboardKey).Select(t => (Actions.KeyboardKeyAction)t);

            foreach (IGrouping<CSInputs.Enums.KeyboardKeys, Actions.KeyboardKeyAction> item in key_acts_test.Where(t => t.KeyMethod != Enums.KeyPressMethods.Press).GroupBy(t => t.KeyboardKey))
            {
                if (item.Where(t => t.KeyMethod == Enums.KeyPressMethods.Down).Count() != item.Where(t => t.KeyMethod == Enums.KeyPressMethods.Up).Count())
                {
                    MessageBox.Show(Statics.AppSession.ActiveLanguage.info_keyboard_key_missing);
                    return false;
                }
            }

            IEnumerable<Actions.MouseKeyAction> mouse_acts_test = GetActions().Where(t => t.ActionType == Enums.ActionTypes.MouseButton).Select(t => (Actions.MouseKeyAction)t);
            foreach (IGrouping<CSInputs.Enums.MouseKeys, Actions.MouseKeyAction> item in mouse_acts_test.Where(t => t.KeyMethod != Enums.KeyPressMethods.Press).GroupBy(t => t.MouseKey))
            {
                if (item.Where(t => t.KeyMethod == Enums.KeyPressMethods.Down).Count() != item.Where(t => t.KeyMethod == Enums.KeyPressMethods.Up).Count())
                {
                    MessageBox.Show(Statics.AppSession.ActiveLanguage.info_mouse_key_missing);
                    return false;
                }
            }

            if (PrimaryKey == CSInputs.Enums.KeyboardKeys.None)
            {
                if (SecondaryKey != CSInputs.Enums.KeyboardKeys.None)
                {
                    if (key_acts_test.Where(t => t.KeyboardKey == SecondaryKey).Count() > 0)
                    {
                        MessageBox.Show(Statics.AppSession.ActiveLanguage.info_actions_has_trigger_key);
                        return false;
                    }
                }
                else if (SecondaryMouseKey != CSInputs.Enums.MouseKeys.None)
                {
                    if (mouse_acts_test.Where(t => t.MouseKey == SecondaryMouseKey).Count() > 0)
                    {
                        MessageBox.Show(Statics.AppSession.ActiveLanguage.info_actions_has_trigger_key);
                        return false;
                    }
                }
            }

            #endregion
            return true;
        }
        private void SaveMacro()
        {
            if (txtMacroName.Text.Length < 2)
            {
                MessageBox.Show(Statics.AppSession.ActiveLanguage.info_enter_macro_name, "Err");
                return;
            }
            if (dtActions.Rows.Count < 1)
            {
                MessageBox.Show(Statics.AppSession.ActiveLanguage.info_no_action_to_save, "Err");
                return;
            }

            if (!CheckActions())
            {
                return;
            }

            if (Macro.Trigger != null)
            {
                Macro.Trigger.Stop();
            }

            Macro.Name = txtMacroName.Text;

            switch (cbTriggerType.SelectedIndex)
            {
                case 0:
                    if (SecondaryKey == 0 && SecondaryMouseKey == 0)
                    {
                        MessageBox.Show(Statics.AppSession.ActiveLanguage.info_no_key_selected, "Err");
                        return;
                    }
                    if (SecondaryMouseKey != 0)
                    {
                        Macro.Trigger = new Triggers.MouseTrigger();
                        (Macro.Trigger as Triggers.MouseTrigger).Method = (Enums.TriggerKeyMethods)cbTriggerMethod.SelectedIndex;
                        (Macro.Trigger as Triggers.MouseTrigger).PrimaryKey = PrimaryKey;
                        (Macro.Trigger as Triggers.MouseTrigger).SecondaryKey = SecondaryMouseKey;
                    }
                    if (SecondaryKey != 0)
                    {
                        Macro.Trigger = new Triggers.KeyboardTrigger();
                        (Macro.Trigger as Triggers.KeyboardTrigger).Method = (Enums.TriggerKeyMethods)cbTriggerMethod.SelectedIndex;
                        (Macro.Trigger as Triggers.KeyboardTrigger).PrimaryKey = PrimaryKey;
                        (Macro.Trigger as Triggers.KeyboardTrigger).SecondaryKey = SecondaryKey;
                    }
                    break;
                case 1:
                    Macro.Trigger = new Triggers.ColorTrigger();
                    (Macro.Trigger as Triggers.ColorTrigger).Method = (Enums.ColorTriggerMethods)cbTriggerMethod.SelectedIndex;
                    (Macro.Trigger as Triggers.ColorTrigger).Pos = new Point((int)mPosX.Value, (int)mPosY.Value);
                    (Macro.Trigger as Triggers.ColorTrigger).Color = pnlSelectedColor.BackColor;
                    break;
            }
            for (int i = 0; i < actionTable.Rows.Count; i++)
            {
                Macro.Trigger.Actions.Add((Interfaces.IMacroAction)actionTable.Rows[i][0]);
            }

            DialogResult = DialogResult.OK;
        }
    }
}
