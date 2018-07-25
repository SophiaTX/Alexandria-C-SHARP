using System;
using System.Collections;
using System.Reflection;
using Alexandria.abapwrapper.Communication;
using Alexandria.abapwrapper.Logging;
using Alexandria.abapwrapper.Messaging.Responses.DTO;
using Alexandria.net.Messaging.Responses.DTO;
using Alexandria.net.Settings;
using Newtonsoft.Json;

namespace Alexandria.abapwrapper.API
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
		
		#endregion
	}
}