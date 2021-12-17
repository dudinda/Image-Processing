using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.ColorMatrix.Interface;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components;
using ImageProcessing.App.UILayer.FormEventBinders.ColorMatrix.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.ColorMatrix.Interface;
using ImageProcessing.App.UILayer.FormExposers.ColorMatrix;

namespace ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.ColorMatrix.Implementation
{
    internal class ColorMatrixFormEventBinderWrapper : IColorMatrixFormEventBinderWrapper
    {
        private readonly ColorMatrixFormEventBinder _binder;

        public ColorMatrixFormEventBinderWrapper(
            IEventAggregatorWrapper aggregator)
        {
            _binder = new ColorMatrixFormEventBinder(aggregator);
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
