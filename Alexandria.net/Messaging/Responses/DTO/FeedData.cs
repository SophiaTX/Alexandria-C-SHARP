using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class FeedData
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CurrentMedianHistory current_median_history { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<object> price_history { get; set; }
    }
}