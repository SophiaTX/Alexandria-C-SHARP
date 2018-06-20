/*using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Alexandria.net.Core
{
    public class DaemonOld
    {
        #region Member Variables

        private const string DefaultAddress = "http://13.95.151.252";
        private const int DefaultPort = 9593;
        private const string JsonRpc = "2.0";
        private const string SendTransaction = "send_trans";
        private readonly BlockchainConnector _connector;
        private Timer _timer;
        private const int TimeoutInMilliseconds = 20000;
        private readonly string _receiverAddress;
        private Thread _thread;
        private readonly Message _message;
        #endregion

        #region Constructors

        public Daemon(string receiveraddress, string dbname, string ipaddress = null, int? port = null)
        {
            _receiverAddress = receiveraddress;
            _connector = new BlockchainConnector(ipaddress ?? DefaultAddress, port ?? DefaultPort);
        }

        #endregion

        #region EventHandlers

        /// <summary>   Event queue for all listeners interested in accountCreated events. </summary>
        public event DataReceivedEventHandler OnDataReceivedBlockChainEvent;

        //public event MessageIdUpdateEventHandler MessageIdUpdateEvent;

        #endregion

        #region Events

        private void SophiaClient_DataReceived(object o)
        {
            _timer = new Timer(CheckIfDataReceived, null, TimeoutInMilliseconds, Timeout.Infinite);
        }

        #endregion

        #region Methods
        public void StartListeningForMessages()
        {
            //listening thread for incoming messages
            var t = new ParameterizedThreadStart(SophiaClient_DataReceived);
            _thread = new Thread(t)
            {
                Name = "SophiaDataReceiver",
                Priority = ThreadPriority.Normal,
                IsBackground = true
            };
           _thread.Start();
        }

        public void StopListeningForMessages()
        {
            _thread.Abort();
        }

        /// <summary>
        ///     Converts data to the blockchain format for SophiaTX and sends it to the blockchain
        /// </summary>
        /// <typeparam name="T">The Object Type to send</typeparam>
        /// <param name="object">The object data to send</param>
        /// <param name="receiverpublickey">the receivers public key</param>
        /// <param name="sender">the message sender</param>
        /// <param name="receiver">the message receiver</param>
        /// <param name="transId"></param>
        /// <param name="methodname">the method that should be called</param>
        public async Task<DataRequestResponse> SendData<T>(T @object, string receiverpublickey,
            string sender, string receiver, string transId, string methodname = "send_trans")
        {
            try
            {
                var jsondata = JsonConvert.SerializeObject(@object);

                var requestobj = new
                {
                    jsonrpc = JsonRpc,
                    method = SendTransaction,
                    @params = new List<string>
                    {
                        methodname,
                        transId,
                        sender,
                        receiver,
                        jsondata
                    },
                    id = transId
                };
                var requestjson = JsonConvert.SerializeObject(requestobj);
                var reqresp = new DataRequestResponse {Request = requestjson};
                //send and await the response   
                var response = await _connector.SendAsync(requestjson);
                if (response == null) return null;
                var content = await response.Content.ReadAsStringAsync();
                reqresp.Response = JsonConvert.DeserializeObject<DataResponse>(content);
                return reqresp;
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message);
                throw;
            }
        }

        /// <summary>
        ///     Returns the decrypted data based on the object type passed in to the methods
        /// </summary>
        /// <typeparam name="T">The Object type to return</typeparam>
        /// <param name="args">the data received arguements</param>
        /// <param name="receiver">the receiver id</param>
        /// <param name="receiverprivatekey">the sender private key</param>
        /// <returns>the deserialized object data</returns>
        public T GetData<T>(DataReceivedEventArgs args, string receiver, string receiverprivatekey = "")
        {
            try
            {
                if (!args.Message.Data.Contains("{")) return default(T);
                return args.Message.Receiver != receiver
                    ? default(T)
                    : JsonConvert.DeserializeObject<T>(args.Message.Data);
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        ///     Returns the decrypted data based on the object type passed in to the methods
        /// </summary>
        /// <typeparam name="T">The Object type to return</typeparam>
        /// <param name="args">the data received arguements</param>
        /// <param name="receiver">the list of receiver ids</param>
        /// <param name="receiverprivatekey">the sender private key</param>
        /// <returns>the deserialized object data</returns>
        public T GetDataMultiReceiver<T>(DataReceivedEventArgs args, List<string> receiver,
            string receiverprivatekey = "")
        {
            try
            {
                if (!args.Message.Data.Contains("{")) return default(T);
                return !receiver.Contains(args.Message.Receiver)
                    ? default(T)
                    : JsonConvert.DeserializeObject<T>(args.Message.Data);
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        ///     Returns the decrypted data based on the object type passed in to the methods
        /// </summary>
        /// <typeparam name="T">The Object type to return</typeparam>
        /// <param name="args">the data received arguements</param>
        /// <param name="receiverprivatekey">the sender private key</param>
        /// <returns>the deserialized object data</returns>
        public T GetDataNoReceiverCheck<T>(DataReceivedEventArgs args, string receiverprivatekey = "")
        {
            try
            {
                return !args.Message.Data.Contains("{")
                    ? default(T)
                    : JsonConvert.DeserializeObject<T>(args.Message.Data);
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// Gets the data from the blockchain with the receiver address {
        /// "jsonrpc":"2.0","method":"recv_trans","params":["{0}" "{1}"],"id":{2}}
        /// </summary>
        private async void CheckIfDataReceived(object state)
        {
            await GetObjects();
            _message.SaveJson();
            _timer.Change(TimeoutInMilliseconds, Timeout.Infinite);
        }


        public async Task GetObjects()
        {
            var result = true;
            do
            {
                var reqresp = await GetObject();
                if (reqresp.Response.Result[0] == null)
                {
                    result = false;
                }
                else
                {
                    var content = reqresp.Response.Result[0];
                    if (content.Receiver == _receiverAddress)
                        OnDataReceivedBlockChainEvent?.Invoke(this, new DataReceivedEventArgs(content));
                    _message.SetNextId();                   
                }
            } while (result);
        }

        public async Task<ReceiveDataRequestResponse> GetObject()
        {
            try
            {
                var requestobj = new
                {
                    jsonrpc = JsonRpc,
                    method = "get_object",
                    @params = new List<string> {_message.MessageId},
                    id = "1"
                };
                var requestjson = JsonConvert.SerializeObject(requestobj);
                var reqresp = new ReceiveDataRequestResponse { Request = requestjson };
                //send and await the response   
                var response = await _connector.SendAsync(requestjson);
                if (response == null) return null;
                var content = await response.Content.ReadAsStringAsync();
                reqresp.Response = JsonConvert.DeserializeObject<ReceiveDataResponse>(content);
                return reqresp;
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message);
                throw;
            }
        }
        #endregion
    }
}*/