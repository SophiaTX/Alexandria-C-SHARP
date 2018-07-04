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
        public string voting_proxy { get; set; }
        public string balance { get; set; }
        public string vesting_shares { get; set; }
        public string vesting_withdraw_rate { get; set; }
        public int to_withdraw { get; set; }
        public List<object> witness_votes { get; set; }
        public List<object> sponsored_accounts { get; set; }
        public string sponsoring_account { get; set; }
    }
}