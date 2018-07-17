using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class ApplicationData
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("author")]
        public string Author { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("metadata")]
        public string Metadata { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("price_param")]
        public string PriceParam { get; set; }
    }
}