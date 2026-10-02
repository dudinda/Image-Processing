using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.ColorMatrix.Interface;
using ImageProcessing.App.Presentation.UnitTests.Fakes.Components;
using ImageProcessing.App.UI.Services.FormEventBinders.ColorMatrix.Implementation;
using ImageProcessing.App.UI.Services.FormExposers;

namespace ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.ColorMatrix.Implementation
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
