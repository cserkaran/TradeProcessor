namespace TradeProcessor.Interfaces.Extensibility
{
    /// <summary>
    /// Provide a new Extension instance everytime when requested.
    /// </summary>
    public interface IExtensionProvider
    {
        /// <summary>
        /// Gets an instance of the extension
        /// </summary>
        /// <returns></returns>
        IExtension GetExtension();
    }
}
