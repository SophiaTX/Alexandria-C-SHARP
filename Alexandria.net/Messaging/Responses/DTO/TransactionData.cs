using System;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses.DTO
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
        [JsonProperty("ref_block_num")]
        public long ref_block_prefix { get; set; }
        /// <summary>
        /// the expiration date and time of the transaction
        /// </summary>
        [JsonProperty("ref_block_num")]
        public DateTime expiration { get; set; }
        /// <summary>
        /// the list of the operations asscoiated with the transaction
        /// </summary>
        [JsonProperty("ref_block_num")]
        public List<List<object>> operations { get; set; }
        /// <summary>
        /// the extensions associated with the transaction
        /// </summary>
        [JsonProperty("ref_block_num")]
        public List<object> extensions { get; set; }
        /// <summary>
        /// the list of the signatures assigned to the trabnsaction
        /// </summary>
        [JsonProperty("signatures")]
        public List<string> signatures { get; set; }
        /// <summary>
        /// the identification number of the transaction
        /// </summary>
        [JsonProperty("transaction_id")]
        public string transaction_id { get; set; }
        /// <summary>
        /// the block number the transaction was added to
        /// </summary>
        [JsonProperty("block_num")]
        public int block_num { get; set; }
        /// <summary>
        /// The transaction number in the blockchain
        /// </summary>
        [JsonProperty("transaction_num")]
        public int transaction_num { get; set; }
    }
}