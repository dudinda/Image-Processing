using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.Domain.Services.BitmapCopy.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Pipeline.Interface;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.Menu;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.Show;
using ImageProcessing.App.Presentation.Presenters;
using ImageProcessing.App.Presentation.ViewModels;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

using Microsoft.Extensions.Logging;

namespace ImageProcessing.App.Integration.Monolith.Presentation.Presenters
{
    internal class MainMenuPresenterWrapper : BasePresenter<IMainView>,
        ISubscriber<ShowConvolutionMenuEventArgs>, ISubscriber<ShowDistributionMenuEventArgs>,
        ISubscriber<ShowRgbMenuEventArgs>, ISubscriber<ShowSettingsMenuEventArgs>,
        ISubscriber<ShowTransformationMenuEventArgs>, ISubscriber<ShowRotationMenuEventArgs>,
        ISubscriber<ShowScalingMenuEventArgs>
    {
        private IMainView? _view;

        public override IMainView View
           => _view ??= Controller.IoC.Resolve<IMainView>();

        public override void Run()
        {
            Aggregator.Subscribe(this, View);
        }

        public ILoggerFactory Logger { get; }
        public IBitmapCopyServiceWrapper Reference { get; }
        public IAwaitablePipelineServiceWrapper Pipeline { get; }

        public MainMenuPresenterWrapper(
            IBitmapCopyServiceWrapper reference,
            IAwaitablePipelineServiceWrapper pipeline,
            ILoggerFactory logger)
        {
            Logger = logger;
            Reference = reference;
            Pipeline = pipeline;
        }

        /// <inheritdoc cref="ShowRgbMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowRgbMenuEventArgs e)
        {
            Controller.Run<RgbPresenterWrapper, BitmapViewModel>(
                new BitmapViewModel(new System.Drawing.Rectangle()));

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowScalingMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowScalingMenuEventArgs e)
        {
            Controller.Run<ScalingPresenterWrapper, BitmapViewModel>(
               new BitmapViewModel(new System.Drawing.Rectangle()));

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowRotationMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowRotationMenuEventArgs e)
        {
            Controller.Run<RotationPresenterWrapper, BitmapViewModel>(
               new BitmapViewModel(new System.Drawing.Rectangle()));

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowDistributionMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowDistributionMenuEventArgs e)
        {
            Controller.Run<DistributionPresenterWrapper, BitmapViewModel>(
               new BitmapViewModel(new System.Drawing.Rectangle()));

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowConvolutionMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowConvolutionMenuEventArgs e)
        {
            Controller.Run<ConvolutionPresenterWrapper, BitmapViewModel>(
               new BitmapViewModel(new System.Drawing.Rectangle()));

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowTransformationMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowTransformationMenuEventArgs e)
        {
            Controller.Run<TransformationPresenterWrapper, BitmapViewModel>(
               new BitmapViewModel(new System.Drawing.Rectangle()));

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowSettingsMenuEventArgs"/>
        public virtual Task OnEventHandler(object publisher, ShowSettingsMenuEventArgs e)
        {
            Controller.Run<SettingsPresenterWrapper>();

            return Task.CompletedTask;
        }
    }
}
