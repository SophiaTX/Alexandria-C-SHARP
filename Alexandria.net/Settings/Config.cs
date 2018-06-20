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
        /// 
        /// </summary>
        public int ReceiveInterval { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Hostname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ushort DaemonPort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ushort WalletPort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Api { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Version { get; set; }

        #endregion
    }
}