using System;
using System.Diagnostics;

using ImageProcessing.App.ServiceLayer.Win.Services.Logger.Interface;

namespace ImageProcessing.App.ServiceLayer.Win.Services.Logger.Implementation
{
    /// <inheritdoc cref="ILoggerService"/>
    public sealed class LoggerService : ILoggerService
    {
        private readonly EventLog _viewer = new EventLog(nameof(ImageProcessing));

        /// <inheritdoc/>
        public void WriteEntry(string message, EventLogEntryType type)
            => _viewer.WriteEntry(message, type);
        
    }
}
