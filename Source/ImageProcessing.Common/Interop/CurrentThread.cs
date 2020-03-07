using ImageProcessing.Common.Interop.Api;

namespace ImageProcessing.Common.Interop
{
    /// <summary>
    /// Provides a wrapper over the native windows kernel
    /// method <see cref="NativeMethods.GetCurrentThreadId"/>
    /// </summary>
    public static class CurrentThread
    {
        public static int GetId() => NativeMethods.GetCurrentThreadId();
    }
}
