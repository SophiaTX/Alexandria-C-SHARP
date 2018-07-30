using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the brain key suggest data
    /// </summary>
    public class BrainKeySuggestionData
    {
        /// <summary>
        /// the brain key suggestion id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// the brain key registrar
        /// </summary>
        [JsonProperty("registrar")]
        public string Registrar { get; set; }
        /// <summary>
        /// the brain key name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// the brain key owner
        /// </summary>
        [JsonProperty("owner")]
        public Owner Owner { get; set; }
        /// <summary>
        /// the brian key active status
        /// </summary>
        [JsonProperty("active")]
        public Active Active { get; set; }
        /// <summary>
        /// the brain key options
        /// </summary>
        [JsonProperty("options")]
        public Options Options { get; set; }
        /// <summary>
        /// the rights to publish status
        /// </summary>
        [JsonProperty("rights_to_publish")]
        public RightsToPublish RightsToPublish { get; set; }
        /// <summary>
        /// the statistics properties
        /// </summary>
        [JsonProperty("statistics")]
        public string Statistics { get; set; }
        /// <summary>
        /// the control flags of the brain key
        /// </summary>
        [JsonProperty("top_n_control_flags")]
        public int TopNControlFlags { get; set; }
    }
}