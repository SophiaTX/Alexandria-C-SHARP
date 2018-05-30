using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Alexandria.net.API
{
    internal class SphTxJsonRpc
    {
        #region const
		private const string Crlf = "\r\n";
	    #endregion

		#region Enums

	    private enum EhttpMethod
		{
			Get = 1,
			Post = 2,
			Put = 3
		}
		#endregion

		#region Structures

	    private struct JsonRpc
		{
			public string Version;
			public int Port;
			public string Api;
		}
		#endregion

		#region Variables
		private int _requestId;
	    private readonly string _url;
		private readonly JsonRpc _jsonRpc;
		#endregion

		#region Constructors
		public SphTxJsonRpc(string hostname, ushort port, string api, string version = "2.0")
		{
			_jsonRpc.Port = port;
			_jsonRpc.Api = api;
			_jsonRpc.Version = version;

			_url = string.Format("http:\\{0}:{1}{2}", hostname, _jsonRpc.Port, _jsonRpc.Api);

			// Bypass SSL
			ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, policyErrors) => true;
			ServicePointManager.Expect100Continue = true;
#pragma warning disable 618
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
#pragma warning restore 618
		}
		#endregion

		#region private methods
		private int GetRequestId()
		{
			return _requestId++;
		}

	    private string GetHttpRequest(string strData, EhttpMethod eMethod)
	    {
		    string bodyRequest;
		    string response;
		    var request = (HttpWebRequest) WebRequest.Create(_url);

		    switch (eMethod)
		    {
			    case EhttpMethod.Post:
				    request.Method = "POST";
				    request.Accept = "application/json-rpc";
				    request.ContentType = "application/json-rpc; charset=UTF-8";
				    bodyRequest = strData;
				    break;

			    case EhttpMethod.Get:
				    request.Method = "GET";
				    request.Headers.Add(string.Format("GET:{0} HTTP/1.1", strData));
				    request.Accept = "*/*";
				    bodyRequest = strData;
				    break;

			    case EhttpMethod.Put:
				    var boundary = DateTime.Now.Ticks.ToString().Substring(0, 10);
				    request.Headers.Add(string.Format("POST:{0}{1} HTTP/1.1", _jsonRpc.Api, "upload/"));
				    request.Method = "POST";
				    request.Accept = "*/*";
				    request.ContentType = string.Format("multipart/form-data; boundary=%s", boundary);
				    bodyRequest = string.Format("--{0}{1}", boundary, Crlf);
				    bodyRequest += string.Format("Content-Disposition: form-data; name=\"unknown\"; filename=\"newFile.bin\"{0}",
					    Crlf);
				    bodyRequest += string.Format("{0}", Crlf);
				    bodyRequest += string.Format("{0}{1}", strData, Crlf);
				    bodyRequest += string.Format("--{0}--{1}", boundary, Crlf);
				    break;

			    default:
				    throw new Exception("Method not found : supported : GET/POST/PUT");
		    }

		    if (eMethod != EhttpMethod.Get)
		    {
			    // Setting DATA
			    var stringbuilder = new StringBuilder().Append(bodyRequest);
			    var aData = Encoding.UTF8.GetBytes(stringbuilder.ToString());

			    request.Headers.Add(string.Format("ContentLength: {0}", aData.Length));

			    using (var oStream = request.GetRequestStream())
			    {
				    oStream.Write(aData, 0, aData.Length);
			    }
		    }

		    // Execute request
		    using (var responseWeb = (HttpWebResponse) (request.GetResponse()))
		    {
			    if (responseWeb.StatusCode != HttpStatusCode.OK)
			    {
				    throw new Exception(string.Format("Error request response : {0} - {1}", responseWeb.StatusCode,
					    responseWeb.StatusDescription));
			    }

			    // Read response
			    using (var stream = new StreamReader(responseWeb.GetResponseStream() ?? throw new InvalidOperationException()))
			    {
				    response = stream.ReadToEnd();
				    stream.Close();
			    }
		    }

		    return response;
	    }

	    #endregion

		#region public methods
	    public string SendRequest(string method, ArrayList @params = null)
		{
			int retry;
			var result = string.Empty;
			var request = new Hashtable
			{
				["jsonrpc"] = _jsonRpc.Version,
				["id"] = GetRequestId(),
				["method"] = method
			};

			if (null != @params)
			{
				request["params"] = @params;
			}

			var jason = JsonConvert.SerializeObject(request);
			for(retry = 1; retry < 2; retry++)
			{
				try
				{
					result = GetHttpRequest(jason, EhttpMethod.Post);
					break;
				}
				catch
				{
					if (retry == 2)
					{
						throw;
					}
				}
				System.Threading.Thread.Sleep(1000);
			}
			return result;
		}
		#endregion
    }
}