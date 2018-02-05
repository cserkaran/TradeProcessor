using System;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TradeProcessor.Infrastructure
{
    /// <summary>
    /// A safe catalog implementation based on
    /// https://stackoverflow.com/questions/4144683/handle-reflectiontypeloadexception-during-mef-composition
    /// to force MEF to load the plugin and figure out if there are any exports
    /// </summary>
    /// <seealso cref="System.ComponentModel.Composition.Primitives.ComposablePartCatalog" />
    public class SafeDirectoryCatalog : ComposablePartCatalog
    {
        /// <summary>
        /// The catalog
        /// </summary>
        private readonly AggregateCatalog _catalog;

        /// <summary>
        /// Initializes a new instance of the <see cref="SafeDirectoryCatalog"/> class.
        /// </summary>
        /// <param name="directory">The directory.</param>
        public SafeDirectoryCatalog(string directory)
        {
            var files = Directory.EnumerateFiles(directory, "*.dll", SearchOption.AllDirectories);

            _catalog = new AggregateCatalog();

            foreach (var file in files)
            {
                try
                {
                    var asmCat = new AssemblyCatalog(file);

                    // Force MEF to load the plugin and figure out if there are any exports
                    // good assemblies will not throw the RTLE exception and can be added to the catalog
                    if (asmCat.Parts.ToList().Count > 0)
                        _catalog.Catalogs.Add(asmCat);
                }
                catch (ReflectionTypeLoadException)
                {
                }
                catch (BadImageFormatException)
                {
                }
            }
        }

        /// <summary>
        /// Gets the part definitions that are contained in the catalog.
        /// </summary>
        public override IQueryable<ComposablePartDefinition> Parts
        {
            get { return _catalog.Parts; }
        }
    }
}
