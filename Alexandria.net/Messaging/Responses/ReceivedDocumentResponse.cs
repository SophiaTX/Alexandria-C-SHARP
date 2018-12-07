using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    public class ReceivedDocumentResponse
    {
        public string jsonrpc { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("result")]
        public ReceiveDocResultData Result { get; set; }
        public int id { get; set; }
    }
}