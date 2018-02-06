using TradeProcessor.Infrastructure.Extensibility;
using TradeProcessor.Interfaces;
using TradeProcessor.Interfaces.Extensibility;

namespace TradeProcessor.Repository
{
    [ExtensionProvider("TradeRepositoryExtensionProvider", typeof(IDbRepository))]
    public class TradeRepositoryExtensionProvider : IExtensionProvider
    {
        public IExtension GetExtension()
        {
            return new TradeRepositoryDbExtension();
        }
    }
}
