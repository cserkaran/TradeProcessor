using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeProcessor.Interfaces;
using TradeProcessor.Interfaces.Extensibility;

namespace TradeProcessor.Infrastructure.Extensibility
{
    public sealed class DbRepositoryExtension : IDbRepositoryExtension
    {
        public IList<IDbRepository> DbRepositories()
        {
             
        }
    }
}
