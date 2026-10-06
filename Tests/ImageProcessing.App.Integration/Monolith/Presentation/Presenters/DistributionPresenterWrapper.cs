using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.Domain.Providers.BitmapLuminance.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.BitmapCopy.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Bmp.Interface;
using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.DomainEvents.DistributionArgs;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.Menu;
using ImageProcessing.App.Presentation.Presenters;
using ImageProcessing.App.Presentation.ViewModels;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

using Microsoft.Extensions.Logging;

namespace ImageProcessing.App.Integration.Monolith.Presentation.Presenters
{
    internal class DistributionPresenterWrapper : BasePresenter<IDistributionView, BitmapViewModel>,
        ISubscriber<TransformHistogramEventArgs>, ISubscriber<ShuffleEventArgs>,
        ISubscriber<BuildRandomVariableFunctionEventArgs>, ISubscriber<ShowQualityMeasureMenuEventArgs>,
        ISubscriber<GetRandomVariableInfoEventArgs>, ISubscriber<ShowTooltipOnErrorEventArgs>,
        ISubscriber<RestoreFocusEventArgs>, ISubscriber<ContainerUpdatedEventArgs>
    {
        private readonly DistributionPresenter _presenter;

        public override IDistributionView View
            => _presenter.View;

        public IBitmapCopyServiceWrapper Copy { get; }
        public IBitmapLuminanceProviderWrapper Provider { get; }
        public IBitmapServiceWrapper Service { get; }
        public ILogger<DistributionPresenter> Logger { get; }

        public DistributionPresenterWrapper(
            IBitmapLuminanceProviderWrapper provider,
            IBitmapCopyServiceWrapper copy,
            IBitmapServiceWrapper service,
            ILogger<DistributionPresenter> logger) 
        {
            Copy = copy;
            Provider = provider;
            Service = service;
            Logger = logger;

            _presenter = new DistributionPresenter(copy, provider, service, logger);
        }

        public override void Run(BitmapViewModel vm)
        {
            _presenter.Run(vm);
            base.Run(vm);
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
