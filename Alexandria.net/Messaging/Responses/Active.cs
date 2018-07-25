using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the active data related to the brain key
    /// </summary>
    public class Active
    {
        /// <summary>
        /// the weight threshold associated with tht brain key
        /// </summary>
        [JsonProperty("weight_threshold")]
        public int WeightThreshold { get; set; }
        /// <summary>
        /// the account authorisations associated with the brain key
        /// </summary>
        [JsonProperty("account_auths")]
        public List<object> AccountAuths { get; set; }
        /// <summary>
        /// the key authourisations associated with the brain key
        /// </summary>
        [JsonProperty("key_auths")]
        public List<List<object>> KeyAuths { get; set; }
    }
}