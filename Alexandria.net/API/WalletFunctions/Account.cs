using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.net.Communication;
using Newtonsoft.Json;
using Alexandria.net.Logging;
using Alexandria.net.Messaging.Responses;
using Alexandria.net.Messaging.Responses.DTO;
using Alexandria.net.Settings;


namespace Alexandria.net.API.WalletFunctions
{
    /// <inheritdoc />
    /// <para>
    /// Wallet Account Functions 
    /// </para>
    public class Account : RpcConnection
    {
        private readonly ILogger _logger;
    
        #region Constructors

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public Account(IConfig config) :
            base(config)
        {
            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(LoggingType.Server, assemblyname);
        }

        #endregion

        /// <summary>
        /// Returns true if an account with given name exists.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns true if success and false for failed try</returns>
        private bool AccountExists(string accountName)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName};
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
        /// Returns true if the library has imported the private key corresponding to the given public key.
        /// </summary>
        /// <param name="key">Input byte[] key</param>
        /// <returns>Returns true if success and false for failed try</returns>
        private bool HasPrivateKeys(byte[] key)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {key};
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
        /// Returns true if the library has imported the private key corresponding to the account's owner key.In case of
        /// authorities consisting of more than one key(mutlisig), it returns true if and only if the library has
        /// sufificient keys to resolve the owner autority.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns true if success and false for failed try</returns>
        private bool HasAccountOwnerPrivateKey(string accountName)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName};
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
        /// Returns true if the library has imported the private key corresponding to the account's active key.In case of
        /// authorities consisting of more than one key(mutlisig), it returns true if and only if the library has
        /// sufficient keys to resolve the active autority.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns true if success and false for failed try</returns>
        private bool HasAccountActivePrivateKey(string accountName)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName};
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
        /// Returns true if the library has imported the private key corresponding to the account's memo key.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns true if success and false for failed try</returns>
        private bool HasAccountMemoPrivateKey(string accountName)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName};
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
        /// Returns the active authority of the given account.Object authority has the following structure:
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <returns>Returns the Json object with the details about the active authority</returns>
        private Authority GetActiveAuthority(string accountName)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<Authority>(result);
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
        private Authority GetOwnerAuthority(string accountName)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<Authority>(result);
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
        private byte[] GetMemoKey(string accountName)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<byte[]>(result);
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
        private ulong GetAccountBalance(string accountName)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<ulong>(result);
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
        private ulong GetVestingBalance(string accountName)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<ulong>(result);
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
        private Authority CreateSimpleAuthority(byte[] pubKey)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {pubKey};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<Authority>(result);
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
        private Authority CreateSimpleMultisigAuthority(List<byte[]> pubKeys, ulong requiredSignatures)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {pubKeys, requiredSignatures};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<Authority>(result);
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
        private Authority CreateSimpleManagedAuthority(string managingAccountName)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {managingAccountName};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<Authority>(result);
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
        private Authority CreateSimpleMultiManagedAuthority(List<string> managingAccounts, uint requiredSignatures)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {managingAccounts, requiredSignatures};
                var result = SendRequest(reqname, @params);
                return JsonConvert.DeserializeObject<Authority>(result);
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
        /// <param name="owner">Input Authority owner</param>
        /// <param name="active">Input Authority active</param>
        /// <param name="memo">Input byte[] memo</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public TransactionResponse UpdateAccount(string accountName, string json_meta, string owner, string active,
            string memo, string privateKey)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName, json_meta, owner, active, memo};
                var result = SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);

                var response = StartBroadcasting(contentdata.result, privateKey);
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
        /// <returns></returns>
        public TransactionResponse SetVotingProxy(string accountToModify, string proxy, string privateKey)
        {	
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountToModify, proxy};
                var result= SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);
				
                var response = StartBroadcasting(contentdata.result, privateKey);
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
        /// <param name="accountName">the account name the information is required for</param>
        /// <returns>the account information</returns>
        public GetAccountResponse GetAccount(string accountName)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName};
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
        /// Creates the new sophiatx account
        /// </summary>
        /// <param name="witnessname">the name of the witness who will create the account.  Please use initminer as default</param>
        /// <param name="accountname">the account name to create</param>
        /// <param name="jsonMeta">json formatted details of account</param>
        /// <param name="ownerkey">the owner key</param>
        /// <param name="activekey">the active key</param>
        /// <param name="memokey">the memo key</param>
        /// <param name="privatekey">the private key used for the digest</param>
        /// <returns>the account creation response details</returns>
        public TransactionResponse CreateAccount(string accountname, string jsonMeta, string ownerkey,
            string activekey, string memokey, string witnessname = "initminer",
            string privatekey = "5JPwY3bwFgfsGtxMeLkLqXzUrQDMAsqSyAZDnMBkg7PDDRhQgaV")
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {witnessname, accountname, jsonMeta, ownerkey, activekey, memokey};
                var result = SendRequest(reqname, @params);

                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);

                var response = StartBroadcasting(contentdata.result, privatekey);
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
        /// <param name="accountName"></param>
        /// <param name="privateKey"></param>
        /// <returns>Returns object containing information about the new operation created</returns>
        public TransactionResponse DeleteAccount(string accountName, string privateKey)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {accountName};
                var result = SendRequest(reqname, @params);
                var contentdata = JsonConvert.DeserializeObject<AccountResponse>(result);

                var response = StartBroadcasting(contentdata.result, privateKey);
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