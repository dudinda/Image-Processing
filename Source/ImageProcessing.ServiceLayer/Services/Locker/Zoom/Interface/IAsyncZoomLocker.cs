using ImageProcessing.ServiceLayer.Services.Locker.Base.Interface;
using ImageProcessing.Common.Enums;

namespace ImageProcessing.ServiceLayer.Services.LockerService.Zoom.Interface
{
    /// <summary>
    /// Provides async synchronization during the zooming
    /// of <see cref="ImageContainer.Source"/> and
    /// <see cref="ImageContainer.Destination"/>.
    /// </summary>
    public interface IAsyncZoomLocker : IAsyncLocker
    {

    }
}
