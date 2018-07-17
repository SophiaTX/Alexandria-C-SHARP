using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class Authority
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("weight_threshold")]
        public uint WeightThreshold { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("account_auths")]
        public Dictionary<string, ushort> AccountAuths { get; set; }       
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("key_auths")]
        public Dictionary<char[], ushort> KeyAuths { get; set; }   
    }
}