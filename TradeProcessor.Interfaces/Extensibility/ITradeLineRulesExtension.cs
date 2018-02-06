using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeProcessor.Domain.Interfaces;

namespace TradeProcessor.Interfaces.Extensibility
{
    public interface ITradeLineRulesExtension  : IExtension
    {
        IList<ITradeLineRule> TradeLineRules();
    }
}
