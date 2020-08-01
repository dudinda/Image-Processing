using System;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.ServiceLayer.Services.Locker.Base.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface
{
    /// <summary>
    /// Provides safe async access to the operations
    /// perfomed on the copies of <see cref="ImageContainer.Source"/>
    /// and <see cref="ImageContainer.Destination"/>.
    /// </summary>
    public interface IAsyncOperationLocker 
    {
        /// <inheritdoc cref="IAsyncLocker.LockAsync{TResult}(Func{TResult})"/>
        Task<TResult> LockOperationAsync<TResult>(Func<TResult> worker);

        /// <inheritdoc cref="IAsyncLocker.LockAsync(Action)"/>
        Task LockOperationAsync(Action worker);
    }
}
