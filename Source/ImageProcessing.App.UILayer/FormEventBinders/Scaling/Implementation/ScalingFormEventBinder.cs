using System.Windows.Forms;

using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.ScalingArgs;
using ImageProcessing.App.UILayer.FormEventBinders.Scaling.Interface;
using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;

namespace ImageProcessing.App.UILayer.FormEventBinders.Scaling.Implementation
{
    internal sealed class ScalingFormEventBinder : IScalingFormEventBinder
    {
        private readonly IEventAggregator _aggregator;

        public ScalingFormEventBinder(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }

        public void OnElementExpose(IScalingFormExposer source)
        {
            source.ScaleButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new ScaleEventArgs(source.Parameters));

            source.FormClosed += (sender, args)
                => _aggregator.PublishFrom(source, new FormIsClosedEventArgs());
        }

        public bool ProcessCmdKey(IScalingFormExposer view, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Q:

                    view.ScaleButton.PerformClick();
                    return true;

                case Keys.Enter:

                    view.ScaleButton.PerformClick();
                    return true;
            }

            return false;
        }
    }
}
