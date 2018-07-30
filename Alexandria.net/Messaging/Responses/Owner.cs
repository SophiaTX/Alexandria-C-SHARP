using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// The owner details
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// the weighting threshold of the owner
        /// </summary>
        [JsonProperty("weight_threshold")]
        public int WeightThreshold { get; set; }
        /// <summary>
        /// the account authority
        /// </summary>
        [JsonProperty("account_auths")]
        public List<object> AccountAuths { get; set; }
        /// <summary>
        /// the key authtorisations
        /// </summary>
        [JsonProperty("key_auths")]
        public List<List<object>> KeyAuths { get; set; }
    }
}