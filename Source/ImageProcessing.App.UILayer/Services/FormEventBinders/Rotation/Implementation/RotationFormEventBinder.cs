using System.Windows.Forms;

using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.DomainEvents.RotationArgs;
using ImageProcessing.App.UILayer.Services.FormEventBinders.Rotation;
using ImageProcessing.App.UILayer.Services.FormExposers;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;

namespace ImageProcessing.App.UILayer.Services.FormEventBinders.Rotation.Implementation
{
    internal sealed class RotationFormEventBinder : IRotationFormEventBinder
    {
        private readonly IEventAggregator _aggregator;

        public RotationFormEventBinder(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }

        public void OnElementExpose(IRotationFormExposer source)
        {
            source.RotateButton.Click += (sender, args)
                => _aggregator.PublishFrom(source, new RotateEventArgs());

            source.FormClosed += (sender, args)
                => _aggregator.PublishFrom(source, new FormIsClosedEventArgs());
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
