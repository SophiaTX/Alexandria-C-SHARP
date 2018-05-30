using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Receive.DTO
{
    public class ReceiveDataResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("result")]
        public List<ReceiveResponseResult> Result { get; set; }
    }
}