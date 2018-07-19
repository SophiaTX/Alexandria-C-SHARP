using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the application search data response
    /// </summary>
    public class ApplicationSearchResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the application search data
        /// </summary>
        [JsonProperty("result")]
        public List<ApplicationSearchData> Result { get; set; }
    }
    
}