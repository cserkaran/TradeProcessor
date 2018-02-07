using System.Collections.Generic;
using TradeProcessor.Domain.Models;

namespace TradeProcessor.Interfaces
{
    /// <summary>
    /// Repository for CRUD operations with TradeRecord.
    /// </summary>
    /// <seealso cref="TradeProcessor.Interfaces.IDbRepository" />
    public interface ITradeRepository : IDbRepository
    {
        /// <summary>
        /// Creates the trade records.
        /// </summary>
        /// <param name="trades">The trades.</param>
        void CreateTradeRecords(IEnumerable<TradeRecord> trades);
    }
}
