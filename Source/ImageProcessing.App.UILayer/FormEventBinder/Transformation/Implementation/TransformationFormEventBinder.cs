using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.DomainEvent.TransformationArgs;
using ImageProcessing.App.UILayer.FormEventBinder.Transformation.Interface;
using ImageProcessing.App.UILayer.FormExposer.Transformation;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;

namespace ImageProcessing.App.UILayer.FormEventBinder.Transformation.Implementation
{
    internal sealed class TransformationFormEventBinder : ITransformationFormEventBinder
    {
        private readonly IEventAggregator _aggregator;

        public TransformationFormEventBinder(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }

        public void OnElementExpose(ITransformationFormExposer source)
        {
            source.ApplyButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ApplyTransformationEventArgs(source.Parameters)
                );
        }

        public bool ProcessCmdKey(ITransformationFormExposer view, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Q:

                    view.ApplyButton.PerformClick();
                    return true;

                case Keys.Enter:

                    view.ApplyButton.PerformClick();
                    return true;
            }

            return false;
        }
    }
}
