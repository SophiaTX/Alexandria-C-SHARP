using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Alexandria.net.API;
using Alexandria.net.Communication;
using Alexandria.net.Enums;
using Alexandria.net.Events;
using Alexandria.net.Logging;
using Alexandria.net.Mapping;
using Alexandria.net.Settings;
using Newtonsoft.Json;
using Serilog;
using Serilog.Sinks.Graylog;
using Serilog.Sinks.Graylog.Core;

namespace Alexandria.net.Core
{
    /// <summary>
    /// The main entry point for accessing the SophiaTX Blockchain
    /// </summary>
    public class SophiaClient
    {
        #region Member Variables
        /// <summary>
        /// The RPC Connection for sending and receiving information from the blockchain
        /// </summary>
        public static RpcConnection RpcConnection;
        #endregion
        
        #region Properties

        /// <summary>
        /// Sophia Blockchain Account functions
        /// </summary>
        public Account Account { get; }
        /// <summary>
        /// Sophia Blockchain Asset functions
        /// </summary>
        public Asset Asset { get; }
        /// <summary>
        /// Sophia Blockchain Key functions
        /// </summary>
        public Key Key { get; }
        /// <summary>
        /// Sophia Blockchain Transaction functions
        /// </summary>
        public Transaction Transaction { get; }
        /// <summary>
        /// Sophia Blockchain Witness functions
        /// </summary>
        public Witness Witness { get; }
		
        /// <summary>
        /// Sophia Blockchain Data functions
        /// </summary>
        public Data Data { get; }
        /// <summary>
        /// Sophia Blockchain Application functions
        /// </summary>
        public Application Application { get; }
        

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

            var methodMapper = LoadJson<List<MethodMapper>>("MethodMapper.json");
            
            if (config == null) return;
            if (hostname != "")
                config.Hostname = hostname;
            if (daemonPort != 0)
                config.DaemonPort = daemonPort;
            if (walletPort != 0)
                config.WalletPort = walletPort;

            Account = new Account(config, methodMapper);
            Asset = new Asset(config, methodMapper);
            Key = new Key(config, methodMapper);
            Transaction = new Transaction(config, methodMapper);
            Witness = new Witness(config, methodMapper);
            Data = new Data(config, methodMapper);
            Application = new Application(config, methodMapper);

            RpcConnection = new RpcConnection(config);
        }

        #endregion
        
        #region EventHandlers

        /// <summary>   Event queue for all listeners interested in accountCreated events. </summary>
        public event DataReceivedEventHandler OnDataReceivedBlockChainEvent
        {
            add => Data.OnDataReceivedBlockChainEvent += value;
            remove => Data.OnDataReceivedBlockChainEvent -= value;
        }

        #endregion

        #region Methods

        private static T LoadJson<T>(string filename)
        {
            try
            {
                var fullFilename = $"{AssemblyDirectory}/{filename}";
                if (File.Exists(fullFilename))
                {
                    return JsonConvert.DeserializeObject<T>(File.ReadAllText(fullFilename));
                }
                
                if (typeof(T) == typeof(Config))
                {                   
                    var config = new Config
                    {
                        LoggingType = LoggingType.Server,
                        LoggingServer = "http://logging.sophiatx.com",
                        LoggingPort = 12205,
                        BuildMode = BuildMode.Prod,
                        Hostname = "34.244.93.54",
                        DaemonPort = 9195,
                        WalletPort = 9195,
                        Api = "/rpc",
                        Version = "2.0",
                        DaemonEndpoint="http://stagenet.sophiatx.com:9193"
                    };
                    File.WriteAllText(fullFilename, JsonConvert.SerializeObject(config));
                    return (T) Convert.ChangeType(config, typeof(T));
                }
                else if (typeof(T) == typeof(BlockchainConfig))
                {
                    var blockChainConfig = new BlockchainConfig
                    {
                        Account = AccountOwner.Sender,
                        Index = 0,
                        IsoTimeStamp = DateTime.UtcNow,
                        SearchType = SearchType.BySender,
                        Start = StartBy.Index
                    };
                    File.WriteAllText(fullFilename, JsonConvert.SerializeObject(blockChainConfig));
                    return (T) Convert.ChangeType(blockChainConfig, typeof(T));
                }
                else if (typeof(T) == typeof(List<MethodMapper>))
                {
                    var mm = new MethodMapperCollection();
                    
                    var coll = mm.BuildMethodMapperJson(fullFilename);
                    
                    return (T) Convert.ChangeType(coll, typeof(T));
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