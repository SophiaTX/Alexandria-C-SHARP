using System.Collections;
using System.Globalization;
using System.Reflection;
using Newtonsoft.Json.Linq;

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
            return call_api_value(MethodBase.GetCurrentMethod().Name, @params).ToString(CultureInfo.InvariantCulture);
        }

        // Get the WIF Private key corresponding To a Public key. The Private key must already be In the wallet.
        // Parameters:
        // role: - active | owner | posting | memo 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <param name="role"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public JObject get_private_key_from_password(string account, string role, string password)
        {
            var @params = new ArrayList {account, role, password};
            return call_api(MethodBase.GetCurrentMethod().Name, @params);
        }

        //    Imports a WIF Private Key into the wallet To be used To sign transactionsby an account.
        //
        //    example: import_key 5KQwrPbwdL6PhXujxW37FSSQZ1JiwsST4cqQzDeyXtP79zkvFD3
        //
        //    Parameters:
        //         wif_key: the WIF Private Key To import 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wifKey"></param>
        /// <returns></returns>
        public bool import_key(string wifKey)
        {
            var @params = new ArrayList {wifKey};
            return (bool) call_api_value(MethodBase.GetCurrentMethod().Name, @params);
        }
        
        /// <summary>
        /// Dumps all Private keys owned by the wallet.
        /// The keys are printed In WIF format. You can import these keys into another wallet using 'import_key()' 
        /// </summary>
        /// <returns>a map containing the Private keys, indexed by their Public key</returns>
        public JToken list_keys()
        {
            return call_api_token(MethodBase.GetCurrentMethod().Name);
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
            return call_api_value(MethodBase.GetCurrentMethod().Name, @params).ToString(CultureInfo.InvariantCulture);
        }
        

        /// <summary>
        /// Suggests a safe brain key To use For creating your account.
        /// create_account_with_brain_key()' requires you to specify a 'brain key', a
        /// Long passphrase that provides enough entropy to generate cyrptographic
        // /keys. This function will suggest a suitably random string that should be
        /// easy to write down (And, with effort, memorize).
        /// </summary>
        /// <returns>the suggested brain key</returns>
        public string suggest_brain_key()
        {
            return call_api_value(MethodBase.GetCurrentMethod().Name).ToString(CultureInfo.InvariantCulture);
        }
        
        public bool generate_private_key_c(byte[] privatekey)
        {
            return Wallet.generate_private_key(privatekey);
        }

        public bool get_transaction_digest_c(string transaction, byte[] digest)
        {
            return Wallet.get_transaction_digest(transaction, digest);
        }

        public bool sign_digest_c(string digest, string privatekey, byte[] signeddigest)
        {
            return Wallet.sign_digest(digest, privatekey, signeddigest);
        }

        public bool add_signature_c(string transaction, string signature, byte[] signedtx)
        {
            return Wallet.add_signature(transaction, signature, signedtx);
        }
        
    }
}