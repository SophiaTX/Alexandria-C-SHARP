using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses
{
    public class RecieveOperation
    {
        public string fee { get; set; }
        public string sender { get; set; }
        public List<string> recipients { get; set; }
        public int app_id { get; set; }
        public string data { get; set; }
    }
}