using System;
using System.Collections;
using System.Collections.Generic;
using Alexandria.net.Communication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Alexandria.net.API
{
	public class SphTxApi : IDisposable
	{
		#region Enums

		private enum EType
		{
			RemoteProcedureCall,
			WebSockets
		};

		#endregion

		#region Variables

		private readonly EType _etype;
		private readonly RpcConnection _json;
		private readonly WebsocketConnection _socket;

		#endregion

		#region Constructors

		protected SphTxApi(string hostname, ushort port)
		{
			_json = new RpcConnection(hostname, port, "/rpc");
			_etype = EType.RemoteProcedureCall;
		}

		protected SphTxApi(string uri)
		{
			_socket = new WebsocketConnection(uri);
			_etype = EType.WebSockets;
		}

		#endregion

		#region Private methods

		private string SendRequest(string method, ArrayList @params = null)
		{
			if (_etype == EType.RemoteProcedureCall)
			{
				var resp = _json.SendRequest(method, @params);
				return resp.Result;
			}

			using (var t = _socket.SendRequest(method, @params))
			{
				t.Wait();
				return t.Result;
			}
		}

		#endregion

		#region protected methods

		protected string call_api(string method)
		{
			return JsonConvert.DeserializeObject<string>(SendRequest(method));
		}

		protected string call_api(string method, ArrayList @params)
		{
			return JsonConvert.DeserializeObject<string>(SendRequest(method, @params));
		}

		protected JArray call_api_array(string method, ArrayList @params)
		{
			return JsonConvert.DeserializeObject<Dictionary<string, JArray>>(SendRequest(method, @params))["result"];
		}

		protected JArray call_api_array(string method)
		{
			return JsonConvert.DeserializeObject<Dictionary<string, JArray>>(SendRequest(method))["result"];
		}

		protected JValue call_api_value(string method)
		{
			return JsonConvert.DeserializeObject<Dictionary<string, JValue>>(SendRequest(method))["result"];
		}

		protected JValue call_api_value(string method, ArrayList @params)
		{
			return JsonConvert.DeserializeObject<Dictionary<string, JValue>>(SendRequest(method, @params))["result"];

		}

		protected JToken call_api_token(string method, ArrayList @params)
		{
			return JsonConvert.DeserializeObject<Dictionary<string, JToken>>(SendRequest(method, @params))["result"];
		}

		protected JToken call_api_token(string method)
		{
			return JsonConvert.DeserializeObject<Dictionary<string, JToken>>(SendRequest(method))["result"];
		}

		public void Dispose()
		{
			((IDisposable) _socket)?.Dispose();
		}

		#endregion
	}
}