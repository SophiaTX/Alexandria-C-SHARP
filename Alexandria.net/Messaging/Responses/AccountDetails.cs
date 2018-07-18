using System.Collections.Generic;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// 
    /// </summary>
    public class AccountDetails
    {
        /// <summary>
        /// the id of the transaction
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        /// <summary>
        /// the account name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// the account owner
        /// </summary>
        [JsonProperty("owner")]
        public Owner Owner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("active")]
        public Active Active { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("memo_key")]
        public string MemoKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("json_metadata")]
        public string JsonMetadata { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("voting_proxy")]
        public string VotingProxy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("balance")]
        public string Balance { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("vesting_shares")]
        public string VestingShares { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("vesting_withdraw_rate")]
        public string VestingWithdrawRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("to_withdraw")]
        public int ToWithdraw { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("witness_votes")]
        public List<object> WitnessVotes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sponsored_accounts")]
        public List<object> SponsoredAccounts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sponsoring_account")]
        public string SponsoringAccount { get; set; }
    }
}