using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// teh response from the help method call
    /// </summary>
    public class HelpResponse
    {
        /// <summary>
        /// the id of the transaction
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the resultat data from the help call
        /// </summary>
        [JsonProperty("result")]
        public string Result { get; set; }
    }
}