using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{   
    /// <summary>
    /// 
    /// </summary>
    public class ListAccountsResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> result { get; set; }
    }
}