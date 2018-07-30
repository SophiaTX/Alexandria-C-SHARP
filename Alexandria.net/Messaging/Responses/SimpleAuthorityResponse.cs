using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the authority data response
    /// </summary>
    public class SimpleAuthorityResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// tghe authority result data
        /// </summary>
        [JsonProperty("result")]
        public SimpleAuthorityData Result { get; set; }
    }
}