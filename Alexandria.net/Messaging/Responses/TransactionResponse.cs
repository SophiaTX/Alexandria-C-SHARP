using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// The Transaction Response passed back from the blockchain
    /// </summary>
    public class TransactionResponse
    {
        /// <summary>
        /// the response id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the resulting transaction data sent back from the blockchain
        /// </summary>
        [JsonProperty("result")]
        public TransactionData Result { get; set; }
    }

    
}