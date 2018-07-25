using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.net.Communication;
using Alexandria.net.Enums;
using Alexandria.net.Extensions;
using Alexandria.net.Logging;
using Alexandria.net.Messaging.Receiver;
using Alexandria.net.Messaging.Responses;
using Alexandria.net.Settings;
using Newtonsoft.Json;
using ILogger = Alexandria.net.Logging.ILogger;
using Logger = Alexandria.net.Logging.Logger;

namespace Alexandria.net.API
{
    /// <inheritdoc />
    /// <summary>
    /// Sophia Blockchain Data functions
    /// </summary>
    public class Data : RpcConnection
    {
        #region member variables

        private readonly ILogger _logger;

        #endregion

        #region ctor

        /// <summary>
        /// Data object constructor
        /// </summary>
        /// <param name="config">the Configuration paramaters for the endpoint and ports</param>
        public Data(IConfig config) : base(config)
        {
            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(config, LoggingType.Server, assemblyname);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sends the parsed data to the blockchain
        /// </summary>
        /// <param name="data">the data to send, this is a type parameter, so any data type can be sent</param>
        /// <param name="senderinfo">the sender info required for the transaction</param>
        /// <param></param>
        /// <returns>the transaction response data</returns>
        public TransactionResponse Send<T>(T data, SenderData senderinfo)
        {
            try
            {
                var customjsonrpc = MakeCustomJsonOperation(senderinfo.Sender, senderinfo.Recipients, senderinfo.AppId,
                    senderinfo.Document);
                if (customjsonrpc == null) return null;
                var resp = StartBroadcasting(customjsonrpc.Result, senderinfo.PrivateKey);
                return resp;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Sends the parsed data to the blockchain
        /// </summary>
        /// <param name="senderinfo">the sender info required for the transaction</param>
        /// <param></param>
        /// <returns>the transaction response data</returns>
        public TransactionResponse Send(SenderData senderinfo)
        {
            try
            {
                var customjsonrpc = MakeCustomJsonOperation(senderinfo.Sender, senderinfo.Recipients, senderinfo.AppId,
                    senderinfo.Document);
                if (customjsonrpc == null) return null;
                var resp = StartBroadcasting(customjsonrpc.Result, senderinfo.PrivateKey);
                return resp;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Send custom data data
        /// </summary>
        /// <param name="senderdata">Data collection</param>
        /// <returns></returns>
        public TransactionResponse SendBinary(SenderData senderdata)
        {
            try
            {
                var customjsonrpc = MakeCustomBinaryOperation(senderdata.AppId, senderdata.Sender, senderdata.Recipients,
                    
                    senderdata.DocumentChars);
                if (customjsonrpc == null) return null;
                var resp = StartBroadcasting(customjsonrpc.Result, senderdata.PrivateKey);
                return resp;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Allowed options for search_type are "by_sender", "by_recipient", "by_sender_datetime", "by_recipient_datetime".
        /// Account is then either sender or recevier, and start is either index od ISO time stamp.
        /// </summary>
        /// <param name="appId">The Id of the application which we are receiving for</param>
        /// <param name="searchType">based on the Search Type Enum</param>
        /// <param name="accountName">Account Owner - sender or receiver</param>
        /// <param name="start">Start by value - index or ISO timestamps</param>
        /// <param name="count"></param>
        /// <returns>the received document response data</returns>
        public ReceivedDocumentResponse Receive(ulong appId, string accountName, SearchType searchType, string start,
            uint count)
        {
            ReceivedDocumentResponse result;
            try
            {
                result = GetReceivedDocuments(appId, accountName, searchType,
                    start,
                    count);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return result;
        }

        /// <summary>
        /// Allowed options for search_type are "by_sender", "by_recipient", "by_sender_datetime", "by_recipient_datetime".
        /// Account is then either sender or recevier, and start is either index od ISO time stamp.
        /// </summary>
        /// <param name="type">the receive type object</param>
        /// <param name="appId">The Id of the application which we are receiving for</param>
        /// <param name="searchType">based on the Search Type Enum</param>
        /// <param name="accountName">Account Owner - sender or receiver</param>
        /// <param name="start">Start by value - index or ISO timestamps</param>
        /// <param name="count"></param>
        /// <returns>the received document response data</returns>
        public T Receive<T>(T type, ulong appId, string accountName, SearchType searchType, string start, uint count)
        {
            try
            {
                var result = GetReceivedDocuments(appId, accountName, searchType, start, count);
                return JsonConvert.DeserializeAnonymousType(result.Result.ToString(), type);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion
        
        #region Private Methods
        /// <summary>
        /// creates the custom json operation 
        /// </summary>
        /// <param name="sender">string sender</param>
        /// <param name="recipients">List of string recipients</param>
        /// <param name="appId">ulong appId</param>
        /// <param name="document">string document</param>
        /// <returns>the json response data response</returns>
        private CustomJsonResponse MakeCustomJsonOperation(string sender, List<string> recipients, uint appId,
            string document)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {appId, sender, recipients, document};
                var response = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<CustomJsonResponse>(response);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// creates the custom json operation 
        /// </summary>
        /// <param name="sender">string sender</param>
        /// <param name="recipients">List of string recipients</param>
        /// <param name="appId">the application id</param>
        /// <param name="document">string document</param>
        /// <returns>the account response data </returns>
        private AccountResponse MakeCustomBinaryOperation(ulong appId, string sender, List<string> recipients, 
            string document)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {appId, sender, recipients, document};
                var response = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<AccountResponse>(response);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }


        /// <summary>
        /// creates the custom json operation 
        /// </summary>
        /// <param name="sender">string sender</param>
        /// <param name="recipients">List of string recipients</param>
        /// <param name="appId">the application id</param>
        /// <param name="document">string document</param>
        /// <returns>the account response data </returns>
        private AccountResponse MakeCustomBinaryBase58Operation(string sender, List<string> recipients, ulong appId,
            string document)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {sender, recipients, appId, document};
                var response = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<AccountResponse>(response);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Allowed options for search_type are "by_sender", "by_recipient", "by_sender_datetime", "by_recipient_datetime".
        /// Account is then either sender or recevier, and start is either index od ISO time stamp.
        /// </summary>
        /// <param name="appId">the application id</param>
        /// <param name="searchType"></param>
        /// <param name="account"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private ReceivedDocumentResponse GetReceivedDocuments(ulong appId, 
            string account,SearchType searchType, string start, uint count)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {appId, account,searchType.GetStringValue(),  start, count};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<ReceivedDocumentResponse>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }
        #endregion
    }
}