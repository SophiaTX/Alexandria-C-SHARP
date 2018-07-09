using System;
using System.IO;
using System.Reflection;
using Alexandria.abapwrapper.API;
using Alexandria.abapwrapper.Enums;
using Alexandria.abapwrapper.Logging;
using Alexandria.abapwrapper.Messaging.Responses.DTO;
using Alexandria.abapwrapper.Settings;
using Alexandria.net.Messaging.Responses.DTO;
using Newtonsoft.Json;

namespace Alexandria.abapwrapper
{
    class Program
    {
        private readonly ILogger _logger;
        private readonly Key _key;

        public Program()
        {
            _logger = new Logger(LoggingType.File, Assembly.GetExecutingAssembly().GetName().Name);
            var config = LoadJson<Config>("config.json");
            if (config != null)
            {
                config.Hostname = "195.48.9.208";
                config.DaemonPort = 8095;
                config.WalletPort = 8096;

                _key = new Key(config);
            }
            else
            {
                var logger = new Logger(LoggingType.Server, Assembly.GetExecutingAssembly().GetName().Name);
                logger.WriteError("Error with the config file");
            }
        }

        static void Main(string[] args)
        {
        }

        private static T LoadJson<T>(string filename)
        {
            try
            {
                var fullfilename = $"{AssemblyDirectory}/{filename}";
                if (File.Exists(fullfilename))
                {
                    return JsonConvert.DeserializeObject<T>(File.ReadAllText(fullfilename));
                }

                var config = new Config
                {
                    LoggingType = LoggingType.File,
                    BuildMode = BuildMode.Prod,
                    Hostname = "195.48.9.208",
                    DaemonPort = 8095,
                    WalletPort = 8096,
                    Api = "/rpc",
                    Version = "2.0"
                };
                File.WriteAllText(fullfilename, JsonConvert.SerializeObject(config));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return default(T);
        }

        private static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ListKeys()
        {
            try
            {
                return _key.ListKeys();
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
        public KeyResponse GeneratePrivateKey(byte[] privatekey, byte[] publickey)
        {
            try
            {
                return _key.GeneratePrivateKey(privatekey, publickey);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
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
                return _key.GetTransactionDigest(transaction, chainId, digest);
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
                return _key.SignDigest(digest, privatekey, signeddigest);
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
            try
            {
                return AddSignature(transaction, signature, signedtx);
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
                return _key.GetPublicKey(privateKey, publicKey);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
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
            try
            {
                return GenerateKeyPairFromBrainKey(brainKey, privateKey, publicKey);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
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
            try
            {
                return _key.VerifySignature(digest, publicKey, signedDigest);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
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
            try
            {
                return _key.EncryptMemo(memo, privateKey, publicKey, encryptedMemo);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }

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
            try
            {
                return _key.DecryptMemo(memo, privateKey, publicKey, decryptedMemo);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
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
                return SuggestBrainKey();
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
                return NormalizeBrainKey(brainKey);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Message:{ex.Message} | StackTrace:{ex.StackTrace}");
                throw;
            }
        }
    }
}