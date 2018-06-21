using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Receiver.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class ReceiveResponseResult
    {
        //{"id": "2.19.2","sender": "1.2.15","receiver": "1.2.16","method_type": 0,"transaction_id": 5,"data": "TEST1","created": "2017-10-24T16:41:50"}
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sender")]
        public string Sender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("receiver")]
        public string Receiver { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("method_type")]
        public string MethodType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("created")]
        public string Created { get; set; }
    }
}