using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Scaling.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.BitmapCopy.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Logger.Interface;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.ScalingArgs;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.Integration.Monolith.PresentationLayer.Presenters
{
    internal class ScalingPresenterWrapper : BasePresenter<IScalingView, BitmapViewModel>,
        ISubscriber<ScaleEventArgs>, ISubscriber<ShowTooltipOnErrorEventArgs>,
        ISubscriber<ContainerUpdatedEventArgs>, ISubscriber<RestoreFocusEventArgs>,
        ISubscriber<FormIsClosedEventArgs>, ISubscriber<EnableControlEventArgs>
    {
        private readonly ScalingPresenter _presenter;

        public override IScalingView View
            => _presenter.View;

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
            _presenter.Run(vm);
            base.Run(vm);
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
