using System;
using System.Collections.Generic;

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
        public string previous { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime timestamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string witness { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string transaction_merkle_root { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<object> extensions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string witness_signature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<object> transactions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string block_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string signing_key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<object> transaction_ids { get; set; }
    }
}