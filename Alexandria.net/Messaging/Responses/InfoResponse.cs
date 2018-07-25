using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the Info response from the Info method call
    /// </summary>
    public class InfoResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the results of the info request
        /// </summary>
        [JsonProperty("result")]
        public InfoData Result { get; set; }
    }
}