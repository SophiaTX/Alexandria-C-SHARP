using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the block response
    /// </summary>
    public class BlockResponse
    {
        /// <summary>
        /// the transaction id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the block data object
        /// </summary>
        [JsonProperty("result")]
        public BlockData Result { get; set; }
    }
}