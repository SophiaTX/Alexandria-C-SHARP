using System;
using System.IO;
using System.Reflection;
using Alexandria.net.Logging;
using Alexandria.net.Settings;
using Newtonsoft.Json;

//todo - Martyn's todos
//todo - link in the send and receive
//todo - threadsafe delegate for the receive message
//todo - timeout period to be cojnfigurable :: specified in the config file


namespace Alexandria.net.Core
{
    /// <summary>
    /// The main entry point for accessing the SophiaTX Blockchain
    /// </summary>
    public class SophiaClient
    {
        #region Member Variables

        private Config _config;

        #endregion

        #region Properties

        /// <summary>
        /// The blockchain daemon
        /// </summary>
        public Daemon Daemon { get; }

        /// <summary>
        /// the blockchain wallet
        /// </summary>
        public Wallet Wallet { get; }

        #endregion

        #region Ctor

        /// <summary>
        /// Client Constructor
        /// </summary>
        /// <param name="hostname">the rpc endpoint ip address</param>
        /// <param name="daemonPort">the daemon rpc endpoint post</param>
        /// <param name="walletPort">the wallet rpc endpoint post</param>
        public SophiaClient(string hostname = "", ushort daemonPort = 0, ushort walletPort = 0)
        {
            LoadJson();
            if (_config != null)
            {
                if (hostname != "")
                    _config.Hostname = hostname;
                if (daemonPort != 0)
                    _config.DaemonPort = daemonPort;
                if (walletPort != 0)
                    _config.WalletPort = walletPort;

                Daemon = new Daemon(_config);
                Wallet = new Wallet(_config);
            }
            else
            {
                var logger = new Logger(loggingType.server, Assembly.GetExecutingAssembly().GetName().Name);
                logger.WriteError("Error with the config file");
            }
        }

        #endregion

        #region Methods

        private void LoadJson()
        {
            var filename = $"{AssemblyDirectory}/config.json";
            if (File.Exists(filename))
            {
                _config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(filename));
            }
            else
            {
                _config = new Config
                {
                    LoggingType = loggingType.file,
                    BuildMode = BuildMode.Prod,
                    Hostname = "127.0.0.1",
                    DaemonPort = 8091,
                    WalletPort = 8091,
                    Api = "/rpc",
                    Version = "2.0"
                };
                File.WriteAllText(filename, JsonConvert.SerializeObject(_config));
            }
        }

        private static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }     
        #endregion
    }
}