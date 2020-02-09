using System.Runtime.InteropServices;

namespace ImageProcessing.Common.Interop
{
    public static class CurrentThread
    {
        [DllImport("kernel32.dll")]
        private static extern int GetCurrentThreadId();

        public static int GetId() => GetCurrentThreadId();
    }
}
