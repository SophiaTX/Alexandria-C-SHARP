using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the brain key suggestion object
    /// </summary>
    public class BrainKeySuggestion
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the brain key suggestion data
        /// </summary>
        [JsonProperty("result")]
        public BrainKeySuggestionData Result { get; set; }
    }
}