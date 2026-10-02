using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.Domain.Providers.Rotation.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.BitmapCopy.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Logger.Interface;
using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.DomainEvents.RotationArgs;
using ImageProcessing.App.Presentation.Presenters;
using ImageProcessing.App.Presentation.ViewModels;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.Integration.Monolith.Presentation.Presenters
{
    internal class RotationPresenterWrapper : BasePresenter<IRotationView, BitmapViewModel>,
        ISubscriber<RotateEventArgs>, ISubscriber<ShowTooltipOnErrorEventArgs>,
        ISubscriber<ContainerUpdatedEventArgs>, ISubscriber<RestoreFocusEventArgs>,
        ISubscriber<FormIsClosedEventArgs>, ISubscriber<EnableControlEventArgs>
    {
        private readonly RotationPresenter _presenter;

        public override IRotationView View
            => _presenter.View;

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

        /// <inheritdoc cref="RotateEventArgs"/>
        public Task OnEventHandler(object publisher, RotateEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ShowTooltipOnErrorEventArgs"/>
        public Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ContainerUpdatedEventArgs"/>
        public Task OnEventHandler(object publisher, ContainerUpdatedEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="RestoreFocusEventArgs"/>
        public Task OnEventHandler(object publisher, RestoreFocusEventArgs e)
        {
            return Task.CompletedTask;
        }

        public Task OnEventHandler(object publisher, FormIsClosedEventArgs e)
        {
            return Task.CompletedTask;
        }

        public Task OnEventHandler(object publisher, EnableControlEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
