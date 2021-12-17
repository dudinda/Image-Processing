using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Settings.Interface;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components;
using ImageProcessing.App.UILayer.FormEventBinders.Settings.Implementation;
using ImageProcessing.App.UILayer.FormExposers.Settings;

namespace ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Settings.Implementation
{
    internal class SettingsFormEventBinderWrapper : ISettingsFormEventBinderWrapper
    {
        private readonly SettingsFormEventBinder _binder;

        public SettingsFormEventBinderWrapper(
            IEventAggregatorWrapper aggregator)
        {
            _binder = new SettingsFormEventBinder(aggregator);
        }

        public virtual void OnElementExpose(ISettingsFormExposer form)
        {
            _binder.OnElementExpose(form);
        }
    }
}
