using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the authority data for handling transactions
    /// </summary>
    public class Authority
    {
        /// <summary>
        /// the authority weighting threshold
        /// </summary>
        [JsonProperty("weight_threshold")]
        public uint WeightThreshold { get; set; }
        /// <summary>
        /// the account authorities
        /// </summary>
        [JsonProperty("account_auths")]
        public Dictionary<string, ushort> AccountAuths { get; set; }       
        /// <summary>
        /// the key authority
        /// </summary>
        [JsonProperty("key_auths")]
        public Dictionary<char[], ushort> KeyAuths { get; set; }   
    }
}