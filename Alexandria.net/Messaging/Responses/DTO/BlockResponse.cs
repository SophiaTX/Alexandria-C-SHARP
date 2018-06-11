using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class BlockResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("result")]
        public BlockData Result { get; set; }
    }
}