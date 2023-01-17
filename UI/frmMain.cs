using CSInputs.ReadInput;
using CSInputs.Structs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using TGMacro.Bases;
using TGMacro.ProjectData;

namespace TGMacro
{
    public partial class frmMain : Form
    {
        private readonly string[] prjList = new string[0];
        public frmMain(params string[] param)
        {
            InitializeComponent();
            TopMost = Statics.AppSession.TopMost;
            prjList = param;
            Shown += FrmMain_Shown;
        }

        private void LoadLanguage()
        {
            btnFile.Text = Statics.AppSession.ActiveLanguage.btnFile;
            lblNoMacroMessage.Text = Statics.AppSession.ActiveLanguage.info_no_macro;
            btnHelp.Text = Statics.AppSession.ActiveLanguage.btnHelp;
            btnAbout.Text = Statics.AppSession.ActiveLanguage.btnAbout;
            btnAdd.Text = Statics.AppSession.ActiveLanguage.btnAdd;
            btnEnable.Text = Statics.AppSession.ActiveLanguage.btnEnable_off;
            btnImportProject.Text = Statics.AppSession.ActiveLanguage.btnImportProject;
            btnImportScript.Text = Statics.AppSession.ActiveLanguage.btnImportScript;
            btnLoadProject.Text = Statics.AppSession.ActiveLanguage.btnLoadProject;
            btnSaveProject.Text = Statics.AppSession.ActiveLanguage.btnSaveProject;
            btnUpdates.Text = Statics.AppSession.ActiveLanguage.btnUpdates;
            toolTip1.SetToolTip(btnStatus, Statics.AppSession.ActiveLanguage.text_macro_status);
            toolTip1.SetToolTip(btnTopMost, Statics.AppSession.ActiveLanguage.btnTopMost);
            toolTip1.SetToolTip(picLanguage, Statics.AppSession.ActiveLanguage.btnChangeLanguage);
            toolTip1.SetToolTip(cmbLanguage, Statics.AppSession.ActiveLanguage.btnChangeLanguage);
            toolTip1.SetToolTip(button1, "Buy me a coffee");
        }
        private void FrmMain_Shown(object sender, EventArgs e)
        {
            // add embedded languages to languages dictionary
            var tur = new Langs.TUR();
            var eng = new Langs.ENG();
            Statics.AppSession.Languages.Add(new Langs.TUR());
            Statics.AppSession.Languages.Add(new Langs.ENG());

            // import third party languages with distinct language names
            ImportLanguages();

            // add languages to ui
            cmbLanguage.DataSource = Statics.AppSession.Languages;

            // check if three letter system language name exist in languages
            var systemLanguageMatch = Statics.AppSession.Languages.Where(t => t.language_name.ToLower() == System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName.ToLower()).FirstOrDefault();
            if (systemLanguageMatch != null)
            {
                cmbLanguage.SelectedIndex = cmbLanguage.FindString(systemLanguageMatch.language_name);
                Statics.AppSession.ActiveLanguage = systemLanguageMatch;
            }
            else
            {
                cmbLanguage.SelectedIndex = cmbLanguage.FindString("ENG");
                Statics.AppSession.ActiveLanguage = eng;
            }

            Statics.AppSession.InputListener = new InputListener();


            LoadLanguage();
            checkEnableButton();
            checkTopMostButton();

            registerEvents();

            for (int i = 0; i < prjList.Length; i++)
            {
                ImportProject(prjList[i]);
            }

            Statics.AppSession.InputListener.KeyboardInputs += Hook_KeyboardInputs;

        }

        private void ImportLanguages()
        {
            if (!Directory.Exists("Langs"))
                return;

            var langFilePaths = Directory.GetFiles("Langs\\", "*.tglang");
            if (langFilePaths.Count() < 1)
                return;


            var jsonSerializer = new JavaScriptSerializer();
            for (int i = 0; i < langFilePaths.Length; i++)
            {
                try
                {
                    string json = File.ReadAllText(langFilePaths[i]);
                    var newLang = jsonSerializer.Deserialize<LanguageBase>(json);
                    if (Statics.AppSession.Languages.Where(t => t.language_name.ToUpper() == newLang.language_name.ToUpper()).Count() > 0
                        || newLang.language_name.Length != 3)
                        continue;
                    Statics.AppSession.Languages.Add(newLang);
                }
                catch
                {
                    MessageBox.Show(langFilePaths[i] + " couldn't be added. Invalid file.", "Invalid language file");
                }
            }
        }

        private void Hook_KeyboardInputs(KeyboardData data, ref ModifierKey modifierKey)
        {
            if (data.Key == CSInputs.Enums.KeyboardKeys.Home && data.Flags == CSInputs.Enums.KeyFlags.Up)
            {
                Statics.AppSession.Enable = !Statics.AppSession.Enable;
                checkEnableButton();
            }
        }

