using System;
using System.IO;
using System.Reflection;
using Alexandria.net.Enums;
using Alexandria.net.Logging;
using Alexandria.net.Settings;
using Newtonsoft.Json;

namespace Alexandria.net.Core
{
    /// <summary>
    /// The main entry point for accessing the SophiaTX Blockchain
    /// </summary>
    public class SophiaClient
    {
        #region Properties

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
            var config = LoadJson<Config>("config.json");
            var blockchainConfig = LoadJson<BlockchainConfig>("blockchainconfig.json");
            if (config != null)
            {
                if (hostname != "")
                    config.Hostname = hostname;
                if (daemonPort != 0)
                    config.DaemonPort = daemonPort;
                if (walletPort != 0)
                    config.WalletPort = walletPort;

                //Daemon = new Daemon(_config);
                Wallet = new Wallet(config, blockchainConfig);
            }
            else
            {
                var logger = new Logger(LoggingType.Server, Assembly.GetExecutingAssembly().GetName().Name);
                logger.WriteError("Error with the config file");
            }
        }

        #endregion

        #region Methods

        private static T LoadJson<T>(string filename)
        {
            try
            {
                var fullfilename = $"{AssemblyDirectory}/{filename}";
                if (File.Exists(fullfilename))
                {
                    return JsonConvert.DeserializeObject<T>(File.ReadAllText(fullfilename));
                }

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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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