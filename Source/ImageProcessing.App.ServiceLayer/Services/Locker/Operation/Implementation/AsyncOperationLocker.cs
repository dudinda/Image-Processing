using System;
using System.Threading.Tasks;
using ImageProcessing.App.ServiceLayer.Services.Locker.Base.Abstract;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Implementation
{
    /// <inheritdoc cref="IAsyncOperationLocker"/>
    public class AsyncOperationLocker : AsyncLockerBase, IAsyncOperationLocker
    {
        /// <inheritdoc/>
        public virtual async Task<TResult> LockOperationAsync<TResult>(Func<TResult> worker)
            => await LockAsync(worker).ConfigureAwait(false);

        /// <inheritdoc/>
        public virtual async Task LockOperationAsync(Action worker)
            => await LockAsync(worker).ConfigureAwait(false);
    }
}
