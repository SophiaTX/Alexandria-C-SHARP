using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    
    public class SeedResult
    {
        public string account_name { get; set; }
    }
    /// <summary>
    /// the account name from seed response object
    /// </summary>
    public class AccountNameFromSeedResponse
    {
        public string jsonrpc { get; set; }
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the account name results data
        /// </summary>
        [JsonProperty("result")]
        public SeedResult Result { get; set; }
    }
}