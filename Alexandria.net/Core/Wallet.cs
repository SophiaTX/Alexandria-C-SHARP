namespace Alexandria.net.Core
{
	public class Wallet : Alexandria.net.API.Wallet
	{
		#region Constructors

		public Wallet(string hostname = "127.0.0.1", ushort port = 8091) : base(hostname, port)
		{
		}

		#endregion
    }
}