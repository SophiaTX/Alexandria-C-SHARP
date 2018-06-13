﻿using System.Collections;
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
	public partial class  Wallet : RpcConnection
	{
		#region DllImports
		[DllImport("/Users/sanjivjha/RiderProjects/Alexandria/Alexandria.net/Lib/libalexandria.dylib")]
		private static extern bool generate_private_key([MarshalAs(UnmanagedType.LPArray)]byte[] private_key);

		[DllImport("/Users/sanjivjha/RiderProjects/Alexandria/Alexandria.net/Lib/libalexandria.dylib")]
		private static extern bool get_transaction_digest([MarshalAs(UnmanagedType.LPStr)] string transaction,
			[MarshalAs(UnmanagedType.LPArray)] byte[] digest);

		[DllImport("/Users/sanjivjha/RiderProjects/Alexandria/Alexandria.net/Lib/libalexandria.dylib")]
		private static extern bool sign_digest([MarshalAs(UnmanagedType.LPStr)] string digest,
			[MarshalAs(UnmanagedType.LPStr)] string private_key, [MarshalAs(UnmanagedType.LPArray)] byte[] signed_digest);        
        
		[DllImport("/Users/sanjivjha/RiderProjects/Alexandria/Alexandria.net/Lib/libalexandria.dylib")]
		private static extern bool add_signature([MarshalAs(UnmanagedType.LPStr)] string transaction,
			[MarshalAs(UnmanagedType.LPStr)] string signature, [MarshalAs(UnmanagedType.LPArray)] byte[] signed_tx);
		#endregion
		
		#region Constructors

		/// <summary>
		/// Wallet Constructor
		/// </summary>
		/// <param name="hostname">the rpc endpoint ip address</param>
		/// <param name="port">the rpc endpoint post</param>
		protected Wallet(string hostname = "127.0.0.1", ushort port = 8091) : base(hostname, port)
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
		/// <param name="broadcast">true if you wish to broadcast the transaction.</param>
		/// <returns></returns>
		public string Challenge(string challenger, string challenged, bool broadcast = true)
		{
			var @params = new ArrayList {challenger, challenged, broadcast};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		/// <summary>
		/// This method will convert SBD To STEEM at the current_median_history price one week from the time it Is executed.
		/// This method depends upon there being a valid price feed.
		/// </summary>
		/// <param name="from">The account requesting conversion Of its SBD i.e. "1.000 SBD"</param>
		/// <param name="amount">The amount Of SBD To convert</param>
		/// <param name="broadcast">true if you wish to broadcast the transaction.</param>
		/// <returns></returns>
		public string convert_sbd(string from, decimal amount, bool broadcast = true)
		{
			var @params = new ArrayList {@from, amount, broadcast};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}
		
		/// <summary>
		/// Marks one account As following another account. Requires the posting authority Of the follower.
		/// </summary>
		/// <param name="follower"></param>
		/// <param name="following"></param>
		/// <param name="what">a set of things to follow: posts, comments, votes, ignore</param>
		/// <param name="broadcast">true if you wish to broadcast the transaction.</param>
		/// <returns></returns>
		public string Follow(string follower, string following, ArrayList what, bool broadcast = true)
		{
			var @params = new ArrayList {follower, following, what, broadcast};
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

		//return the current price feed history
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public FeedHistoryResponse get_feed_history()
		{
			var result= SendRequest(MethodBase.GetCurrentMethod().Name);
			var contentdata = JsonConvert.DeserializeObject<FeedHistoryResponse>(result);
			return contentdata;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public string get_owner_history(string account)
		{
			var @params = new ArrayList {account};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		/// <summary>
		/// This returns a Default-initialized Object Of the given type; it can be used during early development Of the wallet When we don't yet have custom
		/// commands for creating all of the operations the blockchain supports.
		///
		/// Any operation the blockchain supports can be created Using the transaction //builder's 'add_operation_to_builder_transaction()' , but to do that from
		/// the CLI you need To know what the JSON form Of the operation looks Like. //This will give you a template you can fill In. It's better than nothing.
		/// </summary>
		/// <param name="operationType">the type Of operation To Return, must be one Of the operations defined In 'steemit/chain/operations.hpp' (e.g., "global_parameters_update_operation") </param>
		/// <returns> a Default-constructed operation of the given type</returns>
		public string get_prototype_operation(string operationType)
		{
			var @params = new ArrayList {operationType};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		/// <summary>
		/// Returns the state info associated With the URL
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		public string get_state(string url)
		{
			var @params = new ArrayList {url};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
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
		/// Returns detailed help On a Single API command.
		/// </summary>
		/// <param name="method">the name Of the API command you want help With</param>
		/// <returns>a multi-line String suitable For displaying On a terminal</returns>
		public string Gethelp(string method)
		{
			var @params = new ArrayList {method};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params).ToString(CultureInfo.InvariantCulture);
		}

		/// <summary>
		/// Returns a list Of all commands supported by the wallet API.
		/// </summary>
		/// <returns>a multi-line String suitable For displaying On a terminal</returns>
		public string help()
		{
			return SendRequest(MethodBase.GetCurrentMethod().Name).ToString(CultureInfo.InvariantCulture);
		}

		/// <summary>
		/// Returns info about the current state Of the blockchain
		/// </summary>
		/// <returns></returns>
		public InfoResponse info()
		{
			var result =  SendRequest(MethodBase.GetCurrentMethod().Name);
			var contentdata = JsonConvert.DeserializeObject<InfoResponse>(result);
			return contentdata;
		}
 
		/// <summary>
		/// Checks whether the wallet Is locked (Is unable To use its Private keys). This state can be changed by calling 'lock()' or 'unlock()'.
		/// </summary>
		/// <returns>true if the wallet Is locked</returns>
		public bool is_locked()
		{
			var result = SendRequest(MethodBase.GetCurrentMethod().Name);
			return result == "true";
		}
  
		/// <summary>
		/// Checks whether the wallet has just been created And has Not yet had a password set. Calling 'set_password' will transition the wallet to the locked state.
		/// </summary>
		/// <returns>true if the wallet Is New</returns>
		public LockUnlockResponse is_new()
		{
			var result = SendRequest(MethodBase.GetCurrentMethod().Name);			
			var contentdata = JsonConvert.DeserializeObject<LockUnlockResponse>(result);
			return contentdata;
		} 
   
		/// <summary>
		/// Loads a specified Graphene wallet. The current wallet Is closed before the New wallet Is loaded.
		/// </summary>
		/// <param name="walletFilename">the filename Of the wallet JSON file To load. If 'wallet_filename' is empty, it reloads the existing wallet file</param>
		/// <returns>true if the specified wallet Is loaded</returns>
		public bool load_wallet_file(string walletFilename)
		{
			var @params = new ArrayList {walletFilename};
			var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
			return result == "true";
		}

		/// <summary>
		/// Locks the wallet immediately.
		/// </summary>
		public LockUnlockResponse Lock()
		{
			var result = SendRequest("lock");
			
			var contentdata = JsonConvert.DeserializeObject<LockUnlockResponse>(result);
			return contentdata;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="nodes"></param>
		public void network_add_nodes(ArrayList nodes)
		{
			SendRequest(MethodBase.GetCurrentMethod().Name);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string network_get_connected_peers()
		{
			return SendRequest(MethodBase.GetCurrentMethod().Name);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="challenged"></param>
		/// <param name="broadcast">true if you wish to broadcast the transaction.</param>
		/// <returns></returns>
		public string Prove(string challenged, bool broadcast = true)
		{
			var @params = new ArrayList {challenged, broadcast};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		/// <summary>
		/// A witness can Public a price feed For the STEEM:SBD market. The median price feed Is used To process conversion requests from SBD To STEEM.
		/// </summary>
		/// <param name="witness">The witness publishing the price feed </param>
		/// <param name="exchangeRate">The desired exchange rate</param>
		/// <param name="broadcast">true if you wish to broadcast the transaction.</param>
		/// <returns></returns>
		public string publish_feed(string witness, decimal exchangeRate, bool broadcast = true)
		{
			var @params = new ArrayList {witness, exchangeRate, broadcast};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		/// <summary>
		/// Saves the current wallet To the given filename.
		/// </summary>
		/// <param name="walletFilename">the filename Of the New wallet JSON file To create Or overwrite. If 'wallet_filename' is empty, save to the current filename. </param>
		public void save_wallet_file(string walletFilename)
		{
			var @params = new ArrayList {walletFilename};
			SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		/// <summary>
		/// Sets a New password On the wallet.
		/// The wallet must be either 'new' or 'unlocked' to execute this command.
		/// </summary>
		/// <param name="password">the new password</param>
		public void set_password(string password)
		{
			var @params = new ArrayList {password};
			SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="seconds"></param>
		public void set_transaction_expiration(uint seconds)
		{
			var @params = new ArrayList {seconds};
			SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		/// <summary>
		/// Set the voting proxy For an account.
		///
		/// If a user does Not wish To take an active part In voting, they can choose to allow another account to vote their stake.
		///
		/// Setting a vote proxy does Not remove your previous votes from the blockchain, they remain there but are ignored. If you later null out your
		/// vote proxy, your previous votes will take effect again.
		///
		/// This setting can be changed at any time.
		/// </summary>
		/// <param name="accountToModify">the name Or id Of the account To update</param>
		/// <param name="proxy">the name Of account that should proxy To, Or empty String To have no proxy </param>
		/// <param name="broadcast">true if you wish to broadcast the transaction.</param>
		/// <returns></returns>
		public string set_voting_proxy(string accountToModify, string proxy, bool broadcast = true)
		{
			var @params = new ArrayList {accountToModify, proxy, broadcast};
			return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
		}

		/// <summary>
		/// The wallet remain unlocked until the 'lock' is called or the program exits.
		/// </summary>
		/// <param name="password">the password previously Set With 'set_password()'</param>
		public LockUnlockResponse unlock(string password)
		{
			var @params = new ArrayList {password};
			var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
			
			var contentdata = JsonConvert.DeserializeObject<LockUnlockResponse>(result);
			return contentdata;
		}
		
		/// <summary>
		/// Unlocks the wallet
		/// </summary>
		/// <param name="password">the password to unlock the wallet</param>
		/// <returns>the response received from the blockchain for the request</returns>
		public LockUnlockResponse unlock(ArrayList password)
		{
			var result = SendRequest(MethodBase.GetCurrentMethod().Name, password);
			
			var contentdata = JsonConvert.DeserializeObject<LockUnlockResponse>(result);
			return contentdata;
		}

		/// <summary>
		/// Set up a vesting withdraw request. The request Is fulfilled once a week over the next two years (104 weeks)
		/// </summary>
		/// <param name="from">account vests are drawn from</param>
		/// <param name="vestingShares">the amount of vests to withdrawover the Next two
		///        years. Each week (amount/104) shares are withdrawn And depositted
		///        back as STEEM. i.e. "10.000000 VESTS" </param>
		/// <param name="broadcast">true if you want to broadcast the transaction</param>
		/// <returns></returns>
		public LockUnlockResponse withdraw_vesting(string from, decimal vestingShares, bool broadcast = true)
		{
			var @params = new ArrayList {@from, vestingShares, broadcast};
			var result= SendRequest(MethodBase.GetCurrentMethod().Name, @params);
			var contentdata = JsonConvert.DeserializeObject<LockUnlockResponse>(result);
			return contentdata;
		}

		#endregion
	}
}