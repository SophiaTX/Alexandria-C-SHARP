using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the response data for the GetOperationsInBlock method
    /// </summary>
    public class GetOperationsResponse
    {
        public string jsonrpc { get; set; }
        /// <summary>
        /// the tyransaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the operations data result
        /// </summary>
        [JsonProperty("result")]
        public GetOperationResult Result { get; set; }
    }
    public class GetOperationResult
    {
        public List<object> ops_in_block { get; set; }
    }
    
}