using TradeProcessor.Domain.Interfaces;
using TradeProcessor.Infrastructure.Extensibility;
using TradeProcessor.Interfaces.Extensibility;

namespace TradeProcessor.Rules.Extensibility
{
    [ExtensionProvider("TradeLineRuleExtensionProvider", typeof(ITradeLineRule))]
    public class TradeLineRuleExtensionProvider : IExtensionProvider
    {
        public IExtension GetExtension()
        {
            return new TradeLineRulesExtension();
        }
    }
}
