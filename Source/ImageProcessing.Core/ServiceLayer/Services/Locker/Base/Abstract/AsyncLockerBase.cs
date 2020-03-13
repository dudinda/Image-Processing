using System;
using System.Threading;
using System.Threading.Tasks;

using ImageProcessing.Core.ServiceLayer.Services.Locker.Base.Interface;

namespace ImageProcessing.Core.ServiceLayer.Services.Locker.Base.Abstract
{
    public abstract class AsyncLockerBase : IAsyncLocker
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public async Task<T> LockAsync<T>(Func<T> worker)
        {
            await _semaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                return await Task.Run(() => worker()).ConfigureAwait(false);
            }
            catch
            {
                throw;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task LockAsync(Action worker)
        {
            await _semaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                await Task.Run(() => worker()).ConfigureAwait(false);
            }
            catch
            {
                throw;
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
