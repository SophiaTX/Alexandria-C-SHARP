using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Alexandria.net.Communication;
using Alexandria.net.Enums;
using Alexandria.net.Events;
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
        private Thread _thread;
        private Timer _timer;
        private int _timeoutInMilliseconds = 20000;
        private ulong _appId = 1;
        private string _accountName = "initminer";
        private SearchType _searchType;
        private string _startBy;
        private uint _count;

        #endregion

        #region ctor

        /// <summary>
        /// Data object constructor
        /// </summary>
        /// <param name="config">the Configuration paramaters for the endpoint and ports</param>
        public Data(IConfig config) : base(config)
        {
            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(config, assemblyname);
        }

        #endregion
        
        #region EventHandlers

        /// <summary>   Event queue for all listeners interested in accountCreated events. </summary>
        public event DataReceivedEventHandler OnDataReceivedBlockChainEvent;

        #endregion
        
        #region Events
        
        private void SophiaClient_DataReceived(object o)
        {
            _timer = new Timer(CheckIfDataReceived, null, _timeoutInMilliseconds, Timeout.Infinite);
        }
        #endregion
        

        #region Public Methods

        /// <summary>
        /// Starts the timer for automatic collection of messages
        /// </summary>
        /// <param name="count"></param>
        /// <param name="frequency">the timer frequency to be set, default is 20 seconds (milliseconds)</param>
        /// <param name="appid"></param>
        /// <param name="accountname"></param>
        /// <param name="searchtype"></param>
        /// <param name="startby"></param>
        public void StartListening(string appid, string accountname, SearchType searchtype, string startby, uint count,
            int frequency = 20000)
        {
            try
            {
                _searchType = searchtype;
                _startBy = startby;
                _count = count;
                var t = new ParameterizedThreadStart(SophiaClient_DataReceived);
                _thread = new Thread(t)
                {
                    Name = "SophiaDataReceiver",
                    Priority = ThreadPriority.Normal,
                    IsBackground = true
                };
                _thread.Start();
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
        /// <param name="data">the data to send, this is a type parameter, so any data type can be sent</param>
        /// <param name="senderinfo">the sender info required for the transaction</param>
        /// <param></param>
        /// <returns>the transaction response data</returns>
        public TransactionResponse SendJson<T>(T data, JsonData senderinfo)
        {
            try
            {
                var jsondata = JsonConvert.SerializeObject(data);
                var customjsonrpc = MakeCustomJsonOperation(senderinfo.Sender, senderinfo.Recipients, senderinfo.AppId,
                    jsondata);
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
        /// <param name="data">the data to send, this is a type parameter, so any data type can be sent</param>
        /// <param name="jsonData">the sender info required for the transaction</param>
        /// <param></param>
        /// <returns>the transaction response data</returns>
        public async Task<TransactionResponse> SendJsonAsync<T>(T data, JsonData jsonData)
        {
            try
            {
                var jsondata = JsonConvert.SerializeObject(data);
                var customjsonrpc = await MakeCustomJsonOperationAsync(jsonData.Sender, jsonData.Recipients,
                    jsonData.AppId,
                    jsondata);
                if (customjsonrpc == null) return null;
                var resp = await StartBroadcastingAsync(customjsonrpc.Result, jsonData.PrivateKey);
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
        /// <param name="jsonData">the sender info required for the transaction</param>
        /// <param></param>
        /// <returns>the transaction response data</returns>
        public TransactionResponse SendJson(JsonData jsonData)
        {
            try
            {
                var customjsonrpc = MakeCustomJsonOperation(jsonData.Sender, jsonData.Recipients, jsonData.AppId,
                    jsonData.JsonDoc);
                if (customjsonrpc == null) return null;
                var resp = StartBroadcasting(customjsonrpc.Result, jsonData.PrivateKey);
                return resp;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }
        
        /// <summary>
        /// Sends the parsed data asynchronously to the blockchain 
        /// </summary>
        /// <param name="jsonData">the sender info required for the transaction</param>
        /// <param></param>
        /// <returns>the transaction response data</returns>
        public async Task<TransactionResponse> SendJsonAsync(JsonData jsonData)
        {
            try
            {
                var customjsonrpc = await MakeCustomJsonOperationAsync(jsonData.Sender, jsonData.Recipients, jsonData.AppId,
                    jsonData.JsonDoc);
                if (customjsonrpc == null) return null;
                var resp = await StartBroadcastingAsync(customjsonrpc.Result, jsonData.PrivateKey);
                return resp;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Send custom data data to the blockchain
        /// </summary>
        /// <param name="binaryData"></param>
        /// <returns></returns>
        public TransactionResponse SendBinary(BinaryData binaryData)
        {
            try
            {
                var customjsonrpc = MakeCustomBinaryOperation(binaryData.AppId, binaryData.Sender, binaryData.Recipients,
                    binaryData.BinaryDoc);
                if (customjsonrpc == null) return null;
                var resp = StartBroadcasting(customjsonrpc.Result, binaryData.PrivateKey);
                return resp;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Send custom data data asynchronously to the blockchain
        /// </summary>
        /// <param name="binaryData">Data collection</param>
        /// <returns></returns>
        public async Task<TransactionResponse> SendBinaryAsync(BinaryData binaryData)
        {
            try
            {
                var customjsonrpc = await MakeCustomBinaryOperationAsync(binaryData.AppId, binaryData.Sender, binaryData.Recipients,
                    
                    binaryData.BinaryDoc);
                if (customjsonrpc == null) return null;
                var resp = await StartBroadcastingAsync(customjsonrpc.Result, binaryData.PrivateKey);
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
        /// <param name="appId">The Id of the application which we are receiving for</param>
        /// <param name="searchType">based on the Search Type Enum</param>
        /// <param name="accountName">Account Owner - sender or receiver</param>
        /// <param name="start">Start by value - index or ISO timestamps</param>
        /// <param name="count"></param>
        /// <returns>the received document response data</returns>
        public async Task<ReceivedDocumentResponse> ReceiveAsync(ulong appId, string accountName, SearchType searchType,
            string start, uint count)
        {
            ReceivedDocumentResponse result;
            try
            {
                result = await GetReceivedDocumentsAsync(appId, accountName, searchType,
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
        public async Task<T> ReceiveAsync<T>(T type, ulong appId, string accountName, SearchType searchType,
            string start, uint count)
        {
            try
            {
                var result = await GetReceivedDocumentsAsync(appId, accountName, searchType, start, count);
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
        /// Gets the data from the blockchain with the receiver address {
        /// "jsonrpc":"2.0","method":"recv_trans","params":["{0}" "{1}"],"id":{2}}
        /// </summary>
        private async void CheckIfDataReceived(object state)
        {
            var response = await ReceiveAsync( _appId, _accountName, _searchType, _startBy, _count);
            if (response.Result[0] != null)
            {
                OnDataReceivedBlockChainEvent?.Invoke(this, new DataReceivedEventArgs(response));
            }

            //_message.SaveJson();
            _timer.Change(_timeoutInMilliseconds, Timeout.Infinite);
        }

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

        private async Task<CustomJsonResponse> MakeCustomJsonOperationAsync(string sender, List<string> recipients,
            uint appId, string document)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {appId, sender, recipients, document};
                var response = await SendRequestAsync(reqname, @params);
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
        private async Task<AccountResponse> MakeCustomBinaryOperationAsync(ulong appId, string sender,
            List<string> recipients, string document)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {appId, sender, recipients, document};
                var response = await SendRequestAsync(reqname, @params);
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
        private async Task<ReceivedDocumentResponse> GetReceivedDocumentsAsync(ulong appId, string account,
            SearchType searchType, string start, uint count)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {appId, account, searchType.GetStringValue(), start, count};
                var result = await SendRequestAsync(reqname, @params);
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