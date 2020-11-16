using System.Threading.Tasks;

using ImageProcessing.App.DomainLayer.DomainEvent.SettingsArgs;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.Views.Settings;
using ImageProcessing.App.ServiceLayer.Services.Settings.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.Presenters.Settings
{
    internal sealed class SettingsPresenter : BasePresenter<ISettingsView>,
        ISubscriber<ChangeLumaEventArgs>,
        ISubscriber<ChangeRotationEventArgs>,
        ISubscriber<ChangeScalingEventArgs>
    {
        private readonly IAppSettings _settings;

        public SettingsPresenter(
            IAppController controller,
            IAppSettings settings) : base(controller)
        {
            _settings = settings;
        }

        public async Task OnEventHandler(object publisher, ChangeRotationEventArgs e)
            => _settings.Rotation = View.FirstDropdown;

        public async Task OnEventHandler(object publisher, ChangeScalingEventArgs e)
            => _settings.Scaling = View.SecondDropdown;

        public async Task OnEventHandler(object publisher, ChangeLumaEventArgs e)
            => _settings.Rec = View.ThirdDropdown;
    }
}
