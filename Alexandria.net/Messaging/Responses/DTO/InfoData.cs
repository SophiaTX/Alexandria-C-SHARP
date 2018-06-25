using System;

namespace Alexandria.net.Messaging.Responses.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class InfoData
    {
        /// <summary>
        /// 
        /// </summary>
        public int head_block_number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string head_block_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string current_witness { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string virtual_supply { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string current_supply { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string total_vesting_shares { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string total_reward_fund { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int maximum_block_size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int current_aslot { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string recent_slots_filled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int participation_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int last_irreversible_block_num { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int average_block_size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string max_virtual_bandwidth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string witness_majority_version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hardfork_version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string head_block_age { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string participation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MedianSbdPrice median_sbd_price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string account_creation_fee { get; set; }
    }
}