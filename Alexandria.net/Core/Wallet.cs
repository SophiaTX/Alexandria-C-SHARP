using Alexandria.net.API.WalletFunctions;
using Alexandria.net.Settings;

namespace Alexandria.net.Core
{
	/// <summary>
	/// List of all the functionalities supported by the SophiaTX C# Wallet API
	/// </summary>
	public class Wallet 
	{
		#region Member Variables

		/// <summary>
		/// 
		/// </summary>
		public Account Account { get; }
		/// <summary>
		/// 
		/// </summary>
		public Asset Asset { get; }
		/// <summary>
		/// 
		/// </summary>
		public Cryptography Cryptography { get; }
		/// <summary>
		/// 
		/// </summary>
		public Key Key { get; }
		/// <summary>
		/// 
		/// </summary>
		public Network Network { get; }
		/// <summary>
		/// 
		/// </summary>
		public Transaction Transaction { get; }
		/// <summary>
		/// 
		/// </summary>
		public Witness Witness { get; }

		#endregion
		
		#region ctors

		/// <summary>
		/// 
		/// </summary>
		/// <param name="config"></param>
		public Wallet(IConfig config)
		{
			Account = new Account(config);
			Asset = new Asset(config);
			Cryptography = new Cryptography(config);
			Key = new Key(config);
			Network = new Network(config);
			Transaction = new Transaction(config);
			Witness = new Witness(config);
		}	
		#endregion
    }
}	