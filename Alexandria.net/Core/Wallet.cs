using Alexandria.net.API;
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
		public Key Key { get; }
		/// <summary>
		/// 
		/// </summary>
		public Transaction Transaction { get; }
		/// <summary>
		/// 
		/// </summary>
		public Witness Witness { get; }
		
		/// <summary>
		/// 
		/// </summary>
		public Data Data { get; }
		/// <summary>
		/// 
		/// </summary>
		public Application Application { get; }

		#endregion
		
		#region ctors

		/// <summary>
		/// 
		/// </summary>
		/// <param name="config">the Configuration paramaters for the endpoint and ports</param>
		/// <param name="blockchainConfig"></param>
		public Wallet(IConfig config, IBlockchainConfig blockchainConfig)
		{
			Account = new Account(config);
			Asset = new Asset(config);
			Key = new Key(config);
			Transaction = new Transaction(config);
			Witness = new Witness(config);
			Data = new Data(config, blockchainConfig);
			Application=new Application(config);
			
		}	
		#endregion
    }
}	