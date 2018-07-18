using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    
    /// <summary>
    /// 
    /// </summary>
    public class CreateAccountResponse
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
        public List<object> Result { get; set; }
    }
}