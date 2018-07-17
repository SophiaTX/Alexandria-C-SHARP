using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses.DTO
{
    
    /// <summary>
    /// 
    /// </summary>
    public class CurrentMedianHistory
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("base")]
        public string Base { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("quote")]
        public string Quote { get; set; }
    }
}
//jkjkjk