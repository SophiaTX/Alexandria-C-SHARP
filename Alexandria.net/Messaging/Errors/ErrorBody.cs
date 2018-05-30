using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Errors
{
    public class ErrorBody
    {
        [JsonProperty("data")]
        public ErrorData Data { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }
    }
}