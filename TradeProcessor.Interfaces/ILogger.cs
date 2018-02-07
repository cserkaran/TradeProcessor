using System.Diagnostics;

namespace TradeProcessor.Interfaces.Logging
{
    /// <summary>
    /// Interface to be implemented by Loggers
    /// </summary>
    public interface ILogger
    {
        void Log(EventLogEntryType eventLogType, string message);
    }
}
