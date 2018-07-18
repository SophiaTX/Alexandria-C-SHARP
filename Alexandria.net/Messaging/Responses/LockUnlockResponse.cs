using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// The wallet lock and unlock response
    /// </summary>
    public class LockUnlockResponse
    {
        /// <summary>
        /// the Id of the call
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// the result passed back from the blockchain
        /// </summary>
        [JsonProperty("Result")]
        public string Result { get; set; }
    }
}