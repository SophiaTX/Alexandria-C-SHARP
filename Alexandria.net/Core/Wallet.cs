using Alexandria.net.API.WalletFunctions;

namespace Alexandria.net.Core
{
	/// <summary>
	/// 
	/// </summary>
	public class Wallet 
	{
		#region Mewmber Variables

		public Account Account { get; set; }
		public Asset Asset { get; set; }
		public Cryptography Cryptography { get; set; }
		public Key Key { get; set; }
		public Network Network { get; set; }
		public Transaction Transaction { get; set; }
		public Witness Witness { get; set; }

		#endregion
		
		#region ctors

		/// <summary>
		/// 
		/// </summary>
		/// <param name="hostname"></param>
		/// <param name="port"></param>
		public Wallet(string hostname, ushort port)
		{
			Account = new Account(hostname, port);
			Asset = new Asset(hostname, port);
			Cryptography = new Cryptography(hostname, port);
			Key = new Key(hostname, port);
			Network = new Network(hostname, port);
			Transaction = new Transaction(hostname, port);
			Witness = new Witness(hostname, port);

		}

		public Wallet()
		{
			Account = new Account();
			Asset = new Asset();
			Cryptography = new Cryptography();
			Key = new Key();
			Network = new Network();
			Transaction = new Transaction();
			Witness = new Witness();
		}

		#endregion
    }
}	