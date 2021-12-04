using System.Threading.Tasks;

using ImageProcessing.App.PresentationLayer.DomainEvents.SettingsArgs;
using ImageProcessing.App.PresentationLayer.Presenters;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Services.Settings.Interface;
using ImageProcessing.App.ServiceLayer.Win.Services.Logger.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.Integration.Monolith.PresentationLayer
{
    internal class SettingsPresenterWrapper : BasePresenter<ISettingsView>,
        ISubscriber<ChangeLumaEventArgs>,
        ISubscriber<ChangeRotationEventArgs>,
        ISubscriber<ChangeScalingEventArgs>
    {
        private readonly SettingsPresenter _presenter;

        public ILoggerService Logger { get; }
        public IAppSettings Settings { get; }

        public SettingsPresenterWrapper(
            ILoggerService logger,
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

        public virtual Task OnEventHandler(object publisher, ChangeLumaEventArgs e)
        {
            return Task.CompletedTask;
        }

        public Task OnEventHandler(object publisher, ChangeRotationEventArgs e)
        {
            return Task.CompletedTask;
        }

        public Task OnEventHandler(object publisher, ChangeScalingEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
