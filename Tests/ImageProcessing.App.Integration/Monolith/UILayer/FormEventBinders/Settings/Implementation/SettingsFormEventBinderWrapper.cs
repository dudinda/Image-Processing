using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Settings.Interface;
using ImageProcessing.App.Presentation.UnitTests.Fakes.Components;
using ImageProcessing.App.UI.Services.FormEventBinders.Settings.Implementation;
using ImageProcessing.App.UI.Services.FormExposers;

namespace ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Settings.Implementation
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
