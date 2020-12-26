using DevExpress.Utils.Drawing.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sinowyde.DOP.DataReport.Control
{
    /// <summary>
    /// 截图
    /// </summary>
    public class DevImageCapturer
    {
        [System.Runtime.InteropServices.DllImport("USER32.dll")]
        internal static extern IntPtr GetDC(IntPtr dc);
        [System.Runtime.InteropServices.DllImport("USER32.dll")]
        internal static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [System.Runtime.InteropServices.DllImport("USER32.dll")]
        internal static extern IntPtr GetDesktopWindow();
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        internal static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        internal static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        internal static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        internal static extern bool DeleteObject(IntPtr hObject);
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        internal static extern IntPtr SelectObject(IntPtr hdc, IntPtr obj);
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        internal static extern IntPtr CreateSolidBrush(int color);
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        internal static extern IntPtr CreatePatternBrush(IntPtr hBitmap);

        /// <summary>
        /// 获取控件的截图
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="pattern">图片</param>
        /// <returns></returns>
        public static Bitmap GetControlBitmap(System.Windows.Forms.Control control, Bitmap pattern)
        {
            int width = control.Width;
            int height = control.Height;
            if (control is Form)
            {
                width = control.ClientRectangle.Width;
                height = control.ClientRectangle.Height;
            }
            IntPtr hdc = GetDC(control.Handle);
            IntPtr compDC = CreateCompatibleDC(hdc);
            IntPtr compHBmp = CreateCompatibleBitmap(hdc, width, height);
            IntPtr prev = SelectObject(compDC, compHBmp);
            IntPtr brush = IntPtr.Zero, prevBrush = IntPtr.Zero;
            if (pattern != null)
            {
                brush = CreatePatternBrush(pattern.GetHbitmap());
                prevBrush = SelectObject(compDC, brush);
            }
            Point pt = new Point(0, 0);
            BitBlt(compDC, 0, 0, width, height, hdc, pt.X, pt.Y, 0x00C000CA);
            SelectObject(compDC, prev);
            if (prevBrush != IntPtr.Zero)
                SelectObject(compDC, prevBrush);
            ReleaseDC(control.Handle, hdc);
            NativeMethods.DeleteDC(compDC);
            Bitmap bmp = Bitmap.FromHbitmap(compHBmp);
            DeleteObject(compHBmp);
            if (brush != IntPtr.Zero)
                DeleteObject(brush);
            return bmp;
        }

        /// <summary>
        /// 获取控件的截图
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="pattern">图片</param>
        /// <param name="offSetX">X</param>
        /// <param name="offSetY">Y</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <returns></returns>
        public static Bitmap GetControlBitmap(System.Windows.Forms.Control control, Bitmap pattern, int offSetX = 0, int offSetY = 0, int width = 0, int height = 0)
        {
            width = width == 0 ? control.Width : width;
            height = height == 0 ? control.Height : height;
            if (control is Form)
            {
                width = control.ClientRectangle.Width;
                height = control.ClientRectangle.Height;
            }
            IntPtr hdc = GetDC(control.Handle);
            IntPtr compDC = CreateCompatibleDC(hdc);
            IntPtr compHBmp = CreateCompatibleBitmap(hdc, width, height);
            IntPtr prev = SelectObject(compDC, compHBmp);
            IntPtr brush = IntPtr.Zero, prevBrush = IntPtr.Zero;
            if (pattern != null)
            {
                brush = CreatePatternBrush(pattern.GetHbitmap());
                prevBrush = SelectObject(compDC, brush);
            }
            Point pt = new Point(offSetX, offSetY);
            BitBlt(compDC, 0, 0, width, height, hdc, pt.X, pt.Y, 0x00C000CA);
            SelectObject(compDC, prev);
            if (prevBrush != IntPtr.Zero)
                SelectObject(compDC, prevBrush);
            ReleaseDC(control.Handle, hdc);
            NativeMethods.DeleteDC(compDC);
            Bitmap bmp = Bitmap.FromHbitmap(compHBmp);
            DeleteObject(compHBmp);
            if (brush != IntPtr.Zero)
                DeleteObject(brush);
            return bmp;
        }
    }
}
