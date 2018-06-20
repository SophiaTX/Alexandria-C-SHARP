using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Receive.DTO
{
    public class ReceiveResponseResult
    {
        //{"id": "2.19.2","sender": "1.2.15","receiver": "1.2.16","method_type": 0,"transaction_id": 5,"data": "TEST1","created": "2017-10-24T16:41:50"}
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("sender")]
        public string Sender { get; set; }

        [JsonProperty("receiver")]
        public string Receiver { get; set; }

        [JsonProperty("method_type")]
        public string MethodType { get; set; }

        [JsonProperty("transaction_id")]
        public string TransId { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }
    }
}