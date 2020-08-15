using System.Threading;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Fakes
{
    internal class SynchronizationContextWrapper : SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object state)
            => d(state);
    }
}
