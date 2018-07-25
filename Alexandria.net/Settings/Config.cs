using Alexandria.net.Enums;
using Alexandria.net.Logging;

namespace Alexandria.net.Settings
{
    /// <summary>
    /// Configuraton object for the build mode, the logging type and the endpoints
    /// </summary>
    public class Config : IConfig
    {
        #region Member Variables
        /// <summary>
        /// The buildmode: Prod is standard and should be used always,
        /// Test should be set when the addon is presented for testing
        /// before release and used to confirm with Sophia 
        /// </summary>
        public BuildMode BuildMode { get; set; }
        /// <summary>
        /// The logging type which will be used
        /// </summary>
        public LoggingType LoggingType { get; set; }
        /// <summary>
        /// the ip address and port of the logging server
        /// </summary>
        public string LoggingServer { get; set; }
        /// <summary>
        /// The receiver interval (ms) for checking for new transactions
        /// </summary>
        public int ReceiveInterval { get; set; }
        /// <summary>
        /// The connection hostname to connect to the blockchain
        /// </summary>
        public string Hostname { get; set; }
        /// <summary>
        /// the daemon port number
        /// </summary>
        public ushort DaemonPort { get; set; }
        /// <summary>
        /// the wallet port number
        /// </summary>
        public ushort WalletPort { get; set; }
        /// <summary>
        /// the rpc api string
        /// </summary>
        public string Api { get; set; }
        /// <summary>
        /// the json version
        /// </summary>
        public string Version { get; set; }

        #endregion
    }
}