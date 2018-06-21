using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
   
    /// <summary>
    /// 
    /// </summary>
    public class AccountHistoryResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<List<object>> result { get; set; }
    }
}