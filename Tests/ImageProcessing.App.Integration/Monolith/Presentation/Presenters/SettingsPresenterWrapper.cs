using System.Threading.Tasks;

using ImageProcessing.App.Domain.Models.Options;
using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.DomainEvents.SettingsArgs;
using ImageProcessing.App.Presentation.Presenters;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

using Microsoft.Extensions.Logging;

namespace ImageProcessing.App.Integration.Monolith.Presentation.Presenters
{
    internal class SettingsPresenterWrapper : BasePresenter<ISettingsView>,
        ISubscriber<ChangeLumaEventArgs>, ISubscriber<ChangeRotationEventArgs>,
        ISubscriber<ChangeScalingEventArgs>, ISubscriber<FormIsClosedEventArgs>,
        ISubscriber<EnableControlEventArgs>
    {
        private readonly SettingsPresenter _presenter;

        public override ISettingsView View
            => _presenter.View;

        public ILogger<SettingsPresenter> Logger { get; }
        public SettingsOptions Settings { get; }

        public SettingsPresenterWrapper(
            ILogger<SettingsPresenter> logger,
            SettingsOptions settings)
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
