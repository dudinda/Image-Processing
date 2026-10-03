using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Rotation.Interface;
using ImageProcessing.App.Presentation.UnitTests.Fakes.Components;
using ImageProcessing.App.UI.Services.FormEventBinders.Rotation.Implementation;
using ImageProcessing.App.UI.Services.FormExposers;

namespace ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Rotation.Implementation
{
    internal class RotationFormEventBinderWrapper : IRotationFormEventBinderWrapper
    {
        private readonly RotationFormEventBinder _binder;

        public RotationFormEventBinderWrapper(
            IEventAggregatorWrapper aggregator)
        {
            _binder = new RotationFormEventBinder(aggregator);
        }

        public virtual void OnElementExpose(IRotationFormExposer form)
        {
            _binder.OnElementExpose(form);
        }

        public virtual bool ProcessCmdKey(IRotationFormExposer view, Keys keyData)
        {
            return _binder.ProcessCmdKey(view, keyData);
        }
    }
}
