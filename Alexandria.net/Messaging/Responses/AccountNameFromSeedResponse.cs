using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the account name from seed response object
    /// </summary>
    public class AccountNameFromSeedResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the account name results data
        /// </summary>
        [JsonProperty("result")]
        public string Result { get; set; }
    }
}