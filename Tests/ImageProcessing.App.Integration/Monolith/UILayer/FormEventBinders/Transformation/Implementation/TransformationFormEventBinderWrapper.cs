using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Transformation.Interface;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components;
using ImageProcessing.App.UILayer.FormEventBinders.Transformation.Implementation;
using ImageProcessing.App.UILayer.FormExposers.Transformation;

namespace ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Transformation.Implementation
{
    internal class TransformationFormEventBinderWrapper : ITransformationFormEventBinderWrapper
    {
        private readonly TransformationFormEventBinder _binder;

        public TransformationFormEventBinderWrapper(
            IEventAggregatorWrapper aggregator)
        {
            _binder = new TransformationFormEventBinder(aggregator);
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
