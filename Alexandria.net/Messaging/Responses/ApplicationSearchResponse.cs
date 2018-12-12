using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the application search data response
    /// </summary>
    public class ApplicationSearchResponse
    {
        public string jsonrpc { get; set; }
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the application search data
        /// </summary>
        [JsonProperty("result")]
        public AppResult Result { get; set; }
    }

    public class AppResult
    {
        public List<ApplicationSearchData> application_buyings { get; set; }
    }
}