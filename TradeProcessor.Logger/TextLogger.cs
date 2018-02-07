using System.Diagnostics;
using TradeProcessor.Interfaces.Logging;

namespace TradeProcessor.TextLogger
{
    /// <summary>
    /// Logger to log to a text file.
    /// </summary>
    /// <seealso cref="TradeProcessor.Interfaces.Logging.ILogger" />
    public class TextLogger : ILogger
    {
        /// <summary>
        /// Logs the specified event log type.
        /// </summary>
        /// <param name="eventLogType">Type of the event log.</param>
        /// <param name="message">The message.</param>
        public void Log(EventLogEntryType eventLogType, string message)
        {
            // log to a text file..
        }
    }
}
