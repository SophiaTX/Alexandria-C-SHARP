using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// The respoinse data for the GetWithness call
    /// </summary>
    public class GetWitnessResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the witness details
        /// </summary>
        [JsonProperty("result")]
        public WitnessDetails Result { get; set; }
    }
}