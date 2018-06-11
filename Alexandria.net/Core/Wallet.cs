namespace Alexandria.net.Core
{
	/// <summary>
	/// 
	/// </summary>
	public class Wallet : Alexandria.net.API.WalletFunctions.Wallet
	{
		#region ctors
		/// <summary>
		/// Default constructor
		/// </summary>
		public Wallet()
		{
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="hostname"></param>
		/// <param name="port"></param>
		public Wallet(string hostname, ushort port) : base(hostname, port)
		{
			
		}
		#endregion
    }
}	