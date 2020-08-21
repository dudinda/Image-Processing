using System;
using System.Threading.Tasks;

using ImageProcessing.App.ServiceLayer.Services.Locker.Base.Abstract;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Zoom.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.LockerService.Zoom.Implementation
{
    /// <inheritdoc cref="IAsyncZoomLocker"/>
    internal class AsyncZoomLocker : AsyncLockerBase, IAsyncZoomLocker
    {
        /// <inheritdoc />
        public virtual async Task<TResult> LockZoomAsync<TResult>(Func<TResult> worker)
            => await LockAsync(worker).ConfigureAwait(false);

        /// <inheritdoc />
        public virtual async Task LockZoomAsync(Action worker)
            => await LockAsync(worker).ConfigureAwait(false);   
    }
}
