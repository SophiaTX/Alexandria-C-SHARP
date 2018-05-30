using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class RightsToPublish
    {
        public bool is_publishing_manager { get; set; }
        public List<object> publishing_rights_received { get; set; }
        public List<object> publishing_rights_forwarded { get; set; }
    }
}