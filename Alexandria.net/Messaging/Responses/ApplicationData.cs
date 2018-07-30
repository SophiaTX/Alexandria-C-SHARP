using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// The application data 
    /// </summary>
    public class ApplicationData
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the application name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// the application author
        /// </summary>
        [JsonProperty("author")]
        public string Author { get; set; }
        /// <summary>
        /// the application url
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// the application metadata
        /// </summary>
        [JsonProperty("metadata")]
        public string Metadata { get; set; }
        /// <summary>
        /// the applicatiopn price parameter
        /// </summary>
        [JsonProperty("price_param")]
        public string PriceParam { get; set; }
    }
}