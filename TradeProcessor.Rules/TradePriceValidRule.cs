using TradeProcessor.Domain.Interfaces;

namespace TradeProcessor.Rules
{
    /// <summary>
    /// Rule to check if trade price is valid or not.
    /// </summary>
    /// <seealso cref="TradeProcessor.Domain.Interfaces.ITradeLineRule" />
    public class TradePriceValidRule : ITradeLineRule
    {
        /// <summary>
        /// Indicates the message used to notify the user if the rule fails
        /// </summary>
        public string ValidationMessage { get; private set; }

        /// <summary>
        /// Evaluates the validity of a rule.
        /// </summary>
        /// <param name="lineFields"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
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
