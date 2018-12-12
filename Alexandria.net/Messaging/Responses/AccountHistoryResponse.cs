using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// The account history response data
    /// </summary>
    public class AccountHistoryResponse
    {
        public string jsonrpc { get; set; }
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the account history results data
        /// </summary>
        [JsonProperty("result")]
        public HistoryResult Result { get; set; }
    }

    public class HistoryResult
    {
        public List<object> account_history { get; set; }
    }
}