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
using Alexandria.net.Mapping;
using Alexandria.net.Messaging.Responses;
using Alexandria.net.Settings;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Graylog;
using Serilog.Sinks.Graylog.Core;
using ILogger = Alexandria.net.Logging.ILogger;
using Logger = Alexandria.net.Logging.Logger;


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
        


        /// <summary>
        /// 
        /// </summary>
        protected readonly CSharpToCpp CSharpToCpp = new CSharpToCpp();
       
        private readonly ILogger _logger;
        private readonly BuildMode _buildMode;
        /// <summary>
        /// 
        /// </summary>
        public static string ChainId;


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
        public RpcConnection(IConfig config, bool wallet = true)
        {
            Config = config;
            _uri = $"http://{Config.Hostname}:{(wallet ? Config.WalletPort : config.DaemonPort)}{config.Api}";
            _client = new HttpClient();
            _jsonRpc = Config.Version;

            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;

            //_logger = new Logger(config, assemblyname);


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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="params"></param>
        /// <param name="type"></param>
        /// <returns></returns>
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
                result = ProcessRequestOnDaemon(method, @params, type).Result;
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
                var transresponse = trans.CreateSimpleTransaction(contentdata);
                if (transresponse == null) return null;

                var transaction = JsonConvert.SerializeObject(transresponse.Result);
                
                var digest = key.GetTransactionDigest(transaction,ChainId,new byte[64]);
           
                var signature = key.SignDigest(digest, privateKey, new byte[130]);
                var response = key.AddSignature(transaction, signature,new byte[transaction.Length + 200]);
                finalResponse = trans.BroadcastTransaction(response);          
            }
            catch (Exception ex)
            {                
 
                throw;
            }

            return finalResponse;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="contentdata"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected TransactionResponse GetSimpleTransaction<T>(T contentdata)
        {
            var trans = new Transaction(Config);
            TransactionResponse transresponse;
            try
            {               
                transresponse = trans.CreateSimpleTransaction(contentdata);
                if (transresponse == null) return null;                        
            }
            catch (Exception ex)
            {
              
                
              
                throw;
            }

            return transresponse;
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
            TransactionResponse finalResponse;
            try
            {
            
                var transresponse = await trans.CreateSimpleTransactionAsync(contentdata);
                if (transresponse == null) return null;

                var transaction = JsonConvert.SerializeObject(transresponse.Result);
                var digest = key.GetTransactionDigest(transaction,ChainId,new byte[64]);
                var signature = key.SignDigest(digest, privateKey, new byte[130]);
                var response = key.AddSignature(transaction, signature,new byte[transaction.Length + 200]);
               
                finalResponse = await trans.BroadcastTransactionAsync(response);          
            }
            catch (Exception ex)
            {
                
                throw;
            }

            return finalResponse;
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

                if (response.Contains("error"))
                {

                    try
                    {
                        if (_buildMode == BuildMode.Test)
                        {
                            System.Uri uri = new Uri(Config.LoggingServer);
                            string hostname = uri.Host;
                            var loggerConfig = new LoggerConfiguration().WriteTo.Graylog(new GraylogSinkOptions
                            {
                                
                                HostnameOrAddress = hostname,
                                Port = Config.LoggingPort

                            }).CreateLogger();


                            loggerConfig.Write(LogEventLevel.Error, response);

                        }

                        throw new SophiaBlockchainException(response);
                    }
                    catch (SophiaBlockchainException sx)
                    {               
                        throw sx;
                    }
                }
            }
            catch (HttpRequestException ex)
            {               
                               throw;
            }
            
           return response;
        }
        
        /// <summary>
        /// Processes the request and gets the response from the server
        /// </summary>
        /// <param name="methodname">the method name to call</param>
        /// <param name="params">the paramaters to pass with the method</param>
        /// <param name="type"></param>
        /// <returns>the http response from the server</returns>
        private async Task<string> ProcessRequestOnDaemon(string methodname,  object @params , Type type = null)
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
             
                var httpResponse = _client.PostAsync(Config.DaemonEndpoint, new StringContent(json, Encoding.UTF8)).Result;

                if (httpResponse == null) return response;
                response = await httpResponse.Content.ReadAsStringAsync();

                if (response.Contains("error"))
                {
                   
                    if (_buildMode == BuildMode.Test)
                    {          
                        var loggerConfig = new LoggerConfiguration().WriteTo.Graylog(new GraylogSinkOptions
                        {
                            HostnameOrAddress = Config.LoggingServer,
                            Port = Config.LoggingPort
                                     
                        }).CreateLogger();
           
            
                        loggerConfig.Write(LogEventLevel.Error,response);
                        
                    }
                    throw new SophiaBlockchainException(response); 
                }
            }
            catch (HttpRequestException ex)
            {               
               
                throw ex;
            }
            catch (SophiaBlockchainException sx)
            {               
               
                throw sx;
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