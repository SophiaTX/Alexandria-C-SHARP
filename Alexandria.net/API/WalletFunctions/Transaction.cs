using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.net.Communication;
using Alexandria.net.Logging;
using Alexandria.net.Messaging.Responses.DTO;
using Alexandria.net.Settings;
using Newtonsoft.Json;

namespace Alexandria.net.API.WalletFunctions
{
	/// <inheritdoc />
	/// <para>
	/// Wallet Transaction Functions
	/// </para>
	
	public class  Transaction : RpcConnection
	{	
		private readonly ILogger _logger;
		
		#region Constructors

		/// <summary>
		/// Wallet Constructor
		/// </summary>
		/// <param name="config">the Configuration paramaters for the endpoint and ports</param>
		public Transaction(IConfig config) : base(config)
		{
			var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
			_logger = new Logger(LoggingType.Server, assemblyname);
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Returns info such as client version, git version of graphene/fc, version of boost, openssl.
		/// </summary>
		/// <returns>Returns compile time info And client And dependencies versions</returns>
		public AboutResponse About()
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var result= SendRequest(reqname);
				var contentdata = JsonConvert.DeserializeObject<AboutResponse>(result);
				return contentdata;

			}
			catch(Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw ;
			}
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="challenger"></param>
		/// <param name="challenged"></param>
		/// <returns></returns>
		private string Challenge(string challenger, string challenged)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {challenger, challenged};
				return SendRequest(reqname, @params);
			}
			catch(Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw ;
			}
			
		}

		/// <summary>
		/// Returns information about the block
		/// </summary>
		/// <param name="num">the block num</param>
		/// <returns>Public block data On the blockchain</returns>
		public BlockResponse GetBlock(int num)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {num};
				var result =  SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<BlockResponse>(result);
				return contentdata;
			}
			catch(Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw ;
			}
			
		}

		/// <summary>
		/// get current price feed history
		/// @returns Price feed history data on the blockchain
		/// </summary>
		/// <returns>Returns object with Feed details</returns>
		public FeedHistoryResponse GetFeedHistory()
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var result= SendRequest(reqname);
				var contentdata = JsonConvert.DeserializeObject<FeedHistoryResponse>(result);
				return contentdata;
			}
			catch(Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw ;
			}
			
		}

		/// <summary>
		/// Get transaction by ID.
		/// </summary>
		/// <param name="trxId"></param>
		/// <returns>Returns object with transaction details</returns>
		public TransactionResponse GetTransaction(string trxId)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {trxId};
				var result= SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<TransactionResponse>(result);
				return contentdata;
			}
			catch(Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw ;
			}
			
		}

		/// <summary>
		/// Broadcasts transaction once it is created, helps to register Transactions on the Blockchain
		/// </summary>
		/// <param name="signedTx"></param>
		/// <returns>Returns Object with Transaction id and other details</returns>
		public TransactionResponse BroadcastTransaction(SignedTransactionResponse signedTx)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {signedTx};
				var result= SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<TransactionResponse>(result);
				return contentdata;
			}
			catch(Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw ;
			}
			
		}
		
		/// <summary>
		/// Creates Transaction for all the operations created
		/// </summary>
		/// <param name="operation"></param>
		/// <returns>Returns Object with block number and other trnasaction details</returns>
		public TransactionResponse CreateSimpleTransaction(AccountResponse operation)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {operation.result};
				var result= SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<TransactionResponse>(result);
				return contentdata;
			}
			catch(Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw ;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="operation"></param>
		/// <returns></returns>
		public TransactionResponse CreateTransaction(List<AccountResponse> operation)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {operation};
				var result= SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<TransactionResponse>(result);
				return contentdata;
			}
			catch(Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw ;
			}
		}

		/// <summary>
		/// A witness can Public a price feed For the SPHTX:SBD market.
		/// The median price feed Is used To process conversion requests from SBD To SPHTX.
		/// </summary>
		/// <param name="witness">The witness publishing the price feed </param>
		/// <param name="exchangeRate">The desired exchange rate</param>
		/// <returns></returns>
		private string PublishFeed(string witness, decimal exchangeRate)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {witness, exchangeRate};
				return SendRequest(reqname, @params);
			}
			catch(Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw ;
			}
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="seconds"></param>
		private void SetTransactionExpiration(uint seconds)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {seconds};
				SendRequest(reqname, @params);
			}
			catch(Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw ;
			}
			
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
		public AccountResponse SetVotingProxy(string accountToModify, string proxy)
		{	
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {accountToModify, proxy};
				var result= SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
				
				var broadcast = new BroadCastTransactionProcess(Config);
                var response = broadcast.StartBroadcasting(contentdata);
                return response == null ? null : contentdata;
			}
			catch(Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw ;
			}
		}

		/// <summary>
		/// Set up a vesting withdraw request. The request Is fulfilled once a week over the next two years (104 weeks).
		/// The amount of vests to withdrawover the Next two
		///        years. Each week (amount/104) shares are withdrawn And depositted
		///        back as STEEM. i.e. "10.000000 VESTS"
		/// </summary>
		/// <param name="from">account vests are drawn from </param>
		/// <param name="vestingShares"> The amount should be in the format "10.0000 VESTS" showing amount and currency symbol</param>
		/// <returns></returns>
		public AccountResponse WithdrawVesting(string from, string vestingShares)
		{
			//var trans = new Transaction(Config);
			//var key = new Key(Config);
			//var pk = "5KGL7MNAfwCzQ8DAq7DXJsneXagka3KNcjgkRayJoeJUucSLkev";
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {from, vestingShares};
				var result = SendRequest(reqname, @params);

				var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);

				var broadcast = new BroadCastTransactionProcess(Config);
				var response = broadcast.StartBroadcasting(contentdata);
				return response == null ? null : contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
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
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {@from, to, amount, memo};
				return SendRequest(reqname, @params);
			}
			catch(Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw ;
			}
			
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
		public string TransferToVesting(string from, string to, decimal amount)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {from, to, amount};
				return SendRequest(reqname, @params);
			}
			catch(Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw ;
			}
			
		}

		/// <summary>
		/// Sequence of operations included/generated in a specified block
		/// </summary>
		/// <param name="BlockNumber">Integer Block Number </param>
		/// <param name="OnlyVirtual">Boolean Only Virtual operation listing</param>
		/// <returns>Returns sequence of operations included/generated in a specified block</returns>
		public GetOperationsResponse GetOpsInBlock(int BlockNumber,bool OnlyVirtual)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {BlockNumber,OnlyVirtual};
				var result =  SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<GetOperationsResponse>(result);
				return contentdata;
			}
			catch (Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}

		#endregion
		/// <summary>
		/// Returns a list of all commands supported by the wallet API.
		/// This lists each command, along with its arguments and return types.
		/// @returns a multi-line string suitable for displaying on a terminal
		/// </summary>
		/// <returns>Returns a list of all commands supported by the wallet API</returns>
		public HelpResponse Help()
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var result= SendRequest(reqname);
				var contentdata = JsonConvert.DeserializeObject<HelpResponse>(result);
				return contentdata;
			}
			catch(Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw ;
			}
		}
		/// <summary>
		/// Info about the current state of the blockchain
		/// </summary>
		/// <returns>Returns info about the current state of the blockchain</returns>
		public InfoResponse Info()
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var result= SendRequest(reqname);
				var contentdata = JsonConvert.DeserializeObject<InfoResponse>(result);
				return contentdata;
			}
			catch(Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw ;
			}
		}

		public SerializedTransaction SerializeTransaction(SignedTransactionResponse signed_tx)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {signed_tx};
				var result= SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<SerializedTransaction>(result);
				return contentdata;
			}
			catch(Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw ;
			}
		}
	}
}