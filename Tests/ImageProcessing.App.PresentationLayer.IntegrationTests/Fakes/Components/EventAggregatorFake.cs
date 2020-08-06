using System.Threading;

using ImageProcessing.Microkernel.MVP.Aggregator.Implementation;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Fakes
{
    internal sealed class EventAggregatorFake : EventAggregator
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
