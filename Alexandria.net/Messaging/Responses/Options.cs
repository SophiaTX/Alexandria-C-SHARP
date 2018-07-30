using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the options available with the transaction
    /// </summary>
    public class Options
    {
        /// <summary>
        /// the memo key value
        /// </summary>
        [JsonProperty("memo_key")]
        public string MemoKey { get; set; }
        /// <summary>
        /// the voting account address
        /// </summary>
        [JsonProperty("voting_account")]
        public string VotingAccount { get; set; }
        /// <summary>
        /// the miner number
        /// </summary>
        [JsonProperty("num_miner")]
        public int NumMiner { get; set; }
        /// <summary>
        /// the list of votes 
        /// </summary>
        [JsonProperty("votes")]
        public List<object> Votes { get; set; }
        /// <summary>
        /// the extensions associated with the options
        /// </summary>
        [JsonProperty("extensions")]
        public List<object> Extensions { get; set; }
        /// <summary>
        /// subscription allowed
        /// </summary>
        [JsonProperty("allow_subscription")]
        public bool AllowSubscription { get; set; }
        /// <summary>
        /// the price for subscribing
        /// </summary>
        [JsonProperty("price_per_subscribe")]
        public PricePerSubscribe PricePerSubscribe { get; set; }
        /// <summary>
        /// the subscription period
        /// </summary>
        [JsonProperty("subscription_period")]
        public int SubscriptionPeriod { get; set; }
    }
}