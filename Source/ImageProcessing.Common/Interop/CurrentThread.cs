using ImageProcessing.Common.Interop.Api;

namespace ImageProcessing.Common.Interop
{
    public static class CurrentThread
    {
        public static int GetId() => UnmanagedApi.GetCurrentThreadId();
    }
}
