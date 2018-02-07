using TradeProcessor.Domain.Interfaces;

namespace TradeProcessor.Rules
{
    /// <summary>
    /// Rule to check if trade currencies are well formed or not.
    /// </summary>
    /// <seealso cref="TradeProcessor.Domain.Interfaces.ITradeLineRule" />
    public class TradeCurrenciesMalformedRule : ITradeLineRule
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
