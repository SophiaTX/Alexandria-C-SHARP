using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class FeedData
    {
        public int id { get; set; }
        public CurrentMedianHistory current_median_history { get; set; }
        public List<object> price_history { get; set; }
    }
}