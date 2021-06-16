using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TGMacro
{
    public static class ScriptParser
    {
        private static readonly OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public static void LoadScriptTo(DataTable actionsTalbe)
        {
            openFileDialog1.Filter = "AMC Script |*.amc";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                if (fi.Extension.ToLower() == ".amc")
                {
                    importAMC(actionsTalbe, openFileDialog1.FileName);
                }
                else
                {
                    MessageBox.Show(Statics.AppSession.ActiveLanguage.error_unkown_script, "Err");
                }
            }
        }

        private static void importAMC(DataTable actionsTalbe, string filePath)
        {
            frmTimeAdjuster frmAdjuster = new frmTimeAdjuster();
            if (frmAdjuster.ShowDialog() == DialogResult.OK)
            {
                foreach (Interfaces.IMacroAction item in amcToActions(filePath, frmAdjuster.SleepAdjustValue))
                {
                    actionsTalbe.Rows.Add(item, item.Icon, item.VisibleText, item.VisibleValue);
                }
            }
        }

        private static Interfaces.IMacroAction[] amcToActions(string filePath, int waitAdjustAmount = 0)
        {
            List<Interfaces.IMacroAction> tmpActions = new List<Interfaces.IMacroAction>();
            try
            {
                string amcFile = File.ReadAllText(filePath);
                amcFile = Regex.Replace(amcFile, "<(.*?)>", "");
                string[] amcFileLines = amcFile.ToLower().Split('\n').Where(t => t.Trim().Length > 3).ToArray();

                foreach (string item in amcFileLines)
                {
                    string[] tmpLine = item.Trim().Split(' ');
                    if (tmpLine[0] == "mover" && tmpLine.Length == 3)
                    {
                        tmpActions.Add(new Actions.MouseMoveAction()
                        {
                            MouseMoveMethod = CSInputs.Enums.MousePositioning.Relative,
                            MousePos = new System.Drawing.Point(int.Parse(tmpLine[1]), int.Parse(tmpLine[2]))
                        });
                    }

                    if (tmpLine[0] == "leftdown" && tmpLine.Length == 2)
                    {
                        tmpActions.Add(new Actions.MouseKeyAction()
                        {
                            KeyMethod = Enums.KeyPressMethods.Down,
                            MouseKey = CSInputs.Enums.MouseKeys.MouseLeft,
                            MouseMoveMethod = CSInputs.Enums.MousePositioning.Relative,
                        });
                    }

                    if (tmpLine[0] == "leftup" && tmpLine.Length == 2)
                    {
                        tmpActions.Add(new Actions.MouseKeyAction()
                        {
                            KeyMethod = Enums.KeyPressMethods.Up,
                            MouseKey = CSInputs.Enums.MouseKeys.MouseLeft,
                            MouseMoveMethod = CSInputs.Enums.MousePositioning.Relative,
                        });
                    }

                    if (tmpLine[0] == "delay" && tmpLine.Length == 3)
                    {
                        tmpActions.Add(new Actions.WaitAction()
                        {
                            SleepAmount = int.Parse(tmpLine[1]) + waitAdjustAmount
                        });
                    }
                }
            }
            catch
            {
                MessageBox.Show(Statics.AppSession.ActiveLanguage.error_import_script, "Err");
            }
            return tmpActions.ToArray();
        }

    }
}
