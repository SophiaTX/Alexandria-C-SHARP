using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the account exists reponse object
    /// </summary>
    public class AccountExistResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the boolean response whether the account exists
        /// </summary>
        [JsonProperty("result")]
        public bool Result { get; set; }
    }
}