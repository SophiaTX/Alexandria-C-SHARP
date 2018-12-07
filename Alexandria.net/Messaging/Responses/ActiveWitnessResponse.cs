using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    public class ActiveWitnessResponseResult
    
    {   /// <summary>
        /// List of active witnesses
        /// </summary>
        [JsonProperty("active_witnesses")]
        public List<string> ActiveWitnesses { get; set; }
    }
    /// <summary>
    /// The active witness response data
    /// </summary>
    public class ActiveWitnessResponse
    {
        /// <summary>
        /// JsonRpc version
        /// </summary>
        [JsonProperty("jsonrpc")]
        public string JsonRpc { get; set; }
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the active witness response information
        /// </summary>
        [JsonProperty("result")]
        public ActiveWitnessResponseResult Result { get; set; }
    }
}