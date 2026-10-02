using System.Threading;

namespace ImageProcessing.App.Presentation.IntegrationTests.Fakes
{
    internal class SynchronizationContextWrapper : SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object state)
            => Send(d, state);
    }
}
