using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// The operations data
    /// </summary>
    public class Operations
    {
        /// <summary>
        /// The transaction id
        /// </summary>
        [JsonProperty("trx_id")]
        public string TrxId { get; set; }
        /// <summary>
        /// the number of the block
        /// </summary>
        [JsonProperty("block")]
        public int Block { get; set; }
        /// <summary>
        /// the number of transactions in the block
        /// </summary>
        [JsonProperty("trx_in_block")]
        public int TrxInBlock { get; set; }
        /// <summary>
        /// the number of operations in the transaction
        /// </summary>
        [JsonProperty("op_in_trx")]
        public int OpInTrx { get; set; }
        /// <summary>
        /// the virtual operation id
        /// </summary>
        [JsonProperty("virtual_op")]
        public int VirtualOp { get; set; }
        /// <summary>
        /// the timestamp of the operation
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// the list of operations
        /// </summary>
        [JsonProperty("op")]
        public List<object> Op { get; set; }
        /// <summary>
        /// the operation fee payer 
        /// </summary>
        [JsonProperty("fee_payer")]
        public string FeePayer { get; set; }
    }
}