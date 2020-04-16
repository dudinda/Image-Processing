using System;
using System.Text;

using ImageProcessing.App.CommonLayer.Extensions.EnumExtensions;
using ImageProcessing.Utility.Interop.Api;
using ImageProcessing.Utility.Interop.Code.Enum;

namespace ImageProcessing.Utility.Interop.Code.Wrapper
{
    public static class Dialog
    {
        private static string ModalWindowClass
            = ClassOnlyForSystem.DialogBox.GetDescription();

        /// <summary>
        /// Close all modals belonging to the specified
        /// thread.
        /// </summary>
        public static void Close(int threadId)
        {
            // Enumerate windows to find dialogs
            var callback = new NativeMethods.EnumThreadWndProc(CheckWindow);
            NativeMethods.EnumThreadWindows(threadId, callback, IntPtr.Zero);
            GC.KeepAlive(callback);
        }

        /// <summary>
        /// Check wether the specified descriptor
        /// contains any modal window. If so, close it.
        /// </summary>
        private static bool CheckWindow(IntPtr hWnd, IntPtr lp)
        {
            // Checks if the descriptor is a Windows dialog
            var builder = new StringBuilder(260);

            if (NativeMethods.GetClassName(hWnd, builder, builder.Capacity) == 0)
            {
                return false;
            }

            if (builder.ToString() == ModalWindowClass)
            {
                // Close it by sending WM_CLOSE to the window
                NativeMethods.SendMessage(hWnd, 0x0010, IntPtr.Zero, IntPtr.Zero);
            }

            return true;
        }
    }
}
