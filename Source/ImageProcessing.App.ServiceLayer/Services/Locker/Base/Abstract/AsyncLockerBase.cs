using System;
using System.Threading;
using System.Threading.Tasks;

using ImageProcessing.App.ServiceLayer.Services.Locker.Base.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.Locker.Base.Abstract
{
    /// <inheritdoc cref="IAsyncLocker" />
    public abstract class AsyncLockerBase : IAsyncLocker
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        /// <inheritdoc />
        public async Task<TResult> LockAsync<TResult>(Func<TResult> worker)
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

        /// <inheritdoc />
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