        private void checkEnableButton()
        {
            if (Statics.AppSession.Enable)
            {
                btnEnable.Text = Statics.AppSession.ActiveLanguage.btnEnable_on;
                btnEnable.Image = Properties.Resources.stop_32;
            }
            else
            {
                btnEnable.Text = Statics.AppSession.ActiveLanguage.btnEnable_off;
                btnEnable.Image = Properties.Resources.start_32;
            }
        }

        private void checkTopMostButton()
        {
            if (Statics.AppSession.TopMost)
            {
                btnTopMost.BackgroundImage = Properties.Resources.lock_16;
            }
            else
            {
                btnTopMost.BackgroundImage = Properties.Resources.unlock_16;
            }
        }

        private void registerEvents()
        {
            Statics.AppSession.LanguageChanged += (s, e) => LoadLanguage();

            button1.Click += (s, e) => Process.Start("https://www.buymeacoffee.com/trksyln");

            btnFile.Click += (s, e) =>
            {
                System.Drawing.Point location = PointToScreen(btnFile.Location);
                location.Y += btnFile.Height;
                ctFileMenu.Show(location);
            };

            btnHelp.Click += (s, e) =>
            {
                System.Drawing.Point location = PointToScreen(btnHelp.Location);
                location.Y += btnHelp.Height;
                ctHelpMenu.Show(location);
            };

            btnUpdates.Click += (s, e) =>
            {
                try
                {
                    System.Diagnostics.Process.Start("https://sourceforge.net/projects/tmacro/");
                }
                catch { }
            };
            cmbLanguage.SelectedIndexChanged += (s, e) =>
            {
                Statics.AppSession.ActiveLanguage = (LanguageBase)cmbLanguage.SelectedItem;
            };

            btnClose.Click += (s, e) => Close();
            btnMin.Click += (s, e) => WindowState = FormWindowState.Minimized;
            lblTitle.MouseDown += (s, e) =>
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Sys.WindowHandling.ReleaseCapture();
                    Sys.WindowHandling.SendMessage(Handle, Sys.WindowHandling.WM_NCLBUTTONDOWN, Sys.WindowHandling.HT_CAPTION, 0);
                }
            };
            pnlMain.MouseDown += (s, e) =>
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Sys.WindowHandling.ReleaseCapture();
                    Sys.WindowHandling.SendMessage(Handle, Sys.WindowHandling.WM_NCLBUTTONDOWN, Sys.WindowHandling.HT_CAPTION, 0);
                }
            };
            Statics.AppSession.TopMostStatusChanged += (s, e) =>
            {
                checkTopMostButton();
                TopMost = Statics.AppSession.TopMost;
            };
            btnEnable.Click += (s, e) =>
            {
                Statics.AppSession.Enable = !Statics.AppSession.Enable;
                checkEnableButton();
            };
            btnStatus.Click += (s, e) =>
            {
                Statics.AppSession.Enable = !Statics.AppSession.Enable;
                checkEnableButton();
            };
            btnTopMost.Click += (s, e) =>
            {
                Statics.AppSession.TopMost = !Statics.AppSession.TopMost;
            };
            Statics.AppSession.EnableStatusChanged += (s, e) =>
            {
                if (Statics.AppSession.Enable)
                {
                    btnStatus.BackgroundImage = Properties.Resources.playing_16;
                }
                else
                {
                    btnStatus.BackgroundImage = Properties.Resources.paused_16;
                }
            };

            btnAdd.Click += (s, e) =>
            {
                frmMacroEditor mEditor = new frmMacroEditor();
                if (mEditor.ShowDialog() == DialogResult.OK)
                {
                    MacroItem mcr = mEditor.Macro;
                    ucMacroItem itm = new ucMacroItem(mcr, pnlMacroList);
                    pnlMacroList.Controls.Add(itm);

                }
            };
            pnlMacroList.ControlAdded += (s, e) =>
            {
                lblNoMacroMessage.Visible = pnlMacroList.Controls.Count < 1;
                ucMacroItem itm = (e.Control as ucMacroItem);
                Statics.AppSession.Macros.Add(itm.Macro);

                ResizeMacroItems();
            };
            pnlMacroList.ControlRemoved += (s, e) =>
            {
                lblNoMacroMessage.Visible = pnlMacroList.Controls.Count < 1;
                Statics.AppSession.Macros.Remove((e.Control as ucMacroItem).Macro);
                ResizeMacroItems();
            };

            btnSaveProject.Click += (s, e) =>
            {
                ShowSaveDialog();
            };

            btnLoadProject.Click += (s, e) =>
            {
                ShowLoadDialog();
            };

            btnImportProject.Click += (s, e) =>
            {
                ShowImportDialog();
            };

            btnImportScript.Click += (s, e) =>
            {
                frmMacroEditor mEditor = new frmMacroEditor(null, true);
                if (mEditor.ShowDialog() == DialogResult.OK)
                {
                    MacroItem mcr = mEditor.Macro;
                    ucMacroItem itm = new ucMacroItem(mcr, pnlMacroList);
                    pnlMacroList.Controls.Add(itm);

                }
            };

            btnAbout.Click += (s, e) =>
            {
                new frmAbout().ShowDialog();
            };
        }

        private void ShowSaveDialog()
        {
            if (Statics.AppSession.Macros.Count < 1)
            {
                MessageBox.Show(Statics.AppSession.ActiveLanguage.info_nothing_to_save, "Err");
                return;
            }
            saveFileDialog1.Title = "Save Project";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveProject(saveFileDialog1.FileName);
            }
        }

        private void ShowLoadDialog()
        {
            openFileDialog1.Title = "Open Project";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadProject(openFileDialog1.FileName);
            }
        }

        private void ShowImportDialog()
        {
            openFileDialog1.Title = "Import Project";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImportProject(openFileDialog1.FileName);
            }
        }

        private void SaveProject(string filePath)
        {
            try
            {
                TGMacroProject project = new TGMacroProject();
                List<Macro> prjMacros = new List<Macro>();
                foreach (MacroItem item in Statics.AppSession.Macros)
                {
                    Macro prjMacro = new Macro(item.Name)
                    {
                        Trigger = new Trigger(item.Trigger)
                    };
                    List<ProjectData.Action> acts = new List<ProjectData.Action>();
                    foreach (Interfaces.IMacroAction act in item.Trigger.Actions)
                    {
                        acts.Add(new ProjectData.Action(act));
                    }
                    prjMacro.Actions = acts.ToArray();
                    prjMacros.Add(prjMacro);
                }
                project.Macros = prjMacros.ToArray();
                SaveProjectFile(project, filePath);
            }
            catch
            {
                MessageBox.Show(Statics.AppSession.ActiveLanguage.error_saving_project, "Err");
            }
        }

        private void LoadProject(string filePath)
        {
            try
            {
                foreach (MacroItem item in Statics.AppSession.Macros)
                {
                    item.Trigger.Dispose();
                }
                Statics.AppSession.Macros.Clear();

                pnlMacroList.Controls.Clear();
                TGMacroProject project = LoadProjectFile(filePath);
                foreach (Macro mcros in project.Macros)
                {
                    MacroItem mi = new MacroItem
                    {
                        Name = mcros.Name,
                        Trigger = mcros.Trigger.GetTrigger()
                    };
                    List<Interfaces.IMacroAction> acts = new List<Interfaces.IMacroAction>();
                    foreach (ProjectData.Action act in mcros.Actions)
                    {
                        acts.Add(act.GetAction());
                    }
                    mi.Trigger.Actions = acts;

                    ucMacroItem itm = new ucMacroItem(mi, pnlMacroList);
                    pnlMacroList.Controls.Add(itm);
                }

            }
            catch
            {
                MessageBox.Show(Statics.AppSession.ActiveLanguage.error_loding_project, "Err");
            }
        }

        private void ImportProject(string filePath)
        {
            try
            {
                TGMacroProject project = LoadProjectFile(filePath);
                foreach (Macro mcros in project.Macros)
                {
                    MacroItem mi = new MacroItem
                    {
                        Name = mcros.Name,
                        Trigger = mcros.Trigger.GetTrigger()
                    };
                    List<Interfaces.IMacroAction> acts = new List<Interfaces.IMacroAction>();
                    foreach (ProjectData.Action act in mcros.Actions)
                    {
                        acts.Add(act.GetAction());
                    }
                    mi.Trigger.Actions = acts;

                    ucMacroItem itm = new ucMacroItem(mi, pnlMacroList);
                    pnlMacroList.Controls.Add(itm);
                }
            }
            catch
            {
                MessageBox.Show(Statics.AppSession.ActiveLanguage.error_importing_project, "Err");
            }
        }

        private void SaveProjectFile(TGMacroProject obj, string path)
        {
            if (File.Exists(path))
                try
                {
                    File.Delete(path);
                }
                catch { }
            DataContractJsonSerializer xs = new DataContractJsonSerializer(obj.GetType());
            using (FileStream tw = new FileStream(path, FileMode.OpenOrCreate))
            {
                xs.WriteObject(tw, obj);
            }
        }

        private TGMacroProject LoadProjectFile(string path)
        {
            DataContractJsonSerializer xs = new DataContractJsonSerializer(typeof(TGMacroProject));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                return (TGMacroProject)xs.ReadObject(fs);
            }

        }

        private void ResizeMacroItems()
        {
            foreach (ucMacroItem item in pnlMacroList.Controls)
            {
                item.Width = pnlMacroList.VerticalScroll.Visible ? pnlMacroList.Width - 30 : pnlMacroList.Width - 6;
            }
        }
    }
}
