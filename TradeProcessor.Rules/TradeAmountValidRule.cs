using TradeProcessor.Domain.Interfaces;

namespace TradeProcessor.Rules
{
    /// <summary>
    /// Rule to check if trade amount is valid or not.
    /// </summary>
    /// <seealso cref="TradeProcessor.Domain.Interfaces.ITradeLineRule" />
    public class TradeAmountValidRule : ITradeLineRule
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
