using TradeProcessor.Interfaces.Extensibility.Extensibility;
using TradeProcessor.Interfaces.Logging;

namespace TradeProcessor.TextLogger
{
    public class TextLoggingExtension : ILoggingExtension
    {
        public ILogger Logger { get; }

        public TextLoggingExtension()
        {
            Logger = new TextLogger();
        }
    }
}
