using System;
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
    /// <summary>
    /// </summary>
    public class Key :RpcConnection
    {
        private readonly ILogger _logger;
        //todo - lib path needs to be solved
        private const string Libpath = "/Users/sanjivjha/RiderProjects/Alexandria/Alexandria.net/libalexandria.dylib";
        #region DllImports
        /// <summary>
        /// Create a private key
        /// </summary>
        /// <param name="privateKey">byte[52] private_key</param>
        /// <returns>Returns true if success or false for failed try</returns>
        [DllImport(Libpath)]
        private static extern bool generate_private_key([MarshalAs(UnmanagedType.LPArray)]byte[] privateKey);
        /// <summary>
        /// Create a Transaction digest of the given transaction
        /// </summary>
        /// <param name="transaction">string transaction</param>
        /// <param name="digest">byte[] digest</param>
        /// <returns>Returns true if success or false for failed try</returns>
        [DllImport(Libpath)]
        private static extern bool get_transaction_digest([MarshalAs(UnmanagedType.LPStr)] string transaction,
            [MarshalAs(UnmanagedType.LPArray)] byte[] digest);
        
        /// <summary>
        /// Creates signamture for the given transaction and digest
        /// </summary>
        /// <param name="digest">string digest</param>
        /// <param name="privateKey">string private_key</param>
        /// <param name="signedDigest">byte[] signed_digest</param>
        /// <returns>Returns true if success or false for failed try</returns>
        [DllImport(Libpath)]
        private static extern bool sign_digest([MarshalAs(UnmanagedType.LPStr)] string digest,
            [MarshalAs(UnmanagedType.LPStr)] string privateKey, [MarshalAs(UnmanagedType.LPArray)] byte[] signedDigest);        
        
        /// <summary>
        /// Sign a transcation using the given signature
        /// </summary>
        /// <param name="transaction">string transaction</param>
        /// <param name="signature">string signature</param>
        /// <param name="signedTx">byte[] signed_tx</param>
        /// <returns>Returns true if success or false for failed try</returns>
        [DllImport(Libpath)]
        private static extern bool add_signature([MarshalAs(UnmanagedType.LPStr)] string transaction,
            [MarshalAs(UnmanagedType.LPStr)] string signature, [MarshalAs(UnmanagedType.LPArray)] byte[] signedTx);
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
        /// Generates the Private Keys
        /// </summary>
        /// <param name="privatekey">the key bytes</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public string generate_private_key_c(byte[] privatekey)
        {
            try
            {
                return generate_private_key(privatekey) ? System.Text.Encoding.Default.GetString(privatekey) : string.Empty;
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
        public bool get_transaction_digest_c(string transaction, byte[] digest)
        {
            try
            {
                return get_transaction_digest(transaction, digest);
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
                return sign_digest(digest, privatekey, signeddigest)
                    ? System.Text.Encoding.Default.GetString(signeddigest)
                    : string.Empty;
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
        public SendResponseResult add_signature_c(string transaction, string signature, byte[] signedtx)
        {
            SendResponseResult result;
            try
            {
                var value = add_signature(transaction, signature, signedtx);
                if (!value) return null;
                result = JsonConvert.DeserializeObject<SendResponseResult>(
                    System.Text.Encoding.Default.GetString(signedtx));
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                
                throw;
            }
            return result;
        }

    }
}