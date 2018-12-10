using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Alexandria.net.Communication;
using Alexandria.net.Logging;
using Alexandria.net.Mapping;
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
	public class  Transaction : ApiBase
	{	
		
		#region Constructors

		/// <inheritdoc />
		/// <summary>
		/// Wallet Constructor
		/// </summary>
		/// <param name="config">the Configuration parameters for the endpoint and ports</param>
		/// <param name="methodMapperCollection"></param>
		public Transaction(IConfig config, List<MethodMapper> methodMapperCollection) : base(methodMapperCollection)
		{
			Logger = new Logger(config, Assembly.GetExecutingAssembly().GetName().Name);
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Returns info such as client version, git version of graphene/fc, version of boost, openssl.
		/// </summary>
		/// <returns>Returns compile time info And client And dependencies versions</returns>
		public AboutResponse About()
		{
			var @params = ParamCollection.Single(s => s.MethodName == "About");
			var result= SendRequest(@params.BlockChainMethodName);
			var content = JsonConvert.DeserializeObject<AboutResponse>(result);
			return content;
		}
			
		/// <summary>
		/// Returns info such as client version, git version of graphene/fc, version of boost, openssl.
		/// </summary>
		/// <returns>Returns compile time info And client And dependencies versions</returns>
		public async Task<AboutResponse> AboutAsync()
		{
			var @params = ParamCollection.Single(s => s.MethodName == "About");
			var result= await SendRequestAsync(@params.BlockChainMethodName);
			var content = JsonConvert.DeserializeObject<AboutResponse>(result);
			return content;
		}

		/// <summary>
		/// Returns information about the block
		/// </summary>
		/// <param name="num">the block num</param>
		/// <returns>Public block data On the blockchain</returns>
		public BlockResponse GetBlock(uint num)
		{
			var @params = ParamCollection.Single(s => s.MethodName == "GetBlock");
			var data = @params.GetObjectAndJsonValue(num);
			var result =  SendRequest(@params.BlockChainMethodName, data);
			var content = JsonConvert.DeserializeObject<BlockResponse>(result);
			return content;
		}

		/// <summary>
		/// get current price feed history
		/// @returns Price feed history data on the blockchain
		/// </summary>
		/// <returns>Returns object with Feed details</returns>
		public FeedHistoryResponse GetFeedHistory(string symbol)
		{
			var @params = ParamCollection.Single(s => s.MethodName == "GetFeedHistory");
			var data = @params.GetObjectAndJsonValue(symbol);
			var result= SendRequest(@params.BlockChainMethodName,data);
			var content = JsonConvert.DeserializeObject<FeedHistoryResponse>(result);
			return content;
		}

		/// <summary>
		/// Get transaction by ID.
		/// </summary>
		/// <param name="trxId"></param>
		/// <returns>Returns object with transaction details</returns>
		public TransactionResponse GetTransaction(string trxId)
		{
			var @params = ParamCollection.Single(s => s.MethodName == "GetTransaction");
			var data = @params.GetObjectAndJsonValue(trxId);
			var result= SendRequest(@params.BlockChainMethodName,data);
			var content = JsonConvert.DeserializeObject<TransactionResponse>(result);
			return content;
		}
		
		/// <summary>
		/// Creates the transaqction
		/// </summary>
		/// <param name="operation">the namne of the operation to be created</param>
		/// <returns>the transactio nresponbse from the call</returns>
		public TransactionResponse CreateTransaction(List<AccountResponse> operation)
		{
			var @params = ParamCollection.Single(s => s.MethodName == "CreateTransaction");
			var data = @params.GetObjectAndJsonValue(operation);
			var result = SendRequest(@params.BlockChainMethodName, data);
			var content = JsonConvert.DeserializeObject<TransactionResponse>(result);
			return content;
		}
		

		/// <summary>
		/// Sequence of operations included/generated in a specified block
		/// </summary>
		/// <param name="blockNumber">Integer Block Number </param>
		/// <param name="onlyVirtual">Boolean Only Virtual operation listing</param>
		/// <returns>Returns sequence of operations included/generated in a specified block</returns>
		public GetOperationsResponse GetOpsInBlock(uint blockNumber,bool onlyVirtual)
		{
			var @params = ParamCollection.Single(s => s.MethodName == "GetOpsInBlock");
			var data = @params.GetObjectAndJsonValue(blockNumber,onlyVirtual);
			var result = SendRequest(@params.BlockChainMethodName, data);
			var content = JsonConvert.DeserializeObject<GetOperationsResponse>(result);
			return content;
		}

		/// <summary>
		/// Returns a list of all commands supported by the wallet API.
		/// This lists each command, along with its arguments and return types.
		/// </summary>
		/// <returns>Returns a list of all commands supported by the wallet API</returns>
		public HelpResponse Help()
		{
			var @params = ParamCollection.Single(s => s.MethodName == "Help");
			var result = SendRequest(@params.BlockChainMethodName);
			var content = JsonConvert.DeserializeObject<HelpResponse>(result);
			return content;
		}
		
		/// <summary>
		/// Info about the current state of the blockchain
		/// </summary>
		/// <returns>Returns info about the current state of the blockchain</returns>
		public InfoResponse Info()
		{
			var @params = ParamCollection.Single(s => s.MethodName == "Info");
			var result = SendRequest(@params.BlockChainMethodName);
			var content = JsonConvert.DeserializeObject<InfoResponse>(result);
			return content;
		}
		
		/// <summary>
		/// Serialize currently generated transaction on to the blockchain with other transactions
		/// </summary>
		/// <param name="signedTx">Already signed transaction</param>
		/// <returns>object</returns>
		public SerializedTransaction SerializeTransaction(SignedTransactionResponse signedTx)
		{
			var @params = ParamCollection.Single(s => s.MethodName == "SerializeTransaction");
			var data = @params.GetObjectAndJsonValue(signedTx);
			var result = SendRequest(@params.BlockChainMethodName, data);
			var content = JsonConvert.DeserializeObject<SerializedTransaction>(result);
			return content;
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
			var @params = ParamCollection.Single(s => s.MethodName == "CalculateFee");
			var data = @params.GetObjectAndJsonValue(operation,symbol);
			var result = SendRequest(@params.BlockChainMethodName, data);
			var content = JsonConvert.DeserializeObject<FeesResponse>(result);
			return content;
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
			var @params = ParamCollection.Single(s => s.MethodName == "AddFee");
			var data = @params.GetObjectAndJsonValue(operation,fee);
			var result = SendRequest(@params.BlockChainMethodName, data);
			var content = JsonConvert.DeserializeObject<AccountResponse>(result);
			return content;
		}
		/// <summary>
		///  Sign and Send the transaction 
		/// </summary>
		/// <param name="contentData"></param>
		/// <param name="privateKey"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
        public TransactionResponse SignAndSendTransaction<T>(T contentData, string privateKey)
        {           
	        var transaction = JsonConvert.SerializeObject(contentData);                
	        var digest = GetTransactionDigest(transaction,ChainId,new byte[64]);
	        var signature = SignDigest(digest, privateKey, new byte[130]);
	        var response = AddSignature(transaction, signature,new byte[transaction.Length + 200]);
	        var finalResponse = BroadcastTransaction(response);
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
			var content = JsonConvert.DeserializeObject<DaemonResponse>(result);
			return content;
		}
		#endregion
	}
}