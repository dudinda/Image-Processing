using System.Threading;

namespace ImageProcessing.App.PresentationLayer.UnitTests.Services
{
    internal sealed class AutoResetEventService : IAutoResetEventService
    {
        private readonly AutoResetEvent _event
            = new AutoResetEvent(false);

        public void WaitSignal()
            => _event.WaitOne();

        public void Signal()
            => _event.Set();

        public void Dispose()
            => _event.Close();
    }
}
