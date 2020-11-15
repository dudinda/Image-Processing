using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.DomainEvent.ColorMatrix;
using ImageProcessing.App.UILayer.FormEventBinder.ColorMatrix.Interface;
using ImageProcessing.App.UILayer.FormExposer.ColorMatrix;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;

namespace ImageProcessing.App.UILayer.FormEventBinder.ColorMatrix.Implementation
{
    internal class ColorMatrixEventBinder : IColorMatrixEventBinder
    {
        private readonly IEventAggregator _aggregator;

        public ColorMatrixEventBinder(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }

        public void OnElementExpose(IColorMatrixFormExposer source)
        {
            source.ApplyButton.Click += (sender, args)
                 => _aggregator.PublishFrom(source,
                     new ApplyColorMatrixEventArgs()
                 );
        }

        public bool ProcessCmdKey(IColorMatrixFormExposer view, Keys keyData)
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
