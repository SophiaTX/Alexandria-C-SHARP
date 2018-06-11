using System;
using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class BlockData
    {
        public string previous { get; set; }
        public DateTime timestamp { get; set; }
        public string witness { get; set; }
        public string transaction_merkle_root { get; set; }
        public List<object> extensions { get; set; }
        public string witness_signature { get; set; }
        public List<object> transactions { get; set; }
        public string block_id { get; set; }
        public string signing_key { get; set; }
        public List<object> transaction_ids { get; set; }
    }
}