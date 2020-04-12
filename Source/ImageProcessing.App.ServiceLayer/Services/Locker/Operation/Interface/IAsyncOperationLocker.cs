using ImageProcessing.App.ServiceLayer.Services.Locker.Base.Interface;
using ImageProcessing.App.Common.Enums;

namespace ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface
{
    /// <summary>
    /// Provides safe async access to the operations
    /// perfomed on the copies of <see cref="ImageContainer.Source"/>
    /// and <see cref="ImageContainer.Destination"/>.
    /// </summary>
    public interface IAsyncOperationLocker : IAsyncLocker
    {

    }
}
