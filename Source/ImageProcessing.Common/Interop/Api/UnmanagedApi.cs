using System;
using System.Runtime.InteropServices;
using System.Text;

using ImageProcessing.Common.Interop.Structs;

namespace ImageProcessing.Common.Interop.Api
{
    internal static class UnmanagedApi
    {
        internal delegate bool EnumThreadWndProc(IntPtr hWnd, IntPtr lp);

        [DllImport("user32.dll")]
        internal static extern bool EnumThreadWindows(int tid, EnumThreadWndProc callback, IntPtr lp);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern int GetClassName(IntPtr hWnd, StringBuilder buffer, int buflen);

        [DllImport("user32.dll")]
        internal static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        [DllImport("user32.dll")]
        internal static extern bool GetCursorPos(out LPPOINT lpPoint);

        [DllImport("kernel32.dll")]
        internal static extern int GetCurrentThreadId();

    }
}
