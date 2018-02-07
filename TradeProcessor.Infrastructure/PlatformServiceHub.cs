using System;
using System.Collections.Generic;
using System.Linq;
using TradeProcessor.Domain.Interfaces;
using TradeProcessor.Interfaces;
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

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <value>
        /// The logger.
        /// </value>
        public ILogger Logger { get; private set; }

        /// <summary>
        /// Gets the TradeRepository for CRUD operations with TradeRecord.
        /// </summary>
        /// <value>
        /// The trade repository.
        /// </value>
        public ITradeRepository TradeRepository { get; private set; }

        /// <summary>
        /// Gets the rules to be satisfied to create a valid TradeRecord.
        /// </summary>
        /// <value>
        /// The trade line rules.
        /// </value>
        public IList<ITradeLineRule> TradeLineRules { get; private set; }

        /// <summary>
        /// Private constructor for singleton pattern
        /// </summary>
        private PlatformServiceHub()
        {
            TradeLineRules = new List<ITradeLineRule>();
        }

        /// <summary>
        /// Initializes the hub.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        public void Initialize(IServiceHubInitializer initializer)
        {
            Logger = initializer.InitLogger();
            TradeLineRules = initializer.InitializeTradeLineRules();
            IList<IDbRepository> dbRepositories = initializer.InitializeDbRepositories();
            TradeRepository = dbRepositories.OfType<ITradeRepository>().FirstOrDefault();
        }
    }
}
