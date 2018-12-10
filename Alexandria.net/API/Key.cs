using System.Collections.Generic;
using System.Linq;
 using System.Reflection;
using Alexandria.net.Logging;
 using Alexandria.net.Mapping;
 using Alexandria.net.Messaging.Responses;
using Alexandria.net.Settings;
using Newtonsoft.Json;

namespace Alexandria.net.API
{
    /// <inheritdoc />
    /// <para>
    /// Sophia Blockchain Key functions
    /// </para>
    public class Key : ApiBase
    {

        #region Constructor

        /// <summary>
        /// Key Constructor
        /// </summary>
        /// <param name="config">the Configuration parameters for the endpoint and ports</param>
        /// <param name="methodMapperCollection"></param>
        /// 
        public Key(IConfig config, List<MethodMapper> methodMapperCollection) :
            base(methodMapperCollection)
        {
            Logger = new Logger(config, Assembly.GetExecutingAssembly().GetName().Name);
        }
        #endregion
        
        
        /// <summary>
        /// gets the list of keys
        /// </summary>
        /// <returns>the keys result</returns>
        public string ListKeys()
        {
            var @params = ParamCollection.Single(s => s.MethodName == "");
            var result = SendRequest(@params.BlockChainMethodName);
            return result;
        }

        /// <summary>
        /// Generates private_key in WIF format based on random seed.
        /// </summary>
        /// <param name="privatekey">returns parameter of size 51</param>
        /// <param name="publickey">returns parameter of size 53</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public KeyResponse GeneratePrivateKey(byte[] privatekey, byte[] publickey)
        {

            KeyResponse result = null;
            if (generate_private_key(privatekey, publickey))
            {
                result = new KeyResponse
                {
                    PrivateKey = System.Text.Encoding.Default.GetString(privatekey),
                    PublicKey = System.Text.Encoding.Default.GetString(publickey)
                };
            }

            return result;
        }


        /// <summary>
        /// Creates digest of JSON formatted transaction
        /// </summary>
        /// <param name="transaction">the transaction to digest</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public GetTransactionDigestResponse GetTransactionDigestServer(string transaction)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "GetTransactionDigestServer");
            var data = @params.GetObjectAndJsonValue(transaction);

            var result= SendRequest(@params.BlockChainMethodName, data);
            var content = JsonConvert.DeserializeObject<GetTransactionDigestResponse>(result);
            return content;
        }
        
        
        

