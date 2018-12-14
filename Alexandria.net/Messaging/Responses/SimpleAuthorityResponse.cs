using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    public class AuthorityResponse
    {
        public SimpleAuthorityData active_authority { get; set; }
    }
    /// <summary>
    /// the authority data response
    /// </summary>
    public class SimpleAuthorityResponse
    {
        public string jsonrpc { get; set; }
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// tghe authority result data
        /// </summary>
        [JsonProperty("result")]
        public AuthorityResponse Result { get; set; }
    }
}