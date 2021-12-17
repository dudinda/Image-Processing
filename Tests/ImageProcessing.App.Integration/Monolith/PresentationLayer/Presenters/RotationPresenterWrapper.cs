using System;
using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Interface;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.RgbArgs;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Providers.Rgb.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Rotation.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Win.Services.Logger.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.Integration.Monolith.PresentationLayer
{
    internal class RotationPresenterWrapper : BasePresenter<IRgbView, BitmapViewModel>,
          ISubscriber<ApplyRgbFilterEventArgs>,
          ISubscriber<ApplyRgbChannelFilterEventArgs>,
          ISubscriber<ContainerUpdatedEventArgs>,
          ISubscriber<ShowColorMatrixMenuEventArgs>,
          ISubscriber<ShowTooltipOnErrorEventArgs>,
          ISubscriber<RestoreFocusEventArgs>
    {
        private readonly RotationPresenter _presenter;

        public IRotationProvider Provider { get; }
        public ILoggerService Logger { get; }
        public IAsyncOperationLocker Locker { get; }

        public RotationPresenterWrapper(
            IAsyncOperationLocker locker,
            IRotationProvider provider,
            ILoggerService logger)
        {
            Provider = provider;
            Logger = logger;
            Locker = locker;

            _presenter = new RotationPresenter(locker, provider, logger);
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
