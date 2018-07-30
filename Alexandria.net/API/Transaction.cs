using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.net.Communication;
using Alexandria.net.Logging;
using Alexandria.net.Messaging.Responses;
using Alexandria.net.Settings;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using AccountResponse = Alexandria.net.Messaging.Responses.AccountResponse;

namespace Alexandria.net.API
{
	/// <inheritdoc />
	/// <para>
	/// Sophia Blockchain transaction functions
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
			_logger = new Logger(config, LoggingType.Server, assemblyname);
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
		/// Returns information about the block
		/// </summary>
		/// <param name="num">the block num</param>
		/// <returns>Public block data On the blockchain</returns>
		public BlockResponse GetBlock(uint num)
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
		public FeedHistoryResponse GetFeedHistory(string symbol)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {symbol};
				var result= SendRequest(reqname, @params);
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
				var @params = new ArrayList {signedTx.result};
				var result= SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<TransactionResponse>(result);
				return contentdata;
			}
			catch(Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				
				throw;
			}		
		}

		
		/// <summary>
		/// Creates Transaction for all the operations created
		/// </summary>
		/// <param name="operation"></param>
		/// <returns>Returns Object with block number and other trnasaction details</returns>
		public TransactionResponse CreateSimpleTransaction<T>(T operation)
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
		/// Creates the transaqction
		/// </summary>
		/// <param name="operation">the namne of the operation to be created</param>
		/// <returns>the transactio nresponbse from the call</returns>
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
		/// Sequence of operations included/generated in a specified block
		/// </summary>
		/// <param name="blockNumber">Integer Block Number </param>
		/// <param name="onlyVirtual">Boolean Only Virtual operation listing</param>
		/// <returns>Returns sequence of operations included/generated in a specified block</returns>
		public GetOperationsResponse GetOpsInBlock(uint blockNumber,bool onlyVirtual)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {blockNumber,onlyVirtual};
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

		/// <summary>
		/// Returns a list of all commands supported by the wallet API.
		/// This lists each command, along with its arguments and return types.
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
		
		/// <summary>
		/// Serialize currently generated transaction on to the blockchain with other transactions
		/// </summary>
		/// <param name="signedTx">Already signed transaction</param>
		/// <returns>object</returns>
		public SerializedTransaction SerializeTransaction(SignedTransactionResponse signedTx)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {signedTx};
				var result= SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<SerializedTransaction>(result);
				return contentdata;
			}
			catch(Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw;
			}
		}
		/// <summary>
		/// Calculate the possible fees deduction for the selected operation
		/// </summary>
		/// <param name="operation">Operation object</param>
		/// <param name="symbol">Asset Symbol</param>
		/// <typeparam name="T">Type of operation object</typeparam>
		/// <returns>Calculated fees for the transaction</returns>
		public FeesResponse CalculateFee<T>(T operation, string symbol)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {operation,symbol};
				var result= SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<FeesResponse>(result);
				return contentdata;
			}
			catch(Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw ;
			}
		}
		/// <summary>
		/// Add the calculated fees to the transaction
		/// </summary>
		/// <param name="operation">Operation object</param>
		/// <param name="fee">Calculated Fees</param>
		/// <typeparam name="T">Type of operation object</typeparam>
		/// <returns>object</returns>
		public AccountResponse AddFee<T>(T operation, string fee)
		{
			try
			{
				var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
				var @params = new ArrayList {operation,fee};
				var result= SendRequest(reqname, @params);
				var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
				return contentdata;
			}
			catch(Exception ex)
			{
				_logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
				throw ;
			}
		}
		
		#endregion
	}
}