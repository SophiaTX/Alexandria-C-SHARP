namespace Alexandria.net.Messaging.Receiver
{
    /// <summary>
    /// Price quote structure
    /// </summary>
    public class PrizeFeedQuoteMessage
    {
        /// <summary>
        /// Currency symbol
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Price feed depending on the currency symbol
        /// </summary>
        public PrizeFeedQuote PrizeFeedQuote { get; set; }
    }
}