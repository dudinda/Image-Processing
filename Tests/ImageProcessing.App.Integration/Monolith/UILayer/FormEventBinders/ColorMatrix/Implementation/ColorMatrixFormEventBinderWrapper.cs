using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.ColorMatrix.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.ColorMatrix.Interface;
using ImageProcessing.App.UILayer.FormExposers.ColorMatrix;

namespace ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.ColorMatrix.Implementation
{
    internal class ColorMatrixFormEventBinderWrapper : IColorMatrixFormEventBinderWrapper
    {
        private readonly IColorMatrixFormEventBinder _binder;

        public ColorMatrixFormEventBinderWrapper(
            IColorMatrixFormEventBinder binder)
        {
            _binder = binder;
        }

        public virtual void OnElementExpose(IColorMatrixFormExposer form)
        {
            _binder.OnElementExpose(form);
        }

        public virtual bool ProcessCmdKey(IColorMatrixFormExposer view, Keys keyData)
        {
            return _binder.ProcessCmdKey(view, keyData);
        }
    }
}
