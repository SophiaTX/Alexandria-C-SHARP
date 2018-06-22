using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using Alexandria.net.Communication;
using Alexandria.net.Logging;
using Alexandria.net.Messaging.Responses.DTO;
using Alexandria.net.Settings;
using Newtonsoft.Json;

namespace Alexandria.net.API.WalletFunctions
{
    /// <inheritdoc />
    /// <para>
    /// Wallet Key Functions
    /// </para>
    public class Key : RpcConnection
    {
        private readonly ILogger _logger;
        private const string Libpath = "libalexandria";

        #region DllImports

        /// <summary>
        /// Creates a private key
        /// </summary>
        /// <param name="privateKey">byte[52] private_key</param>
        /// <param name="publickey">the public key</param>
        /// <returns>Returns true if success or false for failed try</returns>
        [DllImport(Libpath)]
        private static extern bool generate_private_key([MarshalAs(UnmanagedType.LPArray)] byte[] privateKey,
            [MarshalAs(UnmanagedType.LPArray)] byte[] publickey);

        [DllImport(Libpath)]
        private static extern bool get_transaction_digest([MarshalAs(UnmanagedType.LPStr)] string transaction,
            [MarshalAs(UnmanagedType.LPStr)] string chain_id,
            [MarshalAs(UnmanagedType.LPArray)] byte[] digest);

        [DllImport(Libpath)]
        private static extern bool sign_digest([MarshalAs(UnmanagedType.LPStr)] string digest,
            [MarshalAs(UnmanagedType.LPStr)] string privateKey, [MarshalAs(UnmanagedType.LPArray)] byte[] signedDigest);

