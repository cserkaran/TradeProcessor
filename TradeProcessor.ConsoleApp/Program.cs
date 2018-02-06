using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeProcessor.Infrastructure;

namespace TradeProcessor.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PlatformServiceHub.Instance.Initialize();
        }
    }
}
