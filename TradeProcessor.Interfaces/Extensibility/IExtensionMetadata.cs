using System;

namespace TradeProcessor.Interfaces.Extensibility
{
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
