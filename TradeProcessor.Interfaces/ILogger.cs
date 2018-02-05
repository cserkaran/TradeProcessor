using System;
using System.Diagnostics;

namespace TradeProcessor.Interfaces
{
    public interface ILogger
    {
        void Log(EventLogEntryType type, Exception e);
    }
}
