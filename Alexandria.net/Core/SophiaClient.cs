using Alexandria.net.Communication;

namespace Alexandria.net.Core
{
    public class SophiaClient
    {
        public Daemon Daemon { get; set; }
        public Wallet Wallet { get; set; }
        public SphTxWebsocket WebSocket { get; set; }

        public SophiaClient(string hostname, ushort daemonPort, ushort walletPort)
        {
            Daemon = new Daemon(hostname, daemonPort);
            Wallet = new Wallet(hostname, walletPort);
        }

        public SophiaClient()
        {
            Daemon = new Daemon();
            Wallet = new Wallet();
            WebSocket = new SphTxWebsocket();
        }
    }
}