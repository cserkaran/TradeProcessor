using System.Collections.Generic;
using TradeProcessor.Domain.Interfaces;
using TradeProcessor.Interfaces.Logging;

namespace TradeProcessor.Interfaces
{
    public interface IServiceHubInitializer
    {
        IList<ITradeLineRule> InitializeTradeLineRules();

        IList<IDbRepository> InitializeDbRepositories();

        ILogger InitLogger();

    }
}
