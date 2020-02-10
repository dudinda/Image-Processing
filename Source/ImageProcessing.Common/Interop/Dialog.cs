using System;
using System.Text;

using ImageProcessing.Common.Interop.Api;

public static class Dialog
{
    private const string ModalWindowClass = "#32770";

    public static void Close(int threadId)
    {
        // Enumerate windows to find dialogs
        var callback = new UnmanagedApi.EnumThreadWndProc(CheckWindow);
        UnmanagedApi.EnumThreadWindows(threadId, callback, IntPtr.Zero);
        GC.KeepAlive(callback);
    }

    private static bool CheckWindow(IntPtr hWnd, IntPtr lp)
    {
        // Checks if the descriptor is a Windows dialog
        var builder = new StringBuilder(260);

        UnmanagedApi.GetClassName(hWnd, builder, builder.Capacity);

        if (builder.ToString() == ModalWindowClass)
        {
            // Close it by sending WM_CLOSE to the window
            UnmanagedApi.SendMessage(hWnd, 0x0010, IntPtr.Zero, IntPtr.Zero);
        }

        return true;
    }
}