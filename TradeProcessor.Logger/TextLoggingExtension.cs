using TradeProcessor.Interfaces.Extensibility.Extensibility;
using TradeProcessor.Interfaces.Logging;

namespace TradeProcessor.TextLogger
{
    /// <summary>
    /// TextLoggingExtension to inject TextLogger.
    /// </summary>
    /// <seealso cref="TradeProcessor.Interfaces.Extensibility.Extensibility.ILoggingExtension" />
    public class TextLoggingExtension : ILoggingExtension
    {
        public ILogger Logger { get; }

        public TextLoggingExtension()
        {
            Logger = new TextLogger();
        }
    }
}
