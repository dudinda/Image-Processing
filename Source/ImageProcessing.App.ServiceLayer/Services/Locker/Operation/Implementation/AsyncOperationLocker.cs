using System;
using System.Threading.Tasks;
using ImageProcessing.App.ServiceLayer.Services.Locker.Base.Abstract;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Implementation
{
    /// <inheritdoc cref="IAsyncOperationLocker"/>
    public sealed class AsyncOperationLocker : AsyncLockerBase, IAsyncOperationLocker
    {
        /// <inheritdoc/>
        public async Task<TResult> LockOperationAsync<TResult>(Func<TResult> worker)
            => await LockAsync(worker).ConfigureAwait(false);

        /// <inheritdoc/>
        public async Task LockOperationAsync(Action worker)
            => await LockAsync(worker).ConfigureAwait(false);
    }
}
