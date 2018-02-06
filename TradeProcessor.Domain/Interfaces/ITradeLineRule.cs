namespace TradeProcessor.Domain.Interfaces
{
    public interface ITradeLineRule
    {
        /// <summary>
        /// Evaluates the validity of a rule given an instance of an entity
        /// </summary>
       
        bool Validate(string[] lineFields,int lineNumber);

        /// <summary>
        /// Indicates the message used to notify the user if the rule fails
        /// </summary>
        string ValidationMessage { get; }
    }
}
