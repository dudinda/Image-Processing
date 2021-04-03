using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Container;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.FileDialog;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Menu;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Show;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Providers.Rotation.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Scaling.Interface;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Interface;
using ImageProcessing.App.ServiceLayer.Win.Services.NonBlockDialog.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

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
          ISubscriber<TrackBarEventArgs>,
          ISubscriber<UndoRedoEventArgs>
    {

        private readonly MainPresenter _presenter;

        public ICacheService<Bitmap> Cache { get; }
        public INonBlockDialogService Dialog { get; }
        public IAwaitablePipeline Pipeline { get; }
        public IAsyncOperationLocker Operation { get; }
        public IScalingProvider Zoom { get; }
        public IRotationProvider Rotation { get; }

         
        public MainPresenterWrapper(
            ICacheService<Bitmap> cache,
            INonBlockDialogService dialog,
            IAwaitablePipeline pipeline,
            IAsyncOperationLocker operation,
            IScalingProvider zoom,
            IRotationProvider rotation) 
        {
            Cache = cache;
            Dialog = dialog;
            Pipeline = pipeline;
            Operation = operation;
            Zoom = zoom;

            _presenter = new MainPresenter(cache, dialog, pipeline, operation, zoom, rotation);
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

        public virtual async Task OnEventHandler(object publisher, TrackBarEventArgs e)
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
