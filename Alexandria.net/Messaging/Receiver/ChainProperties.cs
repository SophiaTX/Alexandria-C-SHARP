using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Receiver
{
    /// <summary>
    /// This fee, paid in SPHTX, is converted into VESTING SHARES for the new account. Accounts
    /// without vesting shares cannot earn usage rations and therefore are powerless. This minimum
    /// fee requires all accounts to have some kind of commitment to the network that includes the
    /// ability to vote and make transactions
    /// </summary>
    public class ChainProperties
    {
        /// <summary>
        /// the creation fee that was offered in SPHTX
        /// </summary>
        [JsonProperty("account_creation_fee")]
        public string AccountCreationFee { get; set; }
        /// <summary>
        /// the last block in the chain
        /// </summary>
        [JsonProperty("maximum_block_size")]
        public int MaximumBlockSize { get; set; }
        /// <summary>
        /// The price feed information
        /// </summary>
        [JsonProperty("price_feeds")]
        public List<List<PrizeFeedQuoteMessage>> PriceFeeds { get; set; }
    }
}