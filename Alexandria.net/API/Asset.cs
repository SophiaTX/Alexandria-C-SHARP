using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Alexandria.net.Logging;
using Alexandria.net.Mapping;
using Alexandria.net.Messaging.Responses;
using Alexandria.net.Settings;
using Newtonsoft.Json;

namespace Alexandria.net.API
{
    /// <inheritdoc />
    /// <para>
    /// Sophia Blockchain Asset functions
    /// </para>
    public class Asset : ApiBase
    {
        #region Constructors

        /// <summary>
        /// asset constructor
        /// </summary>
        /// <param name="config">the Configuration parameters for the endpoint and ports</param>
        /// <param name="methodMapperCollection"></param>
        public Asset(IConfig config, List<MethodMapper> methodMapperCollection) :
            base(methodMapperCollection)
        {
            Logger = new Logger(config, Assembly.GetExecutingAssembly().GetName().Name);
        }

        #endregion

        #region Methods

        /// <summary> 
        /// Transfer given assets from one user to other one.
        /// </summary>
        /// <param name="from">string from</param>
        /// <param name="to">string to</param>
        /// <param name="memo">string memo</param>
        /// <param name="amount">the amount to transfer "10.0000 SPHTX"</param>
        /// <param name="privateKey"></param>
        /// <returns>Returns Transaction object</returns>
        public TransactionResponse Transfer(string from, string to, string amount, string memo, string privateKey)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "Transfer");
            var data = @params.GetObjectAndJsonValue(from, to, amount, memo);
            var result = SendRequest(@params.BlockChainMethodName, data);

            var content = JsonConvert.DeserializeObject<AccountResponse>(result);
            var response = StartBroadcasting(content.Result, privateKey);
            return response;
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
            var @params = ParamCollection.Single(s => s.MethodName == "TransferToVesting");
            var data = @params.GetObjectAndJsonValue(@from, to, amount);
            var result = SendRequest(@params.BlockChainMethodName, data);

            var content = JsonConvert.DeserializeObject<AccountResponse>(result);
            var response = StartBroadcasting(content.Result, privateKey);
            return response;
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
            var @params = ParamCollection.Single(s => s.MethodName == "WithdrawVesting");
            var data = @params.GetObjectAndJsonValue(@from, vestingShares);
            var result = SendRequest(@params.BlockChainMethodName, data);
            var content = JsonConvert.DeserializeObject<AccountResponse>(result);
            var response = StartBroadcasting(content.Result, privateKey);
            return response;
        }


        /// <summary>
        /// Returns the balance of the given account and UIA
        /// </summary>
        /// <param name="accountName">string accountName</param>
        /// <param name="assetSymbol">string assetSymbol</param>
        /// <returns>Returns ulong Account balance</returns>
        private ulong GetAccountUiaBalance(string accountName, string assetSymbol)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "GetAccountUiaBalance");
            var data = @params.GetObjectAndJsonValue(accountName, assetSymbol);
            var result = SendRequest(@params.BlockChainMethodName, data);
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
        private bool CreateUia(string ownerAccountName, Authority managementAuthority, ulong maxSupply,
            string assetSymbol)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "CreateUia");
            var data = @params.GetObjectAndJsonValue(ownerAccountName,
                managementAuthority, maxSupply, assetSymbol);
            var result = SendRequest(@params.BlockChainMethodName, data);
            return result == "true";
        }

        /// <summary>
        /// Issues an UIA for the Receiver account of given ammount
        /// </summary>
        /// <param name="receiverAccountName">string receiverAccountName</param>
        /// <param name="amount">ulong amount</param>
        /// <param name="assetSymbol">string assetSymbol</param>
        /// <returns>Returns true if success or false for failed try</returns>
        private bool IssueUia(string receiverAccountName, ulong amount, string assetSymbol)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "IssueUia");
            var data = @params.GetObjectAndJsonValue(receiverAccountName, amount,
                assetSymbol);
            var result = SendRequest(@params.BlockChainMethodName, data);
            return result == "true";
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
            var @params = ParamCollection.Single(s => s.MethodName == "BurnUia");
            var data = @params.GetObjectAndJsonValue(accountName, amount, assetSymbol);
            var result = SendRequest(@params.BlockChainMethodName, data);

            return result == "true";
        }

        /// <summary>
        /// Check for the authority assigned to given UIA, identify by Symbol
        /// </summary>
        /// <param name="assetSymbol">string assetSymbol</param>
        /// <returns>Returns Json object with details combining</returns>
        private Authority GetUiaAuthority(string assetSymbol)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "GetUiaAuthority");
            var data = @params.GetObjectAndJsonValue(assetSymbol);
            var result = SendRequest(@params.BlockChainMethodName, data);

            return JsonConvert.DeserializeObject<Authority>(result);
        }
        
        /// <summary>
        /// Checks if the given UIA has a private key, identify by Sumbol
        /// </summary>
        /// <param name="assetSymbol">string assetSymbol</param>
        /// <returns>Returns true if success or false for failed try</returns>
        private bool HasUiaPrivateKey(string assetSymbol)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "HasUiaPrivateKey");
            var data = @params.GetObjectAndJsonValue(assetSymbol);
            var result = SendRequest(@params.BlockChainMethodName, data);

            return result == "true";
        }
        #endregion
    }
}