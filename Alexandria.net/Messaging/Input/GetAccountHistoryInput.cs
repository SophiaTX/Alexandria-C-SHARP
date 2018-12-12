using System;

namespace Alexandria.net.Input
{
    public class GetAccountHistoryInput
    {
        public string account { get; set; }
        public uint start { get; set; }
        public int limit { get; set; }
    }
}