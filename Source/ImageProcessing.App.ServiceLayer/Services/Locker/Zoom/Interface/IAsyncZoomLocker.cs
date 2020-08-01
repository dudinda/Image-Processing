using System;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.ServiceLayer.Services.Locker.Base.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.LockerService.Zoom.Interface
{
    /// <summary>
    /// Provides async synchronization during the zooming
    /// of <see cref="ImageContainer.Source"/> and
    /// <see cref="ImageContainer.Destination"/>.
    /// </summary>
    public interface IAsyncZoomLocker 
    {
        /// <inheritdoc cref="IAsyncLocker.LockAsync{TResult}(Func{TResult})"/>
        Task<TResult> LockZoomAsync<TResult>(Func<TResult> worker);

        /// <inheritdoc cref="IAsyncLocker.LockAsync(Action)"/>
        Task LockZoomAsync(Action worker);
    }
}
