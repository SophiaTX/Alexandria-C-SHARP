using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    public class AccountResponseResult
    {
        public List<object> op { get; set; }
    }
    /// <summary>
    /// the account response 
    /// </summary>
    public class AccountResponse
    {
        public string jsonrpc { get; set; }
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the account response data
        /// </summary>
        [JsonProperty("result")]
        public AccountResponseResult Result { get; set; }
    }
}