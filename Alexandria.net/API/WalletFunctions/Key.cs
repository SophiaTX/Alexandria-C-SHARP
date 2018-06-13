using System.Collections;
using System.Globalization;
using System.Reflection;
using Alexandria.net.Messaging.Responses.DTO;
using Newtonsoft.Json;

namespace Alexandria.net.API.WalletFunctions
{
    public partial class Wallet // Key
    {
        /// <summary>
        /// Gets the user private key
        /// </summary>
        /// <param name="pubkey">the associated public key</param>
        /// <returns>the private key</returns>
        public string get_private_key(string pubkey)
        {
            var @params = new ArrayList {pubkey};
            return SendRequest(MethodBase.GetCurrentMethod().Name, @params).ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Get the WIF Private key corresponding To a Public key. The Private key must already be In the wallet.
        /// </summary>
        /// <param name="account">the account to use</param>
        /// <param name="role">active | owner | posting | memo </param>
        /// <param name="password">the account password</param>
        /// <returns>the private key</returns>
        public KeyFromPassword get_private_key_from_password(string account, string role, string password)
        {
            var @params = new ArrayList {account, role, password};
            var result= SendRequest(MethodBase.GetCurrentMethod().Name, @params);
            var contentdata = JsonConvert.DeserializeObject<KeyFromPassword>(result);
            return contentdata;
        }
 
        /// <summary>
        /// Imports a WIF Private Key into the wallet To be used To sign transactionsby an account.
        /// </summary>
        /// <param name="wifKey">the WIF Private Key To import</param>
        /// <returns></returns>
        // todo - this was returning bool, check and update code accordingly
        public string import_key(string wifKey)
        {
            var @params = new ArrayList {wifKey};
            return SendRequest(MethodBase.GetCurrentMethod().Name, @params);
        }
        
        /// <summary>
        /// Dumps all Private keys owned by the wallet.
        /// The keys are printed In WIF format. You can import these keys into another wallet using 'import_key()' 
        /// </summary>
        /// <returns>a map containing the Private keys, indexed by their Public key</returns>
        public string list_keys()
        {
            return SendRequest(MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// Transforms a brain key To reduce the chance Of errors When re-entering the
        /// key from memory.
        /// This takes a user-supplied brain key And normalizes it into the form used
        /// For generating private keys. In particular, this upper-cases all ASCII
        /// characters And collapses multiple spaces into one.
        /// </summary>
        /// <param name="key">the brain key As supplied by the user </param>
        /// <returns>the brain key In its normalized form</returns>
        public string normalize_brain_key(string key)
        {
            var @params = new ArrayList {key};
            return SendRequest(MethodBase.GetCurrentMethod().Name, @params).ToString(CultureInfo.InvariantCulture);
        }
        

        /// <summary>
        /// Suggests a safe brain key To use For creating your account.
        /// create_account_with_brain_key()' requires you to specify a 'brain key', a
        /// Long passphrase that provides enough entropy to generate cyrptographic
        /// keys. This function will suggest a suitably random string that should be
        /// easy to write down (And, with effort, memorize).
        /// </summary>
        /// <returns>the suggested brain key</returns>
        public string suggest_brain_key()
        {
            return SendRequest(MethodBase.GetCurrentMethod().Name).ToString(CultureInfo.InvariantCulture);
        }
        
        /// <summary>
        /// Generates the Private Keys
        /// </summary>
        /// <param name="privatekey">the key bytes</param>
        /// <returns>true if generated</returns>
        public bool generate_private_key_c(byte[] privatekey)
        {
            return generate_private_key(privatekey);
            
        }

        /// <summary>
        /// Gets the transaction digest
        /// </summary>
        /// <param name="transaction">the transaction to digest</param>
        /// <param name="digest">the digest bytes</param>
        /// <returns>true if successful</returns>
        public bool get_transaction_digest_c(string transaction, byte[] digest)
        {
            return get_transaction_digest(transaction, digest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="privatekey"></param>
        /// <param name="signeddigest"></param>
        /// <returns></returns>
        public bool sign_digest_c(string digest, string privatekey, byte[] signeddigest)
        {
            return sign_digest(digest, privatekey, signeddigest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="signature"></param>
        /// <param name="signedtx"></param>
        /// <returns></returns>
        public bool add_signature_c(string transaction, string signature, byte[] signedtx)
        {
            return add_signature(transaction, signature, signedtx);
        }
        
    }
}