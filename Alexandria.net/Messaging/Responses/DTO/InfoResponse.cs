using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class InfoResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("result")]
        public InfoData Result { get; set; }
    }
}