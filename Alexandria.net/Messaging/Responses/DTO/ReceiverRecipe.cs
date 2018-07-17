using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class ReceiverRecipe
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expiration")]
        public ulong AppId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expiration")]
        public string Sender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expiration")]
        public List<string> Recipients { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expiration")]
        public string Binary { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expiration")]
        public bool Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expiration")]
        public string Document { get; set; }
    }
}