using System.Windows.Forms;

using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.DomainEvents.ScalingArgs;
using ImageProcessing.App.UI.Services.FormEventBinders.Scaling;
using ImageProcessing.App.UI.Services.FormExposers;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;

namespace ImageProcessing.App.UI.Services.FormEventBinders.Scaling.Implementation
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
