using System;
using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses
{
    public class ReceiveDocResultData
    {               
        public int id { get; set; }
        public string sender { get; set; }
        public List<string> recipients { get; set; }
        public int app_id { get; set; }
        public string data { get; set; }
        public DateTime received { get; set; }
        public bool binary { get; set; }
    
}
}