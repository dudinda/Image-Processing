using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.FileDialogArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.ImageContainer;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.Menu;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.Show;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.Presenters.Main;
using ImageProcessing.App.PresentationLayer.Views.Main;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Zoom.Interface;
using ImageProcessing.App.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Exposers
{
    internal class MainPresenterWrapper : BasePresenter<IMainView>,
          ISubscriber<AttachBlockToRendererEventArgs>,
          ISubscriber<ShowConvolutionMenuEventArgs>,
          ISubscriber<ShowDistributionMenuEventArgs>,
          ISubscriber<ShowRgbMenuEventArgs>,
          ISubscriber<OpenFileDialogEventArgs>,
          ISubscriber<SaveAsFileDialogEventArgs>,
          ISubscriber<SaveWithoutFileDialogEventArgs>,
          ISubscriber<ShowTooltipOnErrorEventArgs>,
          ISubscriber<ReplaceImageEventArgs>,
          ISubscriber<ZoomEventArgs>,
          ISubscriber<UndoRedoEventArgs>
    {
        private readonly MainPresenter _presenter;

        public IAppController Controller { get; }
        
        public ICacheService<Bitmap> Cache { get; }

        public INonBlockDialogService Dialog { get; }

        public IAwaitablePipeline Pipeline { get; }

        public IAsyncOperationLocker Operation { get; }

        public IAsyncZoomLocker Zoom { get; }

        public MainPresenterWrapper(
            IAppController controller,
            ICacheService<Bitmap> cache,
            INonBlockDialogService dialog,
            IAwaitablePipeline pipeline,
            IAsyncOperationLocker operation,
            IAsyncZoomLocker zoom)  : base(controller)
        {
            Controller = controller;
            Cache = cache;
            Dialog = dialog;
            Pipeline = pipeline;
            Operation = operation;
            Zoom = zoom;

            _presenter = new MainPresenter(controller,
                cache, dialog, pipeline,
                operation, zoom);
        }

        public virtual async Task OnEventHandler(object publisher, UndoRedoEventArgs e)
            => _presenter.OnEventHandler(publisher, e);
       
        public virtual async Task OnEventHandler(object publisher, AttachBlockToRendererEventArgs e)
            => _presenter.OnEventHandler(publisher, e);
       
        public virtual async Task OnEventHandler(object publisher, ZoomEventArgs e)
            => _presenter.OnEventHandler(publisher, e);

        public virtual async Task OnEventHandler(object publisher, ShowConvolutionMenuEventArgs e)
            => _presenter.OnEventHandler(publisher, e);

        public virtual async Task OnEventHandler(object publisher, ShowDistributionMenuEventArgs e)
            => _presenter.OnEventHandler(publisher, e);

        public virtual async Task OnEventHandler(object publisher, ShowRgbMenuEventArgs e)
            => _presenter.OnEventHandler(publisher, e);

        public virtual async Task OnEventHandler(object publisher, OpenFileDialogEventArgs e)
        {
            
            _presenter.OnEventHandler(publisher, e);
        }

        public virtual async Task OnEventHandler(object publisher, SaveAsFileDialogEventArgs e)
            => _presenter.OnEventHandler(publisher, e);

        public virtual async Task OnEventHandler(object publisher, SaveWithoutFileDialogEventArgs e)
            => _presenter.OnEventHandler(publisher, e);

        public virtual async Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
            => _presenter.OnEventHandler(publisher, e);

        public virtual async Task OnEventHandler(object publisher, ReplaceImageEventArgs e)
            => _presenter.OnEventHandler(publisher, e);

        public override void Run()
        {
            var bind = View;
            _presenter.Run();
        }
    }
}
