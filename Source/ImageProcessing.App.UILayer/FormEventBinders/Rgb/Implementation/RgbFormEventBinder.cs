using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.RgbArgs;
using ImageProcessing.App.UILayer.Exposers.Rgb;
using ImageProcessing.App.UILayer.FormEventBinders.Rgb.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;

namespace ImageProcessing.App.UILayer.FormEventBinders.Rgb.Implementation
{
    internal sealed class RgbFormEventBinder : IRgbFormEventBinder
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
                     new ApplyRgbFilterEventArgs(source)
                 );

            source.RedButton.CheckedChanged += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ApplyRgbColorFilterEventArgs(RgbColors.Red, source)
                );

            source.GreenButton.CheckedChanged += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ApplyRgbColorFilterEventArgs(RgbColors.Green, source)
                );

            source.BlueButton.CheckedChanged += (sender, args)
               => _aggregator.PublishFrom(source,
                   new ApplyRgbColorFilterEventArgs(RgbColors.Blue, source)
               );
        }

        public bool ProcessCmdKey(IRgbFormExposer view, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.R: view.RedButton.Checked = !view.RedButton.Checked; return true;
                case Keys.G: view.GreenButton.Checked = !view.GreenButton.Checked; return true;
                case Keys.B: view.BlueButton.Checked = !view.BlueButton.Checked; return true;                    
            }

            return false;
        }
    }
}
