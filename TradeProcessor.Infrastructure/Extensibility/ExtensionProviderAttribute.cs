using System;
using System.ComponentModel.Composition;
using TradeProcessor.Interfaces.Extensibility;

namespace TradeProcessor.Infrastructure.Extensibility
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ExtensionProviderAttribute : ExportAttribute, IExtensionMetadata
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the extension</param>
        /// <param name="stage">Stage / Domain of the extension</param>
        /// <param name="participant">Participant that this extension belongs to</param>
        /// <param name="extensionTarget">Extenion target type</param>
        public ExtensionProviderAttribute(string name,  Type extensionTarget)
            : base(typeof(IExtensionProvider))
        {
            Name = name;
            ExtensionTarget = extensionTarget;
        }

        /// <summary>
        /// Gets the target of extension
        /// </summary>
        public Type ExtensionTarget { get; private set; }

        /// <summary>
        /// Gets the name of the extension
        /// </summary>
        public string Name { get; private set; }
    }
}
