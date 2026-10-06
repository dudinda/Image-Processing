using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.Domain.Providers.Rgb.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.BitmapCopy.Interface;
using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.DomainEvents.RgbArgs;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Rgb.Interface;
using ImageProcessing.App.Presentation.Presenters;
using ImageProcessing.App.Presentation.ViewModels;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

using Microsoft.Extensions.Logging;

namespace ImageProcessing.App.Integration.Monolith.Presentation.Presenters
{
    internal class RgbPresenterWrapper : BasePresenter<IRgbView, BitmapViewModel>,
          ISubscriber<ApplyRgbFilterEventArgs>, ISubscriber<ApplyRgbChannelFilterEventArgs>,
          ISubscriber<ContainerUpdatedEventArgs>, ISubscriber<ShowColorMatrixMenuEventArgs>,
          ISubscriber<ShowTooltipOnErrorEventArgs>, ISubscriber<RestoreFocusEventArgs>
    {
        private readonly RgbPresenter _presenter;

        public override IRgbView View
            => _presenter.View;

        public IRgbProviderWrapper Provider { get; }
        public IBitmapCopyServiceWrapper Copy { get; }
        public IRgbFactoryWrapper Factory { get; }
        public ILogger<RgbPresenter> Logger { get; }

        public RgbPresenterWrapper(
            IBitmapCopyServiceWrapper copy,
            IRgbFactoryWrapper factory,
            ILogger<RgbPresenter> logger,
            IRgbProviderWrapper provider)
        {
            Provider = provider;
            Factory = factory;
            Copy = copy;
            Logger = logger;

            _presenter = new RgbPresenter(copy, factory, logger, provider);
        }

        public override void Run(BitmapViewModel vm)
        {
            _presenter.Run(vm);
            base.Run(vm);
        }

        public virtual Task OnEventHandler(object publisher, ApplyRgbChannelFilterEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, ApplyRgbFilterEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, ShowColorMatrixMenuEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, ContainerUpdatedEventArgs e)
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
    }
}
