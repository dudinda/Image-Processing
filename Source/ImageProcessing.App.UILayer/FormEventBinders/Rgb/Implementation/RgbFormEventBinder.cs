using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.DomainEvents.RgbArgs;
using ImageProcessing.App.UILayer.FormEventBinders.Rgb.Interface;
using ImageProcessing.App.UILayer.FormExposers.Rgb;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;

namespace ImageProcessing.App.UILayer.FormEventBinders.Rgb.Implementation
{
    internal class RgbFormEventBinder : IRgbFormEventBinder
    {
        private readonly IEventAggregator _aggregator;

        public RgbFormEventBinder(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }

        public void OnElementExpose(IRgbFormExposer source)
        {
            source.ApplyFilterButton.Click += (sender, args)
                 => _aggregator.PublishFrom(source,
                     new ApplyRgbFilterEventArgs()
                 );

            source.ColorMatrixMenuButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ShowColorMatrixMenuEventArgs()
                );

            source.RedButton.CheckedChanged += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ApplyRgbChannelFilterEventArgs(RgbChannels.Red)
                );

            source.GreenButton.CheckedChanged += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ApplyRgbChannelFilterEventArgs(RgbChannels.Green)
                );

            source.BlueButton.CheckedChanged += (sender, args)
               => _aggregator.PublishFrom(source,
                   new ApplyRgbChannelFilterEventArgs(RgbChannels.Blue)
               );
        }

        public bool ProcessCmdKey(IRgbFormExposer view, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.R:

                    view.RedButton.Checked = !view.RedButton.Checked;
                    return true;

                case Keys.G:

                    view.GreenButton.Checked = !view.GreenButton.Checked;
                    return true;

                case Keys.B:

                    view.BlueButton.Checked = !view.BlueButton.Checked;
                    return true;                    
            }

            return false;
        }
    }
}
