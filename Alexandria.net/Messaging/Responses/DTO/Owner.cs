using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// 
        /// </summary>
        public int weight_threshold { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<object> account_auths { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<List<object>> key_auths { get; set; }
    }
}