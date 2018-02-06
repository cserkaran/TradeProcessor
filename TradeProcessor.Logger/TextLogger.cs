using System;
using System.Diagnostics;
using TradeProcessor.Interfaces.Logging;

namespace TradeProcessor.TextLogger
{
    public class TextLogger : ILogger
    {
        public void Log(EventLogEntryType eventLogType, Exception e)
        {
            // log to a text file..
        }
    }
}
