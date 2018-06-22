using System;
using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class Operations
    {
        public string trx_id { get; set; }
        public int block { get; set; }
        public int trx_in_block { get; set; }
        public int op_in_trx { get; set; }
        public int virtual_op { get; set; }
        public DateTime timestamp { get; set; }
        public List<object> op { get; set; }
        public string fee_payer { get; set; }
    }
}