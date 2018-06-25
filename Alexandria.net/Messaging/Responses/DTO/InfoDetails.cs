using System;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class MedianSbd1Price
    {
        public string @base { get; set; }
        public string quote { get; set; }
    }

    public class MedianSbd2Price
    {
        public string @base { get; set; }
        public string quote { get; set; }
    }

    public class MedianSbd3Price
    {
        public string @base { get; set; }
        public string quote { get; set; }
    }

    public class MedianSbd4Price
    {
        public string @base { get; set; }
        public string quote { get; set; }
    }

    public class MedianSbd5Price
    {
        public string @base { get; set; }
        public string quote { get; set; }
    }

    public class InfoDetails
    {
        public int head_block_number { get; set; }
        public string head_block_id { get; set; }
        public DateTime time { get; set; }
        public string current_witness { get; set; }
        public string current_supply { get; set; }
        public string total_vesting_shares { get; set; }
        public int maximum_block_size { get; set; }
        public int current_aslot { get; set; }
        public string recent_slots_filled { get; set; }
        public int participation_count { get; set; }
        public int last_irreversible_block_num { get; set; }
        public int average_block_size { get; set; }
        public string witness_majority_version { get; set; }
        public string hardfork_version { get; set; }
        public string head_block_age { get; set; }
        public string participation { get; set; }
        public MedianSbd1Price median_sbd1_price { get; set; }
        public MedianSbd2Price median_sbd2_price { get; set; }
        public MedianSbd3Price median_sbd3_price { get; set; }
        public MedianSbd4Price median_sbd4_price { get; set; }
        public MedianSbd5Price median_sbd5_price { get; set; }
        public string account_creation_fee { get; set; }
    }
}