using System;
using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.Domain.Services.Locker.Interface;
using ImageProcessing.App.Domain.Services.LockerService.Operation.Implementation;
using System.Threading;

namespace ImageProcessing.App.Integration.Monolith.Domain.Services.Locker.Implementation
{
    internal class AsyncOperationLockerWrapper : IAsyncOperationLockerWrapper
    {
        private readonly AsyncOperationLocker _locker
            = new AsyncOperationLocker();

        public async Task<TResult> LockOperationAsync<TResult>(Func<TResult> worker, CancellationToken token)
            => await _locker.LockOperationAsync(worker, token).ConfigureAwait(false);

        public async Task LockOperationAsync(Action worker, CancellationToken token)
            => await _locker.LockOperationAsync(worker, token).ConfigureAwait(false);
    }
}
