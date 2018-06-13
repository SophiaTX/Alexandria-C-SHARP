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
        protected Asset(string hostname = "127.0.0.1", ushort port = 8091) : base(hostname, port)
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
        /// <param name="asset_symbol"></param>
        /// <returns></returns>
        public bool transfer(string from, string to, string memo, ulong balance, string asset_symbol)
        {
            var @params = new ArrayList {from, to, memo, balance, asset_symbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Returns the balance of the given account and UIA
        /// </summary>
        /// <param name="account_name"></param>
        /// <param name="asset_symbol"></param>
        /// <returns></returns>
        public ulong getAccountUiaBalance(string account_name, string asset_symbol)
        {
            var @params = new ArrayList {account_name, asset_symbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return Convert.ToUInt64(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner_account_name"></param>
        /// <param name="management_authority"></param>
        /// <param name="max_supply"></param>
        /// <param name="asset_symbol"></param>
        /// <returns></returns>
        public bool createUia(string owner_account_name, Authority management_authority, ulong max_supply, string asset_symbol)
        {
            var @params = new ArrayList {owner_account_name, management_authority, max_supply, asset_symbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        public bool issueUia(string reveiver_account_name, ulong amount, string asset_symbol)
        {
            var @params = new ArrayList {reveiver_account_name, amount, asset_symbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        public bool burnUia(string account_name, ulong amount, string asset_symbol)
        {
            var @params = new ArrayList {account_name, amount, asset_symbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);   
            return result == "true";
        }

        public Authority getUiaAuthority(string asset_symbol)
        {
            var @params = new ArrayList {asset_symbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<Authority>(result);
        }

        public bool hasUiaPrivateKey(string asset_symbol)
        {
            var @params = new ArrayList {asset_symbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }
    }
}