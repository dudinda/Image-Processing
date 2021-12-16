using System.Diagnostics;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Logger.Interface;
using ImageProcessing.App.ServiceLayer.Win.Services.Logger.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Logger.Implementation
{
    internal class LoggerServiceWrapper : ILoggerServiceWrapper
    {
        private readonly LoggerService _service
            = new LoggerService();

        public void WriteEntry(string message, EventLogEntryType type)
            => _service.WriteEntry(message, type);
    }
}
