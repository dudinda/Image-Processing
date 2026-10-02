using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.DomainEvents.SettingsArgs;
using ImageProcessing.App.UI.Services.FormEventBinders.Settings;
using ImageProcessing.App.UI.Services.FormExposers;
using ImageProcessing.Microkernel.MVP.Services.Aggregator;

namespace ImageProcessing.App.UI.Services.FormEventBinders.Settings.Implementation
{
    internal sealed class SettingsFormEventBinder : ISettingsFormEventBinder
    {
        private readonly IEventAggregator _aggregator;

        public SettingsFormEventBinder(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }

        public void OnElementExpose(ISettingsFormExposer form)
        {
            form.LumaDropDown.SelectionChangeCommitted += (sender, args)
                => _aggregator.PublishFrom(form, new ChangeLumaEventArgs());

            form.ScalingDropDown.SelectionChangeCommitted += (sender, args)
                => _aggregator.PublishFrom(form, new ChangeScalingEventArgs());

            form.RotationDropDown.SelectionChangeCommitted += (sender, args)
                => _aggregator.PublishFrom(form, new ChangeRotationEventArgs());

            form.FormClosed += (sender, args)
                => _aggregator.PublishFrom(form, new FormIsClosedEventArgs());
        }
    }
}
