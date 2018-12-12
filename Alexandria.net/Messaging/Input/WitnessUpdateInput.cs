using Alexandria.net.Messaging.Receiver;
using Alexandria.net.Messaging.Responses;

namespace Alexandria.net.Input
{
    public class WitnessUpdateInput
    {
        public string witness_account_name { get; set; }
        public string url { get; set; }
        public string block_signing_key { get; set; }
        public ChainProperties props { get; set; }
    }
}