using System.Diagnostics;
using TradeProcessor.Interfaces.Logging;

namespace TradeProcessor.TextLogger
{
    public class TextLogger : ILogger
    {
        public void Log(EventLogEntryType eventLogType, string message)
        {
            // log to a text file..
        }
    }
}
