using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses.DTO
{
    /// <summary>
    /// the lock and unlock response data
    /// </summary>
    public class LockUnlockRequestResponse
    {
        /// <summary>
        /// the lock / unlock reponse
        /// </summary>
        [JsonProperty("response")]
        public LockUnlockResponse Response { get; set; }
        /// <summary>
        /// the request which was made
        /// </summary>
        [JsonProperty("request")]
        public string Request { get; set; }
    }
}