using System;
using System.Threading.Tasks;

using ImageProcessing.App.ServiceLayer.Facades.MainPresenterLockers.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Zoom.Interface;

namespace ImageProcessing.App.ServiceLayer.Facades.MainPresenterLockers.Implementation
{
    public sealed class MainPresenterLockersFacade : IMainPresenterLockersFacade
    {
        private readonly IAsyncOperationLocker _operationLocker;
        private readonly IAsyncZoomLocker _zoomLocker;

        public MainPresenterLockersFacade(
            IAsyncOperationLocker operationLocker,
            IAsyncZoomLocker zoomLocker)
        {
            _operationLocker = operationLocker;
            _zoomLocker = zoomLocker;
        }

        public async Task<TResult> LockOperationAsync<TResult>(Func<TResult> worker)
            => await _operationLocker.LockOperationAsync(worker).ConfigureAwait(false);
        
        public async Task LockOperationAsync(Action worker)
            => await _operationLocker.LockOperationAsync(worker).ConfigureAwait(false);

        public async Task<TResult> LockZoomAsync<TResult>(Func<TResult> worker)
             => await _zoomLocker.LockZoomAsync(worker).ConfigureAwait(false);

        public async Task LockZoomAsync(Action worker)
            => await _zoomLocker.LockZoomAsync(worker).ConfigureAwait(false);
    }
}
