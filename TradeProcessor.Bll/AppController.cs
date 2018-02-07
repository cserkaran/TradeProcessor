using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using TradeProcessor.Domain.Models;
using TradeProcessor.Infrastructure;
using TradeProcessor.Interfaces;

namespace TradeProcessor.Bll
{
    public class AppController
    {
        private static float LotSize = 100000f;
        private IServiceHubInitializer _initializer;

        public AppController(IServiceHubInitializer initializer)
        {
            _initializer = initializer;
        }

        public void ProcessTrades(Stream stream)
        {
            PlatformServiceHub.Instance.Initialize(_initializer);
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
