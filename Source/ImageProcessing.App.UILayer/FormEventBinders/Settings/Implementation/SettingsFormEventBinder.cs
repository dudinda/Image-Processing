using ImageProcessing.App.PresentationLayer.DomainEvents.SettingsArgs;
using ImageProcessing.App.UILayer.FormEventBinders.Settings.Interface;
using ImageProcessing.App.UILayer.FormExposers.Settings;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;

namespace ImageProcessing.App.UILayer.FormEventBinders.Settings.Implementation
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
        }
    }
}
