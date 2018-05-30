using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class Account
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("result")]
        public Result AccountDetails { get; set; }
    }
}