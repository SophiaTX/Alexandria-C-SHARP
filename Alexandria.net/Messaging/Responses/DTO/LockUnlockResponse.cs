using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class LockUnlockResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("Result")]
        public string Result { get; set; }

        //{"id":1,"result":false}
    }
}