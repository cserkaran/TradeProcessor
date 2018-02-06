using System;
using System.Diagnostics;

namespace TradeProcessor.Interfaces.Logging
{
    public interface ILogger
    {
        void Log(EventLogEntryType eventLogType, Exception e);
    }
}
