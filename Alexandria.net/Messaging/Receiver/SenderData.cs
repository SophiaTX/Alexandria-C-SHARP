using System.Collections.Generic;
using Alexandria.net.Enums;

namespace Alexandria.net.API.WalletFunctions
{
    public class SenderData
    {
        public string Sender { get; set; }
        public List<string> Recipients { get; set; }
        public ulong AppId { get; set; }
        public string Document { get; set; }
        public List<char> DocumentChars { get; set; }
        public string PrivateKey { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}