using System.Collections.Generic;

namespace TradeProcessor.Interfaces.Extensibility
{
    /// <summary>
    /// Extension interface to inject multiple database repositories.
    /// Database repositories follow Repository pattern.
    /// </summary>
    /// <seealso cref="TradeProcessor.Interfaces.Extensibility.IExtension" />
    public interface IDbRepositoryExtension : IExtension
    {
        /// <summary>
        /// The list of Database Repositories.
        /// </summary>
        /// <returns>The list of Database Repositories</returns>
        IList<IDbRepository> DbRepositories();
    }
}
