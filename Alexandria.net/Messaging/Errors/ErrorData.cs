using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Errors
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorData
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("stack")]
        public string Stack { get; set; }
    }
}