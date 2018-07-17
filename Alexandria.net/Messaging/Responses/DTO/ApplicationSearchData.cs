using System;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationSearchData
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("app_id")]
        public int AppId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("buyer")]
        public string Buyer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("created")]
        public DateTime Created { get; set; }
    }
}