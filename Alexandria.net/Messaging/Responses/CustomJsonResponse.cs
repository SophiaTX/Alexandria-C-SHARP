using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// response data for the MakeCustomJsonOperation method call
    /// </summary>
    public class CustomJsonResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the transction results
        /// </summary>
        [JsonProperty("result")]
        public List<object> Result { get; set; }
    }
}


//{"id":0,"result":["custom_json",{"fee":"0.000000 SPHTX","sender":"test103","recipients":["test101"],"app_id":1,"json":"the quick brown fox jumped over something..."}]}