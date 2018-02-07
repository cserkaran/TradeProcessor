using TradeProcessor.Infrastructure.Extensibility;
using TradeProcessor.Interfaces.Extensibility;
using TradeProcessor.Interfaces.Logging;

namespace TradeProcessor.TextLogger
{
    /// <summary>
    /// Extension to provide textlogger instance.
    /// </summary>
    /// <seealso cref="TradeProcessor.Interfaces.Extensibility.IExtensionProvider" />
    [ExtensionProvider("TextLoggingExtensionProvider", typeof(ILogger))]
    public class TextLoggingExtensionProvider : IExtensionProvider
    {
        /// <summary>
        /// Gets an instance of the extension
        /// </summary>
        /// <returns></returns>
        public IExtension GetExtension()
        {
            return new TextLoggingExtension();
        }
    }
}
