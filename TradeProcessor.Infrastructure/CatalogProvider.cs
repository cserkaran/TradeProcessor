using System.IO;

namespace TradeProcessor.Infrastructure
{
    /// <summary>
    /// Provider catalog for MEF
    /// </summary>
    public class CatalogProvider
    {

        /// <summary>
        /// Gets the<see cref="SafeDirectoryCatalog"/>.
        /// </summary>
        /// <value>
        /// The directory catalog.
        /// </value>
        public static SafeDirectoryCatalog DirectoryCatalog
        {
            get
            {
                // load mef extensions from the current application execution directory.
                var catalog = new SafeDirectoryCatalog(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
                return catalog;
            }
        }
    }
}
