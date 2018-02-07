using TradeProcessor.Infrastructure.Extensibility;
using TradeProcessor.Interfaces;
using TradeProcessor.Interfaces.Extensibility;

namespace TradeProcessor.Repository
{
    /// <summary>
    /// Provider to inject the extension
    /// </summary>
    /// <seealso cref="TradeProcessor.Interfaces.Extensibility.IExtensionProvider" />
    [ExtensionProvider("TradeRepositoryExtensionProvider", typeof(IDbRepository))]
    public class TradeRepositoryExtensionProvider : IExtensionProvider
    {
        public IExtension GetExtension()
        {
            return new TradeRepositoryDbExtension();
        }
    }
}
