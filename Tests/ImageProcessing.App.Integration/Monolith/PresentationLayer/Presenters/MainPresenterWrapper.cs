using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Rotation.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Scaling.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.BitmapCopy.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Logger.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Pipeline.Interface;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Container;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.FileDialog;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.Integration.Monolith.PresentationLayer.Presenters
{
    internal class MainPresenterWrapper : BasePresenter<IMainView>,
        ISubscriber<AttachBlockToRendererEventArgs>, ISubscriber<OpenFileDialogEventArgs>,
        ISubscriber<SaveAsFileDialogEventArgs>, ISubscriber<SetSourceEventArgs>,
        ISubscriber<SaveWithoutFileDialogEventArgs>, ISubscriber<ShowTooltipOnErrorEventArgs>,
        ISubscriber<TrackBarEventArgs>, ISubscriber<UndoRedoEventArgs>,
        ISubscriber<FormIsClosedEventArgs>
    {
        private readonly MainPresenter _presenter;

        public override IMainView View
            => _presenter.View;

        public MainMenuPresenterWrapper MenuPresenter { get; }
        public IBitmapCopyServiceWrapper Reference { get; }
        public INonBlockDialogServiceWrapper Dialog { get; }
        public IAwaitablePipelineServiceWrapper Pipeline { get; }
        public IScalingProviderWrapper Scaling { get; }
        public IRotationProviderWrapper Rotation { get; }
        public ILoggerServiceWrapper Logger { get; }

        public MainPresenterWrapper(
            IBitmapCopyServiceWrapper reference,
            INonBlockDialogServiceWrapper dialog,
            IAwaitablePipelineServiceWrapper pipeline,
            ILoggerServiceWrapper logger,
            IScalingProviderWrapper scaling,
            IRotationProviderWrapper rotation) 
        {
            Reference = reference;
            Dialog = dialog;
            Pipeline = pipeline;
            Scaling = scaling;
            Logger = logger;
            Rotation = rotation;
            MenuPresenter = Controller.IoC.Resolve<MainMenuPresenterWrapper>();

            _presenter = new MainPresenter(reference, dialog, pipeline, rotation, scaling, logger);
        }

        public override void Run()
        {
            _presenter.Run();     
            MenuPresenter.Run();
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

        /// <inheritdoc cref="TrackBarEventArgs"/>
        public virtual Task OnEventHandler(object publisher, TrackBarEventArgs e)
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
    }
}
