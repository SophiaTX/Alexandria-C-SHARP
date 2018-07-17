using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Alexandria.net.Messaging.Responses.DTO
{
   
    /// <summary>
    /// 
    /// </summary>
    public class AccountHistoryResponse
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
        public List<List<object>> Result { get; set; }
    }
}