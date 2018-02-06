using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeProcessor.Interfaces.Logging;

namespace TradeProcessor.Interfaces.Extensibility.Extensibility
{
    public interface ILoggingExtension : IExtension
    {
        ILogger Logger { get; }
    }
}
