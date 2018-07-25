using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the managed authority response data
    /// </summary>
    public class ManagedAuthorityResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the authoruty data 
        /// </summary>
        [JsonProperty("result")]
        public ManagedAuthoritydata Result { get; set; }
    }
}