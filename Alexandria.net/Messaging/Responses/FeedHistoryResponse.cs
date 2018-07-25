using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the response to the GetFeedHistory nmethod call
    /// </summary>
    public class FeedHistoryResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the feed data information
        /// </summary>
        [JsonProperty("result")]
        public FeedData Result { get; set; }
    }
}