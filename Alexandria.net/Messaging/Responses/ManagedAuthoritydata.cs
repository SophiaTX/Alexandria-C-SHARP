using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the mamnaged authority data
    /// </summary>
    public class ManagedAuthoritydata
    {
        /// <summary>
        /// the weight threshold 
        /// </summary>
        [JsonProperty("weight_threshold")]
        public int WeightThreshold { get; set; }
        /// <summary>
        /// the account authority
        /// </summary>
        [JsonProperty("account_auths")]
        public List<List<object>> AccountAuths { get; set; }
        /// <summary>
        /// the key authorities
        /// </summary>
        [JsonProperty("key_auths")]
        public List<object> KeyAuths { get; set; }
    }
}