using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Alexandria.net.Communication;
using Newtonsoft.Json;

namespace Alexandria.net.API.WalletFunctions
{
    /// <summary>
    /// 
    /// </summary>
    public class Account : RpcConnection
    {

        #region Constructors

        /// <summary>
        /// Wallet Constructor
        /// </summary>
        /// <param name="hostname">the rpc endpoint ip address</param>
        /// <param name="port">the rpc endpoint post</param>
        protected Account(string hostname = "127.0.0.1", ushort port = 8091) : base(hostname, port)
        {
        }

        #endregion

        /// <summary>
        /// Returns true if an account with given name exists.
        /// </summary>
        /// <param name="account_name"></param>
        /// <returns></returns>
        public bool accountExists(string account_name)
        {
            var @params = new ArrayList {account_name};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Returns true if the library has imported the private key corresponding to the given public key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool hasPrivateKeys(byte[] key)
        {
            var @params = new ArrayList {key};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Returns true if the library has imported the private key corresponding to the account's owner key.In case of
        /// authorities consisting of more than one key(mutlisig), it returns true if and only if the library has
        /// sufificient keys to resolve the owner autority.
        /// </summary>
        /// <param name="account_name"></param>
        /// <returns></returns>
        public bool hasAccountOwnerPrivateKey(string account_name)
        {
            var @params = new ArrayList {account_name};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Returns true if the library has imported the private key corresponding to the account's active key.In case of
        /// authorities consisting of more than one key(mutlisig), it returns true if and only if the library has
        /// sufficient keys to resolve the active autority.
        /// </summary>
        /// <param name="account_name"></param>
        /// <returns></returns>
        public bool hasAccountActivePrivateKey(string account_name)
        {
            var @params = new ArrayList {account_name};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Returns true if the library has imported the private key corresponding to the account's memo key.
        /// </summary>
        /// <param name="account_name"></param>
        /// <returns></returns>
        public bool hasAccountMemoPrivateKey(string account_name)
        {
            var @params = new ArrayList {account_name};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Returns the active authority of the given account.Object authority has the following structure:
        /// </summary>
        /// <param name="account_name"></param>
        /// <returns></returns>
        public Authority getActiveAuthority(string account_name)
        {
            var @params = new ArrayList {account_name};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<Authority>(result);
        }

        /// <summary>
        /// Returns the owner authority of the given account.
        /// </summary>
        /// <param name="account_name"></param>
        /// <returns></returns>
        public Authority getOwnerAuthority(string account_name)
        {
            var @params = new ArrayList {account_name};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<Authority>(result);
        }

        /// <summary>
        /// Returns the memo key of the given account.
        /// </summary>
        /// <param name="account_name"></param>
        /// <returns></returns>
        public byte[] getMemoKey(string account_name)
        {
            var @params = new ArrayList {account_name};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<byte[]>(result);
        }


        /// <summary>
        /// Get account SPHTX balance.
        /// </summary>
        /// <param name="account_name"></param>
        /// <returns></returns>
        public ulong getAccountBalance(string account_name)
        {
            var @params = new ArrayList {account_name};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<ulong>(result);
        }

        /// <summary>
        /// Get account vested SPHTX balance.

        /// </summary>
        /// <param name="account_name"></param>
        /// <returns></returns>
        public ulong getVestingBalance(string account_name)
        {
            var @params = new ArrayList {account_name};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<ulong>(result);
        }

        /// <summary>
        /// Creates authority resolvable with signature corresponding to the given pub_key.
        /// </summary>
        /// <param name="pub_key"></param>
        /// <returns></returns>
        public Authority createSimpleAuthority(byte[] pub_key)
        {
            var @params = new ArrayList {pub_key};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<Authority>(result);
        }

        /// <summary>
        /// Creates authority resolvable with given number of signatures out of the given set of keys.
        /// </summary>
        /// <param name="pub_keys"></param>
        /// <param name="required_signatures"></param>
        /// <returns></returns>
        public Authority createSimpleMultisigAuthority(List<byte[]> pub_keys, ulong required_signatures)
        {
            var @params = new ArrayList {pub_keys, required_signatures};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<Authority>(result);
        }

        /// <summary>
        /// Creates authority resolvable with a given managing account.
        /// </summary>
        /// <param name="managing_account_name"></param>
        /// <returns></returns>
        public Authority createSimpleManagedAuthority(string managing_account_name)
        {
            var @params = new ArrayList {managing_account_name};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<Authority>(result);
        }

        /// <summary>
        /// Creates authority resolvable with given number of​ managing accounts.
        /// </summary>
        /// <param name="managing_accounts"></param>
        /// <param name="required_signatures"></param>
        /// <returns></returns>
        public Authority createSimpleMultiManagedAuthority(List<string> managing_accounts, uint required_signatures)
        {
            var @params = new ArrayList {managing_accounts, required_signatures};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<Authority>(result);
        }

        /// <summary>
        /// Update account authorities.
        /// </summary>
        /// <param name="account_name"></param>
        /// <param name="owner"></param>
        /// <param name="active"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        public bool updateAccount(string account_name, Authority owner, Authority active, byte[] memo)
        {
            var @params = new ArrayList {account_name, owner, active, memo};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Deposit to_vestings SPHTXs to vesting.
        /// </summary>
        /// <param name="account_name"></param>
        /// <param name="to_vestings"></param>
        /// <returns></returns>
        public bool depositVesting(string account_name, ulong to_vestings)
        {
            var @params = new ArrayList {account_name, to_vestings};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Withdraw from_vestings vested SPHTXs.
        /// </summary>
        /// <param name="account_name"></param>
        /// <param name="from_vestings"></param>
        /// <returns></returns>
        public bool withdrawVestings(string account_name, ulong from_vestings)
        {
            var @params = new ArrayList {account_name, from_vestings};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Vote or unvote a witness.
        /// </summary>
        /// <param name="voting_account_name"></param>
        /// <param name="voted_account_name"></param>
        /// <param name="approve"></param>
        /// <returns></returns>
        public bool voteForWitness(string voting_account_name, string voted_account_name, string approve)
        {
            var @params = new ArrayList {voting_account_name, voted_account_name, approve};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Update an account to witness.Requires XXX vested SPHTX before updating.
        /// </summary>
        /// <param name="account_name"></param>
        /// <param name="url"></param>
        /// <param name="block_key"></param>
        /// <returns></returns>
        public bool updateToWitness(string account_name, string url, byte[] block_key)
        {
            var @params = new ArrayList {account_name, url, block_key};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Creates new account in the SophiaTX blockchain.
        /// </summary>
        /// <param name="registering_account_name"></param>
        /// <param name="new_account_name"></param>
        /// <param name="owner"></param>
        /// <param name="active"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        public bool createAccount(string registering_account_name, string new_account_name, Authority owner,
            Authority active, byte[] memo)
        {
            var @params = new ArrayList {registering_account_name, new_account_name, owner, active, memo};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }
    }
}