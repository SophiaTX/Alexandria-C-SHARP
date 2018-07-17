using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class Active
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("weight_threshold")]
        public int WeightThreshold { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_auths")]
        public List<object> AccountAuths { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("key_auths")]
        public List<List<object>> KeyAuths { get; set; }
    }
}