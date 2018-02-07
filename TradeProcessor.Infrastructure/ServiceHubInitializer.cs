using System.Collections.Generic;
using System.Linq;
using TradeProcessor.Domain.Interfaces;
using TradeProcessor.Infrastructure.Extensibility;
using TradeProcessor.Interfaces;
using TradeProcessor.Interfaces.Extensibility;
using TradeProcessor.Interfaces.Extensibility.Extensibility;
using TradeProcessor.Interfaces.Logging;

namespace TradeProcessor.Infrastructure
{
    public class ServiceHubInitializer : IServiceHubInitializer
    {
        private readonly ExtensionRepository _extensionRepository;

        public ServiceHubInitializer()
        {
            ExtensionRepositoryLoader.Instance.Load();

            _extensionRepository = ExtensionRepositoryLoader.Instance.GetInnerRepository<ExtensionRepository>();
        }

        public IList<ITradeLineRule> InitializeTradeLineRules()
        {
            List<ITradeLineRule> tradeLineRules = new List<ITradeLineRule>();
            var tradeLineRulesExtensions = _extensionRepository.GetExtension<ITradeLineRulesExtension>(typeof(ITradeLineRule));
            foreach (var tradeLineRulesExtension in tradeLineRulesExtensions)
            {
                tradeLineRules.AddRange(tradeLineRulesExtension.TradeLineRules());
            }

            return tradeLineRules;
        }

        public IList<IDbRepository> InitializeDbRepositories()
        {
            List<IDbRepository> dbRepositories = new List<IDbRepository>();
            var dbRepositoryExtensions = _extensionRepository.GetExtension<IDbRepositoryExtension>(typeof(IDbRepository));
            foreach (var dbRepositoryExtension in dbRepositoryExtensions)
            {
                dbRepositories.AddRange(dbRepositoryExtension.DbRepositories());
            }

            return dbRepositories;
        }

        public ILogger InitLogger()
        {
            var loggingExtension = _extensionRepository.GetExtension<ILoggingExtension>(typeof(ILogger)).FirstOrDefault();
            return loggingExtension.Logger;
        }
    }
}
