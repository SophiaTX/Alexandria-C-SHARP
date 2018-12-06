using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Alexandria.net.Communication;
using Alexandria.net.Logging;
using Alexandria.net.Messaging.Responses;
using Alexandria.net.Settings;
using Newtonsoft.Json;
using AccountResponse = Alexandria.net.Messaging.Responses.AccountResponse;
using ILogger = Alexandria.net.Logging.ILogger;

namespace Alexandria.net.API
{
	/// <inheritdoc />
	/// <para>
	/// Sophia Blockchain transaction functions
	/// </para>
	public class  Transaction : RpcConnection
	{	
		private readonly ILogger _logger;
		private IConfig Config { get; }
		#region Constructors
			
		/// <summary>
		/// Wallet Constructor
		/// </summary>
		/// <param name="config">the Configuration paramaters for the endpoint and ports</param>
		public Transaction(IConfig config) : base(config)
		{
			Config = config;
			var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
			_logger = new Logger(config, assemblyname);
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Returns info such as client version, git version of graphene/fc, version of boost, openssl.
		/// </summary>
		/// <returns>Returns compile time info And client And dependencies versions</returns>
		public AboutResponse About()
		{
			var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
			var result= SendRequest(reqname);
			var contentdata = JsonConvert.DeserializeObject<AboutResponse>(result);
			return contentdata;
		}
			
		/// <summary>
		/// Returns info such as client version, git version of graphene/fc, version of boost, openssl.
		/// </summary>
		/// <returns>Returns compile time info And client And dependencies versions</returns>
		public async Task<AboutResponse> AboutAsync()
		{
			var reqname = CSharpToCpp.GetValue("About");
			var result= await SendRequestAsync(reqname);
			var contentdata = JsonConvert.DeserializeObject<AboutResponse>(result);
			return contentdata;
		}

		/// <summary>
		/// Returns information about the block
		/// </summary>
		/// <param name="num">the block num</param>
		/// <returns>Public block data On the blockchain</returns>
		public BlockResponse GetBlock(uint num)
		{
			var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
			var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, num);
			//var @params = new ArrayList {num};
			var result =  SendRequest(reqname, @params);
			var contentdata = JsonConvert.DeserializeObject<BlockResponse>(result);
			return contentdata;
		}

		/// <summary>
		/// get current price feed history
		/// @returns Price feed history data on the blockchain
		/// </summary>
		/// <returns>Returns object with Feed details</returns>
		public FeedHistoryResponse GetFeedHistory(string symbol)
		{
			var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
			var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, symbol);
			//var @params = new ArrayList {symbol};
			var result= SendRequest(reqname, @params);
			var contentdata = JsonConvert.DeserializeObject<FeedHistoryResponse>(result);
			return contentdata;
		}

