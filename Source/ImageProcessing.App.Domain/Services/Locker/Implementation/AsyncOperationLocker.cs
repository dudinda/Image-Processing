using System;
using System.Threading;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Services.Locker;

namespace ImageProcessing.App.Domain.Services.LockerService.Operation.Implementation
{
    /// <inheritdoc cref="IAsyncOperationLocker"/>
    public class AsyncOperationLocker : IAsyncOperationLocker
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        /// <inheritdoc />
        public async Task<TResult> LockOperationAsync<TResult>(Func<TResult> worker, CancellationToken token)
        {
            await _semaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                return await Task.Run(() => { return worker(); }, token).ConfigureAwait(false);
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
        public async Task LockOperationAsync(Action worker, CancellationToken token)
        {
            await _semaphore.WaitAsync().ConfigureAwait(false);
            try
            {
                await Task.Run(() => worker(), token).ConfigureAwait(false);
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