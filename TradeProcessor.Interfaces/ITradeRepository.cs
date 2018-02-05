using System.Collections.Generic;
using TradeProcessor.Domain;

namespace TradeProcessor.Interfaces
{
    public interface ITradeRepository
    {
        void CreateTradeRecords(IEnumerable<TradeRecord> trades);
    }
}
