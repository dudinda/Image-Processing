using System;
using System.Threading.Tasks;

namespace ImageProcessing.Presentation.Code.Singletons
{
    internal class ZoomLocker
    {
        private static ZoomLocker _instance;
        private static object _sync = new object();

        private static AsyncLocker _locker;

        private ZoomLocker() 
        {
            _locker = new AsyncLocker();
        }

        public static ZoomLocker Get()
        {
            if (_instance is null)
            {
                lock (_sync)
                {
                    if (_instance is null)
                    {
                        _instance = new ZoomLocker();
                    }
                }
            }
            return _instance;
        }

        public async Task LockZoom(Action worker)
        {
            await _locker.LockAsync(worker).ConfigureAwait(false);
        }

        public async Task<T> LockZoom<T>(Func<T> worker)
        {
            return await _locker.LockAsync(worker).ConfigureAwait(false);
        }
    }
}
