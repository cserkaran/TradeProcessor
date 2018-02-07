using System;
using TradeProcessor.Infrastructure;

namespace TradeProcessor.ConsoleApp
{
    /// <summary>
    /// Console app to test everything is loading fine.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            PlatformServiceHub.Instance.Initialize(new ServiceHubInitializer());
            Console.Read();
        }
    }
}
