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
        /// <param name="api"></param>
        /// <param name="version"></param>
        public Account(string hostname = "127.0.0.1", ushort port = 8091, string api = "/rpc", string version = "2.0") :
            base(hostname, port, api, version)
        {
        }

        #endregion

        /// <summary>
        /// Returns true if an account with given name exists.
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public bool accountExists(string accountName)
        {
            var @params = new ArrayList {accountName};
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
        /// <param name="accountName"></param>
        /// <returns></returns>
        public bool hasAccountOwnerPrivateKey(string accountName)
        {
            var @params = new ArrayList {accountName};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Returns true if the library has imported the private key corresponding to the account's active key.In case of
        /// authorities consisting of more than one key(mutlisig), it returns true if and only if the library has
        /// sufficient keys to resolve the active autority.
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public bool hasAccountActivePrivateKey(string accountName)
        {
            var @params = new ArrayList {accountName};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Returns true if the library has imported the private key corresponding to the account's memo key.
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public bool hasAccountMemoPrivateKey(string accountName)
        {
            var @params = new ArrayList {accountName};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Returns the active authority of the given account.Object authority has the following structure:
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public Authority getActiveAuthority(string accountName)
        {
            var @params = new ArrayList {accountName};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<Authority>(result);
        }

        /// <summary>
        /// Returns the owner authority of the given account.
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public Authority getOwnerAuthority(string accountName)
        {
            var @params = new ArrayList {accountName};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<Authority>(result);
        }

        /// <summary>
        /// Returns the memo key of the given account.
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public byte[] getMemoKey(string accountName)
        {
            var @params = new ArrayList {accountName};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<byte[]>(result);
        }


        /// <summary>
        /// Get account SPHTX balance.
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public ulong getAccountBalance(string accountName)
        {
            var @params = new ArrayList {accountName};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<ulong>(result);
        }

        /// <summary>
        /// Get account vested SPHTX balance.
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        public ulong getVestingBalance(string accountName)
        {
            var @params = new ArrayList {accountName};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<ulong>(result);
        }

        /// <summary>
        /// Creates authority resolvable with signature corresponding to the given pub_key.
        /// </summary>
        /// <param name="pubKey"></param>
        /// <returns></returns>
        public Authority createSimpleAuthority(byte[] pubKey)
        {
            var @params = new ArrayList {pubKey};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<Authority>(result);
        }

        /// <summary>
        /// Creates authority resolvable with given number of signatures out of the given set of keys.
        /// </summary>
        /// <param name="pubKeys"></param>
        /// <param name="requiredSignatures"></param>
        /// <returns></returns>
        public Authority createSimpleMultisigAuthority(List<byte[]> pubKeys, ulong requiredSignatures)
        {
            var @params = new ArrayList {pubKeys, requiredSignatures};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<Authority>(result);
        }

        /// <summary>
        /// Creates authority resolvable with a given managing account.
        /// </summary>
        /// <param name="managingAccountName"></param>
        /// <returns></returns>
        public Authority createSimpleManagedAuthority(string managingAccountName)
        {
            var @params = new ArrayList {managingAccountName};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<Authority>(result);
        }

        /// <summary>
        /// Creates authority resolvable with given number of​ managing accounts.
        /// </summary>
        /// <param name="managingAccounts"></param>
        /// <param name="requiredSignatures"></param>
        /// <returns></returns>
        public Authority createSimpleMultiManagedAuthority(List<string> managingAccounts, uint requiredSignatures)
        {
            var @params = new ArrayList {managingAccounts, requiredSignatures};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return JsonConvert.DeserializeObject<Authority>(result);
        }

        /// <summary>
        /// Update account authorities.
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="owner"></param>
        /// <param name="active"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        public bool updateAccount(string accountName, Authority owner, Authority active, byte[] memo)
        {
            var @params = new ArrayList {accountName, owner, active, memo};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Deposit to_vestings SPHTXs to vesting.
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="toVestings"></param>
        /// <returns></returns>
        public bool depositVesting(string accountName, ulong toVestings)
        {
            var @params = new ArrayList {accountName, toVestings};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Withdraw from_vestings vested SPHTXs.
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="fromVestings"></param>
        /// <returns></returns>
        public bool withdrawVestings(string accountName, ulong fromVestings)
        {
            var @params = new ArrayList {accountName, fromVestings};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Vote or unvote a witness.
        /// </summary>
        /// <param name="votingAccountName"></param>
        /// <param name="votedAccountName"></param>
        /// <param name="approve"></param>
        /// <returns></returns>
        public bool voteForWitness(string votingAccountName, string votedAccountName, string approve)
        {
            var @params = new ArrayList {votingAccountName, votedAccountName, approve};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Update an account to witness.Requires XXX vested SPHTX before updating.
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="url"></param>
        /// <param name="blockKey"></param>
        /// <returns></returns>
        public bool updateToWitness(string accountName, string url, byte[] blockKey)
        {
            var @params = new ArrayList {accountName, url, blockKey};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }

        /// <summary>
        /// Creates new account in the SophiaTX blockchain.
        /// </summary>
        /// <param name="registeringAccountName"></param>
        /// <param name="newAccountName"></param>
        /// <param name="owner"></param>
        /// <param name="active"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        public bool createAccount(string registeringAccountName, string newAccountName, Authority owner,
            Authority active, byte[] memo)
        {
            var @params = new ArrayList {registeringAccountName, newAccountName, owner, active, memo};
            var result = SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            return result == "true";
        }
    }
}