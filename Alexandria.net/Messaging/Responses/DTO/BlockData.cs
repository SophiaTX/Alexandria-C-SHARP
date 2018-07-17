using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class BlockData
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("previous")]
        public string Previous { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("witness")]
        public string Witness { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("transaction_merkle_root")]
        public string TransactionMerkleRoot { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("extensions")]
        public List<object> Extensions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("witness_signature")]
        public string WitnessSignature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("transactions")]
        public List<object> Transactions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("block_id")]
        public string BlockId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("signing_key")]
        public string SigningKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("transaction_ids")]
        public List<object> TransactionIds { get; set; }
    }
}