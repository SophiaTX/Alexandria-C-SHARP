using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the account response 
    /// </summary>
    public class AccountResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the account response data
        /// </summary>
        [JsonProperty("result")]
        public List<object> Result { get; set; }
    }
}