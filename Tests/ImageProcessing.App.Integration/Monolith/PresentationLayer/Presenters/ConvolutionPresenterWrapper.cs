using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Locker.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Logger.Interface;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.ConvolutionArgs;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Providers.Interface.Convolution;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Win.Services.Logger.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.TestsComponents.Wrappers.Presenters
{
    internal class ConvolutionPresenterWrapper : BasePresenter<IConvolutionView, BitmapViewModel>,
          ISubscriber<ApplyConvolutionKernelEventArgs>,
          ISubscriber<ShowTooltipOnErrorEventArgs>,
          ISubscriber<ContainerUpdatedEventArgs>,
          ISubscriber<RestoreFocusEventArgs>
    {
        private readonly ConvolutionPresenter _presenter;

        public IConvolutionProvider Provider { get; }
        public IAsyncOperationLocker Locker { get; }
        public ILoggerService Logger { get; }

        public ConvolutionPresenterWrapper(
            IAsyncOperationLockerWrapper locker,
            IConvolutionProvider provider,
            ILoggerServiceWrapper logger)
        {
            Provider = provider;
            Locker = locker;
            Logger = logger;

            _presenter = new ConvolutionPresenter(locker, provider, logger);
        }

        public override void Run(BitmapViewModel vm)
        {
            base.Run(vm);
            _presenter.Run(vm);
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
    }
}
