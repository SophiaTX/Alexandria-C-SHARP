using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the response data from the GetApplication method call
    /// </summary>
    public class GetApplicationResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the application data returned from the call
        /// </summary>
        [JsonProperty("result")]
        public List<ApplicationData> Result { get; set; }
    }
}