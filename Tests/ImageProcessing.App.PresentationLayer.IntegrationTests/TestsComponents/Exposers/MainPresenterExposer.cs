using System.Drawing;

using ImageProcessing.App.PresentationLayer.Presenters.Main;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Zoom.Interface;
using ImageProcessing.App.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Interface;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Exposers
{
    internal class MainPresenterExposer : MainPresenter
    {

        public IAppController Controller
            => base.Controller;

        public ICacheService<Bitmap> Cache
            => base._cache;

        public INonBlockDialogService Dialog
            => base._dialog;

        public IAwaitablePipeline Pipeline
            => base._pipeline;

        public IAsyncOperationLocker Operation
            => base._operation;

        public IAsyncZoomLocker Zoom
            => base._zoom;

        public MainPresenterExposer(
            IAppController controller,
            ICacheService<Bitmap> cache,
            INonBlockDialogService dialog,
            IAwaitablePipeline pipeline,
            IAsyncOperationLocker operation,
            IAsyncZoomLocker zoom)
            : base(controller, cache, dialog,  
                   pipeline, operation, zoom)
        {

        }
    }
}
