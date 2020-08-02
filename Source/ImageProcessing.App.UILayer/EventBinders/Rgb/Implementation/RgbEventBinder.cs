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

        public void Bind(IRgbFormElements source)
        {
            source.ApplyFilterButton.Click += (sender, args)
                 => _aggregator.PublishFrom(source,
                     new RgbFilterEventArgs(source)
                 );

            source.RedButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new RgbColorFilterEventArgs(RgbColors.Red, source)
                );

            source.GreenButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new RgbColorFilterEventArgs(RgbColors.Green, source)
                );

            source.BlueButton.Click += (sender, args)
               => _aggregator.PublishFrom(source,
                   new RgbColorFilterEventArgs(RgbColors.Blue, source)
               );
        }
    }
}
