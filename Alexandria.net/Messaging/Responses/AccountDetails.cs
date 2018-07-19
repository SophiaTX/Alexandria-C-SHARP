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
        /// the active status
        /// </summary>
        [JsonProperty("active")]
        public Active Active { get; set; }
        /// <summary>
        /// the memo key information 
        /// </summary>
        [JsonProperty("memo_key")]
        public string MemoKey { get; set; }
        /// <summary>
        /// the meta data in json format
        /// </summary>
        [JsonProperty("json_metadata")]
        public string JsonMetadata { get; set; }
        /// <summary>
        /// the voting proxy details
        /// </summary>
        [JsonProperty("voting_proxy")]
        public string VotingProxy { get; set; }
        /// <summary>
        /// the balance of the account
        /// </summary>
        [JsonProperty("balance")]
        public string Balance { get; set; }
        /// <summary>
        /// the number of vested shares on the account
        /// </summary>
        [JsonProperty("vesting_shares")]
        public string VestingShares { get; set; }
        /// <summary>
        /// the vesting withdraw rate
        /// </summary>
        [JsonProperty("vesting_withdraw_rate")]
        public string VestingWithdrawRate { get; set; }
        /// <summary>
        /// the amount to withdraw
        /// </summary>
        [JsonProperty("to_withdraw")]
        public int ToWithdraw { get; set; }
        /// <summary>
        /// the witness votes on the account
        /// </summary>
        [JsonProperty("witness_votes")]
        public List<object> WitnessVotes { get; set; }
        /// <summary>
        /// the sponsored accounts on the account
        /// </summary>
        [JsonProperty("sponsored_accounts")]
        public List<object> SponsoredAccounts { get; set; }
        /// <summary>
        /// the name of the sponsoring account
        /// </summary>
        [JsonProperty("sponsoring_account")]
        public string SponsoringAccount { get; set; }
    }
}