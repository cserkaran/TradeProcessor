using System.Collections.Generic;
using TradeProcessor.Domain;

namespace TradeProcessor.Interfaces
{
    public interface ITradeRepository : IDbRepository
    {
        void CreateTradeRecords(IEnumerable<TradeRecord> trades);
    }
}
