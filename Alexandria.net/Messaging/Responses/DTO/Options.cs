using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class Options
    {
        public string memo_key { get; set; }
        public string voting_account { get; set; }
        public int num_miner { get; set; }
        public List<object> votes { get; set; }
        public List<object> extensions { get; set; }
        public bool allow_subscription { get; set; }
        public PricePerSubscribe price_per_subscribe { get; set; }
        public int subscription_period { get; set; }
    }
}