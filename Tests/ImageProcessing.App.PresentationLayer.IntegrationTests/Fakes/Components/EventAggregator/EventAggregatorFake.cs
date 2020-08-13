using System.Threading;

using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components;
using ImageProcessing.Microkernel.MVP.Aggregator.Implementation;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Fakes
{
    internal sealed class EventAggregatorFake : EventAggregator, IEventAggregatorFake
    {
        private object _state = new object();

        internal override void Post(SendOrPostCallback d, object state)
        {
            var thisSyncContext = new MockSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(thisSyncContext);

            thisSyncContext.Post(d, _state);
        }
    }
}