        [DllImport(Libpath)]
        private static extern bool add_signature([MarshalAs(UnmanagedType.LPStr)] string transaction,
            [MarshalAs(UnmanagedType.LPStr)] string signature, [MarshalAs(UnmanagedType.LPArray)] byte[] signedTx);
        [DllImport(Libpath)]
        private static extern bool get_public_key([MarshalAs(UnmanagedType.LPStr)] string private_key, [MarshalAs(UnmanagedType.LPArray)]byte[] public_key);
        [DllImport(Libpath)]
        private static extern bool generate_key_pair_from_brain_key([MarshalAs(UnmanagedType.LPStr)] string brain_key, [MarshalAs(UnmanagedType.LPArray)]byte[] private_key, [MarshalAs(UnmanagedType.LPArray)]byte[] public_key);
        [DllImport(Libpath)]
        private static extern bool verify_signature([MarshalAs(UnmanagedType.LPStr)] string digest, [MarshalAs(UnmanagedType.LPStr)] string public_key, [MarshalAs(UnmanagedType.LPStr)] string signed_digest);
        [DllImport(Libpath)]
        private static extern bool encrypt_memo([MarshalAs(UnmanagedType.LPStr)] string memo, [MarshalAs(UnmanagedType.LPStr)] string private_key, [MarshalAs(UnmanagedType.LPStr)] string public_key, [MarshalAs(UnmanagedType.LPArray)]byte[] encrypted_memo );
        [DllImport(Libpath)]
        private static extern bool decrypt_memo([MarshalAs(UnmanagedType.LPStr)] string memo, [MarshalAs(UnmanagedType.LPStr)] string private_key, [MarshalAs(UnmanagedType.LPStr)] string public_key, [MarshalAs(UnmanagedType.LPArray)]byte[] decrypted_memo);
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public Key(IConfig config) :
            base(config)
        {
            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(LoggingType.Server, assemblyname);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ListKeys()
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var result = SendRequest(reqname);
                return result;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
         
        /// Generates private_key in WIF format based on random seed.
         
        /// </summary>
        /// <param name="privatekey">returns parameter of size 51</param>
        /// <param name="publickey">returns parameter of size 53</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public string GeneratePrivateKey(byte[] privatekey, byte[] publickey)
        {
            string result;
            try
            {
                result = generate_private_key(privatekey, publickey)
                    ? System.Text.Encoding.Default.GetString(publickey)
                    : string.Empty;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }

            return result;
        }

        /// <summary>
        /// Creates digest of JSON formatted transaction
        /// </summary>
        /// <param name="transaction">the transaction to digest</param>
        /// <param name="chainId">the id in the blockchain</param>
        /// <param name="digest">the digest bytes, returned digest of transaction (size 64)</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public string GetTransactionDigest(string transaction, string chainId, byte[] digest)
        {
            try
            {
                var result = get_transaction_digest(transaction, chainId, digest)
                    ? System.Text.Encoding.Default.GetString(digest)
                    : string.Empty;

                return result;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }

        }


        /// <summary>
        /// Creates a signature for the given private key and transaction digest
        /// </summary>
        /// <param name="digest">string digest</param>
        /// <param name="privatekey">string privatekey</param>
        /// <param name="signeddigest"> byte[] signeddigest, returns signature (size 130)</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public string SignDigest(string digest, string privatekey, byte[] signeddigest)
        {
            try
            {
                var result = sign_digest(digest, privatekey, signeddigest)
                    ? System.Text.Encoding.Default.GetString(signeddigest)
                    : string.Empty;

                return result;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }

        }

        /// <summary>
        /// Adds signature to JSON formatted transaction
        /// </summary>
        /// <param name="transaction">string transaction</param>
        /// <param name="signature">string signature</param>
        /// <param name="signedtx">byte[] signedtx, returned signed transaction (size variable, depends on size of transaction on input_)</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public SignedTransactionResponse AddSignature(string transaction, string signature, byte[] signedtx)
        {
            var trans = new Transaction(Config);
            try
            {
                var value = add_signature(transaction, signature, signedtx);
                if (!value) return null;

                var signedTransaction = System.Text.Encoding.Default.GetString(signedtx);

                var result = JsonConvert.DeserializeObject<SignedTransactionResponse>(signedTransaction);
                
                return result;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");

                throw;
            }

        }
        /// <summary>
         /// Returns public_key for given private_key
         /// </summary>
         /// <param name="privateKey">Private key in WIF format</param>
         /// <param name="publicKey">return paramter public key derived from private_key size 53</param>
         /// <returns>return paramter public key derived from private_key</returns>
        public string GetPublicKey(string privateKey, byte[] publicKey)
        {
            try
            {
                
                var result= get_public_key(privateKey, publicKey)
                    ? System.Text.Encoding.Default.GetString(publicKey)
                    : string.Empty;
                
                return result;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
            
        }
        /// <summary>
        /// Generates new private/public key pair from brian key.
        /// </summary>
        /// <param name="brain_key"></param>
        /// <param name="private_key"></param>
        /// <param name="public_key"></param>
        /// <returns></returns>
        public bool GenerateKeyPairFromBrainKey(string brain_key, byte[] private_key, byte[] public_key)
        {
            try
            {
                var result = generate_key_pair_from_brain_key(brain_key, private_key, public_key);
                var PublicKey= System.Text.Encoding.Default.GetString(public_key);
                var PrivateKey= System.Text.Encoding.Default.GetString(private_key);  
                    
                
                return result;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
            
        }
        /// <summary>
        /// Function for verifying signature base on digest and public key
        /// </summary>
        /// <param name="digest">digest that will be singed</param>
        /// <param name="public_key">corresponding public key to private_key used fo signing</param>
        /// <param name="signed_digest">digest singed by private_key</param>
        /// <returns>true if signature is correct</returns>
        public bool VeriFySignature(string digest,string public_key,string signed_digest)
        {
            try
            {
                var result = verify_signature(digest, public_key, signed_digest);
                  
                return result;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
            
        }
        /// <summary>
        /// Returns the encrypted memo
        /// </summary>
        /// <param name="memo">memo that should be encrypted</param>
        /// <param name="private_key">Private key of sender of memo</param>
        /// <param name="public_key">Public key of recipient</param>
        /// <param name="encrypted_memo">return value of encrypted memo</param>
        /// <returns>true if signature is correct</returns>
        public string EncryptMemo( string memo,  string private_key,  string public_key, byte[] encrypted_memo)
        {
            try
            {
                var result= encrypt_memo(memo, private_key, public_key,encrypted_memo)
                    ? System.Text.Encoding.Default.GetString(encrypted_memo)
                    : string.Empty;
                
                return result;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
            
        }
        /// <summary>
        /// Returns the decrypted memo if possible given private keys
        /// </summary>
        /// <param name="memo">memo that should be encrypted</param>
        /// <param name="private_key">Private key of recipient of memo</param>
        /// <param name="public_key">Public key of sender</param>
        /// <param name="decrypted_memo">decrypted memo</param>
        /// <returns>true if signature is correct</returns>
        public string DecryptMemo( string memo,  string private_key,  string public_key, byte[] decrypted_memo)
        {
            try
            {
                
                var result= decrypt_memo(memo, private_key, public_key,decrypted_memo)
                    ? System.Text.Encoding.Default.GetString(decrypted_memo)
                    : string.Empty;
                
                return result;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
            
        }
        /// <summary>
        /// Create a passphrase for users to remember easily and use ot to generate corresponding public and private keys
        /// </summary>
        /// <returns>Returns a passphrase</returns>
        public BrainKeySuggestion SuggestBrainKey()
        {
            try
            {
                
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var result = SendRequest(reqname);
                var contentdata = JsonConvert.DeserializeObject<BrainKeySuggestion>(result);
                return contentdata;
                
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        /// <summary>
        /// Normalizes the case of passphrase for correct key generation
        /// </summary>
        /// <param name="brainKey">distorted passphrase</param>
        /// <returns>Returns normalized Passphrase</returns>
        public string NormalizeBrainKey(string brainKey)
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name);
                var @params = new ArrayList {brainKey};
                var result = SendRequest(reqname,@params);
                return result;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        
    }
}