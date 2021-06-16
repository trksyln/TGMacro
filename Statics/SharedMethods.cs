using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace TGMacro.Statics
{
    public static class SharedMethods
    {
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);


        public static Color GetColorAt(Point location)
        {
            Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
            try
            {
                using (Graphics gdest = Graphics.FromImage(screenPixel))
                {
                    using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                    {
                        IntPtr hSrcDC = gsrc.GetHdc();
                        IntPtr hDC = gdest.GetHdc();
                        int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                        gdest.ReleaseHdc();
                        gsrc.ReleaseHdc();
                    }
                }
            }
            catch { }

            return screenPixel.GetPixel(0, 0);
        }

        public static bool getPrimaryKeyStatus(CSInputs.Enums.KeyboardKeys key, CSInputs.ReadInput.ModifierKey modifierKey)
        {
            switch (key)
            {
                case CSInputs.Enums.KeyboardKeys.Ctrl:
                    return modifierKey.Control;
                case CSInputs.Enums.KeyboardKeys.Alt:
                    return modifierKey.Alt;
                case CSInputs.Enums.KeyboardKeys.Shift:
                    return modifierKey.Shift;
                default:
                    return false;
            }
        }
    }
}
