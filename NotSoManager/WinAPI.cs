using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NotSoManager
{
    class WinAPI
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("User32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int status);


        public static bool PixelScan(Bitmap img, Point point, Color pixel)
        {
            return pixel == img.GetPixel(point.X, point.Y);
        }
        public static Process WaitForProcessByName(string name)
        {
            while (Process.GetProcessesByName(name).Length <= 0)
                Thread.Sleep(10);
            return Process.GetProcessesByName(name)[0];
        }
        public static bool CheckProcessByName(string name)
        {
            return !(Process.GetProcessesByName(name).Length <= 0);
        }
        public static Size GetWindowSize(IntPtr hWnd)
        {
            Rect rect = new Rect();
            WinAPI.GetWindowRect(hWnd, ref rect);
            return new Size(rect.bottom - rect.top, rect.right - rect.left);
        }
        public static Bitmap GetImgByName(string name)
        {
            Process proc = Process.GetProcessesByName(name)[0];
            Rect rect = new Rect();
            WinAPI.ShowWindow(proc.MainWindowHandle, 1);
            Thread.Sleep(10);
            WinAPI.GetWindowRect(proc.MainWindowHandle, ref rect);
            Size windowSize = GetWindowSize(proc.MainWindowHandle);
            Bitmap img = new Bitmap(windowSize.Width, windowSize.Height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(img);
            graphics.CopyFromScreen(rect.left, rect.top, 0, 0, windowSize, CopyPixelOperation.SourceCopy);

            return img;
        }
    }
}
