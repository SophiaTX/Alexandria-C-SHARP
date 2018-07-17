using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses.DTO
{   
    /// <summary>
    /// the list of accounts response data
    /// </summary>
    public class ListAccountsResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the response data
        /// </summary>
        [JsonProperty("result")]
        public List<string> Result { get; set; }
    }
}