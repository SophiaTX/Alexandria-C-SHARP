using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Receiver
{
    /// <summary>
    /// the price feed quote object
    /// </summary>
    public class PrizeFeedQuote
    {
        /// <summary>
        /// the base price
        /// </summary>
        [JsonProperty("base")]
        public string Base { get; set; }

        /// <summary>
        /// the quote price
        /// </summary>
        [JsonProperty("quote")]
        public string Quote { get; set; }
    }
}