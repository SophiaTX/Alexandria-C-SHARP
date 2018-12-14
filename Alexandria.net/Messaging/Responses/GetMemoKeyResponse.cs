using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    public class MemoResult
    {
        public string memo_key { get; set; }
    }

    /// <summary>
    /// the memo key response data
    /// </summary>
    public class GetMemoKeyResponse
    {
        public string jsonrpc { get; set; }
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the string result of the memo key
        /// </summary>
        [JsonProperty("result")]
        public string MemoResult { get; set; }
    }
}