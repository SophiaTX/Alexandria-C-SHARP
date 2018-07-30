using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the response data for the GetOperationsInBlock method
    /// </summary>
    public class GetOperationsResponse
    {
        /// <summary>
        /// the tyransaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the operations data result
        /// </summary>
        [JsonProperty("result")]
        public List<Operations> Result { get; set; }
    }
}