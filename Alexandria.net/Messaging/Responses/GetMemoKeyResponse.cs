using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the memo key response data
    /// </summary>
    public class GetMemoKeyResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the string result of the memo key
        /// </summary>
        [JsonProperty("result")]
        public string Result { get; set; }
    }
}