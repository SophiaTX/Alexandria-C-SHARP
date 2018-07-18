using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Errors
{
    /// <summary>
    /// Error details
    /// </summary>
    public class ErrorData
    {
        /// <summary>
        /// Error code
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// Error name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Error stack trace
        /// </summary>
        [JsonProperty("stack")]
        public string Stack { get; set; }
    }
}