using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// 
    /// </summary>
    public class BrainKeySuggestionData
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("registrar")]
        public string Registrar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("owner")]
        public Owner Owner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("active")]
        public Active Active { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("options")]
        public Options Options { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("rights_to_publish")]
        public RightsToPublish RightsToPublish { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("statistics")]
        public string Statistics { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("top_n_control_flags")]
        public int TopNControlFlags { get; set; }
    }
}