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
        [JsonProperty("is_publishing_manager")]
        public bool IsPublishingManager { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("publishing_rights_received")]
        public List<object> PublishingRightsReceived { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("publishing_rights_forwarded")]
        public List<object> PublishingRightsForwarded { get; set; }
    }
}