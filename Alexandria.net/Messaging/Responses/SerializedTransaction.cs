using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// Response from the serialise transaction call
    /// </summary>
    public class SerializedTransaction
    {
        /// <summary>
        /// the response id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the result from the blockchain:: error or ok
        /// </summary>
        [JsonProperty("result")]
        public string Result { get; set; }
    }
}