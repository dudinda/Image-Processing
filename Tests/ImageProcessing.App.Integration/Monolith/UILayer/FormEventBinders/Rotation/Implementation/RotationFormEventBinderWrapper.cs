using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Rotation.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Rotation.Interface;
using ImageProcessing.App.UILayer.FormExposers;

namespace ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Rotation.Implementation
{
    internal class RotationFormEventBinderWrapper : IRotationFormEventBinderWrapper
    {
        private readonly IRotationFormEventBinder _binder;

        public RotationFormEventBinderWrapper(
            IRotationFormEventBinder binder)
        {
            _binder = binder;
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
