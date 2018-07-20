using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the data reposnse from the GetAccount method call
    /// </summary>
    public class GetAccountResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the account details result data
        /// </summary>
        [JsonProperty("result")]
        public AccountDetails Result { get; set; }
    }
}