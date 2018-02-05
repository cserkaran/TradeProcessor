using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeProcessor.Infrastructure
{
    /// <summary>
    /// A Service Hub at platform level to do System level initializations and 
    /// provide a single global access to multiple other services e.g. Logging Service 
    /// can be made part of this hub.
    /// A single instance of this exists throughout the app.
    /// </summary>
    public class PlatformServiceHub
    {
        /// <summary>
        /// The lazy object for singleton pattern.
        /// </summary>
        private static readonly Lazy<PlatformServiceHub> LazyObject =
          new Lazy<PlatformServiceHub>(() => new PlatformServiceHub());

        /// <summary>
        /// The singleton instance of PlatformServiceHub
        /// </summary>
        public static PlatformServiceHub Instance
        {
            get
            {
                return LazyObject.Value;
            }
        }

        /// <summary>
        /// Private constructor for singleton pattern
        /// </summary>
        private PlatformServiceHub()
        {

        }

        public void Initialize()
        {
            //ExtensionRepository.Instance.Load(root);
        }
    }
}
