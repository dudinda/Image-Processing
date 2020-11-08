using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.Container;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.FileDialog;
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
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Wrappers.Presenters
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
            IAsyncZoomLocker zoom) : base(controller)
        {
            Cache = cache;
            Dialog = dialog;
            Pipeline = pipeline;
            Operation = operation;
            Zoom = zoom;

            _presenter = new MainPresenter(controller, cache, dialog, pipeline, operation, zoom);
        }

        public override void Run()
        {
            base.Run();
            _presenter.Run();
        }

        public virtual async Task OnEventHandler(object publisher, SaveWithoutFileDialogEventArgs e)
        {
            
        }

        public virtual async Task OnEventHandler(object publisher, UndoRedoEventArgs e)
        {
            
        }

        public virtual async Task OnEventHandler(object publisher, ZoomEventArgs e)
        {
           
        }

        public virtual async Task OnEventHandler(object publisher, ReplaceImageEventArgs e)
        {
            
        }

        public virtual async Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
           
        }

        public virtual async Task OnEventHandler(object publisher, SaveAsFileDialogEventArgs e)
        {
           
        }

        public virtual async Task OnEventHandler(object publisher, OpenFileDialogEventArgs e)
        {
            
        }

        public virtual async Task OnEventHandler(object publisher, ShowRgbMenuEventArgs e)
        {
           
        }

        public virtual async Task OnEventHandler(object publisher, ShowDistributionMenuEventArgs e)
        {
           
        }

        public virtual async Task OnEventHandler(object publisher, ShowConvolutionMenuEventArgs e)
        {
            
        }

        public virtual async Task OnEventHandler(object publisher, AttachBlockToRendererEventArgs e)
        {
            
        }
    }
}
