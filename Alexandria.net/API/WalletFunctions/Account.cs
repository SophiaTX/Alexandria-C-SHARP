using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.net.Communication;
using Newtonsoft.Json;
using Alexandria.net.Logging;
using Alexandria.net.Messaging.Responses;
using Alexandria.net.Settings;

namespace Alexandria.net.API.WalletFunctions
{
    /// <inheritdoc />
    /// <summary>
    /// Wallet Account Functions 
    /// </summary>
    public class Account : RpcConnection
    {
        private readonly ILogger _logger;
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Wallet Constructor
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
        public bool accountExists(string accountName)
        {
            try
            {
                var @params = new ArrayList {accountName};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
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
        public bool hasPrivateKeys(byte[] key)
        {
            try
            {
                var @params = new ArrayList {key};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
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
        public bool hasAccountOwnerPrivateKey(string accountName)
        {
            try
            {
                var @params = new ArrayList {accountName};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
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
        public bool hasAccountActivePrivateKey(string accountName)
        {
            try
            {
                var @params = new ArrayList {accountName};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
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
        public bool hasAccountMemoPrivateKey(string accountName)
        {
            try
            {
                var @params = new ArrayList {accountName};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
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
        public Authority getActiveAuthority(string accountName)
        {
            try
            {
                var @params = new ArrayList {accountName};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
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
        public Authority getOwnerAuthority(string accountName)
        {
            try
            {
                var @params = new ArrayList {accountName};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
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
        public byte[] getMemoKey(string accountName)
        {
            try
            {
                var @params = new ArrayList {accountName};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
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
        public ulong getAccountBalance(string accountName)
        {
            try
            {
                var @params = new ArrayList {accountName};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
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
        public ulong getVestingBalance(string accountName)
        {
            try
            {
                var @params = new ArrayList {accountName};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
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
        /// <returns>Returns Json object with details combining
        /// -WeightThreshold
        /// -AccountAuths
        /// -KeyAuths
        /// </returns>
        public Authority createSimpleAuthority(byte[] pubKey)
        {
            try
            {
                var @params = new ArrayList {pubKey};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
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
        /// <returns>Returns Json object with details combining
        /// -WeightThreshold
        /// -AccountAuths
        /// -KeyAuths
        /// </returns>
        public Authority createSimpleMultisigAuthority(List<byte[]> pubKeys, ulong requiredSignatures)
        {
            try
            {
                var @params = new ArrayList {pubKeys, requiredSignatures};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
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
        /// <returns>Returns Json object with details combining
        /// -WeightThreshold
        /// -AccountAuths
        /// -KeyAuths
        /// </returns>
        public Authority createSimpleManagedAuthority(string managingAccountName)
        {
            try
            {
                var @params = new ArrayList {managingAccountName};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                return JsonConvert.DeserializeObject<Authority>(result);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
           
        }

        /// <summary>
        /// Creates authority resolvable with given number of​ managing accounts.
        /// </summary>
        /// <param name="managingAccounts">Input List of string managingAccounts</param>
        /// <param name="requiredSignatures">Input uint requiredSignatures</param>
        /// <returns>Returns Json object with details combining
        /// -WeightThreshold
        /// -AccountAuths
        /// -KeyAuths
        /// </returns>
        public Authority createSimpleMultiManagedAuthority(List<string> managingAccounts, uint requiredSignatures)
        {
            try
            {
                var @params = new ArrayList {managingAccounts, requiredSignatures};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
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
        public bool updateAccount(string accountName, Authority owner, Authority active, byte[] memo)
        {
            try
            {
                var @params = new ArrayList {accountName, owner, active, memo};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                return result == "true";
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }

        /// <summary>
        /// Deposit to_vestings SPHTXs to vesting.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <param name="toVestings">Input ulong toVestings</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public bool depositVesting(string accountName, ulong toVestings)
        {
            try
            {
                var @params = new ArrayList {accountName, toVestings};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                return result == "true";
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
           
        }

        /// <summary>
        /// Withdraw from_vestings vested SPHTXs.
        /// </summary>
        /// <param name="accountName">Input string accountName</param>
        /// <param name="fromVestings">Input ulong fromVestings</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public bool withdrawVestings(string accountName, ulong fromVestings)
        {
            try
            {
                var @params = new ArrayList {accountName, fromVestings};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                return result == "true";
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }

        /// <summary>
        /// Vote or unvote a witness.
        /// </summary>
        /// <param name="votingAccountName">Input string votingAccountName</param>
        /// <param name="votedAccountName">Input string votedAccountName</param>
        /// <param name="approve">Input string approve</param>
        /// <returns></returns>
        public bool voteForWitness(string votingAccountName, string votedAccountName, string approve)
        {
            try
            {
                var @params = new ArrayList {votingAccountName, votedAccountName, approve};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                return result == "true";
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }

        /// <summary>
        /// Update an account to witness.Requires XXX vested SPHTX before updating.
        /// </summary>
        /// <param name="accountName">Inout string accountName</param>
        /// <param name="url">Input string url</param>
        /// <param name="blockKey">Input byte[] blockKey</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public bool updateToWitness(string accountName, string url, byte[] blockKey)
        {
            try
            {
                var @params = new ArrayList {accountName, url, blockKey};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                return result == "true";
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
            
        }

        /// <summary>
        /// Creates new account in the SophiaTX blockchain.
        /// </summary>
        /// <param name="registeringAccountName">Input string registeringAccountName</param>
        /// <param name="newAccountName">Input string newAccountName</param>
        /// <param name="owner">Input Authority owner</param>
        /// <param name="active">Input Authority active</param>
        /// <param name="memo">Input byte[] memo</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public bool createAccount(string registeringAccountName, string newAccountName, Authority owner,
            Authority active, byte[] memo)
        {
            try
            {
                var @params = new ArrayList {registeringAccountName, newAccountName, owner, active, memo};
                var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
                return result == "true";
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
           
        }
    }
}