using System;
using System.Collections;
using System.Reflection;
using Alexandria.net.Communication;
using Newtonsoft.Json;

namespace Alexandria.net.API.WalletFunctions
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class Asset : RpcConnection
    {

        #region Constructors

        /// <summary>
        /// Wallet Constructor
        /// </summary>
        /// <param name="hostname">the rpc endpoint ip address</param>
        /// <param name="port">the rpc endpoint post</param>
        public Asset(string hostname = "127.0.0.1", ushort port = 8091, string api = "/rpc", string version = "2.0") :
            base(hostname, port, api, version)
        {
        }

        #endregion
        
        
        /// <summary>
        /// Trnasfer given assets from one user to other one.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="memo"></param>
        /// <param name="balance"></param>
        /// <param name="assetSymbol"></param>
        /// <returns></returns>
        public bool transfer(string from, string to, string memo, ulong balance, string assetSymbol)
        {
            var @params = new ArrayList {from, to, memo, balance, assetSymbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Returns the balance of the given account and UIA
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="assetSymbol"></param>
        /// <returns></returns>
        public ulong getAccountUiaBalance(string accountName, string assetSymbol)
        {
            var @params = new ArrayList {accountName, assetSymbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return Convert.ToUInt64(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerAccountName"></param>
        /// <param name="managementAuthority"></param>
        /// <param name="maxSupply"></param>
        /// <param name="assetSymbol"></param>
        /// <returns></returns>
        public bool createUia(string ownerAccountName, Authority managementAuthority, ulong maxSupply, string assetSymbol)
        {
            var @params = new ArrayList {ownerAccountName, managementAuthority, maxSupply, assetSymbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        public bool issueUia(string reveiverAccountName, ulong amount, string assetSymbol)
        {
            var @params = new ArrayList {reveiverAccountName, amount, assetSymbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        public bool burnUia(string accountName, ulong amount, string assetSymbol)
        {
            var @params = new ArrayList {accountName, amount, assetSymbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);   
            return result == "true";
        }

        public Authority getUiaAuthority(string assetSymbol)
        {
            var @params = new ArrayList {assetSymbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<Authority>(result);
        }

        public bool hasUiaPrivateKey(string assetSymbol)
        {
            var @params = new ArrayList {assetSymbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }
    }
}