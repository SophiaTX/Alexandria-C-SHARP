using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the brain key publishing rights
    /// </summary>
    public class RightsToPublish
    {
        /// <summary>
        /// the publishing manager property
        /// </summary>
        [JsonProperty("is_publishing_manager")]
        public bool IsPublishingManager { get; set; }
        /// <summary>
        /// the rights received value
        /// </summary>
        [JsonProperty("publishing_rights_received")]
        public List<object> PublishingRightsReceived { get; set; }
        /// <summary>
        /// the rights forwarded value
        /// </summary>
        [JsonProperty("publishing_rights_forwarded")]
        public List<object> PublishingRightsForwarded { get; set; }
    }
}