using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.Domain.Services;
using ImageProcessing.App.Integration.Monolith.Domain.Services.BitmapCopy.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Pipeline.Interface;
using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.Container;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.FileDialog;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.Toolbar;
using ImageProcessing.App.Presentation.Presenters;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

using Microsoft.Extensions.Logging;

namespace ImageProcessing.App.Integration.Monolith.Presentation.Presenters
{
    internal class MainPresenterWrapper : BasePresenter<IMainView>,
         ISubscriber<AttachBlockToRendererEventArgs>, ISubscriber<AttachBlockToPaintEventArgs>,
        ISubscriber<ShowTooltipOnErrorEventArgs>, ISubscriber<FormIsClosedEventArgs>,
        ISubscriber<FormIsLoadedEventArgs>, ISubscriber<MouseDownEventArgs>,
        ISubscriber<MouseMoveEventArgs>, ISubscriber<MouseUpEventArgs>
    {
        private readonly MainPresenter _presenter;

        public override IMainView View
            => _presenter.View;

        public MainMenuPresenterWrapper MenuPresenter { get; }
        public MainTrackbarPresenterWrapper TrackBarPresenter { get; }
        public MainToolbarPresenterWrapper ToolBarPresenter { get; }

        public IBitmapCopyServiceWrapper Reference { get; }
        public IDrawServiceWrapper Draw { get; }
        public IAwaitablePipelineServiceWrapper Pipeline { get; }
        public ILoggerFactory Logger { get; }

        public MainPresenterWrapper(
            IBitmapCopyServiceWrapper reference,
            IDrawServiceWrapper draw,
            IAwaitablePipelineServiceWrapper pipeline,
            ILoggerFactory logger) 
        {
            Reference = reference;
            Draw = draw;
            Pipeline = pipeline;
            Logger = logger;

            MenuPresenter = Controller.IoC.Resolve<MainMenuPresenterWrapper>();
            TrackBarPresenter = Controller.IoC.Resolve<MainTrackbarPresenterWrapper>();
            ToolBarPresenter = Controller.IoC.Resolve<MainToolbarPresenterWrapper>();

            _presenter = new MainPresenter(reference, draw, pipeline, logger.CreateLogger<MainPresenter>());
        }

        public override void Run()
        {
            _presenter.Run();

            MenuPresenter.Run();
            TrackBarPresenter.Run();

            Aggregator.Subscribe(this, View);
            base.Run();
        }

        public virtual Task OnEventHandler(object publisher, OpenFileDialogEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="SaveAsFileDialogEventArgs"/>
        public virtual Task OnEventHandler(object publisher, SaveAsFileDialogEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="SaveWithoutFileDialogEventArgs"/>
        public virtual Task OnEventHandler(object publisher, SaveWithoutFileDialogEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="AttachBlockToRendererEventArgs"/>
        public virtual Task OnEventHandler(object publisher, AttachBlockToRendererEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="SetSourceEventArgs"/>
        public virtual Task OnEventHandler(object publisher, SetSourceEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="UndoRedoEventArgs"/>
        public virtual Task OnEventHandler(object publisher, UndoRedoEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowTooltipOnErrorEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, FormIsClosedEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, FormIsLoadedEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, AttachBlockToPaintEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, MouseDownEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, MouseMoveEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, MouseUpEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
