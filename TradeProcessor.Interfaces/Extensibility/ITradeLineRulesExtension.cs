using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeProcessor.Domain.Interfaces;

namespace TradeProcessor.Interfaces.Extensibility
{
    /// <summary>
    /// Extension to inject tradeline rules.
    /// </summary>
    /// <seealso cref="TradeProcessor.Interfaces.Extensibility.IExtension" />
    public interface ITradeLineRulesExtension  : IExtension
    {
        IList<ITradeLineRule> TradeLineRules();
    }
}
