using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class BlockResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("result")]
        public BlockData Result { get; set; }
    }
}