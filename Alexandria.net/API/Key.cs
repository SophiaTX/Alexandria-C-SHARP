using System.Collections;
using System.Globalization;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Alexandria.net.API
{
    public partial class Wallet // Key
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pubkey"></param>
        /// <returns></returns>
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
        
        //    Transforms a brain key To reduce the chance Of errors When re-entering the
        //    key from memory.
        //
        //    This takes a user-supplied brain key And normalizes it into the form used
        //    For generating private keys. In particular, this upper-cases all ASCII
        //    characters And collapses multiple spaces into one.
        //
        //    Parameters:
        //     key: the brain key As supplied by the user 
        //
        //    Returns
        //        the brain key In its normalized form
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string normalize_brain_key(string key)
        {
            var @params = new ArrayList {key};
            return call_api_value(MethodBase.GetCurrentMethod().Name, @params).ToString(CultureInfo.InvariantCulture);
        }
        
        //Suggests a safe brain key To use For creating your account.
        //'create_account_with_brain_key()' requires you to specify a 'brain key', a
        //Long passphrase that provides enough entropy to generate cyrptographic
        //keys. This function will suggest a suitably random string that should be
        //easy to write down (And, with effort, memorize).
        //
        //Returns
        //    a suggested brain_key
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string suggest_brain_key()
        {
            return call_api_value(MethodBase.GetCurrentMethod().Name).ToString(CultureInfo.InvariantCulture);
        }
    }
}