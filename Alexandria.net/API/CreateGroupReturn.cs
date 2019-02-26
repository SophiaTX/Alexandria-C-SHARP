using System.Collections.Generic;

namespace Alexandria.net.API
{
    public class CreateGroupReturn
    {
        public string group_name;
        public IEnumerable<Dictionary<string,GroupMeta>> operation_payloads;
    }
}