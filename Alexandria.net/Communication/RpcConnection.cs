﻿using System;
using System.Collections;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Alexandria.net.API;
using Alexandria.net.Enums;
using Alexandria.net.Exceptions;
using Alexandria.net.Extensions;
using Alexandria.net.Logging;
using Alexandria.net.Mapping;
using Alexandria.net.Messaging.Responses;
using Alexandria.net.Settings;
using Newtonsoft.Json;

namespace Alexandria.net.Communication
{
    /// <summary>
    /// Abstract Class which manages the sending and receiving of data to and from the blockchain
    /// </summary>
    public abstract class RpcConnection
    {
        #region Variables
        private int _requestId;
        private readonly string _uri;
        private readonly HttpClient _client;
        private readonly string _jsonRpc;
        protected readonly CSharpToCpp CSharpToCpp = new CSharpToCpp();
        private readonly ILogger _logger;
        private readonly BuildMode _buildMode;
        #endregion

        #region Properties

        private IConfig Config { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// RPCConnection Constructor
        /// </summary>
        /// <param name="config">the Configuration paramaters for the endpoint and ports</param>
        /// <param name="wallet">true if configuraing for the wallet</param>
        protected RpcConnection(IConfig config, bool wallet = true)
        {
            Config = config;
            _uri = $"http://{Config.Hostname}:{(wallet ? Config.WalletPort : config.DaemonPort)}{config.Api}";
            _client = new HttpClient();
            _jsonRpc = Config.Version;

            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(config, assemblyname);
            _buildMode = Config.BuildMode;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Sends the request to the blockchain
        /// </summary>
        /// <param name="method">the method to call</param>
        /// <param name="params">the parameters to send with the method</param>
        /// <param name="type">type of operation</param>
        /// <returns>the http response from ther server</returns>
        protected async Task<string> SendRequestAsync(string method, ArrayList @params = null, Type type = null)
        {
            string result; 
            try
            {
                result = await ProcessRequest(method, @params, type);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return result;
        }
        
        protected string SendRequest(string method, ArrayList @params = null, Type type = null)
        {
            string result; 
            try
            {
                result = ProcessRequest(method, @params, type).Result;
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
        /// <param name="contentdata">the transaction generated by the operations</param>
        /// <param name="privateKey">private key of the user</param>
        /// <typeparam name="T">type of the transaction's json body</typeparam>
        /// <returns> transaction response data</returns>
        protected TransactionResponse StartBroadcasting<T>(T contentdata, string privateKey)
        {
            var trans = new Transaction(Config);
            var key = new Key(Config);
            TransactionResponse finalResponse;
            try
            {
               //ask for token symbol each time a transaction is performed
               //todo:next build append a parameter as "CurrencySymbol" in each transaction functions to calculate the charges. 
                
                var fees = trans.CalculateFee(contentdata, "SPHTX");
                
                var feeAddedOperation = trans.AddFee(contentdata, fees.result);
                
                var transresponse = trans.CreateSimpleTransaction(feeAddedOperation.Result);
                if (transresponse == null) return null;

                var aboutresponse = trans.About();
                if (aboutresponse == null) return null;

                var transaction = JsonConvert.SerializeObject(transresponse.Result);
                
                var digest = key.GetTransactionDigest(transaction,aboutresponse.Result.ChainId,new byte[64]);

                var signature = key.SignDigest(digest, privateKey, new byte[130]);
                var response = key.AddSignature(transaction, signature,new byte[transaction.Length + 200]);
                finalResponse = trans.BroadcastTransaction(response);          
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }

            return finalResponse;
        }
        
        /// <summary>
        /// The method is used to broadcast the transaction asynchronously over the blockchain
        /// using the account of the user 
        /// </summary>
        /// <param name="contentdata">the transaction generated by the operations</param>
        /// <param name="privateKey">private key of the user</param>
        /// <typeparam name="T">type of the transaction's json body</typeparam>
        /// <returns> transaction response data</returns>
        protected async Task<TransactionResponse> StartBroadcastingAsync<T>(T contentdata, string privateKey)
        {
            var trans = new Transaction(Config);
            var key = new Key(Config);
            Task<TransactionResponse> finalResponse;
            try
            {
               //ask for token symbol each time a transaction is performed
               //todo:next build append a parameter as "CurrencySymbol" in each transaction functions to calculate the charges. 
                
                var fees = trans.CalculateFee(contentdata, "SPHTX");
                
                var feeAddedOperation = trans.AddFee(contentdata, fees.result);
                
                var transresponse = trans.CreateSimpleTransaction(feeAddedOperation.Result);
                if (transresponse == null) return null;

                var aboutresponse = trans.About();
                if (aboutresponse == null) return null;

                var transaction = JsonConvert.SerializeObject(transresponse.Result);
                
                var digest = key.GetTransactionDigest(transaction,aboutresponse.Result.ChainId,new byte[64]);

                var signature = key.SignDigest(digest, privateKey, new byte[130]);
                var response = key.AddSignature(transaction, signature,new byte[transaction.Length + 200]);
                finalResponse = trans.BroadcastTransactionAsync(response);          
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }

            return finalResponse.Result;
        }

        #endregion

        #region private methods

        /// <summary>
        /// Processes the request and gets the response from the server
        /// </summary>
        /// <param name="methodname">the method name to call</param>
        /// <param name="params">the paramaters to pass with the method</param>
        /// <param name="type"></param>
        /// <returns>the http response from the server</returns>
        private async Task<string> ProcessRequest(string methodname, ArrayList @params = null, Type type = null)
        {
            var response = string.Empty;
            try
            {
                var request = new
                {
                    jsonrpc = _jsonRpc,
                    id = GetRequestId(),
                    method = methodname,
                    @params = @params ?? new ArrayList()
                };

                var json = JsonConvert.SerializeObject(request).GetJsonString(type);
             
                var httpResponse = _client.PostAsync(_uri, new StringContent(json, Encoding.UTF8)).Result;

                if (httpResponse == null) return response;
                response = await httpResponse.Content.ReadAsStringAsync();
                if (_buildMode == BuildMode.Test)
                {
                    _logger.WriteTestData(
                        $"Date & Time: {DateTime.UtcNow} || Method: {methodname} || Request Data: {json} || Response Data: {response}");
                }

                if (response.Contains("error"))
                {
                    throw new SophiaBlockchainException(response);
                    
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.WriteError($"Message: {ex.Message} | StackTrace: {ex.StackTrace}");
                throw;
            }
            catch (SophiaBlockchainException sx)
            {
                _logger.WriteError($"Message: {sx.Message} | StackTrace: {sx.StackTrace} | Response: {sx.ErrMsg}");
                throw;

            }
           return response;
        }
        
        private int GetRequestId()
        {
            return _requestId++;
        }

        #endregion

    }  
}