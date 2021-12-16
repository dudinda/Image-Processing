using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Transformation.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Transformation.Interface;
using ImageProcessing.App.UILayer.FormExposers.Transformation;

namespace ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Transformation.Implementation
{
    internal class TransformationFormEventBinderWrapper : ITransformationFormEventBinderWrapper
    {
        private readonly ITransformationFormEventBinder _binder;

        public TransformationFormEventBinderWrapper(
            ITransformationFormEventBinder binder)
        {
            _binder = binder;
        }

        public virtual void OnElementExpose(ITransformationFormExposer form)
        {
            _binder.OnElementExpose(form);
        }

        public virtual bool ProcessCmdKey(ITransformationFormExposer view, Keys keyData)
        {
            return _binder.ProcessCmdKey(view, keyData);
        }
    }
}
