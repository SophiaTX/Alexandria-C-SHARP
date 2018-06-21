using System;
using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class SignedTransactionResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public int ref_block_num { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long ref_block_prefix { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime expiration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<List<object>> operations { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<object> extensions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> signatures { get; set; }
    }
}