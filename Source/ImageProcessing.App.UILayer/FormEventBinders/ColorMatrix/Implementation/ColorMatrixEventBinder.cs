using System.Windows.Forms;

using ImageProcessing.App.PresentationLayer.DomainEvents.ColorMatrixArgs;
using ImageProcessing.App.UILayer.FormEventBinders.ColorMatrix.Interface;
using ImageProcessing.App.UILayer.FormExposers.ColorMatrix;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;

namespace ImageProcessing.App.UILayer.FormEventBinders.ColorMatrix.Implementation
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

            source.ApplyCustomButton.Click += (sender, args)
                 => _aggregator.PublishFrom(source,
                     new ApplyCustomColorMatrixEventArgs()
                 );

            source.CustomCheckBox.CheckedChanged += (sender, args)
                => _aggregator.PublishFrom(source,
                    new CustomColorMatrixEventArgs(source.CustomCheckBox.Checked)
                );

            source.ColorMatrixDropDown.SelectionChangeCommitted += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ChangeColorMatrixEventArgs()
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
