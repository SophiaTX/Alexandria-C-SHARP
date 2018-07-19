using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the authority data related to the authority response
    /// </summary>
    public class CreateSimpleAuthorityData
    {
        /// <summary>
        /// the weighting threshold of the authority
        /// </summary>
        [JsonProperty("weight_threshold")]
        public int WeightThreshold { get; set; }
        /// <summary>
        /// the account authorisation of the authority
        /// </summary>
        [JsonProperty("account_auths")]
        public List<object> AccountAuths { get; set; }
        /// <summary>
        /// the key authorisations of the authority
        /// </summary>
        [JsonProperty("key_auths")]
        public List<List<object>> KeyAuths { get; set; }
    }
}