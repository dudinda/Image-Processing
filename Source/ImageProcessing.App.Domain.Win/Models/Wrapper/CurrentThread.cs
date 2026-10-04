using ImageProcessing.Utility.Interop.Services.Api;

namespace ImageProcessing.Utility.Interop.Models.Wrapper
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
