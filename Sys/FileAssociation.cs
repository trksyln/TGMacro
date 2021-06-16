using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;

namespace TGMacro
{
    public static class FileAssociation
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        private static bool DoesFileAssociationExists(string extension)
        {
            RegistryKey classes = GetClasses();
            RegistryKey extensionKey = classes.OpenSubKey(extension);
            return (extensionKey != null);
        }

        public static void CreateFileAssociation(string extension, string key, string description, string path)
        {
            RegistryKey classes = GetClasses();
            if (DoesFileAssociationExists(extension))
            {
                classes.DeleteSubKey(extension);
            }

            RegistryKey extensionKey = classes.CreateSubKey(extension);
            extensionKey.SetValue(null, key);

            RegistryKey typeKey = classes.CreateSubKey(key);
            typeKey.SetValue(null, description);

            RegistryKey shellKey = typeKey.CreateSubKey("shell");
            RegistryKey shellOpenKey = shellKey.CreateSubKey("open");
            RegistryKey shellOpenCommandKey = shellOpenKey.CreateSubKey("command");
            shellOpenCommandKey.SetValue(null, path);
            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }

        private static RegistryKey GetClasses()
        {
            return Registry.ClassesRoot;
        }

        public static void AssociateThis()
        {
            string path = string.Format("\"{0}\" \"%1\"", System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            CreateFileAssociation(".tmacroproj", "TMacroProjectFile", "TGMacro Project File", path);
        }
    }
}
