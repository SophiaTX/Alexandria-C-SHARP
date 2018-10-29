using System;
using System.Collections.Generic;

namespace Alexandria.net.Messaging.Responses
{
    public class Result
    {
        public List<object> serials { get; set; }
        public string holder { get; set; }
        public string new_holder { get; set; }
        public List<object> history_items { get; set; }
        public string meta { get; set; }
        public string info { get; set; }
        public DateTime change_date { get; set; }
    }

    public class DaemonResponse
    {
        public string jsonrpc { get; set; }
        public Result result { get; set; }
        public int id { get; set; }
    }
}