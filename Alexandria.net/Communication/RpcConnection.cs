 using System;
 using System.Collections;
using System.Net.Http;
 using System.Reflection;
 using System.Text;
using System.Threading.Tasks;
 using Alexandria.net.Logging;
 using Alexandria.net.Mapping;
 using Alexandria.net.Settings;
 using Newtonsoft.Json;

namespace Alexandria.net.Communication
{
    /// <summary>
    /// Abstract Class which manages the sending and receiving of data to and from the blockchain
    /// </summary>
    public abstract class RpcConnection
    {
        #region Variables
        private int _requestId;
        private readonly string _uri;
        private readonly HttpClient _client;
        private readonly string _jsonRpc;
        protected readonly CSharpToCPP CSharpToCpp = new CSharpToCPP();
        private readonly ILogger _logger;
        private readonly BuildMode _buildMode;
        #endregion

        #region Properties

        protected IConfig Config { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// RPCConnection Constructor
        /// </summary>
        /// <param name="config"></param>
        protected RpcConnection(IConfig config, bool Wallet = true)
        {
            Config = config;
            _uri = string.Format("http://{0}:{1}{2}", Config.Hostname, Wallet ? Config.WalletPort : config.DaemonPort,
                config.Api);
            _client = new HttpClient();
            _jsonRpc = Config.Version;

            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(loggingType.server, assemblyname);
            _buildMode = Config.BuildMode;
        }

        #endregion

        #region public methods
        /// <summary>
        /// Sends the request to the blockchain
        /// </summary>
        /// <param name="method">the method to call</param>
        /// <param name="params">the parameters to send with the method</param>
        /// <returns>the http response from ther server</returns>
        protected string SendRequest(string method, ArrayList @params = null)
        {
            var resp = ProcessRequest(method, @params);
            return resp.Result;
        }


        #endregion

        #region private methods
        /// <summary>
        /// Processes the request and gets the response from the server
        /// </summary>
        /// <param name="methodname">the method name to call</param>
        /// <param name="params">the paramaters to pass with the method</param>
        /// <returns>the http response from the server</returns>
        private async Task<string> ProcessRequest(string methodname, ArrayList @params = null)
        {
            var response = string.Empty;
            try
            {
                var request = new
                {
                    jsonrpc = _jsonRpc,
                    id = GetRequestId(),
                    method = methodname,
                    @params = @params ?? new ArrayList()
                };

                var json = JsonConvert.SerializeObject(request);

                var httpResponse = await SendAsync(json);

                if (httpResponse == null) return response;
                response = await httpResponse.Content.ReadAsStringAsync();
                if (_buildMode == BuildMode.Test)
                {
                    _logger.WriteTestData(
                        $"Date & Time: {DateTime.UtcNow} || Method: {methodname} || Request Data: {json} || Response Data: {response}");
                }
            }
            catch (HttpRequestException ex)
            {
                response = $"{ex.Message}";
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
            }
            
            return response;
        }

        private int GetRequestId()
        {
            return _requestId++;
        }

        /// <summary>
        ///     Sends the data to the blockchain
        /// </summary>
        /// <param name="data">the data to send</param>
        /// <returns>the response from the send</returns>
        private async Task<HttpResponseMessage> SendAsync(string data)
        {
            var response =
                await _client.PostAsync(_uri, new StringContent(data, Encoding.UTF8));
            response.EnsureSuccessStatusCode();
            return response;
        }

        #endregion

    }

    
}