using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// The active witness response data
    /// </summary>
    public class ActiveWitnessResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the active witness response information
        /// </summary>
        [JsonProperty("result")]
        public List<string> Result { get; set; }
    }
}