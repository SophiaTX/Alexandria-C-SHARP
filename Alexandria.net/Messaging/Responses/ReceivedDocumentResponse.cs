using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// 
    /// </summary>
    public class ReceivedDocumentResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("result")]
        public List<List<object>> Result { get; set; }
    }
}