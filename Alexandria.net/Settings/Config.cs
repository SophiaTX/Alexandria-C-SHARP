using System.IO;
using Alexandria.net.Logging;
using Newtonsoft.Json;

namespace Alexandria.net.Settings
{
    public class Config : IConfig
    {
        #region Member Variables
        /// <summary>
        /// 
        /// </summary>
        public BuildMode BuildMode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public loggingType LoggingType { get; set; }
        public int ReceiveInterval { get; set; }
        public string Hostname { get; set; }
        public ushort DaemonPort { get; set; }
        public ushort WalletPort { get; set; }
        public string Api { get; set; }
        public string Version { get; set; }

        #endregion
    }
}