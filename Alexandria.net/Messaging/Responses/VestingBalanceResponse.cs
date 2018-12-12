using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    public class VestingResult
    {
        public int vesting_balance { get; set; }
    }
    /// <summary>
    /// the vesting balance response
    /// </summary>
    public class VestingBalanceResponse
    {
        public string jsonrpc { get; set; }
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the amount in vesting
        /// </summary>
        [JsonProperty("result")]
        public VestingResult Result { get; set; }
    }
}