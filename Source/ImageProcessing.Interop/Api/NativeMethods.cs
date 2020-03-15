using System;
using System.Runtime.InteropServices;
using System.Text;

using ImageProcessing.Interop.Code.Structs;

namespace ImageProcessing.Interop.Api
{
    /// <summary>
    /// Provides the API from windows kernel
    /// native methods
    /// </summary>
    internal static class NativeMethods
    {
        /// <summary>
        /// Receives the window handles associated
        /// with a thread
        /// </summary>
        internal delegate bool EnumThreadWndProc(IntPtr hWnd, IntPtr lp);

        /// <summary>
        /// Enumerates all nonchild windows associated with a thread by passing the handle
        /// to each window, in turn, to an application-defined callback function. 
        /// </summary>
        [DllImport("user32.dll")]
        internal static extern bool EnumThreadWindows(int tid, EnumThreadWndProc callback, IntPtr lp);

        /// <summary>
        /// Retrieves the name of the class to which the specified window belongs.
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern int GetClassName(IntPtr hWnd, StringBuilder buffer, int buflen);

        /// <summary>
        /// Sends the specified message to a window or windows.
        /// The <b>SendMessage</b> function calls the window procedure for the specified window and
        /// does not return until the window procedure has processed the message.
        /// </summary>
        [DllImport("user32.dll")]
        internal static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        /// <summary>
        /// Retrieves the position of the mouse cursor, in screen coordinates.
        /// </summary>
        [DllImport("user32.dll")]
        internal static extern bool GetCursorPos(out LPPOINT lpPoint);

        /// <summary>
        /// Retrieves the thread identifier of the calling thread.
        /// </summary>
        [DllImport("kernel32.dll")]
        internal static extern int GetCurrentThreadId();

    }
}
