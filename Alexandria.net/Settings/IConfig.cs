using Alexandria.net.Enums;
using Alexandria.net.Logging;

namespace Alexandria.net.Settings
{
    /// <summary>
    /// IConfig
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// BuildMode
        /// </summary>
        BuildMode BuildMode { get; set; }
        /// <summary>
        /// Logging Type
        /// </summary>
        LoggingType LoggingType { get; set; }
        /// <summary>
        /// Receive Interval
        /// </summary>
        int ReceiveInterval { get; set; }
        /// <summary>
        /// Host name 
        /// </summary>
        string Hostname { get; set; }
        /// <summary>
        /// Daemon Port
        /// </summary>
        ushort DaemonPort { get; set; }
        /// <summary>
        /// Wallet Port
        /// </summary>
        ushort WalletPort { get; set; }
        /// <summary>
        /// Api
        /// </summary>
        string Api { get; set; }
        /// <summary>
        /// Version
        /// </summary>
        string Version { get; set; }
    }
}