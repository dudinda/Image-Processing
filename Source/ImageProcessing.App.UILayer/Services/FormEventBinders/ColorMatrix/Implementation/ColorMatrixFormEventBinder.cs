using System.Windows.Forms;

using ImageProcessing.App.PresentationLayer.DomainEvents.ColorMatrixArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.UILayer.Services.FormEventBinders.ColorMatrix;
using ImageProcessing.App.UILayer.Services.FormExposers;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;

namespace ImageProcessing.App.UILayer.Services.FormEventBinders.ColorMatrix.Implementation
{
    internal sealed class ColorMatrixFormEventBinder : IColorMatrixFormEventBinder
    {
        private readonly IEventAggregator _aggregator;

        public ColorMatrixFormEventBinder(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }

        public void OnElementExpose(IColorMatrixFormExposer source)
        {
            source.ApplyButton.Click += (sender, args)
                 => _aggregator.PublishFrom(source, new ApplyColorMatrixEventArgs());

            source.ApplyCustomButton.Click += (sender, args)
                 => _aggregator.PublishFrom(source, new ApplyCustomColorMatrixEventArgs());

            source.CustomCheckBox.CheckedChanged += (sender, args)
                => _aggregator.PublishFrom(source, new CustomColorMatrixEventArgs(source.CustomCheckBox.Checked));

            source.ColorMatrixDropDown.SelectionChangeCommitted += (sender, args)
                => _aggregator.PublishFrom(source, new ChangeColorMatrixEventArgs());

            source.FormClosed += (sender, args)
                => _aggregator.PublishFrom(source, new FormIsClosedEventArgs());
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
