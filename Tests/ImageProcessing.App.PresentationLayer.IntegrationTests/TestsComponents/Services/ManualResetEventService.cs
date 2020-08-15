using System.Threading;

namespace ImageProcessing.App.PresentationLayer.UnitTests.Services
{
    internal sealed class ManualResetEventService : IManualResetEventService
    {
        public ManualResetEvent Event { get; private set; }
            = new ManualResetEvent(false);

        public void Dispose()
            => Event.Dispose();
    }
}
