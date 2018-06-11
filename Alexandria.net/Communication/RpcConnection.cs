using System;
using System.Collections;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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

        #endregion

        #region Constructors

        /// <summary>
        /// RPCConnection Constructor
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <param name="api"></param>
        /// <param name="version"></param>
        protected RpcConnection(string hostname, ushort port, string api = "/rpc", string version = "2.0")
        {
            _uri = string.Format("http://{0}:{1}{2}", hostname, port, api);
            _client = new HttpClient();
            _jsonRpc = version;
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
            }
            catch (HttpRequestException e)
            {
                response = $"{e.Message}";
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

        /// <summary>
        ///     Receives data from the blockchain
        /// </summary>
        /// <param name="data">the data</param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> ReceiveAsync(string data)
        {
            var response = await _client.PostAsync(_uri, new StringContent(data, Encoding.UTF8));
            response.EnsureSuccessStatusCode();
            return response;
        }

        #endregion

    }

    
}