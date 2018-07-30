using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the feed data median history data
    /// </summary>
    public class CurrentMedianHistory
    {
        /// <summary>
        /// the base value
        /// </summary>
        [JsonProperty("base")]
        public string Base { get; set; }
        /// <summary>
        /// the quote value
        /// </summary>
        [JsonProperty("quote")]
        public string Quote { get; set; }
    }
}
