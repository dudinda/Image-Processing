using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Scaling.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.BitmapCopy.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Locker.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Logger.Interface;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.ScalingArgs;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.Integration.Monolith.PresentationLayer
{
    internal class ScalingPresenterWrapper : BasePresenter<IScalingView, BitmapViewModel>,
        ISubscriber<ScaleEventArgs>, ISubscriber<ShowTooltipOnErrorEventArgs>,
        ISubscriber<ContainerUpdatedEventArgs>, ISubscriber<RestoreFocusEventArgs>
    {
        private readonly ScalingPresenter _presenter;

        public IBitmapCopyServiceWrapper Copy { get; }
        public IScalingProviderWrapper Provider { get; }
        public ILoggerServiceWrapper Logger { get; }

        public ScalingPresenterWrapper(
            IBitmapCopyServiceWrapper copy,
            IScalingProviderWrapper provider,
            ILoggerServiceWrapper logger)
        {
            Provider = provider;
            Logger = logger;
            Copy = copy;

            _presenter = new ScalingPresenter(copy, provider, logger);
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
