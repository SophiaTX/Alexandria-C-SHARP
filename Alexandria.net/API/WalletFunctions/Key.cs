using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Alexandria.net.Communication;
using Alexandria.net.Logging;
using Alexandria.net.Messaging.Responses.DTO;
using Newtonsoft.Json;

namespace Alexandria.net.API.WalletFunctions
{
    public class Key :RpcConnection
    {
        private readonly ILogger _logger;
        private const string libpath = "/Users/sanjivjha/RiderProjects/Alexandria/Alexandria.net/libalexandria.dylib";
        #region DllImports
        /// <summary>
        /// Create a private key
        /// </summary>
        /// <param name="private_key">byte[52] private_key</param>
        /// <returns>Returns true if success or false for failed try</returns>
        [DllImport(libpath)]
        private static extern bool generate_private_key([MarshalAs(UnmanagedType.LPArray)]byte[] private_key);
        /// <summary>
        /// Create a Transaction digest of the given transaction
        /// </summary>
        /// <param name="transaction">string transaction</param>
        /// <param name="digest">byte[] digest</param>
        /// <returns>Returns true if success or false for failed try</returns>
        [DllImport(libpath)]
        private static extern bool get_transaction_digest([MarshalAs(UnmanagedType.LPStr)] string transaction,
            [MarshalAs(UnmanagedType.LPArray)] byte[] digest);
        
        /// <summary>
        /// Creates signamture for the given transaction and digest
        /// </summary>
        /// <param name="digest">string digest</param>
        /// <param name="private_key">string private_key</param>
        /// <param name="signed_digest">byte[] signed_digest</param>
        /// <returns>Returns true if success or false for failed try</returns>
        [DllImport(libpath)]
        private static extern bool sign_digest([MarshalAs(UnmanagedType.LPStr)] string digest,
            [MarshalAs(UnmanagedType.LPStr)] string private_key, [MarshalAs(UnmanagedType.LPArray)] byte[] signed_digest);        
        
        /// <summary>
        /// Sign a transcation using the given signature
        /// </summary>
        /// <param name="transaction">string transaction</param>
        /// <param name="signature">string signature</param>
        /// <param name="signed_tx">byte[] signed_tx</param>
        /// <returns>Returns true if success or false for failed try</returns>
        [DllImport(libpath)]
        private static extern bool add_signature([MarshalAs(UnmanagedType.LPStr)] string transaction,
            [MarshalAs(UnmanagedType.LPStr)] string signature, [MarshalAs(UnmanagedType.LPArray)] byte[] signed_tx);
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        /// <param name="api"></param>
        /// <param name="version"></param>
        public Key(string hostname = "127.0.0.1", ushort port = 8091, string api = "/rpc", string version = "2.0") :
            base(hostname, port, api, version)
        {
            
            var assemblyname = Assembly.GetExecutingAssembly().GetName().Name;
            _logger = new Logger(loggingType.server, assemblyname);
            //todo - solve the loading of the dll
            //AppDomain.CurrentDomain.BaseDirectory
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
                _logger.WriteError(ex.Message);
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
                _logger.WriteError(ex.Message);
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
                _logger.WriteError(ex.Message);
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
            SendResponseResult result = null;
            try
            {
                var value = add_signature(transaction, signature, signedtx);
                if (!value) return null;
                result = JsonConvert.DeserializeObject<SendResponseResult>(
                    System.Text.Encoding.Default.GetString(signedtx));
            }
            catch (Exception ex)
            {
                _logger.WriteError(ex.Message);
                
                throw;
            }
            return result;
        }

    }
}

//todo - logging needs to be implemented