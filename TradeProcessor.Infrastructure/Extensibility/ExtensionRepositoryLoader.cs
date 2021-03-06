﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using TradeProcessor.Interfaces.Extensibility;

namespace TradeProcessor.Infrastructure
{
    /// <summary>
    /// Load of <see cref="IExtensionRepository"/> extensions
    /// </summary>
    public class ExtensionRepositoryLoader
    {
        private static readonly Lazy<ExtensionRepositoryLoader> LazyInstance =
            new Lazy<ExtensionRepositoryLoader>(() => new ExtensionRepositoryLoader());

        /// <summary>
        /// Property used for MEF imports
        /// </summary>
        [ImportMany]
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        private List<IExtensionRepository> Parts { get; set; }

        /// <summary>
        /// Indicates whether the repository has been loaded or not
        /// </summary>
        private bool isLoaded;

        /// <summary>
        /// Private constructor for singleton pattern
        /// </summary>
        private ExtensionRepositoryLoader()
        {
        }

        /// <summary>
        /// Gets an instance of the extension repository
        /// </summary>
        public static ExtensionRepositoryLoader Instance
        {
            get
            {
                return LazyInstance.Value;
            }
        }

        /// <summary>
        /// Loads the extensions
        /// </summary>
        public void Load()
        {
            if (isLoaded)
            {
                return;
            }


            var catalog = CatalogProvider.DirectoryCatalog;
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            isLoaded = true;
            ProcessImports();
            container.Dispose();

        }

        /// <summary>
        /// Retreives an instance of given type of inner Repository
        /// </summary>
        /// <typeparam name="T">Type of repository</typeparam>
        /// <returns>Inner repository if it exists else null</returns>
        public T GetInnerRepository<T>()
        {
            if (this.Parts != null)
            {
                return Parts.OfType<T>().FirstOrDefault();
            }

            return default(T);
        }

        private void ProcessImports()
        {
            if (Parts != null)
            {
                foreach (var part in Parts)
                {
                    part.ProcessImports();
                }
            }
        }
    }
}
