using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using Alexandria.net.Communication;
using Alexandria.net.Messaging.Responses.DTO;
using Newtonsoft.Json;

namespace Alexandria.net.API.WalletFunctions
{
	/// <summary>
	/// All wallet calls to the SophiaTX Blockchain
	/// </summary>
	public partial class  Transaction : RpcConnection
	{	
		#region Constructors

		/// <summary>
		/// Wallet Constructor
		/// </summary>
		/// <param name="hostname">the rpc endpoint ip address</param>
		/// <param name="port">the rpc endpoint post</param>
		public Transaction(string hostname = "127.0.0.1", ushort port = 8091, string api = "/rpc",
			string version = "2.0") : base(hostname, port, api, version)
		{
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Gets the compile time info
		/// </summary>
		/// <returns>Returns compile time info And client And dependencies versions</returns>
		public string About()
		{
			return SendRequest(MethodBase.GetCurrentMethod().Name.ToLower());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="challenger"></param>
		/// <param name="challenged"></param>
		/// <returns></returns>
		public string Challenge(string challenger, string challenged)
		{
			var @params = new ArrayList {challenger, challenged};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		/// <summary>
		/// Returns information about the block
		/// </summary>
		/// <param name="num">the block num</param>
		/// <returns>Public block data On the blockchain</returns>
		public BlockResponse get_block(int num)
		{
			var @params = new ArrayList {num};
			var result =  SendRequest(MethodBase.GetCurrentMethod().Name, @params);
			var contentdata = JsonConvert.DeserializeObject<BlockResponse>(result);
			return contentdata;
		}

		/// <summary>
		/// return the current price feed history
		/// </summary>
		/// <returns></returns>
		public FeedHistoryResponse get_feed_history()
		{
			var result= SendRequest(MethodBase.GetCurrentMethod().Name);
			var contentdata = JsonConvert.DeserializeObject<FeedHistoryResponse>(result);
			return contentdata;
		}

		/// <summary>
		/// Returns transaction by ID.
		/// </summary>
		/// <param name="trxId"></param>
		/// <returns></returns>
		public string get_transaction(string trxId)
		{
			var @params = new ArrayList {trxId};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		/// <summary>
		/// A witness can Public a price feed For the SPHTX:SBD market.
		/// The median price feed Is used To process conversion requests from SBD To SPHTX.
		/// </summary>
		/// <param name="witness">The witness publishing the price feed </param>
		/// <param name="exchangeRate">The desired exchange rate</param>
		/// <returns></returns>
		private string publish_feed(string witness, decimal exchangeRate)
		{
			var @params = new ArrayList {witness, exchangeRate};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="seconds"></param>
		private void set_transaction_expiration(uint seconds)
		{
			var @params = new ArrayList {seconds};
			SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		/// <summary>
		/// Set the voting proxy For an account.
		/// If a user does Not wish To take an active part In voting, they can choose to allow another account to vote their stake.
		/// Setting a vote proxy does Not remove your previous votes from the blockchain,
		/// they remain there but are ignored. If you later null out your vote proxy, your previous votes will take effect again.
		/// This setting can be changed at any time.
		/// </summary>
		/// <param name="accountToModify">the name Or id Of the account To update</param>
		/// <param name="proxy">the name Of account that should proxy To, Or empty String To have no proxy </param>
		/// <returns></returns>
		public string set_voting_proxy(string accountToModify, string proxy)
		{
			var @params = new ArrayList {accountToModify, proxy};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		/// <summary>
		/// Set up a vesting withdraw request. The request Is fulfilled once a week over the next two years (104 weeks)
		/// </summary>
		/// <param name="from">account vests are drawn from</param>
		/// <param name="vestingShares">the amount of vests to withdrawover the Next two
		///        years. Each week (amount/104) shares are withdrawn And depositted
		///        back as STEEM. i.e. "10.000000 VESTS" </param>
		/// <returns></returns>
		public LockUnlockResponse withdraw_vesting(string from, decimal vestingShares)
		{
			var @params = new ArrayList {from, vestingShares};
			var result= SendRequest(MethodBase.GetCurrentMethod().Name, @params);
			var contentdata = JsonConvert.DeserializeObject<LockUnlockResponse>(result);
			return contentdata;
		}

		/// <summary>
		/// Transfer funds from one account To another. SPHTX And SBD can be transferred.
		/// </summary>
		/// <param name="from">The account the funds are coming from </param>
		/// <param name="to">The account the funds are going To </param>
		/// <param name="amount">The funds being transferred. i.e. "100.000 SPHTX" </param>
		/// <param name="memo">A memo For the transactionm, encrypted With the To account's</param>
		/// <returns></returns>
		public string Transfer(string from, string to, decimal amount, string memo)
		{
			var @params = new ArrayList {@from, to, amount, memo};
			return SendRequest(MethodBase.GetCurrentMethod().Name.ToLower(), @params);
		}

		/// <summary>
		/// Transfer STEEM into a vesting fund represented by vesting shares (VESTS).
		/// VESTS are required To vesting For a minimum Of one coin year And can be
		/// withdrawn once a week over a two year withdraw period. VESTS are Protected
		/// against dilution up until 90% Of STEEM Is vesting.
		/// </summary>
		/// <param name="from">The account the SPHTX Is coming from </param>
		/// <param name="to">The account getting the VESTS </param>
		/// <param name="amount">The amount Of STEEM To vest i.e. "100.00 SPHTX" </param>
		/// <returns></returns>
		public string transfer_to_vesting(string from, string to, decimal amount)
		{
			var @params = new ArrayList {@from, to, amount};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		#endregion
	}
}