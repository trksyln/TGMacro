using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace TGMacro
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        [Obsolete]
        private static void Main(string[] args)
        {
            new Mutex(true, "trksyln-TMACRO", out bool createdNew);
            if (!createdNew)
            {
                MessageBox.Show("Already running.", "Err");
                return;
            }
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            AppDomain.CurrentDomain.AppendPrivatePath(@"Bin");
            List<string> prjList = new List<string>();
            for (int i = 0; i < args.Length; i++)
            {
                FileInfo fi = new FileInfo(args[i]);
                if (fi.Exists && fi.Extension.ToLower() == "tmacroproj")
                {
                    prjList.Add(fi.FullName);
                }
            }

            if (!File.Exists("Bin\\CSInputs.dll"))
            {
                MessageBox.Show("\"CSInputs.dll\" could not be found in \"Bin\" folder.", "Err");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain(args));
        }

    }
}
