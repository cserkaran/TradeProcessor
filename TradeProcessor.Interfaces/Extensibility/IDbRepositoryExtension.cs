using System.Collections.Generic;

namespace TradeProcessor.Interfaces.Extensibility
{
    public interface IDbRepositoryExtension : IExtension
    {
        IList<IDbRepository> DbRepositories();
    }
}
