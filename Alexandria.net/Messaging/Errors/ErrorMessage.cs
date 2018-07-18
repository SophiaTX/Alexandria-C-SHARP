using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Errors
{
    /// <summary>
    /// Error result details
    /// </summary>
    public class ErrorMessage
    {
        /// <summary>
        /// result id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// error body
        /// </summary>
        [JsonProperty("error")]
        public ErrorBody Error { get; set; }
    }
}