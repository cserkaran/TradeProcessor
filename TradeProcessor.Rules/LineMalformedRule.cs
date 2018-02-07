using TradeProcessor.Domain.Interfaces;

namespace TradeProcessor.Rules
{
    /// <summary>
    /// Checks if the text line is well formed or not.
    /// </summary>
    /// <seealso cref="TradeProcessor.Domain.Interfaces.ITradeLineRule" />
    public class LineMalformedRule : ITradeLineRule
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
