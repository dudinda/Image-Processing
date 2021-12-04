
using System.Windows.Forms;

using ImageProcessing.App.PresentationLayer.DomainEvents.RotationArgs;
using ImageProcessing.App.UILayer.FormEventBinders.Rotation.Interface;
using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;

namespace ImageProcessing.App.UILayer.FormEventBinders.Rotation.Implementation
{
    internal sealed class RotationEventBinder : IRotationEventBinder
    {
        private readonly IEventAggregator _aggregator;

        public RotationEventBinder(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }

        public void OnElementExpose(IRotationFormExposer source)
        {
            source.RotateButton.Click += (sender, args)
                 => _aggregator.PublishFrom(source, new RotateEventArgs());
        }

        public bool ProcessCmdKey(IRotationFormExposer view, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.R:

                    view.RotateButton.PerformClick();
                    return true;
            }

            return false;
        }
    }
}
