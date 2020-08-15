using System.Threading;

using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components;
using ImageProcessing.Microkernel.MVP.Aggregator.Implementation;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Fakes
{
    internal sealed class EventAggregatorWrapper : EventAggregator, IEventAggregatorWrapper
    {
        private object _state = new object();

        internal override void Post(SendOrPostCallback d, object state)
        {
            var thisSyncContext = new SynchronizationContextWrapper();
            SynchronizationContext.SetSynchronizationContext(thisSyncContext);

            thisSyncContext.Post(d, _state);
        }
    }
}
