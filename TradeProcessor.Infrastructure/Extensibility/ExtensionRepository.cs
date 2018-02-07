using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using TradeProcessor.Interfaces.Extensibility;

namespace TradeProcessor.Infrastructure.Extensibility
{
    /// <summary>
    /// Repository of extensions loaded by the platform.
    /// </summary>
    /// <seealso cref="TradeProcessor.Interfaces.Extensibility.IExtensionRepository" />
    [Export(typeof(IExtensionRepository))]
    public sealed class ExtensionRepository : IExtensionRepository
    {
        [ImportMany(typeof(IExtensionProvider))]
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private List<Lazy<IExtensionProvider, IExtensionMetadata>> importedExtensionProviders = new List<Lazy<IExtensionProvider, IExtensionMetadata>>();

        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        private List<Tuple<IExtensionProvider, IExtensionMetadata>> loadedExtensions =
            new List<Tuple<IExtensionProvider, IExtensionMetadata>>();

        /// <summary>
        /// The Extension Repository will call this method on "Parts" so that parts can copy lazy loaded subparts 
        /// before the MEF container used for composition is disposed (to release memory)
        /// </summary>
        void IExtensionRepository.ProcessImports()
        {
            if (importedExtensionProviders != null)
            {
                foreach (var extensionProvider in importedExtensionProviders)
                {
                    this.loadedExtensions.Add(
                        new Tuple<IExtensionProvider, IExtensionMetadata>(
                            extensionProvider.Value,
                            extensionProvider.Metadata));
                }
            }
        }

        /// <summary>
        /// Gets an instance of extensions
        /// </summary>
        /// <typeparam name="T">Type of extension expected</typeparam>
        /// <param name="extensionTarget">taget type</param>
        /// <returns>List of extensions</returns>
        public IList<T> GetExtension<T>(Type extensionTarget) where T : class
        {
            var providers = this.loadedExtensions.Where(i => i.Item2.ExtensionTarget == extensionTarget);
            var list = providers.Select(tuple => tuple.Item1.GetExtension() as T).ToList();
            list.RemoveAll(e => e == null);
            return list;
        }
    }
}