        /// <summary>
        /// Adds signature to JSON formatted transaction
        /// </summary>
        /// <param name="transaction">string transaction</param>
        /// <param name="signature">string signature</param>
        /// <returns>Returns true if success or false for failed try</returns>
        public SignedTransactionResponse AddSignatureServer(TransactionResponse transaction, string signature)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "AddSignatureServer");
            var data = @params.GetObjectAndJsonValue(transaction.Result, signature);
            
            var signedTransaction = SendRequest(@params.BlockChainMethodName, data);
            var result = JsonConvert.DeserializeObject<SignedTransactionResponse>(signedTransaction);
            return result;
        }

        /// <summary>
        /// Returns public_key for given private_key
        /// </summary>
        /// <param name="privateKey">Private key in WIF format</param>
        /// <param name="publicKey">return paramter public key derived from private_key size 53</param>
        /// <returns>return paramter public key derived from private_key</returns>
        public string GetPublicKey(string privateKey, byte[] publicKey)
        {
            var result = get_public_key(privateKey, publicKey)
                ? System.Text.Encoding.Default.GetString(publicKey)
                : "Please enter correct a private key";

            return result;
        }

        /// <summary>
        /// Generates new private/public key pair from brian key.
        /// </summary>
        /// <param name="brainKey"></param>
        /// <param name="privateKey"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        public KeyResponse GenerateKeyPairFromBrainKey(string brainKey, byte[] privateKey, byte[] publicKey)
        {
            KeyResponse result = null;
            if (generate_key_pair_from_brain_key(brainKey, privateKey, publicKey))
            {
                result = new KeyResponse
                {
                    PrivateKey = System.Text.Encoding.Default.GetString(privateKey),
                    PublicKey = System.Text.Encoding.Default.GetString(publicKey)
                };
            }

            return result;
        }

        /// <summary>
        /// Function for verifying signature base on digest and public key
        /// </summary>
        /// <param name="digest">digest that will be singed</param>
        /// <param name="publicKey">corresponding public key to private_key used fo signing</param>
        /// <param name="signedDigest">digest singed by private_key</param>
        /// <returns>true if signature is correct</returns>
        public bool VerifySignature(string digest, string publicKey, string signedDigest)
        {
            var result = verify_signature(digest, publicKey, signedDigest);
            return result;
        }

        /// <summary>
        /// Returns the encrypted memo
        /// </summary>
        /// <param name="memo">memo that should be encrypted</param>
        /// <param name="privateKey">Private key of sender of memo</param>
        /// <param name="publicKey">Public key of recipient</param>
        /// <param name="encryptedMemo">return value of encrypted memo, byte[1024]</param>
        /// <returns>true if signature is correct</returns>
        public string EncryptMemo(string memo, string privateKey, string publicKey, byte[] encryptedMemo)
        {
            var result = encrypt_memo(memo, privateKey, publicKey, encryptedMemo)
                ? System.Text.Encoding.Default.GetString(encryptedMemo)
                : string.Empty;

            return result;
        }

        /// <summary>
        /// Returns the decrypted memo if possible given private keys
        /// </summary>
        /// <param name="memo">memo that should be encrypted</param>
        /// <param name="privateKey">Private key of recipient of memo</param>
        /// <param name="publicKey">Public key of sender</param>
        /// <param name="decryptedMemo">decrypted memo, byte[1024]</param>
        /// <returns>true if signature is correct</returns>
        public string DecryptMemo(string memo, string privateKey, string publicKey, byte[] decryptedMemo)
        {
            var result = decrypt_memo(memo, privateKey, publicKey, decryptedMemo)
                ? System.Text.Encoding.Default.GetString(decryptedMemo)
                : string.Empty;

            return result;
        }
        /// <summary>
        /// Encode the memo in base64 format
        /// </summary>
        /// <param name="input">data to be formatted</param>
        /// <param name="output">base64 formatted result</param>
        /// <returns>base64 result or empty string</returns>
        public string EncodeBase64(string input, byte[] output)
        {
            var result = base64_encode(input, output)
                ? System.Text.Encoding.Default.GetString(output)
                : string.Empty;

            return result;
        }
        /// <summary>
        /// Decode the memo in base64 format
        /// </summary>
        /// <param name="input">Base64 fromatted data</param>
        /// <param name="output">Decoded data</param>
        /// <returns>Decoded data or empty string</returns>
        public string DecodeBase64(string input, byte[] output)
        {
            var result = base64_decode(input, output)? System.Text.Encoding.Default.GetString(output)
                : string.Empty;

            return result;
        }

        /// <summary>
        /// Create a pass-phrase for users to remember easily and use ot to generate
        /// corresponding public and private keys
        /// </summary>
        /// <returns>Returns a pass-phrase</returns>
        public BrainKeySuggestion SuggestBrainKey()
        {
            var @params = ParamCollection.Single(s => s.MethodName == "SuggestBrainKey");
            var result = SendRequest(@params.BlockChainMethodName);
            var content = JsonConvert.DeserializeObject<BrainKeySuggestion>(result);
            return content;
        }

        /// <summary>
        /// Normalizes the case of passphrase for correct key generation
        /// </summary>
        /// <param name="brainKey">distorted passphrase</param>
        /// <returns>Returns normalized Passphrase</returns>
        public string NormalizeBrainKey(string brainKey)
        {
            var @params = ParamCollection.Single(s => s.MethodName == "NormalizeBrainKey");
            var data = @params.GetObjectAndJsonValue(brainKey);
           
            var result = SendRequest(@params.BlockChainMethodName, data);
            return result;
        }
    }
}