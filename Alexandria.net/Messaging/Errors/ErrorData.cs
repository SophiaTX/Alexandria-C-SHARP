using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Errors
{
    public class ErrorData
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("stack")]
        public string Stack { get; set; }
    }
}