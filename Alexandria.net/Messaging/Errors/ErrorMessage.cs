using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Errors
{
    public class ErrorMessage
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("error")]
        public ErrorBody Error { get; set; }
    }
}