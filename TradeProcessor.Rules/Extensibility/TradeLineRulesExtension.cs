using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeProcessor.Domain.Interfaces;
using TradeProcessor.Interfaces;
using TradeProcessor.Interfaces.Extensibility;

namespace TradeProcessor.Rules.Extensibility
{
    public class TradeLineRulesExtension : ITradeLineRulesExtension
    {
        public IList<ITradeLineRule> TradeLineRules()
        {
            return new List<ITradeLineRule>()
            {
                new LineMalformedRule(),
                new TradeCurrenciesMalformedRule(),
                new TradeAmountValidRule(),
                new TradePriceValidRule()
            };
        }
    }
}
