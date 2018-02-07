using System.Collections.Generic;
using TradeProcessor.Domain.Interfaces;
using TradeProcessor.Interfaces.Logging;

namespace TradeProcessor.Interfaces
{
    /// <summary>
    /// Initializer to load the MEF exports and read and initialize the loaded extensions
    /// </summary>
    public interface IServiceHubInitializer
    {
        /// <summary>
        /// Initializes the trade line rules.
        /// </summary>
        /// <returns></returns>
        IList<ITradeLineRule> InitializeTradeLineRules();

        /// <summary>
        /// Initializes the database repositories.
        /// </summary>
        /// <returns></returns>
        IList<IDbRepository> InitializeDbRepositories();

        /// <summary>
        /// Initializes the logger.
        /// </summary>
        /// <returns></returns>
        ILogger InitLogger();

    }
}
