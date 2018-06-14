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
        /// <param name="from">string from</param>
        /// <param name="to">string to</param>
        /// <param name="memo">string memo</param>
        /// <param name="balance">ulong balance</param>
        /// <param name="assetSymbol">string assetSymbol</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public bool transfer(string from, string to, string memo, ulong balance, string assetSymbol)
        {
            var @params = new ArrayList {from, to, memo, balance, assetSymbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Returns the balance of the given account and UIA
        /// </summary>
        /// <param name="accountName">string accountName</param>
        /// <param name="assetSymbol">string assetSymbol</param>
        /// <returns>Returns retruns ulong Accournt balance</returns>
        public ulong getAccountUiaBalance(string accountName, string assetSymbol)
        {
            var @params = new ArrayList {accountName, assetSymbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return Convert.ToUInt64(result);
        }

        /// <summary>
        /// Create UIA for the given account authority
        /// </summary>
        /// <param name="ownerAccountName">string ownerAccountName</param>
        /// <param name="managementAuthority">Authority managementAuthority</param>
        /// <param name="maxSupply">ulong maxSupply</param>
        /// <param name="assetSymbol">string assetSymbol</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public bool createUia(string ownerAccountName, Authority managementAuthority, ulong maxSupply, string assetSymbol)
        {
            var @params = new ArrayList {ownerAccountName, managementAuthority, maxSupply, assetSymbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }
        /// <summary>
        /// Issues an UIA for the Receiver account of given ammount
        /// </summary>
        /// <param name="reveiverAccountName">string reveiverAccountName</param>
        /// <param name="amount">ulong amount</param>
        /// <param name="assetSymbol">string assetSymbol</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public bool issueUia(string reveiverAccountName, ulong amount, string assetSymbol)
        {
            var @params = new ArrayList {reveiverAccountName, amount, assetSymbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }
        /// <summary>
        ///  Vanish given amount of UIA 
        /// </summary>
        /// <param name="accountName">string accountName</param>
        /// <param name="amount">ulong amount</param>
        /// <param name="assetSymbol">string assetSymbol</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public bool burnUia(string accountName, ulong amount, string assetSymbol)
        {
            var @params = new ArrayList {accountName, amount, assetSymbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);   
            return result == "true";
        }
        /// <summary>
        /// Check for the authority assigned to given UIA, identify by Symbol
        /// </summary>
        /// <param name="assetSymbol">string assetSymbol</param>
        /// <returns>Returns Json object with details combining
        /// -WeightThreshold
        /// -AccountAuths
        /// -KeyAuths
        /// </returns>
        public Authority getUiaAuthority(string assetSymbol)
        {
            var @params = new ArrayList {assetSymbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<Authority>(result);
        }
        /// <summary>
        /// Checks if the given UIA has a private key, identify by Sumbol
        /// </summary>
        /// <param name="assetSymbol">string assetSymbol</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public bool hasUiaPrivateKey(string assetSymbol)
        {
            var @params = new ArrayList {assetSymbol};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }
    }
}