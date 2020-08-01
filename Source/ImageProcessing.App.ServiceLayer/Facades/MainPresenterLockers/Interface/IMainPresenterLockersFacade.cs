using System;
using System.Threading.Tasks;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Zoom.Interface;

namespace ImageProcessing.App.ServiceLayer.Facades.MainPresenterLockers.Interface
{
    public interface IMainPresenterLockersFacade
        : IAsyncOperationLocker,
          IAsyncZoomLocker
    {

    }
}
