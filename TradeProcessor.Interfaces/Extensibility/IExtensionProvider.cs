namespace TradeProcessor.Interfaces.Extensibility
{
    public interface IExtensionProvider
    {
        /// <summary>
        /// Gets an instance of the extension
        /// </summary>
        /// <returns></returns>
        IExtension GetExtension();
    }
}
