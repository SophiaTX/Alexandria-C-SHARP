using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Errors
{
    /// <summary>
    /// Error detail body
    /// </summary>
    public class ErrorBody
    {
        /// <summary>
        /// Error details
        /// </summary>
        [JsonProperty("data")]
        public ErrorData Data { get; set; }

        /// <summary>
        /// Error code
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }
    }
}