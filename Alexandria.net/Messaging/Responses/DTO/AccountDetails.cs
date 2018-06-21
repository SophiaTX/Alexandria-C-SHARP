using System;
using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses.DTO
{
    public class AccountDetails
    {
        public int id { get; set; }
        public string name { get; set; }
        public Owner owner { get; set; }
        public Active active { get; set; }
        public string memo_key { get; set; }
        public string json_metadata { get; set; }
        public string proxy { get; set; }
        public DateTime last_owner_update { get; set; }
        public DateTime last_account_update { get; set; }
        public DateTime created { get; set; }
        public string recovery_account { get; set; }
        public DateTime last_account_recovery { get; set; }
        public string reset_account { get; set; }
        public string balance { get; set; }
        public string vesting_shares { get; set; }
        public string vesting_withdraw_rate { get; set; }
        public DateTime next_vesting_withdrawal { get; set; }
        public int withdrawn { get; set; }
        public int to_withdraw { get; set; }
        public List<int> proxied_vsf_votes { get; set; }
        public int witnesses_voted_for { get; set; }
    }
}