using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the vesting balance response
    /// </summary>
    public class VestingBalanceResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the amount in vesting
        /// </summary>
        [JsonProperty("result")]
        public int Result { get; set; }
    }
}