using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Settings.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Settings.Interface;
using ImageProcessing.App.UILayer.FormExposers.Settings;

namespace ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Settings.Implementation
{
    internal class SettingsFormEventBinderWrapper : ISettingsFormEventBinderWrapper
    {
        private readonly ISettingsFormEventBinder _binder;

        public SettingsFormEventBinderWrapper(
            ISettingsFormEventBinder binder)
        {
            _binder = binder;
        }

        public virtual void OnElementExpose(ISettingsFormExposer form)
        {
            _binder.OnElementExpose(form);
        }
    }
}
