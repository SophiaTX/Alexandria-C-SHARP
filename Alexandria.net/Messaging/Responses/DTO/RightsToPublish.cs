using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class RightsToPublish
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expiration")]
        public bool is_publishing_manager { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expiration")]
        public List<object> publishing_rights_received { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expiration")]
        public List<object> publishing_rights_forwarded { get; set; }
    }
}