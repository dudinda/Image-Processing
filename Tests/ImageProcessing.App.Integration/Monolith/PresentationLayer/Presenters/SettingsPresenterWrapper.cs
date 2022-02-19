using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Logger.Interface;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.SettingsArgs;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Services.Settings.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.Integration.Monolith.PresentationLayer
{
    internal class SettingsPresenterWrapper : BasePresenter<ISettingsView>,
        ISubscriber<ChangeLumaEventArgs>, ISubscriber<ChangeRotationEventArgs>,
        ISubscriber<ChangeScalingEventArgs>, ISubscriber<FormIsClosedEventArgs>,
        ISubscriber<EnableControlEventArgs>
    {
        private readonly SettingsPresenter _presenter;

        public override ISettingsView View
            => _presenter.View;

        public ILoggerServiceWrapper Logger { get; }
        public IAppSettings Settings { get; }

        public SettingsPresenterWrapper(
            ILoggerServiceWrapper logger,
            IAppSettings settings)
        {
            Settings = settings;
            Logger = logger;

            _presenter = new SettingsPresenter(logger, settings);
        }

        public override void Run()
        {
            base.Run();
            _presenter.Run();
        }

        /// <inheritdoc cref="ChangeRotationEventArgs"/>
        public Task OnEventHandler(object publisher, ChangeRotationEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ChangeScalingEventArgs"/>
        public Task OnEventHandler(object publisher, ChangeScalingEventArgs e)
        {
            return Task.CompletedTask;
        }

        /// <inheritdoc cref="ChangeLumaEventArgs"/>
        public Task OnEventHandler(object publisher, ChangeLumaEventArgs e)
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
