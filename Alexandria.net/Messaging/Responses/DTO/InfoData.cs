using System;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class InfoData
    {
        public int head_block_number { get; set; }
        public string head_block_id { get; set; }
        public DateTime time { get; set; }
        public string current_witness { get; set; }
        public string virtual_supply { get; set; }
        public string current_supply { get; set; }
        public string total_vesting_shares { get; set; }
        public string total_reward_fund { get; set; }
        public int maximum_block_size { get; set; }
        public int current_aslot { get; set; }
        public string recent_slots_filled { get; set; }
        public int participation_count { get; set; }
        public int last_irreversible_block_num { get; set; }
        public int average_block_size { get; set; }
        public string max_virtual_bandwidth { get; set; }
        public string witness_majority_version { get; set; }
        public string hardfork_version { get; set; }
        public string head_block_age { get; set; }
        public string participation { get; set; }
        public MedianSbdPrice median_sbd_price { get; set; }
        public string account_creation_fee { get; set; }
    }
}