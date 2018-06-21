using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.net.Communication;
using Alexandria.net.Logging;
using Alexandria.net.Messaging.Responses.DTO;
using Alexandria.net.Settings;
using Newtonsoft.Json;


namespace Alexandria.net.API.WalletFunctions
{
    /// <inheritdoc />
    /// <para>
    /// Wallet Network Functions
    /// </para>
    public class Network : RpcConnection
    {
        private readonly ILogger _logger;
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Wallet Constructor
        /// </summary>
        /// <param name="config"></param>
        public Network(IConfig config) :
            base(config)
        {
            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(LoggingType.Server, assemblyname);
        }

        #endregion

        /// <summary>
        /// Returns true if the library is connected to a backend.
        /// </summary>
        /// <returns>Returns true if success and false for failed try</returns>
        private ActiveWitnessResponse IsConnected()
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var result = SendRequest(reqname);
                
                var contentdata = JsonConvert.DeserializeObject<ActiveWitnessResponse>(result);
                return contentdata;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
            
        }

        /// <summary>
        /// Connects to the WS endpoint.
        /// </summary>
        /// <param name="host">string host</param>
        /// <param name="port">int port</param>
        /// <returns>Returns true if success and false for failed try</returns>
        private bool Connect(string host, int port)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {host, port};
                var result = SendRequest(reqname, @params);
                return result == "true";
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
            
        }

        
        /// <summary>
        /// Get hash including chain ID (digest), ready to be signed, of a JSON formatted transaction.
        /// </summary>
        /// <param name="transaction">string transaction</param>
        /// <returns>Returns char[] transaction digest</returns>
        private char[] GetTransactionDigest(string transaction)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {transaction};
                return SendRequest(reqname, @params).ToCharArray();
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }

        /// <summary>
        /// </summary>
        /// <param name="sender">string sender</param>
        /// <param name="recipients">List of string recipients</param>
        /// <param name="appId">ulong appId</param>
        /// <param name="document">string document</param>
        /// <returns></returns>
        public string MakeCustomJsonOperation(string sender, List<string> recipients, ulong appId, string document)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {sender, recipients, appId, document};
                return SendRequest(reqname, @params);
            }
            catch(Exception ex)
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
        public string MakeCustomBinaryOperation(string sender, List<string> recipients, ulong appId,
            List<char> document)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {sender, recipients, appId, document};
                return SendRequest(reqname, @params);
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
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
        public string MakeCustomBinaryBase58Operation(string sender, List<string> recipients, ulong appId,
            string document)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {sender, recipients, appId, document};
                return SendRequest(reqname, @params);
            }
            catch(Exception ex)
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
        public Dictionary<ulong, ReceiverRecipe> GetReceivedDocuments(ulong appId, string searchType,
            string account, string start, uint count)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {appId, searchType, account, start, count};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<Dictionary<ulong, ReceiverRecipe>>(result);
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }

        
        /// <summary>
        /// Form a transaction out of existing operations.
        /// </summary>
        /// <param name="operations"></param>
        /// <returns></returns>
        public string MakeTransaction(List<string> operations)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {operations};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<string>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }


        /// <summary>
        /// Add signature to the transaction. Useful fo rmulti-sig transactions,
        /// where all the signatures have to be calculated and added one by one.
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public string AddSignature(string transaction, char[] signature)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {transaction, signature};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<string>(result);
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
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool SendSignedTransaction(string transaction)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {transaction};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<bool>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }
    }
}