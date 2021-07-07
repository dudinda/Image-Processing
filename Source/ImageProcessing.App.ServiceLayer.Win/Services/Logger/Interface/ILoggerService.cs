using System.Diagnostics;

namespace ImageProcessing.App.ServiceLayer.Win.Services.Logger.Interface
{
    /// <summary>
    /// Wrapper around the <see cref="EventLog"/> class.
    /// </summary>
    public interface ILoggerService
    {
        /// <inheritdoc cref="EventLog.WriteEntry(string, EventLogEntryType)"/>
        void WriteEntry(string message, EventLogEntryType type);
    }
}
