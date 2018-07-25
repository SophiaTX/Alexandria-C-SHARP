using System;
using System.Collections;
using System.Reflection;
using Alexandria.net.Communication;
using Alexandria.net.Logging;
using Alexandria.net.Messaging.Responses;
using Alexandria.net.Settings;
using Newtonsoft.Json;

namespace Alexandria.net.API
{
    /// <inheritdoc />
    /// <para>
    /// Sophia Blockchain Asset functions
    /// </para>
    public class Asset : RpcConnection
    {
        private readonly ILogger _logger;

        #region Constructors

        /// <summary>
        /// asset constructor
        /// </summary>
        /// <param name="config">the Configuration paramaters for the endpoint and ports</param>
        public Asset(IConfig config) :
            base(config)
        {
            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(config, LoggingType.Server, assemblyname);
        }

        #endregion

        #region Methods
        /// <summary> 
        /// Trnasfer given assets from one user to other one.
        /// </summary>
        /// <param name="from">string from</param>
        /// <param name="to">string to</param>
        /// <param name="memo">string memo</param>
        /// <param name="amount">the amount to transfer "10.0000 SPHTX"</param>
        /// <param name="privateKey"></param>
        /// <returns>Returns Transaction object</returns>
        public TransactionResponse Transfer(string from, string to,  string amount,string memo, string privateKey)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {from, to, amount,memo };
                var result = SendRequest(reqname, @params);

                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
                var response = StartBroadcasting(contentdata.Result, privateKey);
                return response;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Transfer SPHTX into a vesting fund represented by vesting shares (VESTS). VESTS are required to vesting
        /// for a minimum of one coin year and can be withdrawn once a week over a two year withdraw period.
        /// VESTS are protected against dilution up until 90% of SPHTX is vesting.
        /// </summary>
        /// <param name="from">The account the SPHTX is coming from</param>
        /// <param name="to">The account getting the VESTS</param>
        /// <param name="amount">The amount of SPHTX to vest i.e. "100.00 SPHTX"</param>
        /// <param name="privateKey"></param>
        /// <returns>Returns Transaction object</returns>
        public TransactionResponse TransferToVesting(string from, string to, string amount, string privateKey)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {from, to, amount};
                var result = SendRequest(reqname, @params);

                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
                var response = StartBroadcasting(contentdata.Result, privateKey);
                return response;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }
        
        /// <summary>
        /// Set up a vesting withdraw request. The request Is fulfilled once a week over the next two years (104 weeks).
        /// The amount of vests to withdrawover the Next two
        /// years. Each week (amount/104) shares are withdrawn And deposited
        /// back as SPHTX. i.e. "10.000000 VESTS"
        /// </summary>
        /// <param name="from">account vests are drawn from </param>
        /// <param name="vestingShares"> The amount should be in the format "10.0000 VESTS" showing amount and currency symbol</param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public TransactionResponse WithdrawVesting(string from, string vestingShares, string privateKey)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {from, vestingShares};
                var result = SendRequest(reqname, @params);

                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
                var response = StartBroadcasting(contentdata.Result, privateKey);
                return response;
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
        private ulong GetAccountUiaBalance(string accountName, string assetSymbol)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
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
        private bool CreateUia(string ownerAccountName, Authority managementAuthority, ulong maxSupply, string assetSymbol)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
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
        private bool IssueUia(string reveiverAccountName, ulong amount, string assetSymbol)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
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
        private bool BurnUia(string accountName, ulong amount, string assetSymbol)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
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
        /// <returns>Returns Json object with details combining</returns>
        private Authority GetUiaAuthority(string assetSymbol)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
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
        private bool HasUiaPrivateKey(string assetSymbol)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
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
        #endregion
    }
}