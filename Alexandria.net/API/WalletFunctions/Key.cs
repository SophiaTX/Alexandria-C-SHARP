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
    /// <para>
    /// Wallet Key Functions
    /// </para>
    public class Key : RpcConnection
    {
        private readonly ILogger _logger;
        private const string Libpath = "../../../../../Alexandria.net/libalexandria";

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
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name.ToLower());
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
        /// Generates Public and Private keys
        /// </summary>
        /// <param name="privatekey"></param>
        /// <param name="publickey"></param>
        /// <returns>Returns true if success or false for failed try</returns>
        public string GeneratePrivateKey(byte[] privatekey, byte[] publickey)
        {
            string result;
            try
            {
                result = generate_private_key(privatekey, publickey)
                    ? System.Text.Encoding.Default.GetString(privatekey)
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
        /// Gets the transaction digest
        /// </summary>
        /// <param name="transaction">the transaction to digest</param>
        /// <param name="digest">the digest bytes</param>
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
        /// <param name="signeddigest"> byte[] signeddigest</param>
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
        /// Signs the given transactions and returns true for success
        /// </summary>
        /// <param name="transaction">string transaction</param>
        /// <param name="signature">string signature</param>
        /// <param name="signedtx">byte[] signedtx</param>
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
                trans.broadcast_transaction(result);
                return result;
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");

                throw;
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string SuggestBrainKey()
        {
            try
            {
                var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name.ToLower());
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
        /// 
        /// </summary>
        public void NormalizeBrainKey()
        {
            var reqname = CSharpToCpp.GetValue(MethodBase.GetCurrentMethod().Name.ToLower());
            //throw new NotImplementedException();
        }
    }
}