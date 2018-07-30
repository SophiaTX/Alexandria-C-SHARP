using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the block data object
    /// </summary>
    public class BlockData
    {
        /// <summary>
        /// the previous block number
        /// </summary>
        [JsonProperty("previous")]
        public string Previous { get; set; }
        /// <summary>
        /// the block timestamp
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// the witness of the block
        /// </summary>
        [JsonProperty("witness")]
        public string Witness { get; set; }
        /// <summary>
        /// the merkle root of the transaction
        /// </summary>
        [JsonProperty("transaction_merkle_root")]
        public string TransactionMerkleRoot { get; set; }
        /// <summary>
        /// the block data extensions
        /// </summary>
        [JsonProperty("extensions")]
        public List<string> Extensions { get; set; }
        /// <summary>
        /// the block witness signature
        /// </summary>
        [JsonProperty("witness_signature")]
        public string WitnessSignature { get; set; }
        /// <summary>
        /// the list of transactions in the block
        /// </summary>
        [JsonProperty("transactions")]
        public List<object> Transactions { get; set; }
        /// <summary>
        /// the block id
        /// </summary>
        [JsonProperty("block_id")]
        public string BlockId { get; set; }
        /// <summary>
        /// the block signing key
        /// </summary>
        [JsonProperty("signing_key")]
        public string SigningKey { get; set; }
        /// <summary>
        /// the block trabnsaction ids
        /// </summary>
        [JsonProperty("transaction_ids")]
        public List<object> TransactionIds { get; set; }
    }
}