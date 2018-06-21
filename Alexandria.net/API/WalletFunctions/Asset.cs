using System;
using System.Collections;
using System.Reflection;
using Alexandria.net.Communication;
using Alexandria.net.Logging;
using Alexandria.net.Messaging.Responses;
using Alexandria.net.Settings;
using Newtonsoft.Json;

namespace Alexandria.net.API.WalletFunctions
{
    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public class Asset : RpcConnection
    {
        private readonly ILogger _logger;

        #region Constructors

        /// <summary>
        /// Wallet Constructor
        /// </summary>
        /// <param name="config"></param>
        public Asset(IConfig config) :
            base(config)
        {
            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(LoggingType.Server, assemblyname);
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
        public bool Transfer(string from, string to, string memo, ulong balance, string assetSymbol)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name.ToLower());
                var @params = new ArrayList {from, to, memo, balance, assetSymbol};
                var result = SendRequest(reqname, @params);
                return result == "true";
            }
            catch (Exception ex)
            {
                
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }

        /// <summary>
        /// Returns the balance of the given account and UIA
        /// </summary>
        /// <param name="accountName">string accountName</param>
        /// <param name="assetSymbol">string assetSymbol</param>
        /// <returns>Returns retruns ulong Accournt balance</returns>
        public ulong GetAccountUiaBalance(string accountName, string assetSymbol)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name.ToLower());
                var @params = new ArrayList {accountName, assetSymbol};
                var result = SendRequest(reqname, @params);
                return Convert.ToUInt64(result);
            }
            catch (Exception ex)
            {
                
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }

        /// <summary>
        /// Create UIA for the given account authority
        /// </summary>
        /// <param name="ownerAccountName">string ownerAccountName</param>
        /// <param name="managementAuthority">Authority managementAuthority</param>
        /// <param name="maxSupply">ulong maxSupply</param>
        /// <param name="assetSymbol">string assetSymbol</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public bool CreateUia(string ownerAccountName, Authority managementAuthority, ulong maxSupply, string assetSymbol)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name.ToLower());
                var @params = new ArrayList {ownerAccountName, managementAuthority, maxSupply, assetSymbol};
                var result = SendRequest(reqname, @params);
                return result == "true";
            }
            catch (Exception ex)
            {
                
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }
        /// <summary>
        /// Issues an UIA for the Receiver account of given ammount
        /// </summary>
        /// <param name="reveiverAccountName">string reveiverAccountName</param>
        /// <param name="amount">ulong amount</param>
        /// <param name="assetSymbol">string assetSymbol</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public bool IssueUia(string reveiverAccountName, ulong amount, string assetSymbol)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name.ToLower());
                var @params = new ArrayList {reveiverAccountName, amount, assetSymbol};
                var result = SendRequest(reqname, @params);
                return result == "true";
            }
            catch (Exception ex)
            {
                
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }
        /// <summary>
        ///  Vanish given amount of UIA 
        /// </summary>
        /// <param name="accountName">string accountName</param>
        /// <param name="amount">ulong amount</param>
        /// <param name="assetSymbol">string assetSymbol</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public bool BurnUia(string accountName, ulong amount, string assetSymbol)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name.ToLower());
                var @params = new ArrayList {accountName, amount, assetSymbol};
                var result = SendRequest(reqname, @params);   
                return result == "true";
            }
            catch (Exception ex)
            {
                
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
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
        public Authority GetUiaAuthority(string assetSymbol)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name.ToLower());
                var @params = new ArrayList {assetSymbol};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<Authority>(result);
            }
            catch (Exception ex)
            {
                
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
            
        }
        /// <summary>
        /// Checks if the given UIA has a private key, identify by Sumbol
        /// </summary>
        /// <param name="assetSymbol">string assetSymbol</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public bool HasUiaPrivateKey(string assetSymbol)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name.ToLower());
                var @params = new ArrayList {assetSymbol};
                var result = SendRequest(reqname, @params);
                return result == "true";
            }
            catch (Exception ex)
            {
                
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
            
        }
    }
}