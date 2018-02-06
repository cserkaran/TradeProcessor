using System;
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
    /// <summary>
    /// A Service Hub at platform level to do System level initializations and 
    /// provide a single global access to multiple other services e.g. Logging Service 
    /// can be made part of this hub.
    /// A single instance of this exists throughout the app.
    /// </summary>
    public class PlatformServiceHub
    {
        /// <summary>
        /// The lazy object for singleton pattern.
        /// </summary>
        private static readonly Lazy<PlatformServiceHub> LazyObject =
          new Lazy<PlatformServiceHub>(() => new PlatformServiceHub());

        private List<IDbRepository> _dbRepositories;

        /// <summary>
        /// The singleton instance of PlatformServiceHub
        /// </summary>
        public static PlatformServiceHub Instance
        {
            get
            {
                return LazyObject.Value;
            }
        }

        public ILogger Logger { get; private set; }

        public ITradeRepository TradeRepository { get; private set; }

        public IList<ITradeLineRule> TradeLineRules { get; private set; }

        /// <summary>
        /// Private constructor for singleton pattern
        /// </summary>
        private PlatformServiceHub()
        {
            TradeLineRules = new List<ITradeLineRule>();
        }

        public void Initialize()
        {
            ExtensionRepositoryLoader.Instance.Load();

            var extensionRepository = ExtensionRepositoryLoader.Instance.GetInnerRepository<ExtensionRepository>();

            InitLogger(extensionRepository);

            InitializeTradeLineRules(extensionRepository);

            InitializeDbRepositories(extensionRepository);
        }

        private void InitializeTradeLineRules(ExtensionRepository extensionRepository)
        {
            var tradeLineRulesExtensions = extensionRepository.GetExtension<ITradeLineRulesExtension>(typeof(ITradeLineRule));
            foreach (var tradeLineRulesExtension in tradeLineRulesExtensions)
            {
                foreach (var tradeLineRule in tradeLineRulesExtension.TradeLineRules())
                {
                    TradeLineRules.Add(tradeLineRule);
                }
            }
        }

        private void InitializeDbRepositories(ExtensionRepository extensionRepository)
        {
            _dbRepositories = new List<IDbRepository>();
            var dbRepositoryExtensions = extensionRepository.GetExtension<IDbRepositoryExtension>(typeof(IDbRepository));
            foreach (var dbRepositoryExtension in dbRepositoryExtensions)
            {
                _dbRepositories.AddRange(dbRepositoryExtension.DbRepositories());
            }

            TradeRepository = _dbRepositories.OfType<ITradeRepository>().FirstOrDefault();
        }

        private void InitLogger(ExtensionRepository extensionRepository)
        {
            var loggingExtension = extensionRepository.GetExtension<ILoggingExtension>(typeof(ILogger)).FirstOrDefault();
            Logger = loggingExtension.Logger;
        }
    }
}
