using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeProcessor.Domain.Interfaces;

namespace TradeProcessor.Rules
{
    public class TradeCurrenciesMalformedRule : ITradeLineRule
    {
        public string ValidationMessage { get; private set; }

        public bool Validate(string[] lineFields, int lineNumber)
        {
            if (lineFields[0].Length != 6)
            {
                ValidationMessage = $"WARN: Trade currencies on line {0} malformed: [{lineFields[0]}]";
                return false;
            }

            ValidationMessage = string.Empty;
            return true;
        }
    }
}
