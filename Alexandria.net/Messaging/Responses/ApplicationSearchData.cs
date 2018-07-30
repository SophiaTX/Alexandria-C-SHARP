using System;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the Application Search data
    /// </summary>
    public class ApplicationSearchData
    {
        /// <summary>
        /// the aplication search id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the application id
        /// </summary>
        [JsonProperty("app_id")]
        public int AppId { get; set; }
        /// <summary>
        /// the application buyer
        /// </summary>
        [JsonProperty("buyer")]
        public string Buyer { get; set; }
        /// <summary>
        /// the application creation date
        /// </summary>
        [JsonProperty("created")]
        public DateTime Created { get; set; }
    }
}