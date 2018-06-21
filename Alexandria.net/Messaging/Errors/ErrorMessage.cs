using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Errors
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorMessage
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("error")]
        public ErrorBody Error { get; set; }
    }
}