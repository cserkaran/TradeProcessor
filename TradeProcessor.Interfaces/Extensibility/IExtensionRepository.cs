namespace TradeProcessor.Interfaces.Extensibility
{
    /// <summary>
    /// Interface to be implemented by MEF based extension repositories
    /// </summary>
    public interface IExtensionRepository
    {
        /// <summary>
        /// The Extension Repository will call this method on "Parts" so that parts can copy lazy loaded subparts 
        /// before the MEF container used for composition is disposed (to release memory)
        /// </summary>
        void ProcessImports();
    }
}
