using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Alexandria.net.Communication
{
	public class WebsocketConnection : IDisposable
	{
		#region Variables

		private readonly Uri _uri;
		private ClientWebSocket _clientWebSocket;
		private const string JsonRpc = "2.0";
		#endregion

		#region Constructors

		public WebsocketConnection(string uri = "ws://node.sophiatx.ws")
		{
			_uri = new Uri(uri);
			_clientWebSocket = new ClientWebSocket();
		}

		#endregion

		#region Public methods

		public async Task<string> SendRequest(string method, ArrayList @params = null)
		{
			var result = string.Empty;
			var bytes = new byte[2048];
			var request = new
			{
				jsonrpc = JsonRpc,
				id = 1,
				method = method,
				request = @params ?? (IEnumerable) ""
			};

			var jason = JsonConvert.SerializeObject(request);
			for (var retry = 1; retry < 2; retry++)
			{
				try
				{
					if (_clientWebSocket.State != WebSocketState.Open)
						await _clientWebSocket.ConnectAsync(_uri, CancellationToken.None);

					var bytesToSend = new ArraySegment<byte>(Encoding.UTF8.GetBytes(jason));
					var bytesReceived = new ArraySegment<byte>(bytes);
					await _clientWebSocket.SendAsync(bytesToSend, WebSocketMessageType.Text, true, CancellationToken.None);
					WebSocketReceiveResult resp;
					do
					{
						resp = await _clientWebSocket.ReceiveAsync(bytesReceived, CancellationToken.None);
						result += Encoding.UTF8.GetString(bytesReceived.Array, 0, resp.Count);
					} while (!resp.EndOfMessage);

					break;
				}
				catch
				{
					if (retry == 2) throw;
				}
				Thread.Sleep(1000);
			}

			return result;
		}

		#endregion

		#region IDisposable Support

		void IDisposable.Dispose()
		{
			if (WebSocketState.Open == _clientWebSocket.State)
			{
				_clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
			}

			_clientWebSocket.Dispose();
			_clientWebSocket = null;
		}

		#endregion
	}
}