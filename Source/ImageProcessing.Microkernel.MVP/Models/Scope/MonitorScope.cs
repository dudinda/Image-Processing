using System;
using System.Threading;

namespace ImageProcessing.Microkernel.MVP.Models.Scope
{
    /// <summary>
    /// The main purpose is to isolate the monitor lock used to synchronize access
    /// within the Event Aggregator. By default, the value is set to true.
    /// When the integration testing workflow is used, the value is set to false to avoid deadlocks.
    /// </summary>
    /// <example>
    /// <code>
    /// public class EventAggregatorWrapper : EventAggregator, IEventAggregatorWrapper
    /// {
    ///     public EventAggregatorWrapper()
    ///     {
    ///         _lock = new MonitorScope(false);
    ///     }
    ///     ...
    /// }
    /// </code>
    /// </example>
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
