namespace Alexandria.net.Messaging.Receiver
{
    public class PrizeFeedQuoteMessage
    {
        public string Currency { get; set; }

        public PrizeFeedQuote PrizeFeedQuote { get; set; }
    }
}