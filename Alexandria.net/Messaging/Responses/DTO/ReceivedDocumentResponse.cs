using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class ReceivedDocumentResponse
    {
        [JsonProperty("expiration")]
        public int id { get; set; }
        [JsonProperty("expiration")]
        public List<List<object>> result { get; set; }
    }
}