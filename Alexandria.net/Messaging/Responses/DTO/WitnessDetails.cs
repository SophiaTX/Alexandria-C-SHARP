using System;
using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class Props
    {
        public string account_creation_fee { get; set; }
        public int maximum_block_size { get; set; }
    }

    public class WitnessDetails
    {
        public int id { get; set; }
        public string owner { get; set; }
        public DateTime created { get; set; }
        public string url { get; set; }
        public int votes { get; set; }
        public string virtual_last_update { get; set; }
        public string virtual_position { get; set; }
        public string virtual_scheduled_time { get; set; }
        public int total_missed { get; set; }
        public int last_aslot { get; set; }
        public int last_confirmed_block_num { get; set; }
        public string signing_key { get; set; }
        public Props props { get; set; }
        public List<object> submitted_exchange_rates { get; set; }
        public string running_version { get; set; }
        public string hardfork_version_vote { get; set; }
        public DateTime hardfork_time_vote { get; set; }
    }
}