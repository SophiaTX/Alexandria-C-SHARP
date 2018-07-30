using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the authority response 
    /// </summary>
    public class CreateSimpleAuthorityResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the Authority data response
        /// </summary>
        [JsonProperty("result")]
        public CreateSimpleAuthorityData Result { get; set; }
    }
}