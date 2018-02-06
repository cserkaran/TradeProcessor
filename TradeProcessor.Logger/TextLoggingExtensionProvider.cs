using TradeProcessor.Infrastructure.Extensibility;
using TradeProcessor.Interfaces.Extensibility;
using TradeProcessor.Interfaces.Logging;

namespace TradeProcessor.TextLogger
{
    [ExtensionProvider("TextLoggingExtensionProvider", typeof(ILogger))]
    public class TextLoggingExtensionProvider : IExtensionProvider
    {
        public IExtension GetExtension()
        {
            return new TextLoggingExtension();
        }
    }
}
