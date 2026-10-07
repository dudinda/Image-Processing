using System.Threading;

using ImageProcessing.App.Presentation.UnitTests.Fakes.Components;
using ImageProcessing.Microkernel.MVP.Models.Scope;
using ImageProcessing.Microkernel.MVP.Services.Aggregator.Implementation;

namespace ImageProcessing.App.Presentation.IntegrationTests.Fakes
{
    internal sealed class EventAggregatorWrapper : EventAggregator, IEventAggregatorWrapper
    {
        public EventAggregatorWrapper()
        {
            _lock = new MonitorScope(false);
        }
        protected override void Post(SendOrPostCallback d, object state)
        {
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContextWrapper());
            SynchronizationContext.Current.Send(d, state);
        }

    }
}
