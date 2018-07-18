using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    
    /// <summary>
    /// 
    /// </summary>
    public class ActiveWitnessResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("result")]
        public List<string> Result { get; set; }
    }
}