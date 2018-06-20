using System;
using System.Collections;
using System.IO;
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
    public class Key :RpcConnection
    {
        private readonly ILogger _logger;
        //todo - lib path needs to be solved
        private const string Libpath = "../../../../../Alexandria.net/libalexandria";
        #region DllImports
        
        [DllImport(Libpath)]
        private static extern bool generate_private_key([MarshalAs(UnmanagedType.LPArray)]byte[] privateKey, [MarshalAs(UnmanagedType.LPArray)]byte[] publickey);
        
        [DllImport(Libpath)]
        private static extern bool get_transaction_digest([MarshalAs(UnmanagedType.LPStr)] string transaction,[MarshalAs(UnmanagedType.LPStr)] string chain_id,
            [MarshalAs(UnmanagedType.LPArray)] byte[] digest);
        
        
        [DllImport(Libpath)]
        private static extern bool sign_digest([MarshalAs(UnmanagedType.LPStr)] string digest,
            [MarshalAs(UnmanagedType.LPStr)] string privateKey, [MarshalAs(UnmanagedType.LPArray)] byte[] signedDigest);        
        
        
        [DllImport(Libpath)]
        private static extern bool add_signature([MarshalAs(UnmanagedType.LPStr)] string transaction,
            [MarshalAs(UnmanagedType.LPStr)] string signature, [MarshalAs(UnmanagedType.LPArray)] byte[] signedTx);
        #endregion

       
        public Key(IConfig config) :
            base(config)
        {
            

            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(loggingType.server, assemblyname);
            
        }
        
        
        /// <summary>
        /// Generates Public and Private keys
        /// </summary>
        /// <param name="privatekey"></param>
        /// <param name="publickey"></param>
        /// <returns>Returns true if success or false for failed try</returns>
        public string generate_private_key_c(byte[] privatekey,byte[] publickey)
        {
            try
            {
               
                var result = generate_private_key(privatekey, publickey);
                var PublicKey = System.Text.Encoding.Default.GetString(publickey);
                var PrivateKey = System.Text.Encoding.Default.GetString(privatekey);
                
                return PublicKey;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
           
        }

        /// <summary>
        /// Gets the transaction digest
        /// </summary>
        /// <param name="transaction">the transaction to digest</param>
        /// <param name="digest">the digest bytes</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public string get_transaction_digest_c(string transaction, string chainId, byte[] digest)
        {
            try
            {
                var result= get_transaction_digest(transaction,chainId, digest)?
                    System.Text.Encoding.Default.GetString(digest)
                    :String.Empty;
                
                return result;
            }
            catch(Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw ;
            }
            
        }
        

        /// <summary>
        /// Creates a signature for the given private key and transaction digest
        /// </summary>
        /// <param name="digest">string digest</param>
        /// <param name="privatekey">string privatekey</param>
        /// <param name="signeddigest"> byte[] signeddigest</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public string sign_digest_c(string digest, string privatekey, byte[] signeddigest)
        {
            try
            {
                var result= sign_digest(digest, privatekey, signeddigest)
                    ? System.Text.Encoding.Default.GetString(signeddigest)
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
        /// Signs the given transactions and returns true for success
        /// </summary>
        /// <param name="transaction">string transaction</param>
        /// <param name="signature">string signature</param>
        /// <param name="signedtx">byte[] signedtx</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public SignedTransactionResponse add_signature_c(string transaction, string signature, byte[] signedtx)
        {
            Transaction newTransaction=new Transaction(Config);
            try
            {
                var value = add_signature(transaction, signature, signedtx);
                //if (!value) return null;

                var signedTransaction = System.Text.Encoding.Default.GetString(signedtx);
                
                var result = JsonConvert.DeserializeObject<SignedTransactionResponse>(signedTransaction);
                newTransaction.broadcast_transaction(result);
                return result;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                
                throw;
            }
            
        }
         

        public string suggest_brain_key()
        {
            try
            {
               
                var result = SendRequest(MethodBase.GetCurrentMethod().Name);
                return result;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }

        public void normalize_brain_key()
        {
            //throw new NotImplementedException();
        }

        
    }
}