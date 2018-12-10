using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Alexandria.net.Enums;
using Alexandria.net.Exceptions;
using Alexandria.net.Extensions;
using Alexandria.net.Settings;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Graylog;
using Serilog.Sinks.Graylog.Core;


namespace Alexandria.net.Communication
{
    /// <summary>
    /// Sealed Class which manages the sending and receiving of data to and from the blockchain
    /// </summary>
    public sealed class RpcConnection
    {
        #region Variables

        private int _requestId;
        private readonly string _uri;
        private static HttpClient _client;
        private readonly string _jsonRpc;
        private readonly BuildMode _buildMode;
        private static IConfig _config;
        #endregion

        #region Constructors

        /// <summary>
        /// RPCConnection Constructor
        /// </summary>
        /// <param name="config">the Configuration parameters for the endpoint and ports</param>
        /// <param name="wallet">true if configuring for the wallet</param>
        public RpcConnection(IConfig config, bool wallet = true)
        {
            _config = config;
            _uri = $"http://{_config.Hostname}:{(wallet ? _config.WalletPort : config.DaemonPort)}{config.Api}";
            var hch = new HttpClientHandler {Proxy = null, UseProxy = false};
            _client = new HttpClient(hch);
            _jsonRpc = _config.Version;
            _buildMode = _config.BuildMode;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Processes the request and gets the response from the server
        /// </summary>
        /// <param name="methodName">the method name to call</param>
        /// <param name="parameters"></param>
        /// <param name="type"></param>
        /// <returns>the http response from the server</returns>
        public async Task<string> ProcessRequest(string methodName, object parameters, Type type = null)
        {          
            var response = string.Empty;
            var request = new
            {
                jsonrpc = _jsonRpc,
                id = GetRequestId(),
                method = methodName,
                @params = new {parameters}
            };

            var json = JsonConvert.SerializeObject(request).GetJsonString(type);
             
            var httpResponse = _client.PostAsync(_uri, new StringContent(json, Encoding.UTF8)).Result;

            if (httpResponse == null) return response;
            response = await httpResponse.Content.ReadAsStringAsync();

            if (!response.Contains("error")) return response;
            if (_buildMode != BuildMode.Test) throw new SophiaBlockchainException(response);
            var uri = new Uri(_config.LoggingServer);
            var hostname = uri.Host;
            var loggerConfig = new LoggerConfiguration().WriteTo.Graylog(new GraylogSinkOptions
            {
                                
                HostnameOrAddress = hostname,
                Port = _config.LoggingPort

            }).CreateLogger();
            loggerConfig.Write(LogEventLevel.Error, response);

            throw new SophiaBlockchainException(response);

        }
        
        /// <summary>
        /// Processes the request and gets the response from the server
        /// </summary>
        /// <param name="methodName">the method name to call</param>
        /// <param name="params">the parameters to pass with the method</param>
        /// <param name="type"></param>
        /// <returns>the http response from the server</returns>
        public async Task<string> ProcessRequestOnDaemon(string methodName,  object @params , Type type = null)
        {          

            var response = string.Empty;
            var request = new
            {
                jsonrpc = _jsonRpc,
                id = GetRequestId(),
                method = methodName,
                @params = @params ?? new object()
            };

            var json = JsonConvert.SerializeObject(request).GetJsonString(type);
             
            var httpResponse = _client.PostAsync(_config.DaemonEndpoint, new StringContent(json, Encoding.UTF8)).Result;

            if (httpResponse == null) return response;
            response = await httpResponse.Content.ReadAsStringAsync();

            if (response.Contains("error"))
            {
                if (_buildMode != BuildMode.Test) throw new SophiaBlockchainException(response);
                var loggerConfig = new LoggerConfiguration().WriteTo.Graylog(new GraylogSinkOptions
                {
                    HostnameOrAddress = _config.LoggingServer,
                    Port = _config.LoggingPort
                                     
                }).CreateLogger();
           
                loggerConfig.Write(LogEventLevel.Error,response);
                throw new SophiaBlockchainException(response); 
            }

            return response;
        }
        
        
        private int GetRequestId()
        {
            return _requestId++;
        }

        #endregion
    }  
}