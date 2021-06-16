using System;
using System.Collections.Generic;
using System.Reflection;

namespace TGMacro.Statics
{
    public static class AppSession
    {
        public static event EventHandler LanguageChanged;
        public static Interfaces.ILanguage _activeLanguage;
        public static Interfaces.ILanguage ActiveLanguage { get => _activeLanguage; set { _activeLanguage = value; LanguageChanged?.Invoke(null, null); } }

        private static bool _enable = false;

        public static bool Enable
        {
            get => _enable;
            set
            {
                _enable = value;
                EnableStatusChanged?.Invoke(null, null);
            }
        }
        public static event EventHandler EnableStatusChanged;
        public static string Version = Assembly.GetExecutingAssembly().GetName().Version.Major + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor;
        public static float BuildNumber = Assembly.GetExecutingAssembly().GetName().Version.Revision;
        private static bool _topMost = false;
        public static bool TopMost
        {
            get => _topMost;
            set
            {
                _topMost = value;
                TopMostStatusChanged?.Invoke(null, null);
            }
        }

        public static event EventHandler TopMostStatusChanged;

        public static CSInputs.ReadInput.InputListener InputListener;

        public static List<MacroItem> Macros = new List<MacroItem>();
    }
}
