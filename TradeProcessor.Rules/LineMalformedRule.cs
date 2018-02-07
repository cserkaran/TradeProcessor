using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeProcessor.Domain.Interfaces;

namespace TradeProcessor.Rules
{
    public class LineMalformedRule : ITradeLineRule
    {
        public string ValidationMessage { get; private set; }

        public bool Validate(string[] lineFields,int lineNumber)
        {
            if (lineFields.Length != 3)
            {
                ValidationMessage = $"WARN: Line {lineNumber} malformed. Only {lineFields.Length} field(s) found.";
                return false;
            }

            ValidationMessage = string.Empty;

            return true;
        }
    }
}
