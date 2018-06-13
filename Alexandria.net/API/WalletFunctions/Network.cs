using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.net.Communication;
using Newtonsoft.Json;

namespace Alexandria.net.API.WalletFunctions
{
    /// <inheritdoc />
    public class Network : RpcConnection
    {

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Wallet Constructor
        /// </summary>
        /// <param name="hostname">the rpc endpoint ip address</param>
        /// <param name="port">the rpc endpoint post</param>
        protected Network(string hostname = "127.0.0.1", ushort port = 8091) : base(hostname, port)
        {
        }

        #endregion

        /// <summary>
        /// Returns true if the library is connected to a backend.
        /// </summary>
        /// <returns></returns>
        public bool isConnected()
        {
            var result = SendRequest(MethodBase.GetCurrentMethod().Name);
            return result == "true";
        }

        /// <summary>
        /// Connects to the WS endpoint.
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public bool connect(string host, int port)
        {
            var @params = new ArrayList {host, port};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Get hash including chain ID (digest), ready to be signed, of a JSON formatted transaction.
        /// </summary>
        /// <returns></returns>
        public char[] getTransactionDigest(string transaction)
        {
            var @params = new ArrayList {transaction};
            return SendRequest(MethodBase.GetCurrentMethod().Name, @params).ToCharArray();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="recipients"></param>
        /// <param name="app_id"></param>
        /// <param name="document"></param>
        /// <returns></returns>
        public string makeCustomJsonOperation(string sender, List<string> recipients, ulong app_id, string document)
        {
            var @params = new ArrayList {sender, recipients, app_id, document};
            return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="recipients"></param>
        /// <param name="app_id"></param>
        /// <param name="document"></param>
        /// <returns></returns>
        public string makeCustomBinaryOperation(string sender, List<string> recipients, ulong app_id,
            List<char> document)
        {
            var @params = new ArrayList {sender, recipients, app_id, document};
            return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="recipients"></param>
        /// <param name="app_id"></param>
        /// <param name="document"></param>
        /// <returns></returns>
        public string makeCustomBinaryBase58Operation(string sender, List<string> recipients, ulong app_id,
            string document)
        {
            var @params = new ArrayList {sender, recipients, app_id, document};
            return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
        }

        /// <summary>
        /// Allowed options for search_type are "by_sender", "by_recipient", "by_sender_datetime", "by_recipient_datetime".
        /// Account is then either sender or recevier, and start is either index od ISO time stamp.
        /// </summary>
        /// <param name="app_id"></param>
        /// <param name="search_type"></param>
        /// <param name="account"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public Dictionary<ulong, ReceiverRecipe> get_received_documents(ulong app_id, string search_type,
            string account, string start, uint count)
        {
            var @params = new ArrayList {app_id, search_type, account, start, count};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<Dictionary<ulong, ReceiverRecipe>>(result);
        }

    }
}