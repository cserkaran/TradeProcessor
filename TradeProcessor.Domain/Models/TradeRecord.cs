namespace TradeProcessor.Domain.Models
{
    /// <summary>
    /// The TradeRecord Domain model.
    /// </summary>
    public class TradeRecord
    {
        /// <summary>
        /// Gets or sets the source currency.
        /// </summary>
        /// <value>
        /// The source currency.
        /// </value>
        public string SourceCurrency { get; set; }

        /// <summary>
        /// Gets or sets the destination currency.
        /// </summary>
        /// <value>
        /// The destination currency.
        /// </value>
        public string DestinationCurrency { get; set; }

        /// <summary>
        /// Gets or sets the lots.
        /// </summary>
        /// <value>
        /// The lots.
        /// </value>
        public float Lots { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }
    }
}
