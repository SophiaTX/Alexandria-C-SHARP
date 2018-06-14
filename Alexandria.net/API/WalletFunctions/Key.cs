using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using Alexandria.net.Communication;
using Alexandria.net.Messaging.Responses.DTO;
using Newtonsoft.Json;

namespace Alexandria.net.API.WalletFunctions
{
    public class Key :RpcConnection
    {
        #region DllImports
        [DllImport("/Users/sanjivjha/RiderProjects/Alexandria/Alexandria.net/Lib/libalexandria.dylib")]
        private static extern bool generate_private_key([MarshalAs(UnmanagedType.LPArray)]byte[] private_key);

        [DllImport("/Users/sanjivjha/RiderProjects/Alexandria/Alexandria.net/Lib/libalexandria.dylib")]
        private static extern bool get_transaction_digest([MarshalAs(UnmanagedType.LPStr)] string transaction,
            [MarshalAs(UnmanagedType.LPArray)] byte[] digest);

        [DllImport("/Users/sanjivjha/RiderProjects/Alexandria/Alexandria.net/Lib/libalexandria.dylib")]
        private static extern bool sign_digest([MarshalAs(UnmanagedType.LPStr)] string digest,
            [MarshalAs(UnmanagedType.LPStr)] string private_key, [MarshalAs(UnmanagedType.LPArray)] byte[] signed_digest);        
        
        [DllImport("/Users/sanjivjha/RiderProjects/Alexandria/Alexandria.net/Lib/libalexandria.dylib")]
        private static extern bool add_signature([MarshalAs(UnmanagedType.LPStr)] string transaction,
            [MarshalAs(UnmanagedType.LPStr)] string signature, [MarshalAs(UnmanagedType.LPArray)] byte[] signed_tx);
        #endregion


        public Key(string hostname = "127.0.0.1", ushort port = 8091, string api = "/rpc", string version = "2.0") :
            base(hostname, port, api, version)
        {
            //todo - solve the loading of the dll
            //AppDomain.CurrentDomain.BaseDirectory
        }

        /// <summary>
        /// Generates the Private Keys
        /// </summary>
        /// <param name="privatekey">the key bytes</param>
        /// <returns>true if generated</returns>
        public string generate_private_key_c(byte[] privatekey)
        {
            return generate_private_key(privatekey) ? System.Text.Encoding.Default.GetString(privatekey) : string.Empty;
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
        public string sign_digest_c(string digest, string privatekey, byte[] signeddigest)
        {
            return sign_digest(digest, privatekey, signeddigest)
                ? System.Text.Encoding.Default.GetString(signeddigest)
                : string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="signature"></param>
        /// <param name="signedtx"></param>
        /// <returns></returns>
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return result;
        }

    }
}

//todo - logging needs to be implemented