using ImageProcessing.App.Domain.Win.Services.Api;

namespace ImageProcessing.App.Domain.Win.Models.Wrapper
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
