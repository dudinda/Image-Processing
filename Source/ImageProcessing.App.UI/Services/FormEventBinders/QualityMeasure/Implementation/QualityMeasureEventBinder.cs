using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.UI.Services.FormExposers;
using ImageProcessing.Microkernel.MVP.Services.Aggregator;

namespace ImageProcessing.App.UI.Services.FormEventBinders.QualityMeasure.Implementation
{
    internal class QualityMeasureEventBinder : IQualityMeasureEventBinder
    {
        private readonly IEventAggregator _aggregator;

        public QualityMeasureEventBinder(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
        }

        public void OnElementExpose(IQualityMeasureExposer source)
        {
            source.FormClosed += (sender, args)
               => _aggregator.PublishFrom(source, new FormIsClosedEventArgs());
        }
    }
}
