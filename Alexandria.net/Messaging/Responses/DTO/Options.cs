using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class Options
    {
        /// <summary>
        /// 
        /// </summary>
        public string memo_key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string voting_account { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int num_miner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<object> votes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<object> extensions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool allow_subscription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public PricePerSubscribe price_per_subscribe { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int subscription_period { get; set; }
    }
}