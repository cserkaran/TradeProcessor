using System.Collections.Generic;
using TradeProcessor.Domain.Models;

namespace TradeProcessor.Interfaces
{
    public interface ITradeRepository : IDbRepository
    {
        void CreateTradeRecords(IEnumerable<TradeRecord> trades);
    }
}
