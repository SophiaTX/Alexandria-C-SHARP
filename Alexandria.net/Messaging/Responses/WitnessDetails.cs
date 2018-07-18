using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// the witness details passed in the Witness Response
    /// </summary>
    public class WitnessDetails
    {
        /// <summary>
        /// the witness details id
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the witness owner, the account who created or updated the witness
        /// </summary>
        [JsonProperty("owner")]
        public string Owner { get; set; }
        /// <summary>
        /// the witness created datetime
        /// </summary>
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        /// <summary>
        /// the witness url
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
        /// <summary>
        /// the number of votes 
        /// </summary>
        [JsonProperty("votes")]
        public int Votes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("virtual_last_update")]
        public string VirtualLastUpdate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("virtual_position")]
        public string VirtualPosition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("virtual_scheduled_time")]
        public string VirtualScheduledTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("total_missed")]
        public int TotalMissed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("last_aslot")]
        public int LastAslot { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("last_confirmed_block_num")]
        public int LastConfirmedBlockNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("signing_key")]
        public string SigningKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("props")]
        public Props Props { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("submitted_exchange_rates")]
        public List<object> SubmittedExchangeRates { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("running_version")]
        public string RunningVersion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hardfork_version_vote")]
        public string HardforkVersionVote { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("hardfork_time_vote")]
        public DateTime HardforkTimeVote { get; set; }
    }
}