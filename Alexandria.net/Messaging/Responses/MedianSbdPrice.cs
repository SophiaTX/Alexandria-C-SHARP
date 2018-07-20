using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// gives the median of the currency (sbd)
    /// </summary>
    public class MedianSbdPrice
    {
        /// <summary>
        /// the currency symbol
        /// </summary>
        [JsonProperty("base")]
        public string Base { get; set; }
        /// <summary>
        /// the data of the sbd
        /// </summary>
        [JsonProperty("quote")]
        public string Quote { get; set; }
    }
}