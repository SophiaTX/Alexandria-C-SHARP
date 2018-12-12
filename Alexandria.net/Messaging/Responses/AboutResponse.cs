using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the response to the About method call
    /// </summary>
    public class AboutResponse
    {
        public string jsonrpc { get; set; }
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the about data reponse information
        /// </summary>
        [JsonProperty("result")]
        public AboutDataResult Result { get; set; }
    }

    public class AboutDataResult
    {
        public AboutData about { get; set; }
    }
}