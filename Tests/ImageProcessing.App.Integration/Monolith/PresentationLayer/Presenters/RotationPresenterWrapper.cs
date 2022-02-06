using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Rotation.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.BitmapCopy.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Locker.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Logger.Interface;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.RgbArgs;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.Integration.Monolith.PresentationLayer
{
    internal class RotationPresenterWrapper : BasePresenter<IRgbView, BitmapViewModel>,
          ISubscriber<ApplyRgbFilterEventArgs>, ISubscriber<ApplyRgbChannelFilterEventArgs>,
          ISubscriber<ContainerUpdatedEventArgs>, ISubscriber<ShowColorMatrixMenuEventArgs>,
          ISubscriber<ShowTooltipOnErrorEventArgs>, ISubscriber<RestoreFocusEventArgs>
    {
        private readonly RotationPresenter _presenter;

        public IRotationProviderWrapper Provider { get; }
        public ILoggerServiceWrapper Logger { get; }
        public IBitmapCopyServiceWrapper Copy { get; }

        public RotationPresenterWrapper(
            IBitmapCopyServiceWrapper copy,
            IRotationProviderWrapper provider,
            ILoggerServiceWrapper logger)
        {
            Provider = provider;
            Logger = logger;
            Copy = copy;

            _presenter = new RotationPresenter(copy, provider, logger);
        }

        public override void Run(BitmapViewModel vm)
        {
            base.Run(vm);
            _presenter.Run(vm);
        }

        public virtual Task OnEventHandler(object publisher, ApplyRgbFilterEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, ApplyRgbChannelFilterEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, ContainerUpdatedEventArgs e)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnEventHandler(object publisher, ShowColorMatrixMenuEventArgs e)
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
