using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeProcessor.Domain.Interfaces;

namespace TradeProcessor.Rules
{
    public class TradeAmountValidRule : ITradeLineRule
    {
        public string ValidationMessage { get; private set; }

        public bool Validate(string[] lineFields, int lineNumber)
        {
            if (!int.TryParse(lineFields[1], out int tradeAmount))
            {
                ValidationMessage = $"WARN: Trade amount on line {0} is not a valid integer: [{lineFields[1]}]";
                return false;
            }

            if (tradeAmount < 0)
            {
                ValidationMessage = $"WARN: Trade amount on line {0} is not a positive integer: [{lineFields[1]}]";
                return false;
            }

            ValidationMessage = string.Empty;
            return true;
        }
    }
}
