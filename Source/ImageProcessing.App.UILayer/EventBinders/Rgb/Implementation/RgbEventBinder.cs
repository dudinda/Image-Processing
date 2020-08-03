using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.RgbArgs;
using ImageProcessing.App.UILayer.EventBinders.Rgb.Interface;
using ImageProcessing.App.UILayer.FormControls.Rgb;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;

namespace ImageProcessing.App.UILayer.EventBinders.Rgb.Implementation
{
    internal sealed class RgbEventBinder : IRgbEventBinder
    {
        private readonly IEventAggregator _aggregator;

        public RgbEventBinder(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }

        public void Bind(IRgbElementExposer source)
        {
            source.ApplyFilterButton.Click += (sender, args)
                 => _aggregator.PublishFrom(source,
                     new ApplyRgbFilterEventArgs(source)
                 );

            source.RedButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ApplyRgbColorFilterEventArgs(RgbColors.Red, source)
                );

            source.GreenButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ApplyRgbColorFilterEventArgs(RgbColors.Green, source)
                );

            source.BlueButton.Click += (sender, args)
               => _aggregator.PublishFrom(source,
                   new ApplyRgbColorFilterEventArgs(RgbColors.Blue, source)
               );
        }

        public bool ProcessCmdKey(IRgbElementExposer view, Keys keyData)
        {
            return false;
        }
    }
}
