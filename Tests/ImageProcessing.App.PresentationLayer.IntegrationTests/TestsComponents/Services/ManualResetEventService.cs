using System.Threading;

namespace ImageProcessing.App.PresentationLayer.UnitTests.Services
{
    internal sealed class ManualResetEventService : IManualResetEventService
    {
        private readonly ManualResetEvent _event
            = new ManualResetEvent(false);

        public void WaitSignal()
            => _event.WaitOne();

        public void Signal()
            => _event.Set();

        public void Reset()
            => _event.Reset();

        public void Dispose()
            => _event.Dispose();
    }
}
