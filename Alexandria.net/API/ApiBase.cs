using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Alexandria.net.Core;
using Alexandria.net.Mapping;
using Alexandria.net.Messaging.Responses;
using Alexandria.net.Settings;
using Newtonsoft.Json;
using ILogger = Alexandria.net.Logging.ILogger;


namespace Alexandria.net.API
{
    /// <summary>
    /// Abstract Class which manages the sending and receiving of data to and from the blockchain
    /// </summary>
    public abstract class ApiBase
    {
        #region Member Variables
        private const string LibPath = "libalexandria";
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        protected static List<MethodMapper> ParamCollection;

        /// <summary>
        /// 
        /// </summary>
        protected static ILogger Logger;

        /// <summary>
        /// 
        /// </summary>
        protected static string ChainId;

        #endregion

        #region DllImports

        /// <summary>
        /// Creates a private key
        /// </summary>
        /// <param name="privateKey">byte[52] private_key</param>
        /// <param name="publickey">the public key</param>
        /// <returns>Returns true if success or false for failed try</returns>
        [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool generate_private_key([MarshalAs(UnmanagedType.LPArray)] byte[] privateKey,
            [MarshalAs(UnmanagedType.LPArray)] byte[] publickey);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="chainId"></param>
        /// <param name="digest"></param>
        /// <returns></returns>
        [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool get_transaction_digest([MarshalAs(UnmanagedType.LPStr)] string transaction,
            [MarshalAs(UnmanagedType.LPStr)] string chainId,
            [MarshalAs(UnmanagedType.LPArray)] byte[] digest);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="privateKey"></param>
        /// <param name="signedDigest"></param>
        /// <returns></returns>
        [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool sign_digest([MarshalAs(UnmanagedType.LPStr)] string digest,
            [MarshalAs(UnmanagedType.LPStr)] string privateKey, [MarshalAs(UnmanagedType.LPArray)] byte[] signedDigest);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="signature"></param>
        /// <param name="signedTx"></param>
        /// <returns></returns>
        [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool add_signature([MarshalAs(UnmanagedType.LPStr)] string transaction,
            [MarshalAs(UnmanagedType.LPStr)] string signature, [MarshalAs(UnmanagedType.LPArray)] byte[] signedTx);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool get_public_key([MarshalAs(UnmanagedType.LPStr)] string privateKey,
            [MarshalAs(UnmanagedType.LPArray)] byte[] publicKey);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brainKey"></param>
        /// <param name="privateKey"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool generate_key_pair_from_brain_key([MarshalAs(UnmanagedType.LPStr)] string brainKey,
            [MarshalAs(UnmanagedType.LPArray)] byte[] privateKey, [MarshalAs(UnmanagedType.LPArray)] byte[] publicKey);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="publicKey"></param>
        /// <param name="signedDigest"></param>
        /// <returns></returns>
        [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool verify_signature([MarshalAs(UnmanagedType.LPStr)] string digest,
            [MarshalAs(UnmanagedType.LPStr)] string publicKey, [MarshalAs(UnmanagedType.LPStr)] string signedDigest);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memo"></param>
        /// <param name="privateKey"></param>
        /// <param name="publicKey"></param>
        /// <param name="encryptedMemo"></param>
        /// <returns></returns>
        [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool encrypt_memo([MarshalAs(UnmanagedType.LPStr)] string memo,
            [MarshalAs(UnmanagedType.LPStr)] string privateKey, [MarshalAs(UnmanagedType.LPStr)] string publicKey,
            [MarshalAs(UnmanagedType.LPArray)] byte[] encryptedMemo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memo"></param>
        /// <param name="privateKey"></param>
        /// <param name="publicKey"></param>
        /// <param name="decryptedMemo"></param>
        /// <returns></returns>
        [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool decrypt_memo([MarshalAs(UnmanagedType.LPStr)] string memo,
            [MarshalAs(UnmanagedType.LPStr)] string privateKey, [MarshalAs(UnmanagedType.LPStr)] string publicKey,
            [MarshalAs(UnmanagedType.LPArray)] byte[] decryptedMemo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool base64_decode([MarshalAs(UnmanagedType.LPStr)] string input,
            [MarshalAs(UnmanagedType.LPArray)] byte[] output);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        [DllImport(LibPath, CallingConvention = CallingConvention.Cdecl)]
        protected static extern bool base64_encode([MarshalAs(UnmanagedType.LPStr)] string input,
            [MarshalAs(UnmanagedType.LPArray)] byte[] output);



        #endregion

        #region Constructors

        /// <summary>
        /// RPCConnection Constructor
        /// </summary>
        /// <param name="methodMapperCollection"></param>
        protected ApiBase(List<MethodMapper> methodMapperCollection)
        {
            ParamCollection = methodMapperCollection;
        }

        #endregion

        #region protected methods
        
        /// <summary>
        /// Sends the request to the blockchain
        /// </summary>
        /// <param name="method">the method to call</param>
        /// <param name="params">the parameters to send with the method</param>
        /// <param name="type">type of operation</param>
        /// <returns>the http response from the server</returns>
        protected async Task<string> SendRequestAsync(string method, string @params = null, Type type = null)
        {
            string result; 
            try
            {
                result = await SophiaClient.RpcConnection.ProcessRequest(method, @params, type);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="params"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        protected string SendRequest(string method, string @params = null, Type type = null)
        {
            string result; 
            try
            {
                result = SophiaClient.RpcConnection.ProcessRequest(method, @params, type).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="params"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        protected string SendRequestToDaemon(string method, object @params, Type type = null)
        {
            string result; 
            try
            {
                result = SophiaClient.RpcConnection.ProcessRequestOnDaemon(method, @params, type).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return result;
        }

        /// <summary>
        /// The method is used to broadcast the transaction over the blockchain using the account of the user
        /// </summary>
        /// <param name="contentData">the transaction generated by the operations</param>
        /// <param name="privateKey">private key of the user</param>
        /// <typeparam name="T">type of the transaction's json body</typeparam>
        /// <returns> transaction response data</returns>
        protected TransactionResponse StartBroadcasting<T>(T contentData, string privateKey)
        {
            var transResponse = CreateSimpleTransaction(contentData);
            if (transResponse == null) return null;

            var transaction = JsonConvert.SerializeObject(transResponse.Result);

            var digest = GetTransactionDigest(transaction, ChainId, new byte[64]);

            var signature = SignDigest(digest, privateKey, new byte[130]);
            var response = AddSignature(transaction, signature, new byte[transaction.Length + 200]);
            var finalResponse = BroadcastTransaction(response);

            return finalResponse;
        }

        /// <summary>
        /// The method is used to broadcast the transaction asynchronously over the blockchain
        /// using the account of the user 
        /// </summary>
        /// <param name="contentData">the transaction generated by the operations</param>
        /// <param name="privateKey">private key of the user</param>
        /// <typeparam name="T">type of the transaction's json body</typeparam>
        /// <returns> transaction response data</returns>
        protected async Task<TransactionResponse> StartBroadcastingAsync<T>(T contentData, string privateKey)
        {
            var transResponse = await CreateSimpleTransactionAsync(contentData);
            if (transResponse == null) return null;

            var transaction = JsonConvert.SerializeObject(transResponse.Result);
            var digest = GetTransactionDigest(transaction, ChainId, new byte[64]);
            var signature = SignDigest(digest, privateKey, new byte[130]);
            var response = AddSignature(transaction, signature, new byte[transaction.Length + 200]);

            var finalResponse = await BroadcastTransactionAsync(response);

            return finalResponse;
        }

        /// <summary>
        /// Creates digest of JSON formatted transaction
        /// </summary>
        /// <param name="transaction">the transaction to digest</param>
        /// <param name="chainId">the id in the blockchain</param>
        /// <param name="digest">the digest bytes, returned digest of transaction (size 64)</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public string GetTransactionDigest(string transaction, string chainId, byte[] digest)
        {
            var result = get_transaction_digest(transaction, chainId, digest)
                ? System.Text.Encoding.Default.GetString(digest)
                : string.Empty;

            return result;
        }

        /// <summary>
        /// Creates a signature for the given private key and transaction digest
        /// </summary>
        /// <param name="digest">string digest</param>
        /// <param name="privatekey">string privatekey</param>
        /// <param name="signeddigest"> byte[] signeddigest, returns signature (size 130)</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public string SignDigest(string digest, string privatekey, byte[] signeddigest)
        {
            var result = sign_digest(digest, privatekey, signeddigest)
                ? System.Text.Encoding.Default.GetString(signeddigest)
                : string.Empty;

            return result;
        }

        /// <summary>
        /// Adds signature to JSON formatted transaction
        /// </summary>
        /// <param name="transaction">string transaction</param>
        /// <param name="signature">string signature</param>
        /// <param name="signedtx">byte[] signedtx, returned signed transaction (size variable, depends on size of transaction on input_)</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public SignedTransactionResponseData AddSignature(string transaction, string signature, byte[] signedtx)
        {
            var value = add_signature(transaction, signature, signedtx);
            if (!value) return null;

            var signedTransaction = System.Text.Encoding.Default.GetString(signedtx);
            var result = JsonConvert.DeserializeObject<SignedTransactionResponseData>(signedTransaction);
            return result;
        }
        
        /// <summary>
        /// Creates Transaction for all the operations created
        /// </summary>
        /// <param name="operation"></param>
        /// <returns>Returns Object with block number and other transaction details</returns>
        protected TransactionResponse CreateSimpleTransaction<T>(T operation)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "CreateSimpleTransaction");
            var data = @params.GetObjectAndJsonValue(operation);
            var result = SendRequest(@params.BlockChainMethodName, data);
            var content = JsonConvert.DeserializeObject<TransactionResponse>(result);
            return content;
        }
        
        /// <summary>
        /// Creates Transaction for all the operations created
        /// </summary>
        /// <param name="operation"></param>
        /// <returns>Returns Object with block number and other transaction details</returns>
        protected async Task<TransactionResponse> CreateSimpleTransactionAsync<T>(T operation)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "CreateSimpleTransaction");
            var data = @params.GetObjectAndJsonValue(operation);
            //var @params = new ArrayList {operation};
            var result = await SendRequestAsync(@params.BlockChainMethodName, data);

            var content = JsonConvert.DeserializeObject<TransactionResponse>(result);
            return content;
        }
        
        /// <summary>
        /// Broadcasts transaction once it is created, helps to register Transactions on the Blockchain
        /// </summary>
        /// <param name="signedTx"></param>
        /// <returns>Returns Object with Transaction id and other details</returns>
        protected TransactionResponse BroadcastTransaction(SignedTransactionResponseData signedTx)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "BroadcastTransaction");
            var data = @params.GetObjectAndJsonValue(signedTx);
            var result = SendRequest(@params.BlockChainMethodName, data);
            var content = JsonConvert.DeserializeObject<TransactionResponse>(result);
            return content;
        }
		
        /// <summary>
        /// Broadcasts transaction once it is created, helps to register Transactions on the Blockchain asynchronously
        /// </summary>
        /// <param name="signedTx"></param>
        /// <returns>Returns Object with Transaction id and other details</returns>
        protected async Task<TransactionResponse> BroadcastTransactionAsync(SignedTransactionResponseData signedTx)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "BroadcastTransaction");
            var data = @params.GetObjectAndJsonValue(signedTx);
            var result = await SendRequestAsync(@params.BlockChainMethodName, data);
            var content = JsonConvert.DeserializeObject<TransactionResponse>(result);
            return content;
        }

        #endregion

    }

}