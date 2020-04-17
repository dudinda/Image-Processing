using ImageProcessing.Utility.Interop.Api;

namespace ImageProcessing.Utility.Interop.Wrapper
{
    /// <summary>
    /// Provides a wrapper over the native windows kernel
    /// method <see cref="NativeMethods.GetCurrentThreadId"/>.
    /// </summary>
    public static class CurrentThread
    {
        /// <inheritdoc cref="NativeMethods.GetCurrentThreadId"/>
        public static int GetId()
            => NativeMethods.GetCurrentThreadId();
    }
}
