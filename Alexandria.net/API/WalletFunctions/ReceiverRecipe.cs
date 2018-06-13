using System.Collections.Generic;

namespace Alexandria.net.API.WalletFunctions
{
    public class ReceiverRecipe
    {
        public ulong app_id { get; set; }
        public string sender { get; set; }
        public List<string> recipients { get; set; }
        public string binary { get; set; }
        public bool Type { get; set; }
        public string document { get; set; }
    }
}