using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// The account history response data
    /// </summary>
    public class AccountHistoryResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the account history results data
        /// </summary>
        [JsonProperty("result")]
        public List<List<object>> Result { get; set; }
    }
}