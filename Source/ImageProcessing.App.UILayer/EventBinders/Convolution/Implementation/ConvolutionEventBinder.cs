using ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs;
using ImageProcessing.App.UILayer.EventBinders.Convolution.Interface;
using ImageProcessing.App.UILayer.FormElements.Convolution;
using ImageProcessing.Microkernel.MVP.Aggregator.Interface;

namespace ImageProcessing.App.UILayer.EventBinders.Convolution.Implementation
{
    internal sealed class ConvolutionEventBinder : IConvolutionEventBinder
    {
        private readonly IEventAggregator _aggregator;

        public ConvolutionEventBinder(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }

        public void Bind(IConvolutionFormElements source)
        {
            source.ApplyButton.Click += (sender, args)
                => _aggregator.PublishFrom(source,
                    new ConvolutionFilterEventArgs(source)
                );
        }
    }
}
