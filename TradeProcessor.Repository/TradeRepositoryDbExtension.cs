using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeProcessor.Interfaces;
using TradeProcessor.Interfaces.Extensibility;

namespace TradeProcessor.Repository
{
    /// <summary>
    /// Extension to provide TradeRepository instance.
    /// </summary>
    /// <seealso cref="TradeProcessor.Interfaces.Extensibility.IDbRepositoryExtension" />
    public class TradeRepositoryDbExtension : IDbRepositoryExtension
    {
        public IList<IDbRepository> DbRepositories()
        {
            return new List<IDbRepository>() { new TradeRepository() };    
        }
    }
}
