using System;
using Alexandria.net.Enums;

namespace Alexandria.net.Input
{
    public class ListDocsInput
    {
        public ulong app_id { get; set; }
        public string account_name { get; set; }
        public SearchType search_type { get; set; }
        public DateTime start { get; set; }
        public uint count { get; set; }
    }
}