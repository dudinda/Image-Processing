using System.Threading.Tasks;

using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.ScalingArgs;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Providers.Scaling.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Win.Services.Logger.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.Integration.Monolith.PresentationLayer
{
    internal class ScalingPresenterWrapper : BasePresenter<IScalingView, BitmapViewModel>,
        ISubscriber<ScaleEventArgs>,
        ISubscriber<ShowTooltipOnErrorEventArgs>,
        ISubscriber<ContainerUpdatedEventArgs>,
        ISubscriber<RestoreFocusEventArgs>
    {
        private readonly ScalingPresenter _presenter;

        public ILoggerService Logger { get; }
        public IScalingProvider Provider { get; }
        public IAsyncOperationLocker Locker { get; }

        public ScalingPresenterWrapper(
            IAsyncOperationLocker locker,
            IScalingProvider provider,
            ILoggerService logger)
        {
            Provider = provider;
            Logger = logger;
            Locker = locker;

            _presenter = new ScalingPresenter(locker, provider, logger);
        }

        public override void Run(BitmapViewModel vm)
        {
            base.Run(vm);
            _presenter.Run(vm);
        }

        public virtual Task OnEventHandler(object publisher, RestoreFocusEventArgs e)
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

        public virtual Task OnEventHandler(object publisher, ScaleEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
