using Alexandria.net.Enums;
using Alexandria.net.Logging;

namespace Alexandria.net.Settings
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// The buildmode: Prod is standard and should be used always,
        /// Test should be set when the addon is presented for testing
        /// before release and used to confirm with Sophia 
        /// </summary>
        BuildMode BuildMode { get; set; }
        /// <summary>
        /// The logging type which will be used
        /// </summary>
        LoggingType LoggingType { get; set; }
        /// <summary>
        /// the ip address and port of the logging server
        /// </summary>
        string LoggingServer { get; set; }
        /// <summary>
        /// The receiver interval (ms) for checking for new transactions
        /// </summary>
        int ReceiveInterval { get; set; }
        /// <summary>
        /// The connection hostname to connect to the blockchain
        /// </summary>
        string Hostname { get; set; }
        /// <summary>
        /// the daemon port number
        /// </summary>
        ushort DaemonPort { get; set; }
        /// <summary>
        /// the wallet port number
        /// </summary>
        ushort WalletPort { get; set; }
        /// <summary>
        /// the rpc api string
        /// </summary>
        string Api { get; set; }
        /// <summary>
        /// the json version
        /// </summary>
        string Version { get; set; }
    }
}