using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.net.Communication;
using Alexandria.net.Input;
using Alexandria.net.Logging;
using Alexandria.net.Messaging.Params;
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
    public class Account : RpcConnection
    {
        private readonly ILogger _logger;
    
        #region Constructors
        
        /// <summary>
        /// Account Constructor
        /// </summary>
        /// <param name="config">the config file parameters</param>
        public Account(IConfig config) :
            base(config)
        {
            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(config, assemblyname);
        }

        #endregion

        /// <summary>
        /// Returns true if an account with given name exists.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns true if success and false for failed try</returns>
        public AccountExistResponse AccountExists(string accountName)
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            //var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, accountName);
            var @params = new GetAccountInput
            {
                account_name = accountName
            };
            var result = SendRequestToDaemon(reqname, @params);
            return JsonConvert.DeserializeObject<AccountExistResponse>(result);
        }



        /// <summary>
        /// Returns the active authority of the given account.Object authority has the following structure:
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns the Json object with the details about the active authority</returns>
        public SimpleAuthorityResponse GetActiveAuthority(string accountName)
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            //var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, accountName);
            var @params = new GetAccountInput
            {
                account_name = accountName
            };
            var result = SendRequestToDaemon(reqname, @params);
            return JsonConvert.DeserializeObject<SimpleAuthorityResponse>(result);
        }

        /// <summary>
        /// Returns the owner authority of the given account.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns the Json object with the deails about the owner authority</returns>
        public SimpleAuthorityResponse GetOwnerAuthority(string accountName)
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            //var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, accountName);
            var @params = new GetAccountInput
            {
                account_name = accountName
            };
            var result = SendRequestToDaemon(reqname, @params);
            return JsonConvert.DeserializeObject<SimpleAuthorityResponse>(result);
        }

        /// <summary>
        /// Returns the memo key of the given account.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns the Memo Key of the corresponding account</returns>
        public GetMemoKeyResponse GetMemoKey(string accountName)
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            //var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, accountName);
            var @params = new GetAccountInput
            {
                account_name = accountName
            };
            var result = SendRequestToDaemon(reqname, @params);
            return JsonConvert.DeserializeObject<GetMemoKeyResponse>(result);
        }

        /// <summary>
        /// Get SPHTX balance of the account.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns the account balance as a Json object</returns>
        public AccountBalanceResponse GetAccountBalance(string accountName)
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            //var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, accountName);
            var @params = new GetAccountInput
            {
                account_name = accountName
            };
            var result = SendRequestToDaemon(reqname, @params);
            return JsonConvert.DeserializeObject<AccountBalanceResponse>(result);
        }

        /// <summary>
        /// Get SPHTX balance of the vesting account.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns the account balance as a Json object</returns>
        public VestingBalanceResponse GetVestingBalance(string accountName)
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            //var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, accountName);
            var @params = new GetAccountInput
            {
                account_name = accountName
            };
            var result = SendRequestToDaemon(reqname, @params);
            return JsonConvert.DeserializeObject<VestingBalanceResponse>(result);
        }

        /// <summary>
        /// Creates authority resolvable with signature corresponding to the given pub_key.
        /// </summary>
        /// <param name="pubKey">Input byte[] pubKey</param>
        /// <returns>Returns Json object with details combining</returns>
        public CreateSimpleAuthorityResponse CreateSimpleAuthority(string pubKey)
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            //var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, pubKey);
            var @params = new PublicKeyInput {pub_key = pubKey};
            var result = SendRequestToDaemon(reqname, @params);
            return JsonConvert.DeserializeObject<CreateSimpleAuthorityResponse>(result);
        }

        /// <summary>
        /// Creates authority resolvable with given number of signatures out of the given set of keys.
        /// </summary>
        /// <param name="pubKeys">Input List of Byte[] pubKeys</param>
        /// <param name="requiredSignatures">Input ulong requiredSignatures</param>
        /// <returns>Returns Json object with details combining</returns>
        public CreateAuthorityResponse CreateSimpleMultisigAuthority(List<string> pubKeys, ulong requiredSignatures)
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            //var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, pubKeys, requiredSignatures);
            var @params = new AuthorityInput {pub_keys = pubKeys, required_signatures = requiredSignatures};
            var result = SendRequestToDaemon(reqname, @params);
            return JsonConvert.DeserializeObject<CreateAuthorityResponse>(result);
        }

        /// <summary>
        /// Creates authority resolvable with a given managing account.
        /// </summary>
        /// <param name="managingAccountName">string managingAccountName</param>
        /// <returns>Returns Json object with details combining</returns>
        public SimpleAuthorityResponse CreateSimpleManagedAuthority(string managingAccountName)
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            //var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, managingAccountName);
            var @params = new managingAccountInput {managing_account=managingAccountName};
            var result = SendRequestToDaemon(reqname, @params);
            return JsonConvert.DeserializeObject<SimpleAuthorityResponse>(result);
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
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
//            var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, managingAccounts,
//                requiredSignatures);
            var @params = new ArrayList {managingAccounts, requiredSignatures};
            var result = SendRequestToDaemon(reqname, @params);
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
        public BroadcastTxResponse UpdateAccount(string accountName, string jsonMeta, string owner, string active,
            string memo, string privateKey)
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
        //  var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, accountName, jsonMeta, owner,
        //  active, memo);
            var @params = new UpdateAccountInput {account_name = accountName, json_meta = jsonMeta, owner = owner, active = active, memo = memo};
            var result = SendRequestToDaemon(reqname, @params);
            var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
            var response = StartBroadcasting(contentdata.Result, privateKey);
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
        public BroadcastTxResponse SetVotingProxy(string accountToModify, string proxy, string privateKey)
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            //var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, accountToModify, proxy);
            var @params = new SetVotingProxyInput
            {
                account_to_modify = accountToModify,
                proxy = proxy
            };
            var result = SendRequestToDaemon(reqname, @params);
            var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);

            var response = StartBroadcasting(contentdata.Result, privateKey);
            return response;
        }

        /// <summary>
        /// Gets the account information
        /// </summary>
        /// <param name="seed">the account to get</param>
        /// <returns>the account information</returns>
        public GetAccountResponse GetAccount(string accountName)
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            //var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, seed);
            var @params = new GetAccountInput {account_name = accountName};
            var result = SendRequestToDaemon(reqname, @params);
            var contentdata = JsonConvert.DeserializeObject<GetAccountResponse>(result);
            return contentdata;
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
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            //var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, accountName, @from, limit);
            var @params = new GetAccountHistoryInput {account = accountName, start = from, limit = limit};
            var result = SendRequestToDaemon(reqname, @params);
            var contentdata = JsonConvert.DeserializeObject<AccountHistoryResponse>(result);
            return contentdata;
        }
        
        /// <summary>
        /// Get account name given by the system using seed provided by the user during account creation
        /// </summary>
        /// <param name="seed">seed name used while creating the account</param>
        /// <returns>the account details</returns>
        public AccountNameFromSeedResponse GetAccountNameFromSeed(string seed)
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            //var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, seed);
            var @params = new NameFromSeedInput {seed = seed};
            var result = SendRequestToDaemon(reqname, @params);
            var contentdata = JsonConvert.DeserializeObject<AccountNameFromSeedResponse>(result);
            return contentdata;
        }

        /// <summary>
        /// Creates the new sophiatx account
        /// </summary>
        /// <param name="witnessname">the name of the witness who will create the account.  Please use initminer as default</param>
        /// <param name="seed">the account name to create</param>
        /// <param name="jsonMeta">json formatted details of account</param>
        /// <param name="ownerkey">the owner key</param>
        /// <param name="activekey">the active key</param>
        /// <param name="memokey">the memo key</param>
        /// <param name="privatekey">the private key used for the digest</param>
        /// <returns>the account creation response details</returns>
        public BroadcastTxResponse CreateAccount(string seed, string jsonMeta, string ownerkey,
            string activekey, string memokey, string witnessname,
            string privatekey)
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            //var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, witnessname, seed, jsonMeta, ownerkey, activekey, memokey);
            var @params = new CreateAccountInput
            {
                creator = witnessname, 
                name_seed = seed, 
                json_meta = jsonMeta, 
                owner=ownerkey, 
                active = activekey, 
                memo = memokey
            };
            var result = SendRequestToDaemon(reqname, @params);

            var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);

            var response = StartBroadcasting(contentdata.Result, privatekey);
            return response;
        }

        /// <summary>
        /// Deletes the account from the blockchain related to the given name of the account
        /// </summary>
        /// <param name="accountName">the account name to be deleted</param>
        /// <param name="privateKey">the private key attached to the account</param>
        /// <returns>Returns object containing information about the new operation created</returns>
        public BroadcastTxResponse DeleteAccount(string accountName, string privateKey)
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
            //var @params = ParamHelper.GetValue(MethodBase.GetCurrentMethod().Name, accountName);
            var @params = new DeleteAccountInput {account_name = accountName};
            var result = SendRequestToDaemon(reqname, @params);
            var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);                
            var response = StartBroadcasting(contentdata.Result, privateKey);
            return response;
        }
    } 
}