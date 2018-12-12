using System.Collections.Generic;

namespace Alexandria.net.Input
{
    public class MakeCustomJsonInput
    {
        public uint app_id { get; set; }
        public string from { get; set; }
        public List<string> to { get; set; }
        public string json { get; set; }
    }
}