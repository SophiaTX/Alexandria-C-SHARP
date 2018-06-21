using System.Collections.Generic;
using Alexandria.net.Messaging.Receive.DTO;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Receiver.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class ReceiveDataResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("result")]
        public List<ReceiveResponseResult> Result { get; set; }
    }
}