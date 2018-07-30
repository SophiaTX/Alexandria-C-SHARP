using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// The price for subscription
    /// </summary>
    public class PricePerSubscribe
    {
        /// <summary>
        /// the amount for the subscription
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }
        /// <summary>
        /// the id of the asset
        /// </summary>
        [JsonProperty("asset_id")]
        public string AssetId { get; set; }
    }
}