using System.Threading.Tasks;

using ImageProcessing.App.PresentationLayer.DomainEvents.SettingsArgs;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Services.Settings.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class SettingsPresenter : BasePresenter<ISettingsView>,
        ISubscriber<ChangeLumaEventArgs>,
        ISubscriber<ChangeRotationEventArgs>,
        ISubscriber<ChangeScalingEventArgs>
    {
        private readonly IAppSettings _settings;

        public SettingsPresenter(
            IAppSettings settings)
        {
            _settings = settings;
        }

        /// <inheritdoc cref="ChangeRotationEventArgs"/>
        public async Task OnEventHandler(object publisher, ChangeRotationEventArgs e)
            => _settings.Rotation = View.FirstDropdown;

        /// <inheritdoc cref="ChangeScalingEventArgs"/>
        public async Task OnEventHandler(object publisher, ChangeScalingEventArgs e)
            => _settings.Scaling = View.SecondDropdown;

        /// <inheritdoc cref="ChangeLumaEventArgs"/>
        public async Task OnEventHandler(object publisher, ChangeLumaEventArgs e)
            => _settings.Rec = View.ThirdDropdown;
    }
}
