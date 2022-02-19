using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Convolution.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.BitmapCopy.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Logger.Interface;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.ConvolutionArgs;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.TestsComponents.Wrappers.Presenters
{
    internal class ConvolutionPresenterWrapper : BasePresenter<IConvolutionView, BitmapViewModel>,
          ISubscriber<ApplyConvolutionKernelEventArgs>, ISubscriber<ShowTooltipOnErrorEventArgs>,
          ISubscriber<ContainerUpdatedEventArgs>, ISubscriber<RestoreFocusEventArgs>,
          ISubscriber<FormIsClosedEventArgs>, ISubscriber<EnableControlEventArgs>
    {
        private readonly ConvolutionPresenter _presenter;

        public override IConvolutionView View
            => _presenter.View;

        public IConvolutionProviderWrapper Provider { get; }
        public IBitmapCopyServiceWrapper Copy { get; }
        public ILoggerServiceWrapper Logger { get; }

        public ConvolutionPresenterWrapper(
            IBitmapCopyServiceWrapper copy,
            IConvolutionProviderWrapper provider,
            ILoggerServiceWrapper logger)
        {
            Provider = provider;
            Copy = copy;
            Logger = logger;

            _presenter = new ConvolutionPresenter(copy, provider, logger);
        }

        public override void Run(BitmapViewModel vm)
        {
            _presenter.Run(vm);
            base.Run(vm);
        }

        public virtual Task OnEventHandler(object publisher, ApplyConvolutionKernelEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, RestoreFocusEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, ContainerUpdatedEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, FormIsClosedEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, EnableControlEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
