using System;
using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class TransactionData
    {
        public int ref_block_num { get; set; }
        public long ref_block_prefix { get; set; }
        public DateTime expiration { get; set; }
        public List<List<object>> operations { get; set; }
        public List<object> extensions { get; set; }
        public List<string> signatures { get; set; }
        public string transaction_id { get; set; }
        public int block_num { get; set; }
        public int transaction_num { get; set; }
    }
}