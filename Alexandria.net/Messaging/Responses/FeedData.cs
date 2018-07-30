using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// The feed data return in the getfeed response
    /// </summary>
    public class FeedData
    {
        /// <summary>
        /// the transdaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the median history data
        /// </summary>
        [JsonProperty("current_median_history")]
        public CurrentMedianHistory CurrentMedianHistory { get; set; }
        /// <summary>
        /// the price history data
        /// </summary>
        [JsonProperty("price_history")]
        public List<object> PriceHistory { get; set; }
    }
}