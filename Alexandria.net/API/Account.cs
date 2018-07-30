using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.net.Communication;
using Alexandria.net.Logging;
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
            _logger = new Logger(config, LoggingType.Server, assemblyname);
        }

        #endregion

        /// <summary>
        /// Returns true if an account with given name exists.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns true if success and false for failed try</returns>
        public AccountExistResponse AccountExists(string accountName)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<AccountExistResponse>(result);
                
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }


        /// <summary>
        /// Returns the active authority of the given account.Object authority has the following structure:
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns the Json object with the details about the active authority</returns>
        public SimpleAuthorityResponse GetActiveAuthority(string accountName)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<SimpleAuthorityResponse>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Returns the owner authority of the given account.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns the Json object with the deails about the owner authority</returns>
        public SimpleAuthorityResponse GetOwnerAuthority(string accountName)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<SimpleAuthorityResponse>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Returns the memo key of the given account.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns the Memo Key of the corresponding account</returns>
        public GetMemoKeyResponse GetMemoKey(string accountName)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<GetMemoKeyResponse>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }

        }

        /// <summary>
        /// Get SPHTX balance of the account.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns the account balance as a Json object</returns>
        public AccountBalanceResponse GetAccountBalance(string accountName)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<AccountBalanceResponse>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Get SPHTX balance of the vesting account.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns the account balance as a Json object</returns>
        public VestingBalanceResponse GetVestingBalance(string accountName)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<VestingBalanceResponse>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Creates authority resolvable with signature corresponding to the given pub_key.
        /// </summary>
        /// <param name="pubKey">Input byte[] pubKey</param>
        /// <returns>Returns Json object with details combining</returns>
        public SimpleAuthorityResponse CreateSimpleAuthority(string pubKey)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {pubKey};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<SimpleAuthorityResponse>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Creates authority resolvable with given number of signatures out of the given set of keys.
        /// </summary>
        /// <param name="pubKeys">Input List of Byte[] pubKeys</param>
        /// <param name="requiredSignatures">Input ulong requiredSignatures</param>
        /// <returns>Returns Json object with details combining</returns>
        public SimpleAuthorityResponse CreateSimpleMultisigAuthority(List<string> pubKeys, ulong requiredSignatures)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {pubKeys, requiredSignatures};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<SimpleAuthorityResponse>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Creates authority resolvable with a given managing account.
        /// </summary>
        /// <param name="managingAccountName">string managingAccountName</param>
        /// <returns>Returns Json object with details combining</returns>
        public object CreateSimpleManagedAuthority(string managingAccountName)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {managingAccountName};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<object>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Creates authority resolvable with given number of​ managing accounts.
        /// </summary>
        /// <param name="managingAccounts">Input List of string managingAccounts</param>
        /// <param name="requiredSignatures">Input uint requiredSignatures</param>
        /// <returns>Returns Json object with details combining</returns>
        public ManagedAuthorityResponse CreateSimpleMultiManagedAuthority(List<string> managingAccounts, uint requiredSignatures)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {managingAccounts, requiredSignatures};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<ManagedAuthorityResponse>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
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
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName, jsonMeta, owner, active, memo};
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
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountToModify, proxy};
                var result= SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
				
                var response = StartBroadcasting(contentdata.Result, privateKey);
                return response;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
        }

        /// <summary>
        /// Gets the account information
        /// </summary>
        /// <param name="seed">the account to get</param>
        /// <returns>the account information</returns>
        public GetAccountResponse GetAccount(string seed)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {seed};
                var result = SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<GetAccountResponse>(result);
                return contentdata;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Get transaction history of the account
        /// </summary>
        /// <param name="accountName">name of the account</param>
        /// <param name="from">start</param>
        /// <param name="limit"></param>
        /// <returns>the account history data</returns>
        public AccountHistoryResponse GetAccountHistory(string accountName, uint from, uint limit)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName, from, limit};
                var result = SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<AccountHistoryResponse>(result);
                return contentdata;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }
        
        /// <summary>
        /// Get account name given by the system using seed provided by the user during account creation
        /// </summary>
        /// <param name="seed">seed name used while creating the account</param>
        /// <returns>the account details</returns>
        public AccountNameFromSeedResponse GetAccountNameFromSeed(string seed)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {seed};
                var result = SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<AccountNameFromSeedResponse>(result);
                return contentdata;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
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
        public object CreateAccount(string seed, string jsonMeta, string ownerkey,
            string activekey, string memokey, string witnessname,
            string privatekey)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {witnessname, seed, jsonMeta, ownerkey, activekey, memokey};
                var result = SendRequest(reqname, @params);

                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);

                var response = StartBroadcasting(contentdata.Result, privatekey);
                return response;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Deletes the account from the blockchain related to the given name of the account
        /// </summary>
        /// <param name="accountName">the account name to be deleted</param>
        /// <param name="privateKey">the private key attached to the account</param>
        /// <returns>Returns object containing information about the new operation created</returns>
        public TransactionResponse DeleteAccount(string accountName, string privateKey)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName};
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
    }

   
}