using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Receiver
{
    //todo - finalise object description
    /// <summary>
    ///
    /// </summary>
    public class PrizeFeedQuote
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("base")]
        public string Base { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("quote")]
        public string Quote { get; set; }
    }
}