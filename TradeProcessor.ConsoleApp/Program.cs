using TradeProcessor.Infrastructure;

namespace TradeProcessor.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PlatformServiceHub.Instance.Initialize(new ServiceHubInitializer());
        }
    }
}
