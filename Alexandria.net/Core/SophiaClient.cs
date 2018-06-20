using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Alexandria.net.Enums;
using Alexandria.net.Logging;
using Alexandria.net.Settings;
using Newtonsoft.Json;

//todo - link in the send and receive
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
        private BlockchainConfig _blockchainConfig;

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
            _config = LoadJson<Config>("config.json");
            _blockchainConfig = LoadJson<BlockchainConfig>("blockchainconfig.json");
            if (_config != null)
            {
                if (hostname != "")
                    _config.Hostname = hostname;
                if (daemonPort != 0)
                    _config.DaemonPort = daemonPort;
                if (walletPort != 0)
                    _config.WalletPort = walletPort;

                Daemon = new Daemon(_config);
                Wallet = new Wallet(_config, _blockchainConfig);
            }
            else
            {
                var logger = new Logger(LoggingType.Server, Assembly.GetExecutingAssembly().GetName().Name);
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
                    LoggingType = LoggingType.File,
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

        private T LoadJson<T>(string filename)
        {
            var fullfilename = $"{AssemblyDirectory}/{filename}";
            if (File.Exists(fullfilename))
            {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(fullfilename));
            }
            else
            {
                if (typeof(T) == typeof(Config))
                {
                    var config = new Config
                    {
                        LoggingType = LoggingType.File,
                        BuildMode = BuildMode.Prod,
                        Hostname = "195.48.9.208",
                        DaemonPort = 8095,
                        WalletPort = 8096,
                        Api = "/rpc",
                        Version = "2.0"
                    };
                    File.WriteAllText(fullfilename, JsonConvert.SerializeObject(config));
                }
                else if (typeof(T) == typeof(BlockchainConfig))
                {
                    var blockchainconfig = new BlockchainConfig
                    {
                        Account = AccountOwner.Sender,
                        Index = 0,
                        IsoTimeStamp = DateTime.UtcNow,
                        SearchType = SearchType.BySender,
                        Start = StartBy.Index
                    };
                    File.WriteAllText(fullfilename, JsonConvert.SerializeObject(blockchainconfig));
                }
            }

            return default(T);
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