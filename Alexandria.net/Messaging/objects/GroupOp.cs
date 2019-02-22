using System.Collections.Generic;
using System.Numerics;

namespace Alexandria.net.API
{
    public class GroupOp
    {
        public int version = 1;
        public string type; //"add" "disband" "update"
        public string description;
        public string new_group_name;
        public string[] user_list;
        public string senders_pubkey;
        public Dictionary<string,string> new_key;
    }
}