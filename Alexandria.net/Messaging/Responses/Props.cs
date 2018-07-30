using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// Witness Properties
    /// </summary>
    public class Props
    {
        /// <summary>
        /// The account creation fee charged
        /// </summary>
        [JsonProperty("account_creation_fee")]
        public string AccountCreationFee { get; set; }
        /// <summary>
        /// the maximum block size
        /// </summary>
        [JsonProperty("maximum_block_size")]
        public int MaximumBlockSize { get; set; }
    }
}