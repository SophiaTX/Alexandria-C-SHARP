using System.Collections;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Alexandria.net.Communication
{
    public class RpcConnection
    {
        #region Variables

        private int _requestId;
        private readonly string _uri;
        private readonly HttpClient _client;
        private const string JsonRpc = "2.0";

        #endregion

        #region Constructors

        public RpcConnection(string hostname, ushort port, string api, string version = "2.0")
        {
            _uri = string.Format("http://{0}:{1}{2}", hostname, port, api);
            _client = new HttpClient();
        }
        #endregion

        #region public methods


        public async Task<string> SendRequest(string method, ArrayList @params)
        {
            string response = string.Empty;
            try
            {
                var request = new
                {
                    jsonrpc = JsonRpc,
                    id = GetRequestId(),
                    method = method,
                    request = @params ?? (IEnumerable) ""
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


        #endregion

        #region private methods

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