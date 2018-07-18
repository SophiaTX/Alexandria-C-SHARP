using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class ManagedAuthoritydata
    {
        public int weight_threshold { get; set; }
        public List<List<object>> account_auths { get; set; }
        public List<object> key_auths { get; set; }
    }
}