		/// <summary>
		/// Get transaction by ID.
		/// </summary>
		/// <param name="trxId"></param>
		/// <returns>Returns object with transaction details</returns>
		public TransactionResponse GetTransaction(string trxId)
		{
			var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
			var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, trxId);
			//var @params = new ArrayList {trxId};
			var result= SendRequest(reqname, @params);
			var contentdata = JsonConvert.DeserializeObject<TransactionResponse>(result);
			return contentdata;
		}

		/// <summary>
		/// Broadcasts transaction once it is created, helps to register Transactions on the Blockchain
		/// </summary>
		/// <param name="signedTx"></param>
		/// <returns>Returns Object with Transaction id and other details</returns>
		public TransactionResponse BroadcastTransaction(SignedTransactionResponseData signedTx)
		{
			var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
			var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, signedTx);
			//var @params = new ArrayList {signedTx};
			var result= SendRequest(reqname, @params);
			var contentdata = JsonConvert.DeserializeObject<TransactionResponse>(result);
			return contentdata;
		}
		
		/// <summary>
		/// Broadcasts transaction once it is created, helps to register Transactions on the Blockchain asynchronously
		/// </summary>
		/// <param name="signedTx"></param>
		/// <returns>Returns Object with Transaction id and other details</returns>
		public async Task<TransactionResponse> BroadcastTransactionAsync(SignedTransactionResponseData signedTx)
		{
			var reqname = CSharpToCpp.GetValue("BroadcastTransaction");
			var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, signedTx);
			//var @params = new ArrayList {signedTx};
			var result= await SendRequestAsync(reqname, @params);
			var contentdata = JsonConvert.DeserializeObject<TransactionResponse>(result);
			return contentdata;
		}

		
		/// <summary>
		/// Creates Transaction for all the operations created
		/// </summary>
		/// <param name="operation"></param>
		/// <returns>Returns Object with block number and other trnasaction details</returns>
		public TransactionResponse CreateSimpleTransaction<T>(T operation)
		{
			var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
			var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, operation);
			//var @params = new ArrayList {operation};
			var result= SendRequest(reqname, @params);
			var contentdata = JsonConvert.DeserializeObject<TransactionResponse>(result);
			return contentdata;
		}
		
		/// <summary>
		/// Creates Transaction for all the operations created
		/// </summary>
		/// <param name="operation"></param>
		/// <returns>Returns Object with block number and other trnasaction details</returns>
		public async Task<TransactionResponse> CreateSimpleTransactionAsync<T>(T operation)
		{
			var reqname = CSharpToCpp.GetValue("CreateSimpleTransaction");
			var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, operation);
			//var @params = new ArrayList {operation};
			var result= await SendRequestAsync(reqname, @params);
			var contentdata = JsonConvert.DeserializeObject<TransactionResponse>(result);
			return contentdata;
		}
		
		/// <summary>
		/// Creates the transaqction
		/// </summary>
		/// <param name="operation">the namne of the operation to be created</param>
		/// <returns>the transactio nresponbse from the call</returns>
		public TransactionResponse CreateTransaction(List<AccountResponse> operation)
		{
			var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
			var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, operation);
			//var @params = new ArrayList {operation};
			var result= SendRequest(reqname, @params);
			var contentdata = JsonConvert.DeserializeObject<TransactionResponse>(result);
			return contentdata;
		}
		

		/// <summary>
		/// Sequence of operations included/generated in a specified block
		/// </summary>
		/// <param name="blockNumber">Integer Block Number </param>
		/// <param name="onlyVirtual">Boolean Only Virtual operation listing</param>
		/// <returns>Returns sequence of operations included/generated in a specified block</returns>
		public GetOperationsResponse GetOpsInBlock(uint blockNumber,bool onlyVirtual)
		{
			var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
			var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, blockNumber,onlyVirtual);
			//var @params = new ArrayList {blockNumber,onlyVirtual};
			var result =  SendRequest(reqname, @params);
			var contentdata = JsonConvert.DeserializeObject<GetOperationsResponse>(result);
			return contentdata;
		}

		/// <summary>
		/// Returns a list of all commands supported by the wallet API.
		/// This lists each command, along with its arguments and return types.
		/// </summary>
		/// <returns>Returns a list of all commands supported by the wallet API</returns>
		public HelpResponse Help()
		{
			var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
			var result= SendRequest(reqname);
			var contentdata = JsonConvert.DeserializeObject<HelpResponse>(result);
			return contentdata;
		}
		
		/// <summary>
		/// Info about the current state of the blockchain
		/// </summary>
		/// <returns>Returns info about the current state of the blockchain</returns>
		public InfoResponse Info()
		{
			var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
			var result= SendRequest(reqname);
			var contentdata = JsonConvert.DeserializeObject<InfoResponse>(result);
			return contentdata;
		}
		
		/// <summary>
		/// Serialize currently generated transaction on to the blockchain with other transactions
		/// </summary>
		/// <param name="signedTx">Already signed transaction</param>
		/// <returns>object</returns>
		public SerializedTransaction SerializeTransaction(SignedTransactionResponse signedTx)
		{
			var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
			var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, signedTx);
			//var @params = new ArrayList {signedTx};
			var result= SendRequest(reqname, @params);
			var contentdata = JsonConvert.DeserializeObject<SerializedTransaction>(result);
			return contentdata;
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
			var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
			var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, operation,symbol);
			//var @params = new ArrayList {operation,symbol};
			var result= SendRequest(reqname, @params);
			var contentdata = JsonConvert.DeserializeObject<FeesResponse>(result);
			return contentdata;
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
			var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
			var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, operation,fee);
			//var @params = new ArrayList {operation,fee};
			var result= SendRequest(reqname, @params);
			var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
			return contentdata;
		}
		/// <summary>
		///  Sign and Send the transaction 
		/// </summary>
		/// <param name="contentdata"></param>
		/// <param name="privateKey"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
        public TransactionResponse SignAndSendTransaction<T>(T contentdata, string privateKey)
        {           
            var key = new Key(Config);
            TransactionResponse finalResponse;
	        var transaction = JsonConvert.SerializeObject(contentdata);                
	        var digest = key.GetTransactionDigest(transaction,ChainId,new byte[64]);
	        var signature = key.SignDigest(digest, privateKey, new byte[130]);
	        var response = key.AddSignature(transaction, signature,new byte[transaction.Length + 200]);
	        finalResponse = BroadcastTransaction(response);

	        return finalResponse;
        }
		
		/// <summary>
		/// Call external APIs
		/// </summary>
		/// <param name="pluginName"></param>
		/// <param name="methodName"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		public DaemonResponse CallPlugin(string pluginName, string methodName, object args)
		{
			var result= SendRequestToDaemon(pluginName+'.'+methodName, args);
			var contentdata = JsonConvert.DeserializeObject<DaemonResponse>(result);
			return contentdata;
		}
		#endregion
	}
}