using TradeProcessor.Domain.Interfaces;

namespace TradeProcessor.Rules
{
    public class TradePriceValidRule : ITradeLineRule
    {
        public string ValidationMessage { get; private set; }

        public bool Validate(string[] lineFields, int lineNumber)
        {
            decimal tradePrice;
            if (!decimal.TryParse(lineFields[2], out tradePrice))
            {
                ValidationMessage = $"WARN: Trade price on line {0} is not a valid decimal: [{lineFields[1]}]";
                return false;
            }

            ValidationMessage = string.Empty;
            return true;
        }
    }
}
