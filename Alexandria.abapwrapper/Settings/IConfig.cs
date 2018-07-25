using Alexandria.abapwrapper.Enums;
using Alexandria.abapwrapper.Logging;

namespace Alexandria.net.Settings
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// 
        /// </summary>
        BuildMode BuildMode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        LoggingType LoggingType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        int ReceiveInterval { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string Hostname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        ushort DaemonPort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        ushort WalletPort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string Api { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string Version { get; set; }
    }
}