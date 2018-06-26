using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.net.Communication;
using Alexandria.net.Enums;
using Alexandria.net.Extensions;
using Alexandria.net.Logging;
using Alexandria.net.Messaging.Receiver;
using Alexandria.net.Messaging.Responses.DTO;
using Alexandria.net.Settings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ILogger = Alexandria.net.Logging.ILogger;
using Logger = Alexandria.net.Logging.Logger;

namespace Alexandria.net.API.WalletFunctions
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class Data : RpcConnection
    {
        #region member variables

        private readonly ILogger _logger;
        private readonly IBlockchainConfig _blockchainConfig;

        #endregion

        #region ctor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config">the Configuration paramaters for the endpoint and ports</param>
        /// <param name="blockchainConfig"></param>
        public Data(IConfig config, IBlockchainConfig blockchainConfig) : base(config)
        {
            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(LoggingType.Server, assemblyname);
            _blockchainConfig = blockchainConfig;
        }

        #endregion

        #region PublicMethods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="senderdata"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public TransactionResponse Send(SenderData senderdata)
        {
            try
            {
                var customjsonrpc = MakeCustomJsonOperation(senderdata.Sender, senderdata.Recipients, senderdata.AppId,
                    senderdata.FormattedDoc);
                if (customjsonrpc == null) return null;
                var resp = StartBroadcasting(customjsonrpc.result, senderdata.PrivateKey);
                return resp;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="senderdata"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public bool SendBinary(SenderData senderdata, string privateKey)
        {
            var result = false;
            try
            {
                var operations = new List<AccountResponse>();
                foreach (var doc in senderdata.DocumentChars)
                {
                    var operation = MakeCustomBinaryOperation(senderdata.Sender, senderdata.Recipients,
                        senderdata.AppId,
                        doc);
                    if (operation != null)
                        operations.Add(operation);
                }

                if (operations.Count == 0) return false;
                
                foreach (var operation in operations)
                {
                    var resp = StartBroadcasting(operation.result, privateKey);
                    if (resp != null)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }

            return result;
        }


       

        /// <summary>
        /// Allowed options for search_type are "by_sender", "by_recipient", "by_sender_datetime", "by_recipient_datetime".
        /// Account is then either sender or recevier, and start is either index od ISO time stamp.
        /// </summary>
        /// <param name="appId">The Id of the application which we are receiving for</param>
        /// <param name="searchType">based on the Search Type Enum</param>
        /// <param name="account">Account Owner - sender or receiver</param>
        /// <param name="start">Start by value - index or ISO time stamp</param>
        /// <param name="count"></param>
        /// <returns></returns>
        public Dictionary<ulong, ReceiverRecipe> Receive(ulong appId, SearchType searchType, AccountOwner account,
            StartBy start,
            uint count)
        {
            Dictionary<ulong, ReceiverRecipe> result;
            try
            {
                result = GetReceivedDocuments(appId, searchType.GetStringValue(), account.GetStringValue(),
                    start.GetStringValue(),
                    count);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return result;
        }

        #endregion
        
        #region PrivateMethods
                /// <summary>
        /// </summary>
        /// <param name="sender">string sender</param>
        /// <param name="recipients">List of string recipients</param>
        /// <param name="appId">ulong appId</param>
        /// <param name="document">string document</param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="recipients"></param>
        /// <param name="appId"></param>
        /// <param name="document"></param>
        /// <returns></returns>
        private AccountResponse MakeCustomBinaryOperation(string sender, List<string> recipients, ulong appId,
            List<char> document)
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="recipients"></param>
        /// <param name="appId"></param>
        /// <param name="document"></param>
        /// <returns></returns>
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
        /// <param name="appId"></param>
        /// <param name="searchType"></param>
        /// <param name="account"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private Dictionary<ulong, ReceiverRecipe> GetReceivedDocuments(ulong appId, string searchType,
            string account, string start, uint count)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {appId, searchType, account, start, count};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<Dictionary<ulong, ReceiverRecipe>>(result);
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