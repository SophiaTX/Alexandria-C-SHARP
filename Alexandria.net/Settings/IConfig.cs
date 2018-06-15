using Alexandria.net.Logging;

namespace Alexandria.net.Settings
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConfig
    {
        BuildMode BuildMode { get; set; }
        loggingType LoggingType { get; set; }
        int ReceiveInterval { get; set; }
        string Hostname { get; set; }
        ushort DaemonPort { get; set; }
        ushort WalletPort { get; set; }
        string Api { get; set; }
        string Version { get; set; }
    }
}