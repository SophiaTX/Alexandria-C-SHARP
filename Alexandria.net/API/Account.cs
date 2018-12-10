using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Alexandria.net.Logging;
using Alexandria.net.Mapping;
using Alexandria.net.Messaging.Responses;
using Alexandria.net.Settings;
using Newtonsoft.Json;
using AccountResponse = Alexandria.net.Messaging.Responses.AccountResponse;

namespace Alexandria.net.API
{
    /// <inheritdoc />
    /// <para>
    /// Sophia Blockchain Account functions
    /// </para>
    public class Account : ApiBase
    {
        #region Constructors

        /// <summary>
        /// Account Constructor
        /// </summary>
        /// <param name="config">the config file parameters</param>
        /// <param name="methodMapperCollection"></param>
        public Account(IConfig config, List<MethodMapper> methodMapperCollection) :
            base(methodMapperCollection)
        {
            Logger = new Logger(config, Assembly.GetExecutingAssembly().GetName().Name);
        }

        #endregion

        /// <summary>
        /// Returns true if an account with given name exists.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns true if success and false for failed try</returns>
        public AccountExistResponse AccountExists(string accountName)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "AccountExists");
            var data = @params.GetObjectAndJsonValue(accountName);
            var result = SendRequest(@params.BlockChainMethodName, data);
            return JsonConvert.DeserializeObject<AccountExistResponse>(result);
        }



        /// <summary>
        /// Returns the active authority of the given account.Object authority has the following structure:
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns the Json object with the details about the active authority</returns>
        public SimpleAuthorityResponse GetActiveAuthority(string accountName)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "GetActiveAuthority");
            var data = @params.GetObjectAndJsonValue( accountName);
            var result = SendRequest(@params.BlockChainMethodName, data);
            return JsonConvert.DeserializeObject<SimpleAuthorityResponse>(result);
        }

        /// <summary>
        /// Returns the owner authority of the given account.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns the Json object with the deails about the owner authority</returns>
        public SimpleAuthorityResponse GetOwnerAuthority(string accountName)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "GetOwnerAuthority");
            var data = @params.GetObjectAndJsonValue(accountName);
            var result = SendRequest(@params.BlockChainMethodName, data);
            return JsonConvert.DeserializeObject<SimpleAuthorityResponse>(result);
        }

        /// <summary>
        /// Returns the memo key of the given account.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns the Memo Key of the corresponding account</returns>
        public GetMemoKeyResponse GetMemoKey(string accountName)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "GetMemoKey");
            var data = @params.GetObjectAndJsonValue( accountName);
            var result = SendRequest(@params.BlockChainMethodName, data);
            return JsonConvert.DeserializeObject<GetMemoKeyResponse>(result);
        }

        /// <summary>
        /// Get SPHTX balance of the account.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns the account balance as a Json object</returns>
        public AccountBalanceResponse GetAccountBalance(string accountName)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "GetAccountBalance");
            var data = @params.GetObjectAndJsonValue( accountName);
            var result = SendRequest(@params.BlockChainMethodName, data);
            return JsonConvert.DeserializeObject<AccountBalanceResponse>(result);
        }

        /// <summary>
        /// Get SPHTX balance of the vesting account.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns the account balance as a Json object</returns>
        public VestingBalanceResponse GetVestingBalance(string accountName)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "GetVestingBalance");
            var data = @params.GetObjectAndJsonValue( accountName);
            var result = SendRequest(@params.BlockChainMethodName, data);
            return JsonConvert.DeserializeObject<VestingBalanceResponse>(result);
        }

        /// <summary>
        /// Creates authority resolvable with signature corresponding to the given pub_key.
        /// </summary>
        /// <param name="pubKey">Input byte[] pubKey</param>
        /// <returns>Returns Json object with details combining</returns>
        public SimpleAuthorityResponse CreateSimpleAuthority(string pubKey)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "CreateSimpleAuthority");
            var data = @params.GetObjectAndJsonValue( pubKey);
            var result = SendRequest(@params.BlockChainMethodName, data);
            return JsonConvert.DeserializeObject<SimpleAuthorityResponse>(result);
        }

        /// <summary>
        /// Creates authority resolvable with given number of signatures out of the given set of keys.
        /// </summary>
        /// <param name="pubKeys">Input List of Byte[] pubKeys</param>
        /// <param name="requiredSignatures">Input ulong requiredSignatures</param>
        /// <returns>Returns Json object with details combining</returns>
        public SimpleAuthorityResponse CreateSimpleMultisigAuthority(List<string> pubKeys, ulong requiredSignatures)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "CreateSimpleMultisigAuthority");
            var data = @params.GetObjectAndJsonValue( pubKeys, requiredSignatures);
            var result = SendRequest(@params.BlockChainMethodName, data);
            return JsonConvert.DeserializeObject<SimpleAuthorityResponse>(result);
        }

        /// <summary>
        /// Creates authority resolvable with a given managing account.
        /// </summary>
        /// <param name="managingAccountName">string managingAccountName</param>
        /// <returns>Returns Json object with details combining</returns>
        public object CreateSimpleManagedAuthority(string managingAccountName)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "CreateSimpleManagedAuthority");
            var data = @params.GetObjectAndJsonValue( managingAccountName);
            var result = SendRequest(@params.BlockChainMethodName, data);
            return JsonConvert.DeserializeObject<object>(result);
        }

        /// <summary>
        /// Creates authority resolvable with given number of​ managing accounts.
        /// </summary>
        /// <param name="managingAccounts">Input List of string managingAccounts</param>
        /// <param name="requiredSignatures">Input uint requiredSignatures</param>
        /// <returns>Returns Json object with details combining</returns>
        public ManagedAuthorityResponse CreateSimpleMultiManagedAuthority(List<string> managingAccounts,
            uint requiredSignatures)
        {
            managingAccounts.Add(requiredSignatures.ToString());
            var @params = ParamCollection.Single(s => s.MethodName == "CreateSimpleMultiManagedAuthority");
            var data = @params.GetObjectAndJsonValue( managingAccounts,
                requiredSignatures);
            var result = SendRequest(@params.BlockChainMethodName, data);
            return JsonConvert.DeserializeObject<ManagedAuthorityResponse>(result);
        }

        /// <summary>
        /// Update account authorities.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <param name="jsonMeta"></param>
        /// <param name="owner">Input Authority owner</param>
        /// <param name="active">Input Authority active</param>
        /// <param name="memo">Input byte[] memo</param>
        /// <param name="privateKey">the private key associated with the account</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public TransactionResponse UpdateAccount(string accountName, string jsonMeta, string owner, string active,
            string memo, string privateKey)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "UpdateAccount");
            var data = @params.GetObjectAndJsonValue( accountName, jsonMeta, owner,
                active, memo);
            var result = SendRequest(@params.BlockChainMethodName, data);
            var content = JsonConvert.DeserializeObject<AccountResponse>(result);

            var response = StartBroadcasting(content.Result, privateKey);
            return response;
        }

        /// <summary>
        /// Set the voting proxy For an account.
        /// If a user does Not wish To take an active part In voting, they can choose to allow another account to vote their stake.
        /// Setting a vote proxy does Not remove your previous votes from the blockchain,
        /// they remain there but are ignored. If you later null out your vote proxy, your previous votes will take effect again.
        /// This setting can be changed at any time.
        /// </summary>
        /// <param name="accountToModify">the name Or id Of the account To update</param>
        /// <param name="proxy">the name Of account that should proxy To, Or empty String To have no proxy </param>
        /// <param name="privateKey"></param>
        /// <returns>the transaction response from the set voting proxy</returns>
        public TransactionResponse SetVotingProxy(string accountToModify, string proxy, string privateKey)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "SetVotingProxy");
            var data = @params.GetObjectAndJsonValue( accountToModify, proxy);
            var result = SendRequest(@params.BlockChainMethodName, data);
            var content = JsonConvert.DeserializeObject<AccountResponse>(result);

            var response = StartBroadcasting(content.Result, privateKey);
            return response;
        }

        /// <summary>
        /// Gets the account information
        /// </summary>
        /// <param name="seed">the account to get</param>
        /// <returns>the account information</returns>
        public GetAccountResponse GetAccount(string seed)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "GetAccount");
            var data = @params.GetObjectAndJsonValue( seed);
            var result = SendRequest(@params.BlockChainMethodName, data);
            var content = JsonConvert.DeserializeObject<GetAccountResponse>(result);
            return content;
        }

        /// <summary>
        /// Get transaction history of the account
        /// </summary>
        /// <param name="accountName">name of the account</param>
        /// <param name="from">start</param>
        /// <param name="limit"></param>
        /// <returns>the account history data</returns>
        public AccountHistoryResponse GetAccountHistory(string accountName, uint from, int limit)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "GetAccountHistory");
            var data = @params.GetObjectAndJsonValue( accountName, @from, limit);
            var result = SendRequest(@params.BlockChainMethodName, data);
            var content = JsonConvert.DeserializeObject<AccountHistoryResponse>(result);
            return content;
        }
        
        /// <summary>
        /// Get account name given by the system using seed provided by the user during account creation
        /// </summary>
        /// <param name="seed">seed name used while creating the account</param>
        /// <returns>the account details</returns>
        public AccountNameFromSeedResponse GetAccountNameFromSeed(string seed)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "GetAccountNameFromSeed");
            var data = @params.GetObjectAndJsonValue( seed);
            var result = SendRequest(@params.BlockChainMethodName, data);
            var content = JsonConvert.DeserializeObject<AccountNameFromSeedResponse>(result);
            return content;
        }

        /// <summary>
        /// Creates the new sophiatx account
        /// </summary>
        /// <param name="witnessName">the name of the witness who will create the account.  Please use initminer as default</param>
        /// <param name="seed">the account name to create</param>
        /// <param name="jsonMeta">json formatted details of account</param>
        /// <param name="ownerKey">the owner key</param>
        /// <param name="activeKey">the active key</param>
        /// <param name="memoKey">the memo key</param>
        /// <param name="privateKey">the private key used for the digest</param>
        /// <returns>the account creation response details</returns>
        public TransactionResponse CreateAccount(string seed, string jsonMeta, string ownerKey,
            string activeKey, string memoKey, string witnessName,
            string privateKey)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "CreateAccount");
            var data = @params.GetObjectAndJsonValue( witnessName, seed, jsonMeta,
                ownerKey, activeKey, memoKey);
            var result = SendRequest(@params.BlockChainMethodName, data);

            var content = JsonConvert.DeserializeObject<AccountResponse>(result);

            var response = StartBroadcasting(content.Result, privateKey);
            return response;
        }

        /// <summary>
        /// Deletes the account from the blockchain related to the given name of the account
        /// </summary>
        /// <param name="accountName">the account name to be deleted</param>
        /// <param name="privateKey">the private key attached to the account</param>
        /// <returns>Returns object containing information about the new operation created</returns>
        public TransactionResponse DeleteAccount(string accountName, string privateKey)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "DeleteAccount");
            var data = @params.GetObjectAndJsonValue( accountName);
            var result = SendRequest(@params.BlockChainMethodName, data);
            var contentData = JsonConvert.DeserializeObject<AccountResponse>(result);                
            var response = StartBroadcasting(contentData.Result, privateKey);
            return response;
        }
    } 
}