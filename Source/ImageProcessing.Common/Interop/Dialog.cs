using System;
using System.Runtime.InteropServices;
using System.Text;

public static class Dialog
{
    private const string ModalWindowClass = "#32770";

    private delegate bool EnumThreadWndProc(IntPtr hWnd, IntPtr lp);

    [DllImport("user32.dll")]
    private static extern bool EnumThreadWindows(int tid, EnumThreadWndProc callback, IntPtr lp);

    [DllImport("user32.dll")]
    private static extern int GetClassName(IntPtr hWnd, StringBuilder buffer, int buflen);

    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

    public static void Close(int threadId)
    {
        // Enumerate windows to find dialogs
        EnumThreadWndProc callback = new EnumThreadWndProc(CheckWindow);
        EnumThreadWindows(threadId, callback, IntPtr.Zero);
        GC.KeepAlive(callback);
    }

    private static bool CheckWindow(IntPtr hWnd, IntPtr lp)
    {
        // Checks if <hWnd> is a Windows dialog
        var builder = new StringBuilder(260);

        GetClassName(hWnd, builder, builder.Capacity);

        if (builder.ToString() == ModalWindowClass)
        {
            // Close it by sending WM_CLOSE to the window
            SendMessage(hWnd, 0x0010, IntPtr.Zero, IntPtr.Zero);
        }

        return true;
    }
}