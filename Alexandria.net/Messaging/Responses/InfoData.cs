using System;
using Newtonsoft.Json;

namespace Alexandria.net.Messaging.Responses
{
    /// <summary>
    /// The data response from the Info method
    /// </summary>
    public class InfoData
    {
        /// <summary>
        /// the head block number
        /// </summary>
        [JsonProperty("head_block_number")]
        public int HeadBlockNumber { get; set; }
        /// <summary>
        /// the head block id
        /// </summary>
        [JsonProperty("head_block_id")]
        public string HeadBlockId { get; set; }
        /// <summary>
        /// the time of the info call
        /// </summary>
        [JsonProperty("time")]
        public DateTime Time { get; set; }
        /// <summary>
        /// the name of the current witness of the current block
        /// </summary>
        [JsonProperty("current_witness")]
        public string CurrentWitness { get; set; }
        /// <summary>
        /// the virtual supply
        /// </summary>
        [JsonProperty("virtual_supply")]
        public string VirtualSupply { get; set; }
        /// <summary>
        /// the actual supply
        /// </summary>
        [JsonProperty("current_supply")]
        public string CurrentSupply { get; set; }
        /// <summary>
        /// the number of total tokens in vesting
        /// </summary>
        [JsonProperty("total_vesting_shares")]
        public string TotalVestingShares { get; set; }
        /// <summary>
        /// the total reward fund
        /// </summary>
        [JsonProperty("total_reward_fund")]
        public string TotalRewardFund { get; set; }
        /// <summary>
        /// the maximum block size
        /// </summary>
        [JsonProperty("maximum_block_size")]
        public int MaximumBlockSize { get; set; }
        /// <summary>
        /// the current slot number
        /// </summary>
        [JsonProperty("current_aslot")]
        public int CurrentAslot { get; set; }
        /// <summary>
        /// the number of recent slots filled
        /// </summary>
        [JsonProperty("recent_slots_filled")]
        public string RecentSlotsFilled { get; set; }
        /// <summary>
        /// the participant count
        /// </summary>
        [JsonProperty("participation_count")]
        public int ParticipationCount { get; set; }
        /// <summary>
        /// the last irresiverible block number
        /// </summary>
        [JsonProperty("last_irreversible_block_num")]
        public int LastIrreversibleBlockNum { get; set; }
        /// <summary>
        /// the average size of all blocks
        /// </summary>
        [JsonProperty("expiration")]
        public int AverageBlockSize { get; set; }
        /// <summary>
        /// the virtual bandwidth availability
        /// </summary>
        [JsonProperty("average_block_size")]
        public string MaxVirtualBandwidth { get; set; }
        /// <summary>
        /// the version of the witness majority
        /// </summary>
        [JsonProperty("witness_majority_version")]
        public string WitnessMajorityVersion { get; set; }
        /// <summary>
        /// the hardfork version number
        /// </summary>
        [JsonProperty("hardfork_version")]
        public string HardforkVersion { get; set; }
        /// <summary>
        /// the age of the head block
        /// </summary>
        [JsonProperty("head_block_age")]
        public string HeadBlockAge { get; set; }
        /// <summary>
        /// the participation value
        /// </summary>
        [JsonProperty("participation")]
        public string Participation { get; set; }
        /// <summary>
        /// gives the median of the currency (sbd)
        /// </summary>
        [JsonProperty("median_sbd_price")]
        public MedianSbdPrice MedianSbdPrice { get; set; }
        /// <summary>
        /// the fee associated with account creation
        /// </summary>
        [JsonProperty("account_creation_fee")]
        public string AccountCreationFee { get; set; }
    }
}