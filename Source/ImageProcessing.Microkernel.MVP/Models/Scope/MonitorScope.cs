using System;
using System.Threading;

namespace ImageProcessing.Microkernel.MVP.Models.Scope
{
    public class MonitorScope : IDisposable
    {
        private readonly bool _useMonitor;
        private readonly object _sync = new object();

        public MonitorScope(bool useMonitor)
        {
            _useMonitor = useMonitor;
        }

        public IDisposable Enter()
        {
            if (_useMonitor)
            {
                Monitor.Enter(_sync);
            }
            return this;
        }

        public void Dispose()
        {
            if(_useMonitor)
            {
                Monitor.Exit(_sync);
            }
        }
    }
}
