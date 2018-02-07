using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TradeProcessor.Domain;
using TradeProcessor.Domain.Models;
using TradeProcessor.Interfaces;

namespace TradeProcessor.Repository
{
    /// <summary>
    /// Repository for CRUD operations with TradeRecord.
    /// </summary>
    /// <seealso cref="TradeProcessor.Interfaces.ITradeRepository" />
    public class TradeRepository : ITradeRepository
    {
        public void Initialize()
        {
            // Initiliaze repository here.. e.g create DB Pool etc..;
        }

        /// <summary>
        /// Creates the trade records.
        /// </summary>
        /// <param name="trades">The trades.</param>
        public void CreateTradeRecords(IEnumerable<TradeRecord> trades)
        {
            using (var connection = new SqlConnection("Data Source=(local);Initial Catalog=TradeDatabase;Integrated Security=True"))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    foreach (var trade in trades)
                    {
                        var command = connection.CreateCommand();
                        command.Transaction = transaction;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "dbo.insert_trade";
                        command.Parameters.AddWithValue("@sourceCurrency", trade.SourceCurrency);
                        command.Parameters.AddWithValue("@destinationCurrency", trade.DestinationCurrency);
                        command.Parameters.AddWithValue("@lots", trade.Lots);
                        command.Parameters.AddWithValue("@price", trade.Price);

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                connection.Close();
            }
        }

        
    }
}
