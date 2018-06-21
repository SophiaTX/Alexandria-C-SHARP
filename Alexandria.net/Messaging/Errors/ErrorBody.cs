using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Errors
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorBody
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("data")]
        public ErrorData Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }
    }
}