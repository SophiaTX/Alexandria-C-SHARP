using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class RightsToPublish
    {
        /// <summary>
        /// 
        /// </summary>
        public bool is_publishing_manager { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<object> publishing_rights_received { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<object> publishing_rights_forwarded { get; set; }
    }
}