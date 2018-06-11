using System.Collections;
using Alexandria.net.Communication;

namespace Alexandria.net.API
{
	public class SphTxApi
	{
		#region Variables

		private readonly RpcConnection _json;

		#endregion

		#region Constructors

		protected SphTxApi(string hostname, ushort port)
		{
			_json = new RpcConnection(hostname, port, "/rpc");
		}

		#endregion

		#region Methods

		protected string SendRequest(string method, ArrayList @params = null)
		{
			var resp = _json.SendRequest(method, @params);
			return resp.Result;
		}

		#endregion
	}
}