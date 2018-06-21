using System;
using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class SignedTransactionResponse
    {
        public int ref_block_num { get; set; }
        public long ref_block_prefix { get; set; }
        public DateTime expiration { get; set; }
        public List<List<object>> operations { get; set; }
        public List<object> extensions { get; set; }
        public List<string> signatures { get; set; }
    }
}