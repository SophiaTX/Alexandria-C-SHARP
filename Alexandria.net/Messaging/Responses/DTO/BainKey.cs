using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class BainKey
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("brain_priv_key")]
        public string BrainPrivKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("wif_priv_key")]
        public string WifPrivKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pub_key")]
        public string PubKey { get; set; }
    }
}