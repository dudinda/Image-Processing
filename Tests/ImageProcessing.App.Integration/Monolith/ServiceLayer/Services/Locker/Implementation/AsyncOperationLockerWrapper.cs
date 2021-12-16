using System;
using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Locker.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Locker.Implementation
{
    internal class AsyncOperationLockerWrapper : IAsyncOperationLockerWrapper
    {
        private readonly AsyncOperationLocker _locker
            = new AsyncOperationLocker();

        public async Task<TResult> LockOperationAsync<TResult>(Func<TResult> worker)
            => await _locker.LockOperationAsync(worker).ConfigureAwait(false);

        public async Task LockOperationAsync(Action worker)
            => await _locker.LockOperationAsync(worker).ConfigureAwait(false);
    }
}
