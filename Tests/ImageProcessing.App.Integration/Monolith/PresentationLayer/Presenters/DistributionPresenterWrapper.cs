using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.BitmapCopy.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Bmp.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Locker.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Logger.Interface;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.DistributionArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Menu;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.TestsComponents.Wrappers.Presenters
{
    internal class DistributionPresenterWrapper : BasePresenter<IDistributionView, BitmapViewModel>,
        ISubscriber<TransformHistogramEventArgs>, ISubscriber<ShuffleEventArgs>,
        ISubscriber<BuildRandomVariableFunctionEventArgs>, ISubscriber<ShowQualityMeasureMenuEventArgs>,
        ISubscriber<GetRandomVariableInfoEventArgs>, ISubscriber<ShowTooltipOnErrorEventArgs>,
        ISubscriber<RestoreFocusEventArgs>, ISubscriber<ContainerUpdatedEventArgs>
    {
        private readonly DistributionPresenter _presenter;

        public IBitmapCopyServiceWrapper Copy { get; }
        public IBitmapLuminanceProviderWrapper Provider { get; }
        public IBitmapServiceWrapper Service { get; }
        public ILoggerServiceWrapper Logger { get; }

        public DistributionPresenterWrapper(
            IBitmapLuminanceProviderWrapper provider,
            IBitmapCopyServiceWrapper copy,
            IBitmapServiceWrapper service,
            ILoggerServiceWrapper logger) 
        {
            Copy = copy;
            Provider = provider;
            Service = service;
            Logger = logger;

            _presenter = new DistributionPresenter(copy, provider, service, logger);
        }

        public override void Run(BitmapViewModel vm)
        {
            base.Run(vm);
            _presenter.Run(vm);
        }

        public virtual Task OnEventHandler(object publisher, TransformHistogramEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, ShuffleEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, BuildRandomVariableFunctionEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, ShowQualityMeasureMenuEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, GetRandomVariableInfoEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, ContainerUpdatedEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, RestoreFocusEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
