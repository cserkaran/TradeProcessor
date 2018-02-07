using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeProcessor.Interfaces.Logging;

namespace TradeProcessor.Interfaces.Extensibility.Extensibility
{
    /// <summary>
    /// Extension for injecting loggers.
    /// </summary>
    /// <seealso cref="TradeProcessor.Interfaces.Extensibility.IExtension" />
    public interface ILoggingExtension : IExtension
    {
        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <value>
        /// The logger.
        /// </value>
        ILogger Logger { get; }
    }
}
