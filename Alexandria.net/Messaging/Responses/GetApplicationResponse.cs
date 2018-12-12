using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    public class GetAppResult
    {
        public List<ApplicationData> applications { get; set; }
    }
    /// <summary>
    /// the response data from the GetApplication method call
    /// </summary>
    public class GetApplicationResponse
    {
        public string jsonrpc { get; set; }
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the application data returned from the call
        /// </summary>
        [JsonProperty("result")]
        public GetAppResult Result { get; set; }
    }
}