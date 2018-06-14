using Alexandria.net.Communication;

namespace Alexandria.net.Core
{
    /// <summary>
    /// The main entry point for accessing the SophiaTX Blockchain
    /// </summary>
    public class SophiaClient
    {
        /// <summary>
        /// The blockchain daemon
        /// </summary>
        public Daemon Daemon { get; }
        /// <summary>
        /// the blockchain wallet
        /// </summary>
        public Wallet Wallet { get; }
        /// <summary>
        /// Client Constructor
        /// </summary>
        /// <param name="hostname">the rpc endpoint ip address</param>
        /// <param name="daemonPort">the daemon rpc endpoint post</param>
        /// <param name="walletPort">the wallet rpc endpoint post</param>
        public SophiaClient(string hostname, ushort daemonPort, ushort walletPort)
        {
            Daemon = new Daemon(hostname, daemonPort);
            Wallet = new Wallet(hostname, walletPort);
        }
        /// <summary>
        /// Client Constructor
        /// </summary>
        public SophiaClient()
        {
            Daemon = new Daemon();
            Wallet = new Wallet();
        }
    }
}