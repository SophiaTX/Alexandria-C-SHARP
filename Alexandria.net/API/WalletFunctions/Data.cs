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
        public bool Send(SenderData senderdata)
        {
            var result = false;
            try
            {
                //var operations = new List<AccountResponse>();
                foreach (var doc in senderdata.Documents)
                {
                    var operation = MakeCustomJsonOperation(senderdata.Sender, senderdata.Recipients, senderdata.AppId,
                        doc);
                    if (operation == null) continue;
                    var resp = StartBroadcasting(operation, senderdata.PrivateKey);
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
        /// Send custom JSON data
        /// </summary>
        /// <param name="AppID">Application ID</param>
        /// <param name="FromAccount">from Sender</param>
        /// <param name="ToAccount">to List of receivers</param>
        /// <param name="Json">json Data formatted in JSON "{}"</param>
        /// <param name="privateKey">Accounts Private key</param>
        /// <returns></returns>
        public TransactionResponse MakeCustomJsonOperation(int AppID, string FromAccount,string ToAccount, string Json,string privateKey)//SenderData senderdata)
        {
            //var result = false;
            
            List<string> Recipients= new List<string>{ToAccount};
            try
            {
                //var operations = new List<AccountResponse>();
//                foreach (var doc in senderdata.Documents)
//                {
//                    var operation = MakeCustomJsonOperation(senderdata.Sender, senderdata.Recipients, senderdata.AppId,
//                        doc);
//                    if (operation != null)
//                        operations.Add(operation);
//                }

//                if (operations.Count == 0) return false;
//
//                foreach (var operation in operations)
//                {
//                    var resp = StartBroadcasting(operation, senderdata.PrivateKey);
//                    if (resp != null)
//                    {
//                        result = true;
//                    }
//                    else
//                    {
//                        result = false;
//                        break;
//                    }
//                }
                
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {AppID,FromAccount,Recipients,Json};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
                var response = StartBroadcasting(contentdata, privateKey);
                return response;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }

            //return result;
        }

        
        /// <summary>
        /// Send custom data data
        /// </summary>
        /// <param name="AppID">app_id Application ID</param>
        /// <param name="FromAccount">from Sender</param>
        /// <param name="ToAccounts">to List of receivers</param>
        /// <param name="Data">data Data formatted in base58</param>
        /// <param name="privateKey">Accounts Primary key</param>
        /// <returns></returns>
        public TransactionResponse MakeCustomBinaryOperation(int AppID, string FromAccount,string ToAccounts, string Data,string privateKey)
        {
            //var result = false;
            try
            {
//                var operations = new List<AccountResponse>();
//                foreach (var doc in senderdata.DocumentChars)
//                {
//                    var operation = MakeCustomBinaryOperation(senderdata.Sender, senderdata.Recipients,
//                        senderdata.AppId,
//                        doc);
//                    if (operation != null)
//                        operations.Add(operation);
//                }
//
//                if (operations.Count == 0) return false;
//                
//                foreach (var operation in operations)
//                {
//                    var resp = StartBroadcasting(operation, privateKey);
//                    if (resp != null)
//                    {
//                        result = true;
//                    }
//                    else
//                    {
//                        result = false;
//                        break;
//                    }
//                }
                List<string> Recipients= new List<string>{ToAccounts};
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {AppID,FromAccount,Recipients,Data};
                var result = SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
                var response = StartBroadcasting(contentdata, privateKey);
                return response;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }

            //return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="senderdata"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        private bool SendBinaryBase58(SenderData senderdata, string privateKey)
        {
            var result = false;
            try
            {
                var operations = new List<AccountResponse>();
                foreach (var doc in senderdata.Documents)
                {
                    var operation = MakeCustomBinaryBase58Operation(senderdata.Sender, senderdata.Recipients,
                        senderdata.AppId, doc);
                    operations.Add(operation);
                }

                if (operations.Count == 0) return false;

                foreach (var operation in operations)
                {
                    var resp = StartBroadcasting(operation, privateKey);
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
       /// Get all recevied custom jsons and data.
       /// </summary>
       /// <param name="AppID">app_id Application ID</param>
       /// <param name="SearchType">search_type One of "by_sender", "by_recipient", "by_sender_datetime", "by_recipient_datetime"</param>
       /// <param name="AccountName">account_name Name of the relevant (sender/recipient) account</param>
       /// <param name="Start">start Either timestamp in ISO format or index</param>
       /// <param name="count">count Number of items to retrieve</param>
       
        public ReceivedDocumentResponse GetReceivedDocuments(uint AppID, string SearchType, string AccountName,
            string Start,
            uint count)
        {
            //Dictionary<ulong, ReceiverRecipe> result;
            try
            {
//                result = GetReceivedDocuments(appId, searchType.GetStringValue(), account.GetStringValue(),
//                    start.GetStringValue(),
//                    count);
                
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {AppID,AccountName,SearchType,Start,count};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                var response = JsonConvert.DeserializeObject<ReceivedDocumentResponse>(result);
                
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

           // return result;
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
        private AccountResponse MakeCustomJsonOperation(string sender, List<string> recipients, uint appId,
            string document)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {appId, sender, recipients, document};
                var response = SendRequest(reqname, @params);
                var rrrrrr = JsonConvert.DeserializeObject<CustomJsonResponse>(response).result;
                return null;
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