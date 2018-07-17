using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class AccountResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("resulty")]
        public List<object> Result { get; set; }
    }
}