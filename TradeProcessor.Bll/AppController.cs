using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using TradeProcessor.Domain.Models;
using TradeProcessor.Infrastructure;
using TradeProcessor.Interfaces;

namespace TradeProcessor.Bll
{
    /// <summary>
    /// Application Controller part of Business Logic Layer.
    /// Processes the stream and creates the trades in database.
    /// </summary>
    public class AppController
    {
        /// <summary>
        /// The lot size
        /// </summary>
        private static float LotSize = 100000f;

        /// <summary>
        /// The initializer <see cref="IServiceHubInitializer"/> to initialize Service Hub.
        /// </summary>
        private IServiceHubInitializer _initializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppController"/> class.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        public AppController(IServiceHubInitializer initializer)
        {
            _initializer = initializer;
            PlatformServiceHub.Instance.Initialize(_initializer);
        }

        /// <summary>
        /// Processes the stream for creating trades.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public void ProcessTrades(Stream stream)
        {
            
            var lines = new List<string>();

            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            var trades = new List<TradeRecord>();
            var lineCount = 1;

            var rules = PlatformServiceHub.Instance.TradeLineRules;
            bool allRulesPassed = true;
            foreach (var line in lines)
            {
                var fields = line.Split(new char[] { ',' });

                foreach (var rule in rules)
                {
                    if (!rule.Validate(fields, lineCount))
                    {
                        PlatformServiceHub.Instance.Logger.Log(EventLogEntryType.Warning, rule.ValidationMessage);
                        allRulesPassed = false;
                        break;
                    }
                }

                if (!allRulesPassed)
                {
                    return;
                }

                TradeRecord trade = ExtractTradeRecord(fields);

                trades.Add(trade);

                lineCount++;

                PlatformServiceHub.Instance.TradeRepository.CreateTradeRecords(trades);
                PlatformServiceHub.Instance.Logger.Log(EventLogEntryType.Information, $"INFO: {trades.Count} trades processed");
            }
        }

        /// <summary>
        /// Extracts the trade record from the line fields of the stream.
        /// </summary>
        /// <param name="fields">The fields.</param>
        /// <returns><see cref="TradeRecord"/>the record object.</returns>
        private static TradeRecord ExtractTradeRecord(string[] fields)
        {
            var sourceCurrencyCode = fields[0].Substring(0, 3);
            var destinationCurrencyCode = fields[0].Substring(3, 3);

            var tradeAmount = int.Parse(fields[1]);
            var tradePrice = decimal.Parse(fields[2]);

            // Calculate values
            var trade = new TradeRecord
            {
                SourceCurrency = sourceCurrencyCode,
                DestinationCurrency = destinationCurrencyCode,
                Lots = tradeAmount / LotSize,
                Price = tradePrice
            };
            return trade;
        }
    }
}
