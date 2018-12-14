using System.Collections.Generic;

namespace Alexandria.net.Input
{
    public class AuthorityInput
    {
        public List<string> pub_keys { get; set; }
        public ulong required_signatures { get; set; }
    }
}