namespace Alexandria.net.Core
{
	public class Wallet : Alexandria.net.API.WalletFunctions.Wallet
	{
		#region ctors
		public Wallet()
		{
			
		}

		public Wallet(string hostname, ushort port) : base(hostname, port)
		{
			
		}
		#endregion
    }
}	