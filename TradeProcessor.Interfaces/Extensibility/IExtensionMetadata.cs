using System;

namespace TradeProcessor.Interfaces.Extensibility
{
    /// <summary>
    /// Metadata of the extension.
    /// </summary>
    public interface IExtensionMetadata
    {
        /// <summary>
        /// Gets the target of extension
        /// </summary>
        Type ExtensionTarget { get; }

        /// <summary>
        /// Gets the name of the extension
        /// </summary>
        string Name { get; }
    }
}
