using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// The Transaction Data body response from the blockchain transaction
    /// </summary>
    public class TransactionData
    {
        /// <summary>
        /// the block number
        /// </summary>
        [JsonProperty("ref_block_num")]
        public int RefBlockNum { get; set; }
        /// <summary>
        /// the prefix of the block
        /// </summary>
        [JsonProperty("ref_block_prefix")]
        public long RefBlockPrefix { get; set; }
        /// <summary>
        /// the expiration date and time of the transaction
        /// </summary>
        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }
        /// <summary>
        /// the list of the operations asscoiated with the transaction
        /// </summary>
        [JsonProperty("operations")]
        public List<List<object>> Operations { get; set; }
        /// <summary>
        /// the extensions associated with the transaction
        /// </summary>
        [JsonProperty("extensions")]
        public List<object> Extensions { get; set; }
        /// <summary>
        /// the list of the signatures assigned to the trabnsaction
        /// </summary>
        [JsonProperty("signatures")]
        public List<string> Signatures { get; set; }
        /// <summary>
        /// the identification number of the transaction
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }
        /// <summary>
        /// the block number the transaction was added to
        /// </summary>
        [JsonProperty("block_num")]
        public int BlockNum { get; set; }
        /// <summary>
        /// The transaction number in the blockchain
        /// </summary>
        [JsonProperty("transaction_num")]
        public int TransactionNum { get; set; }
    }
}