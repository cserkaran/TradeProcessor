using Moq;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using TradeProcessor.Bll;
using TradeProcessor.Domain.Interfaces;
using TradeProcessor.Domain.Models;
using TradeProcessor.Infrastructure;
using TradeProcessor.Interfaces;
using TradeProcessor.Interfaces.Logging;
using TradeProcessor.Rules;
using Xunit;

namespace TradeProcessor.Tests
{
    public class TradeProcessorTests
    {
        private Mock<IServiceHubInitializer> _mockServiceHubInitializer;

        public TradeProcessorTests()
        {
            _mockServiceHubInitializer = new Mock<IServiceHubInitializer>();

            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(item => item.Log(EventLogEntryType.Information, ""));

            List<ITradeLineRule> tradeLineRules = new List<ITradeLineRule>
            {
                new LineMalformedRule(),
                new TradeCurrenciesMalformedRule(),
                new TradeAmountValidRule(),
                new TradePriceValidRule()
            };

            Mock<ITradeRepository> mockTradeRepository = new Mock<ITradeRepository>();
            mockTradeRepository.Setup(tradeRepo => tradeRepo.CreateTradeRecords(new List<TradeRecord>
            {
                new TradeRecord{ SourceCurrency = "AUD", DestinationCurrency = "EUR",Lots = 90, Price = 12000}
            }));

            _mockServiceHubInitializer.Setup(item => item.InitLogger()).Returns(mockLogger.Object);
            _mockServiceHubInitializer.Setup(item => item.InitializeTradeLineRules()).Returns(tradeLineRules);
            _mockServiceHubInitializer.Setup(item => item.InitializeDbRepositories()).Returns(new List<IDbRepository> { mockTradeRepository.Object});
        }

        [Fact]
        public void Test_TradeLine_IsWellFormed()
        {
            var file = Path.GetDirectoryName(Assembly.GetExecutingAssembly().EscapedCodeBase.Remove(0, 8)) + "\\inputA.txt";
            using (StreamReader r = new StreamReader(file))
            {
                AppController appController = new AppController(_mockServiceHubInitializer.Object);
                appController.ProcessTrades(r.BaseStream);
            }
           
        }
    }
}
