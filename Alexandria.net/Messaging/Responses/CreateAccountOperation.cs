using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses
{
    
    public class CreateAccountOperation
    {
        public string fee { get; set; }
        public string creator { get; set; }
        public string name_seed { get; set; }
        public Owner owner { get; set; }
        public Active active { get; set; }
        public string memo_key { get; set; }
        public string json_metadata { get; set; }
    }
}