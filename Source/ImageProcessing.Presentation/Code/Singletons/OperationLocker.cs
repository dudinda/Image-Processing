using System;
using System.Threading.Tasks;

namespace ImageProcessing.Presentation.Code.Singletons
{
    internal class OperationLocker
    {
        private static OperationLocker _instance;
        private static object _sync = new object();

        private AsyncLocker _locker;
        private OperationLocker()
        {
            _locker = new AsyncLocker();
        }
        public static OperationLocker Get()
        {
            if (_instance is null)
            {
                lock (_sync)
                {
                    if (_instance is null)
                    {
                        _instance = new OperationLocker();
                    }
                }
            }
            return _instance;
        }

        public async Task LockOperation(Action worker)
        {
            await _locker.LockAsync(worker).ConfigureAwait(false);
        }

        public async Task<T> LockOperation<T>(Func<T> worker)
        {
            return await _locker.LockAsync(worker).ConfigureAwait(false);
        }
    }
}
