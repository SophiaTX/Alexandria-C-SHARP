using System.Collections.Generic;

namespace Alexandria.net.Input
{
    public class MakeCustomBinaryInput
    {
        public ulong app_id { get; set; }
        public string from { get; set; }
        public List<string> to { get; set; }
        public string data { get; set; }
    }
}